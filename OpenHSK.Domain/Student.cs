// <copyright file="Student.cs" company="MyCompany.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Me</author>

namespace OpenHSK.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Student Class
    /// </summary>
    public class Student
    {
        /// <summary>
        /// keep tracked the HSK levels of the student
        /// </summary>
        private readonly List<HSKLevel> levels = new List<HSKLevel>();

        /// <summary>
        /// Gets Levels
        /// </summary>
        public IReadOnlyList<HSKLevel> Levels
        {
            get
            {
                return this.levels;
            }
        }

        /// <summary>
        /// Enroll the student to an HSK level
        /// </summary>
        /// <param name="level">the HSK level</param>
        public void Enroll(HSKLevel level)
        {
            if (this.levels.Contains(level))
            {
                throw new InvalidOperationException();
            }
                
            this.levels.Add(level);
        }
    }
}