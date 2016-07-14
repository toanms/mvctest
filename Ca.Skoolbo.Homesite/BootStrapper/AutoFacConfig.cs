using System;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Integration.Mvc;
using Ca.Skoolbo.Homesite.Helpers.Configs;
using RestSharp;
using Skoolbo.ApiClient.AnalysisLeaderboardClients;
using Skoolbo.ApiClient.RestSharpGlobalServices;
using Skoolbo.ApiClient.ZippyShinePaymentClients;
using Skoolbo.RestSharpExtension.Extensions;
using Skoolbo.RestSharpExtension.Services;

namespace Ca.Skoolbo.Homesite.BootStrapper
{
    public static class AutoFacConfig
    {
        public static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

         
            builder.RegisterType<AnalysisLeaderboardClient>().As<IAnalysisLeaderboardClient>().InstancePerLifetimeScope();
            builder.RegisterType<ZippyShinePaymentClient>().As<IZippyShinePaymentClient>().InstancePerLifetimeScope();


            Func<IRestClient> restClientFactory = () =>
            {
                var restClient = new RestClient(WebConfigHelper.ApiClient)
                {
                    Encoding = Encoding.UTF8
                };

                restClient.AddHandler("application/json", new RestSharpJsonDeserializer());

                return restClient;
            };

            Action<Exception> loggingFactory = exception =>
            {
              
            };

            builder.Register<IRestSharpService>(context => new RestSharpService(restClientFactory, loggingFactory)).InstancePerLifetimeScope();

            Func<IRestClient> restGlobalClientFactory = () =>
            {
                var restClient = new RestClient(WebConfigHelper.ApiGlobalClient)
                {
                    Encoding = Encoding.UTF8
                };

                restClient.AddHandler("application/json", new RestSharpJsonDeserializer());

                return restClient;
            };

            builder.Register<IRestSharpGlobalService>(context => new RestSharpGlobalService(restGlobalClientFactory, loggingFactory)).InstancePerLifetimeScope();


            Func<IRestClient> restZippyShineClientFactory = () =>
            {
                var restClient = new RestClient(WebConfigHelper.ApiZippyShinePaymentClient)
                {
                    Encoding = Encoding.UTF8
                };

                restClient.AddHandler("application/json", new RestSharpJsonDeserializer());

                return restClient;
            };

            builder.Register<IRestSharpGlobalService>(context => new RestSharpGlobalService(restZippyShineClientFactory, loggingFactory)).InstancePerLifetimeScope();
        }
    }
}