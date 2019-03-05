using Cadres.Data.Base;
using Cadres.Data.Filter;
using Cadres.Domain.Entity;
using System.Collections.Generic;

namespace Cadres.Data.Repository.Interface
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        IList<Pedido> GetByFilter(PedidoFilter filter);
    }
}
