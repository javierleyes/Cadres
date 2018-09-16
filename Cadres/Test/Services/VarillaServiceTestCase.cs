using Entidades.DTO;
using Entidades.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Common;
using Test.Ninject;

namespace Test.Services
{
    [TestClass]
    public class VarillaServiceTestCase
    {
        private IVarillaService VarillaService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            var kernel = StartUp.Initialize();

            this.VarillaService = kernel.Get<IVarillaService>();
        }

        [TestMethod]
        public void AgregarVarillaNueva()
        {
            int totalVarilla = this.VarillaService.GetDTOAll().Count;

            this.VarillaService.Insert(Utils.CrearVarillaDTO(true));

            Assert.AreEqual(totalVarilla + 1, this.VarillaService.GetDTOAll().Count);
        }

        [TestMethod]
        public void ObtenerVarillasDisponibles_OK()
        {
            FilterVarilla filter = new FilterVarilla() { Disponible = true, };

            IList<VarillaDTO> varillasDisponibles = this.VarillaService.GetByFilter(filter);

            Assert.IsTrue(varillasDisponibles.Count > 0);
        }

        [TestMethod]
        public void DarDeBaja_OK()
        {
            this.VarillaService.Insert(Utils.CrearVarillaDTO(true));

            int cantidadVarillas = this.VarillaService.GetDTOAll().Count();

            int ultimo = this.VarillaService.GetDTOAll().LastOrDefault().Id;

            this.VarillaService.DarDeBaja(this.VarillaService.GetDTOById(ultimo));

            Assert.IsTrue(this.VarillaService.GetById(ultimo).Disponible == false);
            Assert.AreEqual(cantidadVarillas, this.VarillaService.GetDTOAll().Count());
        }

        [TestMethod]
        public void ObtenerByAncho_OK()
        {
            VarillaDTO varilla = Utils.CrearVarillaDTO(true, Convert.ToDecimal(10.50));

            FilterVarilla filter = new FilterVarilla() { Ancho = Convert.ToDecimal(10.50), };

            int cantidadVarillaAncho = this.VarillaService.GetByFilter(filter).Count;

            this.VarillaService.Insert(varilla);

            Assert.AreEqual(cantidadVarillaAncho, this.VarillaService.GetByFilter(filter).Count - 1);
        }
    }
}
