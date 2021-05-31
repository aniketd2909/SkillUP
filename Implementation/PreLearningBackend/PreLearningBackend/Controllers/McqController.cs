using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreLearningBackend.Models.Practice;
using PreLearningBackend.Services.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class McqController : ControllerBase
    {
        private readonly IMcqService _mcqService;

        public McqController(IMcqService mcqService)
        {
            _mcqService = mcqService;
        }
        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] CompleteQuestion completeQuestion)
        {
            bool added=await _mcqService.AddQuestion(completeQuestion);
            if(added)
            return Created(string.Empty,completeQuestion);
            return BadRequest("Something went wrong while adding the question.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            bool deleted = await _mcqService.DeleteQuestion(id);
            if (deleted)
                return Ok();
            return BadRequest("Question doesn't exist to delete.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var completeQuestion = await _mcqService.GetQuestionById(id);
            if (completeQuestion is not null)
                return Ok(completeQuestion);
            return BadRequest("Question doesn't exist.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> SubmitAnswer(int id, AnswerResource answerResource)
        {
            bool answer = await _mcqService.SubmitAnswer(id,answerResource);
            if (answer)
                return Ok("Correct");
            return Ok("Wrong");
        }
    }
}
