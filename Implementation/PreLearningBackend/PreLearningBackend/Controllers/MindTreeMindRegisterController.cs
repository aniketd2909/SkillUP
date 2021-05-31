using Microsoft.AspNetCore.Mvc;
using PreLearningBackend.Models.User;
using PreLearningBackend.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PreLearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MindTreeMindRegisterController : ControllerBase
    {
        IMindTreeMindRegisterService _service;

        public MindTreeMindRegisterController(IMindTreeMindRegisterService service)
        {
            _service = service;
        }

        // GET: api/<MindTreeMindRegisterController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<MindTreeMindRegisterController>/5
        /*  [HttpGet("{id}")]
          public string Get(int id)
          {
              return "value";
          }*/

        // POST api/<MindTreeMindRegisterController>
        [HttpPost]
        public IActionResult Post(MindTreeMindRegister mindTreeMindDetails)
        {
            try
            {

                if (_service.AddDetails(mindTreeMindDetails))
                {
                    return Ok("Added");
                }
                else
                {
                    return BadRequest("Not Added");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MindTreeMindRegisterController>/5
        /* [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }*/

        // DELETE api/<MindTreeMindRegisterController>/5
        /*  [HttpDelete("{id}")]
          public void Delete(int id)
          {
          }*/
    }
}
