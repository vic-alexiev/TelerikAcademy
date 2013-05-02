// ********************************
// <copyright file="Exam.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Exams
{
    /// <summary>
    /// Represents an exam.
    /// </summary>
    public abstract class Exam
    {
        /// <summary>
        /// Returns the result for the specified exam.
        /// </summary>
        /// <returns>An <see cref="ExamResult"/> object.</returns>
        public abstract ExamResult GetResult();
    }
}
