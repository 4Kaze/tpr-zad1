using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zad1;

namespace UnitTests
{
    [TestClass]
    public class DataContextTests
    {
        [TestMethod]
        public void DataContextTest()
        { 
            Dictionary<long, Catalog> exampleBooks = new Dictionary<long, Catalog>();
            DataContext data = new DataContext();
        }

        [TestMethod]
        public void DataContextFillTest()
        {
            IFillInterface fillInterface = new FillConstant();
            DataContext dataContext = new DataContext();
            fillInterface.FillData(dataContext);
            Assert.AreEqual(3, dataContext.Books.Count);
            Assert.AreEqual(3, dataContext.Clients.Count);
            Assert.AreEqual(3, dataContext.Descriptions.Count);
            Assert.AreEqual(3, dataContext.Transactions.Count);
        }
    }
}
