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


    }
}
