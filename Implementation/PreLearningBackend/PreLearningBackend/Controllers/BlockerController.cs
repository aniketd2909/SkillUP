using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreLearningBackend.Services.Blocker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Controllers
{
  //  [Authorize(Roles = "CampusMind")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlockerController : ControllerBase
    {


        private readonly IBlockerService _blockerService;

        public BlockerController(IBlockerService blockerService)
        {
            // create reference object for blocker service
            _blockerService = blockerService;  
        }

     
        [HttpGet]
        public async Task<IActionResult> GetAllBlockers()
        {
            try
            {   
                //Returns the success message
                return Ok(await _blockerService.GetAllBlockers()); 
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
        public async Task<IActionResult> GetBlockerById(int id)
        {
            try
            {  
                //Returns the success message
                return Ok(await _blockerService.GetBlockerById(id)); 

            }
            catch (InvalidBlocker ex)
            {
                //Returns not found if InvalidBlocker Excpetion Occurs
                return NotFound(ex.Message);  
            }
            catch (Exception ex)
            {
                //Returns BadRequest response for other excpetions
                return BadRequest(ex.Message); ; 
            }

        }

       
        [HttpPost]
        public async Task<IActionResult> AddBlocker(Models.Blocker.Blocker blocker)
        {
            try
            {
                bool flag=await _blockerService.AddBlocker(blocker);
                if (flag == true)
                {
                    //Returns Created response if added successfully
                    return Created("Blocker Added", blocker); 
                }

                //Returns Conflict if it was not able to add
                return Conflict("Blocker was not Added");

            }
            catch (Exception ex)
            {
                //Returns BadRequest response for other excpetions
                return BadRequest(ex.Message); 
            }

        }


        [HttpPut]
        public async Task<IActionResult> UpdateBlocker(Models.Blocker.Blocker blocker)
        {
            try
            {
                bool flag=await _blockerService.UpdateBlocker(blocker);
                if (flag == true)
                {
                    //Returns Created response if update successfully
                    return Created("Updated Succesfully", blocker); 
                }

                //Returns Conflict if it was not able to update
                return Conflict("Blocker was not Updated"); 

            }
            catch (InvalidBlocker ex)
            {
                //Returns not found if InvalidBlocker Excpetion Occurs
                return NotFound(ex.Message);  
            }
            catch (Exception ex)
            {
                //Returns BadRequest response for other excpetions
                return BadRequest(ex.Message); 
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlocker(int id)
        {
            try
            {
                bool flag=await _blockerService.DeleteBlocker(id);
                if (flag==true)
                {
                    //Returns success response if deleted successfully  
                    return Ok("Deleted Successfully"); 
                }

                //Returns Conflict if it was not able to delete
                return Conflict("Blocker was not Deleted");  

            }
            catch (InvalidBlocker ex)
            {
                //Returns not found if InvalidBlocker Excpetion Occurs
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
