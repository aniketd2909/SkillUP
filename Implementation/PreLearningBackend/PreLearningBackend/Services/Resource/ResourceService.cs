using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Resource
{
    public class ResourceService : IResourceService // Class which implements IResourceService service
    {
        public readonly AppDbContext _context = null;
        public ResourceService(AppDbContext context) // Reference for AppDbContext
        {
            _context = context;
        }

        // This method is used to add the Resource 
        public async Task<bool> AddResource(Models.Resource.Resource Resource)
        {
            await _context.Resources.AddAsync(Resource);// Adds Resource to database asynchronously
            int checkss = await _context.SaveChangesAsync();// saves the changes 
            if (checkss <= 0)
            {
                return false;
            }
            return true;
        }

        //This method is used to delete resource by Resource id
        public async Task<bool> DeleteResourceById(int id)
        {
            Models.Resource.Resource resource = _context.Resources.Find(id);// Gets the specific Resource by id
            _context.Resources.Remove(resource);// Removes the resource from the system permenantly
            int check = await _context.SaveChangesAsync(); // saves the changes 
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

        // This method is used to update a particular resource in Database.
        public async Task<bool> updateResource(Models.Resource.Resource Resource)
        {
            _context.Resources.Update(Resource);// Updates the exsisting Resource
            int check = await _context.SaveChangesAsync();// saves the changes
            if (check <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
