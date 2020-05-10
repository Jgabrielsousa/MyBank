using Microsoft.EntityFrameworkCore;
using MyBank.Shared.Domain.Entities;
using MyBank.Transfers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Infra.Context
{
    public class TransfersDbContext : DbContext
    {
        public TransfersDbContext(DbContextOptions options) : base(options)
        {

        }
        public TransfersDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProviderMyBank");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialControl>().HasKey(c => c.Id);
        }
        public DbSet<FinancialControl> FinancialControls { get; set; }
    }
}
