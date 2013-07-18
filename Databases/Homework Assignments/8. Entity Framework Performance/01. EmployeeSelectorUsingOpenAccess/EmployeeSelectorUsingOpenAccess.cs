using OpenAccessModels;
using System;
using System.Linq;
using Telerik.OpenAccess.FetchOptimization;

internal class EmployeeSelectorUsingOpenAccess
{
    private static void SelectEmployeesNoInclude()
    {
        using (var context = new TelerikAcademyEntities())
        {
            Console.WriteLine("Employees:");
            foreach (var employee in context.Employees)
            {
                Console.WriteLine(
                    "Name: {0} {1}\nDepartment: {2}\nTown: {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Department.Name,
                    employee.Address.Town.Name);
            }
        }
    }

    /// <summary>
    /// Using FetchStrategy is the way in OpenAccess
    /// to perform Include().
    /// </summary>
    private static void SelectEmployeesWithStrategy()
    {
        using (var context = new TelerikAcademyEntities())
        {
            var strategy = new FetchStrategy();

            strategy.LoadWith<Employee>(e => e.Department);
            strategy.LoadWith<Employee>(e => e.Address);
            strategy.LoadWith<Address>(a => a.Town);

            context.FetchStrategy = strategy;

            foreach (var employee in context.Employees)
            {
                Console.WriteLine(
                    "Name: {0} {1}\nDepartment: {2}\nTown: {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Department.Name,
                    employee.Address.Town.Name);
            }
        }
    }

    private static void SelectEmployeesUsingToList()
    {
        using (var context = new TelerikAcademyEntities())
        {
            Console.WriteLine("Employees:");

            var employees = context.Employees.ToList()
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Address = e.Address.AddressText,
                    TownName = e.Address.Town.Name
                })
                .ToList()
                .Where(e => e.TownName == "Sofia")
                .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine(
                    "Name: {0} {1}\nAddress: {2}\nTown: {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Address,
                    employee.TownName);
            }
        }
    }

    private static void SelectEmployeesUsingOptimization()
    {
        using (var context = new TelerikAcademyEntities())
        {
            Console.WriteLine("Employees:");

            var employees =
                from employee in context.Employees
                join address in context.Addresses
                on employee.AddressID equals address.AddressID
                join town in context.Towns
                on address.TownID equals town.TownID
                where town.Name == "Sofia"
                select employee;

            foreach (var employee in employees)
            {
                Console.WriteLine(
                    "Name: {0} {1}\nAddress: {2}\nTown: {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Address.AddressText,
                    employee.Address.Town.Name);
            }
        }
    }

    static void Main()
    {
        //SelectEmployeesNoInclude();
        SelectEmployeesWithStrategy();
        //SelectEmployeesUsingToList();
        //SelectEmployeesUsingOptimization();
    }
}
