using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreLearningBackend.Services.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        public readonly IResourceService _context = null;
        public ResourceController(IResourceService context)
        {
            _context = context;
        }

        // GET api/<ResourceController>/<TopicId>
         [Authorize(Roles = "CampusMind")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllResultByTopic(int id)
        {
            try
            {
                List<Models.Resource.Resource> resources = await _context.GetAllResourcesByTopicId(id);
                if (resources != null)
                {
                    return Ok(resources);

                }
                return NotFound("No Resources For this Topic");
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Error Occured");
            }
        }

        // POST api/<ResourceController>
      //  [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(Models.Resource.Resource resource)
        {
            try
            {
                await _context.AddResource(resource);
                return Ok("Resource Added");
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Not Added");
            }
        }

        // PUT api/<ResourceController>/5
       // [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Models.Resource.Resource resource)
        {
            try
            {
                await _context.updateResource(resource);
                return Ok("Resource Updated");
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Not Updated");
            }
        }

        // DELETE api/<ResourceController>/5
       /* [Authorize(Roles = "Admin")]*/
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _context.DeleteResourceById(id);
                return Ok("Resource Deleted");
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Not Deleted");
            }
        }
    }
}