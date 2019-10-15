using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zad1;

namespace App
{
    public class DataService
    {
        private IRepositoryInterface repository;
        public DataService(IRepositoryInterface repositoryInterface)
        {
            this.repository = repositoryInterface;
        }

        public string ViewList(IEnumerable<Object> items)
        {
            string answer = "";
            foreach (Object exampleObject in items)
            {
                answer += exampleObject.ToString() + "\n";
            }
            return answer;
        }

        public string ViewList(Dictionary<long, Catalog> items)
        {
            string answer = "";
            foreach (Object exampleObject in items)
            {
                answer += exampleObject.ToString() + "\n";
            }
            return answer;
        }

        public string FullView()
        {
            string answer = "";
            foreach (Person person in repository.GetAllPersons())
            {
                answer += person.ToString() + "\n";
                foreach(Event happening in repository.GetAllTransactions())
                {
                    if(happening.Causer.Equals(person))
                    {
                        answer += "\t" + happening.ToString() + "\n";
                        answer += "\t\t" + happening.BookState.Book.ToString() + "\n";
                    }
                }
            }
            return answer;
        }

        public int BorrowBook(Person person, long bookStateCode)
        {
            StateDescription state = repository.GetStateDescriptionByCode(bookStateCode);
            if (state == null) return 0;
            if (!state.Availabile) return 0;

            state.Availabile = false;
            repository.AddTransaction(new Event(person, state, DateTimeOffset.Now));

            return 1;
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

        // Update

        public int UpdatePersonAtIndex(int index, Person person)
        {
            return repository.UpdatePerson(index, person);
        }

        public int UpdateCatalogAtKey(long key, Catalog catalog)
        {
            return repository.UpdateCatalog(key, catalog);
        }

        public int UpdateTransactionAtIndex(int index, Event transaction)
        {
            return repository.UpdateTransaction(index, transaction);
        }

        public int UpdateStateDescriptionAtIndex(int index, StateDescription description)
        {
            return repository.UpdateStateDescription(index, description);
        }

        public int UpdatePerson(Person person)
        {
            return repository.UpdatePerson(person);
        }

        public int UpdateCatalog(Catalog catalog)
        {
            return repository.UpdateCatalog(catalog);
        }

        public int UpdateTransaction(Event transaction)
        {
            return repository.UpdateTransaction(transaction);
        }

        public int UpdateStateDescription(StateDescription description)
        {
            return repository.UpdateStateDescription(description);
        }

        public int DeletePerson(Person person)
        {
            return repository.DeletePerson(person);
        }

        public int DeleteCatalog(Catalog catalog)
        {
            return repository.DeleteCatalog(catalog);
        }

        public int DeleteTransaction(Event transaction)
        {
            return repository.DeleteTransaction(transaction);
        }

        public int DeleteStateDescription(StateDescription stateDescription)
        {
            return repository.DeleteStateDescription(stateDescription);
        }

        public int DeletePersonByIndex(int index)
        {
            return repository.DeletePersonByIndex(index);
        }

        public int DeleteCatalogByKey(long key)
        {
            return repository.DeleteCatalogByKey(key);
        }

        public int DeleteTransactionByIndex(int index)
        {
            return repository.DeleteTransactionByIndex(index);
        }

        public int DeleteStateDescriptionByIndex(int index)
        {
            return repository.DeleteStateDescriptionByIndex(index);
        }


    }
}
