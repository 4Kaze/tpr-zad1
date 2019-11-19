
using System.IO;

namespace Classes.Serialization
{
    public interface ISerializator
    {
        void Serialize(DataContext dataContext, Stream stream);
        DataContext Deserialize(Stream stream);
    }
}