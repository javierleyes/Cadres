using DAO.Context;
using DAO.Implements;
using DAO.Interfaces;
using Entidades;
using Entidades.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Common;

namespace Test.DAO
{
    [TestClass]
    public class VarillaDAOTestCase
    {
        private IVarillaDAO VarillaDAO { get; set; }
        private CadresContext Context { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            Context = new CadresContext();
            this.VarillaDAO = new VarillaDAO(Context);
        }

        [TestMethod]
        public void ObtenerTodasLasVarillas_Ok()
        {
            this.VarillaDAO.InsertOrUpdate(Utils.CrearVarilla(false));

            Assert.IsTrue(VarillaDAO.GetAll().Count() > 0);
        }

        [TestMethod]
        public void PersistirVarillaYObtener_Ok()
        {
            int cantidadVarillas = this.VarillaDAO.GetAll().Count();

            this.VarillaDAO.InsertOrUpdate(Utils.CrearVarilla(false));

            int ultimoAgregado = this.VarillaDAO.GetAll().ToList().LastOrDefault().Id;
            Varilla varillaObtenida = this.VarillaDAO.GetById(ultimoAgregado);

            Assert.AreEqual(varillaObtenida.Nombre, "Bombre 1,5 Negro Brilloso");
            Assert.AreEqual(varillaObtenida.Precio, Convert.ToDecimal(16.8));
            Assert.AreEqual(varillaObtenida.Cantidad, 8);

            Assert.AreEqual(cantidadVarillas + 1, this.VarillaDAO.GetAll().Count());
        }

        [TestMethod]
        public void ObtenerTodasLasVarillasDisponibles_Ok()
        {
            this.VarillaDAO.InsertOrUpdate(Utils.CrearVarilla(true));

            FilterVarilla filter = new FilterVarilla() { Disponible = true, };

            IList<Varilla> varillasDisponibles = this.VarillaDAO.GetByFilter(filter);

            Assert.IsTrue(varillasDisponibles.Count > 0);
        }

        [TestMethod]
        public void ObtenerTodasLasVarillasNoDisponibles_Ok()
        {
            this.VarillaDAO.InsertOrUpdate(Utils.CrearVarilla(false));

            FilterVarilla filter = new FilterVarilla() { Disponible = false, };

            IList<Varilla> varillasNoDisponibles = this.VarillaDAO.GetByFilter(filter);

            Assert.IsTrue(varillasNoDisponibles.Count > 0);
        }

        [TestMethod]
        public void ActualizarPrecio_OK()
        {
            this.VarillaDAO.InsertOrUpdate(Utils.CrearVarilla(false));

            int ultimoAgregado = this.VarillaDAO.GetAll().ToList().LastOrDefault().Id;
            Varilla varilla = this.VarillaDAO.GetById(ultimoAgregado);

            decimal precioViejo = varilla.Precio;

            varilla.Precio = Convert.ToDecimal(19.25);

            this.VarillaDAO.InsertOrUpdate(varilla);

            Assert.AreEqual(this.VarillaDAO.GetById(ultimoAgregado).Precio, Convert.ToDecimal(19.25));
            Assert.AreNotEqual(this.VarillaDAO.GetById(ultimoAgregado).Precio, precioViejo);
        }
    }
}
