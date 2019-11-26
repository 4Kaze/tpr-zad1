using System;
using System.Runtime.Serialization;

namespace TestClasses
{
    [DataContract]
    public class ExampleXmlB
    {
        [DataMember]
        public float FloatTest { get; set; }
        [DataMember]
        public string StringTest { get; set; }
        [DataMember]
        public DateTime DateTest { get; set; }
        [DataMember]
        public ExampleXmlC Reference { get; set; }

        public ExampleXmlB()
        {

        }

        public ExampleXmlB(float floatTest, string stringTest, DateTime dateTest, ExampleXmlC reference)
        {
            this.FloatTest = floatTest;
            this.StringTest = stringTest;
            this.DateTest = dateTest;
            this.Reference = reference;
        }
    }
}
