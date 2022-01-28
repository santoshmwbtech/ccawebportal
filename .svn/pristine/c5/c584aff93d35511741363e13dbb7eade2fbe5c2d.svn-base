using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class PriceMasterController : Controller
    {
        DLItem dLItem = new DLItem();
        DLItemRate DLItemRate = new DLItemRate();
        // GET: PriceMaster
        public ActionResult Index()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ViewBag.Groups = new SelectList(DLItemRate.GetCategories(Session["OrgID"].ToString()), "CategoryID", "CategoryName");
                ViewBag.Categories = new SelectList(DLItemRate.GetSubCategories(Session["OrgID"].ToString(), 0), "subCategoryID", "SubCategoryName");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult ItemList()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                DLItemRateCreation Criteria = new DLItemRateCreation()
                {
                    CategoryID = 0,
                    SubCategoryID = 0,
                    ItemName = "",//
                    OrgID = Session["OrgID"].ToString(),
                };
                List<DLItemRateCreation> itemList = new List<DLItemRateCreation>();
                itemList = dLItem.GetItemNameAndPriceForCategory(Criteria);
                return PartialView(itemList);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public JsonResult GroupChanged(int CategoryID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json("sessionexpired");
            }
            List<SubCategoryDetails> subcategories = DLItemRate.GetSubCategories(Session["OrgID"].ToString(), CategoryID);
            return Json(subcategories, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetItems(int? CategoryID, int? SubCategoryID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json("sessionexpired");
            }
            if (CategoryID == null)
                CategoryID = 0;

            if (SubCategoryID == null)
                SubCategoryID = 0;

            DLItemRateCreation Criteria = new DLItemRateCreation()
            {
                CategoryID = CategoryID.Value,
                SubCategoryID = SubCategoryID.Value,
                ItemName = "",//
                OrgID = Session["OrgID"].ToString(),
            };
            List<DLItemRateCreation> itemList = new List<DLItemRateCreation>();
            itemList = dLItem.GetItemNameAndPriceForCategory(Criteria);
            return PartialView("ItemList", itemList);
        }
        [HttpPost]
        public ActionResult SearchByName(string Name, int? CategoryID, int? SubCategoryID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json("sessionexpired");
            }
            if (CategoryID == null)
                CategoryID = 0;

            if (SubCategoryID == null)
                SubCategoryID = 0;
            DLItemRateCreation Criteria = new DLItemRateCreation()
            {
                CategoryID = CategoryID.Value,
                SubCategoryID = SubCategoryID.Value,
                ItemName = Name,//
                OrgID = Session["OrgID"].ToString(),
            };
            List<DLItemRateCreation> itemList = new List<DLItemRateCreation>();
            itemList = dLItem.GetItemNameAndPriceForCategory(Criteria);
            return PartialView("ItemList", itemList);
        }
        [HttpPost]
        public JsonResult UpdatePrice(int? RateID, decimal? BaseRateOther)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json("sessionexpired");
            }
            string Result = DLItemRate.UpdatePrice(RateID, BaseRateOther, Session["UserID"].ToString());
            return Json(Result);
        }
        [HttpPost]
        public ActionResult UpdatePriceList(PriceMaster priceMaster, List<DLItemRateCreation> dLItemRates)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return Json(new { url = Url.Action("Index", "Login") });
            }
            DLItemRateCreation Criteria = new DLItemRateCreation()
            {
                CategoryID = 0,
                SubCategoryID = 0,
                ItemName = "",//
                OrgID = Session["OrgID"].ToString(),
            };
            if (ModelState.IsValid)
            {
                priceMaster.ItemsWithRates = dLItemRates;
                DLItemRateCreation Result = DLItemRate.UpdatePriceList(priceMaster, Session["UserID"].ToString());
                
                return Json(new
                {
                    Message = Result.DisplayMessage,
                    AjaxReturn = PartialView("ItemList", dLItem.GetItemNameAndPriceForCategory(Criteria).ToList()).RenderToString()
                });
            }
            else
            {
                return Json(new
                {
                    Message = "Error!! Please contact administrator",
                    AjaxReturn = PartialView("ItemList", dLItem.GetItemNameAndPriceForCategory(Criteria).ToList()).RenderToString()
                });
            }
        }
    }
}