using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DependencyResolver;
using Ninject;
using NLog;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            IService service = new Service();
            service.OpenAccount(new AccountNumberGenerator(), new AccountHolder("Vasya", "Pupkin", "vasya123@rambler.ru"), Priveledge.Base, out string id);
            Console.WriteLine(((Service)service).GetInfo(id));
            service.Deposite(id, 1000);
            Console.WriteLine(((Service)service).GetInfo(id));
            service.Withdraw(id, 500);
            Console.WriteLine(((Service)service).GetInfo(id));
            try
            {
                service.CloseAccount(id);
            }
            catch (Exception e)
            {
                logger.Warn(e.Message);
            }

            Console.WriteLine(((Service)service).GetInfo(id));

            try
            {
                service.CloseAccount(id);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                service.Withdraw(id, 50000);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            service.OpenAccount(new AccountNumberGenerator(), new AccountHolder("Petya", "Ivanov", "petya123@rambler.ru"), Priveledge.Platinum, out string id2);
            Console.WriteLine(((Service)service).GetInfo(id2));
            service.Deposite(id2, 1_000_000);
            Console.WriteLine(((Service)service).GetInfo(id2));
            service.Withdraw(id2, 500);
            Console.WriteLine(((Service)service).GetInfo(id2));
            service.Withdraw(id2, 1_000_000);
            Console.WriteLine(((Service)service).GetInfo(id2));

            Console.ReadLine();
        }
    }
}
