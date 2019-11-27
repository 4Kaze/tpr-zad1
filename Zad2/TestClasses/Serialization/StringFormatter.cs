using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;

namespace TestClasses.Serialization
{
    public class StringFormatter : Formatter
    {
        private string SerilizedData { get; set; }
        public override ISurrogateSelector SurrogateSelector { get; set; }
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }

        public StringFormatter(SerializationBinder binder)
        {
            this.Binder = binder;
            this.Context = new StreamingContext(StreamingContextStates.File);
            this.SerilizedData = "";
        }

        public override object Deserialize(Stream serializationStream)
        {
            object initialObject = null;
            Dictionary<long, object> deserializedObjects = new Dictionary<long, object>();
            Dictionary<object, SerializationInfo> deserializationData = new Dictionary<object, SerializationInfo>();
            Dictionary<SerializationInfo, List<Tuple<string, Type, long>>> pendingObjects = new Dictionary<SerializationInfo, List<Tuple<string, Type, long>>>();

            char[] semiSplitter = { ';' };
            char[] eqSplitter = { '=' };

            using (StreamReader reader = new StreamReader(serializationStream))
            {
                while (!reader.EndOfStream)
                {
                    string header = reader.ReadLine();
                    string[] values = header.Split(';');
                    long id = long.Parse(values[2]);
                    Type objectType = Binder.BindToType(values[0], values[1]);
                    SerializationInfo serializationInfo = new SerializationInfo(objectType, new FormatterConverter());
                    object obj = FormatterServices.GetUninitializedObject(objectType);

                    if (initialObject == null)
                        initialObject = obj;

                    deserializationData.Add(obj, serializationInfo);
                    deserializedObjects.Add(id, obj);
                   
                    string[] fields = reader.ReadLine().Split(semiSplitter, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string field in fields)
                    {
                        string[] parts = field.Split('=');
                        if(parts[2].StartsWith("&"))
                        {
                            if(!pendingObjects.ContainsKey(serializationInfo))
                            {
                                pendingObjects.Add(serializationInfo, new List<Tuple<string, Type, long>>());
                            }
                            if (parts[2].StartsWith("&-1"))
                            {
                                Type type = Type.GetType(parts[0]);
                                serializationInfo.AddValue(parts[1], null, type);
                            } else
                            {
                                pendingObjects[serializationInfo].Add(new Tuple<string, Type, long>(parts[1], Type.GetType(parts[0]), long.Parse(parts[2].Substring(1))));
                            }                            
                        } else
                        {
                            Type type = Type.GetType(parts[0]);
                            serializationInfo.AddValue(parts[1], Convert.ChangeType(parts[2], type), type);
                        }
                    }

                }

                foreach(var pair in pendingObjects)
                {
                    SerializationInfo serializationInfo = pair.Key;
                    foreach(var tuple in pair.Value)
                    {
                        serializationInfo.AddValue(tuple.Item1, deserializedObjects[tuple.Item3], tuple.Item2);
                    }
                }

                foreach(var pair in deserializationData)
                {
                    pair.Key.GetType().GetConstructor(new Type[] { typeof(SerializationInfo), typeof(StreamingContext)}).Invoke(pair.Key, new object[] { pair.Value, Context });
                }
            }

            return initialObject;
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable objData)
            {
                SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
                Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName);

                SerilizedData += assemblyName + ";" + typeName + ";" + this.m_idGenerator.GetId(graph, out bool firstTime) + ";\n";
                objData.GetObjectData(info, Context);

                foreach (SerializationEntry item in info)
                {
                    WriteMember(item.Name, item.Value);
                }

                SerilizedData += "\n";

                while (this.m_objectQueue.Count != 0)
                {
                    this.Serialize(null, this.m_objectQueue.Dequeue());
                }

                WriteStream(serializationStream);

            }
            else
            {
                 
            }
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            SerilizedData += val.GetType() + "=" + name + "=" + val.ToString() + ";";
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(String))) {WriteString(obj, name);}
            else { WriteObject(obj, name, memberType);}

        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            SerilizedData += val.GetType() + "=" + name + "=" + val.ToString() + ";";
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected void WriteString(object obj, string name)
        {
            SerilizedData += obj.GetType() + "=" + name + "="  + (String)obj + ";";
        }


        protected void WriteObject(object obj, string name, Type type)
        {
            if (obj != null)
            {
                SerilizedData += obj.GetType() + "=" + name + "=&" + this.m_idGenerator.GetId(obj, out bool firstTime).ToString() + ";";
                if (firstTime) { this.m_objectQueue.Enqueue(obj); }
            }
            else
            {
                SerilizedData += type + "=" + name + "=&-1;";
            }
        }


        private void WriteStream(Stream serializationStream)
        {
            if (serializationStream != null)
            {
                using (StreamWriter writer = new StreamWriter(serializationStream))
                {
                        writer.Write(SerilizedData);
                }
            }
        }
    }
}
