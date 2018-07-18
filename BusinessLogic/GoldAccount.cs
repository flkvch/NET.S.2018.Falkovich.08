namespace BusinessLogic
{
    /// <summary>
    /// Instance of Gold Account
    /// </summary>
    /// <seealso cref="BusinessLogic.BaseAccount" />
    public class GoldAccount : BaseAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="person">The person.</param>
        public GoldAccount(string id, AccountHolder person) : base(id, person)
        {
            costDeposite = 10;
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
            return value >= -1000;
        }
    }
}
