using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.Common;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class ResetPasswordController : Controller
    {
        DLUserCreation DAL = new DLUserCreation();
        // GET: ResetPassword
        public ActionResult Index(string route)
        {
            if (!string.IsNullOrEmpty(route))
            {
                ChangePassword changePassword = new ChangePassword();
                string UserID = Helper.Decrypt(route);
                changePassword.UserID = Convert.ToInt32(UserID);
                return View(changePassword);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(ChangePassword changepassword)
        {
            DLChangePassword dLChangePassword = new DLChangePassword();
            ChangePassword Result = dLChangePassword.UpdatePassword(changepassword);
            return Json(Result.ReturnMessage);
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