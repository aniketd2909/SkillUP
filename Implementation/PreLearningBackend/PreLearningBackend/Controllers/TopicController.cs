using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreLearningBackend.Models.Resource;
using PreLearningBackend.Services.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        public readonly ITopicService _context = null;//Reference for ITopicService
        public TopicController(ITopicService context)
        {
            _context = context;// creates an reference object for the service
        }
        // GET: api/<TopicController>
        [Authorize(Roles = "CampusMind")]// Gives access to the CampusMind
        [HttpGet]
        public async Task<IActionResult> GetAllTopics()// This method displays all Topics from the system
        {
            try
            {
                return Ok(await _context.GetAllTopics());// Calls the GetAllTopics from the service
            }
            catch (Exception e)
            {
                return NotFound(e.Message);//Responce Message of Explains the error 
            }
        }

        // GET api/<TopicController>/<name>
        [Authorize(Roles = "CampusMind")]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetTopicByName(string name)//This method is to get a particular topic by name
        {
            try
            {

                Topic topic = await _context.GetTopicByName(name);//Calls the method GetTopicByName
                if (topic != null)
                {
                    return Ok(topic);//Returns the topic
                }
                return NotFound("Topic Not Found");//Error if topic not found
            }
            catch (Exception e)
            {
                return NotFound(e.Message);//Responce if an unknown error occurs.
            }
        }

        // POST api/<TopicController>
      //  [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(Topic topic)//This method adds a new Topic to system 
        {
            try
            {
                await _context.AddTopic(topic);// Calls the AddTopic from the service
                return Ok("Topic Added");//Returns the success message
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Topic Not Added");// Returns the conflict occured while adding Topic to the database/system
            }
        }

        // PUT api/<TopicController>/5
      //  [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Topic topic)//This method is used to update the topic
        {
            try
            {
                await _context.updateTopic(topic);//This calls the updateTopic method from service.
                return Ok("Topic Updated");//Success Message
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Error Occured Topic Not Updated");//Error Occured responce
            }
        }

        // DELETE api/<TopicController>/5
       /* [Authorize(Roles = "Admin")]*/
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)//This method deletes the Topic by id.
        {
            try
            {
                await _context.DeleteTopicById(id);//This calls the DeleteTopicById method from service.
                return Ok("Topic Deleted");//Success Responce

            }
            catch (Exception e)
            {
                return NotFound(e.Message);//Error Occured responce
            }
        }
    }
}
