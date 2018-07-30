using DAOs;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test.DAOs
{
    [TestClass]
    public class VarillaDAOTestCase
    {
        private VarillaDAO VarillaDAO { get; set; }

        private void SetUp()
        {
            this.VarillaDAO = new VarillaDAO();
        }

        [TestMethod]
        public void ObtenerTodasLasVarillas_Ok()
        {
            this.SetUp();

            this.VarillaDAO.Add(CrearVarilla(false));
            //this.VarillaDAO.SaveChanges();

            Assert.IsTrue(VarillaDAO.GetAll().Count > 0);
        }

        [TestMethod]
        public void PersistirVarillaYObtener_Ok()
        {
            this.SetUp();

            this.VarillaDAO.Add(CrearVarilla(false));
            //this.VarillaDAO.SaveChanges();

            Varilla varillaObtenida = this.VarillaDAO.GetById(1);

            Assert.AreEqual(varillaObtenida.Nombre, "Bombre 1,5 Negro Brilloso");
            Assert.AreEqual(varillaObtenida.Precio, Convert.ToDecimal(16.8));
            Assert.AreEqual(varillaObtenida.Cantidad, 8);
        }

        [TestMethod]
        public void ObtenerTodasLasVarillasDisponibles_Ok()
        {
            this.SetUp();

            this.VarillaDAO.Add(CrearVarilla(true));
            //this.VarillaDAO.SaveChanges();

            IList<Varilla> varillasDisponibles = this.VarillaDAO.GetByEstadoDisponibilidad(true);

            Assert.IsTrue(varillasDisponibles.Count > 0);
        }

        [TestMethod]
        public void ObtenerTodasLasVarillasNoDisponibles_Ok()
        {
            this.SetUp();

            this.VarillaDAO.Add(CrearVarilla(false));
            //this.VarillaDAO.SaveChanges();

            IList<Varilla> varillasNoDisponibles = this.VarillaDAO.GetByEstadoDisponibilidad(false);

            Assert.IsTrue(varillasNoDisponibles.Count > 0);
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
