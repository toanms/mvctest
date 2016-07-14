using System;
using RestSharp;
using Skoolbo.RestSharpExtension.Services;

namespace Skoolbo.ApiClient.RestSharpZippyShinePaymentServices
{
    public class RestSharpZippyShinePaymentService : RestSharpService, IRestSharpZippyShinePaymentService
    {
        public RestSharpZippyShinePaymentService(Func<IRestClient> restClient, Action<Exception> log) : base(restClient, log)
        {
        }
    }
}
