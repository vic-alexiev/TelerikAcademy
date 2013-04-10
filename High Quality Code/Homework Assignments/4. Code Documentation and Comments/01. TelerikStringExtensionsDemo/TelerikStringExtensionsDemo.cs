using System;
using System.Linq;
using System.Text;
using TelerikStringExtensions;

/// <summary>
/// Demonstrates the use of the extension methods for the <see cref="System.String"/> class.
/// </summary>
internal class TelerikStringExtensionsDemo
{
    private static void Main()
    {
        string value1 = "Telerik Academy";
        Console.WriteLine(value1.ToMD5Hash());

        string value2 = "yes";
        Console.WriteLine(value2.ToBoolean());

        string value3 = "-32768";
        Console.WriteLine(value3.ToShort());

        string value4 = "1234567890";
        Console.WriteLine(value4.ToInteger());

        string value5 = "9223372036854775807";
        Console.WriteLine(value5.ToLong());

        string value6 = "20013/4/30 15:31:00";
        Console.WriteLine(value6.ToDateTime());

        string value7 = "aB";
        Console.WriteLine(value7.CapitalizeFirstLetter());

        string value8 = "The quick brown fox jumps over the lazy dog";
        Console.WriteLine(value8.GetStringBetween("fox", "dog", 20));

        string value9 = "Стани, стани, юнак балкански";
        Console.WriteLine(value9.ConvertCyrillicToLatinLetters());

        string value10 = "It is a truth universally acknowledged";
        Console.WriteLine(value10.ConvertLatinToCyrillicKeyboard());

        string value11 = "петър.иванов";
        Console.WriteLine(value11.ToValidUsername());

        string value12 = "протокол от тайното събрание на общинската избирателна комисия, община РАЗЛОГ, 11 май 2013.docx";
        Console.WriteLine(value12.ToValidLatinFileName());

        string value13 = "The quick brown fox jumps over the lazy dog";
        Console.WriteLine(value13.GetFirstCharacters(7));

        string value14 = "ReadOnlyMultiDictionaryBase.cs";
        Console.WriteLine(value14.GetFileExtension());

        string value15 = "doc";
        Console.WriteLine(value15.ToContentType());

        string value16 = "test";
        Console.WriteLine(string.Join(string.Empty, Encoding.ASCII.GetBytes(value16)));
        Console.WriteLine(string.Join(string.Empty, value16.ToByteArray()));
    }
}
