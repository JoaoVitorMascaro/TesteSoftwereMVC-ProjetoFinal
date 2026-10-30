using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoFinal.Tests
{
    [TestClass]
    public class InstrumentosControllerTests
    {
        [TestMethod]
        public void Index_DeveRetornarView()
        {
            var controller = new InstrumentosController();

            var resultado = controller.index();

            Assert.IsInstanceOfType<ViewResult>(resultado);
        }

        [TestMethod]
        public void Orgao_DeveRetornarView()
        {
            var controller = new InstrumentosController();

            var resultado = controller.Orgao();

            Assert.IsInstanceOfType<ViewResult>(resultado);
        }

        [TestMethod]
        public void Madeiras_DeveRetornarView()
        {
            var controller = new InstrumentosController();

            var resultado = controller.Madeiras();

            Assert.IsInstanceOfType<ViewResult>(resultado);
        }

        [TestMethod]
        public void Metais_DeveRetornarView()
        {
            var controller = new InstrumentosController();

            var resultado = controller.Metais();

            Assert.IsInstanceOfType<ViewResult>(resultado);
        }

        [TestMethod]
        public void Cordas_DeveRetornarView()
        {
            var controller = new InstrumentosController();

            var resultado = controller.Cordas();

            Assert.IsInstanceOfType<ViewResult>(resultado);
        }

        [TestMethod]
        public void Teclas_DeveRetornarView()
        {
            var controller = new InstrumentosController();

            var resultado = controller.Teclas();

            Assert.IsInstanceOfType<ViewResult>(resultado);
        }

        [TestMethod]
        public void Percussao_DeveRetornarView()
        {
            var controller = new InstrumentosController();

            var resultado = controller.Percussao();

            Assert.IsInstanceOfType<ViewResult>(resultado);
        }

        [TestMethod]
        public void AdicionarInstrumentos_DeveRetornarView()
        {
            var controller = new InstrumentosController();

            var resultado = controller.AdicionarInstrumentos();

            Assert.IsInstanceOfType<ViewResult>(resultado);
        }

        [TestMethod]
        public void AdicionarInstrumentos_DeveExigirAutorizacao()
        {
            var metodo = typeof(InstrumentosController)
                .GetMethod(nameof(InstrumentosController.AdicionarInstrumentos));

            Assert.IsNotNull(metodo);

            var atributo = metodo.GetCustomAttributes(
                typeof(AuthorizeAttribute), false);

            Assert.AreEqual(1, atributo.Length);

            var authorize = (AuthorizeAttribute)atributo[0];

            Assert.AreEqual("ADMIN, Admin", authorize.Roles);
        }

        [TestMethod]
        public void Orgao_DeveRetornarViewCorreta()
        {
            var controller = new InstrumentosController();

            var resultado = controller.Orgao() as ViewResult;

            Assert.IsNotNull(resultado);
            Assert.AreEqual("Orgao", nameof(controller.Orgao));
            Assert.IsNull(resultado.ViewName);
        }


        [TestMethod]
        public void AdicionarInstrumentos_DevePermitirSomentePapeisDeAdmin()
        {
            var metodo = typeof(InstrumentosController)
                .GetMethod(nameof(InstrumentosController.AdicionarInstrumentos));

            var atributo = (AuthorizeAttribute?)Attribute.GetCustomAttribute(
                metodo!,
                typeof(AuthorizeAttribute));

            Assert.IsNotNull(atributo);
            Assert.AreEqual("ADMIN, Admin", atributo.Roles);
        }
    }
}
