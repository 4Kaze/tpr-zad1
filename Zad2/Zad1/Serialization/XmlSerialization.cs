using System.IO;
using System.Xml.Serialization;

namespace Classes.Serialization
{
    public class XmlSerialization: Serializator
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
            using (Stream writer = File.Open(Path, FileMode.Create))
            {
                ser.Serialize(writer, dataContext);
            }
        }


        public DataContext Deserialize()
        {
            DataContext obj;
            XmlSerializer ser = new XmlSerializer(typeof(DataContext));
            using(Stream reader = File.Open(Path, FileMode.Open))
            {
                obj = (DataContext)ser.Deserialize(reader);
            }
            return obj;
        }
    }
}
