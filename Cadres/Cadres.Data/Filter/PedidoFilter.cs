﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadres.Data.Filter
{
    public class PedidoFilter
    {
        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public int Estado { get; set; }

        public string Codigo { get; set; }
    }
}