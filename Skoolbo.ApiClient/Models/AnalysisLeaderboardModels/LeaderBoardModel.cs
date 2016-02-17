using System.Collections.Generic;
using Newtonsoft.Json;

namespace Skoolbo.ApiClient.Models.AnalysisLeaderboardModels
{
    public class LeaderBoardModel
    {
        public LeaderBoardModel()
        {
            Ranks = new List<RankLeaderBoardModel>();
        }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "myScore")]
        public string MyScore { get; set; }
        [JsonProperty(PropertyName = "overallScore")]
        public double OverallScore { get; set; }
        [JsonProperty(PropertyName = "ranks")]
        public List<RankLeaderBoardModel> Ranks { get; set; }
    }
}
