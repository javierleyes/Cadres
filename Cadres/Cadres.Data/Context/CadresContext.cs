using Cadres.Domain.Entity;
using System.Data.Entity;

namespace Cadres.Data.Context
{
    public class CadresContext : DbContext
    {
        /*
         * En EF Core debe existir el constructor sin parametros
         * Para iniciar:
         * 1_ Add-Migration InitialMigration
         * 2_ Update-Database
         * 
         * 3_ Drop-Database
         */

        public CadresContext() : base("bd")
        {
            Database.SetInitializer<CadresContext>(null);
        }

        public IDbSet<Varilla> Varillas { get; set; }

        public IDbSet<Pedido> Pedidos { get; set; }

        public IDbSet<Comprador> Compradores { get; set; }

        public IDbSet<Marco> Marcos { get; set; }
    }
}
