using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class TallySyncErrorRptController : Controller
    {
        // GET: TallySyncErrorRpt
        TallySync tallySync = new TallySync();
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
        public ActionResult Search()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult ErrorsList()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                TallySyncErrorDTO search = new TallySyncErrorDTO();
                search.OrgID = Session["OrgID"].ToString();
                var errorsList = tallySync.GetTallySyncErrors(search);
                return PartialView(errorsList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult Search(TallySyncErrorDTO search)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                search.OrgID = Session["OrgID"].ToString();
                var errorsList = tallySync.GetTallySyncErrors(search);
                return PartialView("ErrorsList", errorsList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}