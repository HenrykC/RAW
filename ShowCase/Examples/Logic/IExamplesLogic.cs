using ShowCase.Models;
using System.Collections.Generic;

namespace ShowCase.Examples.Logic
{
    public interface IExamplesLogic
    {
        Example GetExample(int id);
        IList<Example> GetExamples();
        bool DeleteExamples(int id);
        ResultExample AddExamples(Example example);
        Example UpdateExample(Example example);
    }
}