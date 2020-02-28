using Microsoft.EntityFrameworkCore;
using MyBank.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Infra.Data.Context
{
    public class MyBankContext : DbContext
    {
        public MyBankContext(DbContextOptions options) : base(options) { }

        public MyBankContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProviderMyBank");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(o => o.ValidationResult);
        }

        public DbSet<User> Users { get; set; }

        

    }
}
