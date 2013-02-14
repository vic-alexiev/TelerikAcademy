using System;
using System.Collections.Generic;

interface IExpression
{
    void Evaluate(Stack<double> context);
}

class TerminalExpressionNumber : IExpression
{
    private double number;

    public TerminalExpressionNumber(double number)
    {
        this.number = number;
    }

    public void Evaluate(Stack<double> context)
    {
        context.Push(number);
    }
}

class TerminalExpressionPlus : IExpression
{
    public void Evaluate(Stack<double> context)
    {
        context.Push(context.Pop() + context.Pop());
    }
}

class TerminalExpressionMinus : IExpression
{
    public void Evaluate(Stack<double> context)
    {
        context.Push(-context.Pop() + context.Pop());
    }
}

class TerminalExpressionUnaryMinus : IExpression
{
    public void Evaluate(Stack<double> context)
    {
        context.Push(-context.Pop());
    }
}

class TerminalExpressionMultiply : IExpression
{
    public void Evaluate(Stack<double> context)
    {
        context.Push(context.Pop() * context.Pop());
    }
}

class TerminalExpressionDivide : IExpression
{
    public void Evaluate(Stack<double> context)
    {
        double divisor = context.Pop();
        context.Push(context.Pop() / divisor);
    }
}

class TerminalExpressionNaturalLogarithm : IExpression
{
    public void Evaluate(Stack<double> context)
    {
        context.Push(Math.Log(context.Pop()));
    }
}

class TerminalExpressionSquareRoot : IExpression
{
    public void Evaluate(Stack<double> context)
    {
        context.Push(Math.Sqrt(context.Pop()));
    }
}

class TerminalExpressionPower : IExpression
{
    public void Evaluate(Stack<double> context)
    {
        double power = context.Pop();
        context.Push(Math.Pow(context.Pop(), power));
    }
}
