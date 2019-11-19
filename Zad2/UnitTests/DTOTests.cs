using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace UnitTests
{
    [TestClass]
    public class AtomicClassesTest
    {

        [TestMethod]
        public void CatalogConstructorTest()
        {
            string author = "Jane Austen";
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", author);
            Catalog catalog2 = new Catalog("Pride and Prejudice", "This is description", author);
            Assert.AreNotEqual(catalog2.Code, catalog.Code);
            Assert.AreEqual("Pride and Prejudice", catalog.Title);
            Assert.AreEqual("This is description", catalog.Description);
            Assert.AreEqual(author, catalog.Author);
        }

        [TestMethod]
        public void PersonConstructorTest()
        {
            Person person = new Person("Stan", "Peacock", "Michelles 42");
            Person person2 = new Person("Stan", "Peacock", "Michelles 42");
            Assert.AreNotEqual(person2.Code, person.Code);
            Assert.AreEqual("Stan", person.Name);
            Assert.AreEqual("Peacock", person.Surname);
            Assert.AreEqual("Michelles 42", person.Adress);
        }

        [TestMethod]
        public void StatedescriptionConstructorTest()
        {
            string author = "Jane Austen";
            Catalog book = new Catalog("Pride and Prejudice", "This is description", author);
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            StateDescription stateDescription = new StateDescription(book, date, "here");
            StateDescription stateDescription2 = new StateDescription(book, date, "here");
            Assert.AreNotEqual(stateDescription.Code, stateDescription2.Code);
            Assert.AreEqual(stateDescription.Book, book);
            Assert.AreEqual(stateDescription.PurchaseDate, date);
            Assert.AreEqual(stateDescription.Location, "here");
        }

        [TestMethod]
        public void EventConstructorTest()
        {
            Person person = new Person("Mike", "Podolsky");
            string author = "Jane Austen";
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", author);
            StateDescription stateDescription = new StateDescription(catalog, System.DateTimeOffset.Now, "Here");
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            Event happening = new BorrowEvent(person, stateDescription, date);
            Event happening2 = new BorrowEvent(person, stateDescription, date);
            Assert.AreNotEqual(happening2.Code, happening.Code);
            Assert.AreEqual(person, happening.Causer);
            Assert.AreEqual(stateDescription, happening.BookState);
            Assert.AreEqual(date, happening.Date);
        }

        [TestMethod]
        public void EqualsPersonMethodTest()
        {
            Person person = new Person("Stan", "Peacock", "Michelles 42");
            Person person2 = new Person("Stan", "Peacock", "Michelles 42");
            Assert.AreNotEqual(person, person2);

            Person person3 = new Person("Stanley", "Not", "No");
            person3.Code = person.Code;
            Assert.AreEqual(person, person3);
        }

        [TestMethod]
        public void EqualsCatalogMethodTest()
        {
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", "Jane Austen");
            Catalog catalog2 = new Catalog("Pride and Prejudice", "This is description", "Jane Austen");
            Assert.AreNotEqual(catalog, catalog2);

            Catalog catalog3 = new Catalog("Different?", "Don't think so", "A B");
            catalog3.Code = catalog.Code;
            Assert.AreEqual(catalog, catalog3);
        }

        [TestMethod]
        public void EqualsStateDescriptionMethodTest()
        {
            StateDescription stateDescription = new StateDescription(new Catalog("Pride and Prejudice", "This is description", "Jane Austen"), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            StateDescription stateDescription2 = new StateDescription(new Catalog("Pride and Prejudice", "This is description", "Jane Austen"), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            Assert.AreNotEqual(stateDescription, stateDescription2);

            StateDescription stateDescription3 = new StateDescription(new Catalog("Not okay", "Is it not?", "Not her"), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here");
            stateDescription3.Code = stateDescription.Code;
            Assert.AreEqual(stateDescription, stateDescription3);
        }

        [TestMethod]
        public void EqualsEventMethodTest()
        {
            Event transaction = new BorrowEvent(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", "Jane Austen"), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            Event transaction2 = new BorrowEvent(new Person("Stan", "Peacock", "Michelles 42"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", "Jane Austen"), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            Assert.AreNotEqual(transaction, transaction2);

            Event transaction3 = new BorrowEvent(new Person("Stanny", "Peachcock", "Sennelle 24"), new StateDescription(new Catalog("Pride and Prejudice", "This is description", "Jane Austen"), System.DateTimeOffset.ParseExact("28/01/2019", "dd/MM/yyyy", null), "here"), System.DateTimeOffset.ParseExact("28/01/2019 21:37", "dd/MM/yyyy HH:mm", null));
            transaction3.Code = transaction.Code;
            Assert.AreEqual(transaction, transaction3);
        }

        [TestMethod]
        public void CatalogClonableTest()
        {
            string author = "Jane Austen";
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", author);
            Catalog catalog2 = (Catalog)catalog.Clone();
            Assert.AreEqual(catalog, catalog2);
            Assert.AreNotSame(catalog, catalog2);
        }

        [TestMethod]
        public void PersonClonableTest()
        {
            Person person = new Person("Stan", "Peacock", "Michelles 42");
            Person person2 = (Person)person.Clone();
            Assert.AreEqual(person, person2);
            Assert.AreNotSame(person, person2);
        }

        [TestMethod]
        public void StatedescriptionClonableTest()
        {
            string author = "Jane Austen";
            Catalog book = new Catalog("Pride and Prejudice", "This is description", author);
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            StateDescription stateDescription = new StateDescription(book, date, "here");
            StateDescription stateDescription2 = (StateDescription)stateDescription.Clone();
            Assert.AreEqual(stateDescription, stateDescription2);
            Assert.AreNotSame(stateDescription, stateDescription2);
        }

        [TestMethod]
        public void EventClonableTest()
        {
            Person person = new Person("Mike", "Podolsky");
            string author = "Jane Austen";
            Catalog catalog = new Catalog("Pride and Prejudice", "This is description", author);
            StateDescription stateDescription = new StateDescription(catalog, System.DateTimeOffset.Now, "Here");
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            BorrowEvent happening = new BorrowEvent(person, stateDescription, date);
            BorrowEvent happening2 = (BorrowEvent)happening.Clone();
            Assert.AreEqual(happening, happening2);
            Assert.AreNotSame(happening, happening2);
        }


    }
}
