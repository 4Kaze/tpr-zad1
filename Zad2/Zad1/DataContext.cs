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
        public List<Person> Clients;
        [XmlIgnore]
        public Dictionary<long, Catalog> Books;
        [XmlArray("Transactions")]
        public ObservableCollection<Event> Transactions;
        [XmlArray("Descriptions")]
        public List<StateDescription> Descriptions;

        [XmlArray("Books")]
        [XmlArrayItem("Book")]
        public List<KeyValuePair<long, Catalog>> BooksList
        {
            get
            {
                return Books.Select(pair => new KeyValuePair<long, Catalog>(pair.Key, pair.Value)).ToList();
            }
            set
            {
                Books = value.ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public DataContext()
        {
            Clients = new List<Person>();
            Books = new Dictionary<long, Catalog>();
            Transactions = new ObservableCollection<Event>();
            Descriptions = new List<StateDescription>();
        }

        [Serializable]
        public struct KeyValuePair<K, V>
        {
            public KeyValuePair(K k, V v) {
                Key = k;
                Value =v;
            }
                
            public K Key
            { get; set; }

            public V Value
            { get; set; }
        }


    }
}
