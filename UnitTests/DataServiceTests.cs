using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Zad1;
using App;

namespace UnitTests
{
    [TestClass]
    public class DataServiceTests
    {
        public object MessageBox { get; private set; }

        [TestMethod]
        public void DataServiceConstructorTest()
        {
            DataService dataService = new DataService(new DataRepository(new FillConstant()));
        }


        [TestMethod]
        public void DataServiceGenerateViewOfList()
        {
            // nie wiem jak to stestowac
            DataService dataService = new DataService(new DataRepository(new FillConstant()));
            IFillInterface fillInterface = new FillRandom();
            DataContext dataContext = new DataContext();
            fillInterface.FillData(dataContext);
        }


        [TestMethod]
        public void DataServiceAllView()
        {
            // nie wiem jak to stestowac
            DataService dataService = new DataService(new DataRepository(new FillConstant()));
            IFillInterface fillInterface = new FillRandom();
            DataContext dataContext = new DataContext();
            fillInterface.FillData(dataContext);
        }

    }
}