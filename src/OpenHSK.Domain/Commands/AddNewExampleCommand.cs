using CSharpFunctionalExtensions;
using MediatR;

namespace OpenHSK.Domain.Commands
{
    public sealed class AddNewExampleCommand : IRequest<Result<UnitResult, Error>>
    {
        public string? Text { get; set; }

        public string? HskLevel { get; set; }
    }
}