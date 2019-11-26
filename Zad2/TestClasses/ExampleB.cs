using System;
using System.Runtime.Serialization;

namespace TestClasses
{
    public class ExampleB : ISerializable
    {
        public float FloatTest { get; set; }
        public string StringTest { get; set; }
        public DateTime DateTest { get; set; }
        public ExampleC Reference { get; set; }

        public ExampleB(float floatTest, string stringTest, DateTime dateTest, ExampleC reference)
        {
            this.FloatTest = floatTest;
            this.StringTest = stringTest;
            this.DateTest = dateTest;
            this.Reference = reference;
        }


        public ExampleB(SerializationInfo info, StreamingContext context)
        {
            this.FloatTest = info.GetSingle("float");
            this.StringTest = info.GetString("string");
            this.DateTest = info.GetDateTime("date");
            this.Reference = (ExampleC)info.GetValue("refercnceC", typeof(ExampleC));
        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("float", FloatTest);
            info.AddValue("string", StringTest);
            info.AddValue("date", DateTest);
            info.AddValue("refercnceC", Reference, typeof(ExampleC));
        }
    }
}
