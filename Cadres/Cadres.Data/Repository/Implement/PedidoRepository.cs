using Cadres.Data.Base;
using Cadres.Data.Filter;
using Cadres.Data.Repository.Interface;
using Cadres.Domain.Entity;
using Cadres.Domain.States;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cadres.Data.Repository.Implement
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IList<Pedido> GetByFilter(PedidoFilter filter)
        {
            // Comparar fecha
            return this.GetAll().Where(x => (x.Estado == (Estados.EstadoPedido)filter.Estado)
                                         || (x.Numero == filter.Numero)
                                         || ((x.Fecha.Date >= filter.FechaDesde.Date) && (x.Fecha.Date <= filter.FechaHasta.Date))).ToList();

        }
    }
}
