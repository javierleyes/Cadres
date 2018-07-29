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
        private VarillaDBContex VarillaDB { get; set; }

        [TestMethod]
        public void PersistirVarilla_Ok()
        {
            this.VarillaDB = new VarillaDBContex();

            IList<Varilla> listaDeVarillas;

            Varilla varilla = new Varilla();
            varilla.Nombre = "Bombre 1,5 Negro Brilloso";
            varilla.Precio = Convert.ToDecimal(16.8);
            varilla.Cantidad = 8;

            this.VarillaDB.Varillas.Add(varilla);
            this.VarillaDB.SaveChanges();

            listaDeVarillas = VarillaDB.GetAllVarillas();

            Assert.AreEqual(listaDeVarillas.Count, 1);
        }
    }
}
