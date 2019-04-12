using System.ComponentModel;

namespace Cadres.Domain.States
{
    public class Estados
    {
        public enum EstadoPedido
        {
            [Description("Ingresado")]
            Ingresado = 0,

            [Description("Pendiente")]
            Pendiente = 1,

            [Description("Terminado")]
            Terminado = 2,

            [Description("Entregado")]
            Entregado = 3,
        }

        public enum EstadoMarco
        {
            [Description("Ingresado")]
            Ingresado = 0,

            [Description("Pendiente")]
            Pendiente = 1,

            [Description("Listo")]
            Listo = 2,

            [Description("Sin materiales")]
            SinMateriales = 3,
        }
    }
}
