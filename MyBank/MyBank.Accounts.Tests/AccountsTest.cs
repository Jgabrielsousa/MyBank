using Moq;
using MyBank.Accounts.Domain.Entities;
using MyBank.Accounts.Domain.Interfaces.Repository;
using MyBank.Accounts.Domain.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace MyBank.Accounts.Tests
{
    public class AccountsTest 
    {
        private readonly Mock<IAccountRepository> _repo = new Mock<IAccountRepository>();


        private int GetRandomNumber() => new Random().Next(1, 100);

        public AccountService GetMock(Mock<IAccountRepository> _repo) => new AccountService(_repo.Object);

        public Account Item() => new Account() { Balance = 0, Id = GetRandomNumber(), UserId = GetRandomNumber() };

        [Fact]
        public void GetAllAccounts()
        {
            var lista = new List<Account>() { Item() };

            _repo.Setup(c => c.GetAll()).Returns(lista);

            var mock =  GetMock(_repo);

            var items = mock.GetAll();

            Assert.NotNull(items);
        }

        [Fact]
        public void GetOneAccount()
        {
            var item = Item();
            _repo.Setup(c => c.Find(It.IsAny<long>())).Returns(item);
            var mock = GetMock(_repo);

            var itemFound = mock.Find(item.Id);
            Assert.NotNull(itemFound);
        }

        [Fact]
        public void AddAccount()
        {
            var item = Item();
            _repo.Setup(c => c.Add(It.IsAny<Account>())).Returns(item);
            _repo.Setup(c => c.Find(It.IsAny<long>())).Returns(item);
            var mock = GetMock(_repo);
           var itemAdded =  mock.Add(item);

            Assert.Equal(itemAdded, mock.Find(itemAdded.Id));
        }


        [Fact]
        public void UpdateAccount()
        {

            var item = Item();
            var item2 = Item();
            item2.Balance = 100;

            _repo.Setup(c => c.Add(It.IsAny<Account>())).Returns(item);
            _repo.Setup(c => c.Update(It.IsAny<Account>()));
            _repo.SetupSequence(c => c.Find(It.IsAny<long>())).Returns(item).Returns(item2);

            var mock = GetMock(_repo);
            var itemAdded = mock.Add(item);
            var itemFound = mock.Find(itemAdded.Id);
            
            itemFound.Balance += 100;
            mock.Update(itemFound);

            var itemVerify = mock.Find(itemFound.Id);



            Assert.Equal(itemVerify.Balance, itemFound.Balance);
        }


        [Fact]
        public void RemoveAccount()
        {
            var item = Item();
            _repo.Setup(c => c.Add(It.IsAny<Account>())).Returns(item);
            _repo.Setup(c => c.Remove(It.IsAny<Account>()));
            _repo.SetupSequence(c => c.Find(It.IsAny<long>())).Returns(item).Returns(()=>null);
            var mock = GetMock(_repo);
            var itemAdded = mock.Add(item);
            var itemFound = mock.Find(itemAdded.Id);
            mock.Remove(itemFound);
            var itemStillExists = mock.Find(itemFound.Id);
            Assert.Null(itemStillExists);
        }


    }
}
