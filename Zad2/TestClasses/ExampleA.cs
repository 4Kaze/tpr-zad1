using System;
using System.Runtime.Serialization;

namespace TestClasses
{
    public class ExampleA : ISerializable
    {
        public float FloatTest { get; set; } 
        public string StringTest { get; set; }
        public DateTime DateTest { get; set; }
        public ExampleB Reference { get; set; }

        public ExampleA(float floatTest, string stringTest, DateTime dateTest, ExampleB reference)
        {
            this.FloatTest = floatTest;
            this.StringTest = stringTest;
            this.DateTest = dateTest;
            this.Reference = reference;
        }


        public ExampleA(SerializationInfo info, StreamingContext context)
        {
            this.FloatTest = info.GetSingle("float");
            this.StringTest = info.GetString("string");
            this.DateTest = info.GetDateTime("date");
            this.Reference = (ExampleB)info.GetValue("refercnceB", typeof(ExampleB));
            Console.WriteLine("hej");
        }



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("float", FloatTest);
            info.AddValue("string", StringTest);
            info.AddValue("date", DateTest);
            info.AddValue("refercnceB", Reference, typeof(ExampleB));
        }

    }
}
