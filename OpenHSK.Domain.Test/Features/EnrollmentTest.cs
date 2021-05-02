using FluentAssertions;
using System;
using Xunit;

namespace OpenHSK.Domain
{

    public class EnrollmentTest
    {
        readonly Student _sut = new Student();

        [Fact]
        public void AStudentShouldBeAbleToEnrollForAnHSKLevel()
        {
            _sut.Enroll(HskLevel.First);
            _sut.Levels.Should().Contain(HskLevel.First);
        }

        [Fact]
        public void AStudentCannotEnrollTwiceForTheSameHSKLevel()
        {
            _sut.Enroll(HskLevel.First);
            Action secondEnrollment = () => _sut.Enroll(HskLevel.First);

            secondEnrollment.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void AStudentCanEnrollForSixDifferentsLevelsInTheSameTime()
        {
            Student student = new Student();
            student.Enroll(HskLevel.First);
            student.Enroll(HskLevel.Second);
            student.Enroll(HskLevel.Third);
            student.Enroll(HskLevel.Fourth);
            student.Enroll(HskLevel.Fifth);
            student.Enroll(HskLevel.Sixth);

            student.Levels.Should().Contain(new[]{
                HskLevel.First, HskLevel.Second,
                HskLevel.Third, HskLevel.Fourth,
                HskLevel.Fifth, HskLevel.Sixth});

        }
    }  
}
