using System;

namespace Core
{
    /// <summary>
    /// Generates the account number 
    /// </summary>
    /// <seealso cref="Core.IAccountNumberGenerator" />
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        /// <summary>
        /// Generates the account number by the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GenerateAccountNumber(string key)
        {
            return Math.Abs(key.GetHashCode()).ToString();
        }
    }
}
