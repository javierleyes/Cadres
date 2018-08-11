using Entidades;
using System.Data.Entity;

namespace DAOs.Context
{
    public class CadresContext : DbContext
    {
        public CadresContext() : base("Base")
        {
            Database.SetInitializer<CadresContext>(null);
        }
        
        public IDbSet<Varilla> Varillas { get; set; }
    }
}
