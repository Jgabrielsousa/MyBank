using MyBank.Transfers.Domain.Interfaces;
using MyBank.Transfers.Tests.Injector;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using MyBank.Shared.Domain.Entities;

namespace MyBank.Transfers.Tests
{
    public class FinancialTest : IClassFixture<InjectorDependencies>
    {
        private readonly IFinancialControlService _service;
        public FinancialTest(InjectorDependencies injector)
        {
            _service = injector.ServiceProvider.GetService<IFinancialControlService>();
        }

        [Fact]
        public void GetAllFinancialControls()
        {
            var items = _service.GetAll();
            Assert.NotNull(items);
        }

        [Fact]
        public void GetOneFinancialControls()
        {
            var item = _service.Add(new FinancialControl()
            {
                Id = 1,
                Amount = 100,
                Balance = 100,
                Type = "C",
                AccountId = 1
            });

            var ItemFound = _service.Find(item.Id);
            Assert.NotNull(ItemFound);
        }

        [Fact]
        public void AddFinancialControl()
        {
            var item = _service.Add(new FinancialControl()
            {
                Id = 1,
                Amount = 100,
                Balance = 100,
                Type = "C",
                AccountId = 1
            });
            Assert.NotNull(item);
        }
        [Fact]
        public void UpdateFinancialControl()
        {
            var item = _service.Add(new FinancialControl()
            {
                Id = 1,
                Amount = 100,
                Balance = 100,
                Type = "C",
                AccountId = 1
            });
            var itemFound = _service.Find(item.Id);
            itemFound.Type = "D";
             _service.Update(itemFound);
            Assert.NotNull(item);
        }

        [Fact]
        public void RemoveFinancialControl()
        {
            var item = _service.Add(new FinancialControl()
            {
                Id = 1,
                Amount = 100,
                Balance = 100,
                Type = "C",
                AccountId = 1
            });
            var itemFound = _service.Find(item.Id);
            _service.Remove(itemFound);
            Assert.NotNull(item);
        }
    }
}
