using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Base;

namespace Cadres.Service.Interface
{
    public interface IMarcoService : IGenericService<IMarcoRepository, Marco, long>
    {
        MarcoDTO CrearMarco(MarcoDTO marcoDTO);

        MarcoDTO GetByNumero(int numero);

        void SetEstadoListo(int numero);

        void SetEstadoSinMateriales(int numero);

        decimal CalcularPrecio(MarcoDTO marco);
    }
}
