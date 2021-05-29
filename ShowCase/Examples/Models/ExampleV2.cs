using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Examples.Models
{

    public class ExampleV2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BestPractice BestPractice { get; set; }
        public WorstPractice WorstPractice { get; set; }

    }

    public class BestPractice
    {
        public string Text { get; set; }
    }

    public class WorstPractice
    {
        public string Text { get; set; }
    }
}
