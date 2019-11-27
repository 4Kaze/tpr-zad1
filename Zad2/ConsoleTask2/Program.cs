using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using TestClasses;
using TestClasses.Serialization;

namespace ConsoleTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationBinder binder = new StringBinder();

            ExampleXmlA a = new ExampleXmlA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
            ExampleXmlB b = new ExampleXmlB(2.0f, "testB", new DateTime(1999, 11, 2, 0, 0, 0), null);
            ExampleXmlC c = new ExampleXmlC(3.0f, "testC", new DateTime(2000, 10, 3, 0, 0, 0), null);

            ExampleA a_own = new ExampleA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
            ExampleB b_own = new ExampleB(2.0f, "testB", new DateTime(1999, 11, 2, 0, 0, 0), null);
            ExampleC c_own = new ExampleC(3.0f, "testC", new DateTime(2000, 10, 3, 0, 0, 0), null);

            a.Reference = b;
            b.Reference = c;
            c.Reference = a;

            a_own.Reference = b_own;
            b_own.Reference = c_own;
            c_own.Reference = a_own;



            XmlSerializationHelper<ExampleXmlA>.Serialize("xml-A-test.xml", a);
            ExampleXmlA desA = XmlSerializationHelper<ExampleXmlA>.Deserilize("xml-A-test.xml");



            using (FileStream s = new FileStream("example-a.txt", FileMode.Create))
            {
                IFormatter f = new StringFormatter(binder);
                f.Serialize(s, a_own);
            }

            using (FileStream s = new FileStream("example-a.txt", FileMode.Open))
            {
                IFormatter f = new StringFormatter(binder);
                object o = f.Deserialize(s);
                o.ToString();
            }


            if (desA.Reference.Reference.Reference.FloatTest != a.Reference.Reference.Reference.FloatTest)
            {
                do
                {

                } while (true);
            } 
        }
    }
}
