using System;
using System.Runtime.Serialization;

namespace TestClasses
{
    public class ExampleC : ISerializable
    {
        public float FloatTest { get; set; }
        public string StringTest { get; set; }
        public DateTime DateTest { get; set; }
        public ExampleA Reference { get; set; }

        public ExampleC(float floatTest, string stringTest, DateTime dateTest, ExampleA reference)
        {
            this.FloatTest = floatTest;
            this.StringTest = stringTest;
            this.DateTest = dateTest;
            this.Reference = reference;
        }


        public ExampleC(SerializationInfo info, StreamingContext context)
        {
            this.FloatTest = info.GetSingle("float");
            this.StringTest = info.GetString("string");
            this.DateTest = info.GetDateTime("date");
            this.Reference = (ExampleA)info.GetValue("refercnceA", typeof(ExampleA));
        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("float", FloatTest);
            info.AddValue("string", StringTest);
            info.AddValue("date", DateTest);
            info.AddValue("refercnceA", Reference, typeof(ExampleA));
        }
    }
}
