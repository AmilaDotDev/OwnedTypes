using Microsoft.EntityFrameworkCore;
using OwnedTypes.Configurations;
using OwnedTypes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes
{
    public class TestDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=OwnedTypesTestDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }
    }
}
