using System;
using System.Text;

class StringBuilderExtensionDemo
{
    static void Main()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("0123456789");

        StringBuilder result = stringBuilder.Substring(0, 11);
        Console.WriteLine(result);
    }
}
