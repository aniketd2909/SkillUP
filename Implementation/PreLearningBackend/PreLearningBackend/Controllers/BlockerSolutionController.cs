using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreLearningBackend.Services.Blocker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockerSolutionController : ControllerBase
    {
        private readonly IBlockerSolutionService _blockerSolutionService;

        public BlockerSolutionController(IBlockerSolutionService blockerSolutionService)
        {
            // create reference object for blocker solution service
            _blockerSolutionService = blockerSolutionService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBlockerSolutions()
        {
            try
            {
                //Returns the success message
                return Ok(await _blockerSolutionService.GetAllBlockerSoutions());
            }
            catch (EmptyListException ex)
            {
                //Returns not found if EmptyListException Occurs 
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                //Returns BadRequest response for other excpetions
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlockerSolutionById(int id)
        {
            try
            { 
                //Returns the success message
                return Ok(await _blockerSolutionService.GetBlockerSoutionById(id));

            }
            catch (InvalidBlockerSoution ex)
            {    
                //Returns not found if InvalidBlockerSolution Excpetion Occurs
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                //Returns BadRequest response for other excpetions
                return BadRequest(ex.Message); ;
            }

        }


        [HttpPost]
        public async Task<IActionResult> AddBlockerSolution(Models.Blocker.BlockerSolution blockerSolution)
        {
            try
            {
               bool flag=await _blockerSolutionService.AddBlockerSolution(blockerSolution);
                if (flag==true)
                {
                    //Returns Created response if added successfully
                    return Created("BlockerSolution Added", blockerSolution);
                }

                //Returns Conflict if it was not able to add
                return Conflict("BlockerSolution was not Added");
            }
            catch (Exception ex)
            {
                //Returns BadRequest response for other excpetions
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        public async Task<IActionResult> UpdateBlockerSolution(Models.Blocker.BlockerSolution blockerSolution)
        {
            try
            {
                bool flag=await _blockerSolutionService.UpdateBlockerSolution(blockerSolution);
                if (flag==true)
                {
                    //Returns Created response if update successfully
                    return Created("Updated Succesfully", blockerSolution);
                }

                //Returns Conflict if it was not able to update
                return Conflict("BlockerSolution was not Updated");
            }
            catch (InvalidBlockerSoution ex)
            {
                //Returns not found if InvalidBlockerSolution Excpetion Occurs
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                //Returns BadRequest response for other excpetions
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlockerSolution(int id)
        {
            try
            {
                bool flag=await _blockerSolutionService.DeleteBlockerSolution(id);
                if (flag==true)
                {
                    //Returns success response if deleted successfully  
                    return Ok("Deleted Successfully");
                }

                //Returns Conflict if it was not able to delete
                return Conflict("BlockerSolution was not Deleted");

            }
            catch (InvalidBlockerSoution ex)
            {
                //Returns not found if InvalidBlockerSolution Excpetion Occurs
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                //Returns BadRequest response for other excpetions
                return BadRequest(ex.Message);

            }
        }

    }
}
