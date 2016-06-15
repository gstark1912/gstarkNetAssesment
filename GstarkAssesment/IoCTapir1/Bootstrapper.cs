using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using System.Linq;
using DataTapir.Context.Interfaces;
using DataTapir.Context;
using BusinessTapir.Interfaces;
using BusinessTapir.Services;
using DataTapir.Repositories;
using DataTapir.Interfaces;

namespace IoCTapir1
{
    public static class IoCResolver
    {
        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
            container.RegisterType<IServiceEstadoReserva, ServiceEstadoReserva>();
            container.RegisterType<IRepositoryEstadoReserva, RepositoryEstadoReserva>();

            container.RegisterTypes(AllClasses.FromLoadedAssemblies().Where(
                t => t.Namespace == "BusinessTapir.Services"),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);

            container.RegisterTypes(AllClasses.FromLoadedAssemblies().Where(
                t => t.Namespace == "DataTapir.Repositories"),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);
        }
    }
}