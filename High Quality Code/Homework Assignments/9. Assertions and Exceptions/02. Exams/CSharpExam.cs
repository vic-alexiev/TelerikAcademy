// ********************************
// <copyright file="CSharpExam.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Exams
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Represents a C# exam.
    /// </summary>
    public class CSharpExam : Exam
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpExam"/> class.
        /// </summary>
        /// <param name="score">The score achieved in the exam.</param>
        /// <param name="maxScore">The maximum score.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when
        /// <paramref name="score"/> or <paramref name="maxScore"/> is less than zero or when
        /// <paramref name="score"/> exceeds <paramref name="maxScore"/>.</exception>
        public CSharpExam(int score, int maxScore)
        {
            if (score < 0)
            {
                throw new ArgumentOutOfRangeException("score", "score cannot be less than zero.");
            }

            if (maxScore < 0)
            {
                throw new ArgumentOutOfRangeException("maxScore", "maxScore cannot be less than zero.");
            }

            if (score > maxScore)
            {
                throw new ArgumentOutOfRangeException(
                    "score",
                    string.Format("score must be in the range between 0 and {0}.", maxScore));
            }

            this.Score = score;
            this.MaxScore = maxScore;
        }

        /// <summary>
        /// Gets the score achieved in the exam.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Gets the maximum score for the exam.
        /// </summary>
        public int MaxScore { get; private set; }

        /// <summary>
        /// Gets the result achieved in the exam.
        /// </summary>
        /// <returns>An <see cref="ExamResult"/> object.</returns>
        public override ExamResult GetResult()
        {
            Debug.Assert(
                this.Score >= 0 && this.Score <= this.MaxScore,
                string.Format("Score must be between 0 and {0}.", this.MaxScore));

            return new ExamResult(this.Score, 0, this.MaxScore, "Exam results calculated as a score.");
        }
    }
}
