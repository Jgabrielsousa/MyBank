using Microsoft.Extensions.DependencyInjection;
using MyBank.Transfers.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank.Transfers.Tests.Injector
{
    public class InjectorDependencies
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public InjectorDependencies()
        {
            var services = new ServiceCollection();
            Bootstrap.RegisterServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
