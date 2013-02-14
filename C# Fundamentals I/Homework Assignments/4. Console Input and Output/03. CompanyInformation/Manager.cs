using System;

internal class Manager
{
    #region Private fields

    private string firstName;
    private string lastName;
    private byte age;
    private int phoneNumber;

    #endregion

    #region Properties

    public string FirstName
    {
        get
        {
            return firstName;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }
    }

    public byte Age
    {
        get
        {
            return age;
        }
    }

    public int PhoneNumber
    {
        get
        {
            return phoneNumber;
        }
    }

    #endregion

    #region Constructor

    public Manager(string firstName, string lastName, byte age, int phoneNumber)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.phoneNumber = phoneNumber;
    }

    #endregion

    #region Public methods

    public override string ToString()
    {
        return String.Format("Manager:\n" +
            "First name . . . . . . . . . . . . : {0}\n" +
            "Last name. . . . . . . . . . . . . : {1}\n" +
            "Age. . . . . . . . . . . . . . . . : {2}\n" +
            "Phone number . . . . . . . . . . . : {3: (+359) (###) ## ## ##}\n", firstName, lastName, age, phoneNumber);
    }

    #endregion
}
