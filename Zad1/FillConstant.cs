namespace Zad1
{
    public class FillConstant : IFillInterface
    {
        public void FillData(DataContext dataContext)
        {
            // Person Data FIll
            Person person1 = new Person(1, "Marcus", "Sagthon", "Michelles 42");
            Person person2 = new Person(2, "Ugho", "Olkag", "Putar 34");
            Person person3 = new Person(3, "Toby", "Vercer", "Palatem 51");

            dataContext.Clients.Add(person1);
            dataContext.Clients.Add(person2);
            dataContext.Clients.Add(person3);

            // Catalog Data Fill
            System.DateTimeOffset date = System.DateTimeOffset.Now;
            Author author1 = new Author(1, "Jane", "Austen", date);
            Author author2 = new Author(2, "Lew", "Tolstoj", date);
            Author author3 = new Author(3, "Dmitry ", "Glukhovsky", date);

            Catalog catalog1 = new Catalog(1, "Pride and Prejudice", "This is description1", author1);
            Catalog catalog2 = new Catalog(1, "War and Peace", "This is description2", author2);
            Catalog catalog3 = new Catalog(1, "Metro 2033", "This is description3", author3);

            dataContext.Books.Add(1, catalog1);
            dataContext.Books.Add(2, catalog2);
            dataContext.Books.Add(3, catalog3);

            // StateDescription Data Fill
            StateDescription stateDescription1 = new StateDescription(1, catalog1, System.DateTimeOffset.Now, "Somewhere");
            StateDescription stateDescription2 = new StateDescription(2, catalog2, System.DateTimeOffset.Now, "There");
            StateDescription stateDescription3 = new StateDescription(3, catalog3, System.DateTimeOffset.Now, "Here");

            dataContext.Descriptions.Add(stateDescription1);
            dataContext.Descriptions.Add(stateDescription2);
            dataContext.Descriptions.Add(stateDescription3);

            //Event Data Fill
            System.DateTimeOffset date1 = System.DateTimeOffset.Now;
            Event happening1 = new Event(1, person1, stateDescription1, date1);
            Event happening2 = new Event(2, person2, stateDescription1, date1);
            Event happening3 = new Event(3, person3, stateDescription1, date1);

            dataContext.Transactions.Add(happening1);
            dataContext.Transactions.Add(happening2);
            dataContext.Transactions.Add(happening3);
        }
    }
}
