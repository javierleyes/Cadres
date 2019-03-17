using Cadres.Dto.Base;

namespace Cadres.Dto
{
    public class CompradorDTO : DomainDTO<long>
    {
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public long PedidoId { get; set; }
    }
}
