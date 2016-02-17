using System;
using Newtonsoft.Json;

namespace Skoolbo.ApiClient.Models.AnalysisLeaderboardModels
{
    public class TotalScoreModel
    {
        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }

        [JsonProperty(PropertyName = "time_stamp")]
        public DateTime TimeStamp { get; set; }
    }
}
