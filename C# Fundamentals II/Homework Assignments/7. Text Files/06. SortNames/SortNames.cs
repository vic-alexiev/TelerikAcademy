using System;
using System.Collections.Generic;
using System.IO;

class SortNames
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

        string destinationFilePath = sourcefilePath.Insert(sourcefilePath.LastIndexOf(extension), "_sorted");

        try
        {
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(sourcefilePath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
            }

            lines.Sort();

            using (StreamWriter writer = new StreamWriter(destinationFilePath, false))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("\"{0}\" saved successfully.", destinationFilePath);
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
