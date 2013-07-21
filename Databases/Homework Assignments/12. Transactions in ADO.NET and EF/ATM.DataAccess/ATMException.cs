using System;
namespace ATM.DataAccess
{
    public class ATMException : ApplicationException
    {
        public ATMException()
            : base()
        {
        }

        public ATMException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ATMException(string message)
            : this(message, null)
        {
        }
    }
}
