using System.Linq;

using Domain;

namespace DAL.Repositories.ExtensionRepository.Common
{
    public static class ActiveRepositoryExtension
    {
        public static TEntity[] GetActive<TEntity>(this IExtensionRepository<TEntity> self) where TEntity : IActive, IModel
        {
            return self.GetAll().Where(entity => entity.IsActive).ToArray();
        }
    }
}