using System;
using System.Collections.Generic;

public static class RpnExpressionProcessor
{
    private static List<IExpression> expressionList;

    private static void InitializeExpressionList(string[] tokens)
    {
        expressionList = new List<IExpression>();

        foreach (string token in tokens)
        {
            switch (token)
            {
                case "+":
                    {
                        expressionList.Add(new TerminalExpressionPlus());
                        break;
                    }
                case "-":
                    {
                        expressionList.Add(new TerminalExpressionMinus());
                        break;
                    }
                case "~":
                    {
                        expressionList.Add(new TerminalExpressionUnaryMinus());
                        break;
                    }
                case "*":
                    {
                        expressionList.Add(new TerminalExpressionMultiply());
                        break;
                    }
                case "/":
                    {
                        expressionList.Add(new TerminalExpressionDivide());
                        break;
                    }
                case "ln":
                    {
                        expressionList.Add(new TerminalExpressionNaturalLogarithm());
                        break;
                    }
                case "sqrt":
                    {
                        expressionList.Add(new TerminalExpressionSquareRoot());
                        break;
                    }
                case "pow":
                    {
                        expressionList.Add(new TerminalExpressionPower());
                        break;
                    }
                default:
                    {
                        expressionList.Add(new TerminalExpressionNumber(Double.Parse(token)));
                        break;
                    }
            }
        }
    }

    public static double Evaluate(string[] rpnExpression)
    {
        InitializeExpressionList(rpnExpression);

        Stack<double> context = new Stack<double>();

        foreach (IExpression ex in expressionList)
        {
            ex.Evaluate(context);
        }

        return context.Pop();
    }
}
