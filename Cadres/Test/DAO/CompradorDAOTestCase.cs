using DAO.Interfaces;
using Entidades;
using Entidades.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using Test.Common;
using Test.Ninject;

namespace Test.DAO
{
    [TestClass]
    public class CompradorDAOTestCase
    {
        private ICompradorDAO CompradorDAO { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            var kernel = StartUp.Initialize();

            this.CompradorDAO = kernel.Get<ICompradorDAO>();
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
