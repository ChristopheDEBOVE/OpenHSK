using System.Threading.Tasks;
using OpenHSK.Domain.interfaces;
using OpenHSK.Domain.Queries.ReadModel;

namespace OpenHSK.Application.Tests.Fixtures
{
    public class GetAllExampleStub : IGetExampleRepository
    {
        private readonly Example[] _exampleReads;

        public GetAllExampleStub(Example[] exampleReads)
        {
            _exampleReads = exampleReads;
        }

        public Task<Example[]> GetAll()
        {
            return Task.FromResult(_exampleReads);
        }
    }
}