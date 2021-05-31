using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public class ProblemStatementService:IProblemStatementService
    {
        private readonly AppDbContext _context;

        public ProblemStatementService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProblemStatement(ProblemStatement problemStatement)
        {
            await _context.AddAsync(problemStatement);
            int status = await _context.SaveChangesAsync();
            if (status > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteProblemStatement(int id)
        {
            ProblemStatement problemStatement = _context.ProblemStatements.Find(id);
            if (problemStatement != null)
            {
                _context.ProblemStatements.Remove(problemStatement);
                int status = await _context.SaveChangesAsync();
                if (status > 0)
                {
                    return true;
                }
            }
            return false;

        }

        public async Task<List<ProblemStatement>> GetProblemStatement()
        {
            List<ProblemStatement> problemStatements = await _context.ProblemStatements.ToListAsync();
            return problemStatements;
        }

        public async Task<bool> UpdateProblemStatement(int id, ProblemStatement problemStatement)
        {
            problemStatement = _context.ProblemStatements.Find(id);
            if (problemStatement != null)
            {
                _context.ProblemStatements.Update(problemStatement);
                int status = await _context.SaveChangesAsync();
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
