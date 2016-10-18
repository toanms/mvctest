using Newtonsoft.Json;

namespace Skoolbo.ApiClient.Models.ZippyShinePaymentModel
{
    public class ZippyLicenseModel
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
