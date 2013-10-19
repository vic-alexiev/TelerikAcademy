using System;

class ThreeDSlices
{
    static void Main()
    {
        string firstLine = Console.ReadLine();
        string[] dimensions = firstLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int width = Int32.Parse(dimensions[0]);
        int height = Int32.Parse(dimensions[1]);
        int depth = Int32.Parse(dimensions[2]);

        int[, ,] cuboid = new int[width, height, depth];
        long totalSum = 0;

        for (int i = 0; i < height; i++)
        {
            string matrix = Console.ReadLine();
            string[] rows = matrix.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < depth; j++)
            {
                string[] cells = rows[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int k = 0; k < width; k++)
                {
                    cuboid[k, i, j] = Int32.Parse(cells[k]);
                    totalSum += cuboid[k, i, j];
                }
            }
        }

        int equalSumCuts = 0;

        long currentSum = 0;

        for (int i = 0; i < height - 1; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                for (int k = 0; k < width; k++)
                {
                    currentSum += cuboid[k, i, j];
                }
            }

            if (currentSum + currentSum == totalSum)
            {
                equalSumCuts++;
            }
        }

        currentSum = 0;

        for (int i = 0; i < width - 1; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                for (int k = 0; k < height; k++)
                {
                    currentSum += cuboid[i, k, j];
                }
            }

            if (currentSum + currentSum == totalSum)
            {
                equalSumCuts++;
            }
        }

        currentSum = 0;

        for (int i = 0; i < depth - 1; i++)
        {
            for (int j = 0; j < height; j++)
            {
                for (int k = 0; k < width; k++)
                {
                    currentSum += cuboid[k, j, i];
                }
            }

            if (currentSum + currentSum == totalSum)
            {
                equalSumCuts++;
            }
        }

        Console.WriteLine(equalSumCuts);
    }
}
