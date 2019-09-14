using LightInject;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace PhoenixService.Web.ScheduleApi
{
    public class LightinjectDependencyResolver : IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IServiceContainer container;

        public LightinjectDependencyResolver(IServiceContainer container)
        {
            this.container = container;
        }

        public void Dispose()
        {
        }

        object IDependencyScope.GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public object GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        IEnumerable<object> System.Web.Mvc.IDependencyResolver.GetServices(Type serviceType)
        {
            return container.GetAllInstances(serviceType);
        }

        IEnumerable<object> IDependencyScope.GetServices(Type serviceType)
        {
            return container.GetAllInstances(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}