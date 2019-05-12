using System;
using System.Linq;
using System.Threading.Tasks;

using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Generic.User
{
    public interface IUserRepositoryGeneric : IGenericRepository<UserModel>
    {
        Task<UserModel> SomeUserRepositoryMethod();
    }
    
    public class UserRepositoryGeneric : GenericRepository<UserModel>, IUserRepositoryGeneric
    {
        public UserRepositoryGeneric(DataContext context) : base(context)
        {
        }

        public override IQueryable<UserModel> GetAll()
        {
            return Set.AsNoTracking().ToArray().Select(model =>
            {
                model.Id = Guid.Empty;
                return model;
            }).Where(model => model.IsTestBoolProperty).AsQueryable();
        }

        public Task<UserModel> SomeUserRepositoryMethod()
        {
            return GetAll().FirstOrDefaultAsync(model => model.IsTestBoolProperty);
        }
    }
}