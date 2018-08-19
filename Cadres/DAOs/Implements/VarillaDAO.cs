using DAO.Base;
using DAO.Implements;
using DAO.Interfaces;
using Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO
{
    public class VarillaDAO : GenericDAO<Varilla>, IVarillaDAO
    {
        public VarillaDAO(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Varilla> GetByAncho(decimal ancho)
        {
            return this.GetAll().Where(x => x.Ancho == ancho).ToList();
        }

        public IList<Varilla> GetByEstadoDisponibilidad(bool estado)
        {
            return this.GetAll().Where(x => x.Disponible == estado).ToList();
        }
    }
}
