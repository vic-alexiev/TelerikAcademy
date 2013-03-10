using PersonInfo;
using System;

class PersonInfoDemo
{
    static void Main()
    {
        Person richardStallman = new Person("Richard Stallman", new DateTime(1953, 3, 16));
        Console.WriteLine(richardStallman);

        Person lectotype = new Person("Carl Linnaeus");
        Console.WriteLine(lectotype);
    }
}
