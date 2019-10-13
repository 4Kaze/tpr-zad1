using System;
using System.Collections.Generic;

namespace Zad1
{
    public class DataRepository
    {
        private long catalogKey;
        private DataContext dataContext;
        private IFillInterface IfillInterface;

        public long CatalogKey
        {
            get { return this.catalogKey; }
        }

        public DataRepository(IFillInterface fillInterface)
        {
            this.catalogKey = 0;
            this.IfillInterface = fillInterface;
            this.dataContext = new DataContext();
            this.IfillInterface.FillData(dataContext);
        }


        public DataRepository()
        {
            this.catalogKey = 0;
            this.dataContext = new DataContext();
        }

        // Add
        public void AddPerson(Person person)
        {
            dataContext.Clients.Add(person);
        }

        public void AddCatalog(Catalog catalog)
        {
            dataContext.Books.Add(this.catalogKey++, catalog);
        }

        public void AddTransaction(Event transaction)
        {
            dataContext.Transactions.Add(transaction);
        }

        public void AddStateDescription(StateDescription description)
        {
            dataContext.Descriptions.Add(description);
        }

        // Get by index

        public Person GetPerson(int index)
        {
            if (dataContext.Clients.Count > index)
            {
                return dataContext.Clients[index];
            }
            else
            {
                return null;
            }
        }

        public Catalog GetCatalog(long key)
        {
            if (dataContext.Books.ContainsKey(key))
            {
                return dataContext.Books[key];
            }
            else
            {
                return null;
            }
        }

        public Event GetTransaction(int index)
        {
            if (dataContext.Transactions.Count > index)
            {
                return dataContext.Transactions[index];
            }
            else
            {
                return null;
            }
        }

        public StateDescription GetStateDescription(int index)
        {
            if (dataContext.Descriptions.Count > index)
            {
                return dataContext.Descriptions[index];
            }
            else
            {
                return null;
            }
        }

        // Get by code

        public Person GetPersonByCode(long code)
        {
            return dataContext.Clients.Find(p => p.Code == code);
        }

        public Catalog GetCatalogByCode(long code)
        {
           foreach(KeyValuePair<long, Catalog> pair in dataContext.Books)
           {
                if(pair.Value.Code == code)
                    return pair.Value;
           }
           return null;
        }

        public Event GetTransactionByCode(long code)
        {
            foreach(Event transaction in dataContext.Transactions)
            {
                if (transaction.Code == code)
                    return transaction;
            }
            return null;
        }

        public StateDescription GetStateDescriptionByCode(long code)
        {
            return dataContext.Descriptions.Find(d => d.Code == code);
        }

        // GetAll

        public IEnumerable<Person> GetAllPersons()
        {
           return dataContext.Clients;
        }

        public IEnumerable<KeyValuePair<long, Catalog>> GetAllCatalogs()
        {
           return dataContext.Books;
        }

        public IEnumerable<Event> GetAllTransactions()
        {
           return dataContext.Transactions;
        }

        public IEnumerable<StateDescription> GetAllStateDescriptions()
        {
           return dataContext.Descriptions;
        }

        // Update

        public int UpdatePerson(int index, Person person) {
            if(dataContext.Clients.Count > index)
            {
                dataContext.Clients[index] = person;
                return 1;
            }
            return 0;
        }

        public int UpdateCatalog(long key, Catalog catalog) {
            if(dataContext.Books.ContainsKey(key))
            {
                dataContext.Books[key] = catalog;
                return 1;
            }
            return 0;
        }

        public int UpdateTransaction(int index, Event transaction) {
            if(dataContext.Transactions.Count > index)
            {
                dataContext.Transactions[index] = transaction;
                return 1;
            }
            return 0;
        }

        public int UpdateStateDescription(int index, StateDescription description) {
            if(dataContext.Descriptions.Count > index)
            {
                dataContext.Descriptions[index] = description;
                return 1;
            }
            return 0;
        }

        public int UpdatePerson(Person person) {
            int index = dataContext.Clients.IndexOf(person);
            if(index == -1) return 0;
            dataContext.Clients[index] = person;
            return 1;
        }

        public int UpdateCatalog(Catalog catalog) {
           foreach(KeyValuePair<long, Catalog> pair in dataContext.Books)
           {
                if (pair.Value.Code == catalog.Code)
                {
                    dataContext.Books[pair.Key] = catalog;
                    return 1;
                }
           }
           return 0;
        }

        public int UpdateTransaction(Event transaction) {
            int index = dataContext.Transactions.IndexOf(transaction);
            if (index == -1) return 0;
            dataContext.Transactions[index] = transaction;
            return 1;
        }

        public int UpdateStateDescription(StateDescription description) {
            int index = dataContext.Descriptions.IndexOf(description);
            if(index == -1) return 0;
            dataContext.Descriptions[index] = description;
            return 1;
        }

        // Delete

        public int DeletePerson(Person person)
        {
            if (dataContext.Clients.Contains(person))
            {
                dataContext.Clients.Remove(person);
                return 1;
            }
            return 0;
        }

        public int DeleteCatalog(Catalog catalog)
        {
            if (!dataContext.Books.ContainsValue(catalog))
                return 0;

            foreach(KeyValuePair<long, Catalog> pair in dataContext.Books)
            {
                if (pair.Value.Code == catalog.Code)
                {
                    dataContext.Books.Remove(pair.Key);
                    return 1;
                }
            }

            return 0;
        }

        public int DeleteTransaction(Event transaction)
        {
            if (dataContext.Transactions.Contains(transaction))
            {
                dataContext.Transactions.Remove(transaction);
                return 1;
            }
            return 0;
        }

        public int DeleteStateDescription(StateDescription stateDescription)
        {
            if (dataContext.Descriptions.Contains(stateDescription))
            {
                dataContext.Descriptions.Remove(stateDescription);
                return 1;
            }
            return 0;
        }

        public int DeletePersonByIndex(int index)
        {
            if (dataContext.Clients.Count > index)
            {
                dataContext.Clients.RemoveAt(index);
                return 1;
            }
            return 0;
        }

        public int DeleteCatalogByKey(long key)
        {
            if (dataContext.Books.ContainsKey(key))
            {
                dataContext.Books.Remove(key);
                return 1;
            }
            return 0;
        }

        public int DeleteTransactionByIndex(int index)
        {
            if (dataContext.Transactions.Count > index)
            {
                dataContext.Transactions.RemoveAt(index);
                return 1;
            }
            return 0;
        }

        public int DeleteStateDescriptionByIndex(int index)
        {
            if (dataContext.Descriptions.Count > index)
            {
                dataContext.Descriptions.RemoveAt(index);
                return 1;
            }
            return 0;
        }
        

    }
}
