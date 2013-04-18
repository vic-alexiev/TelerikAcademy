// ********************************
// <copyright file="PersonFactory.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using Enums;

/// <summary>
/// Used to create instances of the <see cref="Person"/> class.
/// </summary>
internal class PersonFactory
{
    /// <summary>
    /// Creates a <see cref="Person"/> and sets its properties.
    /// </summary>
    /// <param name="name">The name of the person.</param>
    /// <param name="age">The age of the person.</param>
    /// <param name="sex">The sex of the person.</param>
    /// <returns>The <see cref="Person"/> which has been created.</returns>
    public Person CreatePerson(string name, int? age, Sex sex)
    {
        Person person = new Person(name, age, sex);
        return person;
    }
}
