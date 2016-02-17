using System.Globalization;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace Skoolbo.RestSharpExtension.Extensions
{
    public class RestSharpJsonDeserializer : IDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public CultureInfo Culture { get; set; }

        public RestSharpJsonDeserializer()
        {
            Culture = CultureInfo.InvariantCulture;
            
        }

        public T Deserialize<T>(IRestResponse response)
        {
            if(response != null && !string.IsNullOrEmpty(response.Content))
                return JsonConvert.DeserializeObject<T>(response.Content);

            return default(T);
        }
    }
}