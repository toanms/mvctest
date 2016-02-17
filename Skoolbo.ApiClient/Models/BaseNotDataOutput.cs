using Newtonsoft.Json;

namespace Skoolbo.ApiClient.Models
{
    public class BaseNotDataOutput
    {
        public string Id { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
