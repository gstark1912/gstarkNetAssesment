using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using IoC;

namespace MVC
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = IoCResolver.BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }
    }
}