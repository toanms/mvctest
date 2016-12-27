using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Skoolbo.ApiClient.Models.AnalysisLeaderboardModels
{
   public class TotalizerModel
    {
        [JsonProperty(PropertyName = "event_id")]
        public string EventId { get; set; }

        [JsonProperty(PropertyName = "result")]
        public List<TotalScoreModel> Result { get; set; }

        [JsonProperty(PropertyName = "time_stamp")]
        public DateTime TimeStamp { get; set; }
    }
}
