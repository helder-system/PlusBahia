using MaisBahia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisBahia.Repository
{
    class CategoriaRepository:BaseRepository<Categoria>
    {
        public IEnumerable<Categoria> ObterTodos()
        {
            return maisBahiaContext.Categorias.ToList();
        }
    }
}
