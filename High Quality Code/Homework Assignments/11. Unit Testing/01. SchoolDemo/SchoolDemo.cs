// ********************************
// <copyright file="SchoolDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;

/// <summary>
/// Used to demonstrate the School project functionality.
/// </summary>
internal class SchoolDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        Student martinFowler = new Student("Martin Fowler");
        Student kentBeck = new Student("Kent Beck");
        Student erichGamma = new Student("Erich Gamma");
        Student ralphJohnson = new Student("Ralph Johnson");

        Course operatingSystems = new Course("Operating Systems", "Andrew S. Tanenbaum");

        operatingSystems.AddStudent(martinFowler);
        operatingSystems.AddStudent(kentBeck);
        operatingSystems.AddStudent(erichGamma);

        bool studentRemoved = operatingSystems.RemoveStudent(null);
        Console.WriteLine("Student removed: " + studentRemoved);

        Console.WriteLine("Courses:");
        Console.WriteLine(operatingSystems);

        School schoolOfEngineering = new School("School of Engineering");
        schoolOfEngineering.AddCourse(operatingSystems);
        Console.WriteLine(schoolOfEngineering.Courses.Count);
    }
}
