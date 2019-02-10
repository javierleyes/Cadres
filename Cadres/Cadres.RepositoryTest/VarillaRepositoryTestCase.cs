using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.IoD.Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Data.Entity.Validation;
using System.Linq;

namespace Cadres.RepositoryTest
{
    [TestClass]
    public class VarillaRepositoryTestCase
    {
        private IVarillaRepository VarillaRepository { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            var kernel = StartUp.Initialize();

            this.VarillaRepository = kernel.Get<IVarillaRepository>();
        }

        [TestMethod]
        public void PersistirYObtener_OK()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "Chata 3 kiri",
                Ancho = 3,
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };

            int cantidadInicial = this.VarillaRepository.GetAll().Count();

            long id = this.VarillaRepository.Add(varilla).Id;

            Varilla varillaObtenida = this.VarillaRepository.GetById(id);

            Assert.AreEqual(varilla.Nombre, varillaObtenida.Nombre);
            Assert.AreEqual(varilla.Ancho, varillaObtenida.Ancho);
            Assert.AreEqual(varilla.Cantidad, varillaObtenida.Cantidad);
            Assert.AreEqual(varilla.Disponible, varillaObtenida.Disponible);
            Assert.AreEqual(varilla.Precio, varillaObtenida.Precio);

            Assert.AreEqual(cantidadInicial + 1, this.VarillaRepository.GetAll().Count());
        }

        [TestMethod]
        public void ObtenerTodos()
        {
            int cantidadVarillas = this.VarillaRepository.GetAll().Count();

            Assert.IsTrue(cantidadVarillas > 0);
        }

        [TestMethod]
        public void ActualizarPrecioVarilla_OK()
        {
            long idVarilla = 1;

            decimal precioViejo;
            decimal precioNuevo = 180;

            Varilla varilla = this.VarillaRepository.GetById(idVarilla);

            precioViejo = varilla.Precio;

            varilla.Precio = precioNuevo;

            varilla = this.VarillaRepository.Update(varilla);

            Assert.AreEqual(precioNuevo, varilla.Precio);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ActualizarPrecioVarilla_Error()
        {
            long idVarilla = 1;

            decimal precioViejo;
            decimal precioNuevo = 0;

            Varilla varilla = this.VarillaRepository.GetById(idVarilla);

            precioViejo = varilla.Precio;

            varilla.Precio = precioNuevo;

            varilla = this.VarillaRepository.Update(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Create_Error()
        {
            Varilla varilla = new Varilla()
            {
                Ancho = 3,
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };

            this.VarillaRepository.Add(varilla);
        }
    }
}
