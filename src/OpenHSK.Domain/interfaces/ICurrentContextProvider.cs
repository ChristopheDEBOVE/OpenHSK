using OpenHSK.Domain.Commands.WriteModel;

namespace OpenHSK.Domain.interfaces
{
    public interface ICurrentContextProvider
    {
        User CurrentUser();
    }
}