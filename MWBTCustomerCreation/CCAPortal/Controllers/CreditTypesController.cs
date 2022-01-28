using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class CreditTypesController : Controller
    {
        DLCreditTypes dLCreditTypes = new DLCreditTypes();
        // GET: CreditTypes
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
        public ActionResult Create()
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MCreditType creditType)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                MCreditType Result = dLCreditTypes.SaveData(creditType, Session["OrgID"].ToString(), Session["UserID"].ToString());
                return Json(Result.DisplayMessage);
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Json(new { allErrors });
            }
        }
        public ActionResult CreditTypeList()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }

            List<MCreditType> result = new List<MCreditType>();
            try
            {
                result = dLCreditTypes.GetData(Session["OrgID"].ToString());
            }
            catch (Exception ex)
            {

            }
            return PartialView(result);
        }
        public ActionResult Edit(int CreditTypeID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (CreditTypeID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MCreditType creditType = dLCreditTypes.GetCreditTypeDetails(CreditTypeID);

            if (creditType == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", creditType);
        }
        public ActionResult Delete(int CreditTypeID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (CreditTypeID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MCreditType Result = dLCreditTypes.DeleteCreditType(CreditTypeID, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result.DisplayMessage, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MCreditType creditType)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (ModelState.IsValid)
            {
                MCreditType Result = dLCreditTypes.SaveData(creditType, Session["OrgID"].ToString(), Session["UserID"].ToString());
                return Json(new
                {
                    Message = Result.DisplayMessage,
                    AjaxReturn = PartialView("CreditTypeList", dLCreditTypes.GetData(Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Json(new
                {
                    Message = allErrors,
                    AjaxReturn = PartialView("CreditTypeList", dLCreditTypes.GetData(Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
        }
    }
}