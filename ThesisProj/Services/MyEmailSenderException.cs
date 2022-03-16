using System;

namespace ThesisProj.Services
{
    public class MyEmailSenderException : ApplicationException
    {
        private const string StandardERRORMESSAGE = "Somethinfgg went wrong something email.";

        public MyEmailSenderException() : base(StandardERRORMESSAGE)
        {

        }

        public MyEmailSenderException(string message)
                : base(message)
        {

        }
        public MyEmailSenderException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
