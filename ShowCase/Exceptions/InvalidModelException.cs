using ShowCase.Exceptions.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Exceptions
{
    public class InvalidModelException : Exception, IError
    {
        public int Code { get; set; }
        public new string Message { get; set; }

        public InvalidModelException()
        {
        }

        public InvalidModelException(int errorCode, string message)
            : base(message)
        {
            Code = errorCode;
        }

        public InvalidModelException(int errorCode, string message, Exception inner)
            : base(message, inner)
        {
            Code = errorCode;
        }
    }
}
