using System;

namespace Zad1
{
    public class DataRepository
    {
        private long catalogKey;
        private DataContext dataManagment;
        private IFillInterface fillInterface;

        public long CatalogKey
        {
            get { return this.catalogKey; }
        }

        public DataRepository(IFillInterface fillInterface)
        {
            this.catalogKey = 0;
            this.fillInterface = fillInterface;
            dataManagment = new DataContext();
            this.fillInterface.FillData(dataManagment);
        }


        public DataRepository()
        {
            dataManagment = new DataContext();
        }


        // Person Operations
        public void AddPerson(Person person)
        {
            dataManagment.clients.Add(person);
        }


        public int DeletePersonByReference(Person person)
        {
            if (dataManagment.clients.Contains(person))
            {
                dataManagment.clients.Remove(person);
                return 0;
            }
            return 1;
        }


        public int DeletePersonByIndex(int index)
        {
            if (dataManagment.clients.Count > index)
            {
                dataManagment.clients.RemoveAt(index);
                return 0;
            }
            return 1;
        }


        public Person GetPerson(int index)
        {
            if (dataManagment.clients.Count > index)
            {
                return dataManagment.clients[index];
            }
            else
            {
                return null;
            }
        }

        // Catalog Operations
        public void AddCatalog(Catalog catalog)
        {
            dataManagment.books.Add(this.catalogKey, catalog);
            this.catalogKey += 1;
        }
        


        public int DeleteCatalogByIndex(int index)
        {
            if (dataManagment.books.ContainsKey(index))
            {
                dataManagment.books.Remove(index);
                return 0;
            }
            return 1;
        }


        public Catalog GetCatalog(int index)
        {
            if (dataManagment.books.Count > index)
            {
                return dataManagment.books[index];
            }
            else
            {
                return null;
            }
        }

    }
}
