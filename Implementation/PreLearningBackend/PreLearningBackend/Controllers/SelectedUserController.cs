using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SelectedUserController : ControllerBase
    {
        ISelectedUserService _service;

        public SelectedUserController(ISelectedUserService service)
        {
            _service = service;
        }

        // GET: api/<SelectedUserController>
        /* [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }*/

        // GET api/<SelectedUserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //  _service.GetUserById(id);
                return Ok( await _service.GetUserById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SelectedUserController>
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            try
            {
                bool added = await _service.AddUser(file);
                if (added)
                    return Ok("User Added");
                else
                    return BadRequest("User Not Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SelectedUserController>/5
        [HttpPut]
        public async Task<IActionResult> Put(SelectedUser user)
        {
            try
            {
               await _service.UpdateUser(user);
                return Ok("User updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SelectedUserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await _service.DeleteUser(id);
                return Ok("User Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
