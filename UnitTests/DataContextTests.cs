using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zad1;
using App;

namespace UnitTests
{
    [TestClass]
    public class DataContextTests
    {
        [TestMethod]
        public void DataContextConstructorTest()
        {
            DataContext dc = new DataContext();
            Assert.IsNotNull(dc.Clients);
            Assert.IsNotNull(dc.Books);
            Assert.IsNotNull(dc.Transactions);
            Assert.IsNotNull(dc.Descriptions);
        }

        [TestMethod]
        public void DataContextFillConstatnTest()
        {
            IFillInterface fillInterface = new FillConstant();
            DataContext dataContext = new DataContext();
            fillInterface.FillData(dataContext);
            Assert.AreEqual(3, dataContext.Books.Count);
            Assert.AreEqual(3, dataContext.Clients.Count);
            Assert.AreEqual(3, dataContext.Descriptions.Count);
            Assert.AreEqual(3, dataContext.Transactions.Count);
        }



        [TestMethod]
        public void DataContextFillRandomTest()
        {
            IFillInterface fillInterface = new FillRandom();
            DataContext dataContext = new DataContext();
            int amount = 25;
            fillInterface.FillData(dataContext);
            Assert.AreEqual(amount, dataContext.Books.Count);
            Assert.AreEqual(amount, dataContext.Clients.Count);
            Assert.AreEqual(amount, dataContext.Descriptions.Count);
            Assert.AreEqual(amount, dataContext.Transactions.Count);
        }
    }
}
