using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using OpenHSK.Application.Features.Examples;
using OpenHSK.Application.Tests.Fixtures;
using OpenHSK.Domain;
using OpenHSK.Domain.Commands;
using OpenHSK.Domain.Commands.WriteModel;
using Xunit;

namespace OpenHSK.Application.Tests.Features
{
    public class AddExampleTest
    {
        private readonly ContextManagerForTest _contextManagerForTest;
        private readonly AddNewExampleCommandHandler _sut;
        private readonly SpyAddExampleInRepository _addExampleInRepositorySpyAdd = new SpyAddExampleInRepository();

        public AddExampleTest()
        {
            // Given
            _contextManagerForTest = new ContextManagerForTest();
            _sut = new AddNewExampleCommandHandler(_addExampleInRepositorySpyAdd, _contextManagerForTest);
        }

        [Fact]
        public async Task AnUserThatIsNotStudentCannotPostAnExample()
        {
            //given
            _contextManagerForTest.SwapUser(null);
            var command = new AddNewExampleCommand {Text = "foo", HskLevel = HskLevel.First.Name};

            // When
            var result = await _sut.Handle(command, CancellationToken.None);

            // Then
            result.IsFailure.Should().BeTrue();
            _addExampleInRepositorySpyAdd.Examples.Count.Should().Be(0);
            result.Error.Should().Be(Error.AuthorizationError("The current user is not a student"));
        }

        [Fact]
        public async Task AStudentCanPostAnExample()
        {
            //given
            var student = _contextManagerForTest.CurrentUser() as Student;
            var expectedToBeInserted = new Example("foo", HskLevel.First, student!);
            var command = new AddNewExampleCommand {Text = "foo", HskLevel = HskLevel.First.Name};

            // When
            var result = await _sut.Handle(command, CancellationToken.None);

            // Then
            result.IsSuccess.Should().BeTrue();
            _addExampleInRepositorySpyAdd.Examples.Count.Should().Be(1);
            _addExampleInRepositorySpyAdd.LastInsertedExample.Should().BeEquivalentTo(expectedToBeInserted);
        }

        [Fact]
        public async Task WhenTheStudentSendAnInvalidTextItMustBeReject()
        {
            //given
            var command = new AddNewExampleCommand {Text = "", HskLevel = HskLevel.First.Name};

            // When
            var handleAction = await _sut.Handle(command, CancellationToken.None);

            // Then
            handleAction.Error.Should()
                .Be(Error.ValidationError("The text has an invalid value for the example"));
            _addExampleInRepositorySpyAdd.Examples.Count.Should().Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("foo")]
        public async Task WhenTheStudentSendAnInvalidHskLevelItMustBeReject(string hskLevel)
        {
            //given
            var command = new AddNewExampleCommand {Text = "Good enought Example", HskLevel = hskLevel};

            // When
            var handleAction = await _sut.Handle(command, CancellationToken.None);

            // Then
            handleAction.Error.Should()
                .Be(Error.ValidationError(
                    $"{hskLevel} is not a valid value, must be First, Second, Third, Fourth, Fift or Sixth"));

            _addExampleInRepositorySpyAdd.Examples.Count.Should().Be(0);
        }
    }
}