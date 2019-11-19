
namespace Classes.Serialization
{
    public interface Serializator
    {
        string Path { get; set; }
        void Serialize(DataContext dataContext);
        DataContext Deserialize();
    }
}