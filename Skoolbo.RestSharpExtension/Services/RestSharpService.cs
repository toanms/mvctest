using System;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Skoolbo.RestSharpExtension.Extensions;

namespace Skoolbo.RestSharpExtension.Services
{
    public class RestSharpService : IRestSharpService
    {
        private const string ConstAppilicationErrorMessage = "Error retrieving response.  Check inner details for more info.";

        private readonly Func<IRestClient> _restClient;
        private readonly Action<Exception> _log;

        public RestSharpService(Func<IRestClient> restClient, Action<Exception> log)
        {
            _restClient = restClient;
            _log = log;
        }

        public T Execute<T>(IRestRequest request, out string messageError) where T : new()
        {
            return Execute<T>(_restClient.Invoke(), request, out messageError);
        }

        public T Execute<T>(IRestRequest request) where T : new()
        {
            return Execute<T>(_restClient.Invoke(), request);
        }

        public T Execute<T>(IRestClient restClient, IRestRequest request) where T : new()
        {
            return ExecuteCommand(() =>
            {
                AddParamaterForRequest(request);

                IRestResponse<T> response = restClient.Execute<T>(request);

                if (response.ErrorException == null)
                    return response.Data;

                return default(T);

            });
        }

        public T Execute<T>(IRestClient restClient, IRestRequest request, out string messageError) where T : new()
        {
            return ExecuteCommand(() =>
            {
                AddParamaterForRequest(request);

                IRestResponse<T> response = restClient.Execute<T>(request);

                if (response.ErrorException == null)
                    return response.Data;

                return default(T);

            }, out messageError);
        }

        public IRestResponse Execute(IRestRequest request, out string messageError)
        {
            return Execute(_restClient.Invoke(), request, out messageError);
        }

        public IRestResponse Execute(IRestRequest request)
        {
            return Execute(_restClient.Invoke(), request);
        }

        public IRestResponse Execute(IRestClient restClient, IRestRequest request, out string messageError)
        {
            return ExecuteCommand(() =>
            {
                IRestClient client = _restClient.Invoke();

                AddParamaterForRequest(request);

                IRestResponse response = client.Execute(request);

                if (response.ErrorException == null)
                    return response;

                return null;

            }, out messageError);
        }

        public IRestResponse Execute(IRestClient restClient, IRestRequest request)
        {
            return ExecuteCommand(() =>
            {
                IRestClient client = _restClient.Invoke();

                AddParamaterForRequest(request);

                IRestResponse response = client.Execute(request);

                if (response.ErrorException == null)
                    return response;

                return null;

            });
        }

        public async Task<T> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            return await ExecuteAsync<T>(_restClient.Invoke(), request);
        }

        public async Task<IRestResponse> ExecuteAsync(IRestRequest request)
        {
            return await ExecuteAsync(_restClient.Invoke(), request);
        }

        public async Task<T> ExecuteAsync<T>(IRestClient restClient, IRestRequest request) where T : new()
        {
            var executeCommand = ExecuteCommand(async () =>
            {
                IRestClient client = _restClient.Invoke();

                AddParamaterForRequest(request);

                var tcs = new TaskCompletionSource<T>();

                RestRequestAsyncHandle asyncHandle = client.ExecuteAsync<T>(request, response =>
                {
                    if (response.ErrorException == null)
                    {
                        tcs.SetResult(response.Data);
                    }
                    else
                    {
                        //throw new ApplicationException(ConstAppilicationErrorMessage, response.ErrorException);
                        tcs.SetResult(default(T));
                    }
                });

                T data = await tcs.Task;

                asyncHandle.Abort();

                return data;
            });

            return await executeCommand;
        }

        public async Task<IRestResponse> ExecuteAsync(IRestClient restClient, IRestRequest request)
        {
            var executeCommand = ExecuteCommand(async () =>
            {

                IRestClient client = _restClient.Invoke();

                AddParamaterForRequest(request);

                var tcs = new TaskCompletionSource<IRestResponse>();

                RestRequestAsyncHandle asyncHandle = client.ExecuteAsync(request, response =>
                {
                    if (response.ErrorException == null)
                    {
                        tcs.SetResult(response);
                    }
                    else
                    {
                        throw new ApplicationException(ConstAppilicationErrorMessage, response.ErrorException);
                    }
                });

                IRestResponse data = await tcs.Task;

                asyncHandle.Abort();

                return data;

            });

            return await executeCommand;
        }

        public IRestClient RestClientDefault(string baseUrl)
        {
            var restClient = new RestClient(baseUrl)
            {
                Encoding = Encoding.UTF8
            };
            restClient.AddHandler("application/json", new RestSharpJsonDeserializer());

            return restClient;
        }

        #region Private method
        private T ExecuteCommand<T>(Func<T> func, out string messageError)
        {
            messageError = string.Empty;

            try
            {
                return func();
            }
            catch (ApplicationException applicationException)
            {
                messageError = applicationException.ToString();

                _log.Invoke(applicationException);
            }
            catch (Exception e)
            {
                messageError = e.ToString();

                _log.Invoke(e);
            }
            return default(T);
        }
        private T ExecuteCommand<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (ApplicationException applicationException)
            {
                _log.Invoke(applicationException);
            }
            catch (Exception e)
            {
                _log.Invoke(e);
            }
            return default(T);
        }

        private void AddParamaterForRequest(IRestRequest request)
        {
            request.AddParameter("web", DateTime.UtcNow.ToString("yyyyMMdd"), ParameterType.QueryString);

            request.OnBeforeDeserialization = resp =>
            {
                resp.ContentType = "application/json";
            };
        }
        #endregion
    }
}
