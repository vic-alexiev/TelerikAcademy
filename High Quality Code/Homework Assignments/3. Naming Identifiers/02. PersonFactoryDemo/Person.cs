// ********************************
// <copyright file="Person.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using Enums;

/// <summary>
/// Represents a person.
/// </summary>
internal class Person
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class.
    /// </summary>
    /// <param name="name">The name of the person.</param>
    /// <param name="age">The age of the person.</param>
    /// <param name="sex">The sex of the person.</param>
    public Person(string name, int? age, Sex sex)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("name cannot be null or empty.");
        }

        if (age <= 0)
        {
            throw new ArgumentException("age must be positive.");
        }

        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Person"/> class.
    /// </summary>
    public Person()
        : this(string.Empty, null, Sex.Unknown)
    {
    }

    /// <summary>
    /// Gets the name of the person.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the age of the person.
    /// </summary>
    public int? Age { get; private set; }

    /// <summary>
    /// Gets the sex of the person.
    /// </summary>
    public Sex Sex { get; private set; }

    /// <summary>
    /// Returns the string representation of a <see cref="Person"/>.
    /// </summary>
    /// <returns>The string representation of this instance.</returns>
    public override string ToString()
    {
        return string.Format(
            "Name: {0}, Age: {1}, Sex: {2}",
            string.IsNullOrWhiteSpace(this.Name) ? "[no name specified]" : this.Name,
            this.Age.HasValue ? this.Age.ToString() : "[no age specified]",
            this.Sex);
    }
}
