using DAL.Implements.Operaciones;
using Filters.Operaciones;
using Services.Implements.Operaciones;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Common;
using Test.DAL;
using Xunit;

namespace Test.Services.Operaciones
{
    public class CompradorServiceTestCase
    {
        private InMemoryDbContext Context { get; set; }
        private CompradorService CompradorService { get; set; }
        
        public CompradorServiceTestCase()
        {
            Context = new ContextBuilder().Build();
            this.CompradorService = new CompradorService(new CompradorRepository(Context));
        }

        [Fact]
        public void GetByFilter()
        {
            this.CompradorService.Save(EntityBuilder.CrearComprador());

            CompradorFilter filter = new CompradorFilter()
            {
                Telefono = "4512-8754"
            };

            Assert.True(this.CompradorService.GetByFilter(filter).Count > 0);
        }
    }
}
