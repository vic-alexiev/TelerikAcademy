using System;

class ApplyBonusScores
{
    static void Main()
    {
        string digitAsString;
        byte digit;

        do
        {
            Console.Write("Enter your score (1, ..., 9): ");
            digitAsString = Console.ReadLine();
        }
        while (!Byte.TryParse(digitAsString, out digit));

        switch (digit)
        {
            case 1:
            case 2:
            case 3:
                {
                    Console.WriteLine("Yor final score is {0}.", 10 * digit);
                    break;
                }
            case 4:
            case 5:
            case 6:
                {
                    Console.WriteLine("Yor final score is {0}.", 100 * digit);
                    break;
                }
            case 7:
            case 8:
            case 9:
                {
                    Console.WriteLine("Yor final score is {0}.", 1000 * digit);
                    break;
                }
            case 0:
                {
                    Console.WriteLine("0 is not a valid score.");
                    break;
                }
            default:
                {
                    Console.WriteLine("{0} is not a digit (not a valid score).", digit);
                    break;
                }
        }
    }
}
