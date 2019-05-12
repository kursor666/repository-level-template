using System;
using System.Linq;
using System.Threading.Tasks;

using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Simple
{
    public interface IUserRepositorySimple
    {
        Task<UserModel> GetById(Guid id);
        IQueryable<UserModel> GetAll();
        Task<UserModel> SomeUserRepositoryMethod();
    }
    
    public class UserRepositorySimple : IUserRepositorySimple
    {
        public DataContext Context { get; }
        public DbSet<UserModel> Set { get; }

        public UserRepositorySimple(DataContext context)
        {
            Context = context;
            Set = Context.Set<UserModel>();
        }
        
        public async Task<UserModel> GetById(Guid id)
        {
            return await Context.Users.FindAsync(id);
        }

        public IQueryable<UserModel> GetAll()
        {
            return Set.AsNoTracking().ToArray().Select(model =>
            {
                model.Id = Guid.Empty;
                return model;
            }).Where(model => model.IsTestBoolProperty).AsQueryable();
        }

        public async Task<UserModel> SomeUserRepositoryMethod()
        {
            return await Set.FirstOrDefaultAsync(model => model.IsTestBoolProperty);
        }
    }
}
