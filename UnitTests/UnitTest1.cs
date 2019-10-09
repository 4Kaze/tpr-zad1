using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad1;

namespace UnitTests
{
    [TestClass]
    public class AtomicClassesTest
    {
        [TestMethod]
        public void CatalogTest()
        {
            Catalog catalog = new Catalog("N1", "Pride and Prejudice");
            Assert.AreEqual("N1", catalog.Code);
            Assert.AreEqual("Pride and Prejudice", catalog.ProductName);
            Assert.AreEqual(catalog.Details, "");
            catalog.Details = "Informacja";
            Assert.AreEqual(catalog.Details, "Informacja");
        }

        [TestMethod]
        public void ClientTest()
        {
            Client client1 = new Client("C1", "Stan", "Peacock", "Michelles 42");
            Assert.AreEqual("C1", client1.Code);
            Assert.AreEqual("Stan", client1.Name);
            Assert.AreEqual("Peacock", client1.Surname);
            Assert.AreEqual("Michelles 42", client1.Adress);
            client1.Adress = "St Johnson 12";
            Assert.AreEqual("St Johnson 12", client1.Adress);

            Client client2 = new Client("C2", "Mike", "Podolsky");
            Assert.AreEqual("C2", client2.Code);
            Assert.AreEqual("Mike", client2.Name);
            Assert.AreEqual("Podolsky", client2.Surname);
            Assert.AreEqual("", client2.Adress);
            client2.Adress = "St Leslie 2";
            Assert.AreEqual("St Leslie 2", client2.Adress);
        }
    }
}
