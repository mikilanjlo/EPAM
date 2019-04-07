using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    [Serializable]
    public class BaseAccount : AAccount
    {
        /// <summary>
        /// Initialize  class BaseAccount
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        public BaseAccount(string name, string lastname) : base(name, lastname)
        { }

        /// <summary>
        /// Update bonus points when deposit or withdraw method call
        /// </summary>
        /// <param name="amount">Money that we take or deposit</param>
        protected override void UpdateBonusPoints(int amount)
        {
            bonusPoints += amount / 100;
        }
    }
}
