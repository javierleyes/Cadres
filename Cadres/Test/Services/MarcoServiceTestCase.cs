using DAO.Context;
using DAOs.Implements;
using Entidades.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implements;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services
{
    [TestClass]
    public class MarcoServiceTestCase
    {
        private IMarcoService MarcoService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.MarcoService = new MarcoService(new MarcoDAO(new CadresContext()));
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
