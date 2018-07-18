using BusinessLogic;

namespace Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public interface IRepository
    {
        void Create(BankAccount account);

        BankAccount GetById(string id);

        void Update(BankAccount account);
        //CRUD operations Create Read Update Delete - wout delete?
    }
}
