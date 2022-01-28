using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class SalesChannelTypeController : Controller
    {
        DLSalesChannelType dLSalesChannelType = new DLSalesChannelType();
        // GET: SalesChannelType
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
            ViewBag.SalesChannelTypeList = new SelectList(dLSalesChannelType.GetSalesChannelTypeList(Session["OrgID"].ToString()), "ID", "ChannelType");
            return PartialView();
        }
        public ActionResult SalesChannelTypeList()
        {
            return PartialView(dLSalesChannelType.GetSalesChannelTypeList(Session["OrgID"].ToString()).ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SalesChannelType salesChannelType)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                if (dLSalesChannelType.SaveSalesChannelType(salesChannelType, Session["UserID"].ToString(), Session["OrgID"].ToString()).DisplayMessage.ToLower().Contains("success"))
                {
                    ModelState.Clear();
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return PartialView("SalesChannelTypeList", dLSalesChannelType.GetSalesChannelTypeList(Session["OrgID"].ToString()).ToList());
        }
        public ActionResult Edit(int? ID)
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.SalesChannelTypeList = new SelectList(dLSalesChannelType.GetSalesChannelTypeList(Session["OrgID"].ToString()), "ID", "ChannelType");
            SalesChannelType obj = dLSalesChannelType.GetSalesChannelTypeDetails(ID);

            if (obj == null)
            {
                return HttpNotFound();
            }

            return PartialView("Edit", obj);
        }
        public ActionResult Delete(int ID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (ID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesChannelType Result = dLSalesChannelType.DeleteChannelType(ID, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result.DisplayMessage, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SalesChannelType salesChannelType)
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                if (dLSalesChannelType.SaveSalesChannelType(salesChannelType, Session["UserID"].ToString(), Session["OrgID"].ToString()).DisplayMessage.ToLower().Contains("success"))
                {
                    ModelState.Clear();
                    return PartialView("SalesChannelTypeList", dLSalesChannelType.GetSalesChannelTypeList(Session["OrgID"].ToString()).ToList());
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public JsonResult CheckDuplicateChannelType(string ChannelType)
        {
            if (dLSalesChannelType.CheckDuplicateChannelType(ChannelType, Session["OrgID"].ToString()))
            {
                return Json("Channel type already exists.. please try different one", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("success", JsonRequestBehavior.AllowGet);
            }
        }
    }
}