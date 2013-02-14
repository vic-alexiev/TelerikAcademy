using System;
using System.Globalization;
using System.Text;

class ConvertIntegersToWords
{
    private static string[] ones =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };

    private static string[] teens =
        {
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

    private static string[] tens =
        {
            "",
            "ten",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };

    // US Numbering:
    private static string[] thousands =
        {
            "",
            "thousand",
            "million",
            "billion",
            "trillion",
            "quadrillion",
            "quintillion"
        };

    /// <summary>
    /// Converts a numeric value to words.
    /// </summary>
    /// <see cref="http://www.blackbeltcoder.com/Articles/strings/converting-numbers-to-words"/>
    /// <remarks>
    /// The original source was changed to add "and" before ones and tens.
    /// </remarks>
    /// <param name="value">Value to be converted</param>
    /// <returns></returns>
    private static string Convert(long value)
    {
        string temp;
        bool showThousands = false;
        bool allZeros = true;

        // Use StringBuilder to build result
        StringBuilder builder = new StringBuilder();
        // Convert value to string
        string digits = value.ToString();
        // Traverse characters in reverse order
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            int digit = (int)(digits[i] - '0');
            int column = (digits.Length - (i + 1));

            temp = String.Empty;

            // Determine if ones, tens, or hundreds column
            switch (column % 3)
            {
                case 0:        // Ones position
                    showThousands = true;
                    if (i == 0)
                    {
                        // First digit in number (last in loop)
                        temp = String.Format("{0} ", ones[digit]);
                    }
                    else if (digits[i - 1] == '1')
                    {
                        if (i - 1 > 0 && column == 0)
                        {
                            temp = "and ";
                        }
                        // This digit is part of "teen" value
                        temp += String.Format("{0} ", teens[digit]);
                        // Skip tens position
                        i--;
                    }
                    else if (digit != 0)
                    {
                        // Any non-zero digit
                        if (digits[i - 1] == '0' && column == 0)
                        {
                            temp = "and ";
                        }
                        temp += String.Format("{0} ", ones[digit]);
                    }
                    else
                    {
                        // This digit is zero. If digit in tens and hundreds
                        // column are also zero, don't show "thousands"
                        // Test for non-zero digit in this grouping
                        if (digits[i - 1] != '0' || (i > 1 && digits[i - 2] != '0'))
                            showThousands = true;
                        else
                            showThousands = false;
                    }

                    // Show "thousands" if non-zero in grouping
                    if (showThousands)
                    {
                        if (column > 0)
                        {
                            temp = String.Format("{0}{1}{2}",
                                temp,
                                thousands[column / 3],
                                allZeros ? " " : ", ");
                        }
                        // Indicate non-zero digit encountered
                        allZeros = false;
                    }
                    builder.Insert(0, temp);
                    break;

                case 1:        // Tens column
                    if (digit > 0)
                    {
                        temp = String.Format("{0}{1}",
                            tens[digit],
                            (digits[i + 1] != '0') ? "-" : " ");
                        builder.Insert(0, temp);
                    }
                    break;

                case 2:        // Hundreds column
                    if (digit > 0)
                    {
                        temp = String.Format("{0} hundred ", ones[digit]);
                        builder.Insert(0, temp);
                    }
                    break;
            }
        }

        // Capitalize first letter
        return String.Format("{0}{1}",
            Char.ToUpper(builder[0]),
            builder.ToString(1, builder.Length - 1)).Replace(", and", " and");
    }

    static void Main()
    {
        string numberAsString;
        long number;

        do
        {
            Console.Write("Number: ");
            numberAsString = Console.ReadLine();

        }
        while (!Int64.TryParse(numberAsString, NumberStyles.Number, CultureInfo.InvariantCulture, out number) || number < 0);

        string numberAsWord = Convert(number);

        Console.WriteLine("The number entered is:\n{0}", numberAsWord);
    }
}
