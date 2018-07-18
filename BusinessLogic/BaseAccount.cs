namespace BusinessLogic
{
    /// <summary>
    /// Instance of Base Account
    /// </summary>
    /// <seealso cref="BusinessLogic.BankAccount" />
    public class BaseAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="person">The person.</param>
        public BaseAccount(string id, AccountHolder person) : base(id, person)
        {
            costDeposite = 1000;
            costBalance = costDeposite * 2;
        }

        /// <summary>
        /// Determines whether [is valid balance] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is valid balance] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        protected override bool IsValidBalance(decimal value)
        {
            return value >= 0;
        }
    }
}
