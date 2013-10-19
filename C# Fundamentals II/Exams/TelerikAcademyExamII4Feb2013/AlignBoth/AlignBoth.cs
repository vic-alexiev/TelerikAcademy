using System;
using System.Collections.Generic;
using System.Text;

namespace AlignBoth
{
    class AlignBoth
    {
        private static string JustifyText(List<string> words, int lineWidth)
        {
            int index = 0;

            StringBuilder justifiedTextBuilder = new StringBuilder();

            while (index < words.Count)
            {
                int wordsPerLine = 1;

                justifiedTextBuilder.Append(words[index]);

                int remainingWidth = lineWidth - words[index++].Length;

                while (remainingWidth > 0 && index < words.Count)
                {
                    wordsPerLine++;
                    remainingWidth -= (words[index++].Length + 1);
                }

                if (remainingWidth == 0)
                {
                    for (int i = 1; i < wordsPerLine; i++)
                    {
                        justifiedTextBuilder.AppendFormat(" {0}", words[index - wordsPerLine + i]);
                    }

                    justifiedTextBuilder.AppendFormat("\n");
                }
                else
                {
                    if (remainingWidth < 0)
                    {
                        wordsPerLine--;
                        remainingWidth += words[--index].Length + 1;
                    }

                    if (wordsPerLine > 1)
                    {
                        int[] gaps = new int[wordsPerLine - 1];

                        int additionalWhiteSpaces1 = remainingWidth / gaps.Length;
                        int additionalWhiteSpaces2 = remainingWidth % gaps.Length;

                        for (int i = 0; i < gaps.Length; i++)
                        {
                            gaps[i] = 1 + additionalWhiteSpaces1;

                            if (additionalWhiteSpaces2 > 0)
                            {
                                gaps[i]++;
                                additionalWhiteSpaces2--;
                            }
                        }

                        for (int i = 1; i < wordsPerLine; i++)
                        {
                            justifiedTextBuilder.AppendFormat("{0}{1}", new String(' ', gaps[i - 1]), words[index - wordsPerLine + i]);
                        }
                    }

                    justifiedTextBuilder.AppendFormat("\n");
                }
            }

            return justifiedTextBuilder.ToString();
        }

        static void Main()
        {
            string linesCountAsString = Console.ReadLine();
            int linesCount = Int32.Parse(linesCountAsString);

            string widthAsString = Console.ReadLine();
            int width = Int32.Parse(widthAsString);

            List<string> words = new List<string>();

            for (int row = 0; row < linesCount; row++)
            {
                string line = Console.ReadLine();
                string[] wordsInLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in wordsInLine)
                {
                    words.Add(word);
                }
            }

            Console.WriteLine(JustifyText(words, width));
        }
    }
}
