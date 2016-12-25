using System;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Ca.Skoolbo.Homesite.Helpers.Configs;
using RestSharp;
using Skoolbo.ApiClient.AnalysisLeaderboardClients;
using Skoolbo.ApiClient.RestSharpGlobalServices;
using Skoolbo.RestSharpExtension.Extensions;
using Skoolbo.RestSharpExtension.Services;

namespace Ca.Skoolbo.Homesite.BootStrapper
{
    public static class AutoFacConfig
    {
        public static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<AutofacWebTypesModule>();
         
            builder.RegisterType<AnalysisLeaderboardClient>().As<IAnalysisLeaderboardClient>().InstancePerLifetimeScope();

            Func<string, IRestClient> restClientFactory = apiClient =>
            {
                var restClient = new RestClient(apiClient)
                {
                    Encoding = Encoding.UTF8
                };

                restClient.AddHandler("application/json", new RestSharpJsonDeserializer());

                return restClient;
            };

            Action<Exception> loggingFactory = exception =>
            {
              
            };

            builder.Register<IRestSharpService>(context =>
            {
                var clientFactory = restClientFactory(WebConfigHelper.ApiClient);

                return new RestSharpService(clientFactory, loggingFactory);
            }).InstancePerLifetimeScope();


            builder.Register<IRestSharpGlobalService>(context =>
            {
                var clientFactory = restClientFactory(WebConfigHelper.ApiGlobalClient);

                return new RestSharpGlobalService(clientFactory, loggingFactory);

            }).InstancePerLifetimeScope();

        }
    }
}