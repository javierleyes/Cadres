using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Dto;
using Cadres.Service.Base;

namespace Cadres.Service.Interface
{
    public interface IVarillaService : IGenericService<IVarillaRepository, Varilla, long>
    {
        void DarDeBaja(long id);

        VarillaDTO CrearNueva(VarillaDTO varillaDTO);

        void SetCantidad(long id, int cantidad);

        void SetPrecio(long id, decimal precio);
    }
}
