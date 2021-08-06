using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using OpenHSK.Domain;
using OpenHSK.Domain.Commands;
using OpenHSK.Domain.Commands.WriteModel;
using OpenHSK.Domain.interfaces;
using OpenHSK.Tooling;

namespace OpenHSK.Application.Features.Examples
{
    public class AddNewExampleCommandHandler : IRequestHandler<AddNewExampleCommand, Result<UnitResult, Error>>
    {
        public AddNewExampleCommandHandler(IAddExampleRepository exampleRepository,
            ICurrentContextProvider currentContextProvider)
        {
            ExampleRepository = exampleRepository;
            CurrentContextProvider = currentContextProvider;
        }

        private IAddExampleRepository ExampleRepository { get; }
        private ICurrentContextProvider CurrentContextProvider { get; }

        public async Task<Result<UnitResult, Error>> Handle(AddNewExampleCommand request,
            CancellationToken cancellationToken)
        {
            var student = CurrentContextProvider.CurrentUser() as Student;
            if (student == null)
                return Result.Failure<UnitResult, Error>(Error.AuthorizationError("The current user is not a student"));

            if (request.Text.IsNullOrEmpty())
                return Result.Failure<UnitResult, Error>(
                    Error.ValidationError("The text has an invalid value for the example"));

            var result = HskLevel.FromText(request.HskLevel);

            if (result.IsFailure) return Result.Failure<UnitResult, Error>(Error.ValidationError(result.Error));


            await ExampleRepository.AddAsync(new Example(request.Text, HskLevel.FromText(request.HskLevel).Value,
                student));
            return new UnitResult();
        }
    }
}