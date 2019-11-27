using System;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestClasses;
using TestClasses.Serialization;

namespace SerializationDeserializationTest
{
    [TestClass]
    public class OwnSerializationTests
    {
        [TestMethod]
        public void TestNullReferenceSerializationDeserializationA()
        {
            ExampleA a = new ExampleA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);

            MemoryStream ms = new MemoryStream();
            IFormatter formatter = new StringFormatter(new StringBinder());
            formatter.Serialize(ms, a);

            ExampleA deserializedA = (ExampleA)formatter.Deserialize(new MemoryStream(ms.ToArray()));

            Assert.AreEqual(a.FloatTest, deserializedA.FloatTest);
            Assert.AreEqual(a.StringTest, deserializedA.StringTest);
            Assert.AreEqual(a.DateTest, deserializedA.DateTest);
        }

        [TestMethod]
        public void TestCycleSerializationDeserializationA()
        {
            ExampleA a_own = new ExampleA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
            ExampleB b_own = new ExampleB(2.0f, "testB", new DateTime(1999, 11, 2, 0, 0, 0), null);
            ExampleC c_own = new ExampleC(3.0f, "testC", new DateTime(2000, 10, 3, 0, 0, 0), null);

            a_own.Reference = b_own;
            b_own.Reference = c_own;
            c_own.Reference = a_own;

            MemoryStream ms = new MemoryStream();

            IFormatter formatter = new StringFormatter(new StringBinder());
            formatter.Serialize(ms, a_own);
            
            ExampleA deserializedA = (ExampleA)formatter.Deserialize(new MemoryStream(ms.ToArray()));

            Assert.AreEqual(a_own.FloatTest, deserializedA.FloatTest);
            Assert.AreEqual(a_own.StringTest, deserializedA.StringTest);
            Assert.AreEqual(a_own.DateTest, deserializedA.DateTest);

            Assert.AreEqual(a_own.Reference.FloatTest, deserializedA.Reference.FloatTest);
            Assert.AreEqual(a_own.Reference.StringTest, deserializedA.Reference.StringTest);
            Assert.AreEqual(a_own.Reference.DateTest, deserializedA.Reference.DateTest);

            Assert.AreEqual(a_own.Reference.Reference.FloatTest, deserializedA.Reference.Reference.FloatTest);
            Assert.AreEqual(a_own.Reference.Reference.StringTest, deserializedA.Reference.Reference.StringTest);
            Assert.AreEqual(a_own.Reference.Reference.DateTest, deserializedA.Reference.Reference.DateTest);

            Assert.AreSame(deserializedA, deserializedA.Reference.Reference.Reference);
            Assert.AreSame(deserializedA.Reference, deserializedA.Reference.Reference.Reference.Reference);
            Assert.AreSame(deserializedA.Reference.Reference, deserializedA.Reference.Reference.Reference.Reference.Reference);

        }

        [TestMethod]
        public void TestNullReferenceSerializationDeserializationB()
        {
            ExampleB b = new ExampleB(1.0f, "testB", new DateTime(1998, 12, 1, 0, 0, 0), null);

            MemoryStream ms = new MemoryStream();
            IFormatter formatter = new StringFormatter(new StringBinder());
            formatter.Serialize(ms, b);

            ExampleB deserializedB = (ExampleB)formatter.Deserialize(new MemoryStream(ms.ToArray()));

            Assert.AreEqual(b.FloatTest, deserializedB.FloatTest);
            Assert.AreEqual(b.StringTest, deserializedB.StringTest);
            Assert.AreEqual(b.DateTest, deserializedB.DateTest);
        }

        [TestMethod]
        public void TestCycleSerializationDeserializationB()
        {
            ExampleA a_own = new ExampleA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
            ExampleB b_own = new ExampleB(2.0f, "testB", new DateTime(1999, 11, 2, 0, 0, 0), null);
            ExampleC c_own = new ExampleC(3.0f, "testC", new DateTime(2000, 10, 3, 0, 0, 0), null);

            a_own.Reference = b_own;
            b_own.Reference = c_own;
            c_own.Reference = a_own;

            MemoryStream ms = new MemoryStream();

            IFormatter formatter = new StringFormatter(new StringBinder());
            formatter.Serialize(ms, b_own);

            ExampleB deserializedB = (ExampleB)formatter.Deserialize(new MemoryStream(ms.ToArray()));

            Assert.AreEqual(b_own.FloatTest, deserializedB.FloatTest);
            Assert.AreEqual(b_own.StringTest, deserializedB.StringTest);
            Assert.AreEqual(b_own.DateTest, deserializedB.DateTest);

            Assert.AreEqual(b_own.Reference.FloatTest, deserializedB.Reference.FloatTest);
            Assert.AreEqual(b_own.Reference.StringTest, deserializedB.Reference.StringTest);
            Assert.AreEqual(b_own.Reference.DateTest, deserializedB.Reference.DateTest);

            Assert.AreEqual(b_own.Reference.Reference.FloatTest, deserializedB.Reference.Reference.FloatTest);
            Assert.AreEqual(b_own.Reference.Reference.StringTest, deserializedB.Reference.Reference.StringTest);
            Assert.AreEqual(b_own.Reference.Reference.DateTest, deserializedB.Reference.Reference.DateTest);

            Assert.AreSame(deserializedB, deserializedB.Reference.Reference.Reference);
            Assert.AreSame(deserializedB.Reference, deserializedB.Reference.Reference.Reference.Reference);
            Assert.AreSame(deserializedB.Reference.Reference, deserializedB.Reference.Reference.Reference.Reference.Reference);

        }

        [TestMethod]
        public void TestNullReferenceSerializationDeserializationC()
        {
            ExampleC c = new ExampleC(1.0f, "testC", new DateTime(1998, 12, 1, 0, 0, 0), null);

            MemoryStream ms = new MemoryStream();
            IFormatter formatter = new StringFormatter(new StringBinder());
            formatter.Serialize(ms, c);

            ExampleC deserializedC = (ExampleC)formatter.Deserialize(new MemoryStream(ms.ToArray()));

            Assert.AreEqual(c.FloatTest, deserializedC.FloatTest);
            Assert.AreEqual(c.StringTest, deserializedC.StringTest);
            Assert.AreEqual(c.DateTest, deserializedC.DateTest);
        }

        [TestMethod]
        public void TestCycleSerializationDeserializationC()
        {
            ExampleA a_own = new ExampleA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
            ExampleB b_own = new ExampleB(2.0f, "testB", new DateTime(1999, 11, 2, 0, 0, 0), null);
            ExampleC c_own = new ExampleC(3.0f, "testC", new DateTime(2000, 10, 3, 0, 0, 0), null);

            a_own.Reference = b_own;
            b_own.Reference = c_own;
            c_own.Reference = a_own;

            MemoryStream ms = new MemoryStream();

            IFormatter formatter = new StringFormatter(new StringBinder());
            formatter.Serialize(ms, c_own);

            ExampleC deserializedC = (ExampleC)formatter.Deserialize(new MemoryStream(ms.ToArray()));

            Assert.AreEqual(c_own.FloatTest, deserializedC.FloatTest);
            Assert.AreEqual(c_own.StringTest, deserializedC.StringTest);
            Assert.AreEqual(c_own.DateTest, deserializedC.DateTest);

            Assert.AreEqual(c_own.Reference.FloatTest, deserializedC.Reference.FloatTest);
            Assert.AreEqual(c_own.Reference.StringTest, deserializedC.Reference.StringTest);
            Assert.AreEqual(c_own.Reference.DateTest, deserializedC.Reference.DateTest);

            Assert.AreEqual(c_own.Reference.Reference.FloatTest, deserializedC.Reference.Reference.FloatTest);
            Assert.AreEqual(c_own.Reference.Reference.StringTest, deserializedC.Reference.Reference.StringTest);
            Assert.AreEqual(c_own.Reference.Reference.DateTest, deserializedC.Reference.Reference.DateTest);

            Assert.AreSame(deserializedC, deserializedC.Reference.Reference.Reference);
            Assert.AreSame(deserializedC.Reference, deserializedC.Reference.Reference.Reference.Reference);
            Assert.AreSame(deserializedC.Reference.Reference, deserializedC.Reference.Reference.Reference.Reference.Reference);

        }
    }
}
