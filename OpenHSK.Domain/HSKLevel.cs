// <copyright file="HSKLevel.cs" company="openhsk.com">
//     Open Hsk
//     The descriptions of the differents levels are copied from 
//     https://en.wikipedia.org/wiki/Hanyu_Shuiping_Kaoshi
// </copyright>
// <author>Christophe DEBOVE</author>

namespace OpenHSK.Domain
{
    using System.Collections.Generic;
    using CSharpFunctionalExtensions;

    /// <summary>
    /// There is 6 HSK level    
    /// </summary>
    public sealed class HskLevel : ValueObject
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
        /// Designed for learners who can understand and use some simple Chinese characters 
        /// and sentences to communicate, and prepares them for continuing their Chinese studies.
        /// In HSK 1 all characters are provided along with Pinyin.
        /// </summary>
        public static HskLevel First { get; } = new HskLevel("First");

        /// <summary>
        /// Gets the Second level of HSK
        /// Designed for learners who can use Chinese in a simple and direct manner,
        /// applying it in a basic fashion to their daily lives.
        /// In HSK 2 all characters are provided along with Pinyin.
        /// </summary>
        public static HskLevel Second { get; } = new HskLevel("Second");

        /// <summary>
        /// Gets the Third level of HSK
        /// Designed for learners who can use Chinese to serve the demands of their personal lives,
        /// studies and work, and are capable of completing most of the communicative 
        /// tasks they experience during their Chinese tour.
        /// </summary>
        public static HskLevel Third { get; } = new HskLevel("Third");

        /// <summary>
        /// Gets the Fourth level of HSK
        /// Designed for learners who can discuss a relatively wide range of topics in Chinese 
        /// and are capable of communicating with Chinese speakers at a high standard.
        /// </summary>
        public static HskLevel Fourth { get; } = new HskLevel("Fourth");

        /// <summary>
        /// Gets the Fifth level of HSK
        /// Designed for learners who can read Chinese newspapers and magazines,
        /// watch Chinese films and are capable of writing and delivering a lengthy speech in Chinese.
        /// </summary>
        public static HskLevel Fifth { get; } = new HskLevel("Fifth");

        /// <summary>
        /// Gets the Sixth level of HSK
        /// Designed for learners who can easily understand any information communicated in Chinese
        /// and are capable of smoothly expressing themselves in written or oral form.
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