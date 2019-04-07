using System;

namespace BankSystem
{
    [Serializable]
    public abstract class AAccount
    {
        protected internal string accid { get;}
        protected internal string ownerName { get; protected set; }
        protected internal string ownerLastname { get; protected set; }
        protected double balance;
        protected int bonusPoints;


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

        protected AAccount(string name, string lastName)
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
            Random rnd = new Random();
            accid = rnd.Next(1000000, 10000000).ToString();
        }

        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            balance += amount;
            UpdateBonusPoints(amount);
        }

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

        protected abstract void UpdateBonusPoints(int amount);
    }
}
