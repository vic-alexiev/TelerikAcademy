using System;

public class Student : IComparable<Student>
{
    public Student(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be null or empty.", "firstName");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name cannot be null or empty.", "lastName");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public int CompareTo(Student other)
    {
        int compareResult = this.LastName.CompareTo(other.LastName);
        if (compareResult == 0)
        {
            compareResult = this.FirstName.CompareTo(other.FirstName);
        }

        return compareResult;
    }

    public override string ToString()
    {
        return string.Format(this.FirstName + " " + this.LastName);
    }
}
