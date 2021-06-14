using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Context;


namespace PreLearningBackend.Services.Blocker
{


    public class BlockerService: IBlockerService// Class which implements IBlockerService service
    {

        private readonly AppDbContext _context;

        public BlockerService(AppDbContext context)// Reference for AppDbContext
        {
            _context = context;
        }

        // This method is used to add the blocker 
        public async Task<bool> AddBlocker(Models.Blocker.Blocker blocker)
        {
            bool flag = true;
            await _context.Blockers.AddAsync(blocker);// Adds blocker to database asynchronously
            int check = await _context.SaveChangesAsync();// saves the changes 
            if (check < 0)
            {
                flag = false;
            }
            return flag;

        }

        //Method to update blocker
        public async Task<bool> UpdateBlocker(Models.Blocker.Blocker blocker)
        {
            bool flag = true;
            _context.Blockers.Update(blocker);
            int check = await _context.SaveChangesAsync();
            if (check < 0)
            {
                flag = false;
            }
            return flag;
        }

        //Method to get all blockers
        public async Task<List<Models.Blocker.Blocker>> GetAllBlockers()
        {
            List<Models.Blocker.Blocker> blockers =await _context.Blockers.ToListAsync();
            foreach (Models.Blocker.Blocker blocker in blockers)
            {
                List<Models.Blocker.BlockerSolution> blockerSolutions = await _context.BlockerSolutions.Where(m => m.BlockerId == blocker.Id).ToListAsync();
                foreach (Models.Blocker.BlockerSolution blockerSolution in blockerSolutions)
                {
                    blockerSolution.Blocker = null;
                    blocker.BlockerSolutions.Add(blockerSolution);
                }
            
            }
            //If blockers list is empty throw an EmptyList Exception
            if (blockers.Count == 0)
            {
                throw new  EmptyListException("List is Empty");
            }
            return blockers;

        }

        //Method to get blocker by Id
        public async Task<Models.Blocker.Blocker> GetBlockerById(int id)
        {
            Models.Blocker.Blocker blocker =await _context.Blockers.FindAsync(id);// Gets the specific Blocker by id

            //If blocker with given id is not present throw an InvalidBlocker Exception

            if (blocker == null)
            {
                throw new InvalidBlocker("Blocker not Present");
            }
            List<Models.Blocker.BlockerSolution> blockerSolutions = _context.BlockerSolutions.Where(m => m.BlockerId == id).ToList();
            foreach (var blockerSolution in blockerSolutions)
            {
                blockerSolution.Blocker = null;
                blocker.BlockerSolutions.Add(blockerSolution);
            }
            return blocker;
        }


        //Method to delete blocker
        public async Task<bool> DeleteBlocker(int id)
        {
            bool flag = true;
            Models.Blocker.Blocker blocker =await _context.Blockers.FindAsync(id);

            //If blocker with given id is not present throw an InvalidBlocker Exception

            if (blocker == null)
            {
                throw new InvalidBlocker("Blocker not Present");
            }

            _context.Blockers.Remove(blocker);
            int check = await _context.SaveChangesAsync();
            if (check < 0)
            {
                flag = false;
            }
            return flag;
        }
    }


}

