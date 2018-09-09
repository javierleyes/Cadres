using Entidades.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Services.Interfaces;
using System;
using Test.Ninject;

namespace Test.Services
{
    [TestClass]
    public class MarcoServiceTestCase
    {
        private IMarcoService MarcoService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            StandardKernel kernel = Bindings.LoadDependancy();

            this.MarcoService = kernel.Get<IMarcoService>();
        }

        [TestMethod]
        public void CalcularPrecio_OK()
        {
            VarillaDTO varillaDTO = new VarillaDTO()
            {
                Ancho = Convert.ToDecimal(4.5),
                Precio = Convert.ToDecimal(45.5),
            };

            MarcoDTO marcoDTO = new MarcoDTO()
            {
                Ancho = Convert.ToDecimal(40.5),
                Largo = Convert.ToDecimal(20.5),
                Varilla = varillaDTO,
            };

            marcoDTO.Precio = this.MarcoService.CalcularPrecio(marcoDTO);

            Assert.AreEqual(marcoDTO.Precio, Convert.ToDecimal(71.89));
        }

    }
}
