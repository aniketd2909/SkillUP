using PreLearningBackend.Models.ExperienceFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.ExpereienceFeed
{
    public interface IExperienceFeedService
    {
        // To display all existing feebacks from the system
        Task<List<ExperienceFeed>> GetAllFeedbacks();

        // To add a new feedback to system
        Task<bool> AddExperienceFeed(ExperienceFeed experienceFeed);

        // To Edit/Update exsisting feeback in the system
        Task<bool> UpdateExperienceFeed(int id, ExperienceFeed experienceFeed);

        // To Delete/Remove your feedback from the system
        Task<bool> DeleteExperienceFeed(int id);
    }
}
