using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Classes
{
    public class DataService
    {
        private IRepositoryInterface repository;
        public DataService(IRepositoryInterface repositoryInterface)
        {
            this.repository = repositoryInterface;
        }

        public void BorrowBook(Person person, long bookStateCode)
        {
            StateDescription state = repository.GetStateDescriptionByCode(bookStateCode);
            if (state == null) throw new ItemDoesNotExistException(bookStateCode, typeof(StateDescription));
            if (!state.Availabile) throw new BookUnavailableException(state);

            state.Availabile = false;
            repository.AddTransaction(new Event(person, state, Event.EventType.Borrow, DateTimeOffset.Now));
        }

        public void ReturnBook(long bookStateCode)
        {
            StateDescription state = repository.GetStateDescriptionByCode(bookStateCode);
            if (state == null) throw new ItemDoesNotExistException(bookStateCode, typeof(StateDescription));
            if (!state.Availabile) throw new BookNotUnavailableException(state);

            Person person = GetPersonByBorrowedBook(state);
            state.Availabile = true;
            repository.AddTransaction(new Event(person, state, Event.EventType.Return, DateTimeOffset.Now));
        }

        // Add
        public void AddPerson(Person person)
        {
            repository.AddPerson(person);
        }

        public void AddCatalog(Catalog catalog)
        {
            repository.AddCatalog(catalog);
        }

        public void AddTransaction(Event transaction)
        {
            repository.AddTransaction(transaction);
        }

        public void AddStateDescription(StateDescription description)
        {
            repository.AddStateDescription(description);
        }

        // Get by code

        public Person GetPersonByCode(long code)
        {
            return repository.GetPersonByCode(code);
        }

        public Catalog GetCatalogByCode(long code)
        {
            return repository.GetCatalogByCode(code);
        }

        public Event GetTransactionByCode(long code)
        {
            return repository.GetTransactionByCode(code);
        }

        public StateDescription GetStateDescriptionByCode(long code)
        {
            return repository.GetStateDescriptionByCode(code);
        }


        public Person GetPersonByBorrowedBook(StateDescription book)
        {
            if (book.Availabile) throw new BookNotUnavailableException(book);

            foreach(Event transaction in GetAllTransactions())
            {
                if (transaction.BookState.Code == book.Code)
                    return transaction.Causer;
            }

            throw new ItemDoesNotExistException(string.Format("Could not find person who borrowed {0}", book));
        }

        // GetAll

        public IEnumerable<Person> GetAllPersons()
        {
            return repository.GetAllPersons();
        }

        public IEnumerable<KeyValuePair<long, Catalog>> GetAllCatalogs()
        {
            return repository.GetAllCatalogs();
        }

        public IEnumerable<Event> GetAllTransactions()
        {
            return repository.GetAllTransactions();
        }

        public IEnumerable<StateDescription> GetAllStateDescriptions()
        {
            return repository.GetAllStateDescriptions();
        }

        public List<Catalog> GetBooksByPerson(Person person)
        {
            List<Catalog> books = new List<Catalog>();

            foreach(Event transaction in GetAllTransactionsByPerson(person))
            {
                if (!books.Contains(transaction.BookState.Book))
                    books.Add(transaction.BookState.Book);
            }

            return books;
        }

        public List<Event> GetTransactionsByPersonWithBook(Person person, Catalog catalog)
        {
            List<Event> eventList = new List<Event>();
            foreach (Event transaction in GetAllTransactions())
            {
                if(transaction.BookState.Book.Equals(catalog) && transaction.Causer.Equals(person))
                {
                    eventList.Add(transaction);
                }
            }

            return eventList;
        }

        public List<Event> GetAllTransactionsByPerson(Person person)
        {
            List<Event> eventList = new List<Event>();

            foreach(Event transaction in GetAllTransactions())
            {
                if (transaction.Causer.Equals(person))
                    eventList.Add(transaction);
            }

            return eventList;
        }

        public List<Event> GetAllTransactionsByBook(Catalog book)
        {
            List<Event> eventList = new List<Event>();

            foreach (Event transaction in GetAllTransactions())
            {
                if (transaction.BookState.Book.Equals(book))
                    eventList.Add(transaction);
            }

            return eventList;
        }

        public List<Event> GetAllTransactionsByBookState(StateDescription bookState)
        {
            List<Event> eventList = new List<Event>();

            foreach (Event transaction in GetAllTransactions())
            {
                if (transaction.BookState.Equals(bookState))
                    eventList.Add(transaction);
            }

            return eventList;
        }

        // Update

        public void UpdatePerson(Person person)
        {
            repository.UpdatePerson(person);
        }

        public void UpdateCatalog(Catalog catalog)
        {
            repository.UpdateCatalog(catalog);
        }

        public void UpdateTransaction(Event transaction)
        {
            repository.UpdateTransaction(transaction);
        }

        public void UpdateStateDescription(StateDescription description)
        {
            repository.UpdateStateDescription(description);
        }


        // Delete

        public void DeletePerson(Person person)
        {
            repository.DeletePerson(person);
        }

        public void DeleteCatalog(Catalog catalog)
        {
            repository.DeleteCatalog(catalog);
        }

        public void DeleteTransaction(Event transaction)
        {
            repository.DeleteTransaction(transaction);
        }

        public void DeleteStateDescription(StateDescription stateDescription)
        {
            repository.DeleteStateDescription(stateDescription);
        }

    }
}
