using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicePruebaUnitaria;

namespace CapaPruebaUnitaria
{
    [TestClass]
    public class UnitTestLoginUser
    {
        ServiceUsuarioClient client = new ServiceUsuarioClient();
        [TestMethod]
        public void TestLoginTrue()
        {
            //Arrange
            string username = "Admin";
            string password = "Admin";

            //Act
            bool result = client.LoginUsuario(username, password);

            // Assert
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestLoginFalse()
        {
            //Arrange
            string username = "Vicente";
            string password = "253631";

            //Act
            bool result = client.LoginUsuario(username, password);

            // Assert
            Assert.IsFalse(result);

        }
    }
}
