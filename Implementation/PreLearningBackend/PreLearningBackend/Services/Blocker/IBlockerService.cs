using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Blocker
{
    public interface IBlockerService
    {
        //Method to add blocker
        Task<bool> AddBlocker(Models.Blocker.Blocker blocker);

        //Method to update blocker
        Task<bool> UpdateBlocker(Models.Blocker.Blocker blocker);

        //Method to get all blockers
        Task<List<Models.Blocker.Blocker>> GetAllBlockers();

        //Method to delete blocker
        Task<bool> DeleteBlocker(int id);

        //Method to get blocker by Id
        Task<Models.Blocker.Blocker> GetBlockerById(int id);

    }
}
