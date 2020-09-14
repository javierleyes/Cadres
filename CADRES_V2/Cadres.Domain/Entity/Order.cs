using Cadres.Domain.Base;
using Cadres.Domain.Status;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Cadres.Domain.Entity
{
    [Table("Order", Schema = "dbo")]
    public class Order : Domain<long>
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerPhone { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime? FinishDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        [Required]
        [Range(0, 2)]
        public OrderStatus.OrderMakingStatus OrderMakingStatus { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public IList<Frame> Frames { get; set; }

        public string Note { get; set; }

        public Order(string customerName, string customerPhone, string note = "")
        {
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            Note = note;
            OrderDate = DateTime.Now;
            OrderMakingStatus = OrderStatus.OrderMakingStatus.Pending;
            Frames = new List<Frame>();
            Price = GetTotalPrice();
        }

        public void AddFrame(Frame frame)
            => Frames.Add(frame);

        public decimal GetTotalPrice()
            => Frames.Sum(x => x.Price);
    }
}
