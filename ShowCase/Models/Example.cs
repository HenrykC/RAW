using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class Example
    {
        public int Id { get; set; }

        public string RequestVerb { get; set; }
        public string RequestPath { get; set; }

        public string ResponseCode { get; set; }
        public string ResponseText { get; set; }
        public string ResponseBody { get; set; }
    }
}
