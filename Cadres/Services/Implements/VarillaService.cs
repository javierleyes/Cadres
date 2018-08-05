using DAOs.Interfaces;
using Entidades;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implements
{
    public class VarillaService : IVarillaService
    {
        public IVarillaDAO VarillaDAO { get; set; }

        public void Agregar(Varilla varilla)
        {
            this.VarillaDAO.Add(varilla);
        }

        public void DarDeBaja(Varilla varilla)
        {
            varilla.Disponible = false;
            this.VarillaDAO.Update(varilla);
        }

        public IList<Varilla> GetAll()
        {
            return this.VarillaDAO.GetAll().ToList();
        }

        public Varilla GetById(long idVarilla)
        {
            return this.VarillaDAO.GetById(idVarilla);
        }

        public IList<Varilla> GetByDisponibilidad(bool estaDisponible)
        {
            return this.VarillaDAO.GetByEstadoDisponibilidad(estaDisponible);
        }

        public void ActualizarPrecio(Varilla varilla, decimal precio)
        {
            varilla.Precio = precio;
            this.VarillaDAO.Update(varilla);
        }
    }
}
