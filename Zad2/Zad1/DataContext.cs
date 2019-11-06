using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zad1
{
    public class DataContext
    {
        public List<Person> Clients;
        public Dictionary<long, Catalog> Books;
        public ObservableCollection<Event> Transactions;
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
