using PreLearningBackend.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Resource
{
    public interface ITopicService
    {
         Task<List<Topic>> GetAllTopics();
         Task<Topic> GetTopicByName(string name);
         Task<bool> AddTopic(Topic Topic);
         Task<bool> DeleteTopicById(int id);
         Task<bool> updateTopic(Topic Topic);
    }
}
