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
        private readonly IBestPracticeService _service;

        public BestPracticeController(IBestPracticeService service)
        {
            _service = service; // creates an reference object for the service
        }

        [HttpPost]
        public async Task<ActionResult> AddBestCodingPractice(BestPractice bestCodingPractice)
        {
            try
            {
                bool result = await _service.AddBestPractice(bestCodingPractice); // Calls the AddBestPractice from the service
                if (result)
                    return Conflict("Best Practices Added Successfully.."); //Returns the success message
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


        [HttpGet]
        public async Task<ActionResult<List<BestPractice>>> GetBestPractices()
        {

            try
            {
                List<BestPractice> listOfBestCodingPractice = await _service.GetBestPractices();// Calls the GetBestPractices from the service
                if (listOfBestCodingPractice.Count == 0)
                    return Conflict("No data to display");//Returns if there's no data to display
                else
                    return listOfBestCodingPractice;// Display the Best Coding Practices from the database
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBestCodingPractice(int id, BestPractice bestCodingPractice)
        {
            try
            {

                bool result = await _service.UpdateBestPractice(id, bestCodingPractice);// Calls the UpdateBestCodingPractice from the service
                if (result)
                    return Conflict("Updated Successfully.."); //Returns the success message
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


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBestPractice(int id)
        {
            try
            {
                bool result = await _service.DeleteBestPractice(id);// Calls the DeleteBestPractice from the service
                if (result)
                    return Conflict("Deleted Successfully..");//Returns the success message
                else
                    return Conflict("Id not found");
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
