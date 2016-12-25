using System;
using RestSharp;
using Skoolbo.RestSharpExtension.Services;

namespace Skoolbo.ApiClient.RestSharpGlobalServices
{
    public class RestSharpGlobalService : RestSharpService, IRestSharpGlobalService
    {
        public RestSharpGlobalService(IRestClient restClient, Action<Exception> log) : base(restClient, log)
        {
        }
    }
}
