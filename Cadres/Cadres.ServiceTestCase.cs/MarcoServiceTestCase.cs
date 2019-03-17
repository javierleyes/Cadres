using Cadres.Dto;
using Cadres.IoD.Ninject;
using Cadres.Service.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Cadres.ServiceTestCase.cs
{
    [TestClass]
    public class MarcoServiceTestCase
    {
        public IMarcoService MarcoService { get; set; }

        public StandardKernel kernel { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            this.kernel = StartUp.Initialize();

            this.MarcoService = kernel.Get<IMarcoService>();
        }

        [TestMethod]
        public void CrearMarco_Ok()
        {
            MarcoDTO marcoDTO = this.CrearMarcoDTO();

            MarcoDTO marco = this.MarcoService.CrearMarco(marcoDTO);

            Assert.IsTrue(marco.Numero != 0);
            Assert.AreEqual(marco.Ancho, 63);
            Assert.AreEqual(marco.Ancho, 63);
            Assert.AreEqual(marco.Estado, "Pendiente");
            Assert.AreNotEqual(marco.VarillaId, 0);
            Assert.AreNotEqual(marco.Precio, 0);
        }

        private MarcoDTO CrearMarcoDTO()
        {
            return new MarcoDTO()
            {
                Ancho = 63,
                Largo = 65,
                VarillaId = 2,
            };
        }
    }
}
