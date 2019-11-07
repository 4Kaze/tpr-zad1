using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace SerializationModul
{
    public class BinarySerialization
    {
        public string Path { get; set; }
        public BinarySerialization()
        {

        }


        public void Serialize(DataContext dataContext, string path)
        {
            Path = path;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, dataContext);
            stream.Close();
        }


        public void Serialize(DataContext dataContext)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path + ".bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, dataContext);
            stream.Close();
        }


        public DataContext Deserialize(string path)
        {
            Path = path;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path + ".bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            DataContext obj = (DataContext)formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }


        public DataContext Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path + ".bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            DataContext obj = (DataContext)formatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine("Shit happens");
            return obj;
        }
    }
}