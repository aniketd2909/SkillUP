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
    public class CampusMindRegisterController : ControllerBase
    {
        ICampusMindRegisterService _service;
        public CampusMindRegisterController(ICampusMindRegisterService service)
        {
            _service = service;
        }
        // GET: api/<RegisterController>
        /* [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }*/

        // GET api/<RegisterController>/5
        /* [HttpGet("{id}")]
         public string Get(int id)
         {
             return "value";
         }*/

        // POST api/<RegisterController>
        [HttpPost]
        public IActionResult Post(CampusMindRegister register)
        {
            try
            {
                if (_service.AddDetails(register))
                {
                    return Ok("Added");
                }
                else
                {
                    return BadRequest("This Email is Not Allowed To Register");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<RegisterController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<RegisterController>/5
        /* [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
