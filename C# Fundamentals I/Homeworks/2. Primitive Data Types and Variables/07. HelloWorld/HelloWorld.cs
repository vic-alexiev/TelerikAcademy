using System;

class HelloWorld
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object helloWorldAsObject = String.Format("{0}, {1}!", hello, world);

        Console.WriteLine(helloWorldAsObject);

        //string helloWorldAsString = helloWorldAsObject.ToString();
        //string helloWorldAsString = Convert.ToString(helloWorldAsObject);
        string helloWorldAsString = (string)helloWorldAsObject;

        Console.WriteLine(helloWorldAsString);

    }
}
