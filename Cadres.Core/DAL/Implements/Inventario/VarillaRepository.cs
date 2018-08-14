using DAL.Implements.Base;
using DAL.Interfaces.Inventario;
using Entidades.Inventtario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implements.Inventario
{
    public class VarillaRepository : BaseRepository<Varilla>, IVarillaRepository
    {
        public VarillaRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
