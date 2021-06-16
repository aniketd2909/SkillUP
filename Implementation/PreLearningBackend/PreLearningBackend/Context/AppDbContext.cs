using Microsoft.EntityFrameworkCore;
using PreLearningBackend.Models.Blocker;
using PreLearningBackend.Models.ExperienceFeed;
using PreLearningBackend.Models.Practice;
using PreLearningBackend.Models.Resource;
using PreLearningBackend.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreLearningBackend.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<BestPractice> BestPractices { get; set; }
        public DbSet<ProblemStatement> ProblemStatements { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Blocker> Blockers { get; set; }
        public DbSet<BlockerSolution> BlockerSolutions { get; set; }
        public DbSet<ExperienceFeed> ExperienceFeeds { get; set; }
        public DbSet<Mind> Minds { get; set; }
        public DbSet<CampusMind> CampusMinds { get; set; }
        public DbSet<MindTreeMind> MindTreeMinds { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SelectedUser> SelectedUsers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
    }
}
