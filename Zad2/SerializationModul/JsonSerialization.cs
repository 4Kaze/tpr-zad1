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

            using (var sw = new StreamWriter(this.Path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
            
        }

        public object Deserialize()
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamReader(this.Path))
            {
                return serializer.Deserialize(sw, typeof(DataContext));
            }
        }
    }
}
