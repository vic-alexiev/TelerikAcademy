using System;

public class Person
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Person(string firstName, string lastName)
    {
        if (String.IsNullOrWhiteSpace(firstName) || String.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Names cannot be null or empty.");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.FirstName, this.LastName);
    }
}
