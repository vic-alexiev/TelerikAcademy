using System;

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

    public Animal(string name, int age, bool isMale)
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

    public abstract string GetTypicalSound();

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
}