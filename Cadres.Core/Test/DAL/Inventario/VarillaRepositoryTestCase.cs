using DAL.Implements.Inventario;
using Entidades.Inventtario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Common;
using Xunit;

namespace Test.DAL.Inventario
{
    public class VarillaRepositoryTestCase : IDisposable
    {
        private InMemoryDbContext Context { get; set; }
        private VarillaRepository VarillaRepository { get; set; }

        public VarillaRepositoryTestCase()
        {
            var options = new DbContextOptionsBuilder<InMemoryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            Context = new InMemoryDbContext(options);
            this.VarillaRepository = new VarillaRepository(Context);
        }

        [Fact]
        public void ObtenerTodasLasVarillas_Ok()
        {
            this.VarillaRepository.Add(EntityBuilder.BuildVarilla(false));

            Assert.True(VarillaRepository.GetAll().Count() > 0);
        }

        [Fact]
        public void PersistirVarillaYObtener_Ok()
        {
            int cantidadVarillas = this.VarillaRepository.GetAll().Count();

            this.VarillaRepository.Add(EntityBuilder.BuildVarilla(false));

            int ultimoAgregado = this.VarillaRepository.GetAll().LastOrDefault().Id;
            Varilla varillaObtenida = this.VarillaRepository.GetById(ultimoAgregado);

            Assert.Equal("Bombre 1,5 Negro Brilloso", varillaObtenida.Nombre);
            Assert.Equal(Convert.ToDecimal(16.8), varillaObtenida.Precio);
            Assert.Equal(8, varillaObtenida.Cantidad);

            Assert.Equal(cantidadVarillas + 1, this.VarillaRepository.GetAll().Count());
        }

        [Fact]
        public void ObtenerTodasLasVarillasDisponibles_Ok()
        {
            this.VarillaRepository.Add(EntityBuilder.BuildVarilla(true));

            int cantidadVarillasDisponibles = this.VarillaRepository.GetWhere(x => x.Disponible == true).Count();

            Assert.True(cantidadVarillasDisponibles > 0);
        }

        [Fact]
        public void ObtenerTodasLasVarillasNoDisponibles_Ok()
        {
            this.VarillaRepository.Add(EntityBuilder.BuildVarilla(false));

            int cantidadVarillasNoDisponibles = this.VarillaRepository.GetWhere(x => x.Disponible == false).Count();

            Assert.True(cantidadVarillasNoDisponibles > 0);
        }

        [Fact]
        public void ActualizarPrecio_OK()
        {
            this.VarillaRepository.Add(EntityBuilder.BuildVarilla(false));

            int ultimoAgregado = this.VarillaRepository.GetAll().LastOrDefault().Id;
            Varilla varilla = this.VarillaRepository.GetById(ultimoAgregado);

            decimal precioViejo = varilla.Precio;

            varilla.Precio = Convert.ToDecimal(19.25);

            this.VarillaRepository.Update(varilla);

            Assert.Equal(this.VarillaRepository.GetById(ultimoAgregado).Precio, Convert.ToDecimal(19.25));
            Assert.NotEqual(this.VarillaRepository.GetById(ultimoAgregado).Precio, precioViejo);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
