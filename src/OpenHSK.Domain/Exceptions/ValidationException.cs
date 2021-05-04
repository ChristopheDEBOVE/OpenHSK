namespace OpenHSK.Application.Examples.Commands
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
