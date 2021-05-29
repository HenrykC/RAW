using Microsoft.AspNetCore.Mvc;
using ShowCase.Examples.Logic;
using ShowCase.Examples.Models;
using ShowCase.Exceptions;
using Microsoft.AspNetCore.Http;


namespace ShowCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly IExamplesLogic examplesLogic;

        public ExamplesController(IExamplesLogic examplesLogic)
        {
            this.examplesLogic = examplesLogic;
        }

        /// <summary>
        /// Retrieves all Examples.
        /// </summary>
        /// <returns>All Examples in Json format.</returns>
        /// <response code="200">Request was successfull.</response>
        /// <response code="400">An error occured while retrieving the objects.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ObjectResult GetExamples()
        {
            return Ok(examplesLogic.GetExamples());
        }

        /// <summary>
        /// Retrieves one Example specified by the Id.
        /// </summary>
        /// <param name="id">Example Id</param>
        /// <returns>Specified Example in Json format</returns>
        /// <response code="200">Request was successfull.</response>
        /// <response code="400">An error occured while retrieving the object.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ObjectResult Get(int id)
        {
            if (id <= 0)
                throw new InvalidModelException(2000, "Id can´t be lower than 1");

            return Ok(examplesLogic.GetExample(id)); //200
        }

        /// <summary>
        /// Adds a new Example to the Database.
        /// </summary>
        /// <remarks>    
        /// Sample request:     
        /// {    
        /// "id": 0,
        ///  "bestPractice": "BestPracticeWithCakes",
        ///  "worstPractice": "EverythingWithoutCakes",
        ///  "name": "CakeBestPractice",
        ///  "description": "Everything is better with a cake"
        /// }    
        ///    
        /// </remarks>
        /// <param name="example">Example that should be added to the DB</param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created object in body and location in header</response> 
        /// <response code="400">An error occured while creating the object.</response>
        [HttpPost]
        [ProducesResponseType (StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ObjectResult AddExample([FromBody] Example example)
        {
            example.ValidatePostParameter();

            var result = examplesLogic.AddExamples(example);
            var location = $"{Request.Scheme}://{Request.Host.Value}{Request.Path}/{result.Id}";

            return Created(location, result); //201
        }

        /// <summary>
        /// Updates a given Example (put).
        /// </summary>
        /// <param name="id">Id of the Example</param>
        /// <param name="example">New values of the example</param>
        /// <returns></returns>
        /// <response code="204">Update was successfull.</response>
        /// <response code="400">An error occured while updating the object.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public NoContentResult Put(int id, [FromBody] Example example)
        {
            example.ValidatePatchParameter();
            examplesLogic.UpdateExample(example);
           
            return NoContent(); //204
        }

        /// <summary>
        /// Updates a given Example (patch).
        /// </summary>
        /// <remarks>This is a remark</remarks>
        /// <param name="id">Id of the Example</param>
        /// <param name="example">New values of the example</param>
        /// <response code="200">Request was successfull.</response>
        /// <response code="400">An error occured while updating the object.</response>
        /// <returns></returns>
        // PUT api/<ExamplesController>/5
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ObjectResult Patch(int id, [FromBody] Example example)
        {
            example.ValidatePatchParameter();
            var result = examplesLogic.UpdateExample(example);

            return Ok(result); //200
        }

        /// <summary>
        /// Deletes a given Example.
        /// </summary>
        /// <param name="id">Example Id</param>
        /// <remarks>This is a remark</remarks>
        /// <returns></returns>
        /// <response code="204">Deletion was successfull</response>
        /// <response code="400">An error occured while deleting the object.</response>
        // DELETE api/<ExamplesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public NoContentResult Delete(int id)
        {
            if (id <= 0)
                throw new InvalidModelException(2000, "Id can´t be lower than 1");

            examplesLogic.DeleteExamples(id);

            return NoContent(); // 204
        }
    }
}
