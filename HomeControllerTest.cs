using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ProjetoFinal.Controllers;
using ProjetoFinal.Models;

namespace ProjetoFinal.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_DeveRetornarView()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var resultado = controller.Index();

            // Assert
            Assert.IsInstanceOfType<ViewResult>(resultado);
        }

        [TestMethod]
        public void Privacy_DeveRetornarView()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var resultado = controller.Privacy();

            // Assert
            Assert.IsInstanceOfType<ViewResult>(resultado);
        }
 

        [TestMethod]
            public void Error_DeveRetornarViewComModeloDeErro()
            {
                // Arrange
                var controller = new HomeController();

                controller.ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                };

                // Act
                var resultado = controller.Error();

                // Assert
                var view = resultado as ViewResult;

                Assert.IsNotNull(view);
                Assert.IsNotNull(view.Model);
                Assert.IsTrue(view.Model is ErrorViewModel);
            }


}
}
