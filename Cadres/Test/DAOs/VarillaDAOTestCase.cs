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

            Assert.IsTrue(VarillaDAO.GetAll().Count > 0);
        }

        [TestMethod]
        public void PersistirVarillaYObtener_Ok()
        {
            this.SetUp();

            this.VarillaDAO.Add(CrearVarilla(false));

            int ultimoAgregado = this.VarillaDAO.GetAll().Count;
            Varilla varillaObtenida = this.VarillaDAO.GetById(ultimoAgregado);

            Assert.AreEqual(varillaObtenida.Nombre, "Bombre 1,5 Negro Brilloso");
            Assert.AreEqual(varillaObtenida.Precio, Convert.ToDecimal(16.8));
            Assert.AreEqual(varillaObtenida.Cantidad, 8);
        }

        [TestMethod]
        public void ObtenerTodasLasVarillasDisponibles_Ok()
        {
            this.SetUp();

            this.VarillaDAO.Add(CrearVarilla(true));

            IList<Varilla> varillasDisponibles = this.VarillaDAO.GetByEstadoDisponibilidad(true);

            Assert.IsTrue(varillasDisponibles.Count > 0);
        }

        [TestMethod]
        public void ObtenerTodasLasVarillasNoDisponibles_Ok()
        {
            this.SetUp();

            this.VarillaDAO.Add(CrearVarilla(false));

            IList<Varilla> varillasNoDisponibles = this.VarillaDAO.GetByEstadoDisponibilidad(false);

            Assert.IsTrue(varillasNoDisponibles.Count > 0);
        }

        [TestMethod]
        public void ActualizarPrecio_OK()
        {
            this.SetUp();

            this.VarillaDAO.Add(CrearVarilla(false));

            int ultimoAgregado = this.VarillaDAO.GetAll().Count;
            Varilla varilla = this.VarillaDAO.GetById(ultimoAgregado);

            decimal precioViejo = varilla.Precio;

            varilla.Precio = Convert.ToDecimal(19.25);

            this.VarillaDAO.Update(varilla);

            Assert.AreEqual(this.VarillaDAO.GetById(ultimoAgregado).Precio, Convert.ToDecimal(19.25));
            Assert.AreNotEqual(this.VarillaDAO.GetById(ultimoAgregado).Precio, precioViejo);
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
