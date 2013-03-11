using System;

public abstract class Human : IComparable
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    protected Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Human otherHuman = obj as Human;
        if (otherHuman != null)
        {
            if (this.FirstName.CompareTo(otherHuman.FirstName) == 0)
            {
                return this.LastName.CompareTo(otherHuman.LastName);
            }

            return this.FirstName.CompareTo(otherHuman.FirstName);
        }
        else
        {
            throw new ArgumentException("Object is not a Human.");
        }
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.FirstName, this.LastName);
    }
}
