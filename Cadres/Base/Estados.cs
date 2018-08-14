using System.ComponentModel;

namespace Base
{
    public class Estados
    {
        public enum EstadoPedido
        {
            [Description("Pendiente")]
            Pendiente = 0,

            [Description("Terminado")]
            Terminado = 1,

            [Description("Entregado")]
            Entregado = 2,

            [Description("Falta Insumo")]
            FaltaInsumo = 3
        }
    }
}