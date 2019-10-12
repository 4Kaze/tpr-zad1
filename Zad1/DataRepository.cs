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
    }
}
