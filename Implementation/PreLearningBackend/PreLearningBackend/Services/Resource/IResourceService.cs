using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PreLearningBackend.Models.Resource;

namespace PreLearningBackend.Services.Resource
{
    public interface IResourceService
    {
        // To display all Resources of same topic from the system
        Task<List<Models.Resource.Resource>> GetAllResourcesByTopicId(int id);

        // To add a new Resource to system
        Task<bool> AddResource(Models.Resource.Resource Resource);

        // To Delete/Remove your Resource from the system
        Task<bool> DeleteResourceById(int id);

        // To Edit/Update exsisting Resource in the system
        Task<bool> updateResource(Models.Resource.Resource Resource);
    }
}
