using System.Diagnostics.CodeAnalysis;

using Autofac;

using ConsoleApp1.Examples;

using DAL;
using DAL.Repositories.ExtensionRepository;
using DAL.Repositories.ExtensionRepository.User;
using DAL.Repositories.Generic;
using DAL.Repositories.Generic.User;
using DAL.Repositories.Simple;

using Domain.Models;

namespace ConsoleApp1
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        public static void Main()
        {
            CompositionRoot().Resolve<Application>().Run();
        }

        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<DataContext>().AsSelf();

            #region Extension
            
            builder.RegisterType<Storage>().AsSelf();

            builder.RegisterGeneric(typeof(ExtensionRepository<>)).As(typeof(IExtensionRepository<>));

            builder.RegisterType<UserExtensionRepository>().As<IExtensionRepository<UserModel>>();

            builder.RegisterType<ExtensionExample>().As<ExampleBase>();
            
            #endregion

            #region Generic

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            
            builder.RegisterType<UserRepositoryGeneric>().As<IUserRepositoryGeneric>();

            builder.RegisterType<GenericExample>().As<ExampleBase>();
            
            #endregion

            #region Simple

            builder.RegisterType<UserRepositorySimple>().As<IUserRepositorySimple>();
            
            builder.RegisterType<SimpleExample>().As<ExampleBase>();

            #endregion

            return builder.Build();
        }
    }
}