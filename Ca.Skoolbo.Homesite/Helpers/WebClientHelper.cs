using System.Net;
using System.Text;

namespace Ca.Skoolbo.Homesite.Helpers
{
    public static class WebClientHelper
    {
        public static string Download(string url)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Encoding =
                    Encoding.UTF8;
                    return webClient.DownloadString(url);
                }
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
