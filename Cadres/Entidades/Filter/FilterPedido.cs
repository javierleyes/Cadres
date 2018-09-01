using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Filter
{
    public class FilterPedido
    {
        public DateTime Fecha { get; set; }

        public Estados.EstadoPedido Estado { get; set; }

        public string NombreComprador { get; set; }
    }
}
