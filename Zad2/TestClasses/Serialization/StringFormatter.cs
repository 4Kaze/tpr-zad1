using System;
using System.IO;
using System.Runtime.Serialization;

namespace TestClasses.Serialization
{
    public class StringFormatter : Formatter
    {
        private string SerilizedData { get; set; }
        private string FullString { get; set; }

        public override ISurrogateSelector SurrogateSelector { get; set; }
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }

        public StringFormatter(SerializationBinder binder)
        {
            this.Binder = binder;
            this.Context = new StreamingContext(StreamingContextStates.File);
            this.SerilizedData = "";
            this.FullString = ";Our Serialization \n"
                + ";Version 1.0 \n";
        }

        public override object Deserialize(Stream serializationStream)
        {
            throw new NotImplementedException();
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable objData)
            {
                SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
                Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName);


                SerilizedData += ";" + assemblyName + ";" + typeName + ";" + this.m_idGenerator.GetId(graph, out bool firstTime) + "\n";
                objData.GetObjectData(info, Context);


                foreach (SerializationEntry item in info)
                {
                    WriteMember(item.Name, item.Value);
                }


                FullString += SerilizedData;
                SerilizedData = "";


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
            SerilizedData += ";" + val.GetType() + "=" + name + "=" + val.ToUniversalTime().ToString();
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
            SerilizedData += ";" + val.GetType() + "=" + name + "=" + val.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
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
            SerilizedData += ";" + obj.GetType() + "=" + name + "="  + (String)obj ;
        }


        protected void WriteObject(object obj, string name, Type type)
        {
            if (obj != null)
            {
                SerilizedData += ";" + obj.GetType() + "=" + name + "=" + this.m_idGenerator.GetId(obj, out bool firstTime).ToString();
                if (firstTime) { this.m_objectQueue.Enqueue(obj); }
            }
            else
            {
                SerilizedData += ";" + "null" + "=" + name + "=-1";
            }
        }


        private void WriteStream(Stream serializationStream)
        {
            if (serializationStream != null)
            {
                using (StreamWriter writer = new StreamWriter(serializationStream))
                {
                        writer.Write(FullString);
                }
            }
        }
    }
}
