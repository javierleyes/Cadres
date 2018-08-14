using Entidades.Inventtario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class CadresContext : DbContext
    {
        public CadresContext(DbContextOptions<CadresContext> options) : base(options)
        {
        }

        public DbSet<Varilla> Varillas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Equivalente del Seed de EF6
            // modelBuilder.Entity<Varilla>().HasData(new Varilla { Id = 1, Disponible = true });
        }
    }
}
