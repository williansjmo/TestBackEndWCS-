using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Domain.Entities;
using Test.Domain.Mapping;

namespace Test.Infrastructure.Persistence
{
    public class TestDbContext : DbContext
    {
        public DbSet<Candidate> Candidate { get; set; }
        public TestDbContext(DbContextOptions<TestDbContext> dbContext) : base(dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
