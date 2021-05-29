using ShowCase.Exceptions;

namespace ShowCase.Examples.Models
{
    public class Example
    {
        public int Id { get; set; }

        public string BestPractice { get; set; }

        public string WorstPractice { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public void ValidatePostParameter()
        {
            if (Id != 0)
                throw new InvalidModelException(1000, "Dont set an id to the example model");
            
            if (string.IsNullOrWhiteSpace(Name))
                throw new InvalidModelException(1001, "No 'name' found at the example model");

            if (string.IsNullOrWhiteSpace(BestPractice))
                throw new InvalidModelException(1002, "No 'bestPractice' found at the example model");

            if (string.IsNullOrWhiteSpace(WorstPractice))
                throw new InvalidModelException(1003, "No 'worstPractice' found at the example model");
        }

        public void ValidatePatchParameter()
        {
        }
    }
}
