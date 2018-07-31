using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Fake.Repositories
{
    /// <summary>
    /// Repository, based on list
    /// </summary>
    /// <seealso cref="Repositories.IRepository" />
    public class FakeRepository : IRepository<BankAccount>
    {
        private readonly List<BankAccount> fakeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeRepository"/> class.
        /// </summary>
        public FakeRepository()
        {
            fakeRepository = new List<BankAccount>();
        }

        /// <summary>
        /// Updates the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        public void Update(BankAccount account)
        {
            int index = fakeRepository.FindIndex(x => x.Id == account.Id);
            fakeRepository.RemoveAt(index);
            fakeRepository.Insert(index, account);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public BankAccount GetBy(string id)
        {
            int index = fakeRepository.FindIndex(x => x.Id == id);
            return fakeRepository[index];
        }

        /// <summary>
        /// Creates the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        public void Create(BankAccount account)
        {
            fakeRepository.Add(account);
        }
    }
}
