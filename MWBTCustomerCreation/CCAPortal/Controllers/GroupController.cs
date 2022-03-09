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
        DLCategory _categoryRepository = new DLCategory();
        DLSubCategory _subCategoryRepository = new DLSubCategory();

        //public GroupController(DLCategory category, DLSubCategory subCategory)
        //{
        //    _categoryRepository = category;
        //    _subCategoryRepository = subCategory;
        //}
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

        public ActionResult Create()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ViewBag.CatgList = new SelectList(_subCategoryRepository.GetCategoryList(Session["OrgID"].ToString()), "CategoryID", "CategoryName");
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
                DLCategoryCreation Result = _categoryRepository.SaveData(dLCategoryCreation);
                return Json(Result.DisplayMessage);
            }             
        }

        public ActionResult GroupList()
        {
            var result = new List<DLCategoryCreation>();
            try
            {
                result = _categoryRepository.GetData("", Session["OrgID"].ToString());
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
            
            DLCategoryCreation categoryGroup = _categoryRepository.GetDetails(CategoryID, Session["OrgID"].ToString());

            if (categoryGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatgList = new SelectList(_subCategoryRepository.GetCategoryList(Session["OrgID"].ToString()), "CategoryID", "CategoryName");
            return PartialView("Edit", categoryGroup);
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
                DLCategoryCreation Result = _categoryRepository.SaveGroup(catg, Convert.ToInt32(Session["UserID"].ToString()), Session["OrgID"].ToString());
                return Json(new
                {
                    Message = Result.DisplayMessage,
                    AjaxReturn = PartialView("GroupList", _categoryRepository.GetData("", Session["OrgID"].ToString()).ToList()).RenderToString()
                });                
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return Json(new
                {
                     Message = allErrors,
                     AjaxReturn = PartialView("GroupList", _categoryRepository.GetData("", Session["OrgID"].ToString()).ToList()).RenderToString()
                });
            }
        }
    }
}