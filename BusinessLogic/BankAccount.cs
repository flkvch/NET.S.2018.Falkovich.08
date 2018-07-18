using System;

namespace BusinessLogic
{
    /// <summary>
    /// Instanse of BankAccount
    /// </summary>
    /// <seealso cref="System.IEquatable{BusinessLogic.BankAccount}" />
    public abstract class BankAccount : IEquatable <BankAccount>
    {
        protected int costBalance;
        protected int costDeposite;
        private AccountHolder person;
        private decimal balance;
        private int bonusPoints;

        protected BankAccount(string id, AccountHolder person)
        {
            this.Id = id;
            this.person = person;
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

            bonusPoints += CountBonus(value);
            balance += value;
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

            if (!IsValidBalance(balance - value)) 
            {
                throw new InvalidOperationException($"Can't  withdraw {value}, because actual balance is {balance}.");
            }

            bonusPoints -= CountBonus(value);
            balance -= value;
        }

        /// <summary>
        /// Counts the bonus.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected int CountBonus(decimal value)
        {
            return (int)(balance * (1 / costBalance) + value * (1 / costDeposite));
        }

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
            return Id.ToString() + " "  + Status.ToString() + " " + person.ToString() + " " + balance.ToString() + " " + bonusPoints.ToString();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(BankAccount other)
        {
            if (this == null && other == null)
            {
                return true;
            }

            //???
            return false;
        }
    }
}
