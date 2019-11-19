using System;
using System.Runtime.Serialization;

namespace TestsOfSerializations
{
    [Serializable]
    public class TestA
    {
        private static int nextId = 0;
        
        public TestB TestB { get; set; }
        
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
