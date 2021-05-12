using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowCase.Exceptions.Handler;

namespace ShowCase.Exceptions
{
    public class UserException : Exception, IError
    {
        public int Code { get; set; }
        public new string Message { get; set; }

        public UserException()
        {
        }

        public UserException(int errorCode, string message)
            : base(message)
        {
            Code = errorCode;
        }

        public UserException(int errorCode, string message, Exception inner)
            : base(message, inner)
        {
            Code = errorCode;
        }
    }
}
