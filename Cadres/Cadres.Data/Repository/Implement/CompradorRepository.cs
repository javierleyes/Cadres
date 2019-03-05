using Cadres.Data.Base;
using Cadres.Data.Filter;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cadres.Data.Repository.Implement
{
    public class CompradorRepository : GenericRepository<Comprador>, ICompradorRepository
    {
        public CompradorRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Comprador> GetByFilter(CompradorFilter filter)
        {
            return this.GetAll().Where(x => x.Nombre.Contains(filter.Nombre)
                                    || x.Direccion.Contains(filter.Direccion)
                                    || x.Telefono == filter.Telefono
                                    || x.Pedido.Id == filter.IdPedido).ToList();
        }
    }
}
