using Cadres.Infrastructure;
using Cadres.Infrastructure.Repository;
using Cadres.Service;
using Cadres.Service.Dto;
using Cadres.Service.Interface;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Cadres.ServiceTest
{
    public class FrameServiceTestCase
    {
        private IFrameService FrameService { get; set; }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseLazyLoadingProxies().UseSqlServer("Data Source=localhost, 1401;Initial Catalog=CADRES_TEST;User Id=sa;Password=Sitio.1053;").Options;

            FrameService = new FrameService(new RodRepository(new ApplicationDBContext(options)));
        }

        [Test]
        public void RequestPriceFrameOk()
        {
            var frameDataContact = new FrameGetPriceInputDataContract() { Width = 40, Large = 60, IdRod = 2 };
            Assert.AreEqual(434, FrameService.GetPriceFrameOutputDataContract(frameDataContact).Price);
        }
    }
}