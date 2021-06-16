using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public interface IProblemStatementService
    {
        // To display all problem statements from the system
        Task<List<ProblemStatement>> GetProblemStatement();

        // To add a new problem statement to system
        Task<bool> AddProblemStatement(ProblemStatement problemStatement);

        // To Delete/Remove the problem statement from the system
        Task<bool> DeleteProblemStatement(int id);

        // To Edit/Update exsisting problem statement in the system
        Task<bool> UpdateProblemStatement(int id, ProblemStatement problemStatement);
    }
}
