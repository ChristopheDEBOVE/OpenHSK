using System;
using FluentAssertions;
using OpenHSK.Domain.Commands.WriteModel;
using Xunit;

namespace OpenHSK.Application.Tests.Features
{
    public class EnrollmentTest
    {
        private readonly Student _sut = new Student();

        [Fact(DisplayName = "A student should be able to enroll for an hsk level")]
        [Trait("Feature", "Enrollment")]
        public void AStudentShouldBeAbleToEnrollForAnHskLevel()
        {
            _sut.Enroll(HskLevel.First);
            _sut.Levels.Should().Contain(HskLevel.First);
        }

        [Fact(DisplayName = "A student cannot enroll twice for the same hsk level")]
        [Trait("Feature", "Enrollment")]
        public void AStudentCannotEnrollTwiceForTheSameHskLevel()
        {
            _sut.Enroll(HskLevel.First);
            Action secondEnrollment = () => _sut.Enroll(HskLevel.First);

            secondEnrollment.Should().Throw<InvalidOperationException>();
        }

        [Fact(DisplayName = "A student can enroll for six different levels in the same time")]
        [Trait("Feature", "Enrollment")]
        public void AStudentCanEnrollForSixDifferentLevelsInTheSameTime()
        {
            _sut.Enroll(HskLevel.First);
            _sut.Enroll(HskLevel.Second);
            _sut.Enroll(HskLevel.Third);
            _sut.Enroll(HskLevel.Fourth);
            _sut.Enroll(HskLevel.Fifth);
            _sut.Enroll(HskLevel.Sixth);

            _sut.Levels.Should().Contain(new[]
            {
                HskLevel.First, HskLevel.Second,
                HskLevel.Third, HskLevel.Fourth,
                HskLevel.Fifth, HskLevel.Sixth
            });
        }
    }
}