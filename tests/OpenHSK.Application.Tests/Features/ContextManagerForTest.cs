namespace OpenHSK.Domain
{
    using OpenHSK.Domain.interfaces;
    using System;

    public class ContextManagerForTest : ICurrentContextProvider
    {
        private DateTime DateTime { get; }
        private readonly User user;
        public ContextManagerForTest(DateTime dateTime)
        {
            DateTime = dateTime;
            user = new Student();
        }
        public DateTime CurrentDateTime() => DateTime;
        public User CurrentUser() => user;
    }
}
