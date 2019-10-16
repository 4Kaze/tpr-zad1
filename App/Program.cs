using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Zad1;

namespace App
{
    class Program
    {
        private DataService dataService;
        

        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            dataService = new DataService(new DataRepository());
            ((ObservableCollection<Event>)dataService.GetAllTransactions()).CollectionChanged += new NotifyCollectionChangedEventHandler(TransactionsChange);
        }
        private void write(string message)
        {
            System.Console.WriteLine(message);
        }

        public void TransactionsChange(object sender, NotifyCollectionChangedEventArgs data)
        {
            if(data.Action == NotifyCollectionChangedAction.Add)
            {
                foreach(Event transaction in data.NewItems)
                {
                    write("Added new transaction: " + transaction);
                }
            } else if(data.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Event transaction in data.OldItems)
                {
                    write("Removed the transaction: " + transaction);
                }
            }
        }
    }
}
