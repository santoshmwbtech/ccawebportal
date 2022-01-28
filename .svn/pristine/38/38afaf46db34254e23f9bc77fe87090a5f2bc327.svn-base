using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class UCMappingsController : Controller
    {
        DLUCMappings dLUC = new DLUCMappings();
        // GET: UCMappings
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ViewBag.UserTypes = new SelectList(
                                    new List<SelectListItem>
                                    {
                                        new SelectListItem { Text = "Select", Value = "" },
                                        new SelectListItem { Text = "Marketing Team", Value = "1" },
                                        new SelectListItem { Text = "Channel Partners", Value = "2"},
                                    }, "Value", "Text");
                ViewBag.UserList = new SelectList(
                                    new List<SelectListItem>
                                    {
                                        new SelectListItem { Text = "Select", Value = "" },
                                    }, "Value", "Text");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public JsonResult UserTypeChanged(int? UserType)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                return Json(dLUC.GetUserList(UserType, 0, Session["OrgID"].ToString()), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public ActionResult UserChanged(int? UserType, int? ID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                List<UserDetails> UserList = new List<UserDetails>();
                UserList = dLUC.GetUsers(UserType, ID, Session["OrgID"].ToString());
                return PartialView("UserList", UserList);
            }
            else
            {
                return Json("sessionexpired");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Save(UCMappings uCMappings, List<UserDetails> UserList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                UCMappings Result = new UCMappings();
                uCMappings.Users = UserList;
                Result = dLUC.Save(uCMappings, Convert.ToInt32(Session["UserID"].ToString()));
                return Json(Result.DisplayMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult LoadSwapUsers(int? UserType, int? ID)
        {
            return Json(dLUC.GetUserList(UserType, ID, Session["OrgID"].ToString()), JsonRequestBehavior.AllowGet);
        }
    }
}