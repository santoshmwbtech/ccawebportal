using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class CategoryController : Controller
    {
        DLSubCategoryCreation dlSubCategoryCreation = new DLSubCategoryCreation();
        DLSubCategory dlSubCategory = new DLSubCategory();
        // GET: Category
        public ActionResult Index()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            return View(dlSubCategory.GetDatas("", Session["OrgID"].ToString()));
        }

        public ActionResult Create()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            ViewBag.CatgList = new SelectList(dlSubCategory.GetCategoryList(Session["OrgID"].ToString()), "CategoryID", "CategoryName");            
            return PartialView();
        }

        public ActionResult CategoryList()
        {
            List<DLSubCategoryCreation> result = new List<DLSubCategoryCreation>();
            try
            {
                result = dlSubCategory.GetDatas("",Session["OrgID"].ToString());
            }
            catch (Exception ex)
            {

            }
            return PartialView(result);
        }

        [HttpPost]
        public ActionResult Save(DLSubCategoryCreation dLSubCategoryCreation)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            else
            {
                dLSubCategoryCreation.OrgID = Session["OrgID"].ToString();
                dLSubCategoryCreation.CreatedByID = Convert.ToInt32(Session["UserID"].ToString());
                DLSubCategoryCreation Result = dlSubCategory.SaveDatas(dLSubCategoryCreation);
                return Json(Result.DisplayMessage); //return  PartialView("CategoryList", dlSubCategory.GetDatas("", Session["OrgID"].ToString()).ToList());
            }
        }

        public ActionResult Edit(int SubCategoryID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (SubCategoryID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DLSubCategoryCreation obj = dlSubCategory.GetDetails(SubCategoryID.ToString(), Session["OrgID"].ToString());

            if (obj == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatgList = new SelectList(dlSubCategory.GetCategoryList(Session["OrgID"].ToString()), "CategoryID", "CategoryName");
            return PartialView("Edit", obj);
        }

        [HttpPost]
        public ActionResult UpdateCategory(DLSubCategoryCreation catg)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                DLSubCategoryCreation Result = dlSubCategory.SaveCategory(catg, Convert.ToInt32(Session["UserID"].ToString()), Session["OrgID"].ToString());

                return Json(new
                {
                    Message = Result.DisplayMessage,
                    AjaxReturn = PartialView("CategoryList", dlSubCategory.GetDatas("", Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }            
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

                return Json(new
                {
                    ID = 0,
                    Message = allErrors,
                    AjaxReturn = PartialView("CategoryList", dlSubCategory.GetDatas("", Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
        }
    }
}