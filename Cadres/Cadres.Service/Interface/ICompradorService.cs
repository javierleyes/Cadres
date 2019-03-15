using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Base;

namespace Cadres.Service.Interface
{
    public interface ICompradorService : IGenericService<ICompradorRepository, Comprador, long>
    {
        CompradorDTO CrearComprador(CompradorDTO comprador);
    }
}
