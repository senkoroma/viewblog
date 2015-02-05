using System.Web.Mvc;
using Blog.Dal;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace Blog.WebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<IBlogRepository, BlogRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IBlogRepository, BlogRepository>();
        }
    }
}