// <copyright file="HSKLevel.cs" company="MyCompany.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Me</author>

namespace OpenHSK.Domain
{
    using System.Collections.Generic;
    using CSharpFunctionalExtensions;

    /// <summary>
    /// The HSKLevel
    /// </summary>
    public class HSKLevel : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HSKLevel" /> class.
        /// </summary>
        /// <param name="name">the name of the HSK level</param>
        private HSKLevel(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the First level of HSK
        /// </summary>
        public static HSKLevel First { get; } = new HSKLevel("First");

        /// <summary>
        /// Gets the Second level of HSK
        /// </summary>
        public static HSKLevel Second { get; } = new HSKLevel("Second");

        /// <summary>
        /// Gets the Third level of HSK
        /// </summary>
        public static HSKLevel Third { get; } = new HSKLevel("Third");

        /// <summary>
        /// Gets the Fourth level of HSK
        /// </summary>
        public static HSKLevel Fourth { get; } = new HSKLevel("Fourth");

        /// <summary>
        /// Gets the Fifth level of HSK
        /// </summary>
        public static HSKLevel Fifth { get; } = new HSKLevel("Fifth");

        /// <summary>
        /// Gets the Sixth level of HSK
        /// </summary>
        public static HSKLevel Sixth { get; } = new HSKLevel("Sixth");

        /// <summary>
        /// Gets the name of the HSK level
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// return the string representation of the HSK level
        /// </summary>
        /// <returns>the string representation of the HSK level</returns>
        public override string ToString() => base.ToString();
        
        /// <summary>
        /// Needed to allow structure comparison for value object
        /// </summary>
        /// <returns>return the equality components</returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Name;
        }
    }
}