using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializationModule;
using Classes;

namespace TestsOfSerializations
{
    [TestClass]
    public class OwnSerializationTest
    {
        [TestMethod]
        public void SerilizeDeserializeCheck()
        {
            /*
            OwnSerialization own = new OwnSerialization();

            DataContext dataContext = new DataContext();
            DataContext deserializedContext = new DataContext();
            FillConstant fillConstant = new FillConstant();
            fillConstant.FillData(dataContext);

            own.Serialize(dataContext);
            deserializedContext = own.Deserialize();
            Assert.AreEqual(dataContext.Clients[0].ToString(), deserializedContext.Clients[0].ToString());
*/
        }
    }
}
