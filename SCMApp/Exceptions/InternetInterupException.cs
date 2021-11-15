using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Exceptions
{
    public class InternetInterupException : SCMException
    {
        public InternetInterupException() { }

        public InternetInterupException(string message) : base(message) { }

        public InternetInterupException(string message, Exception innerException) : base(message, innerException) { }
    }
}
