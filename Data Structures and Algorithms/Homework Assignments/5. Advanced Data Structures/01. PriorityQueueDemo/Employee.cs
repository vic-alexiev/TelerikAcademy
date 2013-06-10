using System;

public class Employee : IComparable<Employee>
{
    public string LastName { get; private set; }
    public double Priority { get; private set; } // smaller values are higher priority

    public Employee(string lastName, double priority)
    {
        this.LastName = lastName;
        this.Priority = priority;
    }

    public override string ToString()
    {
        return "(" + this.LastName + ", " + this.Priority.ToString("F1") + ")";
    }

    public int CompareTo(Employee other)
    {
        return this.Priority.CompareTo(other.Priority);
    }
}
