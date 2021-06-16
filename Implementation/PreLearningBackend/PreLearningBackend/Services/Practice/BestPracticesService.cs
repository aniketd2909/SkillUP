using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public class BestPracticesService: IBestPracticesService // Class which implements IBestPractices service
    {
        private readonly AppDbContext _context; // Reference for AppDbContext

        public BestPracticesService(AppDbContext context)
        {
            _context = context;
        }

        // To add a new best practice to system
        public async Task<bool> AddBestPractice(BestPractice bestpractices)
        {
            await _context.AddAsync(bestpractices); // Adds new best practice to database asynchronously
            int status = await _context.SaveChangesAsync(); // saves the changes 
            if (status > 0)
                return true;
            else
                return false;
        }

        // To Delete/Remove best practice from the system
        public async Task<bool> DeleteBestPractice(int id)
        {
            BestPractice bestpractices = _context.BestPractices.Find(id);  // Gets the specific best practice by id
            if (bestpractices != null)
            {
                _context.BestPractices.Remove(bestpractices); // Removes the best practice from the system permenantly
                int status = await _context.SaveChangesAsync(); // saves the changes 
                if (status > 0)
                    return true;
            }
            return false;

        }

        // To display all best practices from the system
        public async Task<List<BestPractice>> GetBestPractices()
        {
            List<BestPractice> bestpractices = await _context.BestPractices.ToListAsync();  // Gets all the best practices from the database 
            return bestpractices;
        }

        // To Edit/Update exsisting best practice in the system
        public async Task<bool> UpdateBestPractice(int id, BestPractice bestpractices)
        {
            bestpractices = _context.BestPractices.Find(id);  // Gets the specific best practice by id
            if (bestpractices != null)
            {
                _context.BestPractices.Update(bestpractices); // Updates the exsisting best practice
                int status = await _context.SaveChangesAsync(); // saves the changes
                if (status > 0)
                {
                    return true;
                }
            }
            else
            {
                throw new IdNotFoundInBestPractice();
            }
            return false;

        }
    }
}
