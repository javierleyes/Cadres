using Entidades;
using System.Collections.Generic;

namespace DAOs.Interfaces
{
    public interface IVarillaDAO : IGenericDAO<Varilla>
    {
        IList<Varilla> GetByEstadoDisponibilidad(bool estado);
    }
}
