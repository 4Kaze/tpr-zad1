using System;
using Zad1;

namespace App
{
    public class FillRandom : IFillInterface
    {

        private Random random;

        public FillRandom()
        {
            this.random = new Random();
        }

        public void FillData(DataContext dataContext)
        {
            string[] firstNames = {"Mark", "Shaun", "Linda", "Laura", "Sam", "Travis", "Marisha", "Liam", "Ashley", "Talisian"};
            string[] secondNames = { "Torck", "Breuer", "Samberg", "Pickock", "Bauger", "Lewisky", "McScott", "Olivers", "Shaumbach", "Pvaretti" };
            string[] address = { "Pickand 12", "St Johns 51", "Pilbers 42", "Southernt 1", "Schunzen 9", "Olkies 24", "St ulwen 37", "Libritz 91", "Uge 42", "Pvara 42" };
            string[] titles = { "Topic 1", "Topic 2", "Topic 3", "Topic 4", "Topic 5", "Topic 6", "Topic 7", "Topic 8", "Topic 9", "Topic 10" };
            string[] descriptions = { "Description 1", "Description 2", "Description 3", "Description 4", "Description 5", "Description 6", "Description 7", "Description 8", "Description 9", "Description 10" };
            string[] places = { "Place 1", "Place 2", "Place 3", "Place 4", "Place 5", "Place 6", "Place 7", "Place 8", "Place 9", "Place 10" };



            // Person Data FIll
            Person person1 = this.CreatePerson(1, firstNames, secondNames, address);
            Person person2 = this.CreatePerson(2, firstNames, secondNames, address);
            Person person3 = this.CreatePerson(3, firstNames, secondNames, address);

            dataContext.Clients.Add(person1);
            dataContext.Clients.Add(person2);
            dataContext.Clients.Add(person3);



            // Catalog Data Fill
            Author author1 = this.CreateAuthor(1, firstNames, secondNames);
            Author author2 = this.CreateAuthor(2, firstNames, secondNames);
            Author author3 = this.CreateAuthor(3, firstNames, secondNames);

            Catalog catalog1 = CreateCatalog(1, titles, descriptions, author1);
            Catalog catalog2 = CreateCatalog(2, titles, descriptions, author2);
            Catalog catalog3 = CreateCatalog(3, titles, descriptions, author3);


            dataContext.Books.Add(1, catalog1);
            dataContext.Books.Add(2, catalog2);
            dataContext.Books.Add(3, catalog3);


            // StateDescription Data Fill
            StateDescription stateDescription1 = this.CreateStateDescription(1, catalog1, places);
            StateDescription stateDescription2 = this.CreateStateDescription(2, catalog2, places);
            StateDescription stateDescription3 = this.CreateStateDescription(3, catalog3, places);

            dataContext.Descriptions.Add(stateDescription1);
            dataContext.Descriptions.Add(stateDescription2);
            dataContext.Descriptions.Add(stateDescription3);


            //Event Data Fill
            Event happening1 = this.CreateEvent(1, person1, stateDescription1);
            Event happening2 = this.CreateEvent(2, person2, stateDescription2);
            Event happening3 = this.CreateEvent(3, person3, stateDescription3);

            dataContext.Transactions.Add(happening1);
            dataContext.Transactions.Add(happening2);
            dataContext.Transactions.Add(happening3);
        }


        public Person CreatePerson(int id, string[] names, string[] surnames, string[] address)
        {
            return new Person(id, this.RandString(names), this.RandString(surnames), this.RandString(address));
        }


        public Author CreateAuthor(int id, string[] names, string[] surnames)
        {
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            return new Author(id, this.RandString(names), this.RandString(surnames), date);
        }


        public Catalog CreateCatalog(int id, string[] titles, string[] descriptions, Author author)
        {
            return new Catalog(id, this.RandString(titles), this.RandString(descriptions), author);
        }


        public StateDescription CreateStateDescription(int id, Catalog catalog, string[] places)
        {
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            return new StateDescription(id, catalog, date, this.RandString(places));
        }


        public Event CreateEvent(int id, Person person, StateDescription stateDescription)
        {
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            return new Event(id, person, stateDescription, date);
        }


        public string RandString(string[] data)
        {
            return data[this.random.Next(10)];
        }
    }
}
