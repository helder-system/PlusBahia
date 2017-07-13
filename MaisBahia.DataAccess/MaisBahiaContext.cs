using MaisBahia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisBahia.DataAccess
{
    public class MaisBahiaContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Anunciante> Anunciantes { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Foto> Fotos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
