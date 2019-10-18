using LightInject;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PhoenixService.ScheduleApp.Specifications.Services;
using PhoenixService.Web.ScheduleApi.Configuration;
using Serilog;
using Serilog.Context;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

[assembly: OwinStartup(typeof(PhoenixService.Web.ScheduleApi.Startup))]

namespace PhoenixService.Web.ScheduleApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Environment.SetEnvironmentVariable("BASEDIR", AppDomain.CurrentDomain.BaseDirectory);

            var containerOptions = new ContainerOptions { EnablePropertyInjection = false };
            var serviceContainer = new ServiceContainer(containerOptions);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(conf => WebLightinjectConfig.Register(conf, serviceContainer));
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var apiConfig = serviceContainer.GetInstance<IApiConfig>();
            if (!apiConfig.IsProdiction)
                GlobalConfiguration.Configure(SwaggerConfig.Register);

            var authService = serviceContainer.GetInstance<IAuthenticationService>();
            var authorizationServerProvider = new TokenBasedAuthorizationServerProvider(authService);

            var authOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/auth"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(10),
                Provider = authorizationServerProvider,
            };

            app.UseOAuthAuthorizationServer(authOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseCors(CorsOptions.AllowAll);

            app.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            {
                using (LogContext.PushProperty("RequestId", Guid.NewGuid()))
                    await next.Invoke(env);
            })));

            app.Use(async (owinContext, next) =>
            {
                var userName = owinContext.Request.User.Identity.IsAuthenticated
                    ? owinContext.Request.User.Identity.Name
                    : "anonymous";
                LogContext.PushProperty("User", userName);

                var ip = owinContext.Request.RemoteIpAddress;
                LogContext.PushProperty("IP", !string.IsNullOrEmpty(ip) ? ip : "unknown");

                await next.Invoke();
            });

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Enrich.FromLogContext()
                .CreateLogger();

            Log.Logger.Information("Application started");
        }
    }
}
