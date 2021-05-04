namespace OpenHSK.Application.Examples.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using OpenHSK.Domain;
    using OpenHSK.Domain.interfaces;
    using OpenHSK.Tooling;

    public class AddNewExampleCommand : IRequest<int>
    {
        public string Text { get; set; }

        public string HskLevel { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<AddNewExampleCommand, int>
    {
        public CreateTodoItemCommandHandler(IAddExampleRepository exampleRepository, ICurrentContextProvider currentContextProvider)
        {
            ExampleRepository = exampleRepository;
            CurrentContextProvider = currentContextProvider;
        }

        public IAddExampleRepository ExampleRepository { get; }
        public ICurrentContextProvider CurrentContextProvider { get; }

        public async Task<int> Handle(AddNewExampleCommand request, CancellationToken cancellationToken)
        {
            if (request.Text.IsNullOrEmpty())
            {
                throw new ValidationException("The text has an invalid value for the example");
            }

            var result = HskLevel.FromText(request.HskLevel);

            if (result.IsFailure)
            {
                throw new ValidationException(result.Error); 
            }


            var student = CurrentContextProvider.CurrentUser() as Student;
            return await ExampleRepository.AddAsync(new Example(request.Text, HskLevel.FromText(request.HskLevel).Value ,student));
        }
    }
}
