using System;

internal class Salaries
{
    private static bool[,] isBoss;
    private static long[] salaries;

    private static void CalculateSalary(int employee, int employeesCount)
    {
        bool hasSubordinates = false;
        for (int other = 0; other < employeesCount; other++)
        {
            if (isBoss[employee, other])
            {
                hasSubordinates = true;
                if (salaries[other] == 0)
                {
                    CalculateSalary(other, employeesCount);
                }

                salaries[employee] += salaries[other];
            }
        }

        if (!hasSubordinates)
        {
            salaries[employee] = 1;
        }
    }

    private static void Main()
    {
        int employeesCount = int.Parse(Console.ReadLine());

        isBoss = new bool[employeesCount, employeesCount];
        salaries = new long[employeesCount];

        for (int i = 0; i < employeesCount; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == 'Y')
                {
                    isBoss[i, j] = true;
                }
            }
        }

        for (int employee = 0; employee < employeesCount; employee++)
        {
            if (salaries[employee] == 0)
            {
                CalculateSalary(employee, employeesCount);
            }
        }

        long total = 0;
        for (int i = 0; i < employeesCount; i++)
        {
            total += salaries[i];
        }

        Console.WriteLine(total);
    }
}
