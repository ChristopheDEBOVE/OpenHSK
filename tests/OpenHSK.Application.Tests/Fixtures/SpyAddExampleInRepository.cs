using System.Collections.Generic;
using System.Threading.Tasks;
using OpenHSK.Domain.Commands.WriteModel;
using OpenHSK.Domain.interfaces;

namespace OpenHSK.Application.Tests.Fixtures
{
    public class SpyAddExampleInRepository : IAddExampleInRepository
    {
        public readonly List<Example> Examples = new List<Example>();
        public Example LastInsertedExample;

        public Task<int> AddAsync(Example example)
        {
            LastInsertedExample = example;
            Examples.Add(example);
            return Task.FromResult(888);
        }
    }
}