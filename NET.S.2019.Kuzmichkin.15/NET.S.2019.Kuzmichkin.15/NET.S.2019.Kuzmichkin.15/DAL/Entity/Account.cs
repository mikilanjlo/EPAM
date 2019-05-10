using System;
using System.Collections.Generic;
using System.Text;

namespace NET.S._2019.Kuzmichkin._15.DAL.Entity
{
    [Serializable]
    public abstract class Account
    {
        //Private with propertyes or protected
        protected string accid;
        protected string ownerName;
        protected string ownerLastname;
        protected double balance;
        protected int bonusPoints;
        private static int currId = 1000000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        protected Account(string name, string lastName)
        {
            if (name == null || lastName == null)
            {
                throw new ArgumentNullException("Parametrs can't be null");
            }

            if (name.Length <= 1 || lastName.Length <= 1)
            {
                throw new ArgumentNullException("Parametrs can't be empty or less then 1");
            }

            ownerName = name;
            ownerLastname = lastName;
            //Random rnd = new Random();
            //accid = rnd.Next(1000000, 10000000).ToString();
            accid = currId++.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        internal string AccId
        {
            get
            {
                return accid;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    accid = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OwnerName
        {
            get
            {
                return ownerName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OwnerLastName
        {
            get
            {
                return ownerLastname;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    balance = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int BonusPoints
        {
            get
            {
                return bonusPoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    bonusPoints = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        // Transpher to service
        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            balance += amount;
            UpdateBonusPoints(amount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void Withdraw(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            if (balance - amount < 0)
            {
                throw new ArgumentException("Balance can't be negetive");
            }

            balance -= amount;
            UpdateBonusPoints(amount);
        }

        /// <summary>
        /// Converts currect instance to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return string.Format("______\nName: {0} {1}\nId: {2}\nBalance: {3}\nPoints: {4}\nType: " + GetType().Name,
                ownerLastname, ownerName, accid, balance, bonusPoints);
        }

        protected abstract void UpdateBonusPoints(int amount);
    }
}
