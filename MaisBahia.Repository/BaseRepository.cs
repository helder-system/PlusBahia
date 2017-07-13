using MaisBahia.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisBahia.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        protected MaisBahiaContext maisBahiaContext;

        public BaseRepository()
        {
            maisBahiaContext = new MaisBahiaContext();
        }

        //Possibilita aplicar injeção de dependências
        public BaseRepository(MaisBahiaContext maisBahiaContext)
        {
            this.maisBahiaContext = maisBahiaContext;
        }

        public void Adiciconar(T entidade)
        {
            maisBahiaContext.Set<T>().Add(entidade);
            maisBahiaContext.SaveChanges();
        }
        public void Editar(T entidade)
        {
            maisBahiaContext.Entry(entidade).State = EntityState.Modified;
            maisBahiaContext.SaveChanges();
        }
        public void Excluir(int Id)
        {
            T entidade = maisBahiaContext.Set<T>().Find(Id);
            maisBahiaContext.Set<T>().Remove(entidade);
            maisBahiaContext.SaveChanges();
        }
    }
}
