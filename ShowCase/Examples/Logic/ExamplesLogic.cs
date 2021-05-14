using ShowCase.Examples.Repository;
using ShowCase.Models;
using System.Collections.Generic;

namespace ShowCase.Examples.Logic
{
    public class ExamplesLogic : IExamplesLogic
    {
        private readonly IExamplesRepository examplesRepository;

        public ExamplesLogic(IExamplesRepository examplesRepository)
        {
            this.examplesRepository = examplesRepository;
        }

        public ResultExample AddExamples(Example example)
        {
            return examplesRepository.AddExamples(example);
        }

        public bool DeleteExamples(int id)
        {
            return examplesRepository.DeleteExamples(id);
        }

        public Example GetExample(int id)
        {
            return examplesRepository.GetExample(id);
        }

        public IList<Example> GetExamples()
        {
            return examplesRepository.GetExamples();
        }

        public Example UpdateExample(Example example)
        {
            return examplesRepository.UpdateExample(example);
        }
    }
}
