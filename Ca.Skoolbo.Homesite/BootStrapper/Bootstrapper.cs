using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

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

            AutoFacConfig.RegisterComponents(builder);

            builder.RegisterFilterProvider();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }

}