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
            new Program();
        }

        Program()
        {
            while (true)
            {
                DoMainMenu();
                Console.WriteLine();
            }
        }

        private void DoSerializationMenu(Format format)
        {
            if(format == Format.OWN)
            {
                bool run = true;
                bool walk = true;
                SerializationBinder binder = new StringBinder();
                Formatter formatter = new StringFormatter(binder);

                while (run)
                {

                    Console.WriteLine("\nDo you want to serialize [s] or deserialize [d]: \n");
                    char choice = Console.ReadKey().KeyChar;

                    switch (choice)
                    {
                        case 's':

                            ExampleA exampleA = new ExampleA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
                            ExampleB exampleB = new ExampleB(2.0f, "testB", new DateTime(1999, 12, 1, 0, 0, 0), null);
                            ExampleC exampleC = new ExampleC(3.0f, "testC", new DateTime(2000, 12, 1, 0, 0, 0), null);

                            exampleA.Reference = exampleB;
                            exampleB.Reference = exampleC;
                            exampleC.Reference = exampleA;


                            while (walk)
                            {
                                Console.WriteLine("\nWhich class from test one you want to serialize, ExampleA [a], ExampleB [b], ExampleC [c]: \n");
                                char example = Console.ReadKey().KeyChar;

                                switch (example)
                                {
                                    case 'a':
                                        using (Stream stream = new FileStream("Own Serialization Example A.txt", FileMode.Create))
                                        {
                                            formatter.Serialize(stream, exampleA);
                                        }
                                        walk = false;
                                        break;

                                    case 'b':
                                        using (Stream stream = new FileStream("Own Serialization Example B.txt", FileMode.Create))
                                        {
                                            formatter.Serialize(stream, exampleB);
                                        }
                                        walk = false;
                                        break;

                                    case 'c':
                                        using (Stream stream = new FileStream("Own Serialization Example C.txt", FileMode.Create))
                                        {
                                            formatter.Serialize(stream, exampleC);
                                        }
                                        walk = false;
                                        break;

                                    default:
                                        Console.WriteLine("\nInvalid choice of clas for example.");
                                        break;
                                }
                            }

                            run = false;
                            break;
                        case 'd':

                            ExampleA exampleA_Des = null;
                            ExampleB exampleB_Des = null;
                            ExampleC exampleC_Des = null;

                            while (walk)
                            {
                                Console.WriteLine("\nWhich class from test one you want to serialize, ExampleA [a], ExampleB [b], ExampleC [c]: \n");
                                char example = Console.ReadKey().KeyChar;

                                switch (example)
                                {
                                    case 'a':
                                        using (Stream stream = new FileStream("Own Serialization Example A.txt", FileMode.Open))
                                        {
                                            exampleA_Des = (ExampleA)formatter.Deserialize(stream);
                                        }
                                        if (exampleA_Des.Reference.Reference.Reference == exampleA_Des)
                                        {
                                            Console.WriteLine("\nDeserialization ended correctly.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nSomething went wrong.");
                                        }
                                        walk = false;
                                        break;


                                    case 'b':
                                        using (Stream stream = new FileStream("Own Serialization Example B.txt", FileMode.Open))
                                        {
                                            exampleB_Des = (ExampleB)formatter.Deserialize(stream);
                                        }
                                        if (exampleB_Des.Reference.Reference.Reference == exampleB_Des)
                                        {
                                            Console.WriteLine("\nDeserialization ended correctly.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nSomething went wrong.");
                                        }
                                        walk = false;
                                        break;

                                    case 'c':
                                        using (Stream stream = new FileStream("Own Serialization Example C.txt", FileMode.Open))
                                        {
                                            exampleC_Des = (ExampleC)formatter.Deserialize(stream);
                                        }
                                        if (exampleC_Des.Reference.Reference.Reference == exampleC_Des)
                                        {
                                            Console.WriteLine("\nDeserialization ended correctly.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nSomething went wrong.");
                                        }
                                        walk = false;
                                        break;

                                    default:
                                        Console.WriteLine("\nInvalid choice of clas for example.");
                                        break;
                                }

                            }
                            run = false;
                            break;

                        default:
                            Console.WriteLine("\nInvalid choice.");
                            break;
                    }
                }
            }
            else if(format == Format.XML)
            {
                bool run = true;
                bool walk = true;



                while (run)
                {

                    Console.WriteLine("\nDo you want to serialize [s] or deserialize [d]: \n");
                    char choice = Console.ReadKey().KeyChar;

                    switch (choice)
                    {
                        case 's':

                            ExampleXmlA exampleA = new ExampleXmlA(1.0f, "testA", new DateTime(1998, 12, 1, 0, 0, 0), null);
                            ExampleXmlB exampleB = new ExampleXmlB(2.0f, "testB", new DateTime(1999, 12, 1, 0, 0, 0), null);
                            ExampleXmlC exampleC = new ExampleXmlC(3.0f, "testC", new DateTime(2000, 12, 1, 0, 0, 0), null);

                            exampleA.Reference = exampleB;
                            exampleB.Reference = exampleC;
                            exampleC.Reference = exampleA;

                            while (walk)
                            {
                                
                                Console.WriteLine("\nWhich class from test one you want to serialize, ExampleA [a], ExampleB [b], ExampleC [c]: ");
                                char example = Console.ReadKey().KeyChar;



                                switch (example)
                                {
                                    case 'a':
                                        XmlSerializationHelper<ExampleXmlA>.Serialize("Xml Serialization Example A.txt", exampleA);
                                        walk = false;
                                        break;

                                    case 'b':
                                        XmlSerializationHelper<ExampleXmlB>.Serialize("Xml Serialization Example B.txt", exampleB);
                                        walk = false;
                                        break;

                                    case 'c':
                                        XmlSerializationHelper<ExampleXmlC>.Serialize("Xml Serialization Example C.txt", exampleC);
                                        walk = false;
                                        break;

                                    default:
                                        Console.WriteLine("\nInvalid choice of clas for example.");
                                        break;
                                }
                            }
                            run = false;
                            break;

                        case 'd':

                            ExampleXmlA exampleA_Des = null;
                            ExampleXmlB exampleB_Des = null;
                            ExampleXmlC exampleC_Des = null;


                            while (walk)
                            {
                                Console.WriteLine("\nWhich class from test one you want to serialize, ExampleA [a], ExampleB [b], ExampleC [c]: ");
                                char example = Console.ReadKey().KeyChar;
                                switch (example)
                                {
                                    case 'a':
                                        exampleA_Des = XmlSerializationHelper<ExampleXmlA>.Deserilize("Xml Serialization Example A.txt");
                                        if (exampleA_Des.Reference.Reference.Reference == exampleA_Des)
                                        {
                                            Console.WriteLine("\nDeserialization ended correctly.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nSomething went wrong.");
                                        }
                                        walk = false;
                                        break;

                                    case 'b':
                                        exampleB_Des = XmlSerializationHelper<ExampleXmlB>.Deserilize("Xml Serialization Example B.txt");
                                        if (exampleB_Des.Reference.Reference.Reference == exampleB_Des)
                                        {
                                            Console.WriteLine("\nDeserialization ended correctly.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nSomething went wrong.");
                                        }
                                        walk = false;
                                        break;

                                    case 'c':
                                        exampleC_Des = XmlSerializationHelper<ExampleXmlC>.Deserilize("Xml Serialization Example C.txt");
                                        if (exampleC_Des.Reference.Reference.Reference == exampleC_Des)
                                        {
                                            Console.WriteLine("\nDeserialization ended correctly.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nSomething went wrong.");
                                        }
                                        walk = false;
                                        break;

                                    default:
                                        Console.WriteLine("\nInvalid choice of clas for example.");
                                        break;
                                }
                            }
                                run = false;
                            break;


                        default:
                            Console.WriteLine("\nInvalid choice.");
                            break;
                    }
                }


            }
            else
            {
                Console.WriteLine("\nWrong format was choosen.");
            }
        }



        private void DoMainMenu()
        {
            Console.WriteLine("SERIALIZATION");
            Console.WriteLine("Choose a format you'd like to use:");
            Console.WriteLine("[1] - xml\n[2] - own");

            bool run = true;

            while (run)
            {
                Console.Write("Choice: ");
                char choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        run = false;
                        DoSerializationMenu(Format.XML);
                        break;
                    case '2':
                        run = false;
                        DoSerializationMenu(Format.OWN);
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;

                }
            }
        }

        enum Format
        {
            XML, OWN
        }
    }
}
