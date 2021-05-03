namespace OpenHSK.Domain
{
    using FluentAssertions;
    using Xunit;

    public class AddExampleTest
    {
        private readonly Student student = new Student();
        private readonly NotEmptyText VALUE_OF_THE_EXAMPLE = "他不是我的爸爸";

        [Fact]
        public void ANewExampleMustHaveAnAuthor()
        {
            new Example(VALUE_OF_THE_EXAMPLE, HskLevel.First, student)
                .Author.Should().Be(student);
        }

        [Fact]
        public void WhenAddingANewExampleTheHskLevelShouldBeSpecified() 
        {
            foreach (var level in HskLevel.Levels)
            {
                new Example(VALUE_OF_THE_EXAMPLE, level,student).Level.Should().Be(level);
            } 
        }
    }
}
