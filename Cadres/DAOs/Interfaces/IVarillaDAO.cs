using DAO.Base;
using Entidades;
using System.Collections.Generic;

namespace DAO.Interfaces
{
    public interface IVarillaDAO : IGenericDAO<Varilla>
    {
        IList<Varilla> GetByEstadoDisponibilidad(bool estado);

        IList<Varilla> GetByAncho(decimal ancho);
    }
}
