using System.Collections.Generic;
using RestSharp;
using Skoolbo.ApiClient.Models;
using Skoolbo.ApiClient.Models.AnalysisLeaderboardModels;
using Skoolbo.ApiClient.RestSharpGlobalServices;
using Skoolbo.RestSharpExtension.Extensions;
using Skoolbo.RestSharpExtension.Services;

namespace Skoolbo.ApiClient.AnalysisLeaderboardClients
{
    public class AnalysisLeaderboardClient : IAnalysisLeaderboardClient
    {
        private readonly IRestSharpGlobalService _restSharpGlobalService;
        private readonly IRestSharpService _restSharpService;

        public AnalysisLeaderboardClient(IRestSharpGlobalService  restSharpGlobalService, IRestSharpService restSharpService)
        {
            _restSharpGlobalService = restSharpGlobalService;
            _restSharpService = restSharpService;
        }

       
        public int GetSchoolRegister(string region)
        {
            var requestUri = $"/api/query/SchoolRegisterCount?region={region}";
            var request = new RestRequest(requestUri, Method.GET)
            {
                JsonSerializer = new JsonSerializer(),
                RequestFormat = DataFormat.Json
            };
            var reponse = _restSharpGlobalService.Execute<int>(request);

            return reponse;
        }
        public int GetPersonalBestTotal(string region)
        {
            var requestUri = $"/api/query/NewRecordCount?region={region}";
            var request = new RestRequest(requestUri, Method.GET)
            {
                JsonSerializer = new JsonSerializer(),
                RequestFormat = DataFormat.Json
            };
            var reponse = _restSharpGlobalService.Execute<int>(request);

            return reponse;
        }

        public List<PersonalBestModel> GetPersonalBest(int limit)
        {
            var uri = $"public/feed?event=personalBest&limit={limit}";

            var request = new RestRequest(uri, Method.GET)
            {
                JsonSerializer = new JsonSerializer(),
                RequestFormat = DataFormat.Json
            };

            var baseOutput = _restSharpService.Execute<BaseOutput<List<PersonalBestModel>>>(request);

            if (baseOutput == null)
                return default(List<PersonalBestModel>);

            return baseOutput.Data;
        }

        public DailyAnalysisModel GetDailyAnalysis(string region)
        {
            var requestUri = $"/api/query/dailyanalysis?region={region}";
            var request = new RestRequest(requestUri, Method.GET)
            {
                JsonSerializer = new JsonSerializer(),
                RequestFormat = DataFormat.Json
            };
            var reponse = _restSharpGlobalService.Execute<DailyAnalysisModel>(request);

            return reponse;
        }

        public TotalizerModel GetLeaderboardTotalizer(bool isGlobal, string accessToken)
        {
            var requestUri = $"weekly/totalizer?access_token={accessToken}&limit=100";

            IRestRequest request = new RestRequest(requestUri, Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };

            request.AddBody(new { is_global = isGlobal });
            var response = _restSharpService.Execute<TotalizerModel>(request);
            return response;
        }

        public LeaderBoardModel GetLeaderboardStudents(string timeFilter, bool isGlobal, string accessToken)
        {
            var countryOrGlobal = isGlobal ? "/global" : "/country";

            var requestUri = $"leaderboard{countryOrGlobal}?access_token={accessToken}&limit=100";

            IRestRequest request = new RestRequest(requestUri, Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };

            request.AddBody(new { time_filter = timeFilter });

            var response = _restSharpService.Execute<BaseOutput<LeaderBoardModel>>(request);

            return response?.Data;
        }

        public LeaderBoardModel GetLeaderboardClasses(string timeFilter, bool isGlobal, string accessToken)
        {
            var countryOrGlobal = isGlobal ? "/global" : "";

            var requestUri = $"leaderboard/classes{countryOrGlobal}?access_token={accessToken}&limit=100";

            IRestRequest request = new RestRequest(requestUri, Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };

            request.AddBody(new { @event = timeFilter });

            return  _restSharpService.Execute<LeaderBoardModel>(request);
        }

        public LeaderBoardModel GetLeaderboardSchools(string timeFilter, bool isGlobal, string accessToken)
        {
            var countryOrGlobal = isGlobal ? "/global" : "";
            var requestUri = $"leaderboard/schools{countryOrGlobal}?access_token={accessToken}&limit=100";

            IRestRequest request = new RestRequest(requestUri, Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };

            request.AddBody(new { @event = timeFilter });

            var response = _restSharpService.Execute<LeaderBoardModel>(request);
            return response;
        }
    }
}