using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using PreLearningBackend.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Resource
{
    public class TopicService : ITopicService
    {
        public readonly AppDbContext _context = null;
        public TopicService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddTopic(Topic Topic)
        {
            await _context.Topics.AddAsync(Topic);
            int check = await _context.SaveChangesAsync();
            if (check <= 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteTopicById(int id)
        {
            Topic topic = _context.Topics.Find(id);
            _context.Topics.Remove(topic);
            int check = await _context.SaveChangesAsync();
            if (check <= 0)
            {
                return false;
            }
            return true;
        }

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

        public async Task<Topic> GetTopicByName(string name)
        {
            Topic topic = await _context.Topics.Where(m => m.Name.Equals(name)).FirstOrDefaultAsync();
            return topic;
        }

        public async Task<bool> updateTopic(Topic Topic)
        {

            _context.Topics.Update(Topic);
            int check = await _context.SaveChangesAsync();
            if (check <= 0)
            {
                return false;
            }
            return true;

        }
    }
}
