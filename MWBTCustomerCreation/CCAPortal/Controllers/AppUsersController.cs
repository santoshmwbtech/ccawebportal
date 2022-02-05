using CCAPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WBT.DLCustomerCreation;
using WBT.DLCustomerCreation.Reports;
using WBT.Entity;
using System.Linq.Dynamic;
using PagedList;
using System.Web.UI;

namespace CCAPortal.Controllers
{
    public class AppUsersController : Controller
    {
        DLGetCustomerCreationReport DAL = new DLGetCustomerCreationReport();
        // GET: AppUsers
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
            if (Session["UserID"] != null && Session["OrgID"] != null && Session["RoleName"] != null)
            {
                CustomerCreations customerCreations = new CustomerCreations();
                ViewBag.BranchList = new SelectList(customerCreations.GetBranchList(Session["OrgID"].ToString(), Session["UserID"].ToString(), Session["RoleName"].ToString()), "BranchID", "Name");
                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
                ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["UserID"].ToString()), "StateWithCityID", "VillageLocalityName");
                ViewBag.LedgerTypes = new SelectList(customerCreations.GetLedgerTypes(), "LedgerTypeID", "LedgerType");
                ViewBag.CustomerTypes = new SelectList(customerCreations.GetCustomerTypes(), "CustomerTypeID", "CustomerType");
                ViewBag.CompanyTypes = new SelectList(customerCreations.GetCompanyTypes(), "CompanyTypeID", "CompanyType");
                ViewBag.CategoryTypes = new SelectList(customerCreations.GetCategoryTypes(), "CategoryTypeID", "CategoryType");
                ViewBag.TaxationTypes = new SelectList(customerCreations.GetTaxationTypes(), "TaxationTypeID", "TaxationType");
                ViewBag.ReligionList = new SelectList(customerCreations.GetTaxationTypes(), "TaxationTypeID", "TaxationType");
                ViewBag.AreaList = new SelectList(DAL.GetAreas(Session["OrgID"].ToString()), "BillingArea", "BillingArea");
                ViewBag.BillingCityList = new SelectList(customerCreations.GetTallyCities(Session["OrgID"].ToString(), string.Empty), "CityName", "CityName");
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult AppUsersList()
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                List<CustomerCreation> customerCreationList = new List<CustomerCreation>();
                CustomerPromotion customerPromotion = new CustomerPromotion();
                customerPromotion.customerList = customerCreationList;
                return PartialView(customerPromotion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]        
        public ActionResult Search(Search search)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                CustomerCreation searchItems = new CustomerCreation();
                CustomerCreations customerCreations = new CustomerCreations();
                List<CustomerCreation> CustomerList = new List<CustomerCreation>();

                searchItems.OrgID = Session["OrgID"].ToString();
                searchItems.FromDate = search.FromDate;
                searchItems.ToDate = search.ToDate;
                searchItems.StateList = search.StateList;
                searchItems.DistrictList = search.DistrictList;
                searchItems.CityList = search.CityList;
                searchItems.LedgerTypeID = search.LedgerTypeID;
                searchItems.CustomerTypeList = search.CustomerTypeList;
                searchItems.CompanyTypeList = search.CompanyTypeList;
                searchItems.CategoryTypeList = search.CategoryTypeList;
                searchItems.TaxationTypeList = search.TaxationTypeList;
                if (Session["UserID"].ToString() != "1")
                    searchItems.SalesManID = Convert.ToInt32(Session["UserID"].ToString());
                else
                    searchItems.SalesManID = 0;
                searchItems.BranchList = search.BranchList;
                searchItems.Religion = search.Religion;
                searchItems.FirmName = search.CustomerName;
                searchItems.Created = search.Created;
                searchItems.Updated = search.Updated;
                searchItems.UpdatePending = search.UpdatePending;
                searchItems.BillingCityList = search.BillingCityList;
                searchItems.AreaList = search.AreaList;

                CustomerList = customerCreations.GetCustomerList(searchItems);
                CustomerPromotion customerPromotion = new CustomerPromotion();
                customerPromotion.customerList = CustomerList;
                customerPromotion.RoleID = Session["UserID"].ToString();
                return PartialView("AppUsersList", customerPromotion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public JsonResult Promotion(CustomerPromotion promotion, HttpPostedFileBase postedFile, List<CustomerCreation> customers)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                DLPromotion DALPromotion = new DLPromotion();
                List<Attachment> MailAttachments = new List<Attachment>();

                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    try
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        var attachment = new Attachment(postedFile.InputStream, fileName);
                        MailAttachments.Add(attachment);
                    }
                    catch (Exception) { }
                }
                string Result = DALPromotion.Promotion(promotion, MailAttachments);
                return Json(Result);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        public JsonResult StateChanged(string StateList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                List<tblState> states = new List<tblState>();
                string[] splitstr = null;
                if (StateList.Contains(','))
                {
                    splitstr = StateList.Split(',');
                    for (int i = 0; i < splitstr.Length; i++)
                    {
                        int StateID = Convert.ToInt32(splitstr[i]);
                        states.Add(new tblState()
                        {
                            StateID = StateID
                        });
                    }
                }
                else
                {
                    int StateID = Convert.ToInt32(StateList);
                    states.Add(new tblState()
                    {
                        StateID = StateID
                    });
                }
                CustomerCreations dL = new CustomerCreations();
                List<tblStateWithCity> citylist = new List<tblStateWithCity>();
                foreach (var item in states)
                {
                    List<tblStateWithCity> cities = dL.GetCities(item.StateID).ToList();
                    citylist.AddRange(cities);
                }
                ViewBag.NewCities = new SelectList(citylist, "StateWithCityID", "VillageLocalityName");
                return Json(ViewBag.NewCities.ToString());
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        [OutputCache(Duration = 3600, VaryByParam = "BranchList", Location = OutputCacheLocation.Client)]
        public JsonResult BranchChanged(string BranchList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                if (BranchList != null)
                {
                    List<tblSysBranch> branches = new List<tblSysBranch>();
                    string[] splitstr = null;
                    if (!string.IsNullOrEmpty(BranchList))
                    {
                        if (BranchList.Contains(','))
                        {
                            splitstr = BranchList.Split(',');
                            for (int i = 0; i < splitstr.Length; i++)
                            {
                                int BranchID = Convert.ToInt32(splitstr[i]);
                                branches.Add(new tblSysBranch()
                                {
                                    BranchID = BranchID.ToString()
                                });
                            }
                        }
                        else
                        {
                            int BranchID = Convert.ToInt32(BranchList);
                            branches.Add(new tblSysBranch()
                            {
                                BranchID = BranchID.ToString()
                            });
                        }
                    }
                    CustomerCreations dL = new CustomerCreations();
                    ACLists aCLists = new ACLists();
                    aCLists = dL.GetCitiesOfBranch(branches, Session["OrgID"].ToString());
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
        [OutputCache(Duration = 3600, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public JsonResult StateChanged(string BranchList, string StateList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                CustomerCreations dL = new CustomerCreations();
                ACLists aCLists = new ACLists();
                aCLists = dL.GetCitiesOfState(BranchList, StateList, Session["OrgID"].ToString());
                return Json(aCLists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult DistrictChanged(string BranchList, string StateList, string DistrictList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                CustomerCreations dL = new CustomerCreations();
                ACLists aCLists = new ACLists();
                aCLists = dL.GetCitiesOfDistrict(BranchList, StateList, DistrictList, Session["OrgID"].ToString());
                return Json(aCLists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        [OutputCache(Duration = 3600, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public JsonResult CityChanged(string BranchList, string StateList, string DistrictList, string CityList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                CustomerCreations dL = new CustomerCreations();
                ACLists aCLists = new ACLists();
                aCLists = dL.GetAreasofCity(BranchList, StateList, DistrictList, CityList, Session["OrgID"].ToString());
                return Json(aCLists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }

        [HttpPost]
        [OutputCache(Duration = 60, VaryByParam = "search", Location = OutputCacheLocation.Client)]
        public ActionResult GetList(Search search, string searchtext, int page = 1, int pageSize = 5)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                int totalpages = 0;
                int totalRecords = 0;
                CustomerCreation searchItems = new CustomerCreation();
                CustomerCreations customerCreations = new CustomerCreations();
                List<CustomerCreation> CustomerList = new List<CustomerCreation>();

                searchItems.OrgID = Session["OrgID"].ToString();
                searchItems.FromDate = search.FromDate;
                searchItems.ToDate = search.ToDate;
                searchItems.StateList = search.StateList;
                searchItems.DistrictList = search.DistrictList;
                searchItems.CityList = search.CityList;
                searchItems.LedgerTypeID = search.LedgerTypeID;
                searchItems.CustomerTypeList = search.CustomerTypeList;
                searchItems.CompanyTypeList = search.CompanyTypeList;
                searchItems.CategoryTypeList = search.CategoryTypeList;
                searchItems.TaxationTypeList = search.TaxationTypeList;
                if (Session["RoleName"].ToString().ToLower() != "admin")
                    searchItems.SalesManID = Convert.ToInt32(Session["UserID"].ToString());
                else
                    searchItems.SalesManID = 0;
                searchItems.BranchList = search.BranchList;
                searchItems.Religion = search.Religion;
                searchItems.FirmName = search.CustomerName;
                searchItems.Created = search.Created;
                searchItems.Updated = search.Updated;
                searchItems.UpdatePending = search.UpdatePending;
                searchItems.BillingCityList = search.BillingCityList;
                searchItems.AreaList = search.AreaList;

                CustomerList = customerCreations.GetCustomerList(searchItems);
                totalRecords = CustomerList.Count();
                totalpages = (totalRecords / pageSize) + ((totalRecords % pageSize) > 0 ? 1 : 0);
                IPagedList<CustomerCreation> allList = CustomerList.ToPagedList(page, pageSize);

                ViewBag.TotalRows = totalRecords;
                ViewBag.totalpages = totalpages;
                ViewBag.PageSize = pageSize;

                CustomerPromotion customerPromotion = new CustomerPromotion();
                customerPromotion.customerList = CustomerList;
                customerPromotion.RoleID = Session["UserID"].ToString();
                return PartialView("CustomerList", customerPromotion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}