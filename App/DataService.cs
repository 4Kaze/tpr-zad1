using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Zad1;

namespace App
{
    public class DataService
    {
        private IRepositoryInterface repositoryInterface;
        public DataService(IRepositoryInterface repositoryInterface)
        {
            this.repositoryInterface = repositoryInterface;
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


        //zaczynając od elementów wykazu(np.czytelnicy, klienci),
        //za nimi zdarzenia odpowiadające kolejnym elementom wykazu(np.wypożyczenia książek, faktury),
        //które przechodząc przez opisy stanu będą indentyfikować pozycje katalogu(np.wypożyczone książki, zakupione towary).


        public string FullView()
        {
            string answer = "";
            foreach (Person person in repositoryInterface.GetAllPersons())
            {
                answer += person.ToString() + "\n";
                foreach(Event happening in repositoryInterface.GetAllTransactions())
                {
                    if(happening.Causer == person)
                    {
                        answer += happening.BookState.Book.ToString() + "\n";
                    }
                }
            }
            return answer;
        }


    }
}
