using FluentAssertions;
using System;
using Xunit;

namespace OpenHSK.Domain
{
    public class TextNotEmptyTest
    {
        [Fact]
        public void ANotEmptyTextMustNotBeEmpty()
        {
            Action constructNewExampleWithEmptyText = () => new NotEmptyText("");           
            constructNewExampleWithEmptyText.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TwoTextAreIdenticalIfTheyHaveTheSameValue()
        {
            new NotEmptyText("foo").Should().Be(new NotEmptyText("foo"));
            new NotEmptyText("foo").Should().NotBe(new NotEmptyText("bar"));
        }
    }
}
