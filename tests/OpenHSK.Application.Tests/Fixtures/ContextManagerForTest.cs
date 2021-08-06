using OpenHSK.Domain.Commands.WriteModel;
using OpenHSK.Domain.interfaces;

namespace OpenHSK.Application.Tests.Fixtures
{
    public class ContextManagerForTest : ICurrentContextProvider
    {
        private User _user = new Student();

        public User CurrentUser()
        {
            return _user;
        }

        public void SwapUser(User user)
        {
            _user = user;
        }
    }
}