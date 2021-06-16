using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Practice
{
    public interface IBestPracticesService
    {
        // To display all best practices from the system
        Task<List<BestPractice>> GetBestPractices();

        // To add a new best practice to system
        Task<bool> AddBestPractice(BestPractice bestpractices);

        // To Delete/Remove the best practice from the system
        Task<bool> DeleteBestPractice(int id);

        // To Edit/Update exsisting best practice in the system
        Task<bool> UpdateBestPractice(int id, BestPractice bestpractices);
    }
}
