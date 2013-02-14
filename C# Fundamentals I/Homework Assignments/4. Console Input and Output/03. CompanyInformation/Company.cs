using System;

internal class Company
{
    #region Private fields

    private string name;
    private string address;
    private int phoneNumber;
    private string faxNumber;
    private string webSite;
    private Manager manager;

    #endregion

    #region Properties

    public string Name
    {
        get
        {
            return name;
        }
    }

    public string Address
    {
        get
        {
            return address;
        }
    }

    public int PhoneNumber
    {
        get
        {
            return phoneNumber;
        }
    }

    public string FaxNumber
    {
        get
        {
            return faxNumber;
        }
    }

    public string WebSite
    {
        get
        {
            return webSite;
        }
    }

    public Manager Manager
    {
        get
        {
            return manager;
        }
    }

    #endregion

    #region Constructor

    public Company(Manager manager, string name, string address, int phoneNumber, string faxNumber, string webSite)
    {
        this.manager = manager;
        this.name = name;
        this.address = address;
        this.phoneNumber = phoneNumber;
        this.faxNumber = faxNumber;
        this.webSite = webSite;
    }

    #endregion

    #region Public methods

    public override string ToString()
    {
        return String.Format("Company:\n" +
            "Name . . . . . . . . . . . . . . . : {0}\n" +
            "Address. . . . . . . . . . . . . . : {1}\n" +
            "Phone number . . . . . . . . . . . : {2: (+359) (###) ## ## ##}\n" +
            "Fax number . . . . . . . . . . . . : {3}\n" +
            "Web site . . . . . . . . . . . . . : {4}\n\n{5}", 
            name, address, phoneNumber, faxNumber, webSite, manager);
    }

    #endregion
}
