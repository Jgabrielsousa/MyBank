using MyBank.Accounts.Domain.Interfaces.Services;
using MyBank.Accounts.Tests.Injector;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

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
        public void GetAllAccountsControls()
        {
            var items = _service.GetAll();
            Assert.NotNull(items);
        }
    }
}
