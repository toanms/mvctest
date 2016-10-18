using System;
using Newtonsoft.Json;

namespace Ca.Skoolbo.Homesite.Models.LeaderboardModels
{
    public class PersonalBestModel
    {
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("data")]
        public string DataJson { get; set; }
        public CategoryPersonal Data
        {
            get
            {
                if (!string.IsNullOrEmpty(DataJson))
                {
                    return JsonConvert.DeserializeObject<CategoryPersonal>(DataJson);
                }
                return null;
            }
        }
        [JsonProperty("event")]
        public string Event { get; set; }
        [JsonProperty("user")]
        public string UserJson { get; set; }
        public UserPersonalBest User
        {
            get
            {
                if (!string.IsNullOrEmpty(UserJson))
                {
                    return JsonConvert.DeserializeObject<UserPersonalBest>(UserJson);
                }
                return null;
            }
        }
        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class CategoryPersonal
    {
        [JsonProperty("course")]
        public string Course { get; set; }
        [JsonProperty("category_code")]
        public string CategoryCode { get; set; }
    }
    public class UserPersonalBest
    {
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("class_name")]
        public string ClassName { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("dna")]
        public string Dna { get; set; }
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        [JsonProperty("luckyPrizeExpired")]
        public string LuckyPrizeExpired { get; set; }
        [JsonProperty("player_id")]
        public string PlayerId { get; set; }
        [JsonProperty("school_code")]
        public string SchoolCode { get; set; }
        [JsonProperty("vehicle")]
        public string Vehicle { get; set; }
    }

}
