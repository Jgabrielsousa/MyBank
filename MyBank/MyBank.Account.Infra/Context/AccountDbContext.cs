using Microsoft.EntityFrameworkCore;
using MyBank.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Accounts.Infra.Context
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions options) : base(options)
        {

        }
        public AccountDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProviderMyBankAccount");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Ignore(c => c.ValidationResult);
            modelBuilder.Entity<FinancialControl>().Ignore(o => o.ValidationResult);

            modelBuilder.Entity<Account>().HasOne(c => c.Users).WithMany(q => q.Account);
            modelBuilder.Entity<FinancialControl>().HasOne(c => c.Accounts).WithMany(q => q.FinancialControl);

        }
        public DbSet<Account> Accounts { get; set; }
    }
}
