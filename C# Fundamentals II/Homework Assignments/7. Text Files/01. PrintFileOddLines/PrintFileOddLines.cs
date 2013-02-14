using System;
using System.IO;

class PrintFileOddLines
{
    static void Main()
    {
        string filePath;

        do
        {
            Console.Write("Enter the name of a file in the local file system: ");
            filePath = Console.ReadLine();
        }
        while (!File.Exists(filePath));

        StreamReader reader = null;

        try
        {
            reader = new StreamReader(filePath);

            int lineNumber = 0;
            string line = reader.ReadLine();

            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 == 1)
                {
                    Console.WriteLine(line);
                }

                line = reader.ReadLine();
            }
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
        }
    }
}
