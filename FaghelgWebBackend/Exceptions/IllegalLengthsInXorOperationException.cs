using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaghelgWebBackend.Exceptions
{
    public class IllegalLengthsInXorOperationException : Exception
    {

        public IllegalLengthsInXorOperationException()
        { }

        public IllegalLengthsInXorOperationException (string message) : base(message)
        { }

        public IllegalLengthsInXorOperationException (string message, Exception inner) : base(message, inner)
        { }
    }
}