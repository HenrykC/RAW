using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class ExampleView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Example Do { get; set; }
        public Example Dont { get; set; }
        public string Description { get; set; }
    }
}
