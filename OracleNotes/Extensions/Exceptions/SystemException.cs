using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleNotes.Extensions.Exceptions
{
    public class InternalSystemException : Exception
    {
        public InternalSystemException() : base() { }
        public InternalSystemException(string message) : base(message) { }
        public InternalSystemException(string message, Exception inner) : base(message, inner) { }
    }
}
