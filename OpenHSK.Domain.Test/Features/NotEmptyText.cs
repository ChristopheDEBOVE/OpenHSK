// <copyright file="NotEmptyText.cs" company="openhsk.com">
//     Open Hsk
// </copyright>
// <author>Christophe DEBOVE</author>

namespace OpenHSK.Domain
{
    using System;
    using System.Collections.Generic;
    using CSharpFunctionalExtensions;

    public class NotEmptyText : ValueObject
    {
        public string Value { get; }

        public NotEmptyText(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("An NotEmptyText must be construct with a not empty value", nameof(value));
            }
            Value = value;
        }

        public static implicit operator NotEmptyText(string v) => new NotEmptyText(v);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}