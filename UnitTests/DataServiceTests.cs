using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zad1;
using App;

namespace UnitTests
{
    [TestClass]
    public class DataServiceTests
    {
        public object MessageBox { get; private set; }

        [TestMethod]
        public void DataServiceConstructorTest()
        {
            DataService dataService = new DataService(new DataRepository(new FillConstant()));
        }


        [TestMethod]
        public void DataServiceGenerateViewOfList()
        {
            // nie wiem jak to stestowac
            // PRÓBOWAŁEM
            DataService dataService = new DataService(new DataRepository(new FillConstant()));
            Assert.IsNotNull(dataService.ViewList(dataService.GetAllCatalogs()));
            Assert.IsNotNull(dataService.ViewList(dataService.GetAllPersons()));
            Assert.IsNotNull(dataService.ViewList(dataService.GetAllStateDescriptions()));
            Assert.IsNotNull(dataService.ViewList(dataService.GetAllTransactions()));

        }


        [TestMethod]
        public void DataServiceAllView()
        {
            // nie wiem jak to stestowac
            // PRÓBOWAŁEM
            DataService dataService = new DataService(new DataRepository(new FillConstant()));
            Assert.IsNotNull(dataService.FullView());
        }

    }
}