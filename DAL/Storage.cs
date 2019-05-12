using Autofac;

using DAL.Repositories.ExtensionRepository;

using Domain;

namespace DAL
{
    public class Storage
    {
        protected ILifetimeScope Container { get; }

        public Storage(ILifetimeScope container)
        {
            Container = container;
        }

        public IExtensionRepository<TEntity> Get<TEntity>() where TEntity : class, IModel
        {
            return (IExtensionRepository<TEntity>) Container.Resolve(typeof(IExtensionRepository<>).MakeGenericType(typeof(TEntity)));
        }
    }
}
