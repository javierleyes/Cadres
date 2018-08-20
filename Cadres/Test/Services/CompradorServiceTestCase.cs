using DAO.Context;
using DAO.Implements;
using Entidades.Filter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implements;
using Test.Common;

namespace Test.Services
{
    [TestClass]
    public class CompradorServiceTestCase
    {
        private CompradorService CompradorService { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.CompradorService = new CompradorService(new CompradorDAO(new CadresContext()));
        }

        [TestMethod]
        public void GetByFilter()
        {
            this.CompradorService.EntityDAO.InsertOrUpdate(Utils.CrearComprador());

            FilterComprador filter = new FilterComprador()
            {
                Telefono = "4512-8754"
            };

            Assert.IsTrue(this.CompradorService.GetByFilter(filter).Count > 0);
        }
    }
}
