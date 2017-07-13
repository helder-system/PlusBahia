using MaisBahia.DataAccess;
using MaisBahia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisBahia.Repository
{
    public class AnuncianteRepository : BaseRepository<Anunciante>
    {
        public IEnumerable<Anunciante> ObterTodos()
        {
            var anunciantes = maisBahiaContext.Anunciantes.Include(a => a.Categoria).Include(a => a.Plano);
            return anunciantes.ToList();
        }

        public Anunciante ObterPorId(int? id)
        {
            return maisBahiaContext.Anunciantes.Find(id);
        }
    }
}
