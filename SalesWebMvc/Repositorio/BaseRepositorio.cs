using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Repositorio;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Repositorio
{

    public class BaseRepositorio<TEntity> : IDisposable where TEntity : class
    {
        protected SalesWebMvcContext Context;
        protected DbSet<TEntity> DbSet;

        public BaseRepositorio(SalesWebMvcContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual TEntity Adicionarrrrrr(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        }

        public virtual TEntity Atualizar(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public virtual TEntity Excluir(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Context.Dispose();
        }
    }
}

