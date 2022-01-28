using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class DashboardController : Controller
    {
        CustomerCreations customerCreations = new CustomerCreations();
        // GET: Dashboard
        DLGetUserCreation DLUser = new DLGetUserCreation();
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public JsonResult GetDashboardData()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                return Json(customerCreations.GetDashboardData(string.Empty, string.Empty, Session["OrgID"].ToString()));
            }
            else
            {
                return Json("sessionexpired");
            }

        }
        [HttpPost]
        public JsonResult Search(string dates)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                string[] splitStr = dates.Split('~');
                string FromDate = splitStr[0];
                string ToDate = splitStr[1];
                return Json(customerCreations.GetDashboardData(FromDate, ToDate, Session["OrgID"].ToString()));
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        public ActionResult _templates()
        {
            List<Templates> templates = new List<Templates>();
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                DLTemplates dLTemplates = new DLTemplates();                
                templates = dLTemplates.GetAllTemplates(Session["OrgID"].ToString());
                return PartialView(templates);
            }
            else
            {
                return PartialView(templates);
            }
        }
        public ActionResult ServiceInstall()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                var userData = DLUser.GetUserDeatil(Convert.ToInt32(Session["UserID"].ToString()));
                if(userData.IsServiceInstalled == true)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}