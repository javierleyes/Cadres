using Cadres.Infrastructure;
using Cadres.Infrastructure.Repository;
using Cadres.Service;
using Cadres.Service.Interface;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Cadres.ServiceTest
{
    public class RodServiceTestCase
    {
        private IRodService RodService { get; set; }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseLazyLoadingProxies().UseSqlServer("Data Source=localhost, 1401;Initial Catalog=CADRES_TEST;User Id=sa;Password=Sitio.1053;").Options;

            RodService = new RodService(new RodRepository(new ApplicationDBContext(options)));
        }

        [Test]
        public void GetRodsAvailable()
        {
            Assert.IsTrue(RodService.GetRodsAvailable().Count > 0);
        }

        [Test]
        public void GetRodByIdOk()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(RodService.GetByid(2).Name));
        }
    }
}
