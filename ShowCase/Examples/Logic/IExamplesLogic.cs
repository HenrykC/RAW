using ShowCase.Examples.Models;
using System.Collections.Generic;

namespace ShowCase.Examples.Logic
{
    public interface IExamplesLogic
    {
        Example GetExample(int id);
        IList<Example> GetExamples();
        bool DeleteExamples(int id);
        Example AddExamples(Example example);
        Example UpdateExample(Example example);
    }
}