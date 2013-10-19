using System;
using System.Text;

class Carpets
{
    private static string Concat(string value, int n, bool frontSpace)
    {
        if (n < 1)
        {
            return String.Empty;
        }

        string[] emptyStringsArray = new string[n + 1];

        if (frontSpace)
        {
            return String.Join(String.Format(" {0}", value), emptyStringsArray);
        }
        else
        {
            return String.Join(String.Format("{0} ", value), emptyStringsArray);
        }
    }

    static void Main()
    {
        string numberN = Console.ReadLine();
        int n = Int32.Parse(numberN); // n is even
        int halfLength = n / 2;

        // upper half of the carpet
        for (int i = 1; i <= halfLength; i++)
        {
            int dotsCount = n - 2 * i;
            Console.Write("{0}", new String('.', dotsCount / 2));

            int slashesCount = i;

            if (i % 2 == 1)
            {
                slashesCount--;
                Console.Write("{0}/\\{1}", Concat("/", slashesCount / 2, false), Concat("\\", slashesCount / 2, true));
            }
            else
            {
                Console.Write("{0}{1}", Concat("/", slashesCount / 2, false), Concat("\\", slashesCount / 2, true));
            }

            Console.WriteLine("{0}", new String('.', dotsCount / 2));
        }

        // lower half of the carpet
        for (int i = 1; i <= halfLength; i++)
        {
            int dotsCount = 2 * i - 2;
            Console.Write("{0}", new String('.', dotsCount / 2));

            int slashesCount = (n - dotsCount) / 2;

            if ((halfLength - i) % 2 == 0)
            {
                slashesCount--;
                Console.Write("{0}\\/{1}", Concat("\\", slashesCount / 2, false), Concat("/", slashesCount / 2, true));
            }
            else
            {
                Console.Write("{0}{1}", Concat("\\", slashesCount / 2, false), Concat("/", slashesCount / 2, true));
            }

            Console.WriteLine("{0}", new String('.', dotsCount / 2));
        }
    }
}
