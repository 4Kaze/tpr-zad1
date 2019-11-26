using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace TestClasses.Serialization
{
    public static class XmlSerializationHelper<T>
    {
        public static void Serialize(string fileName, T _object)
        {
            XmlWriter writer = XmlWriter.Create(fileName, new XmlWriterSettings() { Indent = true });
            DataContractSerializer ser = new DataContractSerializer(typeof(T), null, Int32.MaxValue, false, true, null, null);
            ser.WriteObject(writer, _object);
            writer.Close();
        }

        public static T Deserilize(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            
            T deserializedObject = (T)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            return deserializedObject;
        }
    }
}
