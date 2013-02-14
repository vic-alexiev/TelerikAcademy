using System;
using System.IO;
using System.Security;

class PrintFileContents
{
    static void Main()
    {
        Console.Write("Enter file path: ");
        string path = Console.ReadLine();

        try
        {
            string contents = File.ReadAllText(path);

            Console.WriteLine(contents);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine(ptle.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine(nse.Message);
        }
        catch (SecurityException se)
        {
            Console.WriteLine(se.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
    }
}
