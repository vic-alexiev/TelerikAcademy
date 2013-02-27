using System;

public class Student : Person
{
    public int Id { get; private set; }

    public Student(string firstName, string lastName, int id)
        : base(firstName, lastName)
    {
        this.Id = id;
    }

    public override string ToString()
    {
        return String.Format("{0}, ID = {1}", base.ToString(), this.Id);
    }
}
