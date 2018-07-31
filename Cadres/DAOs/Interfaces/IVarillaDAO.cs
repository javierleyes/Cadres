using Entidades;
using System.Collections.Generic;

namespace DAOs.Interfaces
{
    public interface IVarillaDAO : IGenericDAO<Varilla>
    {
        void Update(Varilla varilla);

        IList<Varilla> GetByEstadoDisponibilidad(bool estado);
    }
}
