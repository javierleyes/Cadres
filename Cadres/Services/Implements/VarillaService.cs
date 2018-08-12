using DAOs;
using Entidades;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Implements
{
    public class VarillaService : GenericService<VarillaDAO, Varilla, int>, IVarillaService
    {
        public VarillaService(VarillaDAO entityDAO) : base(entityDAO)
        {
        }

        public void DarDeBaja(Varilla varilla)
        {
            varilla.Disponible = false;
            Save(varilla);
        }

        public IList<Varilla> GetByDisponibilidad(bool estaDisponible)
        {
            return EntityDAO.GetByEstadoDisponibilidad(estaDisponible);
        }

        public void ActualizarPrecio(Varilla varilla, decimal precio)
        {
            varilla.Precio = precio;
            Save(varilla);
        }
    }
}
