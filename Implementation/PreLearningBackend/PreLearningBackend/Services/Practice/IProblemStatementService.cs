using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public interface IProblemStatementService
    {
        Task<List<ProblemStatement>> GetProblemStatement();
        Task<bool> AddProblemStatement(ProblemStatement problemStatement);

        Task<bool> DeleteProblemStatement(int id);

        Task<bool> UpdateProblemStatement(int id, ProblemStatement problemStatement);
    }
}
