using System;

public class Worker : Human
{
    #region Private Fields

    private double weekSalary;

    private double workingHoursPerDay;

    private double moneyPerHour;

    #endregion

    #region Properties

    public double WeekSalary
    {
        get
        {
            return weekSalary;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Week salary must be a positive number.");
            }
            weekSalary = value;
        }
    }

    public double WorkingHoursPerDay
    {
        get
        {
            return workingHoursPerDay;
        }
        private set
        {
            if (value >= 24)
            {
                throw new ArgumentException("Working hours per day must be less than 24.");
            }
            workingHoursPerDay = value;
        }
    }

    public double MoneyPerHour
    {
        get
        {
            return moneyPerHour;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Money per hour must be a positive number.");
            }
            moneyPerHour = value;
        }
    }

    #endregion

    #region Constructors

    public Worker(string firstName, string lastName, double weekSalary, double workingHoursPerDay, int workingDaysPerWeek)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHoursPerDay = workingHoursPerDay;
        this.moneyPerHour = GetMoneyPerHour(workingDaysPerWeek);
    }

    public Worker(string firstName, string lastName, double weekSalary, double workingHoursPerDay)
        : this(firstName, lastName, weekSalary, workingHoursPerDay, 5)
    {
    }

    public Worker(string firstName, string lastName, double weekSalary, int workingDaysPerWeek)
        : this(firstName, lastName, weekSalary, 8, workingDaysPerWeek)
    {
    }

    public Worker(string firstName, string lastName, double weekSalary)
        : this(firstName, lastName, weekSalary, 8, 5)
    {
    }

    #endregion

    #region Public Methods

    public override string ToString()
    {
        return String.Format("{0}, week salary = {1:F2}, money per hour = {2:F2}",
            base.ToString(), this.WeekSalary, this.MoneyPerHour);
    }

    #endregion

    #region Private Methods

    private double GetMoneyPerHour(int workingDaysPerWeek)
    {
        return this.weekSalary / (workingDaysPerWeek * this.workingHoursPerDay);
    }

    #endregion
}
