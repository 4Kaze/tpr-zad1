using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Classes;

namespace SerializationModule
{
    public class BinarySerialization: Serializator
    {
        public string Path { get; set; }
        public BinarySerialization()
        {

        }

        public BinarySerialization(string path)
        {
            Path = path;
        }

        public void Serialize(DataContext dataContext)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, dataContext);
            stream.Close();
        }

        public DataContext Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read);
            DataContext obj = (DataContext)formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }

    }
}