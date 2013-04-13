using System;

/// <summary>
/// Demonstrates correct naming of identifiers in C#, nothing more.
/// </summary>
internal class CSharpRefactoring
{
    /// <summary>
    /// A completely useless constant. 
    /// </summary>
    public const int MaxCount = 6;

    /// <summary>
    /// The main entry point of the program.
    /// </summary>
    private static void Main()
    {
        ConsolePrinter consolePrinter = new ConsolePrinter();
        consolePrinter.Print(true);
    }

    /// <summary>
    /// Used to print values to the console.
    /// </summary>
    private class ConsolePrinter
    {
        /// <summary>
        /// Prints <paramref name="value"/> to the console.
        /// </summary>
        /// <param name="value">The value to print.</param>
        public void Print(bool value)
        {
            string valueAsString = value.ToString();
            Console.WriteLine(valueAsString);
        }
    }
}
