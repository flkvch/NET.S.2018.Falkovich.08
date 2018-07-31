using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Instanse of a holder of account
    /// </summary>
    public class AccountHolder
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHolder"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <exception cref="ArgumentException">The account holder's data isn't valid.</exception>
        public AccountHolder(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Validation();
        }

        private void Validation()
        {
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex regexName = new Regex(@"^[a-zA-Z'-]+$");

            if (!regexEmail.IsMatch(Email) || !regexName.IsMatch(FirstName) || !regexName.IsMatch(LastName))
            {
                throw new ArgumentException("The account holder's data isn't valid.");
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Email;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (FirstName + LastName + Email).GetHashCode();
        }
    }
}
