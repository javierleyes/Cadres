using Entidades;
using System.Collections.Generic;

namespace DAOs.Interfaces
{
    public interface IVarillaDAO
    {
        IList<Varilla> GetByEstadoDisponibilidad(bool estado);
    }
}
