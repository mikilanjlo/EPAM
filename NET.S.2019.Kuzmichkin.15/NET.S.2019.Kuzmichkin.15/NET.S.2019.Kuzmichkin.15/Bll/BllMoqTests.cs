using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2019.Kuzmichkin._15.DAL.Service;
using NET.S._2019.Kuzmichkin._15.DAL.Interface;
using NET.S._2019.Kuzmichkin._15.DAL.Entity;
using NET.S._2019.Kuzmichkin._15.Bll.Service;
using NET.S._2019.Kuzmichkin._15.Bll.Interface;
using NET.S._2019.Kuzmichkin._15.Bll.Entity;
using NUnit.Framework;
using Moq;

namespace NET.S._2019.Kuzmichkin._15.Bll
{
    [TestFixture]
    public class BllMoqTests
    {
        [TestCase]
        public void Get_Accounts_Test()
        {
            var moq = new Mock<IStorage>();
            moq.Setup(a => a.GetAccounts()).Returns(new List<Account>());

            IService service = new BankService(moq.Object);

            var accounts = service.GetAccounts();

            Assert.IsNotNull(accounts);
        }

        [TestCase]
        public void Add_Wrong_Data_Account_Test()
        {
            var moq = new Mock<IStorage>();
            moq.Setup(a => a.Add("Basic", "", "")).Throws(new ArgumentNullException());

            IService service = new BankService(moq.Object);

            Assert.Throws<ArgumentNullException>(() => service.CreateNewAcc(AccType.Basic, "", ""));
        }
    }
}
