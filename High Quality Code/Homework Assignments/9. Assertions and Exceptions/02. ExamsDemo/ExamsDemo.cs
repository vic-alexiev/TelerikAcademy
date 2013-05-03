// ********************************
// <copyright file="ExamsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using System.Collections.Generic;
using Exams;

/// <summary>
/// Used to demonstrate the use of <see cref="Exam"/> classes.
/// </summary>
internal class ExamsDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        try
        {
            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55, 100),
                new CSharpExam(100, 100),
                new SimpleMathExam(1),
                new CSharpExam(0, 100)
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultAsPercentage();
            Console.WriteLine("Average result = {0:P0}", peterAverageResult);
        }
        catch (ArgumentOutOfRangeException aoorex)
        {
            Console.WriteLine(aoorex.Message);
        }
        catch (ArgumentNullException anex)
        {
            Console.WriteLine(anex.Message);
        }
        catch (ArgumentException aex)
        {
            Console.WriteLine(aex.Message);
        }
    }
}
