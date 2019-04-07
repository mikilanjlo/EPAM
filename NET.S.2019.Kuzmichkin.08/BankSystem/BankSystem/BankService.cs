using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class BankService
    {
        
        public virtual void CreateNewAcc(AccType acctype, string name, string lastname)
        {
            if (name == null || lastname == null)
            {
                throw new ArgumentNullException("Parametrs can't be null");
            }

            if (name.Length <= 1 || lastname.Length <= 1)
            {
                throw new ArgumentNullException("Parametrs can't be empty or less then 1");
            }

            switch (acctype)
            {
                case AccType.Basic:
                    AccountStorage.Add(new BaseAccount(name, lastname));
                    break;
                case AccType.Gold:
                    AccountStorage.Add(new GoldAccount(name, lastname));
                    break;
                case AccType.Platinum:
                    AccountStorage.Add(new PlatinumAccount(name, lastname));
                    break;
            }
        }
    }
}
