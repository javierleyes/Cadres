using Entidades.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Services.Interfaces;
using Test.Common;
using Test.IoD;

namespace Test.Services
{
    [TestClass]
    public class CompradorServiceTestCase
    {
        private ICompradorService CompradorService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            StandardKernel kernel = Bindings.LoadDependancy();

            this.CompradorService = kernel.Get<ICompradorService>();
        }

        [TestMethod]
        public void GetByFilter()
        {
            this.CompradorService.Save(Utils.CrearComprador());

            FilterComprador filter = new FilterComprador()
            {
                Telefono = "4512-8754"
            };

            Assert.IsTrue(this.CompradorService.GetByFilter(filter).Count > 0);
        }
    }
}
