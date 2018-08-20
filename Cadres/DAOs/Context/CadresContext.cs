using Entidades;
using System.Data.Entity;

namespace DAO.Context
{
    public class CadresContext : DbContext
    {
        public CadresContext() : base("Base")
        {
            Database.SetInitializer<CadresContext>(null);
        }

        public IDbSet<Varilla> Varillas { get; set; }

        public IDbSet<Pedido> Pedidos { get; set; }

        public IDbSet<Comprador> Compradores { get; set; }

        public IDbSet<Marco> Marcos { get; set; }
    }
}
