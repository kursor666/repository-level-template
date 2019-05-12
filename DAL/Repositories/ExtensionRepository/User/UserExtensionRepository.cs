using System;
using System.Linq;

using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.ExtensionRepository.User
{
    public class UserExtensionRepository : ExtensionRepository<UserModel>
    {
        public UserExtensionRepository(DataContext context) : base(context)
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
    }
}