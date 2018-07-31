using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
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

        /// <summary>
        /// Counts the bonus.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected override int CountBonus(decimal value)
        {
            return (int)(Balance * (1 / costBalance) + value * (1 / costDeposite)) * 2;
        }
    }
}
