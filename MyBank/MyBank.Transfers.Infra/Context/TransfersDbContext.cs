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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialControl>().Ignore(o => o.ValidationResult);
            modelBuilder.Entity<User>().Ignore(o => o.ValidationResult);
            modelBuilder.Entity<FinancialControl>().HasOne(c => c.Accounts).WithMany(q => q.FinancialControl);
            modelBuilder.Entity<Account>().HasOne(c => c.Users).WithMany(q => q.Accounts);
        }
        public DbSet<FinancialControl> FinancialControls { get; set; }
    }
}
