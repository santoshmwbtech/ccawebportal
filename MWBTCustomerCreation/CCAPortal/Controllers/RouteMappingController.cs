using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class RouteMappingController : Controller
    {
        DLRouteMapping dLRouteMappingData = new DLRouteMapping();

        List<CustomerVendorDetails> customerVenderDetailsList = new List<CustomerVendorDetails>();
        List<CustomerVendorDetails> AddcustomerVenderDetailsList = new List<CustomerVendorDetails>();

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult CreateRouteMapping()
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            string name = "salesman";
            ViewBag.SalesmanList = new SelectList(dLRouteMappingData.GetSalesManList(name), "UserID", "Username");
            ViewBag.RouteList = new SelectList(dLRouteMappingData.GetRouteList(), "ID", "DebtorName");
            return PartialView();
        }
        public ActionResult CustomerVenderList()
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            return PartialView("CustomerVenderList", customerVenderDetailsList);
        }

        [HttpPost]
        public ActionResult GetCustomerVendorList(string hfSelectedValue)
        {
            string[] splitstr = null;
            if (hfSelectedValue.Contains(','))
            {
                splitstr = hfSelectedValue.Split(',');
                foreach (var str in splitstr)
                {
                    int intValue = Convert.ToInt32(str);
                    customerVenderDetailsList = dLRouteMappingData.GetCustomerVenderList(intValue);
                    AddcustomerVenderDetailsList.AddRange(customerVenderDetailsList);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(hfSelectedValue))
                {
                    int intValue = Convert.ToInt32(hfSelectedValue);
                    customerVenderDetailsList = dLRouteMappingData.GetCustomerVenderList(intValue);
                    AddcustomerVenderDetailsList.AddRange(customerVenderDetailsList);
                }
            }
            return PartialView("CustomerVenderList", AddcustomerVenderDetailsList);
        }
        public ActionResult SaveRouteMapping()
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }

            return PartialView("CustomerVenderList", customerVenderDetailsList);
        }
        public ActionResult UpdateRouteMapping()
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult RouteMappingList()
        {
            if (Session["UserID"] == null)
            {
                return this.RedirectToAction("Index", "Login");
            }
            return PartialView();
        }
    }
}