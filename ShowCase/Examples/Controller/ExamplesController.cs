using Microsoft.AspNetCore.Mvc;
using ShowCase.Examples.Logic;
using ShowCase.Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

        [HttpGet]
        public IList<Example> GetExamples()
        {
            return examplesLogic.GetExamples();
        }

        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            return Ok(examplesLogic.GetExample(id));
        }

        // POST api/<ExamplesController>
        [HttpPost]
        public ObjectResult Post([FromBody] Example example)
        {
            return Created(examplesLogic.AddExamples(example).Self, example);
        }

        // PUT api/<ExamplesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Example example)
        {

        }

        // DELETE api/<ExamplesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
