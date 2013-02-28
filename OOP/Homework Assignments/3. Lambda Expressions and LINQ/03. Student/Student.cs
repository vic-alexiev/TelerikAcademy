using System;

public class Student
{
    #region Private Fields

    private DateTime dateOfBirth;
    private string firstName;
    private string lastName;

    #endregion

    #region Properties

    public string FirstName
    {
        get
        {
            return firstName;
        }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("First name cannot be null or empty.");
            }
            firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Last name cannot be null or empty.");
            }
            lastName = value;
        }
    }

    #endregion

    #region Constructors

    public Student(string firstName, string lastName, DateTime dateOfBirth)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.dateOfBirth = dateOfBirth;
    }

    #endregion

    #region Public Methods

    public override string ToString()
    {
        return String.Format("{0} {1} (age {2})", this.FirstName, this.LastName, this.GetAge());
    }

    public int GetAge()
    {
        return CalculateAge(this.dateOfBirth, DateTime.UtcNow);
    }

    #endregion

    #region Private Methods

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

    #endregion
}
