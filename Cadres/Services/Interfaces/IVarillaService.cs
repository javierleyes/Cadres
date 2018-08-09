using DAOs.Interfaces;
using Entidades;
using Entidades.Base;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IVarillaService : IGenericService<IVarillaDAO, Varilla, int>
    {
        IList<Varilla> GetByDisponibilidad(bool estaDisponible);

        void ActualizarPrecio(Varilla varilla, decimal precio);

        void DarDeBaja(Varilla varilla);
    }
}
