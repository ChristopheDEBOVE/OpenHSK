using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using OpenHSK.Application.Features.Examples;
using OpenHSK.Application.Tests.Fixtures;
using OpenHSK.Domain.interfaces;
using OpenHSK.Domain.Queries;
using OpenHSK.Domain.Queries.ReadModel;
using Xunit;

namespace OpenHSK.Application.Tests.Features
{
    public class GetExampleTest
    {
        [Theory]
        [InlineData("example 1")]
        [InlineData("example 2")]
        public async Task AStudentCanGetAllExamples(string content)
        {
            //given
            var query = new GetAllExample();
            Example[] exampleReads = {new Example(content)};
            IGetExampleRepository exampleRepository = new GetAllExampleStub(exampleReads);

            // When
            var examples = await new GetAllExampleQueryHandler(exampleRepository).Handle(query, CancellationToken.None);

            // Then
            examples.IsSuccess.Should().BeTrue();
            examples.Value.Items.First().Should().Be(new Example(content));
        }
    }
}