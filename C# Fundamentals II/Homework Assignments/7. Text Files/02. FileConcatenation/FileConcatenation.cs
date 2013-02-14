using System;
using System.IO;

class FileConcatenation
{
    static void Main()
    {
        string sourceFilePath1;
        string sourceFilePath2;
        string destinationFilePath;

        do
        {
            Console.Write("Enter the path of the first file in the local file system: ");
            sourceFilePath1 = Console.ReadLine();
        }
        while (!File.Exists(sourceFilePath1));

        do
        {
            Console.Write("Enter the path of the second file in the local file system: ");
            sourceFilePath2 = Console.ReadLine();
        }
        while (!File.Exists(sourceFilePath2));

        do
        {
            Console.Write("Enter a valid path for the destination file: ");
            destinationFilePath = Console.ReadLine();
        }
        while (String.IsNullOrWhiteSpace(destinationFilePath) || destinationFilePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0);

        try
        {
            using (StreamWriter overwriteWriter = new StreamWriter(destinationFilePath, false))
            {
                Console.WriteLine("Appending the contents of \"{0}\" to that of \"{1}\" in \"{2}\" .......\n\n", sourceFilePath2, sourceFilePath1, destinationFilePath);

                using (StreamReader file1Reader = new StreamReader(sourceFilePath1))
                {
                    string line = file1Reader.ReadLine();

                    while (line != null)
                    {
                        overwriteWriter.WriteLine(line);
                        line = file1Reader.ReadLine();
                    }
                }
            }

            using (StreamWriter appendWriter = new StreamWriter(destinationFilePath, true))
            {
                using (StreamReader file2Reader = new StreamReader(sourceFilePath2))
                {
                    string line = file2Reader.ReadLine();

                    while (line != null)
                    {
                        appendWriter.WriteLine(line);
                        line = file2Reader.ReadLine();
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
