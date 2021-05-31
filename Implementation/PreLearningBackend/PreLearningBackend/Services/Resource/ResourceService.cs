using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Resource
{
    public class ResourceService : IResourceService
    {
        public readonly AppDbContext _context = null;
        public ResourceService(AppDbContext context)
        {
            _context = context;
        }

        // This method is used to add the Resource 
        public async Task<bool> AddResource(Models.Resource.Resource Resource)
        {
            await _context.Resources.AddAsync(Resource);
            int checkss = await _context.SaveChangesAsync();
            if (checkss <= 0)
            {
                return false;
            }
            return true;
        }

        //This method is used to delete resource by Resource id
        public async Task<bool> DeleteResourceById(int id)
        {
            Models.Resource.Resource resource = _context.Resources.Find(id);
            _context.Resources.Remove(resource);
            int check = await _context.SaveChangesAsync();
            if (check <= 0)
            {
                return false;
            }
            return true;


        }

        //This method takes Topic id as parameter To get all the resources having/belonging to a particular topic id
        public async Task<List<Models.Resource.Resource>> GetAllResourcesByTopicId(int id)
        {
            List<Models.Resource.Resource> AllResources = await _context.Resources.ToListAsync();
            List<Models.Resource.Resource> Resources = new List<Models.Resource.Resource>();
            foreach (Models.Resource.Resource resource in AllResources)
            {
                if (resource.TopicId == id)
                {
                    Resources.Add(resource);
                }
            }
            return Resources;
        }


        public async Task<bool> updateResource(Models.Resource.Resource Resource)
        {
            _context.Resources.Update(Resource);
            int check = await _context.SaveChangesAsync();
            if (check <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
