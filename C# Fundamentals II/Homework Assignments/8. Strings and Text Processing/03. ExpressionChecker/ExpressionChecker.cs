using System;
using System.Text.RegularExpressions;

class ExpressionChecker
{
    /// <summary>
    /// Checks if the brackets in the arithmetic expression are put correctly.
    /// <seealso cref="http://rosettacode.org/wiki/Balanced_brackets#C.23"/>
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static bool IsBalanced1(string expression)
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
    /// <see cref="http://blog.stevenlevithan.com/archives/balancing-groups"/>
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static bool IsBalanced2(string expression)
    {
        // for each left parenthesis push in the stack, for each right parenthesis
        // pop from the stack; in the end the stack should be empty
        string pattern = @"^(?:[^()]+|\((?<Depth>)|\)(?<-Depth>))*(?(Depth)(?!))$";

        Match match = Regex.Match(expression, pattern);

        return match.Success;
    }

    static void Main()
    {
        Console.Write("Enter an expression to check: ");
        string expression = Console.ReadLine();

        Console.WriteLine("This expression is{0} balanced.", IsBalanced1(expression) ? String.Empty : " not");
    }
}
