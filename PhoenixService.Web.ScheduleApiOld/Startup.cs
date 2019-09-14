//using System.Web.Http;
//using System.Web.Mvc;
//using System.Web.Optimization;
//using System.Web.Routing;
//using Microsoft.Owin;
//using Owin;

//[assembly: OwinStartup(typeof(PhoenixService.Web.ScheduleApiOld.Startup))]
//namespace PhoenixService.Web.ScheduleApiOld
//{
//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            var config = new HttpConfiguration();
//            WebApiConfig.Register(config);
//            WebLightinjectConfig.Register(config);

//            AreaRegistration.RegisterAllAreas();
//            GlobalConfiguration.Configure(WebApiConfig.Register);
//            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
//            RouteConfig.RegisterRoutes(RouteTable.Routes);
//            BundleConfig.RegisterBundles(BundleTable.Bundles);

//            app.UseWebApi(config);
//        }
//    }
//}