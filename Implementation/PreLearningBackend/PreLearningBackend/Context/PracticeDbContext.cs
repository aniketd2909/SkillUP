using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Context
{
    public class PracticeDbContext:DbContext
    {
        public PracticeDbContext(DbContextOptions<PracticeDbContext> options):base(options)
        {
        }
    }
}
