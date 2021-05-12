using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Exceptions.Handler
{
    public class Error : IError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
