using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Domain.Mapping
{
    public class CandidateMapping : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(h=> h.Id);
            builder.Property(p=> p.Name).IsRequired().HasMaxLength(20);
            builder.Property(p=> p.LastName).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Age).IsRequired().HasMaxLength(2);
            builder.Property(p => p.Identification).IsRequired().HasMaxLength(10);
            builder.Property(p => p.HouseAspire).IsRequired().HasMaxLength(10);
        }
    }
}
