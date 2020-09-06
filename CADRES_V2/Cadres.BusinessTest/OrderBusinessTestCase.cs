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

        [Test]
        public void CreateOrderOk()
        {
            Order order = new OrderBuilder(CUSTOMER_NAME, PHONE_NAME);

            Assert.AreEqual(CUSTOMER_NAME, order.CustomerName);
            Assert.AreEqual(PHONE_NAME, order.CustomerPhone);
            Assert.AreEqual(DateTime.Today, order.OrderDate.Date);
            Assert.AreEqual(null, order.FinishDate);
            Assert.AreEqual(null, order.DeliveryDate);
            Assert.AreEqual(OrderStatus.OrderMakingStatus.Pending, order.OrderMakingStatus);
            Assert.AreEqual(0, order.Frames.Count);
        }

    }
}
