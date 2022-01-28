using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class MyProfileController : Controller
    {
        DLGetUserCreation dLUser = new DLGetUserCreation();
        DLChangePassword dLChangePassword = new DLChangePassword();
        // GET: MyProfile
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                DLUserCreation user = dLUser.GetUserDeatil(Convert.ToInt32(Session["UserID"].ToString()));
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult PasswordView()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateProfile(DLUserCreation userCreation)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                userCreation.UserID = Convert.ToInt32(Session["UserID"].ToString());
                string Result = dLChangePassword.UpdateProfile(userCreation);
                return Json(Result);
            }
            else
            {
                return Json("sessionExpired");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdatePassword(ChangePassword changePassword)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                changePassword.UserID = Convert.ToInt32(Session["UserID"].ToString());
                ChangePassword Result = dLChangePassword.UpdatePassword(changePassword);
                return Json(Result.ReturnMessage);
            }
            else
            {
                return Json("sessionExpired");
            }
        }

        [HttpPost]
        public JsonResult ValidatePassword(string oldPassword)
        {
            if (Session["UserID"] != null)
            {
                int Result = dLChangePassword.ValidatePassword(oldPassword, Convert.ToInt32(Session["UserID"].ToString()));
                return Json(Result);
            }
            else
            {
                return Json("sessionexpired");
            }

        }
    }
}