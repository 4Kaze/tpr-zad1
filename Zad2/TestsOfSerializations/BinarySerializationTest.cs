using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes.Serialization;

namespace TestsOfSerializations
{
    [TestClass]
    public class RecurrentSerializationDeserializationBinaryTest
    {
        [TestMethod]
<<<<<<< HEAD:Zad2/TestsOfSerializations/BinarySerializationTest.cs
<<<<<<< HEAD:Zad2/TestsOfSerializations/BinarySerializationTest.cs
        public void ReccurentSerializationBinary()
        {/*

=======
        public void TestMethod1()
        {
>>>>>>> parent of 19039b5... serialization tests:Zad2/TestsOfSerializations/UnitTest1.cs
=======
        public void TestMethod1()
        {
>>>>>>> parent of 19039b5... serialization tests:Zad2/TestsOfSerializations/UnitTest1.cs
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
            Assert.AreEqual(testAtest.TestB.TestC.TestA.TestB.TestC.TestA.TestB.TestC.Id, testA.TestB.TestC.TestA.TestB.TestC.TestA.TestB.TestC.Id);

        }
    }
}
