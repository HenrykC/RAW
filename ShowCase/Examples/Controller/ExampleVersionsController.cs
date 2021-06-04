using Microsoft.AspNetCore.Mvc;
using ShowCase.Examples.Logic;
using ShowCase.Examples.Models;
using ShowCase.Exceptions;


namespace ShowCase.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]

    public class ExampleVersionsController : ControllerBase
    {
        private readonly IExamplesLogic examplesLogic;

        public ExampleVersionsController(IExamplesLogic examplesLogic)
        {
            this.examplesLogic = examplesLogic;
        }

        [HttpGet("{id}")]
        public ObjectResult GetExampleV1(int id)
        {
            if (id <= 0)
                throw new InvalidModelException(2000, "Id can´t be lower than 1");

            return Ok(examplesLogic.GetExample(id)); //200
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.1")]
        public ObjectResult GetExampleV2(int id)
        {
            if (id <= 0)
                throw new InvalidModelException(2000, "Id can´t be lower than 1");

            var examplev1 = examplesLogic.GetExample(id);

            var result = new ExampleV2()
            {
                Id = examplev1.Id,
                Name = examplev1.Name,
                Description = examplev1.Description,
                BestPractice = new BestPractice() { Text = examplev1.BestPractice },
                WorstPractice = new WorstPractice() { Text = examplev1.WorstPractice }
            };

            return Ok(result); //200
        }
    }
}
