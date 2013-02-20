using System;

namespace MobilePhone
{
    class MobilePhoneException : ApplicationException
    {
        public MobilePhoneException()
            : base()
        {
        }

        public MobilePhoneException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MobilePhoneException(string message)
            : this(message, null)
        {
        }
    }
}
