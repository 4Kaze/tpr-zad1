using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using Classes.Serialization;
using System.Runtime.Serialization;

namespace TestsOfSerializations
{
    [TestClass]
    public class OwnSerializationTest
    {
        [TestMethod]
        public void SerilizeDeserializeCheck()
        {
            OwnSerialization own = new OwnSerialization();

            DataContext dataContext = new DataContext();
            DataContext deserializedContext = new DataContext();
            FillSerialization fillConstant = new FillSerialization();
            fillConstant.FillData(dataContext);

            own.Serialize(dataContext);
            deserializedContext = own.Deserialize();
            Assert.AreEqual(dataContext.Clients[0].ToString(), deserializedContext.Clients[0].ToString());
        }


        [TestMethod]
        public void SerializePerson()
        {
            ObjectIDGenerator objectID = new ObjectIDGenerator();
            OwnSerialization own = new OwnSerialization();
            DataContext dataContext = new DataContext();
            Person person1 = new Person("Marcus", "Sagthon", "Michelles 42");

            dataContext.Clients.Add(person1);

            string test = own.PrepareSerialization(dataContext, objectID);
            string testEquals = "Classes.Person;1;0;Marcus;Sagthon;Michelles 42;" + "\n";

            Assert.AreEqual(testEquals, test);
        }


        [TestMethod]
        public void SerializeCatalog()
        {
            ObjectIDGenerator objectID = new ObjectIDGenerator();
            OwnSerialization own = new OwnSerialization();
            DataContext dataContext = new DataContext();
            Catalog catalog1 = new Catalog("Pride and Prejudice", "This is description1", "Jane Austen");
            catalog1.Code = 1;

            dataContext.Books.Add(catalog1.Code, catalog1);

            string test = own.PrepareSerialization(dataContext, objectID);
            string testEquals = "Classes.Catalog;1;1;Pride and Prejudice;This is description1;Jane Austen;" + "\n";

            Assert.AreEqual(testEquals, test);
        }


        [TestMethod]
        public void SerializeDescription()
        {
            ObjectIDGenerator objectID = new ObjectIDGenerator();
            OwnSerialization own = new OwnSerialization();
            DataContext dataContext = new DataContext();

            System.DateTimeOffset date = System.DateTimeOffset.Now;

            Catalog catalog1 = new Catalog("Pride and Prejudice", "This is description1", "Jane Austen");
            StateDescription stateDescription1 = new StateDescription(catalog1, date, "Somewhere");

            catalog1.Code = 1;
            stateDescription1.Code = 1;

            dataContext.Books.Add(catalog1.Code, catalog1);
            dataContext.Descriptions.Add(stateDescription1);

            string test = own.PrepareSerialization(dataContext, objectID);
            string testEquals = "Classes.Catalog;1;1;Pride and Prejudice;This is description1;Jane Austen;" + "\n" 
                                + "Classes.StateDescription;2;1;1;True;" + date + ";Somewhere;" + "\n";

            Assert.AreEqual(testEquals, test);
        }


        [TestMethod]
        public void SerializeTransaction()
        {
            ObjectIDGenerator objectID = new ObjectIDGenerator();
            OwnSerialization own = new OwnSerialization();
            DataContext dataContext = new DataContext();

            System.DateTimeOffset date = System.DateTimeOffset.Now;

            Person person1 = new Person("Marcus", "Sagthon", "Michelles 42");
            Catalog catalog1 = new Catalog("Pride and Prejudice", "This is description1", "Jane Austen");
            StateDescription stateDescription1 = new StateDescription(catalog1, date, "Somewhere");
            Event happening1 = new BorrowEvent(person1, stateDescription1, date);


            person1.Code = 1;
            catalog1.Code = 1;
            stateDescription1.Code = 1;
            happening1.Code = 1;

            dataContext.Clients.Add(person1);
            dataContext.Books.Add(catalog1.Code, catalog1);
            dataContext.Descriptions.Add(stateDescription1);
            dataContext.Transactions.Add(happening1);


            string test = own.PrepareSerialization(dataContext, objectID);
            string testEquals = "Classes.Person;1;1;Marcus;Sagthon;Michelles 42;" + "\n"
                                + "Classes.Catalog;2;1;Pride and Prejudice;This is description1;Jane Austen;" + "\n"
                                + "Classes.StateDescription;3;1;2;True;" + date + ";Somewhere;" + "\n"
                                + "Classes.BorrowEvent;4;1;1;3;" + date + ";" + "\n";

            Assert.AreEqual(testEquals, test);
        }


        [TestMethod]
        public void Example()
        {

        }
    }
}
