using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Accounts.Tests.Injector;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using MyBank.Shared.Domain.Entities;

namespace MyBank.Accounts.Tests
{
    public class AccountsTest : IClassFixture<InjectorDependencies>
    {
        private readonly IAccountService _service;

        public AccountsTest(InjectorDependencies injector)
        {
            _service = injector.ServiceProvider.GetService<IAccountService>();
        }
        [Fact]
        public void GetAllAccounts()
        {
            var items = _service.GetAll();
            Assert.NotNull(items);
        }
        [Fact]
        public void GetOneAccount()
        {
            var item = new Account()
            {
                Id = 200,
                UserId = 1,
                Balance = 100
            };
            item = _service.Add(item);
            var itemFound = _service.Find(item.Id);
            Assert.NotNull(item);
        }

        [Fact]
        public void AddAccount()
        {
            var item = new Account()
            {
                Id = 200,
                UserId = 1,
                Balance = 100
            };
            item = _service.Add(item);
            Assert.NotNull(item);
        }
        [Fact]
        public void UpdateAccount()
        {
            var item = new Account()
            {
                Id = 200,
                UserId = 1,
                Balance = 100
            };
            item = _service.Add(item);
            var itemFound = _service.Find(item.Id);
            itemFound.Balance = 2000;
            _service.Update(itemFound);
            Assert.NotNull(item);
        }


        [Fact]
        public void RemoveAccount()
        {
            var item = new Account()
            {
                Id = 200,
                UserId = 1,
                Balance = 100
            };
            item = _service.Add(item);
            var itemFound = _service.Find(item.Id);
            _service.Remove(itemFound);
            Assert.NotNull(item);
        }
    }
}
