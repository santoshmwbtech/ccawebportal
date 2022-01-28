using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;
using WBT.Entity;

namespace CCAPortal.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        DLSettings dLSettings = new DLSettings();
        DLSystemDetails dLSystemDetails = new DLSystemDetails();
        public ActionResult Index()
        {
            if (Session["UserID"] != null || Session["OrgID"] != null)
            {
                ViewBag.SSL = new SelectList(
                                    new List<SelectListItem>
                                    {   
                                        new SelectListItem { Text = "False", Value = "False"},
                                        new SelectListItem { Text = "True", Value = "True" },
                                    }, "Value", "Text");
                return View(dLSettings.GetSettings(Session["OrgID"].ToString()));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Settings settings)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                string OrgID = Session["OrgID"].ToString();
                int LoginUserID = Convert.ToInt32(Session["UserID"]);

                Settings Result = dLSettings.Update(settings, OrgID, LoginUserID);

                return Json(Result.DisplayMessage);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public JsonResult GetSystemDetails()
        {
            var Result = string.Empty;
            bool isTallyOpen = false;
            if (Session["UserID"] != null || Session["OrgID"] != null)
            {
                var orgSystemDetails = dLSystemDetails.GetSystemDetails(Session["OrgID"].ToString());
                if(orgSystemDetails != null)
                {
                    isTallyOpen = orgSystemDetails.IsTallyRunning.Value;
                    if (orgSystemDetails.IsTallyRunning.Value == true)
                        Result = "Tally Running";
                    else
                        Result = "Tally Not Running";
                }
                else
                    Result = "Tally Not Running";
                var IResult = new
                {
                    IsTallyOpen = isTallyOpen,
                    Message = Result
                };
                return Json(IResult, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Result = "Tally Not Running";
                var IResult = new
                {
                    IsTallyOpen = false,
                    Message = Result
                };
                return Json(IResult, JsonRequestBehavior.AllowGet);
            }
        }
    }
}