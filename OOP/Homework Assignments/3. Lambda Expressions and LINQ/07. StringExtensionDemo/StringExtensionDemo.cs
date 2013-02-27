using System;
using System.Globalization;

class StringExtensionDemo
{
    static void Main()
    {
        string prideAndPrejudiceOpening = "It is a truth universally acknowledged, that a single man in possession of a good fortune, must be in want of a wife.";
        string sentenceCapitalized = prideAndPrejudiceOpening.CapitalizeFirstLetters(new CultureInfo("en-US"));
        Console.WriteLine(sentenceCapitalized);
    }
}
