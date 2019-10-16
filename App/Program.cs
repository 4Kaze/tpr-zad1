using System;
using Zad1;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService(new DataRepository(new FillFileData()));
            dataService.ViewList(dataService.GetAllPersons());
            //dataService.ViewList(dataService.GetAllStateDescriptions());
            //dataService.ViewList(dataService.GetAllTransactions());
            //dataService.ViewList(dataService.GetAllCatalogs());

            //dataService.FullView();

            //dataService.(dataService.CreatePerson());
            //dataService.ViewList(dataService.GetAllPersons());

            //Author author = dataService.CreateAuthor();
            //Console.WriteLine(author.ToString());

            int userInput = Console.Read();
        }
    }
}
