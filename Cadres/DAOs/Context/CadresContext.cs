using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
