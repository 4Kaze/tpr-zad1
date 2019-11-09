using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Classes
{
    [Serializable]
    public class DataContext
    {
        [XmlArrayItem("Clients")]
        public List<Person> Clients;
        [XmlArrayItem("Books")]
        public Dictionary<long, Catalog> Books;
        [XmlArrayItem("Transactions")]
        public ObservableCollection<Event> Transactions;
        [XmlElement]
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
