namespace BusinessLogic
{
    /// <summary>
    /// Instance of Silver account
    /// </summary>
    /// <seealso cref="BusinessLogic.BaseAccount" />
    public class SilverAccount : BaseAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SilverAccount"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="person">The person.</param>
        public SilverAccount(string id, AccountHolder person) : base(id, person)
        {
            costDeposite = 100;
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
            return value >= -100;
        }
    }
}
