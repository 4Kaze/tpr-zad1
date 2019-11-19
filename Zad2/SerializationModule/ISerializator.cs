using Classes;
using System.IO;

namespace SerializationModule
{
    public interface ISerializator
    {
        void Serialize(DataContext dataContext, Stream outputStream);
        DataContext Deserialize(Stream inputStream);
    }
}
