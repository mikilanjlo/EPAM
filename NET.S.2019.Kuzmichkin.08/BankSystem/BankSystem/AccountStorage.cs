 using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BankSystem
{
    public class AccountStorage
    {
        private static List<AAccount> listaccs = new List<AAccount>();

        public static void Add(AAccount acc)
        {
            listaccs.Add(acc);
        }

        public static void Remove(string id)
        {
            AAccount acc = GetByID(id);

            if (acc == null)
            {
                throw new ArgumentException("Account not exist");
            }

            listaccs.Remove(acc);
        }

        public void SaveAccs(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("acc.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, listaccs);

            }
        }

        public void LoadAccs(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                List<AAccount> listnew = (List<AAccount>)formatter.Deserialize(fs);

                listaccs = listnew;
            }
        }

        private static AAccount GetByID(string id)
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

            foreach (AAccount a in listaccs)
            {
                if (a.accid == id)
                {
                    return a;
                }
            }

            return null;
        }
    }
}
