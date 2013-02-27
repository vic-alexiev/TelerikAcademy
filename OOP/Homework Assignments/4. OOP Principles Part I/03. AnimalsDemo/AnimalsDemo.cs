using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AnimalsDemo
{
    private static double GetAverageAge(IEnumerable<Animal> animalCollection)
    {
        long sum = 0;
        int count = 0;
        foreach (Animal animal in animalCollection)
        {
            count++;
            sum += animal.Age;
        }

        return (double)sum / count;
    }

    static void Main()
    {
        Animal[] animals = new Animal[]
        {
            new Dog("Rex", 5, true),
            new Frog("Kermit", 58, true),
            new Dog("Stella", 2, false),
            new Tomcat("Hoho", 8),
            new Pussycat("Cleopatra", 5),
            new Dog("Caesar", 3, true),
        };

        double averageAge = GetAverageAge(animals);
        Console.WriteLine("Average age: {0} years", averageAge);

        foreach (Animal animal in animals)
        {
            string sound = animal.GetTypicalSound();
            Console.WriteLine("I'm a {0}", Animal.GetAnimalType(sound).Name);
            Console.WriteLine(animal);
            Console.WriteLine(sound);
        }
    }
}
