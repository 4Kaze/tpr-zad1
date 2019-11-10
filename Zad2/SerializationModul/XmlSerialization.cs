using Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationModul
{
    public class XmlSerialization
    {
        public string Path { get; set; }
        public XmlSerialization()
        {

        }
        
        public XmlSerialization(string path)
        {
            Path = path;
        }

        public void Serialize(DataContext dataContext)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataContext));
            using (Stream writer = File.Open(Path + ".xml", FileMode.Create))
            {
                ser.Serialize(writer, dataContext);
            }
        }


        public DataContext Deserialize()
        {
            DataContext obj;
            XmlSerializer ser = new XmlSerializer(typeof(DataContext));
            using(Stream reader = File.Open(Path + ".xml", FileMode.Open))
            {
                obj = (DataContext)ser.Deserialize(reader);
            }
            return obj;
        }
    }
}
