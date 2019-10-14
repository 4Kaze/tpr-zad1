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
            Person person = new Person("Stan", "Peacock", "Michelles 42");
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

            Person person2 = new Person("Stan", "Peacock", "Michelles 42");
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
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
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

            Catalog catalog2 = new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
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
            StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
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

            StateDescription stateDescription2 = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
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
            Event transaction = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
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

            Event transaction2 = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
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
        public void RepositoryPersonMultipleItemsTest()
        {
            DataRepository dr = new DataRepository();
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 100; i++)
            {
                Person p = new Person("Name" + i.ToString(), "Surname" + i.ToString());
                persons.Add(p);
                dr.AddPerson(p);
            }
            for(int i = 0; i < 100; i++)
            {
                Assert.AreEqual(persons[i], dr.GetPerson(i));
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(persons[i], dr.GetPersonByCode(persons[i].Code));
            }

            int count1 = 0;
            List<Person> personsToRemove = new List<Person>();
            for (int i = 0; i < 100; i += 9)
            {
                personsToRemove.Add(persons[i]);
            }

            foreach(Person p in personsToRemove)
            {
                count1 += 1;
                persons.Remove(p);
                Assert.AreEqual(1, dr.DeletePerson(p));
            }

            foreach(Person p in persons)
            {
                Assert.IsNotNull(dr.GetPersonByCode(p.Code));
            }

            int count2 = 0;
            IEnumerator<Person> enumerator = dr.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100-count1, count2);

            List<int> indexesToRemove = new List<int>();

            for (int i = 0; i < count2; i += 8)
            {
                indexesToRemove.Add(i);
            }

            int count3 = 0;
            foreach(int index in indexesToRemove)
            {
                count1 += 1;
                persons.RemoveAt(index - count3);
                Assert.AreEqual(1, dr.DeletePersonByIndex(index - count3));
                count3 += 1;
            }

            foreach (Person p in persons)
            {
                Assert.IsNotNull(dr.GetPersonByCode(p.Code));
            }

            count2 = 0;
            enumerator = dr.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count1, count2);
        }

        [TestMethod]
        public void RepositoryCatalogMultipleItemsTest()
        {
            DataRepository dr = new DataRepository();
            List<Catalog> catalogs = new List<Catalog>();
            for (int i = 0; i < 100; i++)
            {
                Catalog catalog = new Catalog("Title"+i.ToString(), "Description"+i.ToString(), new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
                catalogs.Add(catalog);
                dr.AddCatalog(catalog);
            }
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(catalogs[i], dr.GetCatalog(i));
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(catalogs[i], dr.GetCatalogByCode(catalogs[i].Code));
            }

            List<int> indexesToRemove = new List<int>();

            for (int i = 0; i < 100; i += 8)
            {
                indexesToRemove.Add(i);
            }

            int count1 = 0;
            foreach (int index in indexesToRemove)
            {
                catalogs.RemoveAt(index - count1);
                Assert.AreEqual(1, dr.DeleteCatalogByKey(index));
                count1 += 1;
            }

            foreach (Catalog p in catalogs)
            {
                Assert.IsNotNull(dr.GetCatalogByCode(p.Code));
            }

            int count2 = 0;
            IEnumerator<KeyValuePair<long, Catalog>> enumerator = dr.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count1, count2);

            List<Catalog> catalogsToRemove = new List<Catalog>();
            for (int i = 0; i < count2; i += 9)
            {
                catalogsToRemove.Add(catalogs[i]);
            }

            foreach (Catalog p in catalogsToRemove)
            {
                count1 += 1;
                catalogs.Remove(p);
                Assert.AreEqual(1, dr.DeleteCatalog(p));
            }

            foreach (Catalog p in catalogs)
            {
                Assert.IsNotNull(dr.GetCatalogByCode(p.Code));
            }

            count2 = 0;
            enumerator = dr.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count1, count2);
        }

        [TestMethod]
        public void RepositoryStateDescriptionMultipleItemsTest()
        {
            DataRepository dr = new DataRepository();
            List<StateDescription> stateDescriptions = new List<StateDescription>();
            for (int i = 0; i < 100; i++)
            {
                StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
                stateDescriptions.Add(stateDescription);
                dr.AddStateDescription(stateDescription);
            }
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(stateDescriptions[i], dr.GetStateDescription(i));
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(stateDescriptions[i], dr.GetStateDescriptionByCode(stateDescriptions[i].Code));
            }

            int count1 = 0;
            List<StateDescription> stateDescriptionsToRemove = new List<StateDescription>();
            for (int i = 0; i < 100; i += 9)
            {
                stateDescriptionsToRemove.Add(stateDescriptions[i]);
            }

            foreach (StateDescription p in stateDescriptionsToRemove)
            {
                count1 += 1;
                stateDescriptions.Remove(p);
                Assert.AreEqual(1, dr.DeleteStateDescription(p));
            }

            foreach (StateDescription p in stateDescriptions)
            {
                Assert.IsNotNull(dr.GetStateDescriptionByCode(p.Code));
            }

            int count2 = 0;
            IEnumerator<StateDescription> enumerator = dr.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count1, count2);

            List<int> indexesToRemove = new List<int>();

            for (int i = 0; i < count2; i += 8)
            {
                indexesToRemove.Add(i);
            }

            int count3 = 0;
            foreach (int index in indexesToRemove)
            {
                count1 += 1;
                stateDescriptions.RemoveAt(index - count3);
                Assert.AreEqual(1, dr.DeleteStateDescriptionByIndex(index - count3));
                count3 += 1;
            }

            foreach (StateDescription p in stateDescriptions)
            {
                Assert.IsNotNull(dr.GetStateDescriptionByCode(p.Code));
            }

            count2 = 0;
            enumerator = dr.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count1, count2);
        }

        [TestMethod]
        public void RepositoryTransactionMultipleItemsTest()
        {
            DataRepository dr = new DataRepository();
            List<Event> transactions = new List<Event>();
            for (int i = 0; i < 100; i++)
            {
                Event transaction = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
                transactions.Add(transaction);
                dr.AddTransaction(transaction);
            }
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(transactions[i], dr.GetTransaction(i));
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(transactions[i], dr.GetTransactionByCode(transactions[i].Code));
            }

            int count1 = 0;
            List<Event> transactionsToRemove = new List<Event>();
            for (int i = 0; i < 100; i += 9)
            {
                transactionsToRemove.Add(transactions[i]);
            }

            foreach (Event p in transactionsToRemove)
            {
                count1 += 1;
                transactions.Remove(p);
                Assert.AreEqual(1, dr.DeleteTransaction(p));
            }

            foreach (Event p in transactions)
            {
                Assert.IsNotNull(dr.GetTransactionByCode(p.Code));
            }

            int count2 = 0;
            IEnumerator<Event> enumerator = dr.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count1, count2);

            List<int> indexesToRemove = new List<int>();

            for (int i = 0; i < count2; i += 8)
            {
                indexesToRemove.Add(i);
            }

            int count3 = 0;
            foreach (int index in indexesToRemove)
            {
                count1 += 1;
                transactions.RemoveAt(index - count3);
                Assert.AreEqual(1, dr.DeleteTransactionByIndex(index - count3));
                count3 += 1;
            }

            foreach (Event p in transactions)
            {
                Assert.IsNotNull(dr.GetTransactionByCode(p.Code));
            }

            count2 = 0;
            enumerator = dr.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count1, count2);
        }


        [TestMethod]
        public void DataRepositoryOperations()
        {
            Person person = new Person("Stan", "Peacock", "Michelles 42");
            Author author = new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null));
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", author);

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
