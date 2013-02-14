using System;

public class Holder
{
    #region Private Fields

    private string firstName;
    private string middleName;
    private string lastName;

    #endregion

    #region Properties

    public string FirstName
    {
        get
        {
            return firstName;
        }
    }

    public string MiddleName
    {
        get
        {
            return middleName;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }
    }

    #endregion

    #region Constructors

    public Holder() : this(String.Empty, String.Empty, String.Empty)
    {
    }

    public Holder(string firstName, string middleName, string lastName)
    {
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
    }

    #endregion

    #region Public Methods

    public override string ToString()
    {
        return String.Format("Holder\n\tFirst name: {0}\n\tMiddle name: {1}\n\tLast name: {2}\n", firstName, middleName, lastName);
    }

    #endregion
}
