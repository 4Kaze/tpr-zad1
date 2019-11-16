using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializationModule;

namespace TestsOfSerializations
{
    [TestClass]
    public class RecurrentSerializationDeserializationBinaryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestA testA = new TestA();
            TestB testB = new TestB();
            TestC testC = new TestC();

            testA.TestB = testB;
            testB.TestC = testC;
            testC.TestA = testA;

            BinarySerialization binarySerialization = new BinarySerialization("plik");
            binarySerialization.CommonSerialize(testA);
            TestA testAtest = (TestA)binarySerialization.CommonDeserialize();


            Assert.AreEqual(testA.TestB, testAtest.TestB);
            Assert.AreEqual(testAtest.TestB.TestC.TestA.TestB.TestC.TestA.TestB.TestC.Id, testA.TestB.TestC.TestA.TestB.TestC.TestA.TestB.TestC.Id);

        }
    }
}
