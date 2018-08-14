using DAL.Implements.Base;
using DAL.Interfaces.Operaciones;
using Entidades.Operaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implements.Operaciones
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
