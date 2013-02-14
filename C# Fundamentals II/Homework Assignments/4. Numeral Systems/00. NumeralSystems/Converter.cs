using System;
using System.Text;
using System.Text.RegularExpressions;

namespace NumeralSystems
{
    public static class Converter
    {
        private static string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static uint[] romanValues = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        private static string[] romanCharacters = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };


        #region Public Methods

        /// <summary>
        /// Converts the given decimal number to the numeral system with the
        /// specified radix (in the range [2, 36]).
        /// Works with non-negative 64-bit integers.
        /// </summary>
        /// <see cref="http://stackoverflow.com/questions/923771/quickest-way-to-convert-a-base-10-number-to-any-base-in-net"/>
        /// <param name="decimalValue">The number to convert.</param>
        /// <param name="radix">The radix of the destination numeral system (in the range [2, 36]).</param>
        /// <returns></returns>
        public static string FromDecimal(long decimalValue, int radix)
        {
            if (decimalValue < 0)
            {
                throw new ArgumentException("The decimal number should be a non-negative 64-bit integer.");
            }

            if (radix < 2 || radix > digits.Length)
            {
                throw new ArgumentException(String.Format("The radix must be an integer in the range [2, {0}].", digits.Length));
            }

            if (decimalValue == 0)
            {
                return "0";
            }

            StringBuilder resultBuilder = new StringBuilder();

            while (decimalValue > 0)
            {
                int remainder = (int)(decimalValue % radix);
                resultBuilder.Insert(0, digits[remainder]);
                decimalValue = decimalValue / radix;
            }

            return resultBuilder.ToString();
        }

        /// <summary>
        /// Converts the given value to decimal (the value's numeral system is specified by the radix).
        /// Works with non-negative values.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <param name="radix">The radix of the source numeral system (in the range [2, 36]).</param>
        /// <returns></returns>
        public static long ToDecimal(string value, int radix)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value is null, empty, or consists only of white-space characters.");
            }

            if (!IsValidNonNegativeInteger(value))
            {
                throw new ArgumentException("Value is not a valid non-negative integer.");
            }

            if (radix < 2 || radix > digits.Length)
            {
                throw new ArgumentException(String.Format("The radix must be an integer in the range [2, {0}].", digits.Length));
            }

            // remove white-spaces, leading zeros and capitalize the letters (if value is hexadecimal)
            string fixedValue = value.TrimStart('0').ToUpper();

            if (fixedValue == String.Empty)
            {
                return 0;
            }

            int n = fixedValue.Length;
            long decimalNumber = 0;
            for (int i = 0; i < n; i++)
            {
                char character = fixedValue[i];
                if (Char.IsDigit(character))
                {
                    // '0' has ASCII code 48 which should be subtracted from the ASCII codes of the
                    // characters '0'-'9' in order to get the int value ('6' - '0' = 54 - 48 = 6)
                    decimalNumber = decimalNumber * radix + (character - '0');
                }
                else
                {
                    // '7' has ASCII code 55 which should be subtracted from the ASCII codes of the
                    // characters 'A' - 'Z' in order to get the int value ('C' - '7' = 67 - 55 = 12)
                    decimalNumber = decimalNumber * radix + (character - '7');
                }
            }

            return decimalNumber;
        }

        /// <summary>
        /// Converts the hexadecimal value to binary code,
        /// replacing each digit with its 4-bit value.
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        public static string FromHexadecimalToBinary(string hexValue)
        {
            if (String.IsNullOrWhiteSpace(hexValue))
            {
                throw new ArgumentException("Value is null, empty, or consists only of white-space characters.");
            }

            if (!IsValidNonNegativeInteger(hexValue))
            {
                throw new ArgumentException("Value is not a valid non-negative integer.");
            }

            string fixedValue = hexValue.TrimStart('0');

            if (hexValue == String.Empty)
            {
                return "0";
            }

            StringBuilder resultBuilder = new StringBuilder();

            foreach (char digit in fixedValue)
            {
                resultBuilder.Append(GetNibble(digit));
            }

            return resultBuilder.ToString().TrimStart('0');
        }

        /// <summary>
        /// Converts the binary value to a hexadecimal integer,
        /// replacing every 4 bits (nibble) with their corresponding hex digit.
        /// </summary>
        /// <param name="binValue"></param>
        /// <returns></returns>
        public static string FromBinaryToHexadecimal(string binValue)
        {
            if (String.IsNullOrWhiteSpace(binValue))
            {
                throw new ArgumentException("Value is null, empty, or consists only of white-space characters.");
            }

            if (!IsValidBinaryInteger(binValue))
            {
                throw new ArgumentException("Value is not a valid binary integer.");
            }

            string fixedValue = binValue.TrimStart('0');

            if (fixedValue == String.Empty)
            {
                return "0";
            }

            int padWidth = (int)Math.Ceiling(fixedValue.Length / 4.0);

            fixedValue = fixedValue.PadLeft(padWidth * 4, '0');

            int n = fixedValue.Length;

            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < n; i += 4)
            {
                string nibble = fixedValue.Substring(i, 4);
                resultBuilder.Append(GetHexDigit(nibble));
            }

            return resultBuilder.ToString();
        }

        /// <summary>
        /// Converts the octal value to binary code,
        /// replacing each digit with its 3-bit value.
        /// </summary>
        /// <param name="octalValue"></param>
        /// <returns></returns>
        public static string FromOctalToBinary(string octalValue)
        {
            if (String.IsNullOrWhiteSpace(octalValue))
            {
                throw new ArgumentException("Value is null, empty, or consists only of white-space characters.");
            }

            if (!IsValidNonNegativeInteger(octalValue))
            {
                throw new ArgumentException("Value is not a valid non-negative integer.");
            }

            string fixedValue = octalValue.TrimStart('0');

            if (fixedValue == String.Empty)
            {
                return "0";
            }

            StringBuilder resultBuilder = new StringBuilder();

            foreach (char digit in fixedValue)
            {
                resultBuilder.Append(Get3BitGroup(digit));
            }

            return resultBuilder.ToString().TrimStart('0');
        }

        /// <summary>
        /// Converts the binary value to an octal integer,
        /// replacing every 3 bits with their corresponding octal digit.
        /// </summary>
        /// <param name="binValue"></param>
        /// <returns></returns>
        public static string FromBinaryToOctal(string binValue)
        {
            if (String.IsNullOrWhiteSpace(binValue))
            {
                throw new ArgumentException("Value is null, empty, or consists only of white-space characters.");
            }

            if (!IsValidBinaryInteger(binValue))
            {
                throw new ArgumentException("Value is not a valid binary integer.");
            }

            string fixedValue = binValue.TrimStart('0');

            if (fixedValue == String.Empty)
            {
                return "0";
            }

            int padWidth = (int)Math.Ceiling(fixedValue.Length / 3.0);

            fixedValue = fixedValue.PadLeft(padWidth * 3, '0');

            int n = fixedValue.Length;

            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < n; i += 3)
            {
                string threeBitGroup = fixedValue.Substring(i, 3);
                resultBuilder.Append(GetOctalDigit(threeBitGroup));
            }

            return resultBuilder.ToString();
        }

        /// <summary>
        /// Converts from an arbitrary base to an arbitrary base,
        /// first converting the value to decimal and then from decimal
        /// to the destination base.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sourceRadix"></param>
        /// <param name="destRadix"></param>
        /// <returns></returns>
        public static string FromArbitraryBaseToAnother(string value, int sourceRadix, int destRadix)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value is null, empty, or consists only of white-space characters.");
            }

            if (!IsValidNonNegativeInteger(value))
            {
                throw new ArgumentException("Value is not a valid non-negative integer.");
            }

            if (sourceRadix < 2 || sourceRadix > digits.Length ||
                destRadix < 2 || destRadix > digits.Length)
            {
                throw new ArgumentException(String.Format("The radix must be an integer in the range [2, {0}].", digits.Length));
            }

            if (value.TrimStart('0') == String.Empty)
            {
                return "0";
            }

            if (sourceRadix == destRadix)
            {
                return value;
            }

            if (sourceRadix == 10)
            {
                return FromDecimal(Int64.Parse(value), destRadix);
            }

            if (destRadix == 10)
            {
                return ToDecimal(value, sourceRadix).ToString();
            }

            if (sourceRadix == 2 && destRadix == 8)
            {
                return FromBinaryToOctal(value);
            }

            if (sourceRadix == 8 && destRadix == 2)
            {
                return FromOctalToBinary(value);
            }

            if (sourceRadix == 2 && destRadix == 16)
            {
                return FromBinaryToHexadecimal(value);
            }

            if (sourceRadix == 16 && destRadix == 2)
            {
                return FromHexadecimalToBinary(value);
            }

            long decimalValue = ToDecimal(value, sourceRadix);
            return FromDecimal(decimalValue, destRadix);
        }

        /// <summary>
        /// Converts the decimal value to a Roman numeral.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromDecimalToRoman(uint value)
        {
            if (value == 0)
            {
                throw new ArgumentException("Value cannot be zero.");
            }

            StringBuilder romanBuilder = new StringBuilder();

            for (int i = 0; i < romanValues.Length; i++)
            {
                while (romanValues[i] <= value)
                {
                    romanBuilder.Append(romanCharacters[i]);

                    value -= romanValues[i];
                }
            }

            return romanBuilder.ToString();
        }

        /// <summary>
        /// Converts a Roman numeral to its decimal equivalent.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static uint FromRomanToDecimal(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value is null, empty, or consists only of white-space characters.");
            }

            if (!IsValidRomanNumeral(value))
            {
                throw new ArgumentException("Value is not a valid Roman numeral.");
            }

            int n = value.Length;

            uint decimalValue = 0;
            uint digitValue;
            uint nextDigitValue;

            int i = 0;
            while (i < n)
            {
                digitValue = GetRomanDigitValue(value[i]);

                if (i + 1 < n &&
                    (nextDigitValue = GetRomanDigitValue(value[i + 1])) > digitValue)
                {
                    decimalValue += nextDigitValue - digitValue;
                    i += 2;
                }
                else
                {
                    decimalValue += digitValue;
                    i++;
                }
            }

            return decimalValue;
        }

        #endregion

        #region Private Methods

        private static bool IsValidNonNegativeInteger(string value)
        {
            string pattern = @"^[0-9a-zA-Z]+$";

            Match match = Regex.Match(value, pattern);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidBinaryInteger(string value)
        {
            string pattern = @"^[01]+$";

            Match match = Regex.Match(value, pattern);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private static bool IsValidRomanNumeral(string value)
        {
            string pattern = @"^[MDCLXVImdclxvi]+$";

            Match match = Regex.Match(value, pattern);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private static string GetNibble(char digit)
        {
            switch (digit)
            {
                case '0':
                    {
                        return "0000";
                    }
                case '1':
                    {
                        return "0001";
                    }
                case '2':
                    {
                        return "0010";
                    }
                case '3':
                    {
                        return "0011";
                    }
                case '4':
                    {
                        return "0100";
                    }
                case '5':
                    {
                        return "0101";
                    }
                case '6':
                    {
                        return "0110";
                    }
                case '7':
                    {
                        return "0111";
                    }
                case '8':
                    {
                        return "1000";
                    }
                case '9':
                    {
                        return "1001";
                    }
                case 'A':
                case 'a':
                    {
                        return "1010";
                    }
                case 'B':
                case 'b':
                    {
                        return "1011";
                    }
                case 'C':
                case 'c':
                    {
                        return "1100";
                    }
                case 'D':
                case 'd':
                    {
                        return "1101";
                    }
                case 'E':
                case 'e':
                    {
                        return "1110";
                    }
                case 'F':
                case 'f':
                    {
                        return "1111";
                    }
                default:
                    {
                        return String.Empty;
                    }
            }
        }

        private static string Get3BitGroup(char digit)
        {
            switch (digit)
            {
                case '0':
                    {
                        return "000";
                    }
                case '1':
                    {
                        return "001";
                    }
                case '2':
                    {
                        return "010";
                    }
                case '3':
                    {
                        return "011";
                    }
                case '4':
                    {
                        return "100";
                    }
                case '5':
                    {
                        return "101";
                    }
                case '6':
                    {
                        return "110";
                    }
                case '7':
                    {
                        return "111";
                    }
                default:
                    {
                        return String.Empty;
                    }
            }
        }

        private static string GetHexDigit(string nibble)
        {
            switch (nibble)
            {
                case "0000":
                    {
                        return "0";
                    }
                case "0001":
                    {
                        return "1";
                    }
                case "0010":
                    {
                        return "2";
                    }
                case "0011":
                    {
                        return "3";
                    }
                case "0100":
                    {
                        return "4";
                    }
                case "0101":
                    {
                        return "5";
                    }
                case "0110":
                    {
                        return "6";
                    }
                case "0111":
                    {
                        return "7";
                    }
                case "1000":
                    {
                        return "8";
                    }
                case "1001":
                    {
                        return "9";
                    }
                case "1010":
                    {
                        return "A";
                    }
                case "1011":
                    {
                        return "B";
                    }
                case "1100":
                    {
                        return "C";
                    }
                case "1101":
                    {
                        return "D";
                    }
                case "1110":
                    {
                        return "E";
                    }
                case "1111":
                    {
                        return "F";
                    }
                default:
                    {
                        return String.Empty;
                    }
            }
        }

        private static string GetOctalDigit(string threeBitGroup)
        {
            switch (threeBitGroup)
            {
                case "000":
                    {
                        return "0";
                    }
                case "001":
                    {
                        return "1";
                    }
                case "010":
                    {
                        return "2";
                    }
                case "011":
                    {
                        return "3";
                    }
                case "100":
                    {
                        return "4";
                    }
                case "101":
                    {
                        return "5";
                    }
                case "110":
                    {
                        return "6";
                    }
                case "111":
                    {
                        return "7";
                    }
                default:
                    {
                        return String.Empty;
                    }
            }
        }

        private static uint GetRomanDigitValue(char digit)
        {
            switch (Char.ToUpper(digit))
            {
                case 'M':
                    {
                        return 1000;
                    }
                case 'D':
                    {
                        return 500;
                    }
                case 'C':
                    {
                        return 100;
                    }
                case 'L':
                    {
                        return 50;
                    }
                case 'X':
                    {
                        return 10;
                    }
                case 'V':
                    {
                        return 5;
                    }
                case 'I':
                    {
                        return 1;
                    }
                default:
                    {
                        throw new ArgumentException("Unknown digit.");
                    }
            }
        }

        #endregion
    }
}
