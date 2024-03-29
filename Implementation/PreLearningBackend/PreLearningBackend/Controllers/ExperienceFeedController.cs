﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Models.ExperienceFeed;
using PreLearningBackend.Services.ExperienceFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class ExperienceFeedController : ControllerBase
    {
        private readonly IExperienceFeedService _service; //Reference for IExperienceFeedService

        public ExperienceFeedController(IExperienceFeedService service)
        {
            _service = service; // creates an reference object for the service
        }

        [Authorize(Roles = "MindtreeMind")] // Restricts users other than MindtreeMind
        [HttpPost]
        public async Task<ActionResult> AddExperienceFeed(ExperienceFeed experienceFeed) //This method adds a new feedback to system 
        {
            try
            {
                bool result = await _service.AddExperienceFeed(experienceFeed); // Calls the AddExperienceFeed from the service
                if (result)
                    return Ok("Experience Feed Added Successfully.."); //Returns the success message
                else
                    throw new ExceptionWhileAdding();

            }
            catch (ExceptionWhileAdding ex)
            {
                return Conflict(ex.ErrorMessage()); // Returns the conflict occured while adding feed to the database/system
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

        [Authorize(Roles = "CampusMind")]  // Restricts users other than CampusMind
        [HttpGet]
        public async Task<ActionResult<List<ExperienceFeed>>> GetAllExperienceFeeds() // This method displays all existing feebacks from the system
        {

            try
            {
                List<ExperienceFeed> listOfExperienceFeeds = await _service.GetAllFeedbacks();// Calls the GetAllFeedbacks from the service
                if (listOfExperienceFeeds.Count == 0)
                    return Ok("No data to display");//Returns if there's no feed to display
                else
                    return Ok(listOfExperienceFeeds);// Display the feedbacks from the database
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

        //[Authorize(Roles = "MindtreeMind")]  // Restricts users other than MindtreeMind
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExperienceFeed(int id, ExperienceFeed experienceFeed) // This method Edit/Update exsisting feeback in the system
        {
            try
            {
                bool result = await _service.UpdateExperienceFeed(id, experienceFeed);// Calls the GetAllFeedbacks from the service
                if (result)
                    return Ok("Updated Successfully.."); //Returns the success message
                else
                    throw new UpdateException();
            }
            catch (UpdateException ex)
            {
                return Conflict(ex.ErrorMessage());// Returns the conflict occured while updating feed
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

        //[Authorize(Roles = "MindtreeMind,Admin")]  // Restricts users other than MindtreeMind and Admin
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFeed(int id)  // This method Delete/Remove your feedback from the system
        {
            try
            {
                bool result = await _service.DeleteExperienceFeed(id);// Calls the DeleteExperienceFeed from the service
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
