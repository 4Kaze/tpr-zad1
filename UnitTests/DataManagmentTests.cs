using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Zad1;

namespace UnitTests
{
    [TestClass]
    public class DataManagmentTests
    {
        [TestMethod]
        public void RepositoryPersonEnumeratorTest()
        {
            DataRepository repository = new DataRepository();
            Person person = new Person("Stan", "Peacock", "Michelles 42");
            repository.AddPerson(person);

            int count = 0;
            IEnumerator<object> enumerator = repository.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            Person person2 = new Person("Stan", "Peacock", "Michelles 42");
            repository.AddPerson(person2);

            count = 0;
            enumerator = repository.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RespositoryPersonADDTest()
        {
            DataRepository repository = new DataRepository();
            Person person = new Person("Stan", "Peacock", "Michelles 42");
            repository.AddPerson(person);
            Assert.AreEqual(person, repository.GetPersonByCode(person.Code));

            IEnumerator<object> enumerator = repository.GetAllPersons().GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(person, enumerator.Current);

            int count = 0;
            enumerator = repository.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void RepositoryPersonUPDATETest()
        {
            DataRepository repository = new DataRepository();
            Person person = new Person("Stan", "Peacock", "Michelles 42");
            repository.AddPerson(person);

            Person person2 = new Person("Stan", "Peacock", "Michelles 42");
            person2.Code = person.Code;
            repository.UpdatePerson(person2);

            Assert.AreEqual(person2, repository.GetPersonByCode(person2.Code));

            Person person3 = new Person("Stan", "Peacock", "Michelles 42");
            person3.Code = person.Code;
            person3.Name = "test";

            repository.UpdatePerson(person3);
            Assert.AreEqual("test", repository.GetPersonByCode(person.Code).Name);
        }

        [TestMethod]
        public void RepositoryPersonDELTETest()
        {
            DataRepository repository = new DataRepository();
            Person person = new Person("Stan", "Peacock", "Michelles 42");
            repository.AddPerson(person);
            repository.DeletePerson(person);

            int count = 0;
            IEnumerator<object> enumerator = repository.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(0, count);
        }
        [TestMethod]
        public void RepositoryCatalogEnumeratorTest()
        {
            DataRepository repository = new DataRepository();
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            repository.AddCatalog(catalog);

            int count = 0;
            IEnumerator<KeyValuePair<long, Catalog>> enumerator = repository.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            Catalog catalog2 = new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            repository.AddCatalog(catalog2);

            count = 0;
            enumerator = repository.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RespositoryCatalogADDTest()
        {
            DataRepository repository = new DataRepository();
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            repository.AddCatalog(catalog);
            Assert.AreEqual(catalog, repository.GetCatalogByCode(catalog.Code));

            IEnumerator<KeyValuePair<long, Catalog>> enumerator = repository.GetAllCatalogs().GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(catalog, enumerator.Current.Value);

            int count = 0;
            enumerator = repository.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void RepositoryCatalogUPDATETest()
        {
            DataRepository repository = new DataRepository();
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            repository.AddCatalog(catalog);

            Catalog catalog2 = new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            catalog2.Code = catalog.Code;
            repository.UpdateCatalog(catalog2);

            Assert.AreEqual(catalog2, repository.GetCatalogByCode(catalog2.Code));

            Catalog catalog3 = new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            catalog3.Code = catalog.Code;
            catalog3.Title = "test";

            repository.UpdateCatalog(catalog3);
            Assert.AreEqual("test", repository.GetCatalogByCode(catalog.Code).Title);
        }

        [TestMethod]
        public void RepositoryCatalogDELTETest()
        {
            DataRepository repository = new DataRepository();
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            repository.AddCatalog(catalog);
            repository.DeleteCatalog(catalog);

            int count = 0;
            IEnumerator<KeyValuePair<long, Catalog>> enumerator = repository.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(0, count);
        }
        [TestMethod]
        public void RepositoryStateDescriptionEnumeratorTest()
        {
            DataRepository repository = new DataRepository();
            StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            repository.AddStateDescription(stateDescription);

            int count = 0;
            IEnumerator<object> enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            StateDescription stateDescription2 = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            repository.AddStateDescription(stateDescription2);

            count = 0;
            enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RespositoryStateDescriptionADDTest()
        {
            DataRepository repository = new DataRepository();
            StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            repository.AddStateDescription(stateDescription);
            Assert.AreEqual(stateDescription, repository.GetStateDescriptionByCode(stateDescription.Code));

            IEnumerator<object> enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(stateDescription, enumerator.Current);

            int count = 0;
            enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void RepositoryStateDescriptionUPDATETest()
        {
            DataRepository repository = new DataRepository();
            StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            repository.AddStateDescription(stateDescription);

            StateDescription stateDescription2 = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            stateDescription2.Code = stateDescription.Code;
            repository.UpdateStateDescription(stateDescription2);

            Assert.AreEqual(stateDescription2, repository.GetStateDescriptionByCode(stateDescription2.Code));

            StateDescription stateDescription3 = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            stateDescription3.Code = stateDescription.Code;
            stateDescription3.Location = "test";

            repository.UpdateStateDescription(stateDescription3);
            Assert.AreEqual("test", repository.GetStateDescriptionByCode(stateDescription.Code).Location);
        }

        [TestMethod]
        public void RepositoryStateDescriptionDELTETest()
        {
            DataRepository repository = new DataRepository();
            StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            repository.AddStateDescription(stateDescription);
            repository.DeleteStateDescription(stateDescription);

            int count = 0;
            IEnumerator<object> enumerator = repository.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(0, count);
        }
        [TestMethod]
        public void RepositoryTransactionEnumeratorTest()
        {
            DataRepository repository = new DataRepository();
            Event transaction = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            repository.AddTransaction(transaction);

            int count = 0;
            IEnumerator<object> enumerator = repository.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);

            Event transaction2 = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            repository.AddTransaction(transaction2);

            count = 0;
            enumerator = repository.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RespositoryTransactionADDTest()
        {
            DataRepository repository = new DataRepository();
            Event transaction = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            repository.AddTransaction(transaction);
            Assert.AreEqual(transaction, repository.GetTransactionByCode(transaction.Code));

            IEnumerator<object> enumerator = repository.GetAllTransactions().GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(transaction, enumerator.Current);

            int count = 0;
            enumerator = repository.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void RepositoryTransactionUPDATETest()
        {
            DataRepository repository = new DataRepository();
            Event transaction = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            repository.AddTransaction(transaction);

            Event transaction2 = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            transaction2.Code = transaction.Code;
            repository.UpdateTransaction(transaction2);

            Assert.AreEqual(transaction2, repository.GetTransactionByCode(transaction2.Code));

            Event transaction3 = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            transaction3.Code = transaction.Code;
            transaction3.ReturnDate = System.DateTimeOffset.ParseExact("28/01/2017 20:00", "dd/MM/yyyy HH:mm", null);

            repository.UpdateTransaction(transaction3);
            Assert.AreEqual(System.DateTimeOffset.ParseExact("28/01/2017 20:00", "dd/MM/yyyy HH:mm", null), repository.GetTransactionByCode(transaction.Code).ReturnDate);
        }

        [TestMethod]
        public void RepositoryTransactionDELTETest()
        {
            DataRepository repository = new DataRepository();
            Event transaction = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            repository.AddTransaction(transaction);
            repository.DeleteTransaction(transaction);

            int count = 0;
            IEnumerator<object> enumerator = repository.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void RepositoryPersonAddMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 100; i++)
            {
                Person person = new Person("Name" + i.ToString(), "Surname" + i.ToString());
                persons.Add(person);
                dr.AddPerson(person);
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(persons[i], dr.GetPersonByCode(persons[i].Code));
            }

            int count = 0;
            IEnumerator<Person> enumerator = dr.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
        }

        [TestMethod]
        public void RepositoryPersonDeleteMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<Person> personsToRemove = new List<Person>();

            for (int i = 0; i < 100; i++)
            {
                Person person = new Person("Name" + i.ToString(), "Surname" + i.ToString());
                if (i % 9 == 0) personsToRemove.Add(person);
                dr.AddPerson(person);
            }

            int count = 0;
            foreach (Person person in personsToRemove)
            {
                count += 1;
                dr.DeletePerson(person);
            }

            foreach (Person person in personsToRemove)
            {
                Assert.IsNull(dr.GetPersonByCode(person.Code));
            }

            int count2 = 0;
            IEnumerator<Person> enumerator = dr.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count, count2);
        }

        [TestMethod]
        public void RepositoryPersonUpdateMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<Person> personsToUpdate = new List<Person>();

            for (int i = 0; i < 100; i++)
            {
                Person person = new Person("Name" + i.ToString(), "Surname" + i.ToString());
                if (i % 8 == 0) personsToUpdate.Add(person);
                dr.AddPerson(person);
            }

            int count = 0;
            foreach (Person person in personsToUpdate)
            {
                count += 1;
                person.Name = "test " + count;
                dr.UpdatePerson(person);
            }

            foreach (Person person in personsToUpdate)
            {
                Assert.AreEqual(person.Name, dr.GetPersonByCode(person.Code).Name);
            }

            count = 0;
            IEnumerator<Person> enumerator = dr.GetAllPersons().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
        }

        [TestMethod]
        public void RepositoryCatalogAddMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<Catalog> catalogs = new List<Catalog>();

            for (int i = 0; i < 100; i++)
            {
                Catalog catalog = new Catalog("Title "+i.ToString(), "Description "+i.ToString(), new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
                catalogs.Add(catalog);
                dr.AddCatalog(catalog);
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(catalogs[i], dr.GetCatalogByCode(catalogs[i].Code));
            }

            int count = 0;
            IEnumerator<KeyValuePair<long, Catalog>> enumerator = dr.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
        }

        [TestMethod]
        public void RepositoryCatalogDeleteMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<Catalog> catalogsToRemove = new List<Catalog>();

            for (int i = 0; i < 100; i++)
            {
                Catalog catalog = new Catalog("Title " + i.ToString(), "Description " + i.ToString(), new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
                if (i % 9 == 0) catalogsToRemove.Add(catalog);
                dr.AddCatalog(catalog);
            }

            int count = 0;
            foreach (Catalog catalog in catalogsToRemove)
            {
                count += 1;
                dr.DeleteCatalog(catalog);
            }

            foreach (Catalog catalog in catalogsToRemove)
            {
                Assert.IsNull(dr.GetCatalogByCode(catalog.Code));
            }

            int count2 = 0;
            IEnumerator<KeyValuePair<long, Catalog>> enumerator = dr.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count, count2);
        }

        [TestMethod]
        public void RepositoryCatalogUpdateMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<Catalog> catalogsToUpdate = new List<Catalog>();

            for (int i = 0; i < 100; i++)
            {
                Catalog catalog = new Catalog("Title " + i.ToString(), "Description " + i.ToString(), new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
                if (i % 8 == 0) catalogsToUpdate.Add(catalog);
                dr.AddCatalog(catalog);
            }

            int count = 0;
            foreach (Catalog catalog in catalogsToUpdate)
            {
                count += 1;
                catalog.Title = "test " + count;
                dr.UpdateCatalog(catalog);
            }

            foreach (Catalog catalog in catalogsToUpdate)
            {
                Assert.AreEqual(catalog.Title, dr.GetCatalogByCode(catalog.Code).Title);
            }

            count = 0;
            IEnumerator<KeyValuePair<long, Catalog>> enumerator = dr.GetAllCatalogs().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
        }
        [TestMethod]
        public void RepositoryStateDescriptionAddMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<StateDescription> stateDescriptions = new List<StateDescription>();

            for (int i = 0; i < 100; i++)
            {
                StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null).AddDays(i), "here");
                stateDescriptions.Add(stateDescription);
                dr.AddStateDescription(stateDescription);
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(stateDescriptions[i], dr.GetStateDescriptionByCode(stateDescriptions[i].Code));
            }

            int count = 0;
            IEnumerator<StateDescription> enumerator = dr.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
        }

        [TestMethod]
        public void RepositoryStateDescriptionDeleteMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<StateDescription> stateDescriptionsToRemove = new List<StateDescription>();

            for (int i = 0; i < 100; i++)
            {
                StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null).AddDays(i), "here");
                if (i % 9 == 0) stateDescriptionsToRemove.Add(stateDescription);
                dr.AddStateDescription(stateDescription);
            }

            int count = 0;
            foreach (StateDescription stateDescription in stateDescriptionsToRemove)
            {
                count += 1;
                dr.DeleteStateDescription(stateDescription);
            }

            foreach (StateDescription stateDescription in stateDescriptionsToRemove)
            {
                Assert.IsNull(dr.GetStateDescriptionByCode(stateDescription.Code));
            }

            int count2 = 0;
            IEnumerator<StateDescription> enumerator = dr.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count, count2);
        }

        [TestMethod]
        public void RepositoryStateDescriptionUpdateMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<StateDescription> stateDescriptionsToUpdate = new List<StateDescription>();

            for (int i = 0; i < 100; i++)
            {
                StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null).AddDays(i), "here");
                if (i % 8 == 0) stateDescriptionsToUpdate.Add(stateDescription);
                dr.AddStateDescription(stateDescription);
            }

            int count = 0;
            foreach (StateDescription stateDescription in stateDescriptionsToUpdate)
            {
                count += 1;
                stateDescription.Location = "test " + count;
                dr.UpdateStateDescription(stateDescription);
            }

            foreach (StateDescription stateDescription in stateDescriptionsToUpdate)
            {
                Assert.AreEqual(stateDescription.Location, dr.GetStateDescriptionByCode(stateDescription.Code).Location);
            }

            count = 0;
            IEnumerator<StateDescription> enumerator = dr.GetAllStateDescriptions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
        }
        [TestMethod]
        public void RepositoryTransactionAddMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<Event> transactions = new List<Event>();

            for (int i = 0; i < 100; i++)
            {
                Event transaction = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null).AddHours(i));
                transactions.Add(transaction);
                dr.AddTransaction(transaction);
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(transactions[i], dr.GetTransactionByCode(transactions[i].Code));
            }

            int count = 0;
            IEnumerator<Event> enumerator = dr.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
        }

        [TestMethod]
        public void RepositoryTransactionDeleteMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<Event> transactionsToRemove = new List<Event>();

            for (int i = 0; i < 100; i++)
            {
                Event transaction = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null).AddHours(i));
                if (i % 9 == 0) transactionsToRemove.Add(transaction);
                dr.AddTransaction(transaction);
            }

            int count = 0;
            foreach (Event transaction in transactionsToRemove)
            {
                count += 1;
                dr.DeleteTransaction(transaction);
            }

            foreach (Event transaction in transactionsToRemove)
            {
                Assert.IsNull(dr.GetTransactionByCode(transaction.Code));
            }

            int count2 = 0;
            IEnumerator<Event> enumerator = dr.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count2++;
            Assert.AreEqual(100 - count, count2);
        }

        [TestMethod]
        public void RepositoryTransactionUpdateMultipleTest()
        {
            DataRepository dr = new DataRepository();
            List<Event> transactionsToUpdate = new List<Event>();

            for (int i = 0; i < 100; i++)
            {
                Event transaction = new Event(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", new Author("Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null).AddHours(i));
                if (i % 8 == 0) transactionsToUpdate.Add(transaction);
                dr.AddTransaction(transaction);
            }

            int count = 0;
            foreach (Event transaction in transactionsToUpdate)
            {
                count += 1;
                transaction.ReturnDate = transaction.BorrowDate.AddDays(count);
                dr.UpdateTransaction(transaction);
            }

            foreach (Event transaction in transactionsToUpdate)
            {
                Assert.AreEqual(transaction.ReturnDate, dr.GetTransactionByCode(transaction.Code).ReturnDate);
            }

            count = 0;
            IEnumerator<Event> enumerator = dr.GetAllTransactions().GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.AreEqual(100, count);
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
            //Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.GetPersonByCode(person.Code));
            //repository.AddPerson(person);
            //Assert.AreEqual(person, repository.GetPersonByCode(person.Code));
            //repository.DeletePersonByIndex(0);
            //Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.GetPersonByCode(person.Code));
            //repository.AddPerson(person);
            //Assert.AreEqual(person, repository.GetPersonByCode(person.Code));
            //Assert.AreEqual(persons, null);
            //Assert.AreEqual(catalogs, null);

            //persons = repository.GetAllPersons();
            //catalogs = repository.GetAllCatalogs();

            //Assert.AreNotEqual(persons, null);
            //Assert.AreNotEqual(catalogs, null);

            //repository.DeletePerson(person);

            //Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.GetPersonByCode(person.Code));

            ////Catalog Collection
            //Assert.ThrowsException<KeyNotFoundException>(() => repository.GetCatalogByCode(catalog.Code));
            //repository.AddCatalog(catalog);
            //Assert.AreEqual(1, repository.CatalogKey);
            //Assert.AreEqual(catalog, repository.GetCatalogByCode(catalog.Code));
            //repository.DeleteCatalogByKey(0);
            //Assert.ThrowsException<KeyNotFoundException>(() => repository.GetCatalogByCode(catalog.Code));
        }
    }
}
