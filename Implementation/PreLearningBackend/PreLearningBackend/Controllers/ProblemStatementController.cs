﻿using Microsoft.AspNetCore.Authorization;
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
    public class ProblemStatementController : ControllerBase
    {
        private readonly IProblemStatementService _service;

        public ProblemStatementController(IProblemStatementService service)
        {
            _service = service; // creates an reference object for the service
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> AddBestCodingPractice(ProblemStatement problemStatement)
        {
            try
            {
                bool result = await _service.AddProblemStatement(problemStatement); // Calls the ProblemStatement from the service
                if (result)
                    return Ok(" Problem Statement Added Successfully.."); //Returns the success message
                else
                    throw new AddProblemStatementError();

            }
            catch (AddBestPracticeError ex)
            {
                return Conflict(ex.message()); // Returns the conflict occured while adding ProblemStatement  to the database/system
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

        [Authorize(Roles = "Admin,CampusMind")]
        [HttpGet]
        public async Task<ActionResult<List<ProblemStatement>>> GetProblemStatement()
        {

            try
            {
                List<ProblemStatement> listOfProblemStatement = await _service.GetProblemStatement();// Calls the GetProblemStatement from the service
                if (listOfProblemStatement.Count == 0)
                    return Ok("No data to display");//Returns if there's no data to display
                else
                    return Ok(listOfProblemStatement);// Display the Problem statements from the database
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
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProblemStatement(int id, ProblemStatement problemStatement)
        {
            try
            {

                bool result = await _service.UpdateProblemStatement(id, problemStatement);// Calls the UpdateProblemStatement from the service
                if (result)
                    return Ok("Updated Successfully.."); //Returns the success message
                else
                    throw new UpdationProblemStatementError();
            }
            catch (UpdationError ex)
            {
                return Conflict(ex.message());// Returns the conflict occured while Updation ProblemStatement
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProblemStatement(int id)
        {
            try
            {
                bool result = await _service.DeleteProblemStatement(id);// Calls the DeleteProblemStatement from the service
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

