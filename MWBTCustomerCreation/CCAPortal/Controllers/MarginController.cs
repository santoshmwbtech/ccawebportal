using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class MarginController : Controller
    {
        CustomerCreations customerCreations = new CustomerCreations();
        Margins margin = new Margins();
        DLMargins dlMargins = new DLMargins();

        // GET: Margin
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
                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
                ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["UserID"].ToString()), "StateWithCityID", "VillageLocalityName");
                ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["UserID"].ToString()), "BranchID", "Name");

                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult BusinessList()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            List<Margins> result = new List<Margins>();
            try
            {
                result = dlMargins.GetBusinessTypeData(Session["OrgID"].ToString());
            }
            catch (Exception ex)
            {
            }
            return PartialView(result);
        }

        [HttpPost]
        public ActionResult BusinessPopup(int BusinessTypeID)
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            //List<Margins> result = new List<Margins>();
            //try
            //{
            //   // result = dlMargins.GetBusinessTypeData(Session["OrgID"].ToString());
            //}
            //catch (Exception ex)
            //{
            //}
            ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
            ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
            ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["UserID"].ToString()), "StateWithCityID", "VillageLocalityName");
            ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["UserID"].ToString()), "BranchID", "Name");
            return PartialView();
        }

        public ActionResult CreditList()
        {
            if (Session["UserID"] == null || Session["OrgID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            List<Margins> result = new List<Margins>();
            try
            {
                result = dlMargins.GetCreditTypeData(Session["OrgID"].ToString());
            }
            catch (Exception ex)
            {
            }
            return PartialView(result);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Save(Brands brands)
        //{
        //    if (Session["UserID"] == null || Session["OrgID"] == null)
        //    {
        //        return this.RedirectToAction("Index", "Login");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        Brands Result = dLBrands.SaveData(brands, Session["OrgID"].ToString(), Session["UserID"].ToString());
        //        return Json(Result.DisplayMessage);
        //    }
        //    else
        //    {
        //        IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
        //        return Json(new { allErrors });
        //    }
        //}

        //public ActionResult BrandList()
        //{
        //    if (Session["UserID"] == null || Session["OrgID"] == null)
        //    {
        //        return this.RedirectToAction("Index", "Login");
        //    }

        //    List<Brands> result = new List<Brands>();
        //    try
        //    {
        //        result = dLBrands.GetData(Session["OrgID"].ToString());
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return PartialView(result);
        //}

        //public ActionResult Edit(int BrandID)
        //{
        //    if (Session["UserID"] == null || Session["OrgID"] == null)
        //    {
        //        return Json(new { url = Url.Action("Index", "Login") });
        //    }
        //    if (BrandID == 0)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ViewBag.ItemCompanies = new SelectList(dLBrands.GetItemCompanies(Session["OrgID"].ToString()), "ItemCompanyID", "CompanyName");
        //    Brands brands = dLBrands.GetIBrandDetail(BrandID);

        //    if (brands == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView("Edit", brands);
        //}

        //public ActionResult Delete(int BrandID)
        //{
        //    if (Session["UserID"] == null || Session["OrgID"] == null)
        //    {
        //        return Json(new { url = Url.Action("Index", "Login") });
        //    }
        //    if (BrandID == 0)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Brands Result = dLBrands.DeleteBrand(BrandID, Session["OrgID"].ToString(), Session["UserID"].ToString());
        //    return Json(Result.DisplayMessage, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update(Brands brands)
        //{
        //    if (Session["UserID"] == null || Session["OrgID"] == null)
        //    {
        //        return Json(new { url = Url.Action("Index", "Login") });
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        Brands Result = dLBrands.SaveData(brands, Session["OrgID"].ToString(), Session["UserID"].ToString());
        //        return Json(new
        //        {
        //            Message = Result.DisplayMessage,
        //            AjaxReturn = PartialView("BrandList", dLBrands.GetData(Session["OrgID"].ToString()).ToList()).RenderToString()
        //        });
        //    }
        //    else
        //    {
        //        IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
        //        return Json(new
        //        {
        //            Message = allErrors,
        //            AjaxReturn = PartialView("BrandList", dLBrands.GetData(Session["OrgID"].ToString()).ToList()).RenderToString()
        //        });
        //    }
        //}
    }
}