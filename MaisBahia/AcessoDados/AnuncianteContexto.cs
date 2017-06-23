using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MaisBahia.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MaisBahia.AcessoDados
{
    public class AnuncianteContexto : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Anunciante> Anunciantes { get; set; }
        public DbSet<Plano> Planos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
        }
    }
}