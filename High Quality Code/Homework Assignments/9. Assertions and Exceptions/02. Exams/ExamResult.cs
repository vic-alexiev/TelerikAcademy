// ********************************
// <copyright file="ExamResult.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Exams
{
    using System;

    /// <summary>
    /// Represents an exam result achieved by a student.
    /// </summary>
    public class ExamResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExamResult"/> class.
        /// </summary>
        /// <param name="grade">Grade achieved.</param>
        /// <param name="minGrade">Minimum grade.</param>
        /// <param name="maxGrade">Maximum grade.</param>
        /// <param name="comments">Additional information.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
        /// <paramref name="grade"/>, <paramref name="minGrade"/> or <paramref name="maxGrade"/>
        /// is less than zero or when <paramref name="maxGrade"/> is less than
        /// <paramref name="minGrade"/> or when <paramref name="grade"/> is not between
        /// <paramref name="minGrade"/> and <paramref name="maxGrade"/>.</exception>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="comments"/>
        /// is null or empty.</exception>
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException("grade", "grade cannot be less than zero.");
            }

            if (minGrade < 0)
            {
                throw new ArgumentOutOfRangeException("minGrade", "minGrade cannot be less than zero.");
            }

            if (maxGrade < 0)
            {
                throw new ArgumentOutOfRangeException("maxGrade", "maxGrade cannot be less than zero.");
            }

            if (maxGrade < minGrade)
            {
                throw new ArgumentOutOfRangeException("maxGrade", "maxGrade cannot be less than minGrade.");
            }

            if (grade < minGrade || grade > maxGrade)
            {
                throw new ArgumentOutOfRangeException(
                    "grade",
                    string.Format("grade must be in the range between {0} and {1}.", minGrade, maxGrade));
            }

            if (string.IsNullOrWhiteSpace(comments))
            {
                throw new ArgumentException("comments cannot be null or empty.", "comments");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        /// <summary>
        /// Gets the grade.
        /// </summary>
        public int Grade { get; private set; }

        /// <summary>
        /// Gets the minimum grade.
        /// </summary>
        public int MinGrade { get; private set; }

        /// <summary>
        /// Gets the maximum grade.
        /// </summary>
        public int MaxGrade { get; private set; }

        /// <summary>
        /// Gets the comments about the grade.
        /// </summary>
        public string Comments { get; private set; }
    }
}
