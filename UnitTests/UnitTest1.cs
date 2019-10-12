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
    }
}
