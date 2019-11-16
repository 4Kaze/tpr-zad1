using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Classes
{
    public interface IOwnSerialization
    {
        string Serialization(ObjectIDGenerator idGenerator);
        void Deserialization(string[] data, Dictionary<long, Object> deserializedObjects);
    }
}
