using System;
using System.Collections.Generic;

internal class ColourfulRabbits
{
    private static void Main()
    {
        Dictionary<int, int> answers = new Dictionary<int, int>();

        int rabbitsInquired = int.Parse(Console.ReadLine());

        for (int i = 0; i < rabbitsInquired; i++)
        {
            int answer = int.Parse(Console.ReadLine());
            answer++;

            if (!answers.ContainsKey(answer))
            {
                answers[answer] = 1;
            }
            else
            {
                answers[answer]++;
            }
        }

        long minRabbitsCount = 0;

        foreach (var pair in answers)
        {
            if (pair.Key >= pair.Value)
            {
                minRabbitsCount += pair.Key;
            }
            else if (pair.Value % pair.Key == 0)
            {
                minRabbitsCount += pair.Value;
            }
            else
            {
                minRabbitsCount += (int)Math.Ceiling((double)pair.Value / pair.Key) * pair.Key;
            }
        }

        Console.WriteLine(minRabbitsCount);
    }
}
