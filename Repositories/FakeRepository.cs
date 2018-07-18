using BusinessLogic;
using System.Collections.Generic;

namespace Repositories
{
    /// <summary>
    /// Repository, based on list
    /// </summary>
    /// <seealso cref="Repositories.IRepository" />
    public class FakeRepository : IRepository
    {
        private List<BankAccount> fakeRepository;

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
        public BankAccount GetById(string id)
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
