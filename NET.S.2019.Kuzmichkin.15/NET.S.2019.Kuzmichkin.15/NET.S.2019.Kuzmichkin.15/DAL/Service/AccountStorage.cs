using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using NET.S._2019.Kuzmichkin._15.DAL.Entity;
using NET.S._2019.Kuzmichkin._15.DAL.Interface;

namespace NET.S._2019.Kuzmichkin._15.DAL.Service
{
    public class AccountStorage : IStorage
    {
        private static List<Account> listaccs = new List<Account>();

        /// <summary>
        /// Add account to the list
        /// </summary>
        /// <param name="acc"></param>
        public void Add(string accType, string name, string lastname)
        {
            switch (accType)
            {
                case "Basic":
                    listaccs.Add(new BaseAccount(name, lastname));
                    break;
                case "Gold":
                    listaccs.Add(new GoldAccount(name, lastname));
                    break;
                case "Platinum":
                    listaccs.Add(new PlatinumAccount(name, lastname));
                    break;
            }
        }

        /// <summary>
        /// Delete account from list by id
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            Account acc = GetByID(id);

            if (acc == null)
            {
                throw new ArgumentException("Account not exist");
            }

            listaccs.Remove(acc);
        }

        /// <summary>
        /// Save list of accounts in file
        /// </summary>
        /// <param name="filename"></param>
        public void SaveAccs(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("acc.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, listaccs);

                Console.WriteLine("Объект сериализован");
            }
        }

        /// <summary>
        /// Load list of accounts from file
        /// </summary>
        /// <param name="filename"></param>
        public void LoadAccs(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                List<Account> listnew = (List<Account>)formatter.Deserialize(fs);

                listaccs = listnew;
            }
        }

        public List<Account> GetAccounts()
        {
            List<Account> result = new List<Account>();

            foreach(Account acc in listaccs)
            {
                result.Add(acc);
            }

            return result;
        }

        /// <summary>
        /// Found account in list by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account GetByID(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            if (id == string.Empty)
            {
                throw new ArgumentException();
            }

            if (listaccs.Count == 0)
            {
                return null;
            }

            foreach (Account a in listaccs)
            {
                if (a.AccId == id)
                {
                    return a;
                }
            }

            return null;
        }
    }
}