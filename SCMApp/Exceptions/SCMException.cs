using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Exceptions
{
    public class SCMException : Exception
    {
        public string ExceptionMessage;

        public SCMException() { }

        public SCMException(string message) : base(message) { ExceptionMessage = message; }

        public SCMException(string message, Exception innerException) : base(message, innerException) { ExceptionMessage = message; }
    }
}
