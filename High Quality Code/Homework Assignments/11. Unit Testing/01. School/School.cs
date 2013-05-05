// ********************************
// <copyright file="School.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

/// <summary>
/// Represents a school as part of a university.
/// </summary>
public class School
{
    #region Private Fields

    /// <summary>
    /// The name of the school.
    /// </summary>
    private string name;

    /// <summary>
    /// A list of courses taught at the school.
    /// </summary>
    private IList<Course> courses;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="School"/> class.
    /// </summary>
    /// <param name="name">School name.</param>
    public School(string name)
    {
        this.Name = name;
        this.courses = new List<Course>();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the name of the school.
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
    /// Gets the list of courses taught at the school.
    /// </summary>
    /// <value>Gets the value of the courses list.</value>
    public IList<Course> Courses
    {
        get
        {
            return new ReadOnlyCollection<Course>(this.courses);
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a course to the list of courses taught at the school.
    /// </summary>
    /// <param name="course">The course to add.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when
    /// <paramref name="course"/> is null.</exception>
    public void AddCourse(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException("course", "course cannot be null.");
        }

        this.courses.Add(course);
    }

    /// <summary>
    /// Removes a course passed as a <see cref="Course"/> instance.
    /// </summary>
    /// <param name="course">The course to remove.</param>
    /// <returns>True if operation succeeds, otherwise - false.</returns>
    public bool RemoveCourse(Course course)
    {
        return this.courses.Remove(course);
    }

    #endregion
}
