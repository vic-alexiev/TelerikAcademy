using System;
using System.Collections.Generic;
using System.Linq;

class Poker
{
    static void Main()
    {
        int[] cards = new int[5];
        Dictionary<string, int> cardsDic = new Dictionary<string, int>();
        cardsDic.Add("A", 0);

        for (int i = 2; i <= 10; i++)
        {
            cardsDic.Add(i.ToString(), 0);
        }

        cardsDic.Add("J", 0);
        cardsDic.Add("Q", 0);
        cardsDic.Add("K", 0);

        for (int i = 0; i < 5; i++)
        {
            string card = Console.ReadLine();
            cardsDic[card]++;

            switch (card)
            {
                case "A":
                    cards[i] = 1;
                    break;
                case "J":
                    cards[i] = 11;
                    break;
                case "Q":
                    cards[i] = 12;
                    break;
                case "K":
                    cards[i] = 13;
                    break;
                default:
                    cards[i] = Int32.Parse(card);
                    break;
            }
        }

        if (cardsDic.ContainsValue(5))
        {
            Console.WriteLine("Impossible");
        }
        else if (cardsDic.ContainsValue(4))
        {
            Console.WriteLine("Four of a Kind");
        }
        else if (cardsDic.ContainsValue(3) && cardsDic.ContainsValue(2))
        {
            Console.WriteLine("Full House");
        }
        else if (cardsDic.ContainsValue(3))
        {
            Console.WriteLine("Three of a Kind");
        }
        else if (cardsDic.Count(c => c.Value == 2) == 2)
        {
            Console.WriteLine("Two Pairs");
        }
        else if (cardsDic.ContainsValue(2))
        {
            Console.WriteLine("One Pair");
        }
        else
        {
            Array.Sort(cards);

            for (int i = 0; i < 4; i++)
            {
                if (!(cards[i] == cards[i + 1] - 1
                    || cards[i] == 1 && cards[i + 1] == 10))
                {
                    Console.WriteLine("Nothing");
                    return;
                }
            }

            Console.WriteLine("Straight");
        }
    }
}
