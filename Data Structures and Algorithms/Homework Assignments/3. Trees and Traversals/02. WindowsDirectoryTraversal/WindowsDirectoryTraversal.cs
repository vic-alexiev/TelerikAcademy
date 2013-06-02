using System;
using System.IO;
using System.Reflection;
using System.Text;

public class WindowsDirectoryTraversal
{
    private static readonly string WindowsPath = Environment.GetEnvironmentVariable("windir");
    private static readonly string SearchPattern = "*.exe";
    private static StringBuilder log = new StringBuilder();

    public static string Location
    {
        get
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }

    /// <summary>
    /// The original source code can be found at
    /// http://msdn.microsoft.com/en-us/library/bb513869.aspx
    /// </summary>
    /// <param name="path">The directory being traversed.</param>
    private static void WalkDirectoryTree(string path)
    {
        string[] filePaths = null;
        string[] subdirectories = null;

        // First, process all the files directly under this folder 
        try
        {
            filePaths = Directory.GetFiles(path, SearchPattern);
        }
        // This is thrown if even one of the files requires permissions greater 
        // than the application provides. 
        catch (UnauthorizedAccessException uaex)
        {
            // This code just writes out the message and continues to recurse. 
            // You may decide to do something different here. For example, you 
            // can try to elevate your privileges and access the file again.
            log.AppendLine(uaex.Message);
        }

        catch (DirectoryNotFoundException dnfex)
        {
            log.AppendLine(dnfex.Message);
        }

        if (filePaths != null)
        {
            foreach (string filePath in filePaths)
            {
                // In this example, we only access the existing file. If we 
                // want to open, delete or modify the file, then 
                // a try-catch block is required here to handle the case 
                // where the file has been deleted since the call to WalkDirectoryTree().
                Console.WriteLine(filePath);
            }

            // Now find all the subdirectories under this directory.
            subdirectories = Directory.GetDirectories(path);

            foreach (string subdirectory in subdirectories)
            {
                // Resursive call for each subdirectory.
                WalkDirectoryTree(subdirectory);
            }
        }
    }

    private static void Main()
    {
        log.Clear();

        WalkDirectoryTree(WindowsPath);

        Console.WriteLine(log);

        // A manifest file has been created where the highest available execution level
        // has been requested (<requestedExecutionLevel  level="highestAvailable" uiAccess="false" />).
        // Because of the privileges elevation (to avoid the UnauthorizedAccessException where possible), 
        // the application starts in another console window which should be prevented from
        // closing when the program finishes.
        Console.Write("Press any key to continue . . . ");
        Console.ReadKey();
    }
}
