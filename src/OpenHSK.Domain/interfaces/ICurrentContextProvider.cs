namespace OpenHSK.Domain.interfaces
{
    using System;

    interface ICurrentContextProvider
    {
        DateTime GetCurrentDateTime();
        User GetCurrentUser();
    }
}
