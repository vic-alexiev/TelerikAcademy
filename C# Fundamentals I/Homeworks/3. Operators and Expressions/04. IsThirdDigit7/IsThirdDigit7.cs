using System;
using System.Globalization;

class IsThirdDigit7
{
    static void Main()
    {
        byte digitPositionRightToLeft = 3;
        byte requiredValue = 7;

        string numberFromConsole;
        uint number;

        do
        {
            Console.WriteLine("Your number:");
            numberFromConsole = Console.ReadLine();
        }
        while (!UInt32.TryParse(numberFromConsole, out number));

        uint numberWithRightmostDigitsRemoved = number / (uint)Math.Pow(10, digitPositionRightToLeft - 1);
        uint digitValue = numberWithRightmostDigitsRemoved % 10;

        Console.WriteLine("The digit at position {0} (right to left) {1} the required value of {2}.",
            digitPositionRightToLeft,
            digitValue == requiredValue ? "equals" : "does not equal",
            requiredValue);
    }
}
