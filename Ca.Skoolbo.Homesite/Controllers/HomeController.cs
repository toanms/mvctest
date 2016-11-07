using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;
using Ca.Skoolbo.Homesite.Extensions;
using Ca.Skoolbo.Homesite.Helpers;
using Ca.Skoolbo.Homesite.Models;
using WebGrease;

namespace Ca.Skoolbo.Homesite.Controllers
{
    public class HomeController : Controller
    {

        private string _feedLink = WebConfigurationManager.AppSettings["Blog"] + "/feed/";
        
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

        public ContentResult GetFeed()
        {
            string cacheKey = "NewsFeedCacheKey";

            MemoryCache cache = MemoryCache.Default;

            if (cache.Contains(cacheKey))
            {
                var feed = cache.Get(cacheKey);
                if (feed != null)
                {
                    return Content(feed.ToString(), "text/xml");
                }
            }
            else
            {
                try
                {
                    var data = WebClientHelper.Download(_feedLink);

                    if (!string.IsNullOrEmpty(data))
                    {
                        DateTimeOffset dt = DateTimeOffset.UtcNow;
                        cache.Add(cacheKey, data, dt.Add(TimeSpan.FromMinutes(30)));
                    }
                    return Content(data, "text/xml");
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }
            }
            return Content(string.Empty, "text/xml");
        }


        [HttpGet]
        public ActionResult HoldingPage()
        {
            var model = new SubscribeModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HoldingPage(SubscribeModel model)
        {
            if (ModelState.IsValid)
            {
                BlobHelper blobHelper = new BlobHelper();
                blobHelper.SaveToBlob(model.Email);
                TempData["IsRegister"] = true;
            }

            return RedirectToAction("HoldingPage");
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

    public class XmlResult : ActionResult
    {
        private object objectToSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResult"/> class.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize to XML.</param>
        public XmlResult(object objectToSerialize)
        {
            this.objectToSerialize = objectToSerialize;
        }

        /// <summary>
        /// Gets the object to be serialized to XML.
        /// </summary>
        public object ObjectToSerialize
        {
            get { return this.objectToSerialize; }
        }

        /// <summary>
        /// Serialises the object that was passed into the constructor to XML and writes the corresponding XML to the result stream.
        /// </summary>
        /// <param name="context">The controller context for the current request.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (this.objectToSerialize != null)
            {
                context.HttpContext.Response.Clear();
                var xs = new System.Xml.Serialization.XmlSerializer(this.objectToSerialize.GetType());
                context.HttpContext.Response.ContentType = "text/xml";
                xs.Serialize(context.HttpContext.Response.Output, this.objectToSerialize);
            }
        }
    }
}