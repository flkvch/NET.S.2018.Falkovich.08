using Core;

namespace BusinessLogic
{
    /// <summary>
    /// Service
    /// </summary>
    public interface IService
    {
        void OpenAccount(IAccountNumberGenerator gen, AccountHolder person, Priveledge priveledge, out string id);

        void CloseAccount(string id);

        void Deposite(string id, decimal value);

        void Withdraw(string id, decimal value);
    }
}
