using System;
using System.Collections.Generic;

namespace Zad1
{
    public class DataRepository : IRepositoryInterface
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
            if (!dataContext.Clients.Contains(person))
                dataContext.Clients.Add(person);
            else
                throw new ItemAlreadyExistsException(person, dataContext.Clients);
        }

        public void AddCatalog(Catalog catalog)
        {
            if (!dataContext.Books.ContainsValue(catalog))
                dataContext.Books.Add(this.catalogKey++, catalog);
            else
                throw new ItemAlreadyExistsException(catalog, dataContext.Books);
        }

        public void AddTransaction(Event transaction)
        {
            if (!dataContext.Transactions.Contains(transaction))
                dataContext.Transactions.Add(transaction);
            else
                throw new ItemAlreadyExistsException(transaction, dataContext.Transactions);
        }

        public void AddStateDescription(StateDescription description)
        {
            if (!dataContext.Descriptions.Contains(description))
                dataContext.Descriptions.Add(description);
            else
                throw new ItemAlreadyExistsException(description, dataContext.Descriptions);
        }

        // Get by index

        public Person GetPerson(int index)
        {
            return dataContext.Clients[index];
        }

        public Catalog GetCatalog(long key)
        {
            return dataContext.Books[key];
        }

        public Event GetTransaction(int index)
        {
            return dataContext.Transactions[index];
        }

        public StateDescription GetStateDescription(int index)
        {
             return dataContext.Descriptions[index];
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

        public void UpdatePerson(int index, Person person) {
            dataContext.Clients[index] = person;
        }

        public void UpdateCatalog(long key, Catalog catalog) {
            dataContext.Books[key] = catalog;
        }

        public void UpdateTransaction(int index, Event transaction) {
            dataContext.Transactions[index] = transaction;
        }

        public void UpdateStateDescription(int index, StateDescription description) {
            dataContext.Descriptions[index] = description;
        }

        public void UpdatePerson(Person person) {
            int index = dataContext.Clients.IndexOf(person);

            if(index == -1)
                throw new ItemDoesNotExistException(person, dataContext.Clients);

            dataContext.Clients[index] = person;
        }

        public void UpdateCatalog(Catalog catalog) {
           foreach(KeyValuePair<long, Catalog> pair in dataContext.Books)
           {
                if (pair.Value.Code == catalog.Code)
                {
                    dataContext.Books[pair.Key] = catalog;
                    return;
                }
           }
           throw new ItemDoesNotExistException(catalog, dataContext.Books);
        }

        public void UpdateTransaction(Event transaction) {
            int index = dataContext.Transactions.IndexOf(transaction);

            if (index == -1)
                throw new ItemDoesNotExistException(transaction, dataContext.Transactions);

            dataContext.Transactions[index] = transaction;
        }

        public void UpdateStateDescription(StateDescription description) {
            int index = dataContext.Descriptions.IndexOf(description);

            if(index == -1)
                throw new ItemDoesNotExistException(description, dataContext.Descriptions);

            dataContext.Descriptions[index] = description;
        }

        // Delete

        public void DeletePerson(Person person)
        {
            if(!dataContext.Clients.Remove(person))
                throw new ItemDoesNotExistException(person, dataContext.Clients);
        }

        public void DeleteCatalog(Catalog catalog)
        {
            foreach(KeyValuePair<long, Catalog> pair in dataContext.Books)
            {
                if (pair.Value.Code == catalog.Code)
                {
                    dataContext.Books.Remove(pair.Key);
                    return;
                }
            }

            throw new ItemDoesNotExistException(catalog, dataContext.Books);
        }

        public void DeleteTransaction(Event transaction)
        {
            if(!dataContext.Transactions.Remove(transaction))
                throw new ItemDoesNotExistException(transaction, dataContext.Transactions);
        }

        public void DeleteStateDescription(StateDescription stateDescription)
        {
            if(!dataContext.Descriptions.Remove(stateDescription))
                throw new ItemDoesNotExistException(stateDescription, dataContext.Descriptions);
        }

        public void DeletePersonByIndex(int index)
        {
            dataContext.Clients.RemoveAt(index);
        }

        public void DeleteCatalogByKey(long key)
        {
            if(!dataContext.Books.Remove(key))
                throw new ItemDoesNotExistException(key, dataContext.Books);
        }

        public void DeleteTransactionByIndex(int index)
        {
            dataContext.Transactions.RemoveAt(index);

        }

        public void DeleteStateDescriptionByIndex(int index)
        {
            dataContext.Descriptions.RemoveAt(index);
        }
        

    }
}
