using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public interface IBestPracticesService
    {
        Task<List<BestPractice>> GetBestPractices();
        Task<bool> AddBestPractice(BestPractice bestpractices);

        Task<bool> DeleteBestPractice(int id);

        Task<bool> UpdateBestPractice(int id, BestPractice bestpractices);
    }
}
