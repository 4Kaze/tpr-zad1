using System;
using System.Collections.Generic;

namespace Zad1
{
    public class DataRepository : IRepositoryInterface
    {
        private DataContext dataContext;
        private IFillInterface IfillInterface;

        public DataRepository(IFillInterface fillInterface)
        {
            this.IfillInterface = fillInterface;
            this.dataContext = new DataContext();
            this.IfillInterface.FillData(dataContext);
        }


        public DataRepository()
        {
            this.dataContext = new DataContext();
        }

        // Add
        public void AddPerson(Person person)
        {
            if (!dataContext.Clients.Contains(person))
                dataContext.Clients.Add((Person)person.Clone());
            else
                throw new ItemAlreadyExistsException(person, dataContext.Clients);
        }

        public void AddCatalog(Catalog catalog)
        {
            if (!dataContext.Books.ContainsKey(catalog.Code))
                dataContext.Books.Add(catalog.Code, (Catalog)catalog.Clone());
            else
                throw new ItemAlreadyExistsException(catalog, dataContext.Books);
        }

        public void AddTransaction(Event transaction)
        {
            if (!dataContext.Transactions.Contains(transaction))
                dataContext.Transactions.Add((Event)transaction.Clone());
            else
                throw new ItemAlreadyExistsException(transaction, dataContext.Transactions);
        }

        public void AddStateDescription(StateDescription description)
        {
            if (!dataContext.Descriptions.Contains(description))
                dataContext.Descriptions.Add((StateDescription)description.Clone());
            else
                throw new ItemAlreadyExistsException(description, dataContext.Descriptions);
        }

        // Get by code

        public Person GetPersonByCode(long code)
        {
            if(dataContext.Clients.Find(p => p.Code == code) == null)
            {
                return null;
            }
            return (Person)dataContext.Clients.Find(p => p.Code == code).Clone();
        }

        public Catalog GetCatalogByCode(long code)
        {
           foreach(KeyValuePair<long, Catalog> pair in dataContext.Books)
           {
                if(pair.Value.Code == code)
                    return (Catalog)pair.Value.Clone();
           }
           return null;
        }

        public Event GetTransactionByCode(long code)
        {
            foreach(Event transaction in dataContext.Transactions)
            {
                if (transaction.Code == code)
                    return (Event)transaction.Clone();
            }
            return null;
        }

        public StateDescription GetStateDescriptionByCode(long code)
        {
            if (dataContext.Descriptions.Find(d => d.Code == code) == null)
            {
                return null;
            }
            return (StateDescription)dataContext.Descriptions.Find(d => d.Code == code).Clone();
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



        //Update
        public void UpdatePerson(Person person) {
            int index = dataContext.Clients.IndexOf(person);

            if(index == -1)
                throw new ItemDoesNotExistException(person, dataContext.Clients);

            dataContext.Clients[index] = (Person)person.Clone();
        }

        public void UpdateCatalog(Catalog catalog) {
            if(dataContext.Books.ContainsKey(catalog.Code))
            {
                dataContext.Books[catalog.Code] = (Catalog)catalog.Clone();
                return;
            }
            throw new ItemDoesNotExistException(catalog, dataContext.Books);
        }

        public void UpdateTransaction(Event transaction) {
            int index = dataContext.Transactions.IndexOf(transaction);

            if (index == -1)
                throw new ItemDoesNotExistException(transaction, dataContext.Transactions);

            dataContext.Transactions[index] = (Event)transaction.Clone();
        }

        public void UpdateStateDescription(StateDescription description) {
            int index = dataContext.Descriptions.IndexOf(description);

            if(index == -1)
                throw new ItemDoesNotExistException(description, dataContext.Descriptions);

            dataContext.Descriptions[index] = (StateDescription)description.Clone();
        }

        // Delete

        public void DeletePerson(Person person)
        {
            if(!dataContext.Clients.Remove(person))
                throw new ItemDoesNotExistException(person, dataContext.Clients);
        }

        public void DeleteCatalog(Catalog catalog)
        {
            if(dataContext.Books.ContainsKey(catalog.Code))
            {
                dataContext.Books.Remove(catalog.Code);
                return;
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

    }
}
