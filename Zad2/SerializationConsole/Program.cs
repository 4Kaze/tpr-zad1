using System;
using System.IO;
using Classes;
using SerializationModule;

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
            IFillInterface fillInterface = new FillConstant();
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
            ISerializator serializator;
            switch (format)
            {
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
            string path = Console.ReadLine();

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
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }
            }

            DataContext deserializedContext = null;

            if(mode == 1)
            {
                Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                serializator.Serialize(dataContext, stream);
                stream.Close();
            } else
            {
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                deserializedContext = serializator.Deserialize(stream);
                stream.Close();
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
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                deserializedContext = serializator.Deserialize(stream);
                stream.Close();
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
            Console.WriteLine("[1] - binary\n[2] - own");
            Console.Write("Choice: ");

            bool run = true;

            while (run)
            {
                char choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        run = false;
                        doSerializationMenu(Format.BINARY);
                        break;
                    case '2':
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
            BINARY, OWN
        }
    }
}
