using Newtonsoft.Json;
using System.IO;

namespace Classes.Serialization
{
    public class JsonSerialization: ISerializator
    {
        public JsonSerialization()
        {

        }

        public void Serialize(DataContext dataContext, Stream stream)
        {
            var serializer = new JsonSerializer();
            var sw = new StreamWriter(stream);
            JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, dataContext, typeof(DataContext));
        }

        public DataContext Deserialize(Stream stream)
        {
            TextReader tr = new StreamReader(stream);
            DataContext obj2 = Newtonsoft.Json.JsonConvert.DeserializeObject<DataContext>(tr.ReadToEnd(), new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            });
            return obj2;
            /*using (StreamReader file = File.OpenText(Path))
            {
                var serializer = new JsonSerializer();
                return (DataContext)serializer.Deserialize(file, typeof(DataContext));
            }*/
        }
    }
}
