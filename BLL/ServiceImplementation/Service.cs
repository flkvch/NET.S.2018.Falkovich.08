using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Fake.Repositories;
using System;
using NLog;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Service to work with a bank
    /// </summary>
    /// <seealso cref="BLL.IService" />
    public class Service : IService
    {
        private IRepository<BankAccount> fakeRepository;
        //private IRepository<AccountHolder> fakeRepositoryHolders;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        public Service()
        {
            fakeRepository = new FakeRepository();
            //fakeRepositoryHolders = new FakeRepositoryHolders();
        }

        /// <summary>
        /// Opens the account.
        /// </summary>
        /// <param name="gen">The gen.</param>
        /// <param name="person">The person.</param>
        /// <param name="priveledge">The priveledge.</param>
        /// <param name="id">The identifier.</param>
        public void OpenAccount(IAccountNumberGenerator gen, AccountHolder person, Priveledge priveledge, out string id)
        {
            BankAccount bankAccount;
            id = gen.GenerateAccountNumber(person + " " + priveledge);

            switch ((int)priveledge)
            {
                case 1:
                    {
                        bankAccount = new BaseAccount(id, person);
                        break;
                    }

                case 2:
                    {
                        bankAccount = new SilverAccount(id, person);
                        break;
                    }

                case 3:
                    {
                        bankAccount = new GoldAccount(id, person);
                        break;
                    }

                case 4:
                    {
                        bankAccount = new PlatinumAccount(id, person);
                        break;
                    }

                default:
                    {
                        bankAccount = new BaseAccount(id, person);
                        break;
                    }
            }

            bankAccount.Status = Status.Open;
            fakeRepository.Create(bankAccount);
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="ArgumentException">This account has already been closed. - id</exception>
        public void CloseAccount(string id)
        {
            BankAccount bankAccount = fakeRepository.GetBy(id);
            if (bankAccount.Status == Status.Closed)
            {
                throw new ArgumentException("This account has already been closed. ", nameof(id));
            }

            bankAccount.Status = Status.Closed;
            fakeRepository.Update(bankAccount);
        }

        /// <summary>
        /// Deposites the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        public void Deposite(string id, decimal value)
        {
            BankAccount bankAccount = fakeRepository.GetBy(id);
            try
            {
                bankAccount.Deposite(value);
            }
            catch (ArgumentException e)
            {
                logger.Warn(e.Message, e.ParamName);
            }

            fakeRepository.Update(bankAccount);
        }

        /// <summary>
        /// Withdraws the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        public void Withdraw(string id, decimal value)
        {
            BankAccount bankAccount = fakeRepository.GetBy(id);
            try
            {
                bankAccount.Withdraw(value);
            }
            catch (ArgumentException e)
            {
                logger.Warn(e.Message, e.ParamName);
            }
            catch (InvalidOperationException e)
            {
                logger.Warn(e.Message);
            }

            fakeRepository.Update(bankAccount);
        }

        /// <summary>
        /// Gets the information about account by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string GetInfo(string id)
        {
            BankAccount bankAccount = fakeRepository.GetBy(id);
            return bankAccount.ToString();
        }
    }
}
