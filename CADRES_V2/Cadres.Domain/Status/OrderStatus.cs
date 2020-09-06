using System.ComponentModel;

namespace Cadres.Domain.Status
{
    public class OrderStatus
    {
        public enum OrderMakingStatus
        {
            [Description("Pendiente")]
            Pending = 0,

            [Description("Terminado")]
            Finish = 1,

            [Description("Entregado")]
            Delivered = 2,
        }
    }
}
