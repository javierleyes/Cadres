﻿using DAO;
using DAO.Context;
using Entidades.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implements;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Common;

namespace Test.Services
{
    [TestClass]
    public class VarillaServiceTestCase
    {
        private IVarillaService VarillaService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.VarillaService = new VarillaService(new VarillaDAO(new CadresContext()));
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
            IList<VarillaDTO> varillasDisponibles = this.VarillaService.GetByDisponibilidad(true);

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

            int cantidadVarillaAncho = this.VarillaService.GetByAncho(Convert.ToDecimal(10.50)).Count;

            this.VarillaService.Insert(varilla);

            Assert.AreEqual(cantidadVarillaAncho, this.VarillaService.GetByAncho(Convert.ToDecimal(10.50)).Count - 1);
        }
    }
}
