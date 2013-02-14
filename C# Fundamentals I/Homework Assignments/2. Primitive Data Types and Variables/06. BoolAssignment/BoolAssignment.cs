using System;

class BoolAssignment
{
    static void Main()
    {
        string gender = String.Empty;

        do
        {
            Console.WriteLine("Your gender (M/F):");
            gender = Console.ReadLine();
        }
        while (String.Compare(gender, "M", true) != 0
            && String.Compare(gender, "F", true) != 0);

        bool isFemale = true;

        if (String.Compare(gender, "M", true) == 0)
        {
            isFemale = false;
        }

        Console.WriteLine("So you are a {0}.", isFemale ? "woman" : "man");
    }
}
