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

namespace CCAPortal.Controllers
{
    public class PerformanceReportController : Controller
    {
        DLGetCustomerCreationReport DAL = new DLGetCustomerCreationReport();
        DLRouteMapping DLSalesman = new DLRouteMapping();
        DLTemplates dLTemplates = new DLTemplates();
        // GET: PerformanceReport
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
                ViewBag.StateList = new SelectList(customerCreations.GetStateList(), "StateID", "StateName");
                ViewBag.DistrictList = new SelectList(customerCreations.GetDistricts(), "DistrictID", "DistrictName");
                ViewBag.CityList = new SelectList(customerCreations.GetAllCities(Session["OrgID"].ToString()), "StateWithCityID", "VillageLocalityName");
                ViewBag.LedgerTypeID = new SelectList(customerCreations.GetLedgerTypes(), "LedgerTypeID", "LedgerType");
                ViewBag.CustomerTypes = new SelectList(customerCreations.GetCustomerTypes(Session["OrgID"].ToString()), "BusinessTypeID", "BusinessTypeName");
                ViewBag.CompanyTypes = new SelectList(customerCreations.GetCompanyTypes(), "CompanyTypeID", "CompanyType");
                ViewBag.CategoryTypes = new SelectList(customerCreations.GetCategoryTypes(), "CategoryTypeID", "CategoryType");
                ViewBag.TaxationTypes = new SelectList(customerCreations.GetTaxationTypes(), "TaxationTypeID", "TaxationType");
                ViewBag.AreaList = new SelectList(DAL.GetAreas(Session["OrgID"].ToString()), "BillingArea", "BillingArea");
                ViewBag.BillingCityList = new SelectList(customerCreations.GetTallyCities(Session["OrgID"].ToString(), string.Empty), "CityName", "CityName");

                string name = "salesman";
                ViewBag.SalesmanList = new SelectList(DLSalesman.GetSalesManList(name, Session["OrgID"].ToString()), "UserID", "Username");

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
                MainCList mainCList = new MainCList();
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
                searchItems.SalesmanList = search.SalesmanList;
                searchItems.Created = search.Created;
                searchItems.Updated = search.Updated;
                searchItems.AreaList = search.AreaList;
                searchItems.BranchList = search.BranchList;
                searchItems.Religion = search.Religion;
                searchItems.FirmName = search.CustomerName;
                searchItems.UpdatePending = search.UpdatePending;
                searchItems.BillingCityList = search.BillingCityList;

                mainCList = DAL.GetCustomerList(searchItems);

                var Entities = new MWBTCustomerAppEntities();

                ViewBag.UpdatedRecords = mainCList.UpdatedRecords;
                ViewBag.TotalRecords = mainCList.TotalRecords;
                ViewBag.PendingRecords = mainCList.PendingRecords;

                ViewBag.SMSTemplates = new SelectList(dLTemplates.GetSMSTemplates(Session["OrgID"].ToString()), "ID", "TemplateName");
                ViewBag.EmailTemplates = new SelectList(dLTemplates.GetEmailTemplates(Session["OrgID"].ToString()), "ID", "TemplateName");
                ViewBag.WhatsappTemplates = new SelectList(dLTemplates.GetWhatsappTemplates(Session["OrgID"].ToString()), "ID", "TemplateName");

                CustomerPromotion customerPromotion = new CustomerPromotion();
                customerPromotion.customerList = mainCList.customerList;
                return PartialView("AppUsersList", customerPromotion);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public JsonResult BranchChanged(string BranchList)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                if (BranchList != null)
                {
                    List<tblSysBranch> branches = new List<tblSysBranch>();
                    string[] splitstr = null;
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
        public JsonResult GetSMSTemplate(int? TemplateID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                var SMSTemplate = dLTemplates.GetSMSTemplateDetails(TemplateID.Value);
                return Json(SMSTemplate, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }
        [HttpPost]
        public JsonResult GetEmailTemplate(int? TemplateID)
        {
            if (Session["UserID"] != null && Session["OrgID"] != null)
            {
                var EmailTemplate = dLTemplates.GetEmailTemplateDetails(TemplateID.Value);
                return Json(EmailTemplate, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("sessionexpired");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Promotion(CustomerPromotion customerPromotion, HttpPostedFileBase postedFile)
        {
            if (Session["UserID"] != null)
            {
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

                string Result = DAL.Promotion(customerPromotion, Convert.ToInt32(Session["UserID"].ToString()), MailAttachments);

                // Generate a new unique identifier against which the file can be stored
                string handle = Guid.NewGuid().ToString();
                var stream = new MemoryStream();
                var writer = new StreamWriter(stream);
                writer.Write(Result);
                writer.Flush();
                stream.Position = 0;
                TempData[handle] = stream.ToArray();
                return new JsonResult()
                {
                    Data = new { FileGuid = handle, FileName = "PromoResult.txt" }
                };
            }
            else
            {
                return Json("sessionexpired");
            }

        }
        [HttpGet]
        public virtual ActionResult DownloadResponseData(string fileGuid, string fileName)
        {
            byte[] data = TempData[fileGuid] as byte[];
            return File(data, "application/txt", fileName);
        }
    }
}