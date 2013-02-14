using System;

public class Employee
{
    private string firstName;
    private string familyName;
    private byte age;
    private Gender gender;
    private int id;
    private int employeeNumber;

    public Employee()
        : this(String.Empty, String.Empty, 0, Gender.Male, 0, 0)
    {
    }

    public Employee(string firstName, string familyName, byte age, Gender gender, int id, int employeeNumber)
    {
        this.firstName = firstName;
        this.familyName = familyName;
        this.age = age;
        this.gender = gender;
        this.id = id;
        this.employeeNumber = employeeNumber;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}\nage: {2}\ngender: {3}\nID: {4}\nEmployee number: {5}",
            firstName, familyName, age, gender, id, employeeNumber);
    }
}
