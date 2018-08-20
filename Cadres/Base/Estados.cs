﻿using System.ComponentModel;

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
        }

        public enum EstadoMarco
        {
            [Description("Pendiente")]
            Pendiente = 0,

            [Description("Listo")]
            Listo = 1,

            [Description("Falta insumo")]
            Falta_Insumo = 2,
        }
    }
}