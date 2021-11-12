using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapaPrueba
{
    [TestClass]
    public class UnitTestLogin
    {
        [TestMethod]
        public void TestLoginTrue()
        {
            //Arrange
            string user = "Admin";
            string password = "Admin";

            ////Act
            //bool result = CapaDatos.BD_Usuario.LoginUsuario(user, password);

            //// Assert
            //Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestLoginFalse()
        {
            //Arrange
            string user = "Excequiel";
            string password = "253631";

            //Act
            //bool result = CapaDatos.BD_Usuario.LoginUsuario(user, password);

            //Assert
            //Assert.AreEqual(false, result);

        }
    }
}
