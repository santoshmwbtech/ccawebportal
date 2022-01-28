using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class BusinessTypesController : Controller
    {
        // GET: BusinessTypes
        DLBusinessTypes dLBusinessTypes = new DLBusinessTypes();
        // GET: BusinessTypes
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
        public ActionResult Save(MBusinessType BusinessType)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                MBusinessType Result = dLBusinessTypes.SaveData(BusinessType, Session["OrgID"].ToString(), Session["UserID"].ToString());
                return Json(Result.DisplayMessage);
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Json(new { allErrors });
            }
        }
        public ActionResult BusinessTypeList()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }

            List<MBusinessType> result = new List<MBusinessType>();
            try
            {
                result = dLBusinessTypes.GetData(Session["OrgID"].ToString());
            }
            catch (Exception ex)
            {

            }
            return PartialView(result);
        }
        public ActionResult Edit(int BusinessTypeID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (BusinessTypeID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MBusinessType BusinessType = dLBusinessTypes.GetBusinessTypeDetails(BusinessTypeID);

            if (BusinessType == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", BusinessType);
        }
        public ActionResult Delete(int BusinessTypeID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (BusinessTypeID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MBusinessType Result = dLBusinessTypes.DeleteBusinessType(BusinessTypeID, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result.DisplayMessage, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MBusinessType BusinessType)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (ModelState.IsValid)
            {
                MBusinessType Result = dLBusinessTypes.SaveData(BusinessType, Session["OrgID"].ToString(), Session["UserID"].ToString());
                return Json(new
                {
                    Message = Result.DisplayMessage,
                    AjaxReturn = PartialView("BusinessTypeList", dLBusinessTypes.GetData(Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Json(new
                {
                    Message = allErrors,
                    AjaxReturn = PartialView("BusinessTypeList", dLBusinessTypes.GetData(Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
        }
    }
}