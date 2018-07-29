using DAOs.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAOs
{
    public class VarillaDAO : DbContext, IGenericDAO<Varilla>, IVarillaDAO
    {
        public VarillaDAO() : base("Base") { }

        public DbSet<Varilla> Varillas { get; set; }

        public IList<Varilla> GetAll()
        {
            return this.Varillas.ToList();
        }

        public Varilla GetById(long id)
        {
            return this.Varillas.Where(x => x.Id == id).FirstOrDefault<Varilla>();
        }

        public void Add(Varilla entidad)
        {
            this.Varillas.Add(entidad);
        }

        public IList<Varilla> GetByEstadoDisponibilidad(bool estado)
        {
            return this.Varillas.Where(x => x.Disponible == estado).ToList<Varilla>();
        }
    }
}
