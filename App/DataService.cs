using System;
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
    }
}
