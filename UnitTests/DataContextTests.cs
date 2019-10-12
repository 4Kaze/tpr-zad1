using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zad1;

namespace UnitTests
{
    public class FillConstatnt : IFillInterface
    {
        public void FillData(DataContext dataContext)
        {
            // Person Data FIll
            Person person1 = new Person(1, "Marcus", "Sagthon", "Michelles 42");
            Person person2 = new Person(2, "Ugho", "Olkag", "Putar 34");
            Person person3 = new Person(3, "Toby", "Vercer", "Palatem 51");

            dataContext.clients.Add(person1);
            dataContext.clients.Add(person2);
            dataContext.clients.Add(person3);

            // Catalog Data Fill
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            Author author1 = new Author(1, "Jane", "Austen", date);
            Author author2 = new Author(2, "Lew", "Tolstoj", date);
            Author author3 = new Author(3, "Dmitry ", "Glukhovsky", date);

            Catalog catalog1 = new Catalog(1, "Pride and Prejudice", "This is description1", author1);
            Catalog catalog2 = new Catalog(1, "War and Peace", "This is description2", author2);
            Catalog catalog3 = new Catalog(1, "Metro 2033", "This is description3", author3);

            dataContext.books.Add(1, catalog1);
            dataContext.books.Add(2, catalog2);
            dataContext.books.Add(3, catalog3);

            // StateDescription Data Fill
            StateDescription stateDescription1 = new StateDescription(1, catalog1, System.DateTimeOffset.Now, "Somewhere");
            StateDescription stateDescription2 = new StateDescription(2, catalog2, System.DateTimeOffset.Now, "There");
            StateDescription stateDescription3 = new StateDescription(3, catalog3, System.DateTimeOffset.Now, "Here");

            dataContext.descriptions.Add(stateDescription1);
            dataContext.descriptions.Add(stateDescription2);
            dataContext.descriptions.Add(stateDescription3);

            //Event Data Fill
            System.DateTimeOffset date1 = System.DateTimeOffset.Now;
            Event happening1 = new Event(1, person1, stateDescription1, date1);
            Event happening2 = new Event(2, person2, stateDescription1, date1);
            Event happening3 = new Event(3, person3, stateDescription1, date1);

            dataContext.transactions.Add(happening1);
            dataContext.transactions.Add(happening2);
            dataContext.transactions.Add(happening3);
        }
    }

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
            IFillInterface fillInterface = new FillConstatnt();
            DataContext dataContext = new DataContext();
            fillInterface.FillData(dataContext);
            Assert.AreEqual(3, dataContext.books.Count);
            Assert.AreEqual(3, dataContext.clients.Count);
            Assert.AreEqual(3, dataContext.descriptions.Count);
            Assert.AreEqual(3, dataContext.transactions.Count);
        }
    }
}
