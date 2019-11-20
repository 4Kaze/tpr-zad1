using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    public class DataContext
    {
        [XmlArray("Clients")]
//       [JsonProperty(PropertyName = "Clients")]
        public List<Person> Clients;
        [XmlElement("Books")]
//        [JsonProperty(PropertyName = "Books")]
        public Dictionary<long, Catalog> Books;
        [XmlArray("Transactions")]
  //      [JsonProperty(PropertyName = "Transactions")]
        public ObservableCollection<Event> Transactions;
        [XmlArray("Descriptions")]
    //    [JsonProperty(PropertyName = "Descriptions")]
        public List<StateDescription> Descriptions;

        public DataContext()
        {
            Clients = new List<Person>();
            Books = new Dictionary<long, Catalog>();
            Transactions = new ObservableCollection<Event>();
            Descriptions = new List<StateDescription>();
        }

        


    }
}
