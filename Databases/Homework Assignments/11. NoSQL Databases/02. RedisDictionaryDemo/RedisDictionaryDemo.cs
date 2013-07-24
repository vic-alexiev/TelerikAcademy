using ConsoleUtils;
using ServiceStack.Redis;
using System;
using System.Text;

internal class RedisDictionaryDemo
{
    private static void Main()
    {
        // The default console's font doesn't support Cyrillic letters.
        // We should find a font with Unicode support and change the
        // default font.
        Console.OutputEncoding = Encoding.UTF8;
        ConsoleHelper.SetConsoleFont(6);

        string hashId = "dictionary";
        string word = "humongous";
        string synonym = "enormous";

        using (var redisClient = new RedisClient("127.0.0.1:6379"))
        {
            if (redisClient.Ping())
            {
                long entriesCount = redisClient.HExists(hashId, StringUtils.ToAsciiCharArray(word));

                if (entriesCount > 0)
                {
                    Console.WriteLine("This word is already in the dictionary.");
                }
                else
                {
                    redisClient.HSetNX(
                        hashId,
                        StringUtils.ToAsciiCharArray(word),
                        StringUtils.ToAsciiCharArray(synonym));

                    byte[] meaning = redisClient.HGet(hashId, StringUtils.ToAsciiCharArray(word));
                    Console.WriteLine(
                        "Word: {0}\nTranslation: {1}",
                        word,
                        StringUtils.StringFromByteArray(meaning));

                    redisClient.HDel(hashId, StringUtils.ToAsciiCharArray(word));
                }
            }
            else
            {
                Console.WriteLine("The Redis server isn't started.");
            }
        }
    }
}
