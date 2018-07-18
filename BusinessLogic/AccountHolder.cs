using System.Text.RegularExpressions;
using System;

namespace BusinessLogic
{
    /// <summary>
    /// Instanse of a holder of account
    /// </summary>
    public class AccountHolder
    {
        private string firstName;
        private string lastName;
        private string email;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHolder"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <exception cref="ArgumentException">The account holder's data isn't valid.</exception>
        public AccountHolder(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            if (!IsValid()) 
            {
                throw new ArgumentException("The account holder's data isn't valid.");
            }
        }

        private bool IsValid()
        {
            Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex regexName = new Regex(@"^[a-zA-Z'-]+$");

            if (regexEmail.IsMatch(email) && regexName.IsMatch(firstName) && regexName.IsMatch(lastName))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return firstName + " " + lastName + " " + email;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (firstName + lastName + email).GetHashCode();
        }
    }
}
