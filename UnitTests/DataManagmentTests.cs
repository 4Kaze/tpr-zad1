using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zad1;

namespace UnitTests
{
    [TestClass]
    public class DataManagmentTests
    {

        [TestMethod]
        public void DataRepositoryOperations()
        {
            Person person = new Person(1, "Stan", "Peacock", "Michelles 42");
            Author author = new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null));
            Catalog catalog = new Catalog(1, "Pride and Prejudice", "This is description", author);

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

            //Catalog Collection
            Assert.AreEqual(null, repository.GetCatalog(0));
            repository.AddCatalog(catalog);
            Assert.AreEqual(1, repository.CatalogKey);
            Assert.AreEqual(catalog, repository.GetCatalog(0));
            repository.DeleteCatalogByIndex(0);
            Assert.AreEqual(null, repository.GetCatalog(0));
        }
    }
}
