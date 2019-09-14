using LightInject;
using System.Web.Http;

namespace PhoenixService.Web.ScheduleApi
{
    public class WebLightinjectConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var containerOptions = new ContainerOptions { EnablePropertyInjection = false };
            var serviceContainer = new ServiceContainer(containerOptions);
            serviceContainer.RegisterTypes();

            var lightInjectDependencyResolver = new LightinjectDependencyResolver(serviceContainer);

            config.DependencyResolver = lightInjectDependencyResolver;
            GlobalConfiguration.Configuration.DependencyResolver = lightInjectDependencyResolver;
        }
    }
}