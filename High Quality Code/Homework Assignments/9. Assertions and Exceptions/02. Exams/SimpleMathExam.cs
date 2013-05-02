// ********************************
// <copyright file="SimpleMathExam.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Exams
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Represents a simple math exam.
    /// </summary>
    public class SimpleMathExam : Exam
    {
        /// <summary>
        /// The maximum number of problems in the exam.
        /// </summary>
        public const int TotalProblems = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMathExam"/> class.
        /// </summary>
        /// <param name="problemsSolved">The number of problems solved.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
        /// <paramref name="problemsSolved"/> is less than zero or when
        /// <paramref name="problemsSolved"/> is greater than ProblemsCount.</exception>
        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0)
            {
                throw new ArgumentOutOfRangeException("problemsSolved", "problemsSolved cannot be less than zero.");
            }

            if (problemsSolved > TotalProblems)
            {
                throw new ArgumentOutOfRangeException(
                    "problemsSolved",
                    string.Format("problemsSolved must be in the range between 0 and {0}.", TotalProblems));
            }

            this.ProblemsSolved = problemsSolved;
        }

        /// <summary>
        /// Gets the number of solved problems.
        /// </summary>
        public int ProblemsSolved { get; private set; }

        /// <summary>
        /// Gets the result achieved in the exam.
        /// </summary>
        /// <returns>An <see cref="ExamResult"/> object.</returns>
        public override ExamResult GetResult()
        {
            Debug.Assert(
                this.ProblemsSolved >= 0 && this.ProblemsSolved <= TotalProblems,
                string.Format("The solved problems must be between 0 and {0}.", TotalProblems));

            switch (this.ProblemsSolved)
            {
                case 0:
                    {
                        return new ExamResult(2, 2, 6, "Bad result: nothing done.");
                    }

                case 1:
                    {
                        return new ExamResult(4, 2, 6, "Average result: 1 problem solved.");
                    }

                default:
                    {
                        return new ExamResult(6, 2, 6, "Excellent result: 2 problems solved.");
                    }
            }
        }
    }
}
