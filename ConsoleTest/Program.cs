using BusinessLogic;
using Core;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IService service = new Service();
            service.OpenAccount(new AccountNumberGenerator(), new AccountHolder("Vasya", "Pupkin", "vasya123@rambler.ru"), Priveledge.Base, out string id);
            Console.WriteLine(((Service)service).GetInfo(id));
            service.Deposite(id, 1000);
            Console.WriteLine(((Service)service).GetInfo(id));
            service.Withdraw(id, 500);
            Console.WriteLine(((Service)service).GetInfo(id));
            service.CloseAccount(id);
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
