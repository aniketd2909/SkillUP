using PreLearningBackend.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Resource
{
    public interface ITopicService
    {
        // To display all Topic from the system.
        Task<List<Topic>> GetAllTopics();

        //To get a particular Topic by its name.
        Task<Topic> GetTopicByName(string name);

        // To add a new Topic to system.
        Task<bool> AddTopic(Topic Topic);

        // To Delete/Remove your Topic from the system
        Task<bool> DeleteTopicById(int id);

        // To Edit/Update exsisting Topic in the system
        Task<bool> updateTopic(Topic Topic);
    }
}
