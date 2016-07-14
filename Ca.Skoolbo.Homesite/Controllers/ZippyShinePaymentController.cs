using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skoolbo.ApiClient.ZippyShinePaymentClients;

namespace Ca.Skoolbo.Homesite.Controllers
{
    public class ZippyShinePaymentController : Controller
    {
        private IZippyShinePaymentClient _paymentClient;

        public ZippyShinePaymentController(IZippyShinePaymentClient paymentClient)
        {
            _paymentClient = paymentClient;
        }


        [Route("payment-success")]
        public ActionResult Success(string id)
        {
            //    if (string.IsNullOrEmpty(id))
            //        return RedirectToAction("Download", "Home");

            var payment = _paymentClient.GetLicenseByKey(id);

            //if (payment != null)
                return View(payment);

            return RedirectToAction("Download", "Home");
        }
    }
}