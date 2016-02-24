using System.Collections.Generic;
using Skoolbo.ApiClient.Models.AnalysisLeaderboardModels;

namespace Skoolbo.ApiClient.AnalysisLeaderboardClients
{
    public interface IAnalysisLeaderboardClient
    {
        int GetSchoolRegister(string region);
        int GetPersonalBestTotal(string region);
        List<PersonalBestModel> GetPersonalBest(int limit);
        DailyAnalysisModel GetDailyAnalysis(string region);
        TotalizerModel GetLeaderboardTotalizer(bool isGlobal, string accessToken);

        LeaderBoardModel GetLeaderboardStudents(string timeFilter, bool isGlobal, string accessToken);

        LeaderBoardModel GetLeaderboardClasses(string timeFilter, bool isGlobal, string accessToken);

        LeaderBoardModel GetLeaderboardSchools(string timeFilter, bool isGlobal, string accessToken);
    }
}