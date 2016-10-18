using RestSharp;
using Skoolbo.ApiClient.Models.ZippyShinePaymentModel;
using Skoolbo.ApiClient.RestSharpGlobalServices;
using Skoolbo.RestSharpExtension.Extensions;

namespace Skoolbo.ApiClient.ZippyShinePaymentClients
{
    public class ZippyShinePaymentClient : IZippyShinePaymentClient
    {
        private readonly IRestSharpGlobalService _restSharpGlobalService;

        public ZippyShinePaymentClient(IRestSharpGlobalService restSharpGlobalService)
        {
            _restSharpGlobalService = restSharpGlobalService;
        }


        public ZippyLicenseModel GetLicenseByKey(string key)
        {
            var requestUri = $"payment/transaction_info?id={key}";
            var request = new RestRequest(requestUri, Method.GET)
            {
                JsonSerializer = new JsonSerializer(),
                RequestFormat = DataFormat.Json
            };
            var reponse = _restSharpGlobalService.Execute<ZippyLicenseModel>(request);

            return reponse;
        }

    }
}