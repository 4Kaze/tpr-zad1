using Classes;

namespace TestsOfSerializations
{
    public class FillSerialization : IFillInterface
    {
        public void FillData(DataContext dataContext)
        {
            // Person Data FIll
            Person person1 = new Person("Marcus", "Sagthon", "Michelles 42");
            Person person2 = new Person("Ugho", "Olkag", "Putar 34");
            Person person3 = new Person("Toby", "Vercer", "Palatem 51");

            dataContext.Clients.Add(person1);
            dataContext.Clients.Add(person2);
            dataContext.Clients.Add(person3);

            // Catalog Data Fill

            Catalog catalog1 = new Catalog("Pride and Prejudice", "This is description1", "Jane Austen");
            Catalog catalog2 = new Catalog("War and Peace", "This is description2", "Lew Tolstoj");
            Catalog catalog3 = new Catalog("Metro 2033", "This is description3", "Dimitry Glukhovsky");

            dataContext.Books.Add(1, catalog1);
            dataContext.Books.Add(2, catalog2);
            dataContext.Books.Add(3, catalog3);

            // StateDescription Data Fill
            StateDescription stateDescription1 = new StateDescription(catalog1, System.DateTimeOffset.Now, "Somewhere");
            StateDescription stateDescription2 = new StateDescription(catalog2, System.DateTimeOffset.Now, "There");
            StateDescription stateDescription3 = new StateDescription(catalog3, System.DateTimeOffset.Now, "Here");
            StateDescription stateDescription4 = new StateDescription(catalog2, System.DateTimeOffset.Now, "Here");

            dataContext.Descriptions.Add(stateDescription1);
            dataContext.Descriptions.Add(stateDescription2);
            dataContext.Descriptions.Add(stateDescription3);

            //Event Data Fill
            System.DateTimeOffset date1 = System.DateTimeOffset.Now;
            Event happening1 = new BorrowEvent(person1, stateDescription1, date1);
            Event happening2 = new BorrowEvent(person2, stateDescription1, date1);
            Event happening3 = new ReturnEvent(person1, stateDescription1, System.DateTimeOffset.Now);

            dataContext.Transactions.Add(happening1);
            dataContext.Transactions.Add(happening2);
            dataContext.Transactions.Add(happening3);
        }
    }
}
