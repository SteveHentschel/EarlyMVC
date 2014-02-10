using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using MyMusicStore.Services;
using MyMusicStore.Controllers;
using MyMusicStore.Factories;
using MyMusicStore.Filters;

namespace MyMusicStore
{
    public static class Bootstrapper
    {

        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));

            IDependencyResolver resolver = DependencyResolver.Current;

            IDependencyResolver newResolver = new Factories.UnityDependencyResolver(container, resolver);

            DependencyResolver.SetResolver(newResolver);
        }


        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();   

            
            // Task 1
            container.RegisterType<IStoreService, StoreService>();
            container.RegisterType<IController, MyStoreController>("MyStore");      // Store or MyStore ??  <either is ok>

            // Task 2
            container.RegisterInstance<IMessageService>(new MessageService
            {
                Message = "You are welcome to our Web Camps Training Kit!",
                ImageUrl = "/Content/Images/webcamps.png"
            });

            container.RegisterType<IViewPageActivator, CustomViewPageActivator>(new InjectionConstructor(container));

            // Task 3
            container.RegisterInstance<IFilterProvider>("FilterProvider", new FilterProvider(container));
            container.RegisterInstance<IActionFilter>("LogActionFilter", new TraceActionFilter());

            return container;
        }
    }
}