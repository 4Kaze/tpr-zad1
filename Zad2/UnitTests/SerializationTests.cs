using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializationModule;
using System.IO;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class OwnSerializationTests
    {
        [TestMethod]
        public void PersonSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Person p = new Person("Jan", "Kowalski");
            Person p2 = new Person("Anna", "Zdynska", "papaja 12");
            dataContext.Clients.Add(p);
            dataContext.Clients.Add(p2);

            ISerializator serializer = new OwnSerialization();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(dataContext, ms);
            ms.Position = 0;
            DataContext deserializedContext = serializer.Deserialize(ms);

            Assert.AreEqual(deserializedContext.Clients[0], p);
            Assert.AreEqual(deserializedContext.Clients[1], p2);
        }

        [TestMethod]
        public void CatalogSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Catalog c = new Catalog("Coś", "tam", "jest");
            Catalog c2 = new Catalog("Bla", "bla", "Car");
            dataContext.Books.Add(0, c);
            dataContext.Books.Add(1, c2);

            ISerializator serializer = new OwnSerialization();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(dataContext, ms);
            ms.Position = 0;
            DataContext deserializedContext = serializer.Deserialize(ms);

            Assert.AreEqual(deserializedContext.Books[0], c);
            Assert.AreEqual(deserializedContext.Books[1], c2);
        }

        [TestMethod]
        public void StateDescSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Person p = new Person("Jan", "Kowalski");
            Person p2 = new Person("Anna", "Zdynska", "papaja 12");

            Catalog c = new Catalog("Coś", "tam", "jest");
            Catalog c2 = new Catalog("Bla", "bla", "Car");

            StateDescription sd = new StateDescription(c, System.DateTimeOffset.Now, "Here");
            StateDescription sd2 = new StateDescription(c2, System.DateTimeOffset.Now, "There");

            dataContext.Books.Add(0, c);
            dataContext.Books.Add(1, c2);
            dataContext.Descriptions.Add(sd);
            dataContext.Descriptions.Add(sd2);

            ISerializator serializer = new OwnSerialization();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(dataContext, ms);
            ms.Position = 0;
            DataContext deserializedContext = serializer.Deserialize(ms);

            Assert.AreEqual(deserializedContext.Descriptions[0], sd);
            Assert.AreEqual(deserializedContext.Descriptions[1], sd2);
            Assert.AreEqual(deserializedContext.Descriptions[0].Book, c);
            Assert.AreEqual(deserializedContext.Descriptions[1].Book, c2);
        }

        [TestMethod]
        public void EventSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Person p = new Person("Jan", "Kowalski");
            Person p2 = new Person("Anna", "Zdynska", "papaja 12");

            Catalog c = new Catalog("Coś", "tam", "jest");

            StateDescription sd = new StateDescription(c, System.DateTimeOffset.Now, "Here");

            Event e = new BorrowEvent(p, sd, System.DateTimeOffset.Now);
            Event e2 = new ReturnEvent(p, sd, System.DateTimeOffset.Now);
            Event e3 = new BorrowEvent(p2, sd, System.DateTimeOffset.Now);

            dataContext.Clients.Add(p);
            dataContext.Clients.Add(p2);
            dataContext.Books.Add(0, c);
            dataContext.Descriptions.Add(sd);
            dataContext.Transactions.Add(e);
            dataContext.Transactions.Add(e2);
            dataContext.Transactions.Add(e3);

            ISerializator serializer = new OwnSerialization();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(dataContext, ms);
            ms.Position = 0;
            DataContext deserializedContext = serializer.Deserialize(ms);

            Assert.AreEqual(deserializedContext.Transactions[0], e);
            Assert.AreEqual(deserializedContext.Transactions[1], e2);
            Assert.AreEqual(deserializedContext.Transactions[2], e3);

            Assert.AreEqual(deserializedContext.Transactions[0].Causer, p);
            Assert.AreEqual(deserializedContext.Transactions[1].Causer, p);
            Assert.AreEqual(deserializedContext.Transactions[2].Causer, p2);

            Assert.AreEqual(deserializedContext.Transactions[0].BookState, sd);

            Assert.AreSame(deserializedContext.Transactions[0].Causer, deserializedContext.Transactions[1].Causer);
            Assert.AreSame(deserializedContext.Transactions[0].BookState, deserializedContext.Transactions[1].BookState);
            Assert.AreSame(deserializedContext.Transactions[1].BookState, deserializedContext.Transactions[2].BookState);
        }
    }


    [TestClass]
    public class BinarySerializationTests
    {
        [TestMethod]
        public void PersonSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Person p = new Person("Jan", "Kowalski");
            Person p2 = new Person("Anna", "Zdynska", "papaja 12");
            dataContext.Clients.Add(p);
            dataContext.Clients.Add(p2);

            ISerializator serializer = new OwnSerialization();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(dataContext, ms);
            ms.Position = 0;
            DataContext deserializedContext = serializer.Deserialize(ms);

            Assert.AreEqual(deserializedContext.Clients[0], p);
            Assert.AreEqual(deserializedContext.Clients[1], p2);
        }

        [TestMethod]
        public void CatalogSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Catalog c = new Catalog("Coś", "tam", "jest");
            Catalog c2 = new Catalog("Bla", "bla", "Car");
            dataContext.Books.Add(0, c);
            dataContext.Books.Add(1, c2);

            ISerializator serializer = new OwnSerialization();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(dataContext, ms);
            ms.Position = 0;
            DataContext deserializedContext = serializer.Deserialize(ms);

            Assert.AreEqual(deserializedContext.Books[0], c);
            Assert.AreEqual(deserializedContext.Books[1], c2);
        }

        [TestMethod]
        public void StateDescSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Person p = new Person("Jan", "Kowalski");
            Person p2 = new Person("Anna", "Zdynska", "papaja 12");

            Catalog c = new Catalog("Coś", "tam", "jest");
            Catalog c2 = new Catalog("Bla", "bla", "Car");

            StateDescription sd = new StateDescription(c, System.DateTimeOffset.Now, "Here");
            StateDescription sd2 = new StateDescription(c2, System.DateTimeOffset.Now, "There");

            dataContext.Books.Add(0, c);
            dataContext.Books.Add(1, c2);
            dataContext.Descriptions.Add(sd);
            dataContext.Descriptions.Add(sd2);

            ISerializator serializer = new OwnSerialization();

            MemoryStream ms = new MemoryStream(1000);
            serializer.Serialize(dataContext, ms);
            ms.Position = 0;
            DataContext deserializedContext = serializer.Deserialize(ms);

            Assert.AreEqual(deserializedContext.Descriptions[0], sd);
            Assert.AreEqual(deserializedContext.Descriptions[1], sd2);
            Assert.AreEqual(deserializedContext.Descriptions[0].Book, c);
            Assert.AreEqual(deserializedContext.Descriptions[1].Book, c2);
        }

        [TestMethod]
        public void EventSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Person p = new Person("Jan", "Kowalski");
            Person p2 = new Person("Anna", "Zdynska", "papaja 12");

            Catalog c = new Catalog("Coś", "tam", "jest");

            StateDescription sd = new StateDescription(c, System.DateTimeOffset.Now, "Here");

            Event e = new BorrowEvent(p, sd, System.DateTimeOffset.Now);
            Event e2 = new ReturnEvent(p, sd, System.DateTimeOffset.Now);
            Event e3 = new BorrowEvent(p2, sd, System.DateTimeOffset.Now);

            dataContext.Clients.Add(p);
            dataContext.Clients.Add(p2);
            dataContext.Books.Add(0, c);
            dataContext.Descriptions.Add(sd);
            dataContext.Transactions.Add(e);
            dataContext.Transactions.Add(e2);
            dataContext.Transactions.Add(e3);

            ISerializator serializer = new OwnSerialization();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(dataContext, ms);
            ms.Position = 0;
            DataContext deserializedContext = serializer.Deserialize(ms);

            Assert.AreEqual(deserializedContext.Transactions[0], e);
            Assert.AreEqual(deserializedContext.Transactions[1], e2);
            Assert.AreEqual(deserializedContext.Transactions[2], e3);

            Assert.AreEqual(deserializedContext.Transactions[0].Causer, p);
            Assert.AreEqual(deserializedContext.Transactions[1].Causer, p);
            Assert.AreEqual(deserializedContext.Transactions[2].Causer, p2);

            Assert.AreEqual(deserializedContext.Transactions[0].BookState, sd);

            Assert.AreSame(deserializedContext.Transactions[0].Causer, deserializedContext.Transactions[1].Causer);
            Assert.AreSame(deserializedContext.Transactions[0].BookState, deserializedContext.Transactions[1].BookState);
            Assert.AreSame(deserializedContext.Transactions[1].BookState, deserializedContext.Transactions[2].BookState);
        }
    }


    [TestClass]
    public class RecursionSerializationTests
    {

        [TestMethod]
        public void RecursionSerializationTest()
        {
            DataContext dataContext = new DataContext();
            Person p = new Person("Jan", "Kowalski");
            Person p2 = new Person("Anna", "Zdynska", "papaja 12");

            Catalog c = new Catalog("Coś", "tam", "jest");
            Catalog c2 = new Catalog("A", "B", "C");
            Catalog c3 = new Catalog("D", "E", "F");

            StateDescription sd = new StateDescription(c, System.DateTimeOffset.Now, "Here");
            StateDescription sd2 = new StateDescription(c2, System.DateTimeOffset.Now, "There");
            StateDescription sd3 = new StateDescription(c3, System.DateTimeOffset.Now, "Somewhere");

            p.Books.Add(sd);
            p.Books.Add(sd2);
            p2.Books.Add(sd3);

            sd.Owner = p;
            sd2.Owner = p;
            sd3.Owner = p2;

            dataContext.Clients.Add(p);
            dataContext.Clients.Add(p2);
            dataContext.Books.Add(1, c);
            dataContext.Books.Add(2, c2);
            dataContext.Books.Add(3, c3);
            dataContext.Descriptions.Add(sd);
            dataContext.Descriptions.Add(sd2);
            dataContext.Descriptions.Add(sd3);

            ISerializator serializer = new OwnSerialization();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(dataContext, ms);
            ms.Position = 0;
            DataContext deserializedContext = serializer.Deserialize(ms);

            Assert.AreEqual(deserializedContext.Clients[0], p);
            Assert.AreEqual(deserializedContext.Clients[1], p2);

            Assert.AreEqual(deserializedContext.Books[1], c);
            Assert.AreEqual(deserializedContext.Books[2], c2);
            Assert.AreEqual(deserializedContext.Books[3], c3);

            Assert.AreEqual(deserializedContext.Descriptions[0], sd);
            Assert.AreEqual(deserializedContext.Descriptions[1], sd2);
            Assert.AreEqual(deserializedContext.Descriptions[2], sd3);

            Assert.AreSame(deserializedContext.Clients[0], deserializedContext.Descriptions[0].Owner);
            Assert.AreSame(deserializedContext.Clients[0], deserializedContext.Descriptions[1].Owner);
            Assert.AreSame(deserializedContext.Clients[1], deserializedContext.Descriptions[2].Owner);

            Assert.AreSame(deserializedContext.Clients[0].Books[0], deserializedContext.Descriptions[0]);
            Assert.AreSame(deserializedContext.Clients[0].Books[1], deserializedContext.Descriptions[1]);
            Assert.AreSame(deserializedContext.Clients[1].Books[0], deserializedContext.Descriptions[2]);
        }
    }
}
