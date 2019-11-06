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

        private string[] firstNames = { "Mark", "Shaun", "Linda", "Laura", "Sam", "Travis", "Marisha", "Liam", "Ashley", "Talisian" };
        private string[] secondNames = { "Torck", "Breuer", "Samberg", "Pickock", "Bauger", "Lewisky", "McScott", "Olivers", "Shaumbach", "Pvaretti" };
        private string[] address = { "Pickand 12", "St Johns 51", "Pilbers 42", "Southernt 1", "Schunzen 9", "Olkies 24", "St ulwen 37", "Libritz 91", "Uge 42", "Pvara 42" };
        private string[] titles = { "Topic 1", "Topic 2", "Topic 3", "Topic 4", "Topic 5", "Topic 6", "Topic 7", "Topic 8", "Topic 9", "Topic 10" };
        private string[] descriptions = { "Description 1", "Description 2", "Description 3", "Description 4", "Description 5", "Description 6", "Description 7", "Description 8", "Description 9", "Description 10" };
        private string[] places = { "Place 1", "Place 2", "Place 3", "Place 4", "Place 5", "Place 6", "Place 7", "Place 8", "Place 9", "Place 10" };


        public void FillData(DataContext dataContext)
        {
            for(int i = 0; i < 25; i++)
            {
                Event e = CreateEvent();
                dataContext.Transactions.Add(e);
                dataContext.Clients.Add(e.Causer);
                dataContext.Descriptions.Add(e.BookState);
                dataContext.Books.Add(i, e.BookState.Book);
            }
        }


        public Person CreatePerson()
        {
            return new Person(this.getRandomString(firstNames), this.getRandomString(secondNames), this.getRandomString(address));
        }


        public string CreateAuthor()
        {
            return this.getRandomString(firstNames) + " " + this.getRandomString(secondNames);
        }


        public Catalog CreateCatalog()
        {
            return new Catalog(this.getRandomString(firstNames), this.getRandomString(secondNames), CreateAuthor());
        }


        public StateDescription CreateStateDescription()
        {
            return new StateDescription(CreateCatalog(), getRandomDate(), this.getRandomString(places));
        }


        public Event CreateEvent()
        {
            Array values = Enum.GetValues(typeof(Event.EventType));
            Event.EventType randomType = (Event.EventType)values.GetValue(random.Next(values.Length));
            return new Event(CreatePerson(), CreateStateDescription(), randomType, getRandomDate());
        }


        private string getRandomString(string[] data)
        {
            return data[this.random.Next(10)];
        }

        private DateTimeOffset getRandomDate()
        {
            DateTimeOffset start = DateTimeOffset.ParseExact("01/01/1900", "dd/MM/yyyy", null);
            DateTimeOffset end = DateTimeOffset.Now;
            start.AddMinutes(random.Next(0, end.Subtract(start).Minutes - 1));
            return start;
        }

    }
}
