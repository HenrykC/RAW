using Microsoft.AspNetCore.Mvc;
using ShowCase.Examples.Logic;
using ShowCase.Examples.Models;
using ShowCase.Exceptions;


namespace ShowCase.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
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

        [HttpGet]
        public ObjectResult GetExamples()
        {
            return Ok(examplesLogic.GetExamples());
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.1")]
        public ObjectResult Get(int id)
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

        [HttpPost]
        public ObjectResult AddExample([FromBody] Example example)
        {
            example.ValidatePostParameter();

            var result = examplesLogic.AddExamples(example);
            var location = $"{Request.Scheme}://{Request.Host.Value}{Request.Path}/{result.Id}";

            return Created(location, result); //201
        }

        [HttpPut("{id}")]
        public NoContentResult Put(int id, [FromBody] Example example)
        {
            example.ValidatePatchParameter();
            examplesLogic.UpdateExample(example);

            return NoContent(); //204
        }


        // PUT api/<ExamplesController>/5
        [HttpPatch("{id}")]
        public ObjectResult Patch(int id, [FromBody] Example example)
        {
            example.ValidatePatchParameter();
            var result = examplesLogic.UpdateExample(example);

            return Ok(result); //200
        }

        // DELETE api/<ExamplesController>/5
        [HttpDelete("{id}")]
        public NoContentResult Delete(int id)
        {
            if (id <= 0)
                throw new InvalidModelException(2000, "Id can´t be lower than 1");

            examplesLogic.DeleteExamples(id);

            return NoContent(); // 204
        }
    }
}
