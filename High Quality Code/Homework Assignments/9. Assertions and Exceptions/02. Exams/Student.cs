// ********************************
// <copyright file="Student.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Exams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">Student's first name.</param>
        /// <param name="lastName">Student's last name.</param>
        /// <param name="exams">A list of exams.</param>
        /// <exception cref="System.ArgumentException">Thrown when
        /// <paramref name="firstName"/> or <paramref name="lastName"/> is null or empty.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="exams"/>
        /// is null.</exception>
        public Student(string firstName, string lastName, IList<Exam> exams)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("firstName cannot be null or empty.", "firstName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("lastName cannot be null or empty.", "lastName");
            }

            if (exams == null)
            {
                throw new ArgumentNullException("exams", "Exams list cannot be null.");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        /// <summary>
        /// Gets Student's first name.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets Student's last name.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets a list of Student's exams.
        /// </summary>
        public IList<Exam> Exams { get; private set; }

        /// <summary>
        /// Returns a list of the exam results achieved by the student.
        /// </summary>
        /// <returns>A list of Student's exam results.</returns>
        public IList<ExamResult> GetExamResults()
        {
            IList<ExamResult> results = new List<ExamResult>();

            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].GetResult());
            }

            return results;
        }

        /// <summary>
        /// Calculates the average of all exam results for the student.
        /// </summary>
        /// <returns>The average exam result.</returns>
        public double CalcAverageExamResultAsPercentage()
        {
            if (this.Exams.Count == 0)
            {
                return 0;
            }

            double[] examPoints = new double[this.Exams.Count];

            IList<ExamResult> examResults = this.GetExamResults();

            for (int i = 0; i < examResults.Count; i++)
            {
                examPoints[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examPoints.Average();
        }
    }
}
