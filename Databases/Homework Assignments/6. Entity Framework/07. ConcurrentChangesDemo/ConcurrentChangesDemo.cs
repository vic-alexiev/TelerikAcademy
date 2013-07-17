using NorthwindModels;
using System;
using System.Linq;
using System.Threading;
using System.Transactions;

/// <summary>
/// Based on http://www.ladislavmrnka.com/2012/09/entity-framework-and-pessimistic-concurrency/
/// </summary>
internal class ConcurrentChangesDemo
{
    private static void PrintRegionDescription(int regionId)
    {
        using (var context = new NorthwindEntities())
        {
            Console.WriteLine("Current description = {0}",
                context.Regions.First(r => r.RegionID == regionId).RegionDescription);
        }
    }

    private static void PrintError(Exception e)
    {
        while (e != null)
        {
            Console.WriteLine(e.Message);
            e = e.InnerException;
        }
    }

    private static Region GetRegionById(NorthwindEntities context, int regionId)
    {
        return context.Regions.SqlQuery(
            string.Format(@"SELECT TOP 1 RegionID,
                                   RegionDescription
                              FROM Region WITH (UPDLOCK)
                             WHERE RegionID = {0}", regionId)).Single();
    }

    private static void RunTest(IsolationLevel isolationLevel)
    {
        // Handles are used only to wait for both workers to complete
        var handles = new WaitHandle[] {
            new ManualResetEvent(false),
            new ManualResetEvent(false)
        };

        var options = new TransactionOptions
        {
            IsolationLevel = isolationLevel,
            Timeout = new TimeSpan(0, 0, 0, 10)
        };

        // Worker's job
        WaitCallback job = state =>
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
                {
                    using (var context = new NorthwindEntities())
                    {
                        var region = GetRegionById(context, 4);
                        Console.WriteLine("Updating description");
                        region.RegionDescription = region.RegionDescription.Trim() + " updated";
                        Console.WriteLine("Saving");
                        context.SaveChanges(); // Save changes to DB
                    }

                    scope.Complete(); // Commit transaction
                    Console.WriteLine("Persisted");
                }
            }
            catch (Exception e)
            {
                PrintError(e);
            }
            finally
            {
                // Signal to the main thread that the worker has completed
                ((ManualResetEvent)state).Set();
            }
        };

        // Run workers
        ThreadPool.QueueUserWorkItem(job, handles[0]);
        ThreadPool.QueueUserWorkItem(job, handles[1]);

        // Wait for both workers to complete
        WaitHandle.WaitAll(handles);
    }

    private static void Main()
    {
        PrintRegionDescription(4); // Get value before tests
        // Run test with specified isolation level
        RunTest(IsolationLevel.Serializable);
        PrintRegionDescription(4); // Get value after tests
    }
}
