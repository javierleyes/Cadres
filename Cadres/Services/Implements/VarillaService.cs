using DAOs.Interfaces;
using Entidades;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Implements
{
    public class VarillaService : IVarillaService
    {
        public IVarillaDAO VarillaDAO { get; set; }

        public void AgregarVarilla(Varilla varilla)
        {
            this.VarillaDAO.Add(varilla);
        }

        public IList<Varilla> GetAll()
        {
            return this.VarillaDAO.GetAll();
        }

        public Varilla GetById(long idVarilla)
        {
            return this.VarillaDAO.GetById(idVarilla);
        }

        public IList<Varilla> GetVarillasByDisponibilidad(bool estaDisponible)
        {
            return this.VarillaDAO.GetByEstadoDisponibilidad(estaDisponible);
        }
    }
}
