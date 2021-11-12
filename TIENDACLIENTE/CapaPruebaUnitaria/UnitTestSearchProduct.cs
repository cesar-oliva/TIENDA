using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceProducto;

namespace CapaPruebaUnitaria
{
    [TestClass]
    public class UnitTestSearchProduct
    {
        ServiceProductoClient client = new ServiceProductoClient();

        [TestMethod]
        public void TestSearcDescriptionProduct()
        {
            //Arrange
            int idProducto = 7;
            //Act
            var result = client.BuscarProductoById(idProducto);

            // Assert
            Assert.AreEqual("REMERA", result.Descripcion);
        }
        [TestMethod]
        public void TestSearchCostProduct()
        {
            //Arrange
            int idProducto = 6;
            //Act
            var result = client.BuscarProductoById(idProducto);

            // Assert
            Assert.AreEqual(1000.00d, result.Costo);

        }
    }
}
