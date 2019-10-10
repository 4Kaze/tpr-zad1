using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad1;

namespace UnitTests
{
    [TestClass]
    public class AtomicClassesTest
    {

        [TestMethod]
        public void CatalogConstructorTest()
        {
            Author author = new Author(1, "Jane", "Austen", System.DateTimeOffset.Parse("1/28/1813"));
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
        public void HappeningConstructorTest()
        {
            Person person = new Person(1, "Mike", "Podolsky");
            Author author = new Author(1, "Jane", "Austen", System.DateTimeOffset.Parse("1/28/1813"));
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
