using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class ExpressionAnalyzer
{
    private static Stack<string> stack = new Stack<string>();

    private static string[] operatorTokens = { "+", "-", "*", "/", "~" };

    private static string[] functionTokens = { "ln", "sqrt", "pow" };

    #region Public Methods

    /// <summary>
    /// Checks if the brackets in the arithmetic expression are put correctly.
    /// <seealso cref="http://rosettacode.org/wiki/Balanced_brackets#C.23"/>
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static bool IsBalanced(string expression)
    {
        int level = 0;
        foreach (var character in expression)
        {
            if (character == ')')
            {
                if (level == 0)
                {
                    return false;
                }
                level--;
            }
            else if (character == '(')
            {
                level++;
            }
        }

        return level == 0;
    }

    /// <summary>
    /// Inserts white-spaces between the tokens so that
    /// the expression can be split into an array of strings.
    /// </summary>
    /// <remarks>
    /// <seealso cref="http://www.dreamincode.net/forums/topic/35320-reverse-polish-notation-in-c%23/"/>
    /// Only the "Regex.Replace" part of the method ReversePolishNotation.Parse has been used
    /// (but not the actual implementation of the shunting-yard algorithm).
    /// </remarks>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string[] Parse(string expression)
    {
        string buffer = expression;
        // capture numbers (anything like 11 or 22.34 is captured)
        buffer = Regex.Replace(buffer, @"(?<number>\d+(\.\d+)?)", " ${number} ");
        // captures symbols: + - * / ( )
        buffer = Regex.Replace(buffer, @"(?<op>[+\-*/()])", " ${op} ");
        // captures function names, currently captures the 3 functions
        // ln (natural logarithm), sqrt (square root) and pow (power)
        buffer = Regex.Replace(buffer, "(?<function>(ln|sqrt|pow))", " ${function} ");
        // trims up consecutive spaces and replace them with just one space
        buffer = Regex.Replace(buffer, @"\s+", " ").Trim();

        // The following chunk captures unary minus operations.
        // 1) We replace every minus sign with the string "MINUS".
        // 2) Then if we find a "MINUS" with a number or right parenthesis in front,
        //    then it's a normal minus operation.
        // 3) Otherwise, it's a unary minus operation.

        // Step 1.
        buffer = Regex.Replace(buffer, "-", "MINUS");
        // Step 2. Looking for generic number \d+(\.\d+)?
        buffer = Regex.Replace(buffer, @"(?<number>(\)|(\d+(\.\d+)?)))\s*MINUS", "${number} -");
        // Step 3. Use the tilde ~ as the unary minus operator
        buffer = Regex.Replace(buffer, "MINUS", "~");

        // tokenize it!
        return buffer.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Translates the expression into Reverse Polish notation (RPN) using
    /// the shunting-yard algorithm as implemented in Magdalina Todorova's
    /// textbook "C++ Programming" (2nd ed., part 2, pp. 114-119)
    /// <seealso cref="http://en.wikipedia.org/wiki/Shunting_yard_algorithm"/>
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string[] TranslateInReversePolishNotation(string[] expression)
    {
        stack.Clear();

        int rpnLength = expression.Count(p => p != "(" && p != ")" && p != ",");

        string[] rpnExpression = new string[rpnLength];

        stack.Push("(");

        int i = 0;
        int j = -1;
        int n = expression.Length;
        string x;

        while (i < n)
        {
            if (IsNumber(expression[i]))
            {
                j++;
                rpnExpression[j] = expression[i];
            }
            else if (IsFunctionToken(expression[i]))
            {
                stack.Push(expression[i]);
            }
            else if (expression[i] == "(")
            {
                stack.Push(expression[i]);
            }
            else if (expression[i] == ",")
            {
                i++;
                continue;
            }
            else if (expression[i] == ")")
            {
                x = stack.Pop();
                while (x != "(")
                {
                    j++;
                    rpnExpression[j] = x;
                    x = stack.Pop();
                }

                x = stack.Pop();

                if (IsFunctionToken(x))
                {
                    j++;
                    rpnExpression[j] = x;
                }
                else
                {
                    stack.Push(x);
                }
            }
            else if (IsOperatorToken(expression[i]))
            {
                x = stack.Pop();
                while (x != "(" && GetPrecedenceIndex(x) <= GetPrecedenceIndex(expression[i]))
                {
                    j++;
                    rpnExpression[j] = x;
                    x = stack.Pop();
                }
                stack.Push(x);
                stack.Push(expression[i]);
            }

            i++;
        }

        x = stack.Pop();
        while (x != "(")
        {
            j++;
            rpnExpression[j] = x;
            x = stack.Pop();
        }

        return rpnExpression;
    }

    #endregion

    #region Private Methods

    private static int GetPrecedenceIndex(string operatorToken)
    {
        int index;
        switch (operatorToken)
        {
            case "+":
                index = 2; break;
            case "-":
                index = 2; break;
            case "*":
                index = 1; break;
            case "/":
                index = 1; break;
            case "~":
                index = 0; break;
            default:
                index = -1; break;
        }

        return index;
    }

    private static bool IsNumber(string value)
    {
        string pattern = @"^\d+(\.\d+)?$";

        Match match = Regex.Match(value, pattern);
        if (match.Success)
        {
            return true;
        }

        return false;
    }

    private static bool IsOperatorToken(string value)
    {
        return operatorTokens.Contains(value);
    }

    private static bool IsFunctionToken(string value)
    {
        return functionTokens.Contains(value);
    }

    #endregion
}