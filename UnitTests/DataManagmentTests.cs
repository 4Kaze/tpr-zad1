using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zad1;

namespace UnitTests
{
    [TestClass]
    public class DataManagmentTests
    {
        [TestMethod]
        public void DataContextTest()
        { 
            Dictionary<long, Catalog> exampleBooks = new Dictionary<long, Catalog>();
            DataContext data = new DataContext();
        }

        [TestMethod]
        public void DataRepositoryOperations()
        {
            Person person = new Person(1, "Stan", "Peacock", "Michelles 42");
            DataRepository repository = new DataRepository();

            //Person Collection
            Assert.AreEqual(null, repository.GetPerson(0));
            repository.AddPerson(person);
            Assert.AreEqual(person, repository.GetPerson(0));
            repository.DeletePersonByIndex(0);
            Assert.AreEqual(null, repository.GetPerson(0));
            repository.AddPerson(person);
            Assert.AreEqual(person, repository.GetPerson(0));
            repository.DeletePersonByReference(person);
            Assert.AreEqual(null, repository.GetPerson(0));
        }
    }
}
