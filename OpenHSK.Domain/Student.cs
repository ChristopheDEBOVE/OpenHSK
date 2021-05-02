// <copyright file="Student.cs" company="openhsk.com">
//     Open Hsk
// </copyright>
// <author>Christophe DEBOVE</author>

namespace OpenHSK.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A student is a person that want to improve his Chinese level, in order to pass the Hsk Exam
    /// </summary>
    public class Student
    {
        /// <summary>
        /// keep tracked the HSK levels of the student
        /// </summary>
        private readonly List<HskLevel> levels = new List<HskLevel>();

        /// <summary>
        /// Gets Levels
        /// </summary>
        public IReadOnlyList<HskLevel> Levels
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
        public void Enroll(HskLevel level)
        {
            if (this.levels.Any(a => a == level))
            {
                throw new InvalidOperationException();
            }
            
            this.levels.Add(level);
        }
    }
}