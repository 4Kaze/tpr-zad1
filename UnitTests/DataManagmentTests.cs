using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zad1;

namespace UnitTests
{
    [TestClass]
    public class DataManagmentTests
    {
        [TestMethod]
        public void RepositoryPersonCRUDTest()
        {
            DataRepository repository = new DataRepository();
            Person person = new Person(1, "Stan", "Peacock", "Michelles 42");
            repository.AddPerson(person);
            Assert.AreEqual(person, repository.GetPerson(0));
            Assert.AreEqual(person, repository.GetPersonByCode(person.Code));

            IEnumerator<object> enumerator = repository.GetAllPersons().GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(person, enumerator.Current);

            int count = 0;
            enumerator = repository.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            Person person2 = new Person(1, "Stan", "Peacock", "Michelles 42");
            person2.Code = 2;
            repository.UpdatePerson(0, person2);
            Assert.AreEqual(person2, repository.GetPerson(0));

            person2.Name = "test";
            repository.UpdatePerson(person2);
            Assert.AreEqual("test", repository.GetPerson(0).Name);

            count = 0;
            enumerator = repository.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);
            repository.AddPerson(person);

            count = 0;
            enumerator = repository.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(2, count);
            repository.DeletePerson(person);

            count = 0;
            enumerator = repository.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            repository.DeletePersonByIndex(0);
            count = 0;
            enumerator = repository.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(0, count);
        }
        [TestMethod]
        public void RepositoryCatalogCRUDTest()
        {
            DataRepository repository = new DataRepository();
            Catalog catalog = new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            repository.AddCatalog(catalog);
            Assert.AreEqual(catalog, repository.GetCatalog(0));
            Assert.AreEqual(catalog, repository.GetCatalogByCode(catalog.Code));

            IEnumerator<KeyValuePair<long, Catalog>> enumerator = repository.GetAllCatalogs().GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(catalog, enumerator.Current.Value);

            int count = 0;
            enumerator = repository.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            Catalog catalog2 = new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            catalog2.Code = 2;
            repository.UpdateCatalog(0, catalog2);
            Assert.AreEqual(catalog2, repository.GetCatalog(0));

            catalog2.Title = "test";
            repository.UpdateCatalog(catalog2);
            Assert.AreEqual("test", repository.GetCatalog(0).Title);

            count = 0;
            enumerator = repository.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);
            repository.AddCatalog(catalog);

            count = 0;
            enumerator = repository.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(2, count);
            int test = repository.DeleteCatalog(catalog);

            count = 0;
            enumerator = repository.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            repository.DeleteCatalogByKey(0);
            count = 0;
            enumerator = repository.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(0, count);
        }
        [TestMethod]
        public void RepositoryStateDescriptionCRUDTest()
        {
            DataRepository repository = new DataRepository();
            StateDescription stateDescription = new StateDescription(1, new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            repository.AddStateDescription(stateDescription);
            Assert.AreEqual(stateDescription, repository.GetStateDescription(0));
            Assert.AreEqual(stateDescription, repository.GetStateDescriptionByCode(stateDescription.Code));

            IEnumerator<object> enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(stateDescription, enumerator.Current);

            int count = 0;
            enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            StateDescription stateDescription2 = new StateDescription(1, new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            stateDescription2.Code = 2;
            repository.UpdateStateDescription(0, stateDescription2);
            Assert.AreEqual(stateDescription2, repository.GetStateDescription(0));

            stateDescription2.Availabile = false;
            repository.UpdateStateDescription(stateDescription2);
            Assert.AreEqual(false, repository.GetStateDescription(0).Availabile);

            count = 0;
            enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);
            repository.AddStateDescription(stateDescription);

            count = 0;
            enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(2, count);
            repository.DeleteStateDescription(stateDescription);

            count = 0;
            enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            repository.DeleteStateDescriptionByIndex(0);
            count = 0;
            enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(0, count);
        }
        [TestMethod]
        public void RepositoryTransactionCRUDTest()
        {
            DataRepository repository = new DataRepository();
            Event transaction = new Event(1, new Person(1, "Stan", "Peacock", "Michelles 42"), new StateDescription(1, new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            repository.AddTransaction(transaction);
            Assert.AreEqual(transaction, repository.GetTransaction(0));
            Assert.AreEqual(transaction, repository.GetTransactionByCode(transaction.Code));

            IEnumerator<object> enumerator = repository.GetAllTransactions().GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(transaction, enumerator.Current);

            int count = 0;
            enumerator = repository.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            Event transaction2 = new Event(1, new Person(1, "Stan", "Peacock", "Michelles 42"), new StateDescription(1, new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            transaction2.Code = 2;
            repository.UpdateTransaction(0, transaction2);
            Assert.AreEqual(transaction2, repository.GetTransaction(0));

            System.DateTimeOffset date = System.DateTimeOffset.ParseExact("31/01/2019 21:37", "dd/MM/yyyy HH:mm", null);
            transaction2.ReturnDate = date;
            repository.UpdateTransaction(transaction2);
            Assert.AreEqual(date, repository.GetTransaction(0).ReturnDate);

            count = 0;
            enumerator = repository.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);
            repository.AddTransaction(transaction);

            count = 0;
            enumerator = repository.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(2, count);
            repository.DeleteTransaction(transaction);

            count = 0;
            enumerator = repository.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            repository.DeleteTransactionByIndex(0);
            count = 0;
            enumerator = repository.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void DataRepositoryOperations()
        {
            Person person = new Person(1, "Stan", "Peacock", "Michelles 42");
            Author author = new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null));
            Catalog catalog = new Catalog(1, "Pride and Prejudice", "This is description", author);

            IEnumerable<KeyValuePair<long, Catalog>> catalogs = null;
            IEnumerable<Person> persons = null;

           DataRepository repository = new DataRepository();

            //Person Collection
            Assert.AreEqual(null, repository.GetPerson(0));
            repository.AddPerson(person);
            Assert.AreEqual(person, repository.GetPerson(0));
            repository.DeletePersonByIndex(0);
            Assert.AreEqual(null, repository.GetPerson(0));
            repository.AddPerson(person);
            Assert.AreEqual(person, repository.GetPerson(0));
            Assert.AreEqual(persons, null);
            Assert.AreEqual(catalogs, null);

            persons = repository.GetAllPersons();
            catalogs = repository.GetAllCatalogs();

            Assert.AreNotEqual(persons, null);
            Assert.AreNotEqual(catalogs, null);

            repository.DeletePerson(person);

            Assert.AreEqual(null, repository.GetPerson(0));

            //Catalog Collection
            Assert.AreEqual(null, repository.GetCatalog(0));
            repository.AddCatalog(catalog);
            Assert.AreEqual(1, repository.CatalogKey);
            Assert.AreEqual(catalog, repository.GetCatalog(0));
            repository.DeleteCatalogByKey(0);
            Assert.AreEqual(null, repository.GetCatalog(0));
        }
    }
}
