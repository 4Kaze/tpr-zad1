using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestsOfSerializations
{
    [Serializable]
    public class TestB
    {
        private static int nextId = 0;

        
        public TestC TestC { get; set; }
        
        public int Id { get; set; }

        public TestB()
        {
            TestC = null;
        }


        public TestB(TestC test)
        {
            TestC = test;
        }


        public override bool Equals(Object obj)
        {
            if (!(obj is TestB)) return false;
            return ((TestB)obj).Id == Id && ((TestB)obj).TestC.Id == TestC.Id && ((TestB)obj).TestC.TestA.Id == TestC.TestA.Id;
        }


        private int GetNextId()
        {
            return nextId++;
        }
    }
}
