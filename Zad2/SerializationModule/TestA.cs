using System;
using System.Runtime.Serialization;

namespace SerializationModule
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class TestA
    {
        private static int nextId = 0;

        [DataMember]
        public TestB TestB { get; set; }

        [DataMember]
        public int Id { get; set; }

        public TestA()
        {
            Id = GetNextId();
            TestB = null;
        }


        public TestA(TestB test)
        {
            TestB = test;
        }


        public override bool Equals(Object obj)
        {
            if (!(obj is TestA)) return false;
            return ((TestA)obj).Id == Id && ((TestA)obj).TestB.Id == TestB.Id && ((TestA)obj).TestB.TestC.Id == TestB.TestC.Id;
        }


        private int GetNextId()
        {
            return nextId++;
        }
    }
}
