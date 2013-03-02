using System;
using System.Collections.Generic;
using System.Linq;

class AnimalsDemo
{
    private static IEnumerable<Tuple<string, double>> GetAverageAges(Animal[] animals)
    {
        var averageAges =
            from animal in animals
            group animal by animal.GetType() into animalType
            select new Tuple<string, double>(animalType.Key.Name, animalType.Average(a => a.Age));

        return averageAges;
    }

    static void Main()
    {
        IVocal[] noisyCreatures = new IVocal[]
        {
            new Dog("Rex", 5, true),
            new Frog("Kermit", 58, true),
            new Dog("Stella", 2, false),
            new Tomcat("Hoho", 8),
            new Pussycat("Cleopatra", 5),
            new Dog("Caesar", 3, true),
        };

        foreach (IVocal noisyCreature in noisyCreatures)
        {
            Console.WriteLine(noisyCreature.GetTypicalSound());
        }

        Animal[] animals = new Animal[]
        {
            new Dog("Rex", 5, true),
            new Frog("Kermit", 58, true),
            new Dog("Stella", 2, false),
            new Tomcat("Hoho", 8),
            new Tomcat("George", 3),
            new Tomcat("Garfield", 10),
            new Pussycat("Cleopatra", 5),
            new Dog("Betty", 12, false),
            new Dog("Mike", 7, true),
            new Dog("Caesar", 3, true),
        };

        decimal averageAge = Animal.GetAverageAge(animals);
        Console.WriteLine("Average age: {0:F2}", averageAge);

        var averageAges = GetAverageAges(animals);
        foreach (var tuple in averageAges)
        {
            Console.WriteLine("Animal: {0}, Average Age: {1:F2}", tuple.Item1, tuple.Item2);
        }
    }
}
