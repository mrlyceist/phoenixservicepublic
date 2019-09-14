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
            serviceContainer.RegisterApiControllers();
            serviceContainer.RegisterTypes();

            serviceContainer.EnablePerWebRequestScope();
            serviceContainer.EnableWebApi(config);
            //serviceContainer.EnableMvc();
        }
    }
}