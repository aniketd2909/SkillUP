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
        public readonly IResourceService _context = null;//Reference for IResourceService
        public ResourceController(IResourceService context)
        {
            _context = context;// creates an reference object for the service
        }

        // GET api/<ResourceController>/<TopicId>
         [Authorize(Roles = "CampusMind")]// Gives access to the CampusMind
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllResourcesByTopic(int id)// This method displays all resources from the system of a particular topic
        {
            try
            {
                List<Models.Resource.Resource> resources = await _context.GetAllResourcesByTopicId(id);// Calls the GetAllResourcesByTopicId from the service
                if (resources != null)
                {
                    return Ok(resources);

                }
                return NotFound("No Resources For this Topic"); //Responce Message
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Error Occured");// Explains the error 
            }
        }

        // POST api/<ResourceController>
      //  [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddResource(Models.Resource.Resource resource)//This method adds a new resource to system 
        {
            try
            {
                await _context.AddResource(resource);// Calls the AddResource from the service
                return Ok("Resource Added"); //Returns the success message
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Not Added");// Returns the conflict occured while adding resource to the database/system
            }
        }

        // PUT api/<ResourceController>/5
       // [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> updateResource(Models.Resource.Resource resource) // This method updates a particular resource
        {
            try
            {
                await _context.updateResource(resource);//This method updates the exixting resource on the changes we make
                return Ok("Resource Updated");//Success message
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Not Updated");//Error message 
            }
        }

        // DELETE api/<ResourceController>/5
       /* [Authorize(Roles = "Admin")]*/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(int id)//This method is used to Delete a particular Resource by its id.
        {
            try
            {
                await _context.DeleteResourceById(id);//This deletes the resouce
                return Ok("Resource Deleted");//Success message
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Not Deleted");//Error message.
            }
        }
    }
}