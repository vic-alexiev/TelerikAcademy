using System;
using System.IO;

class InsertLineNumbers
{
    static void Main()
    {
        string sourceFilePath;
        string destinationFilePath;

        do
        {
            Console.Write("Enter the path of a file in the local file system: ");
            sourceFilePath = Console.ReadLine();
        }
        while (!File.Exists(sourceFilePath));

        do
        {
            Console.Write("Enter a valid path for the destination file: ");
            destinationFilePath = Console.ReadLine();
        }
        while (String.IsNullOrWhiteSpace(destinationFilePath) || destinationFilePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0);

        try
        {
            using (StreamWriter writer = new StreamWriter(destinationFilePath, false))
            {
                Console.WriteLine("Copying the contents of \"{0}\" to \"{1}\" with line numbers in front .......\n\n", sourceFilePath, destinationFilePath);

                using (StreamReader reader = new StreamReader(sourceFilePath))
                {
                    int lineNumber = 0;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        lineNumber++;
                        writer.WriteLine("Line {0}: {1}", lineNumber, line);

                        line = reader.ReadLine();
                    }
                }
            }

            Console.WriteLine("\"{0}\" saved successfully.", destinationFilePath);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine(nse.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
    }
}
