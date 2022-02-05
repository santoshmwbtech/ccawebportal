using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;

namespace CCAPortal.Controllers
{
    public class IncompleteRptController : Controller
    {
        DLIncompleteReport DAL = new DLIncompleteReport();
        // GET: IncompleteRpt
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
                CustomerCreations customerCreations = new CustomerCreations();
                ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["OrgID"].ToString(), Session["UserID"].ToString(), Session["RoleName"].ToString()), "BranchID", "Name");

                IEnumerable<SelectListItem> searchItems = from SearchOptions s in Enum.GetValues(typeof(SearchOptions))
                                                          select new SelectListItem
                                                          {
                                                              Text = s.ToString(),
                                                              Value = s.ToString()
                                                          };
                ViewBag.SearchOptions = new SelectList(searchItems, "Value", "Text");
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult Search(IncompleteCustomers search)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                IncompleteCustomers searchItems = new IncompleteCustomers();
                List<IncompleteCustomers> CustomerList = new List<IncompleteCustomers>();

                searchItems.OrgID = Session["OrgID"].ToString();
                searchItems.FromDate = search.FromDate;
                searchItems.ToDate = search.ToDate;
                searchItems.BranchList = search.BranchList;
                searchItems.IncompleteType = search.IncompleteType;

                CustomerList = DAL.GetIncompleteReport(searchItems, Session["UserID"].ToString());
                IncompletePromotion customerPromotion = new IncompletePromotion();
                customerPromotion.customerList = CustomerList;
                if (CustomerList != null && CustomerList.Count() > 0)
                    customerPromotion.RoleName = CustomerList.FirstOrDefault().RoleName;
                return PartialView("AppUsersList", customerPromotion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}