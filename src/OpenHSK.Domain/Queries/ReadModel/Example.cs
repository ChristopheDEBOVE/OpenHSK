using System.Collections.Generic;

namespace OpenHSK.Domain.Queries.ReadModel
{
    public class Example : CSharpFunctionalExtensions.ValueObject
    {
        private readonly string _content;

        public Example(string content)
        {
            _content = content;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _content;
        }
    }
}