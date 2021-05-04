namespace OpenHSK.Domain
{
    using FluentAssertions;
    using OpenHSK.Application.Examples.Commands;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class SpyExampleRepository : IExampleRepository
    {
        public List<Example> Examples = new List<Example>();
        public Example LastInsertedExample;
        public int Add(Example example)
        {
            LastInsertedExample = example;
            Examples.Add(example);
            return 888;
        }
    }

    public class AddExampleTest
    {
        private readonly DateTime mayTheFourthBeWithYou = new DateTime(2021,05,04);
        private readonly ContextManagerForTest ContextManagerForTest;
        private readonly CreateTodoItemCommandHandler _sut;
        private readonly SpyExampleRepository _exampleRepositorySpy = new SpyExampleRepository();

        public AddExampleTest()
        {
            // Given
            ContextManagerForTest = new ContextManagerForTest(mayTheFourthBeWithYou);                        
            _sut = new CreateTodoItemCommandHandler(_exampleRepositorySpy, ContextManagerForTest);
        }

        [Fact]
        public async Task AStudentCanPostAnExample()
        {
            //given
            var student = ContextManagerForTest.CurrentUser() as Student;
            Example expectedToBeInserted = new Example("foo", HskLevel.First, student);
            var command = new AddNewExampleCommand() { Text = "foo", HskLevel = HskLevel.First.Name };

            // When
            var id = await _sut.Handle(command, CancellationToken.None);

            // Then
            id.Should().Be(888);
            _exampleRepositorySpy.Examples.Count.Should().Be(1);
            _exampleRepositorySpy.LastInsertedExample.Should().BeEquivalentTo(expectedToBeInserted);
        }

        [Fact]
        public async Task WhenTheStudentSendAnInvalidTextItMustBeReject()
        {
            //given
            var command = new AddNewExampleCommand() { Text = "", HskLevel = HskLevel.First.Name };

            // When
            Func<Task> handleAction = async () => await _sut.Handle(command, CancellationToken.None);

            // Then
            await handleAction.Should().ThrowAsync<ValidationException>()
                    .WithMessage("The text has an invalid value for the example");
            _exampleRepositorySpy.Examples.Count.Should().Be(0);            
        }

        [Theory]
        [InlineData("")]
        [InlineData("foo")]
        public async Task WhenTheStudentSendAnInvalidHskLevelItMustBeReject(string hskLevel)
        {
            //given
            var command = new AddNewExampleCommand() { Text = "Good Enought Example", HskLevel = hskLevel };

            // When
            Func<Task> handleAction = async () => await _sut.Handle(command, CancellationToken.None);

            // Then
            await handleAction.Should().ThrowAsync<ValidationException>()
                    .WithMessage($"{hskLevel} is not a valid value, must be First, Second, Third, Fourth, Fift or Sixth");
            _exampleRepositorySpy.Examples.Count.Should().Be(0);
        }
    }
}
