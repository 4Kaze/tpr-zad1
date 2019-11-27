using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace TestClasses.Serialization
{
    public class StringBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            return Assembly.Load(assemblyName).GetType(typeName);
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            typeName = serializedType.FullName;
            assemblyName = serializedType.Assembly.FullName;
        }
    }
}
