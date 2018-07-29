using DAOs;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class VarillaDAOTestCase
    {
        private VarillaDAO VarillaDB { get; set; }

        private void SetUp()
        {
            this.VarillaDB = new VarillaDAO();
        }

        [TestMethod]
        public void ObtenerTodasLasVarillas_Ok()
        {
            this.SetUp();

            this.VarillaDB.Varillas.Add(CrearVarilla(false));
            this.VarillaDB.Add(CrearVarilla(false));
            this.VarillaDB.SaveChanges();

            Assert.IsTrue(VarillaDB.GetAll().Count > 0);
        }

        [TestMethod]
        public void PersistirVarillaYObtener_Ok()
        {
            this.SetUp();

            this.VarillaDB.Varillas.Add(CrearVarilla(false));
            this.VarillaDB.SaveChanges();

            Varilla varillaObtenida = this.VarillaDB.GetById(1);

            Assert.AreEqual(varillaObtenida.Nombre, "Bombre 1,5 Negro Brilloso");
            Assert.AreEqual(varillaObtenida.Precio, Convert.ToDecimal(16.8));
            Assert.AreEqual(varillaObtenida.Cantidad, 8);
        }

        [TestMethod]
        public void ObtenerTodasLasVarillasDisponibles_Ok()
        {
            this.SetUp();

            this.VarillaDB.Varillas.Add(CrearVarilla(true));
            this.VarillaDB.SaveChanges();

            IList<Varilla> varillasDisponibles = this.VarillaDB.GetByEstadoDisponibilidad(true);

            Assert.IsTrue(varillasDisponibles.Count > 0);
        }

        [TestMethod]
        public void ObtenerTodasLasVarillasNoDisponibles_Ok()
        {
            this.SetUp();

            this.VarillaDB.Varillas.Add(CrearVarilla(false));
            this.VarillaDB.SaveChanges();

            IList<Varilla> varillasNoDisponibles = this.VarillaDB.GetByEstadoDisponibilidad(false);

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
