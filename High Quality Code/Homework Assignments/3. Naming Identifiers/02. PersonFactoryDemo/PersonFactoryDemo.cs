// ********************************
// <copyright file="PersonFactoryDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using Enums;

/// <summary>
/// A class which demonstrates the use of the <see cref="PersonFactory"/> class.
/// </summary>
internal class PersonFactoryDemo
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        PersonFactory factory = new PersonFactory();

        Person theOneAndOnly = factory.CreatePerson("Батката", 27, Sex.Male);
        Console.WriteLine(theOneAndOnly);

        Person sheIsTheWoman = factory.CreatePerson("Мацето", 26, Sex.Female);
        Console.WriteLine(sheIsTheWoman);
    }
}
