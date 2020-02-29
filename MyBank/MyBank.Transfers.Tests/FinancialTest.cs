using MyBank.Transfers.Domain.Interfaces;
using MyBank.Transfers.Tests.Injector;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
