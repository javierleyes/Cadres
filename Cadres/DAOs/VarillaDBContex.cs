using Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAOs
{
    public class VarillaDBContex : DbContext
    {
        public VarillaDBContex() : base("Base") { }

        public DbSet<Varilla> Varillas { get; set; }

        public IList<Varilla> GetAllVarillas()
        {
            return this.Varillas.ToList();
        }
    }
}
