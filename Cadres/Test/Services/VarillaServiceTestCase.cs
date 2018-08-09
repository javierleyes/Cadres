using DAOs;
using DAOs.Context;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implements;
using System;
using System.Collections.Generic;

namespace Test.Services
{
    [TestClass]
    public class VarillaServiceTestCase
    {
        private VarillaService VarillaService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.VarillaService = new VarillaService(new VarillaDAO(new CadresContext()));
        }

        [TestMethod]
        public void AgregarVarillaNueva()
        {
            int totalVarilla = this.VarillaService.GetAll().Count;

            this.VarillaService.Save(CrearVarilla(true));

            Assert.AreEqual(totalVarilla + 1, this.VarillaService.GetAll().Count);
        }

        [TestMethod]
        public void ObtenerVarillasDisponibles_OK()
        {
            IList<Varilla> varillasDisponibles = this.VarillaService.GetByDisponibilidad(true);

            Assert.IsTrue(varillasDisponibles.Count > 0);
        }

        [TestMethod]
        public void DarDeBaja_OK()
        {
            this.VarillaService.Save(CrearVarilla(true));
            int ultimo = this.VarillaService.GetAll().Count;

            this.VarillaService.DarDeBaja(this.VarillaService.GetById(ultimo));

            Assert.IsTrue(this.VarillaService.GetById(ultimo).Disponible == false);
        }

        private static Varilla CrearVarilla(bool estado)
        {
            return new Varilla()
            {
                Nombre = "Bombre 1,5 Negro Brilloso",
                Precio = Convert.ToDecimal(16.8),
                Cantidad = 8,
                Disponible = estado
            };
        }
    }
}
