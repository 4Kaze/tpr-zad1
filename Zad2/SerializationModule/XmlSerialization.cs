using Classes;
using System.IO;
using System.Xml.Serialization;

namespace SerializationModule
{
    public class XmlSerialization: ISerializator
    {
        public XmlSerialization()
        {

        }
        
        public void Serialize(DataContext dataContext, Stream stream)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataContext));
            ser.Serialize(stream, dataContext);
        }


        public DataContext Deserialize(Stream stream)
        {
            DataContext obj;
            XmlSerializer ser = new XmlSerializer(typeof(DataContext));
            obj = (DataContext)ser.Deserialize(stream);
            return obj;
        }
    }
}
