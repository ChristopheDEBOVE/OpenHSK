using FluentAssertions;
using System;
using Xunit;

namespace OpenHSK.Domain
{
    public class Enrollment
    {
        readonly Student _sut = new Student();

        [Fact]
        public void AsAStudentIShouldBeAbleToEnrollForAnHSKLevel()
        {
            _sut.Enroll(HSKLevel.First);
            _sut.Levels.Should().Contain(HSKLevel.First);
        }

        [Fact]
        public void AStudentCannotEnrollTwiceForTheSameHSKLevel()
        { 
            _sut.Enroll(HSKLevel.First);
            Action secondEnrollment = () => _sut.Enroll(HSKLevel.First);

            secondEnrollment.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void AStudentCanEnrollForSixDifferentsLevelsInTheSameTime()
        {
            Student student = new Student();

            student.Enroll(HSKLevel.First);
            student.Enroll(HSKLevel.Second);
            student.Enroll(HSKLevel.Third);
            student.Enroll(HSKLevel.Fourth);
            student.Enroll(HSKLevel.Fifth);
            student.Enroll(HSKLevel.Sixth);

            student.Levels.Should().Contain(new []{ 
                HSKLevel.First, HSKLevel.Second,
                HSKLevel.Third, HSKLevel.Fourth, 
                HSKLevel.Fifth, HSKLevel.Sixth});    
        }
    }  
}
