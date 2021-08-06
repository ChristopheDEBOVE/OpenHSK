using FluentAssertions;
using OpenHSK.Domain.Queries.ReadModel;
using Xunit;

namespace OpenHSK.Application.Tests.Features
{
    public class ExampleForReadTest
    {
        [Fact]
        public void TwoExampleAreIdenticalIfTheyShareTheSameContent()
        { 
            new Example("lalala").Should().Be(new Example("lalala"));
        }   
    }
}