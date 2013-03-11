using System;

public abstract class Person
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    protected Person(string firstName, string lastName)
    {
        if (String.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be null or empty.");
        }

        if (String.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name cannot be null or empty.");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.FirstName, this.LastName);
    }
}
