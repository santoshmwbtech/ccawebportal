using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class ForgotPasswordController : Controller
    {
        CustomerCreations DAL = new CustomerCreations();
        // GET: ForgotPassword
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(UserLogin userLogin)
        {
            string BaseURL = GetBaseUrl();
            UserLogin Result = DAL.ForgotPassword(userLogin, BaseURL);
            return Json(Result.Message);
        }
        public string GetBaseUrl()
        {
            var request = HttpContext.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}