using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerializationModul;
using Classes;

namespace SerializationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string c = "a";
            string flag;

            Console.WriteLine("insert [a] xml , [b] binary.");
            flag = Console.ReadLine();

            IFillInterface fillInterface = new FillConstant();
            DataContext dataContext = new DataContext();

            if(flag == "a")
            {
                do
                {
                    Console.WriteLine("insert file name.");
                    string path = Console.ReadLine();
                    XmlSerialization xmlSerialization = new XmlSerialization();
                    xmlSerialization.Path = path;
                    xmlSerialization.Serialize(dataContext);
                    Console.WriteLine("[1] by wyczytac liste osob");
                    Console.Read();
                    DataContext dataContext1 = xmlSerialization.Deserialize();
                    if (dataContext.Books.Count == dataContext1.Books.Count)
                    {
                        Console.WriteLine(dataContext.Clients[0].ToString());
                        Console.WriteLine(dataContext1.Clients[0].ToString());
                    }
                    else
                    {
                        Console.WriteLine("jeblo");
                    }

                    Console.Read();
                    c = Console.ReadLine();
                } while (c != "b");
            }

            if(flag == "b")
            {
                do
                {
                    fillInterface.FillData(dataContext);

                    Console.WriteLine("insert file name.");
                    string path = Console.ReadLine();
                    BinarySerialization binarySerialization = new BinarySerialization();
                    binarySerialization.Path = path;
                    binarySerialization.Serialize(dataContext);

                    Console.WriteLine("[1] by wyczytac liste osob");
                    Console.Read();
                    DataContext dataContext1 = binarySerialization.Deserialize();

                    if (dataContext.Books.Count == dataContext1.Books.Count)
                    {
                        Console.WriteLine(dataContext.Clients[0].ToString());
                        Console.WriteLine(dataContext1.Clients[0].ToString());
                    }
                    else
                    {
                        Console.WriteLine("jeblo");
                    }


                    Console.Read();
                    c = Console.ReadLine();
                } while (c != "b");
            }
        }
    }
}
