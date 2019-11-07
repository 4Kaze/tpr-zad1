using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Classes;
using System.Collections.ObjectModel;

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

        [TestMethod]
        public void DataServiceDataContextFill()
        {
            DataService dataService = new DataService(new DataRepository(new FillConstant()));


            Dictionary<long, Catalog> catalogs = (Dictionary<long, Catalog>)dataService.GetAllCatalogs();
            ObservableCollection<Event> transactions = (ObservableCollection<Event>)dataService.GetAllTransactions();
            List<StateDescription> descriptions = (List<StateDescription>)dataService.GetAllStateDescriptions();
            List<Person> persons = (List<Person>)dataService.GetAllPersons();
            Assert.AreEqual(3, catalogs.Count);
            Assert.AreEqual(3, transactions.Count);
            Assert.AreEqual(3, descriptions.Count);
            Assert.AreEqual(3, persons.Count);

        }
    }
}
