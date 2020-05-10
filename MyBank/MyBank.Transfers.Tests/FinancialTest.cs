using Moq;
using MyBank.Transfers.Domain.Entities;
using MyBank.Transfers.Domain.Interfaces;
using MyBank.Transfers.Domain.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace MyBank.Transfers.Tests
{
    public class FinancialTest
    {
        private readonly Mock<IFinancialControlRepository> _repo = new Mock<IFinancialControlRepository>();
        

        private FinancialControlService GetMock(Mock<IFinancialControlRepository> _repo) =>  new FinancialControlService(_repo.Object);
            
       
        [Fact]
        public void GetOneFinancialControl()
        {
            var item = GetItem();


            //RETURNS
            _repo.Setup(c => c.Add(It.IsAny<FinancialControl>())).Returns(item);
            _repo.Setup(c => c.Find(It.IsAny<long>())).Returns(item);

            //MOCKS
            var mock = GetMock(_repo);
            //ACT
            var expected = mock.Add(item);
            var ItemFound = mock.Find(item.Id);
            //VALIDATIONS
            Assert.NotNull(ItemFound);
        }

        [Fact]
        public void GetAllFinancialControl()
        {
            //BUILD RETURNS
            var items = GetList();
            //SETUPS
            _repo.Setup(c => c.GetAll()).Returns(items);
            //MOCKS
            var mock = GetMock(_repo);
            //ACT
            var expected = mock.GetAll();
            //VALIDATIONS
            Assert.NotNull(expected);
            Assert.Equal(expected,items);
        }

        [Fact]
        public void AddFinancialControl()
        {
            //BUILD RETURNS
            var item = GetItem();
            //SETUPS
            _repo.Setup(c => c.Find(It.IsAny<long>())).Returns(() => item);
            _repo.Setup(c => c.Add(It.IsAny<FinancialControl>())).Returns(item);
            //MOCKS
            var mock = GetMock(_repo);
            //ACT
            var expected = mock.Add(item);
            var ItemFound = mock.Find(item.Id);
            //VALIDATIONS
            Assert.NotNull(ItemFound);
            Assert.Equal(expected, ItemFound);
        }
        [Fact]
        public void UpdateFinancialControl()
        {
            //BUILD RETURNS
            var item = GetItem();
            //SETUPS
            _repo.Setup(c => c.Add(It.IsAny<FinancialControl>())).Returns(item);
            _repo.Setup(c => c.Find(It.IsAny<long>())).Returns(() => item);
            _repo.Setup(c => c.Update(It.IsAny<FinancialControl>()));

            //MOCKS
            var mock = GetMock(_repo);
            //ACT
            mock.Add(item);
            var itemFound = mock.Find(item.Id);
            itemFound.Amount = 1000;
            mock.Update(item);
            var expected = mock.Find(item.Id);
            //VALIDATIONS
            Assert.NotNull(expected);
            Assert.Equal(expected.Amount, itemFound.Amount);
        }

        [Fact]
        public void RemoveFinancialControl()
        {
            //BUILD RETURNS
            var item = GetItem();
            //SETUPS
            _repo.Setup(c => c.Add(It.IsAny<FinancialControl>())).Returns(item);
            _repo.SetupSequence(c => c.Find(It.IsAny<long>())).Returns(item).Returns(() => null);
            _repo.Setup(c => c.Remove(It.IsAny<FinancialControl>()));

            //MOCKS
            var mock = GetMock(_repo);
            //ACT
            mock.Add(item);
            var itemFound = mock.Find(item.Id);
            mock.Remove(itemFound);
            var expected = mock.Find(itemFound.Id);
            //VALIDATIONS
            Assert.Null(expected);
        }

        private int GetRandomNumber() => new Random().Next(1, 100);


        private FinancialControl GetItem() => new FinancialControl()
        {
            Id = GetRandomNumber(),
            Amount = 100,
            Balance = 100,
            Type = "C",
            AccountId = 1
        };

        private List<FinancialControl> GetList() => new List<FinancialControl>() { 
        
            new FinancialControl{
            Id = GetRandomNumber(),
            Amount = 100,
            Balance = 100,
            Type = "C",
            AccountId = 1
        },
             new FinancialControl{
            Id = GetRandomNumber(),
            Amount = 100,
            Balance = 100,
            Type = "C",
            AccountId = 1
        }
        };
    }
}
