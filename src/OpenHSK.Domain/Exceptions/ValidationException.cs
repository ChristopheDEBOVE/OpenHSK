using System;
using System.Runtime.Serialization;

namespace OpenHSK.Application.Examples.Commands
{
    public class ValidationException : Exception, ISerializable
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
