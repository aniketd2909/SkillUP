using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public class BestPracticesService:IBestPracticesService
    {
        private readonly AppDbContext _context;

        public BestPracticesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBestPractice(BestPractice bestpractices)
        {
            await _context.AddAsync(bestpractices);
            int status = await _context.SaveChangesAsync();
            if (status > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteBestPractice(int id)
        {
            BestPractice bestpractices = _context.BestPractices.Find(id);
            if (bestpractices != null)
            {
                _context.BestPractices.Remove(bestpractices);
                int status = await _context.SaveChangesAsync();
                if (status > 0)
                {
                    return true;
                }
            }
            return false;

        }

        public async Task<List<BestPractice>> GetBestPractices()
        {
            List<BestPractice> bestpractices = await _context.BestPractices.ToListAsync();
            return bestpractices;
        }

        public async Task<bool> UpdateBestPractice(int id, BestPractice bestpractices)
        {
            bestpractices = _context.BestPractices.Find(id);
            if (bestpractices != null)
            {
                _context.BestPractices.Update(bestpractices);
                int status = await _context.SaveChangesAsync();
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
