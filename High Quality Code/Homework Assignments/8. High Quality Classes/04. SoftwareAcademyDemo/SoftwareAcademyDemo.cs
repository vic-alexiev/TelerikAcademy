// ********************************
// <copyright file="SoftwareAcademyDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using System.Collections.Generic;
using SoftwareAcademy;

/// <summary>
/// Used to test the software academy courses functionality.
/// </summary>
internal class SoftwareAcademyDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        LocalCourse localCourse = new LocalCourse("Databases");
        Console.WriteLine(localCourse);

        localCourse.Lab = "Enterprise";
        Console.WriteLine(localCourse);

        localCourse.Students = new List<string>() { "Peter", "Maria" };
        Console.WriteLine(localCourse);

        localCourse.TeacherName = "Svetlin Nakov";
        localCourse.AddStudent("Milena");
        localCourse.AddStudent("Todor");
        Console.WriteLine(localCourse);

        OffSiteCourse offsiteCourse = new OffSiteCourse(
            "PHP and WordPress Development",
            "Mario Peshev",
            new List<string>() { "Thomas", "Anne", "Steve" });
        Console.WriteLine(offsiteCourse);
    }
}
