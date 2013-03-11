using System;
using System.Collections.Generic;

public abstract class Animal
{
    private string name;
    private int age;
    private bool isMale;

    public string Name
    {
        get
        {
            return name;
        }
        protected set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            name = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }
            age = value;
        }
    }

    public bool IsMale
    {
        get
        {
            return isMale;
        }
        protected set
        {
            isMale = value;
        }
    }

    protected Animal(string name, int age, bool isMale)
    {
        this.Name = name;
        this.Age = age;
        this.IsMale = isMale;
    }

    public override string ToString()
    {
        return String.Format("{0}: name = {1}, age = {2}, sex = {3}",
            this.GetType().Name, this.Name, this.Age, this.IsMale ? "male" : "female");
    }

    public static Type GetAnimalType(string sound)
    {
        switch (sound)
        {
            case "woof, woof":
                {
                    return typeof(Dog);
                }
            case "ribbit, ribbit":
                {
                    return typeof(Frog);
                }
            case "meow":
                {
                    return typeof(Pussycat);
                }
            case "miaou":
                {
                    return typeof(Kitten);
                }
            case "purr":
                {
                    return typeof(Tomcat);
                }
            default:
                {
                    return typeof(Animal);
                }
        }
    }

    public static decimal GetAverageAge(IEnumerable<Animal> source)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        decimal sum = 0;
        long count = 0L;

        foreach (Animal animal in source)
        {
            sum += animal.Age;
            count++;
        }

        if (count == 0L)
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }
        else
        {
            return sum / count;
        }
    }
}