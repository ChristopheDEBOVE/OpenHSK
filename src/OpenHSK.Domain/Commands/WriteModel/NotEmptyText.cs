// <copyright file="NotEmptyText.cs" company="openhsk.com">
//     Open Hsk
// </copyright>
// <author>Christophe DEBOVE</author>

using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace OpenHSK.Domain.Commands.WriteModel
{
    public class NotEmptyText : ValueObject
    {
        private readonly string _value; 

        private NotEmptyText(string value)
        {
            _value = value;
        }

        public static implicit operator NotEmptyText(string v) => new NotEmptyText(v);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }

        public static Result<NotEmptyText, Error> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<NotEmptyText, Error>( Error.ValidationError($"An NotEmptyText must be construct with a not empty value")); 
            }

            return new NotEmptyText(value);
        }
    }
}