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
        public readonly ITopicService _context = null;
        public TopicController(ITopicService context)
        {
            _context = context;
        }
        // GET: api/<TopicController>
        [Authorize(Roles = "CampusMind")]
        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
            try
            {
                return Ok(await _context.GetAllTopics());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/<TopicController>/<name>
        [Authorize(Roles = "CampusMind")]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetTopicByName(string name)
        {
            try
            {

                Topic topic = await _context.GetTopicByName(name);
                if (topic != null)
                {
                    return Ok(topic);
                }
                return NotFound("Topic Not Found");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST api/<TopicController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(Topic topic)
        {
            try
            {
                await _context.AddTopic(topic);
                return Ok("Topic Added");
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Topic Not Added");
            }
        }

        // PUT api/<TopicController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Topic topic)
        {
            try
            {
                await _context.updateTopic(topic);
                return Ok("Topic Updated");
            }
            catch (Exception e)
            {
                return NotFound(e.Message + "Error Occured Topic Not Updated");
            }
        }

        // DELETE api/<TopicController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _context.DeleteTopicById(id);
                return Ok("Topic Deleted");

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
