using Entidades.Inventtario;
using Entidades.Operaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Common
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {
        }

        public DbSet<Varilla> Varillas { get; set; }

        public DbSet<Comprador> Compradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Equivalente del Seed de EF6
            // modelBuilder.Entity<Varilla>().HasData(new Varilla { Id = 1, Disponible = true });
        }
    }
}
