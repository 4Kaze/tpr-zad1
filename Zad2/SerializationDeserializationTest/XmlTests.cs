using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestClasses;
using TestClasses.Serialization;

namespace SerializationDeserializationTest
{
    [TestClass]
    public class XmlTests
    {
        [TestMethod]
        public void SimpleXMLSerializationTest_ExampleA_null()
        {
            ExampleXmlA a = new ExampleXmlA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);

            XmlSerializationHelper<ExampleXmlA>.Serialize("xml-A-test.xml", a);
            ExampleXmlA desA = XmlSerializationHelper<ExampleXmlA>.Deserilize("xml-A-test.xml");

            Assert.AreEqual(a.FloatTest, desA.FloatTest);
            Assert.AreEqual(a.StringTest, desA.StringTest);
            Assert.AreEqual(a.DateTest, desA.DateTest);
        }


        [TestMethod]
        public void SimpleXMLSerializationTest_ExampleB_null()
        {
            ExampleXmlB b = new ExampleXmlB(1.0f, "testB", new DateTime(1998, 12, 1, 0, 0, 0), null);

            XmlSerializationHelper<ExampleXmlB>.Serialize("xml-B-test.xml", b);
            ExampleXmlB desB = XmlSerializationHelper<ExampleXmlB>.Deserilize("xml-B-test.xml");

            Assert.AreEqual(b.FloatTest, desB.FloatTest);
            Assert.AreEqual(b.StringTest, desB.StringTest);
            Assert.AreEqual(b.DateTest, desB.DateTest);
        }


        [TestMethod]
        public void SimpleXMLSerializationTest_ExampleC_null()
        {
            ExampleXmlC c = new ExampleXmlC(1.0f, "testC", new DateTime(1998, 12, 1, 0, 0, 0), null);

            XmlSerializationHelper<ExampleXmlC>.Serialize("xml-C-test.xml", c);
            ExampleXmlC desC = XmlSerializationHelper<ExampleXmlC>.Deserilize("xml-C-test.xml");

            Assert.AreEqual(c.FloatTest, desC.FloatTest);
            Assert.AreEqual(c.StringTest, desC.StringTest);
            Assert.AreEqual(c.DateTest, desC.DateTest);
        }


        [TestMethod]
        public void SimpleXMLSerializationTest_ExampleA_not_null()
        {
            ExampleXmlA a = new ExampleXmlA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
            ExampleXmlB b = new ExampleXmlB(2.0f, "testB", new DateTime(1999, 11, 2, 0, 0, 0), null);
            ExampleXmlC c = new ExampleXmlC(3.0f, "testC", new DateTime(2000, 10, 3, 0, 0, 0), null);

            a.Reference = b;
            b.Reference = c;
            c.Reference = a;

            XmlSerializationHelper<ExampleXmlA>.Serialize("xml-A-test-reference.xml", a);
            ExampleXmlA desA = XmlSerializationHelper<ExampleXmlA>.Deserilize("xml-A-test-reference.xml");

            Assert.AreEqual(a.FloatTest, desA.FloatTest);
            Assert.AreEqual(a.StringTest, desA.StringTest);
            Assert.AreEqual(a.DateTest, desA.DateTest);

            Assert.AreEqual(a.Reference.FloatTest, desA.Reference.FloatTest);
            Assert.AreEqual(a.Reference.StringTest, desA.Reference.StringTest);
            Assert.AreEqual(a.Reference.DateTest, desA.Reference.DateTest);

            Assert.AreEqual(a.Reference.Reference.FloatTest, desA.Reference.Reference.FloatTest);
            Assert.AreEqual(a.Reference.Reference.StringTest, desA.Reference.Reference.StringTest);
            Assert.AreEqual(a.Reference.Reference.DateTest, desA.Reference.Reference.DateTest);

            Assert.AreEqual(a.Reference.Reference.Reference.FloatTest, desA.Reference.Reference.Reference.FloatTest);
            Assert.AreEqual(a.Reference.Reference.Reference.StringTest, desA.Reference.Reference.Reference.StringTest);
            Assert.AreEqual(a.Reference.Reference.Reference.DateTest, desA.Reference.Reference.Reference.DateTest);
        }


        [TestMethod]
        public void SimpleXMLSerializationTest_ExampleB_not_null()
        {
            ExampleXmlA a = new ExampleXmlA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
            ExampleXmlB b = new ExampleXmlB(2.0f, "testB", new DateTime(1999, 11, 2, 0, 0, 0), null);
            ExampleXmlC c = new ExampleXmlC(3.0f, "testC", new DateTime(2000, 10, 3, 0, 0, 0), null);

            a.Reference = b;
            b.Reference = c;
            c.Reference = a;

            XmlSerializationHelper<ExampleXmlB>.Serialize("xml-B-test-reference.xml", b);
            ExampleXmlB desB = XmlSerializationHelper<ExampleXmlB>.Deserilize("xml-B-test-reference.xml");

            Assert.AreEqual(b.FloatTest, desB.FloatTest);
            Assert.AreEqual(b.StringTest, desB.StringTest);
            Assert.AreEqual(b.DateTest, desB.DateTest);

            Assert.AreEqual(b.Reference.FloatTest, desB.Reference.FloatTest);
            Assert.AreEqual(b.Reference.StringTest, desB.Reference.StringTest);
            Assert.AreEqual(b.Reference.DateTest, desB.Reference.DateTest);

            Assert.AreEqual(b.Reference.Reference.FloatTest, desB.Reference.Reference.FloatTest);
            Assert.AreEqual(b.Reference.Reference.StringTest, desB.Reference.Reference.StringTest);
            Assert.AreEqual(b.Reference.Reference.DateTest, desB.Reference.Reference.DateTest);

            Assert.AreEqual(b.Reference.Reference.Reference.FloatTest, desB.Reference.Reference.Reference.FloatTest);
            Assert.AreEqual(b.Reference.Reference.Reference.StringTest, desB.Reference.Reference.Reference.StringTest);
            Assert.AreEqual(b.Reference.Reference.Reference.DateTest, desB.Reference.Reference.Reference.DateTest);
        }


        [TestMethod]
        public void SimpleXMLSerializationTest_ExampleC_not_null()
        {
            ExampleXmlA a = new ExampleXmlA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
            ExampleXmlB b = new ExampleXmlB(2.0f, "testB", new DateTime(1999, 11, 2, 0, 0, 0), null);
            ExampleXmlC c = new ExampleXmlC(3.0f, "testC", new DateTime(2000, 10, 3, 0, 0, 0), null);

            a.Reference = b;
            b.Reference = c;
            c.Reference = a;

            XmlSerializationHelper<ExampleXmlC>.Serialize("xml-C-test-reference.xml", c);
            ExampleXmlC desC = XmlSerializationHelper<ExampleXmlC>.Deserilize("xml-C-test-reference.xml");

            Assert.AreEqual(c.FloatTest, desC.FloatTest);
            Assert.AreEqual(c.StringTest, desC.StringTest);
            Assert.AreEqual(c.DateTest, desC.DateTest);

            Assert.AreEqual(c.Reference.FloatTest, desC.Reference.FloatTest);
            Assert.AreEqual(c.Reference.StringTest, desC.Reference.StringTest);
            Assert.AreEqual(c.Reference.DateTest, desC.Reference.DateTest);

            Assert.AreEqual(c.Reference.Reference.FloatTest, desC.Reference.Reference.FloatTest);
            Assert.AreEqual(c.Reference.Reference.StringTest, desC.Reference.Reference.StringTest);
            Assert.AreEqual(c.Reference.Reference.DateTest, desC.Reference.Reference.DateTest);

            Assert.AreEqual(c.Reference.Reference.Reference.FloatTest, desC.Reference.Reference.Reference.FloatTest);
            Assert.AreEqual(c.Reference.Reference.Reference.StringTest, desC.Reference.Reference.Reference.StringTest);
            Assert.AreEqual(c.Reference.Reference.Reference.DateTest, desC.Reference.Reference.Reference.DateTest);
        }
    }
}
