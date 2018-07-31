using BLL.Interface.Entities;
using System;
using NLog;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Instanse of BankAccount
    /// </summary>
    /// <seealso cref="T" />
    public abstract class BankAccount
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        protected int costDeposite;
        protected int costBalance;

        protected BankAccount(string id, AccountHolder person)
        {
            this.Id = id;
            this.Person = person;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public Status Status { get; set; }

        /// <summary>
        /// Gets the bonus points.
        /// </summary>
        /// <value>
        /// The bonus points.
        /// </value>
        public int BonusPoints { get; private set; }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        protected decimal Balance { get; private set; }

        /// <summary>
        /// Gets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public AccountHolder Person { get; private set; }

        /// <summary>
        /// Deposites balance with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">You can't deposite account with 0 or negative value. - value</exception>
        public void Deposite(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("You can't deposite account with 0 or negative value.", nameof(value));
            }

            BonusPoints += CountBonus(value);
            Balance += value;
        }

        /// <summary>
        /// Withdraws balance with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">Can't withdraw account with 0 or negative value. - value</exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Withdraw(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Can't withdraw account with 0 or negative value.", nameof(value));
            }

            if (!IsValidBalance(Balance - value))
            {
                throw new InvalidOperationException($"Can't  withdraw {value}, because actual balance is {Balance}.");
            }

            BonusPoints -= CountBonus(value);
            Balance -= value;
        }

        /// <summary>
        /// Counts the bonus.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected abstract int CountBonus(decimal value);

        /// <summary>
        /// Determines whether [is valid balance] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is valid balance] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        protected abstract bool IsValidBalance(decimal value);

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Id + " " + Status + " " + Person + " " + Balance + " " + BonusPoints;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        //public bool Equals(BankAccount other)
        //{
        //    //???
        //    return false;
        //}

    }
}
