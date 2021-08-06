using System.Collections.Generic;

namespace OpenHSK.Domain
{
    public class Error : CSharpFunctionalExtensions.ValueObject
    {
        private readonly string _text;

        private Error(string text)
        {
            _text = text;
        }

        public static Error ValidationError(string text) => new Error(text);
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _text;
        }

        public static Error AuthorizationError(string text)=> new Error(text);
    }
}