using ConsoleUtils;
using System;
using System.Text;

/// <summary>
/// http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/
/// http://docs.mongodb.org/ecosystem/drivers/csharp/
/// </summary>
internal class MongoDictionaryDemo
{
    private static void Main()
    {
        // The default console's font doesn't support Cyrillic letters.
        // We should find a font with Unicode support and change the
        // default font.
        Console.OutputEncoding = Encoding.UTF8;
        ConsoleHelper.SetConsoleFont(6);

        var dictionary = new MongoDictionary(
            "mongodb://localhost/?safe=true",
            "dictionary",
            "entries");

        //dictionary.InsertEntry("humongous", "огромен");

        string translation = dictionary.FindTranslationByName("humongous");

        Console.WriteLine(translation);

        var entries = dictionary.GetAllEntries();

        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }
}
