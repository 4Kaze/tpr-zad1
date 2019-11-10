using Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace SerializationModul
{
    public class JsonSerialization
    {
        public string Path { get; set; }
        public JsonSerialization()
        {

        }

        public JsonSerialization(string path)
        {
            Path = path;
        }


        public void Serialize(object obj)
        {
            var serializer = new JsonSerializer();

            using (FileStream file = File.Open(this.Path, FileMode.Create))
            using (var sw = new StreamWriter(file))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj, typeof(DataContext));
            }

        }

        public DataContext Deserialize()
        {

            DataContext obj2 = Newtonsoft.Json.JsonConvert.DeserializeObject<DataContext>(File.ReadAllText(this.Path), new Newtonsoft.Json.JsonSerializerSettings
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
