using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;
using WBT.DLCustomerCreation.Reports;

namespace CCAPortal.Controllers
{
    public class SalesOrderController : Controller
    {
        CustomerCreations customerCreations = new CustomerCreations();
        DLRouteMapping DLSalesman = new DLRouteMapping();
        public DLSalesOrders so = new DLSalesOrders();
        DLGetCustomerCreationReport DAL = new DLGetCustomerCreationReport();
        // GET: SalesOrder
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

                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
                ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["UserID"].ToString()), "StateWithCityID", "VillageLocalityName");
                ViewBag.LedgerTypes = new SelectList(customerCreations.GetLedgerTypes(), "LedgerTypeID", "LedgerType");
                ViewBag.CustomerTypes = new SelectList(customerCreations.GetCustomerTypes(Session["OrgID"].ToString()), "BusinessTypeID", "BusinessTypeName");
                ViewBag.CompanyTypes = new SelectList(customerCreations.GetCompanyTypes(), "CompanyTypeID", "CompanyType");
                //ViewBag.CategoryTypes = new SelectList(customerCreations.GetCategoryTypes(), "CategoryTypeID", "CategoryType");

                ViewBag.AreaList = new SelectList(DAL.GetAreas(Session["OrgID"].ToString()), "BillingArea", "BillingArea");

                ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["OrgID"].ToString(), Session["UserID"].ToString(), Session["RoleName"].ToString()), "BranchID", "Name");
                string name = "salesman";
                ViewBag.SalesmanList = new SelectList(DLSalesman.GetSalesManList(name, Session["OrgID"].ToString()), "UserID", "Username");
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult SearchSO(SalesOrders dlSalesOrders)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {

                ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["OrgID"].ToString(), Session["UserID"].ToString(), Session["RoleName"].ToString()), "BranchID", "Name");
                string name = "salesman";
                ViewBag.SalesmanList = new SelectList(DLSalesman.GetSalesManList(name, Session["OrgID"].ToString()), "UserID", "Username");

                SalesOrders searchItems = new SalesOrders();
                List<SalesOrders> SOlist = new List<SalesOrders>();

                searchItems.OrgID = Session["OrgID"].ToString();    //// search.OrgID; OrgID purpose
                searchItems.FromDate = dlSalesOrders.FromDate;
                searchItems.ToDate = dlSalesOrders.ToDate;
                searchItems.BranchID = dlSalesOrders.BranchID;
                searchItems.CustID = dlSalesOrders.CustID;
                searchItems.FirmName = dlSalesOrders.FirmName;
                searchItems.SalesOrderNumber = dlSalesOrders.SalesOrderNumber;
                searchItems.OrderDate = dlSalesOrders.OrderDate;
                searchItems.salesmanList = dlSalesOrders.salesmanList;
                searchItems.BranchList = dlSalesOrders.BranchList;

                searchItems.StateList = dlSalesOrders.StateList;
                searchItems.CityList = dlSalesOrders.CityList;
                searchItems.DistrictList = dlSalesOrders.DistrictList;
                searchItems.AreaList = dlSalesOrders.AreaList;
                searchItems.LedgerTypeID = dlSalesOrders.LedgerTypeID;
                searchItems.CustomerTypeList = dlSalesOrders.CustomerTypeList;
                searchItems.CompanyTypeList = dlSalesOrders.CompanyTypeList;

                searchItems.CustomerName = dlSalesOrders.CustomerName;

                SOlist = so.GetSOList(searchItems);

                return PartialView("SalesOrdersList", SOlist);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult SalesOrdersList()
        {
            List<SalesOrders> result = new List<SalesOrders>();
            if(Session["OrgID"] != null && Session["UserID"] != null)
            {
                result = so.GetData(Session["OrgID"].ToString());
            }
            return PartialView(result);
        }
    }
}