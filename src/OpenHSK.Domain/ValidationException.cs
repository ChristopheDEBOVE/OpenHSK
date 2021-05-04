using System;

namespace OpenHSK.Application.Examples.Commands
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
