using Cadres.Domain.Entity;
using Cadres.Domain.Status;
using NUnit.Framework;

namespace Cadres.BusinessTest
{
    public class FrameBusinessTestCase
    {
        private const string ROD_NAME = "Chata 3 Negro Brilloso";
        private const decimal ROD_ANGLE = 3;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateFrameOk()
        {
            Rod rod = new RodBuilder(ROD_NAME)
                .WithWidth(ROD_ANGLE)
                .WithPrice(80);

            Frame frame = new FrameBuilder(40, 60, rod);

            Assert.AreEqual(40, frame.Width);
            Assert.AreEqual(60, frame.Large);
            Assert.AreEqual(FrameStatus.FrameMakingStatus.Pending, frame.MakingStatus);
            Assert.AreEqual(179.2, frame.Price);
            Assert.AreEqual(ROD_NAME, frame.Rod.Name);
            Assert.AreEqual(ROD_ANGLE, frame.Rod.Width);
        }
    }
}