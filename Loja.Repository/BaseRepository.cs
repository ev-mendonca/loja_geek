using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Loja.Domain.Entities;
using Loja.Repository.Context;

namespace Loja.Repository
{
    public abstract class BaseRepository<T> where T : BaseEntity 
    {
        protected readonly SqlServerContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(SqlServerContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        protected virtual void Criar(T obj)
        {
            _dbSet.Add(obj);
            _context.SaveChanges();
        }

        protected virtual void Atualizar(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        protected virtual void Remover(int id)
        {
            T obj = Carregar(id);
            
            if(obj != null)
            {
                _dbSet.Remove(Carregar(id));
                _context.SaveChanges();
            }
        }

        protected virtual T Carregar(int id) => _dbSet.Find(id);

        protected virtual IList<T> Listar() => _dbSet.ToList();
    }
}
