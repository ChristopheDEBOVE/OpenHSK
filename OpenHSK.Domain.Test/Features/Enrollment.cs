using FluentAssertions;
using System;
using Xunit;

namespace OpenHSK.Domain
{
    public class Enrollment
    {
        readonly Student _sut = new Student();

        [Fact]
        public void A_Student_ShouldBeAble_To_Enroll_For_An_HSK_Level()
        {
            _sut.Enroll(HskLevel.First);
            _sut.Levels.Should().Contain(HskLevel.First);
        }

        [Fact]
        public void A_Student_Cannot_Enroll_Twice_For_The_Same_HSK_Level()
        { 
            _sut.Enroll(HskLevel.First);
            Action secondEnrollment = () => _sut.Enroll(HskLevel.First);

            secondEnrollment.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void A_Student_Can_Enroll_For_Six_Differents_Levels_In_The_Same_Time()
        {
            Student student = new Student();

            student.Enroll(HskLevel.First);
            student.Enroll(HskLevel.Second);
            student.Enroll(HskLevel.Third);
            student.Enroll(HskLevel.Fourth);
            student.Enroll(HskLevel.Fifth);
            student.Enroll(HskLevel.Sixth);

            student.Levels.Should().Contain(new []{ 
                HskLevel.First, HskLevel.Second,
                HskLevel.Third, HskLevel.Fourth, 
                HskLevel.Fifth, HskLevel.Sixth});    
        }
    }  
}
