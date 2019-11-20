using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SerializationModule
{
    public interface IOwnSerializable
    {
        string Serialization(ObjectIDGenerator idGenerator);
        void Deserialization(string[] data, Dictionary<long, Object> deserializedObjects, Dictionary<object, List<long>> requiredObjects);
    }
}
