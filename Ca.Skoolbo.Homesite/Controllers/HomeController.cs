using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;
using Ca.Skoolbo.Homesite.Helpers;
using Ca.Skoolbo.Homesite.Models;

namespace Ca.Skoolbo.Homesite.Controllers
{
    public class HomeController : Controller
    {
        private string _feedLink = WebConfigurationManager.AppSettings["Blog"] + "?feed=rss2";
        public ActionResult Index()
        {
            return View();
        }

        [Route("about", Name = "About")]
        public ActionResult About()
        {
            return View();
        }

        [Route("ambassador", Name = "Ambassador")]
        public ActionResult Ambassador()
        {
            return View();
        }

        [Route("partner", Name = "Partner")]
        public ActionResult Partner()
        {
            return View();
        }

                [Route("creatagon", Name = "Creatagon")]
        public ActionResult Creatagon()
        {
            return View();
        }
        
        [Route("testimonials", Name = "Testimonials")]
        public ActionResult Testimonials()
        {
            return View();
        }

        [Route("pricing", Name = "Pricing")]
        public ActionResult Pricing()
        {
            return View();
        }

        [Route("faq", Name = "Faq")]
        [Route("pf", Name = "FaqMx")]
        public ActionResult Faq()
        {
            return View();
        }

        [Route("contact", Name = "Contact")]
        public ActionResult Contact()
        {
            return View();
        }
        [Route("safety", Name = "safety")]
        public ActionResult ChildSafetyPolicy()
        {
            return View();
            //return RedirectToAction("TermsAndConditions");
        }
        [Route("terms", Name = "terms")]
        public ActionResult TermsAndConditions()
        {
            return View();
        }
        [Route("privacy", Name = "privacy")]
        public ActionResult PrivacyPolicy()
        {
            return View();
        }


        [Route("downloads", Name = "Download")]
        public ActionResult Download()
        {
            return View();
        }

        [Route("downloads/popsnaz/{id}")]
        public ActionResult DownloadFile(string id)
        {
            string filePath = string.Empty;
            switch (id.ToLower())
            {
                case "3d-cup":
                    filePath = "~/Images/Downloads/PopSnaz/SkoolBo-3D-Cup.pdf";
                    break;
                case "superhero":
                    filePath = "~/Images/Downloads/PopSnaz/SkoolBo-SuperHero.pdf";
                    break;
            }

            string filepath = Server.MapPath(filePath);
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);

            return File(filedata, MimeMapping.GetMimeMapping(filepath), Path.GetFileName(filepath));
        }

        [Route("mannypacquiao", Name = "MannyPacquiao")]
        public ActionResult MannyPacquiao()
        {
            return View();
        }

        [Route("contest", Name = "Contest")]
        public ActionResult Contest()
        {
            return View();
        }
        //mannypacquiao

        public  ActionResult GetFeed()
        {
            var data = WebClientHelper.Download(_feedLink);
            List<FeedModel> dataShow = new List<FeedModel>();
            if (string.IsNullOrEmpty(data)) return PartialView(dataShow);

            var xmlDoc = XDocument.Parse(data);
            var channel = xmlDoc.Descendants("channel");
            channel.ForEach(item =>
            {
                var result = item.Descendants("item");
                result.Take(3).ForEach(itemResult =>
                {
                    var feedModel = new FeedModel
                    {
                        Title = GetValueElement(itemResult, "title"),
                        Date = GetValueElement(itemResult, "pubDate").ToDateTimeOrDefault(null),
                        Image = GetAttribvalueElement(itemResult, "enclosure", "url"),
                        Link = GetValueElement(itemResult, "link"),
                        Summary = GetValueElement(itemResult, "description")
                    };

                    if (!string.IsNullOrEmpty(feedModel.Summary))
                    {
                        var tagP = feedModel.Summary.IndexOf("</p>", StringComparison.Ordinal);
                        if (tagP != -1 && tagP != 2)
                        {
                            feedModel.Summary = feedModel.Summary.Substring(0, tagP - 1);
                        }
                    }

                    dataShow.Add(feedModel);
                });
            });
            return PartialView(dataShow);
        }

        #region PrivateMethod
        private static string GetAttribvalueElement(XContainer item, string key, string attribKey)
        {
            var result = item.Element(key);
            if (result != null)
            {
                var attrib = result.Attribute(attribKey);
                if (attrib != null)
                {
                    return attrib.Value;
                }
            }
            return string.Empty;
        }
        private static string GetValueElement(XContainer item, string key)
        {
            var result = item.Element(key);
            return result != null ? result.Value : string.Empty;
        }
        #endregion
    }
}