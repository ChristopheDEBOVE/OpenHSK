using FluentAssertions;
using OpenHSK.Domain.Commands.WriteModel;
using Xunit;

namespace OpenHSK.Domain
{
    public class TextNotEmptyTest
    {
        [Fact]
        public void ANotEmptyTextMustNotBeEmpty()
        {
            NotEmptyText.Create("").IsFailure.Should().BeTrue();
        }

        [Fact]
        public void TwoTextAreIdenticalIfTheyHaveTheSameValue()
        {
            NotEmptyText.Create("foo").Should().Be(NotEmptyText.Create("foo"));
            NotEmptyText.Create("foo").Should().NotBe(NotEmptyText.Create("bar"));
        }
    }
}