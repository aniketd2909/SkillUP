using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Models.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Context
{
    public class PracticeDbContext:DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<BestPractice> BestPractices { get; set; }
        public DbSet<ProblemStatement> ProblemStatements { get; set; }
        public PracticeDbContext(DbContextOptions<PracticeDbContext> options):base(options)
        {
        }
    }
}
