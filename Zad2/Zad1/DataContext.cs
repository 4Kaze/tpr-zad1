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
        [XmlElement("Books")]
        public SerializableCatalogDictionary Books;
        [XmlArray("Transactions")]
        public ObservableCollection<Event> Transactions;
        [XmlArray("Descriptions")]
        public List<StateDescription> Descriptions;

        public DataContext()
        {
            Clients = new List<Person>();
            Books = new SerializableCatalogDictionary();
            Transactions = new ObservableCollection<Event>();
            Descriptions = new List<StateDescription>();
        }

        


    }
}
