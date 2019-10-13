using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad1;

namespace UnitTests
{
    [TestClass]
    public class AtomicClassesTest
    {
        [TestMethod]
        public void AuthorConstructorTest()
        {
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            Author author = new Author(1, "Jane", "Austen", date);
            Assert.AreEqual(author.Code, 1);
            Assert.AreEqual(author.Name, "Jane");
            Assert.AreEqual(author.Surname, "Austen");
            Assert.AreEqual(author.DateOfBirth, date);
        }

        [TestMethod]
        public void CatalogConstructorTest()
        {
            Author author = new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null));
            Catalog catalog = new Catalog(1, "Pride and Prejudice", "This is description", author);
            Assert.AreEqual(1, catalog.Code);
            Assert.AreEqual("Pride and Prejudice", catalog.Title);
            Assert.AreEqual("This is description", catalog.Description);
            Assert.AreEqual(author, catalog.Author);
        }

        [TestMethod]
        public void PersonConstructorTest()
        {
            Person person = new Person(1, "Stan", "Peacock", "Michelles 42");
            Assert.AreEqual(1, person.Code);
            Assert.AreEqual("Stan", person.Name);
            Assert.AreEqual("Peacock", person.Surname);
            Assert.AreEqual("Michelles 42", person.Adress);
        }

        [TestMethod]
        public void StatedescriptionConstructorTest()
        {
            Author author = new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null));
            Catalog book = new Catalog(1, "Pride and Prejudice", "This is description", author);
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            StateDescription stateDescription = new StateDescription(1, book, date, "here");
            Assert.AreEqual(stateDescription.Code, 1);
            Assert.AreEqual(stateDescription.Book, book);
            Assert.AreEqual(stateDescription.PurchaseDate, date);
            Assert.AreEqual(stateDescription.Location, "here");
        }

        [TestMethod]
        public void EventConstructorTest()
        {
            Person person = new Person(1, "Mike", "Podolsky");
            Author author = new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null));
            Catalog catalog = new Catalog(1, "Pride and Prejudice", "This is description", author);
            StateDescription stateDescription = new StateDescription(1, catalog, System.DateTimeOffset.Now, "Here");
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            Event happening = new Event(1, person, stateDescription, date);
            Assert.AreEqual(1, happening.Code);
            Assert.AreEqual(person, happening.Causer);
            Assert.AreEqual(stateDescription, happening.BookState);
            Assert.AreEqual(date, happening.BorrowDate);
        }

        [TestMethod]
        public void EqualsPersonMethodTest()
        {
            Person person = new Person(1, "Stan", "Peacock", "Michelles 42");
            Person person2 = new Person(2, "Stan", "Peacock", "Michelles 42");
            Assert.AreNotEqual(person, person2);

            Person person3 = new Person(1, "Stanley", "Not", "No");
            Assert.AreEqual(person, person3);
        }

        [TestMethod]
        public void EqualsCatalogMethodTest()
        {
            Catalog catalog = new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            Catalog catalog2 = new Catalog(2, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null)));
            Assert.AreNotEqual(catalog, catalog2);

            Catalog catalog3 = new Catalog(1, "Different?", "Don't think so", new Author(32, "A", "B", System.DateTimeOffset.ParseExact("30/01/1813", "dd/MM/yyyy", null)));
            Assert.AreEqual(catalog, catalog3);
        }

        [TestMethod]
        public void EqualsStateDescriptionMethodTest()
        {
            StateDescription stateDescription = new StateDescription(1, new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            StateDescription stateDescription2 = new StateDescription(2, new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            Assert.AreNotEqual(stateDescription, stateDescription2);

            StateDescription stateDescription3 = new StateDescription(1, new Catalog(44, "Not okay", "Is it not?", new Author(3, "Me", "Is", System.DateTimeOffset.ParseExact("28/02/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            Assert.AreEqual(stateDescription, stateDescription3);
        }

        [TestMethod]
        public void EqualsEventMethodTest()
        {
            Event transaction = new Event(1, new Person(1, "Stan", "Peacock", "Michelles 42"), new StateDescription(1, new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            Event transaction2 = new Event(2, new Person(1, "Stan", "Peacock", "Michelles 42"), new StateDescription(1, new Catalog(1, "Pride and Prejudice", "This is description", new Author(1, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            Assert.AreNotEqual(transaction, transaction2);

            Event transaction3 = new Event(1, new Person(5, "Stanny", "Peachcock", "Sennelle 24"), new StateDescription(4, new Catalog(1, "Pride and Prejudice", "This is description", new Author(10, "Jane", "Austen", System.DateTimeOffset.ParseExact("28/01/1813", "dd/MM/yyyy", null))), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            Assert.AreEqual(transaction, transaction3);
        }
    }
}
