using System;

namespace Zad1
{
    public class DataRepository
    {
        private DataContext dataManagment;
        public DataRepository()
        {
            dataManagment = new DataContext();
        }



        public void AddPerson(Person person)
        {
            dataManagment.clients.Add(person);
        }


        public void DeletePersonByReference(Person person)
        {
            if (dataManagment.clients.Contains(person))
            {
                dataManagment.clients.Remove(person);
            }
        }


        public void DeletePersonByIndex(int index)
        {
            if (dataManagment.clients.Count > index)
            {
                dataManagment.clients.RemoveAt(index);
            }
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
    }
}
