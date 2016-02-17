using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Ca.Skoolbo.Homesite.BootStrapper;

[assembly: PreApplicationStartMethod(typeof(Bootstrapper), "Run")]
namespace Ca.Skoolbo.Homesite.BootStrapper
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => HttpContext.Current != null ? (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) : null)
               .As<HttpContextBase>()
               .InstancePerDependency();

            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

            AutoFacConfig.RegisterComponents(builder);

            builder.RegisterFilterProvider();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }

}