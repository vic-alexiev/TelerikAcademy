using System;
using System.IO;

class DeleteFileOddLines
{
    static void Main()
    {
        string sourcefilePath;

        do
        {
            Console.Write("Enter the path of a file in the local file system: ");
            sourcefilePath = Console.ReadLine();
        }
        while (!File.Exists(sourcefilePath));

        string extension = Path.GetExtension(sourcefilePath);

        string tempFilePath = sourcefilePath.Insert(sourcefilePath.LastIndexOf(extension), "_tmp");

        try
        {
            using (StreamReader reader = new StreamReader(sourcefilePath))
            {
                using (StreamWriter writer = new StreamWriter(tempFilePath, false))
                {
                    int lineNumber = 0;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        lineNumber++;
                        if (lineNumber % 2 == 0)
                        {
                            // this is an even line - put it in the temp file
                            writer.WriteLine(line);
                        }

                        line = reader.ReadLine();
                    }
                }
            }

            File.Delete(sourcefilePath);

            File.Move(tempFilePath, sourcefilePath);

            Console.WriteLine("\"{0}\" saved successfully.", sourcefilePath);
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
