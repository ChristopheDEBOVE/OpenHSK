// <copyright file="HSKLevel.cs" company="openhsk.com">
//     OpenHSK
// </copyright>
// <author>Christophe DEBOVE</author>

namespace OpenHSK.Domain
{
    using System.Collections.Generic;
    using CSharpFunctionalExtensions;

    /// <summary>
    /// The HSKLevel
    /// </summary>
    public class HskLevel : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HskLevel" /> class.
        /// </summary>
        /// <param name="name">the name of the HSK level</param>
        private HskLevel(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the First level of HSK
        /// </summary>
        public static HskLevel First { get; } = new HskLevel("First");

        /// <summary>
        /// Gets the Second level of HSK
        /// </summary>
        public static HskLevel Second { get; } = new HskLevel("Second");

        /// <summary>
        /// Gets the Third level of HSK
        /// </summary>
        public static HskLevel Third { get; } = new HskLevel("Third");

        /// <summary>
        /// Gets the Fourth level of HSK
        /// </summary>
        public static HskLevel Fourth { get; } = new HskLevel("Fourth");

        /// <summary>
        /// Gets the Fifth level of HSK
        /// </summary>
        public static HskLevel Fifth { get; } = new HskLevel("Fifth");

        /// <summary>
        /// Gets the Sixth level of HSK
        /// </summary>
        public static HskLevel Sixth { get; } = new HskLevel("Sixth");

        /// <summary>
        /// Gets the name of the HSK level
        /// </summary>
        public string Name { get; }

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