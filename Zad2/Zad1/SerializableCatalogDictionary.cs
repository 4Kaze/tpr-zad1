using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Classes
{
    public class SerializableCatalogDictionary : Dictionary<long, Catalog>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<KeyValuePair>));
            reader.Read();
            foreach(KeyValuePair pair in (List<KeyValuePair>)serializer.Deserialize(reader))
            {
                Add(pair.Key, pair.Value);
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<KeyValuePair>));
            serializer.Serialize(writer, this.Select(pair => new KeyValuePair(pair.Key, pair.Value)).ToList());
        }

        [Serializable]
        [XmlType("CatalogKeyValuePair")]
        public struct KeyValuePair
        {
            public KeyValuePair(long k, Catalog v)
            {
                Key = k;
                Value = v;
            }

            public long Key
            { get; set; }

            public Catalog Value
            { get; set; }
        }
    }
}
