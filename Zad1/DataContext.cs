using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zad1
{
    public class DataContext
    {
        public List<Person> clients;
        public Dictionary<long, Catalog> books;
        public ObservableCollection<Event> transactions;
        public List<StateDescription> descriptions;
        public DataContext()
        {
            clients = new List<Person>();
            books = new Dictionary<long, Catalog>();
            transactions = new ObservableCollection<Event>();
            descriptions = new List<StateDescription>();
        }


    }
}
