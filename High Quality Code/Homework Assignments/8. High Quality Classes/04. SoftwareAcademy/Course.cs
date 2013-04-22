// ********************************
// <copyright file="Course.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    /// <summary>
    /// Represents a software academy course.
    /// </summary>
    public abstract class Course
    {
        #region Private Fields

        /// <summary>
        /// The name of the course.
        /// </summary>
        private string name;

        /// <summary>
        /// The name of the teacher in charge of the course.
        /// </summary>
        private string teacherName;

        /// <summary>
        /// A list of students attending the course.
        /// </summary>
        private IList<string> students;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// Used to initialize the inherited fields in the derived classes.
        /// </summary>
        /// <param name="name">The name of the course.</param>
        /// <param name="teacherName">The name of the teacher.</param>
        /// <param name="students">A list of students attending the course.</param>
        protected Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        /// <value>Gets or sets the value of the name field.</value>
        /// <exception cref="System.ArgumentException">Thrown when value is null or empty.</exception>
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
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the course teacher.
        /// </summary>
        /// <value>Gets or sets the value of the teacherName field.</value>
        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                this.teacherName = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of students attending the course.
        /// </summary>
        /// <value>Gets or sets the value of the students list.</value>
        public IList<string> Students
        {
            get
            {
                return new ReadOnlyCollection<string>(this.students);
            }

            set
            {
                if (value != null)
                {
                    this.students = new List<string>();

                    foreach (string student in value)
                    {
                        this.students.Add(string.Copy(student));
                    }
                }
                else
                {
                    this.students = null;
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a student to the list of students attending the course.
        /// </summary>
        /// <param name="student">The name of the student.</param>
        public void AddStudent(string student)
        {
            if (this.students == null)
            {
                this.students = new List<string>();
            }

            this.students.Add(student);
        }

        /// <summary>
        /// Returns the string representation of the course info - 
        /// name, teacher, students.
        /// </summary>
        /// <returns>A string which represents the course info.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Name = {0}", this.Name);

            if (this.TeacherName != null)
            {
                result.AppendFormat("; Teacher = {0}", this.TeacherName);
            }

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
            if (this.students == null || this.students.Count == 0)
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
}
