using System;
using Zad1;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {

            IFillInterface fillInterface = new FillFileData();
            DataContext dataContext = new DataContext();
            fillInterface.FillData(dataContext);
            int userInput = Console.Read();
        }
    }
}
