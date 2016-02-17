using Newtonsoft.Json;

namespace Skoolbo.ApiClient.Models.AnalysisLeaderboardModels
{
    public class RankLeaderBoardModel
    {
        [JsonProperty(PropertyName = "class_name")]
        public string ClassName { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "dna")]
        public string Dna { get; set; }

        [JsonProperty(PropertyName = "player_id")]
        public string PlayerId { get; set; }

        [JsonProperty(PropertyName = "school_code")]
        public string SchoolCode { get; set; }

        [JsonProperty(PropertyName = "school_name")]
        public string SchoolName { get; set; }

        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "state_id")]
        public string StateId { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
    }
}
