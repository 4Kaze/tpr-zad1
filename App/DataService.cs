using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

        public void ViewList(IEnumerable<Object> items)
        {
            string answer = "";
            foreach (Object exampleObject in items)
            {
                answer += exampleObject.ToString() + "\n";
            }
            Console.WriteLine(answer);
        }

        public void ViewList(IEnumerable<KeyValuePair<long, Catalog>> items)
        {
            string answer = "";
            foreach (Object exampleObject in items)
            {
                answer += exampleObject.ToString() + "\n";
            }
            Console.WriteLine(answer);
        }

        public void FullView()
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
            Console.WriteLine(answer);
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

        public void UpdatePersonAtIndex(int index, Person person)
        {
            repository.UpdatePerson(index, person);
        }

        public void UpdateCatalogAtKey(long key, Catalog catalog)
        {
            repository.UpdateCatalog(key, catalog);
        }

        public void UpdateTransactionAtIndex(int index, Event transaction)
        {
            repository.UpdateTransaction(index, transaction);
        }

        public void UpdateStateDescriptionAtIndex(int index, StateDescription description)
        {
            repository.UpdateStateDescription(index, description);
        }

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

        public void DeletePersonByIndex(int index)
        {
            repository.DeletePersonByIndex(index);
        }

        public void DeleteCatalogByKey(long key)
        {
            repository.DeleteCatalogByKey(key);
        }

        public void DeleteTransactionByIndex(int index)
        {
            repository.DeleteTransactionByIndex(index);
        }

        public void DeleteStateDescriptionByIndex(int index)
        {
            repository.DeleteStateDescriptionByIndex(index);
        }



        //Object Creation
        public Person CreatePerson()
        {
            Person person = null; 
            bool runningFlag = true;
            bool decisionFlag = true;
            do
            {
                Console.WriteLine("Podaj imie osoby: ");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Podaj adres: ");
                string adress = Console.ReadLine();
                do
                {
                    Console.WriteLine("Czy jestes pewny, swoich wyborów: Imie - " + name + ", Nazwisko - " + surname + ", Adres - " + adress + ". Tak/tak, by zakonczyc. By zmienić Nie/nie.");
                    string flag = Console.ReadLine();
                    if (flag == "Tak" || flag == "tak")
                    {
                        decisionFlag = false;
                        runningFlag = false;
                        person = new Person(name, surname, adress);
                    }
                    if (flag == "Nie" || flag == "nie")
                    {
                        decisionFlag = false;
                    }
                } while (decisionFlag);
                

            }while (runningFlag);
            return person;
        }


        public Author CreateAuthor()
        {
            Author author = null;
            bool runningFlag = true;
            bool decisionFlag = true;
            do
            {
                Console.WriteLine("Podaj imie osoby: ");
                string name = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko: ");
                string surname = Console.ReadLine();

                DateTimeOffset date = new DateTimeOffset();
                bool dateFlag = true;
                do
                {
                    Console.WriteLine("Podaj date urodzenia: ");
                    string stringDate = Console.ReadLine();
                    if (System.DateTimeOffset.TryParse(stringDate, null as IFormatProvider, DateTimeStyles.AssumeLocal, out date))
                    {
                        dateFlag = false;
                    }
                } while (dateFlag);



                do
                {
                    Console.WriteLine("Czy jestes pewny, swoich wyborów: Imie - " + name + ", Nazwisko - " + surname + ", Data - " + date + ". Tak/tak, by zakonczyc. By zmienić Nie/nie.");
                    string flag = Console.ReadLine();
                    if (flag == "Tak" || flag == "tak")
                    {
                        decisionFlag = false;
                        runningFlag = false;
                        author = new Author(name, surname, date);
                    }
                    if (flag == "Nie" || flag == "nie")
                    {
                        decisionFlag = false;
                    }
                } while (decisionFlag);


            } while (runningFlag);
            return author;
        }

    }
}
