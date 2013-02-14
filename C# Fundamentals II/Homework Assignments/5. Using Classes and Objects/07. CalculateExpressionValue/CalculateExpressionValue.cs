using System;

class CalculateExpressionValue
{
    static void Main()
    {
        Console.Write("Enter an expression to evaluate: ");
        string expression = Console.ReadLine();

        bool isBalanced = ExpressionAnalyzer.IsBalanced(expression);

        if (!isBalanced)
        {
            Console.WriteLine("Your expression is not balanced (contains misnesting brackets).");
        }

        string[] tokens = ExpressionAnalyzer.Parse(expression);
        string[] rpnTokens = ExpressionAnalyzer.TranslateInReversePolishNotation(tokens);

        double value = RpnExpressionProcessor.Evaluate(rpnTokens);

        Console.WriteLine("Your expression has been evaluated to {0:N4}.", value);
    }
}
