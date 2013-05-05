// ********************************
// <copyright file="Course.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

/// <summary>
/// Represents a university course.
/// </summary>
public class Course
{
    #region Constants

    /// <summary>
    /// Represents the maximum number of students which can attend a course.
    /// </summary>
    public const int MaxStudentsCount = 30;

    #endregion

    #region Private Fields

    /// <summary>
    /// The name of the course.
    /// </summary>
    private string name;

    /// <summary>
    /// The name of the professor in charge of the course.
    /// </summary>
    private string professorName;

    /// <summary>
    /// A list of students attending the course.
    /// </summary>
    private IList<Student> students;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Course"/> class.
    /// </summary>
    /// <param name="name">The name of the course.</param>
    /// <param name="professorName">The name of the professor.</param>
    public Course(string name, string professorName)
    {
        this.Name = name;
        this.ProfessorName = professorName;
        this.students = new List<Student>();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the name of the course.
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
    /// Gets or sets the name of the professor in charge of the course.
    /// </summary>
    /// <value>Gets or sets the value of the professorName field.</value>
    /// <exception cref="System.ArgumentException">Thrown when
    /// the value to set is null, empty or contains only 
    /// whitespace characters.</exception>
    public string ProfessorName
    {
        get
        {
            return this.professorName;
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value cannot be null or empty.", "value");
            }

            this.professorName = value;
        }
    }

    /// <summary>
    /// Gets the list of students attending the course.
    /// </summary>
    /// <value>Gets the value of the students list.</value>
    public IList<Student> Students
    {
        get
        {
            return new ReadOnlyCollection<Student>(this.students);
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a student to the list of students attending the course.
    /// </summary>
    /// <param name="student">The student to add.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when
    /// <paramref name="student"/> is null.</exception>
    public void AddStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException("student", "student cannot be null.");
        }

        if (this.students.Count == MaxStudentsCount)
        {
            throw new InvalidOperationException(
                string.Format(
                "Student cannot be added. Course attendants have reached the maximum number ({0}).",
                MaxStudentsCount));
        }

        this.students.Add(student);
    }

    /// <summary>
    /// Removes a student passed as a <see cref="Student"/> instance.
    /// </summary>
    /// <param name="student">The student to remove.</param>
    /// <returns>True if operation succeeds, otherwise - false.</returns>
    public bool RemoveStudent(Student student)
    {
        return this.students.Remove(student);
    }

    /// <summary>
    /// Returns the string representation of the course info - 
    /// name, professor, students.
    /// </summary>
    /// <returns>A string which represents the course info.</returns>
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendFormat("Name = {0}", this.Name);

        result.AppendFormat("; Professor = {0}", this.ProfessorName);

        result.AppendFormat("; Students = {0}", this.GetStudentsAsString());

        return result.ToString();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Converts the list of students into a string.
    /// </summary>
    /// <returns>A string which contains all the names in the students list,
    /// comma-separated and surrounded with curly brackets.</returns>
    private string GetStudentsAsString()
    {
        if (this.students.Count == 0)
        {
            return "{ }";
        }
        else
        {
            return "{ " + string.Join(", ", this.students) + " }";
        }
    }

    #endregion
}
