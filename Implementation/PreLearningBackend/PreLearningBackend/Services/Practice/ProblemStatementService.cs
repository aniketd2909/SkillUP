using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public class ProblemStatementService: IProblemStatementService // Class which implements IProblemStatement service
    {
        private readonly AppDbContext _context; // Reference for AppDbContext

        public ProblemStatementService(AppDbContext context)
        {
            _context = context;
        }

        // To add a new problem statement to system
        public async Task<bool> AddProblemStatement(ProblemStatement problemStatement)
        {
            string question = problemStatement.Question;
            question = question.Replace(".", "." + Environment.NewLine); //To addNew lines while storing data in DB
            problemStatement.Question = question;
            await _context.AddAsync(problemStatement); // Adds new problem statement to database asynchronously
            int status = await _context.SaveChangesAsync(); // saves changes
            if (status > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // To Delete/Remove problem statement from the system
        public async Task<bool> DeleteProblemStatement(int id)
        {
            ProblemStatement problemStatement = _context.ProblemStatements.Find(id); // Gets the specific problem statement by id
            if (problemStatement != null)
            {
                _context.ProblemStatements.Remove(problemStatement); // Removes the problem statement from the system permenantly
                int status = await _context.SaveChangesAsync(); // saves changes
                if (status > 0)
                {
                    return true;
                }
            }
            return false;

        }

        // To display all problem statement from the system
        public async Task<List<ProblemStatement>> GetProblemStatement()
        {
            List<ProblemStatement> problemStatements = await _context.ProblemStatements.ToListAsync(); // Gets all the problem statements from the database 
            return problemStatements;
        }

        // To Edit/Update exsisting problem statement in the system
        public async Task<bool> UpdateProblemStatement(int id, ProblemStatement problemStatement)
        {
            problemStatement = _context.ProblemStatements.Find(id); // Gets the specific problem statement by id
            if (problemStatement != null)
            {
                _context.ProblemStatements.Update(problemStatement);  // Updates the exsisting problem statement
                int status = await _context.SaveChangesAsync(); // saves changes
                if (status > 0)
                {
                    return true;
                }
            }
            else
            {
                throw new IdNotFoundInBestPractice();

            }
            return false;

        }
    }
}
