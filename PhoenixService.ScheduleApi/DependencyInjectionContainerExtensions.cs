using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using LightInject;
using Microsoft.Extensions.DependencyInjection;

namespace PhoenixService.ScheduleApi
{
    public static class DependencyInjectionContainerExtensions
    {
        private static readonly MethodInfo GetInstanceMethod;
        private static readonly MethodInfo GetNamedInstanceMethod;

        static DependencyInjectionContainerExtensions()
        {
            GetInstanceMethod =
                typeof(IServiceFactory)
                .GetTypeInfo()
                .DeclaredMethods
                    .Single(method => method.Name == nameof(IServiceFactory.GetInstance) &&
                                      !method.IsGenericMethod &&
                                      method.GetParameters().Length == 1);
            GetNamedInstanceMethod =
                typeof(IServiceFactory)
                    .GetTypeInfo()
                    .DeclaredMethods
                    .Single(method => method.Name == nameof(IServiceFactory.GetInstance) &&
                                      !method.IsGenericMethod &&
                                      method.GetParameters().Length == 2 &&
                                      method.GetParameters()
                                          .Last()
                                          .ParameterType == typeof(string));
        }

        public static void RegisterServices(this IServiceRegistry container, IServiceCollection serviceCollection)
        {
            var registrations = serviceCollection
                .Select(CreateServiceRegistration)
                .ToList();

            var groupedRegistrations = registrations.GroupBy(r => r.ServiceType);

            foreach (var groupedRegistration in groupedRegistrations)
            {
                groupedRegistration.Last().ServiceName = string.Empty;
                if (!groupedRegistration.Key.GetTypeInfo().IsGenericTypeDefinition &&
                    groupedRegistration.Count() > 1)
                    container.Register(
                        CreateEnumerableServiceRegistration(groupedRegistration.Key, groupedRegistration));
            }

            foreach (var registration in registrations)
            {
                container.Register(registration);
            }
        }

        private static ServiceRegistration CreateEnumerableServiceRegistration(Type elementType,
            IEnumerable<ServiceRegistration> serviceRegistrations)
        {
            var serviceFactoryParameter = Expression.Parameter(typeof(IServiceFactory), "serviceFactory");
            var enumerableType = typeof(IEnumerable<>).MakeGenericType(elementType);
            var getInstanceExpressions = serviceRegistrations
                .Select(serviceRegistration =>
                    CreateGetInstanceExpression(serviceFactoryParameter, serviceRegistration.ServiceType,
                        serviceRegistration.ServiceName))
                .ToList();

            var newArrayExpression = Expression.NewArrayInit(elementType, getInstanceExpressions);
            var lambdaExpression = Expression.Lambda(newArrayExpression, serviceFactoryParameter);

            var enumerableRegistration = new ServiceRegistration
            {
                ServiceName = string.Empty,
                ServiceType = enumerableType,
                FactoryExpression = lambdaExpression.Compile()
            };
            return enumerableRegistration;
        }

        private static Expression CreateGetInstanceExpression(Expression serviceFactoryExpression,
            Type serviceType, string serviceName)
        {
            var getInstanceMethodExpression = serviceName == string.Empty
                ? Expression.Call(serviceFactoryExpression, GetInstanceMethod, Expression.Constant(serviceType))
                : Expression.Call(serviceFactoryExpression, GetNamedInstanceMethod, Expression.Constant(serviceType),
                    Expression.Constant(serviceName));

            return Expression.Convert(getInstanceMethodExpression, serviceType);
        }

        private static ServiceRegistration CreateServiceRegistration(ServiceDescriptor descriptor)
        {
            return descriptor.ImplementationFactory != null
                ? CreateServiceRegistrationForFactoryDelegate(descriptor)
                : (descriptor.ImplementationInstance != null
                    ? CreateServiceRegistrationForInstance(descriptor)
                    : CreateServiceRegistrationServiceType(descriptor));
        }

        private static ServiceRegistration CreateServiceRegistrationServiceType(ServiceDescriptor descriptor)
        {
            var registration = CreateBasicServiceRegistration(descriptor);
            registration.ImplementingType = descriptor.ImplementationType;
            return registration;
        }

        private static ServiceRegistration CreateServiceRegistrationForInstance(ServiceDescriptor descriptor)
        {
            var registration = CreateBasicServiceRegistration(descriptor);
            registration.Value = descriptor.ImplementationInstance;
            return registration;
        }

        private static ServiceRegistration CreateServiceRegistrationForFactoryDelegate(ServiceDescriptor descriptor)
        {
            var registration = CreateBasicServiceRegistration(descriptor);
            registration.FactoryExpression = CreateFactoryDelegate(descriptor);
            return registration;
        }

        private static Delegate CreateFactoryDelegate(ServiceDescriptor descriptor)
        {
            var openGenericMethod = typeof(DependencyInjectionContainerExtensions)
                .GetTypeInfo()
                .GetDeclaredMethod(nameof(CreateTypedFactoryDelegate));
            var closedGenericMethod = openGenericMethod.MakeGenericMethod(descriptor.ServiceType);
            return (Delegate)closedGenericMethod.Invoke(null, new object[] { descriptor });
        }

        private static Func<IServiceFactory, T> CreateTypedFactoryDelegate<T>(ServiceDescriptor descriptor)
        {
            return serviceFactory => (T)descriptor
                .ImplementationFactory(serviceFactory.GetInstance<IServiceProvider>());
        }

        private static ServiceRegistration CreateBasicServiceRegistration(ServiceDescriptor descriptor)
        {
            return new ServiceRegistration
            {
                Lifetime = ResolveLifetime(descriptor),
                ServiceType = descriptor.ServiceType,
                ServiceName = Guid.NewGuid().ToString()
            };
        }

        private static ILifetime ResolveLifetime(ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationInstance != null)
                return null;

            ILifetime lifetime;
            switch (descriptor.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    lifetime = new PerContainerLifetime();
                    break;
                case ServiceLifetime.Scoped:
                    lifetime = new PerScopeLifetime();
                    break;
                case ServiceLifetime.Transient:
                    lifetime = new PerRequestLifeTime();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return lifetime;
        }

    }
}