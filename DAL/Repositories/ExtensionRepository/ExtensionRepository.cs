using System;
using System.Linq;
using System.Threading.Tasks;

using Domain;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.ExtensionRepository
{
    public interface IExtensionRepository<TEntity> where TEntity : IModel
    {
        Task<TEntity> GetById(Guid id);
        IQueryable<TEntity> GetAll();
    }
    
    public class ExtensionRepository<TEntity> : IExtensionRepository<TEntity> where TEntity : class, IModel
    {
        protected DataContext Context { get; }
        protected DbSet<TEntity> Set { get; }

        public ExtensionRepository(DataContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
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
