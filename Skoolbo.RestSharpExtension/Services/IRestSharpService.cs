using System.Threading.Tasks;
using RestSharp;

namespace Skoolbo.RestSharpExtension.Services
{
    public interface IRestSharpService
    {
        T Execute<T>(IRestRequest request, out string messageError) where T : new();
        T Execute<T>(IRestRequest request) where T : new();
        T Execute<T>(IRestClient restClient, IRestRequest request) where T : new();
        T Execute<T>(IRestClient restClient, IRestRequest request, out string messageError) where T : new();
        IRestResponse Execute(IRestRequest request, out string messageError);
        IRestResponse Execute(IRestRequest request);
        IRestResponse Execute(IRestClient restClient, IRestRequest request, out string messageError);
        IRestResponse Execute(IRestClient restClient, IRestRequest request);
        Task<T> ExecuteAsync<T>(IRestRequest request) where T : new();
        Task<IRestResponse> ExecuteAsync(IRestRequest request);
        Task<T> ExecuteAsync<T>(IRestClient restClient, IRestRequest request) where T : new();
        Task<IRestResponse> ExecuteAsync(IRestClient restClient, IRestRequest request);

        IRestClient RestClientDefault(string baseUrl);
    }
}
