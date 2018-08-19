using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO.Operaciones
{
    public class CompradorDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Observaciones { get; set; }

        public virtual IList<PedidoDTO> Pedidos { get; set; }

        public CompradorDTO()
        {
            this.Pedidos = new List<PedidoDTO>();
        }
    }
}
