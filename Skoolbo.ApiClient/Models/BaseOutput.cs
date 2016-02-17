using Newtonsoft.Json;

namespace Skoolbo.ApiClient.Models
{
    public class BaseOutput<T> : BaseNotDataOutput
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        public static BaseOutput<T> GetSuccessOutput(string id = "")
        {
            return new BaseOutput<T>
            {
                Code = "200",
                Message = "Successful.",
                Id = id
            };
        }

        public static BaseOutput<T> GetFailOutput(string id = "")
        {
            return new BaseOutput<T>
            {
                Code = "400",
                Message = "Fail.",
                Id = "id"
            };
        }

        public bool IsSuccess
        {
            get { return !string.IsNullOrEmpty(Code) && Code == "200"; }
        }
    }
}
