using System;
using System.Globalization;

class UpdateUserInputDependingOnVarType
{
    static void Main()
    {
        string userChoice;
        string userInput;

        Console.Write("What will be the type of your input (I - integer, D - double-precision floating-point number, S - string)? ");
        userChoice = Console.ReadLine();

        switch (userChoice)
        {
            case "I":
            case "i":
                {
                    int intNumber;
                    do
                    {
                        Console.Write("Enter your integer: ");
                        userInput = Console.ReadLine();
                    }
                    while (!Int32.TryParse(userInput, NumberStyles.Number, CultureInfo.InvariantCulture, out intNumber));

                    try
                    {
                        checked
                        {
                            Console.WriteLine("Your number + 1 equals to {0}.", ++intNumber);
                        }
                    }
                    catch(OverflowException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
            case "D":
            case "d":
                {
                    double doubleNumber;
                    do
                    {
                        Console.Write("Enter your double-precision floating-point number: ");
                        userInput = Console.ReadLine();
                    }
                    while (!Double.TryParse(userInput, NumberStyles.Number, CultureInfo.InvariantCulture, out doubleNumber));

                    Console.WriteLine("Your number + 1 equals to {0}.", ++doubleNumber);
                    break;
                }
            case "s":
            case "S":
                {
                    Console.WriteLine("Enter your string: ");
                    userInput = Console.ReadLine();
                    Console.WriteLine("Your string with an asterisk appended equals to \"{0}*\".", userInput);
                    break;
                }
            default:
                {
                    Console.WriteLine("This is not a valid option!");
                    break;
                }
        }

    }
}
