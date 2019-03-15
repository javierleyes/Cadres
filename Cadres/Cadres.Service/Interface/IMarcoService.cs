using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Base;

namespace Cadres.Service.Interface
{
    public interface IMarcoService : IGenericService<IMarcoRepository, Marco, long>
    {
        Marco CrearMarco(MarcoDTO marcoDTO);

        void SetEstadoListo(int numero);

        void SetEstadoSinMateriales(int numero);

        decimal CalcularPrecio(MarcoDTO marco);
    }
}
