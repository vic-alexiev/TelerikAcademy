using System;

class PrintStandard52CardDeck
{
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();

        string[] suits = { "CLUBS", "DIAMONDS", "HEARTS", "SPADES" };
        char[] suitSymbols = { '\u2663', '\u2666', '\u2665', '\u2660' };
        string[] ranks = {"ACE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", 
                             "JACK", "QUEEN", "KING" };
        string[] rankSymbols = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine("THE STANDARD 52-CARD DECK:\n");


        for (int i = 0; i < rankSymbols.Length; i++)
        {
            Console.Write("\t\t");

            for (int j = 0; j < suitSymbols.Length; j++)
            {
                Console.Write(" [");

                if (j == 1 || j == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write("{0,3} {1,-2}", rankSymbols[i], suitSymbols[j]);

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("]");
            }

            Console.WriteLine('\n');
        }


        for (int i = 0; i < ranks.Length; i++)
        {
            for (int j = 0; j < suits.Length; j++)
            {
                Console.Write("{0,6} OF {1}", ranks[i], suits[j]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
