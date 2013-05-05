// ********************************
// <copyright file="Student.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using _01.School.Properties;

/// <summary>
/// Represents a student.
/// </summary>
public class Student
{
    #region Private Fields

    /// <summary>
    /// The name of the student.
    /// </summary>
    private string name;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Student"/> class.
    /// </summary>
    /// <param name="name">The name of the student.</param>
    /// <exception cref="System.ArgumentException">Thrown when
    /// <paramref name="name"/> is null, empty or contains only 
    /// whitespace characters.</exception>
    public Student(string name)
    {
        this.Name = name;
        this.Id = this.GetId();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets Student's Id maximum value
    /// </summary>
    /// <value>Gets the value from the settings file.</value>
    public static int IdMaxValue
    {
        get
        {
            return Settings.Default.StudentIdMaxValue;
        }
    }

    /// <summary>
    /// Gets Student's Id minimum value
    /// </summary>
    /// <value>Gets the value from the settings file.</value>
    public static int IdMinValue
    {
        get
        {
            return Settings.Default.StudentIdMinValue;
        }
    }

    /// <summary>
    /// Gets or sets Student's name.
    /// </summary>
    /// <value>Gets or sets the value of the name field.</value>
    /// <exception cref="System.ArgumentException">Thrown when
    /// the value to set is null, empty or contains only 
    /// whitespace characters.</exception>
    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value cannot be null or empty.", "value");
            }

            this.name = value;
        }
    }

    /// <summary>
    /// Gets Student's id (a unique identifier).
    /// </summary>
    public int Id { get; private set; }

    #endregion

    #region Public Methods

    /// <summary>
    /// Returns the string representation of the student.
    /// </summary>
    /// <returns>A string containing Student's name and Id.</returns>
    public override string ToString()
    {
        return string.Format("{{ Id = {0}, Name = {1} }}", this.Id, this.Name);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Generates Student's unique identifier.
    /// If the Id reaches the maximum value, then
    /// counting starts again from the minimum value.
    /// </summary>
    /// <returns>A globally unique Student Id.</returns>
    private int GetId()
    {
        int id = Settings.Default.NextStudentId;

        if (id == Settings.Default.StudentIdMaxValue)
        {
            Settings.Default.NextStudentId = Settings.Default.StudentIdMinValue;
        }
        else
        {
            Settings.Default.NextStudentId++;
        }

        Settings.Default.Save();

        return id;
    }

    #endregion
}
