using System;
using System.Linq;
using System.Text;

static class SecretLanguage
{
    #region Private Fields

    private static string[] words;
    private static string[] sortedWords;
    private static int currentCost = 0;
    private static int totalCost = Int32.MaxValue;

    #endregion

    #region Extension Methods

    /// <summary>
    /// An extension method used to initialize the elements of an array 
    /// with a specified value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <param name="value"></param>
    public static void Populate<T>(this T[] arr, T value, int startIndex)
    {
        for (int i = startIndex; i < arr.Length; i++)
        {
            arr[i] = value;
        }
    }

    #endregion

    #region Private Methods

    private static bool StartsWithPermutationOf(string sequence, int wordIndex, out int cost)
    {
        cost = Int32.MaxValue;

        if (sequence.Length < words[wordIndex].Length)
        {
            return false;
        }

        int wordLength = words[wordIndex].Length;
        string sequenceStart = sequence.Substring(0, wordLength);
        char[] sequenceStartAsArray = sequenceStart.ToCharArray();

        Array.Sort(sequenceStartAsArray);

        string sortedSequenceStart = new String(sequenceStartAsArray);

        if (sortedSequenceStart == sortedWords[wordIndex])
        {
            cost = 0;

            for (int c = 0; c < wordLength; c++)
            {
                if (sequenceStart[c] != words[wordIndex][c])
                {
                    cost++;
                }
            }

            return true;
        }

        return false;
    }

    private static void FindWords(string sentence)
    {
        if (sentence == String.Empty)
        {
            if (currentCost < totalCost)
            {
                totalCost = currentCost;
            }
        }

        for (int index = 0; index < words.Length; index++)
        {
            int cost;

            if (StartsWithPermutationOf(sentence, index, out cost))
            {
                currentCost += cost;

                string restOfSentence = sentence.Substring(words[index].Length);

                FindWords(restOfSentence);

                currentCost -= cost;
            }
        }
    }

    private static int GetMinimalCost(string sentence)
    {
        int n = sentence.Length;
        int m = words.Length;

        int[] minCost = new int[n + 1];
        minCost.Populate(1048576, 1);

        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int wordLength = words[j].Length;

                if (wordLength <= i)
                {
                    string sequence = sentence.Substring(i - wordLength, wordLength);

                    char[] sequenceAsArray = sequence.ToCharArray();
                    Array.Sort(sequenceAsArray);
                    string sortedSequence = new String(sequenceAsArray);

                    if (sortedSequence == sortedWords[j])
                    {
                        int cost = 0;

                        for (int c = 0; c < wordLength; c++)
                        {
                            if (sequence[c] != words[j][c])
                            {
                                cost++;
                            }
                        }

                        minCost[i] = Math.Min(minCost[i], minCost[i - wordLength] + cost);
                    }
                }
            }
        }

        return minCost[n] < 1048576 ? minCost[n] : -1;
    }

    #endregion

    static void Main()
    {
        string sentence = Console.ReadLine();
        string wordSequence = Console.ReadLine();

        words = wordSequence.Split(new char[] { ',', ' ', '"' }, StringSplitOptions.RemoveEmptyEntries);

        int wordsCount = words.Length;
        sortedWords = new string[wordsCount];

        for (int i = 0; i < wordsCount; i++)
        {
            char[] sortedWord = words[i].ToCharArray();
            Array.Sort(sortedWord);
            sortedWords[i] = new String(sortedWord);
        }

        // I solution
        //FindWords(sentence);

        //Console.WriteLine(totalCost != Int32.MaxValue ? totalCost : -1);

        // II solution
        int minimalCost = GetMinimalCost(sentence);
        Console.WriteLine(minimalCost);
    }
}
