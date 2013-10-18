using System;

namespace Midget
{
    class Midget
    {
        static void Main()
        {
            int[] valley = new int[10000];

            string inputValley = Console.ReadLine();
            string[] valleyNumbers = inputValley.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int valleyLength = valleyNumbers.Length;

            for (int i = 0; i < valleyLength; i++)
            {
                valley[i] = Int32.Parse(valleyNumbers[i]);
            }

            string inputPatternsCount = Console.ReadLine();

            int patternsCount = Int32.Parse(inputPatternsCount);

            int[][] patterns = new int[patternsCount][];

            for (int i = 0; i < patternsCount; i++)
            {
                string pattern = Console.ReadLine();

                string[] patternNumbers = pattern.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int k = patternNumbers.Length;

                patterns[i] = new int[k];

                for (int j = 0; j < k; j++)
                {
                    patterns[i][j] = Int32.Parse(patternNumbers[j]);
                }
            }

            if (valleyLength == 1)
            {
                Console.WriteLine(valley[0]);
                return;
            }

            int maxSum = Int32.MinValue;

            foreach (int[] pattern in patterns)
            {
                int patternLength = pattern.Length;
                bool[] visited = new bool[valleyLength];

                int patternIndex = 0;
                int valleyIndex = 0;

                int patternSum = valley[valleyIndex];
                visited[valleyIndex] = true;

                while (true)
                {
                    valleyIndex += pattern[patternIndex];

                    if (valleyIndex < 0 || valleyIndex >= valleyLength || visited[valleyIndex])
                    {
                        break;
                    }

                    patternSum += valley[valleyIndex];
                    visited[valleyIndex] = true;

                    patternIndex = (patternIndex + 1) % patternLength;
                }

                if (maxSum < patternSum)
                {
                    maxSum = patternSum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
