using System.Threading.Tasks;

using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.ExtensionRepository.User
{
    public static class UserRepositoryExtension
    {
        public static async Task<TEntity> SomeUserRepositoryMethod<TEntity>(this IExtensionRepository<TEntity> self) where TEntity : UserModel
        {
            return await self.GetAll().FirstOrDefaultAsync(model => model.IsTestBoolProperty);
        }
    }
}
