using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public interface IRepositoryInterface
    {

        // Add
        void AddPerson(Person person);
        void AddCatalog(Catalog catalog);
        void AddTransaction(Event transaction);
        void AddStateDescription(StateDescription description);



        // Get by code
        Person GetPersonByCode(long code);
        Catalog GetCatalogByCode(long code);
        Event GetTransactionByCode(long code);
        StateDescription GetStateDescriptionByCode(long code);


        // GetAll
        IEnumerable<Person> GetAllPersons();
        IEnumerable<KeyValuePair<long, Catalog>> GetAllCatalogs();
        IEnumerable<Event> GetAllTransactions();
        IEnumerable<StateDescription> GetAllStateDescriptions();


        // Update
        void UpdatePerson(int index, Person person);
        void UpdateCatalog(long key, Catalog catalog);
        void UpdateTransaction(int index, Event transaction);
        void UpdateStateDescription(int index, StateDescription description);
        void UpdatePerson(Person person);
        void UpdateCatalog(Catalog catalog);
        void UpdateTransaction(Event transaction);
        void UpdateStateDescription(StateDescription description);


        // Delete
        void DeletePerson(Person person);
        void DeleteCatalog(Catalog catalog);
        void DeleteTransaction(Event transaction);
        void DeleteStateDescription(StateDescription stateDescription);
        void DeletePersonByIndex(int index);
        void DeleteCatalogByKey(long key);
        void DeleteTransactionByIndex(int index);
        void DeleteStateDescriptionByIndex(int index);
    }
}
