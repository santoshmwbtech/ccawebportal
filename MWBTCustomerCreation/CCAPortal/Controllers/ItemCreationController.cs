using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class ItemCreationController : Controller
    {
        // GET: ItemCreation
        DLItem dlItem = new DLItem();
        public ActionResult Index()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }            
        }

        public ActionResult Create()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }            
            else
            {
                DLItemCreation dlitemcreation = new DLItemCreation();
                     
                dlitemcreation.ItemCode = Convert.ToString(WBT.Common.Helper.GetUniqueNumber);
                ViewBag.GroupList = new SelectList(dlItem.GetGroupList(Session["OrgID"].ToString()), "CategoryID", "CategoryName");
                //ViewBag.SubCategoryList = new SelectList(dlItem.GetSubCategoryList(), "SubCategoryID", "SubCategoryName");
                ViewBag.BrandList = new SelectList(dlItem.GetBrandList(Session["OrgID"].ToString()), "BrandID", "BrandName");
                ViewBag.uomList = new SelectList(dlItem.GetUOMList(), "UnitID", "Unit");
                ViewBag.CompanyList = new SelectList(dlItem.GetCompanyList(Session["OrgID"].ToString()), "ItemCompanyID", "CompanyName");
                return PartialView(dlitemcreation);
            }
        }

        public JsonResult FillSubCategory(int CategoryID)
        {
            var subcatgs = dlItem.GetSubCategoryList(CategoryID); // db.Cities.Where(c => c.StateId == state);
            return Json(subcatgs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillItemNameText(string BagUnit, string PacketUnit, decimal BagSize, decimal PacketSize)
        {
            string ConcatedUOMPBulkunit = dlItem.ConstructingUOMPacketNumber(PacketSize, PacketUnit, BagSize, BagUnit);
            string txtAppendValue = string.Empty;
            if (ConcatedUOMPBulkunit != null)
            {
                txtAppendValue = ConcatedUOMPBulkunit;
            }
            else
            {
                txtAppendValue = "0";
                //Response.Write("<script>alert('Please select Proper Unit');</script>");
            }
                return Json(txtAppendValue, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(DLItemCreation dlitemcreation)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {

                dlitemcreation.OrgID = Session["OrgID"].ToString();
                dlitemcreation.CreatedByID = Convert.ToInt32(Session["UserID"].ToString());
                DLItemCreation Result = dlItem.SaveItem(dlitemcreation);
                return Json(Result.DisplayMessage);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult ItemList()
        {
            List<DLItemCreation> result = new List<DLItemCreation>();
            try
            {
                result = dlItem.GetItems("", Session["OrgID"].ToString());
            }
            catch (Exception ex)
            {

            }
            return PartialView(result);
        }

        public ActionResult Edit(int ItemCode)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ItemCode == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DLItemCreation dlItemsDetails = dlItem.GetItemsDetail(ItemCode.ToString(), Session["OrgID"].ToString());

            if (dlItemsDetails == null)
            {
                return HttpNotFound();
            }

            ViewBag.SubCategoryList = new SelectList(dlItem.GetSubCategoryList(dlItemsDetails.CategoryID), "SubCategoryID", "SubCategoryName");

            ViewBag.GroupList = new SelectList(dlItem.GetGroupList(Session["OrgID"].ToString()), "CategoryID", "CategoryName");
            ViewBag.BrandList = new SelectList(dlItem.GetBrandList(Session["OrgID"].ToString()), "BrandID", "BrandName");
            ViewBag.uomList = new SelectList(dlItem.GetUOMList(), "UnitID", "Unit");
            ViewBag.CompanyList = new SelectList(dlItem.GetCompanyList(Session["OrgID"].ToString()), "ItemCompanyID", "CompanyName");
            return PartialView("Edit", dlItemsDetails);
        }

        [HttpPost]
        public ActionResult UpdateItem(DLItemCreation dlitemcreation)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                DLItemCreation Result = dlItem.UpdateItem(dlitemcreation, Convert.ToInt32(Session["UserID"].ToString()), Session["OrgID"].ToString());
                return Json(new
                {
                    Message = Result.DisplayMessage,
                    AjaxReturn = PartialView("ItemList", dlItem.GetItems("", Session["OrgID"].ToString()).ToList()).RenderToString()
                });
                //if (ID > 0)
                //{
                //    //ModelState.Clear();
                //    return Json(new
                //    {
                //        ID = ID,
                //        Message = "success",
                //        AjaxReturn = PartialView("ItemList", dlItem.GetItems("", Session["OrgID"].ToString()).ToList()).RenderToString()
                //    });                    
                //}
                //else
                //{
                //    return Json(new
                //    {
                //        ID = 0,
                //        Message = "error",
                //        AjaxReturn = PartialView("ItemList", dlItem.GetItems("", Session["OrgID"].ToString()).ToList()).RenderToString()
                //    });
                //}
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}