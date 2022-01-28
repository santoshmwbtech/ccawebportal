using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class GroupController : Controller
    {
        DLCategory dlcc = new DLCategory();
        DLSubCategory dlSubCategory = new DLSubCategory();
        // GET: Group
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

        public ActionResult Create(DLCategoryCreation dLCategory)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ViewBag.CatgList = new SelectList(dlSubCategory.GetCategoryList(), "CategoryID", "CategoryName");
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Save(DLCategoryCreation dLCategoryCreation)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            else
            {
                dLCategoryCreation.OrgID = Session["OrgID"].ToString();
                dLCategoryCreation.CreatedByID = Convert.ToInt32(Session["UserID"].ToString());
                DLCategoryCreation Result = dlcc.SaveData(dLCategoryCreation);
                return Json(Result.DisplayMessage);
            }             
        }

        public ActionResult GroupList()
        {
            List<DLCategoryCreation> result = new List<DLCategoryCreation>();
            try
            {
                result = dlcc.GetData("", Session["OrgID"].ToString());
            }
            catch (Exception ex)
            {

            }
            return PartialView(result);
        }

        public ActionResult Edit(int CategoryID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (CategoryID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            DLCategoryCreation obj = dlcc.GetDetails(CategoryID, Session["OrgID"].ToString());

            if (obj == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatgList = new SelectList(dlSubCategory.GetCategoryList(), "CategoryID", "CategoryName");
            //ViewBag.CatgList = new SelectList(dlSubCategory.GetPrimaryCategoryList(), "CategoryId", "CategoryName");
            return PartialView("Edit", obj);
        }


        [HttpPost]
        public ActionResult UpdateGroup(DLCategoryCreation catg)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                DLCategoryCreation Result = dlcc.SaveGroup(catg, Convert.ToInt32(Session["UserID"].ToString()), Session["OrgID"].ToString());
                return Json(new
                {
                    Message = Result.DisplayMessage,
                    AjaxReturn = PartialView("GroupList", dlcc.GetData("", Session["OrgID"].ToString()).ToList()).RenderToString()
                });                
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Json(new
                {
                     Message = allErrors,
                     AjaxReturn = PartialView("GroupList", dlcc.GetData("", Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
        }
    }
}