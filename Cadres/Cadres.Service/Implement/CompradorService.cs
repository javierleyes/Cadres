using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Base;
using Cadres.Service.Interface;

namespace Cadres.Service.Implement
{
    public class CompradorService : GenericService<ICompradorRepository, Comprador, long>, ICompradorService
    {
        public IPedidoService PedidoService { get; set; }

        public CompradorService(ICompradorRepository entityRepository, IPedidoService pedidoService) : base(entityRepository)
        {
            this.PedidoService = pedidoService;
        }

        public CompradorDTO CrearComprador(CompradorDTO compradorDTO)
        {
            Comprador comprador = this.FromTo(compradorDTO);

            compradorDTO.Id = this.EntityRepository.Save(comprador).Id;

            return compradorDTO;
        }

        private Comprador FromTo(CompradorDTO dto)
        {
            return new Comprador()
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Pedido = this.PedidoService.GetById(dto.PedidoId),
            };
        }
    }
}
