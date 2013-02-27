using System;

public class Human
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.FirstName, this.LastName);
    }
}
