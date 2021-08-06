using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using OpenHSK.Domain.interfaces;
using OpenHSK.Domain.Queries;

namespace OpenHSK.Application.Features.Examples
{
    public class GetAllExampleQueryHandler
    {
        private readonly IGetExampleRepository _exampleRepository;

        public GetAllExampleQueryHandler(IGetExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<Result<Domain.Queries.ReadModel.Examples>> Handle(GetAllExample query, CancellationToken none)
        {
            return new Domain.Queries.ReadModel.Examples(await _exampleRepository.GetAll());
        }
    }
}