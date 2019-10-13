using System;
using System.Collections.Generic;

namespace Zad1
{
    public class DataRepository
    {
        private long catalogKey;
        private DataContext dataContext;
        private IFillInterface fillInterface;

        public long CatalogKey
        {
            get { return this.catalogKey; }
        }

        public DataRepository(IFillInterface fillInterface)
        {
            this.catalogKey = 0;
            this.fillInterface = fillInterface;
            this.dataContext = new DataContext();
            this.fillInterface.FillData(dataContext);
        }


        public DataRepository()
        {
            this.catalogKey = 0;
            this.dataContext = new DataContext();
        }


        // Person Operations
        public void AddPerson(Person person)
        {
            dataContext.Clients.Add(person);
        }


        public int DeletePersonByReference(Person person)
        {
            if (dataContext.Clients.Contains(person))
            {
                dataContext.Clients.Remove(person);
                return 1;
            }
            return 0;
        }


        public int DeletePersonByIndex(int index)
        {
            if (dataContext.Clients.Count > index)
            {
                dataContext.Clients.RemoveAt(index);
                return 1;
            }
            return 0;
        }

        public List<Person> GetAllPersons()
        {
            return dataContext.Clients;
        }



        public Person GetPerson(int index)
        {
            if (dataContext.Clients.Count > index)
            {
                return dataContext.Clients[index];
            }
            else
            {
                return null;
            }
        }

        // Catalog Operations
        public void AddCatalog(Catalog catalog)
        {
            dataContext.Books.Add(this.catalogKey++, catalog);
        }
        


        public int DeleteCatalogByIndex(int index)
        {
            if (dataContext.Books.ContainsKey(index))
            {
                dataContext.Books.Remove(index);
                return 1;
            }
            return 0;
        }


        public Dictionary<long, Catalog> GetAllCatalogs()
        {
            return dataContext.Books;
        }


        public Catalog GetCatalog(int index)
        {
            if (dataContext.Books.Count > index)
            {
                return dataContext.Books[index];
            }
            else
            {
                return null;
            }
        }

    }
}
