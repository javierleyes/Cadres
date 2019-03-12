using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Domain.States;
using Cadres.IoD.Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadres.RepositoryTest
{
    [TestClass]
    public class MarcoRepositoryTestCase
    {
        public IMarcoRepository MarcoRepository { get; set; }
        public IVarillaRepository VarillaRepository { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            var kernel = StartUp.Initialize();

            this.MarcoRepository = kernel.Get<IMarcoRepository>();
            this.VarillaRepository = kernel.Get<IVarillaRepository>();
        }

        [TestMethod]
        public void CrearMarco_OK()
        {
            Varilla varillaObtenida = VarillaRepository.GetById(1);

            Marco marco = new Marco()
            {
                Ancho = Convert.ToDecimal(45.5),
                Largo = Convert.ToDecimal(4.5),
                Precio = Convert.ToDecimal(71.89),
                Estado = Estados.EstadoMarco.Pendiente,
                Varilla = varillaObtenida,
            };

            Marco marcoObtenido = MarcoRepository.Save(marco);

            Assert.AreEqual(Convert.ToDecimal(45.5), marcoObtenido.Ancho);
            Assert.AreEqual(Convert.ToDecimal(4.5), marcoObtenido.Largo);
            Assert.AreEqual(Convert.ToDecimal(71.89), marcoObtenido.Precio);
            Assert.AreEqual(Estados.EstadoMarco.Pendiente, marcoObtenido.Estado);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CrearMarcoSinAncho_Error()
        {
            Varilla varillaObtenida = VarillaRepository.GetById(1);

            Marco marco = new Marco()
            {
                Largo = Convert.ToDecimal(4.5),
                Precio = Convert.ToDecimal(71.89),
                Estado = Estados.EstadoMarco.Pendiente,
                Varilla = varillaObtenida,
            };

            Marco marcoObtenido = MarcoRepository.Save(marco);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CrearMarcoSinLargo_Error()
        {
            Varilla varillaObtenida = VarillaRepository.GetById(1);

            Marco marco = new Marco()
            {
                Ancho = Convert.ToDecimal(45.5),
                Precio = Convert.ToDecimal(71.89),
                Estado = Estados.EstadoMarco.Pendiente,
                Varilla = varillaObtenida,
            };

            Marco marcoObtenido = MarcoRepository.Save(marco);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CrearMarcoSinPrecio_Error()
        {
            Varilla varillaObtenida = VarillaRepository.GetById(1);

            Marco marco = new Marco()
            {
                Ancho = Convert.ToDecimal(45.5),
                Largo = Convert.ToDecimal(4.5),
                Estado = Estados.EstadoMarco.Pendiente,
                Varilla = varillaObtenida,
            };

            Marco marcoObtenido = MarcoRepository.Save(marco);
        }
    }
}
