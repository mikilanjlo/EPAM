using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    [Serializable]
    public class GoldAccount : AAccount
    {
        /// <summary>
        ///  Initialize  class GoldAccount
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        public GoldAccount(string name, string lastname) : base(name, lastname) { }

        /// <summary>
        /// Update bonus points when deposit or withdraw method call
        /// </summary>
        /// <param name="amount">Money that we take or deposit</param>
        protected override void UpdateBonusPoints(int amount)
        {
            bonusPoints += amount / 50;
        }
    }
}
