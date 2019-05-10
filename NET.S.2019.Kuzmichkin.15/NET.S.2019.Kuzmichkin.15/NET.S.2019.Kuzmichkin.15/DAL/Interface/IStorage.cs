using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2019.Kuzmichkin._15.DAL.Entity;

namespace NET.S._2019.Kuzmichkin._15.DAL.Interface
{
    public interface IStorage
    {
        void Add(string accType, string name, string lastname);
        void Remove(string id);
        void SaveAccs(string filename);
        void LoadAccs(string filename);
        Account GetByID(string id);
        List<Account> GetAccounts();


    }
}
