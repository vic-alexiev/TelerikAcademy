using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class DualKeyDictionaryDemo
{
    private static void Main()
    {
        DualKeyDictionary<int, string, string> dictionary = new DualKeyDictionary<int, string, string>();

        // Adding "Zero" to dictionary with primary int key of 0
        dictionary.Add(0, "Zero");
        // Associating binary sub-key of "0000" with primary int key of 0
        dictionary.Associate("0000", 0);

        // Adding "Three" to dictionary with primary int key of 3 and a binary sub-key of "0011"
        dictionary.Add(3, "0011", "Three");

        // Getting value for binary sub-key "0000"
        string value = dictionary["0000"]; // value will be "Zero"
        Console.WriteLine(value);
        // Getting value for int primary key 0
        value = dictionary[0]; // val will be "Zero"
        Console.WriteLine(value);
    }
}
