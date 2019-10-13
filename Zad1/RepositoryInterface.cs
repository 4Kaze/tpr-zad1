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


        // Get by index
        Person GetPerson(int index);
        Catalog GetCatalog(long key);
        Event GetTransaction(int index);
        StateDescription GetStateDescription(int index);


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
        int UpdatePerson(int index, Person person);
        int UpdateCatalog(long key, Catalog catalog);
        int UpdateTransaction(int index, Event transaction);
        int UpdateStateDescription(int index, StateDescription description);
        int UpdatePerson(Person person);
        int UpdateCatalog(Catalog catalog);
        int UpdateTransaction(Event transaction);
        int UpdateStateDescription(StateDescription description);


        // Delete
        int DeletePerson(Person person);
        int DeleteCatalog(Catalog catalog);
        int DeleteTransaction(Event transaction);
        int DeleteStateDescription(StateDescription stateDescription);
        int DeletePersonByIndex(int index);
        int DeleteCatalogByKey(long key);
        int DeleteTransactionByIndex(int index);
        int DeleteStateDescriptionByIndex(int index);
    }
}
