using System;

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public Student(string firstName, string lastName, DateTime dateOfBirth)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = CalculateAge(dateOfBirth, DateTime.UtcNow);
    }

    public override string ToString()
    {
        return String.Format("{0} {1} (age {2})", this.FirstName, this.LastName, this.Age);
    }

    private int CalculateAge(DateTime dateOfBirth, DateTime now)
    {
        int age = now.Year - dateOfBirth.Year;

        if (now.Month < dateOfBirth.Month ||
            now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)
        {
            age--;
        }

        return age;
    }
}
