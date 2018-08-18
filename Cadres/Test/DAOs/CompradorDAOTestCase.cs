using DAOs.Context;
using DAOs.Implements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Common;
using System.Linq;
using Entidades;
using DAOs.Filter;
using System.Collections.Generic;

namespace Test.DAOs
{
    [TestClass]
    public class CompradorDAOTestCase
    {
        private CadresContext Context { get; set; }
        private CompradorDAO CompradorDAO { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.Context = new CadresContext();
            this.CompradorDAO = new CompradorDAO(this.Context);
        }

        [TestMethod]
        public void InsertarComprador()
        {
            int cantidadCompradores = this.CompradorDAO.GetAll().ToList().Count();

            this.CompradorDAO.InsertOrUpdate(Utils.CrearComprador());

            int ultimo = this.CompradorDAO.GetAll().ToList().LastOrDefault().Id;

            Comprador comprador = this.CompradorDAO.GetById(ultimo);

            Assert.AreEqual(comprador.Nombre, "Nombre del Cliente");
            Assert.AreEqual(comprador.Direccion, "Calle falsa 123");
            Assert.AreEqual(comprador.Telefono, "4512-8754");
            Assert.AreEqual(comprador.Observaciones, "Las observaciones de test.");
            Assert.AreEqual(this.CompradorDAO.GetAll().ToList().Count(), cantidadCompradores + 1);
        }

        [TestMethod]
        public void GetByFilter()
        {
            this.CompradorDAO.InsertOrUpdate(Utils.CrearComprador());

            FilterComprador filter = new FilterComprador()
            {
                Nombre = "Nombre del Cliente"
            };

            IList<Comprador> compradores = this.CompradorDAO.GetByFilter(filter);

            Assert.IsTrue(compradores.Count() > 0);
        }
    }
}
