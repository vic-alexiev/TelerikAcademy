using System;
using System.Linq;
using System.Text;

class BasicLanguage
{
    private static string KEYWORDS = "FOREXIT";

    static void Main()
    {
        StringBuilder commandBuilder = new StringBuilder();
        string input;

        do
        {
            input = Console.ReadLine();
            commandBuilder.Append(input + "\n");
        }
        while (!input.EndsWith("EXIT;"));

        string commands = commandBuilder.ToString().Trim();

        long totalCount = 1;
        int? start = null;
        bool betweenForBrackets = false;
        bool betweenPrintBrackets = false;

        StringBuilder builder = new StringBuilder();

        foreach (char currentChar in commands)
        {
            if (currentChar == '(')
            {
                if (betweenPrintBrackets)
                {
                    builder.Append('(');
                }
                else if (builder.ToString().IndexOf("FOR") >= 0)
                {
                    betweenForBrackets = true;
                    builder.Clear();
                }
                else if (!betweenForBrackets)
                {
                    betweenPrintBrackets = true;
                    builder.Clear();
                }
            }
            else if (currentChar == ')')
            {
                if (betweenPrintBrackets)
                {
                    if (totalCount > 0 && builder.Length > 0)
                    {
                        string message = builder.ToString();

                        if (totalCount > 1)
                        {
                            StringBuilder printBuilder = new StringBuilder();

                            for (long i = 0; i < totalCount; i++)
                            {
                                printBuilder.Append(message);
                            }

                            Console.Write(printBuilder);
                        }
                        else
                        {
                            Console.Write(message);
                        }
                    }

                    builder.Clear();
                    totalCount = 1;
                    betweenPrintBrackets = false;
                }
                else if (betweenForBrackets)
                {
                    if (start.HasValue)
                    {
                        totalCount *= (Int32.Parse(builder.ToString()) - start.Value + 1);
                    }
                    else
                    {
                        totalCount *= Int32.Parse(builder.ToString());
                    }

                    start = null;
                    builder.Clear();
                    betweenForBrackets = false;
                }
            }
            else if (currentChar == ',')
            {
                if (betweenPrintBrackets)
                {
                    builder.Append(',');
                }
                else
                {
                    start = Int32.Parse(builder.ToString());
                    builder.Clear();
                }
            }
            else if (betweenPrintBrackets)
            {
                builder.Append(currentChar);
            }
            else if (KEYWORDS.Contains(currentChar) || Char.IsDigit(currentChar) || currentChar == '-')
            {
                builder.Append(currentChar);
            }
            else if (currentChar == ';')
            {
                if (builder.ToString().IndexOf("EXIT") >= 0)
                {
                    break;
                }
            }
        }

        Console.WriteLine();
    }
}
