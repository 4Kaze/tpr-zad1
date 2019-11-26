using System;
using System.Runtime.Serialization;

namespace TestClasses
{
    [DataContract]
    public class ExampleXmlC
    {
        [DataMember]
        public float FloatTest { get; set; }
        [DataMember]
        public string StringTest { get; set; }
        [DataMember]
        public DateTime DateTest { get; set; }
        [DataMember]
        public ExampleXmlA Reference { get; set; }

        public ExampleXmlC()
        {

        }

        public ExampleXmlC(float floatTest, string stringTest, DateTime dateTest, ExampleXmlA reference)
        {
            this.FloatTest = floatTest;
            this.StringTest = stringTest;
            this.DateTest = dateTest;
            this.Reference = reference;
        }
    }
}
