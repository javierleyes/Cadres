using Cadres.Domain.Base;
using Cadres.Domain.Status;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadres.Domain.Entity
{
    public class Order : Domain<long>
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus.OrderMakingStatus OrderMakingStatus { get; set; }
        public string Note { get; set; }
        public IList<Frame> Frames { get; set; }

        public Order(string customerName, string customerPhone, string note = "")
        {
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            Note = note;
            OrderDate = DateTime.Now;
            OrderMakingStatus = OrderStatus.OrderMakingStatus.Pending;
            Frames = new List<Frame>();
        }

        public void AddFrame(Frame frame)
            => Frames.Add(frame);

        public decimal GetTotalPrice()
            => Frames.Sum(x => x.Price);
    }
}
