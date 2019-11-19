using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes.Serialization;

namespace TestsOfSerializations
{
    [TestClass]
    public class RecurrentSerializationDeserializationBinaryTest
    {
        [TestMethod]
        public void ReccurentSerializationBinary()
        {/*

            TestA testA = new TestA();
            TestB testB = new TestB();
            TestC testC = new TestC();

            testA.TestB = testB;
            testB.TestC = testC;
            testC.TestA = testA;

            BinarySerialization binarySerialization = new BinarySerialization("plik");
            binarySerialization.CommonSerialize(testA);
            TestA testAtest = (TestA)binarySerialization.CommonDeserialize();


            Assert.AreEqual(testA, testAtest);
            Assert.AreEqual(testA.TestB, testAtest.TestB);
            Assert.AreEqual(testAtest.TestB.TestC.TestA.TestB.TestC.TestA.TestB.TestC.Id, testA.TestB.TestC.TestA.TestB.TestC.TestA.TestB.TestC.Id);*/

        }
    }
}
