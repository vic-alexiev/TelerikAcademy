using System;
using System.IO;

class FileComparison
{
    static void Main()
    {
        string sourceFilePath1;
        string sourceFilePath2;

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

        int identicalLinesCount = 0;
        int differentLinesCount = 0;

        try
        {
            using (StreamReader reader1 = new StreamReader(sourceFilePath1))
            {
                using (StreamReader reader2 = new StreamReader(sourceFilePath2))
                {
                    string line1 = reader1.ReadLine();
                    string line2 = reader2.ReadLine();

                    while (line1 != null && line2 != null)
                    {
                        if (line1 == line2)
                        {
                            identicalLinesCount++;
                        }
                        else
                        {
                            differentLinesCount++;
                        }

                        line1 = reader1.ReadLine();
                        line2 = reader2.ReadLine();
                    }
                }
            }

            int lines = identicalLinesCount + differentLinesCount;

            Console.WriteLine("Identical lines of the first {0} lines ...............: {1}", lines, identicalLinesCount);
            Console.WriteLine("Different lines of the first {0} lines ...............: {1}", lines, differentLinesCount);
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
