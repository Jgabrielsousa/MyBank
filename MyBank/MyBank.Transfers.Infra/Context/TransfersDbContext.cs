using Microsoft.EntityFrameworkCore;
using MyBank.Shared.Domain.Entities;
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
            modelBuilder.Entity<Account>().HasKey(c => c.Id);
            modelBuilder.Entity<FinancialControl>().HasOne(c => c.Accounts).WithMany(q => q.FinancialControl);
        }
        public DbSet<FinancialControl> FinancialControls { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
