using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.IoD.Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Data.Entity.Validation;
using System.Linq;

namespace Cadres.RepositoryTestCase
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
            Varilla varilla = CrearVarilla();

            int cantidadInicial = this.VarillaRepository.GetAll().Count();

            long id = this.VarillaRepository.Save(varilla).Id;

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
            this.VarillaRepository.Save(this.CrearVarilla());

            int cantidadVarillas = this.VarillaRepository.GetAll().Count();

            Assert.IsTrue(cantidadVarillas > 0);
        }

        [TestMethod]
        public void ActualizarPrecioVarilla_OK()
        {
            Varilla varilla = CrearVarilla();

            this.VarillaRepository.Save(varilla);

            decimal precioViejo;
            decimal precioNuevo = 180;

            Varilla varillaObtenida = this.VarillaRepository.GetById(varilla.Id);

            precioViejo = varilla.Precio;

            varillaObtenida.Precio = precioNuevo;

            varilla = this.VarillaRepository.Update(varillaObtenida);

            Assert.AreEqual(precioNuevo, varilla.Precio);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ActualizarPrecioVarilla_Error()
        {
            Varilla varilla = CrearVarilla();

            this.VarillaRepository.Save(varilla);

            decimal precioViejo;
            decimal precioNuevo = 0;

            Varilla varillaObtenida = this.VarillaRepository.GetById(varilla.Id);

            precioViejo = varilla.Precio;

            varillaObtenida.Precio = precioNuevo;

            varilla = this.VarillaRepository.Update(varillaObtenida);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateSinNombre_Error()
        {
            Varilla varilla = new Varilla()
            {
                Ancho = 3,
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateNombreCorto_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "a",
                Ancho = 3,
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateNombreLargo_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "asdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfdfsghkjhjhkjddddd",
                Ancho = 3,
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateSinAncho_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "varilla prueba test",
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateAnchoMenor_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "varilla prueba test",
                Ancho = (decimal)0.5,
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateAnchoMayor_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "varilla prueba test",
                Ancho = 12,
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateSinCantidad_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "varilla prueba test",
                Ancho = 12,
                Disponible = true,
                Precio = 160,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateCantidadNegativa_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "varilla prueba test",
                Ancho = 12,
                Cantidad = -10,
                Disponible = true,
                Precio = 160,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateSinPrecio_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "varilla prueba test",
                Ancho = 12,
                Cantidad = 10,
                Disponible = true,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreatePrecioNegativo_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "varilla prueba test",
                Ancho = 12,
                Cantidad = 10,
                Precio = -10,
                Disponible = true,
            };

            this.VarillaRepository.Save(varilla);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateSinDisponibilidad_Error()
        {
            Varilla varilla = new Varilla()
            {
                Nombre = "varilla prueba test",
                Ancho = 12,
                Cantidad = 10,
                Precio = 160,
            };

            this.VarillaRepository.Save(varilla);
        }

        private Varilla CrearVarilla()
        {
            return new Varilla()
            {
                Nombre = "Chata 3 kiri",
                Ancho = 3,
                Cantidad = 10,
                Disponible = true,
                Precio = 160,
            };
        }
    }
}
