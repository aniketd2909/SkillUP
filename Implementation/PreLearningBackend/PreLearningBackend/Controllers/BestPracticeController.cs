using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class BestPracticeController : ControllerBase
    {
        private readonly IBestPracticesService _service; //Reference for IExperienceFeedService

        public BestPracticeController(IBestPracticesService service)
        {
            _service = service; // creates an reference object for the service
        }

        /*  [Authorize(Roles = "Admin")]*/ // Restricts users other than Admin
        [HttpPost]
        public async Task<ActionResult> AddBestCodingPractice(BestPractice bestCodingPractice)  //This method adds a new best practice to system 
        {
            try
            {
                bool result = await _service.AddBestPractice(bestCodingPractice); // Calls the AddBestPractice from the service
                if (result)
                    return Ok("Best Practices Added Successfully.."); //Returns the success message
                else
                    throw new AddBestPracticeError();
            }
            catch (AddBestPracticeError ex)
            {
                return Conflict(ex.message()); // Returns the conflict occured while adding best practices to the database/system
            }
            catch (DbUpdateException)
            {
                return Conflict("Unable to Connect to Database"); // Displays when failed to connect to database
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [Authorize(Roles = "CampusMind")] // Restricts users other than CampusMind
        [HttpGet]
        public async Task<ActionResult<List<BestPractice>>> GetBestPractices() //Gets all the best practices from the database
        {

            try
            {
                List<BestPractice> listOfBestCodingPractice = await _service.GetBestPractices();// Calls the GetBestPractices from the service
                if (listOfBestCodingPractice.Count == 0)
                    return Ok("No data to display");//Returns if there's no data to display
                else
                    return Ok(listOfBestCodingPractice);// Display the Best Coding Practices from the database
            }
            catch (DbUpdateException)
            {
                return Conflict("Unable to Connect to Database"); // Displays when failed to connect to database
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /* [Authorize(Roles = "Admin")]*/  // Restricts users other than Admin
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBestCodingPractice(int id, BestPractice bestCodingPractice) // This method Edit/Update exsisting best practice in the system
        {
            try
            {

                bool result = await _service.UpdateBestPractice(id, bestCodingPractice);// Calls the UpdateBestCodingPractice from the service
                if (result)
                    return Ok("Updated Successfully.."); //Returns the success message
                else
                    throw new UpdationError();
            }
            catch (UpdationError ex)
            {
                return Conflict(ex.message());// Returns the conflict occured while UpdateBestCodingPractice
            }
            catch (DbUpdateException)
            {
                return Conflict("Unable to Connect to Database");// Displays when failed to connect to database
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /*[Authorize(Roles = "Admin")]*/  // Restricts users other than Admin
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBestPractice(int id)  // This method Delete/Remove the best practice from the system
        {
            try
            {
                bool result = await _service.DeleteBestPractice(id);// Calls the DeleteBestPractice from the service
                if (result)
                    return Ok("Deleted Successfully..");//Returns the success message
                else
                    return Ok("Id not found");
            }
            catch (DbUpdateException)
            {
                return Conflict("Unable to Connect to Database");// Displays when failed to connect to database
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
