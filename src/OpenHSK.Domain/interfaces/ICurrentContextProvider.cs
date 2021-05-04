namespace OpenHSK.Domain.interfaces
{
    using System;

    public interface ICurrentContextProvider
    {
        DateTime CurrentDateTime();
        User CurrentUser();
    }
}
