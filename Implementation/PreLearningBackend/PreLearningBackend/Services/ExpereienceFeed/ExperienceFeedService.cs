using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using PreLearningBackend.Models.ExperienceFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.ExpereienceFeed
{
    public class ExperienceFeedService : IExperienceFeedService
    {
        public readonly AppDbContext _context;
        public ExperienceFeedService(AppDbContext context)
        {
            _context = context;
        }
        // To add a new feedback to system
        public async Task<bool> AddExperienceFeed(ExperienceFeed experienceFeed)
        {
            bool result = false;
            await _context.ExperienceFeeds.AddAsync(experienceFeed); // Adds feed to database asynchronously
            int status = await _context.SaveChangesAsync(); // saves the changes 
            if (status > 0)
                result = true;

            return result;
        }

        // To Delete/Remove your feedback from the system
        public async Task<bool> DeleteExperienceFeed(int id)
        {
            bool result = false;
            ExperienceFeed experienceFeed = _context.ExperienceFeeds.Find(id); // Gets the specific ExperinceFeed by id
            if (experienceFeed != null)
            {
                _context.ExperienceFeeds.Remove(experienceFeed); // Removes the feed from the system permenantly
                await _context.SaveChangesAsync(); // saves the changes 
                result = true;
            }

            return result;
        }

        // To display all existing feebacks from the system
        public async Task<List<ExperienceFeed>> GetAllFeedbacks()
        {
             return await _context.ExperienceFeeds.ToListAsync(); // Gets all the feeds from the database 
        }

        // To Edit/Update exsisting feeback in the system
        public async Task<bool> UpdateExperienceFeed(int id, ExperienceFeed experienceFeed)
        {
            bool result = false;
            if (id == experienceFeed.Id && experienceFeed.Id != 0)
            {
                _context.ExperienceFeeds.Update(experienceFeed);// Updates the exsisting feed
                int status = await _context.SaveChangesAsync(); // saves the changes
                if (status > 0)
                    result = true;
            }

            return result;
        }
    }
}
