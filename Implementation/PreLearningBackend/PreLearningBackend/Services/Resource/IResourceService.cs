using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PreLearningBackend.Models.Resource;

namespace PreLearningBackend.Services.Resource
{
    public interface IResourceService
    {
        Task<List<Models.Resource.Resource>> GetAllResourcesByTopicId(int id);
        Task<bool> AddResource(Models.Resource.Resource Resource);
        Task<bool> DeleteResourceById(int id);
        Task<bool> updateResource(Models.Resource.Resource Resource);
    }
}
