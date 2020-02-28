using MyBank.Credit.Test.Injector;
using MyBank.Shared.Domain.Interfaces.IServices;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace MyBank.Credit.Test
{
    public class UnitUserTest : IClassFixture<InjectorDependencies>
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        public UnitUserTest(InjectorDependencies injector)
        {
            _userService = injector.ServiceProvider.GetService<IUserService>();
            _accountService = injector.ServiceProvider.GetService<IAccountService>();
            _userService.GetAll();
        }
        [Fact]
        public void GetUsers()
        {
            var items  = _userService.GetAll();
            Assert.NotNull(items);
        }

        [Fact]
        public void GetUsersAccounts()
        {
            var items = _accountService.GetAll();
            Assert.NotNull(items);
        }
    }
}
