using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SerializationModule
{
    public interface IOwnSerializable
    {
        string Serialization(ObjectIDGenerator idGenerator);
        void Deserialization(string[] data, Dictionary<long, Object> deserializedObjects);
    }
}
