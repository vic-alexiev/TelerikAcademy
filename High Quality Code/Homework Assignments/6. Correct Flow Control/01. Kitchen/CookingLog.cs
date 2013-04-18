// ********************************
// <copyright file="CookingLog.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Kitchen
{
    using System;
    using System.Text;

    /// <summary>
    /// Keeps the actions performed by a chef while preparing the meal.
    /// </summary>
    public class CookingLog
    {
        /// <summary>
        /// A <see cref="System.Text.StringBuilder"/> which keeps 
        /// the steps performed while cooking.
        /// </summary>
        private StringBuilder log = new StringBuilder();

        /// <summary>
        /// Adds <paramref name="note"/> in the cooking log.
        /// </summary>
        /// <param name="note">The note to add in the log.</param>
        public void Add(string note)
        {
            string item = string.Format("{0:yyyy-MM-dd HH:mm:ss}: {1}", DateTime.Now, note);
            this.log.AppendLine(item);
        }

        /// <summary>
        /// Returns the log data.
        /// </summary>
        /// <returns>The string representation of the log.</returns>
        public override string ToString()
        {
            return this.log.ToString();
        }
    }
}
