using System;
using Classes;
using Classes.Serialization;

namespace SerializationConsole
{
    class Program
    {
        private DataContext dataContext;

        static void Main(string[] args)
        {
            new Program();
        }

        Program()
        {
            IFillInterface fillInterface = new FillConsole();
            dataContext = new DataContext();
            fillInterface.FillData(dataContext);

            while(true)
            {
                doMainMenu();
                Console.WriteLine();
            }
        }

        private void doSerializationMenu(Format format)
        {
            Serializator serializator;
            switch (format)
            {
                case Format.XML:
                    serializator = new XmlSerialization();
                    break;
                case Format.JSON:
                    serializator = new JsonSerialization();
                    break;
                case Format.BINARY:
                    serializator = new BinarySerialization();
                    break;
                case Format.OWN:
                    serializator = new OwnSerialization();
                    break;
                default:
                    throw new ArgumentException("Unknown serialization format.");
            }

            Console.WriteLine();
            Console.Write("Enter filename: ");
            serializator.Path = Console.ReadLine();

            Console.WriteLine("Choose mode:");
            Console.WriteLine("[1] - Serialization\n[2] - Deserialization");

            int mode = -1;
            while (mode == -1)
            {
                char choice = Console.ReadKey().KeyChar;
                switch(choice)
                {
                    case '1':
                        mode = 1;
                        break;
                    case '2':
                        mode = 2;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            DataContext deserializedContext = null;

            if(mode == 1)
            {
                serializator.Serialize(dataContext);
            } else
            {
                deserializedContext = serializator.Deserialize();
            }

            Console.WriteLine();
            /*            Console.WriteLine("Would you like to test? [y/n]");

                        bool run = true;
                        while (run)
                        {
                            char choice = Console.ReadKey().KeyChar;
                            switch (choice)
                            {
                                case 'y':
                                    run = false;
                                    break;
                                case 'n':
                                    return;
                                default:
                                    Console.WriteLine("Invalid choice.");
                                    break;
                            }
                        }*/

            if (mode == 1)
            {
                deserializedContext = serializator.Deserialize();
            }

            foreach (Event e in deserializedContext.Transactions)
            {
                Console.WriteLine(e);
            }
        }

        private void doMainMenu()
        {
            Console.WriteLine("SERIALIZATION");
            Console.WriteLine("Choose a format you'd like to use:");
            Console.WriteLine("[1] - XML\n[2] - JSON\n[3] - binary\n[4] - own");
            Console.Write("Choice: ");

            bool run = true;

            while (run)
            {
                char choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        run = false;
                        doSerializationMenu(Format.XML);
                        break;
                    case '2':
                        run = false;
                        doSerializationMenu(Format.JSON);
                        break;
                    case '3':
                        run = false;
                        doSerializationMenu(Format.BINARY);
                        break;
                    case '4':
                        run = false;
                        doSerializationMenu(Format.OWN);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;

                }
            }
        }

        enum Format
        {
            XML, JSON, BINARY, OWN
        }
    }
}
