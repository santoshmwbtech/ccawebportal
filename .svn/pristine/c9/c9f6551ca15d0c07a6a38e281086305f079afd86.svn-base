using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class ItemCompanyController : Controller
    {
        DLItemCompany DL = new DLItemCompany();
        // GET: ItemCompany
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {

                return View(DL.GetData(Session["OrgID"].ToString()).ToList());
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
        public ActionResult Save(ItemCompany itemCompany)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                ItemCompany Result = DL.SaveData(itemCompany, Session["OrgID"].ToString(), Session["UserID"].ToString());
                return Json(Result.DisplayMessage);
            }
            else
            {
                return Json("Error");
            }
        }
        public ActionResult CompanyList()
        {
            List<ItemCompany> result = new List<ItemCompany>();
            try
            {
                result = DL.GetData(Session["OrgID"].ToString());
            }
            catch (Exception ex)
            {

            }
            return PartialView(result);
        }
        public ActionResult Edit(int ItemCompanyID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (ItemCompanyID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ItemCompany itemCompany = DL.GetItemCompanyDetail(ItemCompanyID);

            if (itemCompany == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", itemCompany);
        }
        public ActionResult Delete(int ItemCompanyID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (ItemCompanyID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DLRoleCreation Result = DL.DeleteItemCompany(ItemCompanyID, Session["OrgID"].ToString(), Session["UserID"].ToString());
            return Json(Result.DisplayMessage, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ItemCompany itemCompany)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            if (ModelState.IsValid)
            {
                ItemCompany Result = DL.SaveData(itemCompany, Session["OrgID"].ToString(), Session["UserID"].ToString());
                return Json(new
                {
                    Message = Result.DisplayMessage,
                    AjaxReturn = PartialView("CompanyList", DL.GetData(Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
            else
            {
                return Json(new
                {
                    Message = "Error!!",
                    AjaxReturn = PartialView("CompanyList", DL.GetData(Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
        }
    }
}