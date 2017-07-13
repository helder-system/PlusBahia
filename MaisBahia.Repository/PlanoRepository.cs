using MaisBahia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisBahia.Repository
{
    public class PlanoRepository: BaseRepository<Plano>
    {
        public IEnumerable<Categoria> ObterTodos()
        {
            return maisBahiaContext.Categorias.ToList();
        }
    }
}
