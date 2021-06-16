using Microsoft.AspNetCore.Authorization;
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
 /*   [Authorize(Roles = "MindtreeMind")]*/
    [AllowAnonymous]
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
        public async Task<IActionResult> RegisterMind(MindTreeMindRegister mindTreeMindDetails)
        {
            try
            {

                if ( await _service.AddDetails(mindTreeMindDetails))
                {
                    return Ok("Registration Successful");
                }
                else
                {
                    return Ok("This Email is Either Not Allowed To Register Or Already Registered");
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
