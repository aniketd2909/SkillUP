using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using PreLearningBackend.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Resource
{
    public class TopicService : ITopicService // Class which implements ITopicService service
    {
        public readonly AppDbContext _context = null;
        public TopicService(AppDbContext context)// Reference for AppDbContext
        {
            _context = context;
        }

        // This method is used to add the Topic 
        public async Task<bool> AddTopic(Topic Topic)
        {
            await _context.Topics.AddAsync(Topic);// Adds Topic to database asynchronously
            int check = await _context.SaveChangesAsync();// saves the changes 
            if (check <= 0)
            {
                return false;
            }
            return true;
        }

        //This method is used to delete resource by Topic id
        public async Task<bool> DeleteTopicById(int id)
        {
            Topic topic = _context.Topics.Find(id);// Gets the specific Topic by id
            _context.Topics.Remove(topic);// Removes the resource from the system permenantly
            int check = await _context.SaveChangesAsync(); // saves the changes 
            if (check <= 0)
            {
                return false;
            }
            return true;
        }

        //This method is used to get all the topics
        public async Task<List<Topic>> GetAllTopics()
        {
            List<Topic> topics = await _context.Topics.ToListAsync();
            
            foreach (Topic topic in topics)
            {
                List<Models.Resource.Resource> resources = await _context.Resources.Where(m=>m.TopicId==topic.Id).ToListAsync();
                foreach (Models.Resource.Resource resource in resources)
                {
                    resource.Topic = null;
                    topic.Resources.Add(resource);
                    
                }
            }
            return topics;
        }

        //This method is used to get a particular topic by its name.
        public async Task<Topic> GetTopicByName(string name)
        {
            Topic topic = await _context.Topics.Where(m => m.Name.Equals(name)).FirstOrDefaultAsync();
            return topic;
        }

        // This method is used to update a particular Topic in Database.
        public async Task<bool> updateTopic(Topic Topic)
        {

            _context.Topics.Update(Topic);// Updates the exsisting Topic
            int check = await _context.SaveChangesAsync();// saves the changes
            if (check <= 0)
            {
                return false;
            }
            return true;

        }
    }
}
