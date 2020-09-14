using Cadres.Domain.Entity;
using Cadres.Domain.Status;
using NUnit.Framework;
using System;

namespace Cadres.BusinessTest
{
    public class OrderBusinessTestCase
    {
        private const string CUSTOMER_NAME = "Micaela";
        private const string PHONE_NAME = "Luna";

        private const string ROD_NAME = "Chata 3 Negro Brilloso";
        private const decimal ROD_ANGLE = 3;

        [Test]
        public void CreateOrderOk()
        {
            Rod rod = new RodBuilder(ROD_NAME)
                 .WithWidth(ROD_ANGLE)
                 .WithPrice(80);

            Frame frame = new FrameBuilder(40, 60, rod);

            Order order = new OrderBuilder(CUSTOMER_NAME, PHONE_NAME);
            order.AddFrame(frame);

            Assert.AreEqual(CUSTOMER_NAME, order.CustomerName);
            Assert.AreEqual(PHONE_NAME, order.CustomerPhone);
            Assert.AreEqual(DateTime.Today, order.OrderDate.Date);
            Assert.AreEqual(null, order.FinishDate);
            Assert.AreEqual(null, order.DeliveryDate);
            Assert.AreEqual(OrderStatus.OrderMakingStatus.Pending, order.OrderMakingStatus);
            Assert.AreEqual(1, order.Frames.Count);
            Assert.AreEqual(434, order.GetTotalPrice());
        }

    }
}
