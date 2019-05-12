using System;
using System.Linq;
using System.Threading.Tasks;

using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Generic
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> GetById(Guid id);
        IQueryable<TEntity> GetAll();
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected DataContext Context { get; }
        protected DbSet<TEntity> Set { get; }

        public GenericRepository(DataContext context)
        {
            Context = context;
            Set = Context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await Set.FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Set.AsNoTracking();
        }
    }
}