using System;
using System.Diagnostics;
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
                    webClient.Encoding = Encoding.UTF8;
                    webClient.Headers.Add("Content-Type", "application/rss+xml;charset=UTF-8");
                    webClient.Headers.Add("User-Agent", "Mozilla / 5.0(Windows NT 6.1; WOW64; rv: 49.0) Gecko / 20100101 Firefox / 49.0");

                    return webClient.DownloadString(url);
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return string.Empty;
            }
        }




    }
}
