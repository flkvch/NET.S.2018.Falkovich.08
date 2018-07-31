using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Fake;
using DAL.Interface.Interfaces;
using DAL;
using Ninject;
using DAL.Fake.Repositories;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            kernel.Bind<IService>().To<Service>();
            kernel.Bind<IRepository<BankAccount>>().To<FakeRepository>();
            //kernel.Bind<IRepository>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountNumberGenerator>().To<AccountNumberGenerator>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
