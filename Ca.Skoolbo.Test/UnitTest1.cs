using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ca.Skoolbo.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/rss+xml;charset=UTF-8");
                webClient.Headers.Add("User-Agent", "Mozilla / 5.0(Windows NT 6.1; WOW64; rv: 49.0) Gecko / 20100101 Firefox / 49.0");
                var dataString = webClient.DownloadString("http://blog.skoolbo.ca/feed");
                
                Trace.WriteLine(dataString);

                Assert.IsTrue(!string.IsNullOrEmpty(dataString));
            }
        }
    }
}
