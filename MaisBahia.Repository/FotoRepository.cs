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
    public class FotoRepository: BaseRepository<Foto>
    {
        public IEnumerable<Foto> ObterTodos()
        {
            return maisBahiaContext.Fotos.ToList();
        }

        public Foto ObterPorId(int id)
        {
            return maisBahiaContext.Fotos.Find(id);
        }
    }
}
