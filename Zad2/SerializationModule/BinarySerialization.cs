using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Classes;

namespace SerializationModule
{
    public class BinarySerialization: ISerializator
    {
        public BinarySerialization()
        {

        }

        public void Serialize(DataContext dataContext, Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            
            formatter.Serialize(stream, dataContext);
            stream.Flush();
        }

        public DataContext Deserialize(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            DataContext obj = (DataContext)formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }

        /*
        public void CommonSerialize(Object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, obj);
            stream.Close();
        }

        public Object CommonDeserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read);
            Object obj = formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }
        */
    }
}