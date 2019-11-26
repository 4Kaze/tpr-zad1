using System;
using System.Runtime.Serialization;

namespace TestClasses
{
    [DataContract]
    public class ExampleXmlA
    {
        [DataMember]
        public float FloatTest { get; set; }
        [DataMember]
        public string StringTest { get; set; }
        [DataMember]
        public DateTime DateTest { get; set; }
        [DataMember]
        public ExampleXmlB Reference { get; set; }

        public ExampleXmlA()
        {

        }

        public ExampleXmlA(float floatTest, string stringTest, DateTime dateTest, ExampleXmlB reference)
        {
            this.FloatTest = floatTest;
            this.StringTest = stringTest;
            this.DateTest = dateTest;
            this.Reference = reference;
        }
    }
}
