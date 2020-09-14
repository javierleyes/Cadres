using Cadres.Infrastructure;
using Cadres.Infrastructure.Repository;
using Cadres.Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Cadres.RepositoryTest
{
    public class RodRepositoryTestCase
    {
        private IRodRepository RodRepository { get; set; }

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseLazyLoadingProxies().UseSqlServer("Data Source=localhost, 1401;Initial Catalog=CADRES_TEST;User Id=sa;Password=Sitio.1053;").Options;

            RodRepository = new RodRepository(new ApplicationDBContext(options));
        }

        [Test]
        public void GetRodsOk()
        {
            var rods = RodRepository.GetAll().ToList();

            Assert.IsTrue(rods.Count() > 0);
        }

        [Test]
        public void GetRodByIdOk()
        {
            var rod = RodRepository.GetById(2);

            Assert.IsTrue(rod.Id > 0);
            Assert.IsTrue(rod.Price > 0);
            Assert.IsTrue(!string.IsNullOrEmpty(rod.Name));
        }

        [Test]
        public void GetRodByAvailableOk()
        {
            var rods = RodRepository.GetAll().Where(x => x.Available == true);

            Assert.IsTrue(rods.Count() > 0);
        }
    }
}
