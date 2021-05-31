using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Services.Blocker
{
    public class BlockerSolutionService: IBlockerSolutionService
    {
        private readonly AppDbContext _context;

        public BlockerSolutionService(AppDbContext context)
        {
            _context = context;
        }

        //Method to add blocker solution
        public async Task<bool> AddBlockerSolution(Models.Blocker.BlockerSolution blockerSolution)
        {
            bool flag = true;
            await _context.BlockerSolutions.AddAsync(blockerSolution);
            int check = await _context.SaveChangesAsync();
            if (check < 0)
            {
                flag = false;
            }
            return flag;

        }

        //Method to delete blocker solution
        public async Task<bool> DeleteBlockerSolution(int id)
        {
            bool flag = true;
            Models.Blocker.BlockerSolution blockerSolution =await _context.BlockerSolutions.FindAsync(id);

            //If blocker solution with given id is not present throw an InvalidBlockerSolution

            if (blockerSolution == null)
            {
                throw new InvalidBlockerSoution("BlockerSolution not present");
            }
            _context.BlockerSolutions.Remove(blockerSolution);
            int check = await _context.SaveChangesAsync();
            if (check < 0)
            {
                flag = false;
            }
            return flag;

        }

        //Method to get all blocker solutions
        public async Task<List<Models.Blocker.BlockerSolution>> GetAllBlockerSoutions()
        {

            List<Models.Blocker.BlockerSolution> blockerSolutions =await _context.BlockerSolutions.ToListAsync();

            //If there is no blockerSolution present in database, throw an InvalidBlockerSolution

            if (blockerSolutions.Count==0)
            {
                throw new EmptyListException("List is empty");
            }
            return blockerSolutions;
        }

        //Method to get blocker solution by id
        public async  Task<Models.Blocker.BlockerSolution> GetBlockerSoutionById(int id)
        {
            //If blocker solution with given id is not present throw an InvalidBlockerSolution

            Models.Blocker.BlockerSolution blockerSolution =await _context.BlockerSolutions.FindAsync(id);

            if (blockerSolution == null)
            {
                throw new InvalidBlockerSoution("BlockerSolution not present");
            }
            return blockerSolution;
        }

        //Method to update blocker solution
        public async Task<bool> UpdateBlockerSolution(Models.Blocker.BlockerSolution blockerSolution)
        {
            bool flag = true;
            _context.BlockerSolutions.Update(blockerSolution);
            int check = await _context.SaveChangesAsync();
            if (check < 0)
            {
                flag = false;
            }
            return flag;
        }

    }


}

