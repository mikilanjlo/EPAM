using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2019.Kuzmichkin._15.Bll.Entity;
using NET.S._2019.Kuzmichkin._15.DAL.Entity;

namespace NET.S._2019.Kuzmichkin._15.Bll.Interface
{
    public interface IService
    {
        void CreateNewAcc(AccType acctype, string name, string lastname);
        void CheckId(string id);
        void Delete(string id);
        void Deposit(string id, int amount);
        void Withdraw(string id, int amount);
        void Save(string filename);
        void Load(string filename);
        List<Account> GetAccounts();
    }
}
