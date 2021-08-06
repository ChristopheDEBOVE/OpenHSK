// <copyright file="Example.cs" company="openhsk.com">
//     Open Hsk
// </copyright>
// <author>Christophe DEBOVE</author>


using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace OpenHSK.Domain.Commands.WriteModel
{
    /// <summary>
    ///     In order to practice the exam good examples are mandatories
    /// </summary>
    public class Example : ValueObject
    {
        public Example(NotEmptyText text, HskLevel level, Student author)
        {
            _text = text;
            _level = level;
            _author = author;
        }

        private readonly Student _author;
        private readonly HskLevel _level;
        private readonly NotEmptyText _text;
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _author;
            yield return _level;
            yield return _text;
        }
    }
}