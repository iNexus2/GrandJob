﻿namespace HireMe.Data
{
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using HireMe.Entities.Models;
using HireMe.Entities.Models.Chart;
    using HireMe.Entities.Models.Benchmark;

    public class BaseDbContext : IdentityDbContext<User>
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    

    public class FeaturesDbContext : DbContext
    {
        public FeaturesDbContext(DbContextOptions<FeaturesDbContext> options) : base(options) { }

        public DbSet<Contestant> Contestant { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Resume> Resume { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Logs> Logs { get; set; }

        public DbSet<JobStats> JobStats { get; set; }
        public DbSet<CompanyStats> CompanyStats { get; set; }
        public DbSet<Stats> ContestantStats { get; set; }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Files> Files { get; set; }

        public DbSet<ContestantDetails> ContestantDetails { get; set; }

        // Benchmark purpose
        public DbSet<ContestantTest> ContestantTest { get; set; }
        public DbSet<JobsTest> JobsTest { get; set; }
        public DbSet<CompanyTest> CompanyTest { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contestant>()
                        .Property(e => e.userSkillsId)
                        .HasConversion(
                            v => string.Join(',', v),
                            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

        }*/

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }*/
    }

}
