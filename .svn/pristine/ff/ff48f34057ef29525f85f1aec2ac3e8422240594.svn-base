using CCAPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;
using WBT.DLCustomerCreation.Reports;

namespace CCAPortal.Controllers
{
    public class CustomerCitySwapController : Controller
    {
        // GET: CustomerCitySwap
        DLCustomerCitySwap DAL = new DLCustomerCitySwap();
        CustomerCreations customerCreations = new CustomerCreations();
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
        public ActionResult Search()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ViewBag.BranchID = new SelectList(customerCreations.GetBranchList(Session["OrgID"].ToString(), Session["UserID"].ToString()), "BranchID", "Name");
                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                //ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["UserID"].ToString()), "StateWithCityID", "VillageLocalityName");
                ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
                ViewBag.TallyCityList = new SelectList(customerCreations.GetTallyCities(Session["OrgID"].ToString(), string.Empty), "CityName", "CityName");
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult Search(CustomerSearch search)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                CustomerCreation searchItems = new CustomerCreation();
                List<CustomerCitySwap> CustomerList = new List<CustomerCitySwap>();
                SwapCity swapCity = new SwapCity();

                searchItems.FromDate = search.FromDate;
                searchItems.ToDate = search.ToDate;
                searchItems.StateID = search.StateID;
                searchItems.DistrictID = search.DistrictID;
                searchItems.CityID = search.CityID;
                searchItems.BillingCity = search.BillingCity;
                searchItems.BranchID = search.BranchID.ToString();
                searchItems.OrgID = Session["OrgID"].ToString();

                CustomerList = DAL.GetCustomerList(searchItems);
                swapCity.customerCitySwaps = CustomerList;
                ViewBag.CityList = new SelectList(DAL.GetCitiesOfDistrict(Session["OrgID"].ToString(), search.BranchID.ToString(), search.StateID.ToString(), search.DistrictID.ToString()).cities, "CityID", "CityName");
                return PartialView("AppUsersList", swapCity);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CustomerCitySwap(SwapCity swap)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                string Result = DAL.CustomerCitySwap(swap);
                return Json(Result);
            }
            else
            {
                return Json("sessionexpired");
            }
        }

        [HttpPost]
        public JsonResult BranchChanged(string BranchID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                if (!string.IsNullOrEmpty(BranchID))
                {

                    ACLists aCLists = new ACLists();
                    aCLists = DAL.GetCitiesOfBranch(BranchID);
                    return Json(aCLists, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("invalidData");
                }
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult StateChanged(string BranchID, string StateID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ACLists aCLists = new ACLists();
                aCLists = DAL.GetCitiesOfState(Session["OrgID"].ToString(), BranchID, StateID);
                return Json(aCLists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult DistrictChanged(string BranchID, string StateID, string DistrictID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                ACLists aCLists = new ACLists();
                aCLists = DAL.GetCitiesOfDistrict(Session["OrgID"].ToString(), BranchID, StateID, DistrictID);
                return Json(aCLists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
    }
}