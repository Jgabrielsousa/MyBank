using Microsoft.EntityFrameworkCore;
using MyBank.Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!this.Accounts.Any()) {
                this.Accounts.Add(new Account()
                {
                    Id = 1,
                    UserId = 1,
                    Balance = 100
                });
                this.Accounts.Add(new Account()
                {
                    Id = 2,
                    UserId = 2,
                    Balance = 200
                });
                this.SaveChanges();
            }
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProviderMyBankAccount");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(c => c.Id);
            modelBuilder.Entity<FinancialControl>().HasKey(c => c.Id);
            modelBuilder.Entity<Account>().HasOne(c => c.Users).WithMany(q => q.Accounts);
            modelBuilder.Entity<FinancialControl>().HasOne(c => c.Accounts).WithMany(q => q.FinancialControl);

        }
        public DbSet<Account> Accounts { get; set; }
    }



  
}
