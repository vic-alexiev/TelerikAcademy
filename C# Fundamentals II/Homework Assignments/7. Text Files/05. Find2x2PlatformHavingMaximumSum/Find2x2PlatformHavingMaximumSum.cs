using System;
using System.IO;

class Find2x2PlatformHavingMaximumSum
{
    private static int Get2x2PlatformsMaximumSum(int[,] value)
    {
        int maxSum = Int32.MinValue;

        for (int row = 0; row < value.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < value.GetLength(1) - 1; col++)
            {
                int sum;
                checked
                {
                    sum = value[row, col] + value[row, col + 1] + value[row + 1, col] + value[row + 1, col + 1];
                }

                if (maxSum < sum)
                {
                    maxSum = sum;
                }
            }
        }

        return maxSum;
    }

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

        string destinationFilePath = sourcefilePath.Insert(sourcefilePath.LastIndexOf(extension), "_out");

        try
        {
            int size = 0;
            int[,] matrix;

            using (StreamReader reader = new StreamReader(sourcefilePath))
            {
                string line = reader.ReadLine();

                size = Int32.Parse(line);

                matrix = new int[size, size];

                for (int row = 0; row < size; row++)
                {
                    string matrixRow = reader.ReadLine();
                    string[] numbers = matrixRow.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int col = 0; col < size; col++)
                    {
                        matrix[row, col] = Int32.Parse(numbers[col]);
                    }
                }
            }

            int maxSum = Get2x2PlatformsMaximumSum(matrix);

            using (StreamWriter writer = new StreamWriter(destinationFilePath, false))
            {
                writer.WriteLine(maxSum);
            }

            Console.WriteLine("\"{0}\" saved successfully.", destinationFilePath);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch (OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
        catch (IndexOutOfRangeException ioore)
        {
            Console.WriteLine(ioore.Message);
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
