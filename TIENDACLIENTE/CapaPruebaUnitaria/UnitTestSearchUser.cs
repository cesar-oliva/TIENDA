using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicePruebaUnitaria;

namespace CapaPruebaUnitaria
{
    [TestClass]
    public class UnitTestSearchUser
    {
        ServiceUsuarioClient client = new ServiceUsuarioClient();
        [TestMethod]
        public void TestSearchEmailUserTrue()
        {
            //Arrange
            string username = "Mariela";
            //Act
            var result = client.ObtenerUsuarioByNombre(username);

            // Assert
            Assert.AreNotEqual("Mariela@gmail.com", result.Email);
        }
    }
}


