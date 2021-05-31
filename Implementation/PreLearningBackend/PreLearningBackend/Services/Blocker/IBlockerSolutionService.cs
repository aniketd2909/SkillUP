using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Blocker
{
    public interface IBlockerSolutionService
    {
        //Method to get all blocker solutions
        Task<List<Models.Blocker.BlockerSolution>> GetAllBlockerSoutions();

        //Method to get blockersolution by Id 
        Task<Models.Blocker.BlockerSolution> GetBlockerSoutionById(int id);

        //Method to update blockersolution
        Task<bool> UpdateBlockerSolution(Models.Blocker.BlockerSolution blockerSolution);

        //Method to delete blockersolution
        Task<bool> DeleteBlockerSolution(int id);

        //Method to add blockersolution
        Task<bool> AddBlockerSolution(Models.Blocker.BlockerSolution blockerSolution);



    }
}
