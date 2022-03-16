using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Entity;
using WBT.Common;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Configuration;

namespace WBT.DLCustomerCreation.Reports
{
    public class DLCustomerCreationReport
    {
        public string LedgerType { get; set; }
        public string CustID { get; set; }
        public string FirmName { get; set; }
        public string AliasName { get; set; }
        public string CompanyType { get; set; }
        public string CustomerType { get; set; }
        public string TypeofCategory { get; set; }
        public string Religion { get; set; }
        public string WeekOffDay { get; set; }
        public string MobileNumber { get; set; }
        public string ContactpersonName { get; set; }
        public string ContactpersonPhone { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailID { get; set; }
        public string Address3 { get; set; }
        public string BillingArea { get; set; }
        public string BillingLandmark { get; set; }
        public string BillingState { get; set; }
        public string BillingCity { get; set; }
        public string BillingPincode { get; set; }
        public string GSTNumber { get; set; }
        public string PANNumber { get; set; }
        public string AadhaarNumber { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string BillingGPSLocation { get; set; }
        public string BillingLatitude { get; set; }
        public string BillingLongitude { get; set; }
        public string OwnerPhoto { get; set; }
        public string AadhaarPhoto { get; set; }
        public string GSTPhoto { get; set; }
        public string PANPhoto { get; set; }
        public string ShopImage { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string RegistrationType { get; set; }
        public string OwnerName { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public string FromDate { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public string ToDate { get; set; }
        public int StateID { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int CityID { get; set; }
        public int SalesmanID { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
    public class AreaList
    {
        public string BranchID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public string BillingArea { get; set; }
        public string ShippingArea { get; set; }
    }
    public class City
    {
        public string BranchID { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
    public class State
    {
        public string BranchID { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
    }
    public class District
    {
        public string BranchID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
    }
    public class ACLists
    {
        public List<State> states { get; set; }
        public List<AreaList> areaLists { get; set; }
        public List<City> cities { get; set; }
        public List<District> districts { get; set; }
        public object billingcities { get; set; }
    }
    public class MainCList
    {
        public List<CustomerCreation> customerList { get; set; }
        public int UpdatedRecords { get; set; }
        public int TotalRecords { get; set; }
        public int PendingRecords { get; set; }
    }
    public class DLGetCustomerCreationReport
    {
        public List<DLCustomerCreationReport> GetCustomerlist(DLCustomerCreationReport dLCustomerCreationReport)
        {
            List<DLCustomerCreationReport> lstcustomer = new List<DLCustomerCreationReport>();
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {

                    lstcustomer = (from cust in dbContext.tblCustomerVendorDetails
                                   where dLCustomerCreationReport.SalesmanID == 0 ? 1 == 1 : cust.SalesManID == dLCustomerCreationReport.SalesmanID
                                   select new DLCustomerCreationReport
                                   {
                                       CustID = cust.CustID,
                                       LedgerType = cust.LedgerType,
                                       FirmName = cust.FirmName,
                                       AliasName = cust.AliasName,
                                       CompanyType = cust.CompanyType,
                                       CustomerType = cust.CustomerType.ToString(),
                                       TypeofCategory = cust.TypeofCategory,
                                       Religion = cust.Religion,
                                       WeekOffDay = cust.WeekOffDay,
                                       MobileNumber = cust.MobileNumber,
                                       ContactpersonName = cust.ContactpersonName,
                                       ContactpersonPhone = cust.ContactpersonPhone,
                                       TelephoneNumber = cust.TelephoneNumber,
                                       EmailID = cust.EmailID,
                                       Address3 = cust.Address3,
                                       BillingArea = cust.BillingArea,
                                       BillingLandmark = cust.BillingLandmark,
                                       BillingState = cust.BillingState,
                                       BillingPincode = cust.BillingPincode,
                                       GSTNumber = cust.TINNumber,
                                       AadhaarNumber = cust.AadhaarNumber,
                                       PANNumber = cust.PANNumber,
                                       AccountNumber = cust.AccountNumber,
                                       BankName = cust.BankName,
                                       IFSCCode = cust.IFSCCode,
                                       BillingGPSLocation = cust.BillingGPSLocation,
                                       BillingLatitude = cust.BillingLatitude,
                                       BillingLongitude = cust.BillingLongitude,
                                       OwnerPhoto = cust.OwnerPhoto,
                                       AadhaarPhoto = cust.AadhaarPhoto,
                                       RegistrationType = cust.RegistrationType,
                                       OwnerName = cust.OwnerName,
                                       GSTPhoto = cust.GSTPhoto,
                                       ShopImage = cust.ShopImage,
                                       PANPhoto = cust.PANPhoto,
                                       CreationDate = cust.CreationDate,
                                       UpdatedDate = cust.UpdatedDate,
                                       CreatedBy = (dbContext.tblSysUsers.Where(u => u.UserID == cust.CreatedByID).FirstOrDefault().Username),
                                       UpdatedBy = (dbContext.tblSysUsers.Where(u => u.UserID == cust.SalesManID).FirstOrDefault().Username),
                                   }).ToList();
                    DateTime date1 = Convert.ToDateTime("01 / 01 / 0001");
                    if (!string.IsNullOrEmpty(dLCustomerCreationReport.FromDate))
                    {
                        lstcustomer = lstcustomer.Where(i => Convert.ToDateTime(i.CreationDate) >= Convert.ToDateTime(dLCustomerCreationReport.FromDate) && Convert.ToDateTime(i.CreationDate) <= Convert.ToDateTime(dLCustomerCreationReport.ToDate)).ToList();
                    }

                    //if (!string.IsNullOrEmpty(dLCustomerCreationReport.FirmName))
                    //{
                    //    lstcustomer = lstcustomer.Where(i => i.FirmName.Contains(dLCustomerCreationReport.FirmName)).ToList();
                    //}
                    //if (!string.IsNullOrEmpty(dLCustomerCreationReport.Religion))
                    //{
                    //    lstcustomer = lstcustomer.Where(i => i.Religion.Contains(dLCustomerCreationReport.Religion)).ToList();
                    //}

                    //if (dLCustomerCreationReport.StateID > 0)
                    //{

                    //}
                    //if (dLCustomerCreationReport.CityID > 0)
                    //{

                    //}

                    //if (dLCustomerCreationReport.TypeofCategory != null)
                    //{

                    //}                    
                    //if (!string.IsNullOrEmpty(dLCustomerCreationReport.WeekOffDay))
                    //{

                    //    foreach(var item in lstcustomer)
                    //    {
                    //        if(item.WeekOffDay!=null)
                    //        {
                    //            lstcustomer = lstcustomer.Where(i => i.WeekOffDay==dLCustomerCreationReport.WeekOffDay).ToList();
                    //        }                            
                    //    }                       
                    //}
                    //if (dLCustomerCreationReport.BillingArea != null)
                    //{

                    //}                    
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
            }
            return lstcustomer;
        }
        //GetStates
        public List<tblState> GetStateList()
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = dbContext.Database.BeginTransaction())
                    {
                        List<tblState> stateList = new List<tblState>();
                        stateList = (from s in dbContext.tblStates
                                     select s).ToList();

                        return stateList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetCities
        public List<tblStateWithCity> GetCities(int StateID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = dbContext.Database.BeginTransaction())
                    {
                        List<tblStateWithCity> cityList = new List<tblStateWithCity>();
                        cityList = (from s in dbContext.tblStateWithCities
                                    where s.StateID == StateID
                                    select s).ToList();

                        return cityList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //Get Areas
        public List<CustomerCreation> GetAreas(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = dbContext.Database.BeginTransaction())
                    {
                        List<CustomerCreation> areaList = new List<CustomerCreation>();
                        areaList = (from s in dbContext.tblCustomerVendorDetails
                                    where s.BillingArea != "" && s.BillingArea != null
                                    && s.OrgID == OrgID
                                    select new CustomerCreation
                                    {
                                        BillingArea = s.BillingArea,
                                        ShippingArea = s.ShippingArea
                                    }).Distinct().ToList();

                        return areaList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public ACLists GetAreaCityList(List<tblSysBranch> branches)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    ACLists AreaCityList = new ACLists();
                    using (var dbcxtransaction = dbContext.Database.BeginTransaction())
                    {
                        List<CustomerCreation> areas = new List<CustomerCreation>();
                        areas = (from s in dbContext.tblCustomerVendorDetails
                                 where s.BillingArea != "" && s.BillingArea != null
                                 select new CustomerCreation
                                 {
                                     OrgID = s.OrgID,
                                     BillingArea = s.BillingArea,
                                     ShippingArea = s.ShippingArea
                                 }).Distinct().ToList();

                        List<tblStateWithCity> cityList = new List<tblStateWithCity>();
                        cityList = (from s in dbContext.tblStateWithCities
                                    select s).ToList();
                        var CustomerList = dbContext.tblCustomerVendorDetails.ToList();
                        var Cities = (from c in CustomerList
                                      join ct in cityList on c.CityID equals ct.StatewithCityID
                                      join b in branches on c.OrgID equals b.BranchID
                                      select new City
                                      {
                                          CityID = ct.StatewithCityID,
                                          CityName = ct.VillageLocalityname
                                      }).Distinct().ToList();

                        List<AreaList> areaList = (from s in areas
                                                   join b in branches on s.OrgID equals b.BranchID
                                                   select new AreaList
                                                   {
                                                       BillingArea = s.BillingArea,
                                                       ShippingArea = s.ShippingArea
                                                   }).Distinct().ToList();

                        AreaCityList.areaLists = areaList;
                        AreaCityList.cities = Cities;
                        return AreaCityList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public string Promotion(CustomerPromotion promo, int UserID, List<Attachment> MailAttachments)
        {
            try
            {
                string Result = string.Empty;
                if (promo.IsEmail == true)
                {
                    string Bcc = string.Empty;
                    IEnumerable<string> bccList = promo.customerList.Select(c => c.EmailID);

                    string ToEmailID = ConfigurationManager.AppSettings["FromMailID"].ToString();
                    string FromMailID = ConfigurationManager.AppSettings["FromMailID"].ToString();
                    string MailPassword = ConfigurationManager.AppSettings["MailPassword"].ToString();
                    string MailServerHost = ConfigurationManager.AppSettings["MailServerHost"].ToString();
                    string SendingPort = ConfigurationManager.AppSettings["SendingPort"].ToString();
                    //string APKPath = ConfigurationManager.AppSettings["APKPath"].ToString();
                    string MailSubject = promo.MailSubject;

                    Helper.SendMail(ToEmailID, FromMailID, promo.MailBody, MailSubject, MailServerHost, MailPassword, SendingPort, bccList, MailAttachments);
                    Result = "Email Sent Successfully!!";
                }
                else if (promo.IsSMS == true)
                {
                    string MobileNumbers = string.Join(",", promo.customerList.Where(b => b.IsChecked == true).Select(c => c.MobileNumber));

                    string BaseURL = ConfigurationManager.AppSettings["PromoBaseURL"];
                    string APIKey = ConfigurationManager.AppSettings["PromoAPIKey"];
                    string SenderID = ConfigurationManager.AppSettings["PromotionalSenderID"];
                    Result = Helper.SendMessage(BaseURL, APIKey, MobileNumbers, promo.SMSBody, SenderID);
                }
                return Result;
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return "Error!! Please contact administrator";
            }
        }

        public int GetAllCustomerList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    if (dbContext.Database.Connection.State == System.Data.ConnectionState.Closed)
                        dbContext.Database.Connection.Open();

                    int customerCount = dbContext.tblCustomerVendorDetails.Where(c => c.OrgID == OrgID && c.MobileNumber != null && c.EmailID != null).Count();
                    return customerCount;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return 0;
            }
        }

        public MainCList GetCustomerList(CustomerCreation search)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    MainCList mainCList = new MainCList();

                    //Get Tally User ID
                    int TallyUserID = Entities.tblSysUsers.Where(s => s.FName.ToLower() == "administrator").FirstOrDefault().UserID;

                    List<tblSysUser> UserList = Entities.tblSysUsers.Where(u => u.RoleID == 3).ToList();

                    List<CustomerCreation> customerCreationList = (from c in Entities.tblCustomerVendorDetails
                                                                   where c.OrgID == search.OrgID
                                                                   select new CustomerCreation
                                                                   {
                                                                       CustID = c.CustID,
                                                                       OrgID = c.OrgID,
                                                                       BranchID = c.BranchID,
                                                                       CompanyName = Entities.tblSysOrganizations.Where(o => o.OrgID == c.OrgID).FirstOrDefault().Name,
                                                                       FirmName = c.FirmName,
                                                                       CustomerType = c.CustomerTypeID == null ? "" : Entities.tblCustomerTypes.Where(ct => ct.CustomerTypeID == c.CustomerTypeID).FirstOrDefault().CustomerType,
                                                                       CustomerTypeID = c.CustomerTypeID == null ? 0 : c.CustomerTypeID.Value,
                                                                       CategoryTypeID = c.CategoryTypeID == null ? 0 : c.CategoryTypeID.Value,
                                                                       TaxationTypeID = c.TaxationTypeID == null ? 0 : c.TaxationTypeID.Value,
                                                                       LedgerTypeID = c.LedgerTypeID == null ? 0 : c.LedgerTypeID.Value,
                                                                       CompanyTypeID = c.CompanyTypeID == null ? 0 : c.CompanyTypeID.Value,
                                                                       AliasName = c.AliasName,
                                                                       BillingState = c.BillingState,
                                                                       BillingCity = string.IsNullOrEmpty(c.BillingCity) == false ? c.BillingCity : "",
                                                                       BillingArea = c.BillingArea == null ? string.Empty : c.BillingArea,
                                                                       LedgerType = c.LedgerType,
                                                                       MobileNumber = c.MobileNumber,
                                                                       StateID = c.StateID == null ? 0 : c.StateID.Value,
                                                                       CityID = c.CityID == null ? 0 : c.CityID.Value,
                                                                       CreatedByID = c.CreatedByID,
                                                                       ModifiedByID = c.ModifiedByID == null ? 0 : c.ModifiedByID,
                                                                       CreationDate = c.CreationDate,
                                                                       UpdatedDate = c.UpdatedDate == null ? new DateTime() : c.UpdatedDate.Value,
                                                                       EmailID = c.EmailID,
                                                                       RegistrationType = c.RegistrationType,
                                                                       TypeofCategory = c.TypeofCategory,
                                                                       Name = c.OwnerName,
                                                                       CompanyType = c.CompanyType,
                                                                       SalesManID = c.SalesManID != null ? c.SalesManID : 0,
                                                                       CreatedStr = c.CreatedByID == 0 ? string.Empty : (Entities.tblSysUsers.Where(s => s.UserID == c.CreatedByID).FirstOrDefault().FName),
                                                                       UpdatedStr = c.ModifiedByID == null ? string.Empty : (Entities.tblSysUsers.Where(s => s.UserID == c.ModifiedByID).FirstOrDefault().FName),
                                                                       Religion = c.Religion == null ? "" : c.Religion,
                                                                   }).ToList();

                    customerCreationList.ForEach(c => c.StateID = c.StateID == null ? 0 : c.StateID);

                    if (search.BranchList != null && search.BranchList.Count() > 0)
                    {
                        customerCreationList = customerCreationList.Where(m => search.BranchList.Contains(Convert.ToInt32(m.BranchID))).ToList();
                    }

                    if (!string.IsNullOrEmpty(search.FirmName))
                    {
                        customerCreationList = customerCreationList.Where(c => c.FirmName.ToLower().Contains(search.FirmName.ToLower())).ToList();
                    }
                    if (!string.IsNullOrEmpty(search.Religion) && search.Religion != "0")
                    {
                        customerCreationList = customerCreationList.Where(c => c.Religion.ToLower() == search.Religion.ToLower()).ToList();
                    }

                    if (search.StateList != null && search.StateList.Count() > 0)
                    {
                        customerCreationList = customerCreationList.Where(m => search.StateList.Contains(m.StateID.Value)).ToList();
                    }

                    if (search.DistrictList != null && search.DistrictList.Count() > 0)
                    {
                        List<tblStateWithCity> CitiesList = Entities.tblStateWithCities.Where(c => search.DistrictList.Contains(c.DistrictID.Value)).ToList();

                        customerCreationList = customerCreationList.Where(m => CitiesList.Any(ct => ct.StatewithCityID == m.CityID.Value)).ToList();
                    }

                    if (search.CityList != null && search.CityList.Count() > 0)
                    {
                        customerCreationList = customerCreationList.Where(m => search.CityList.Contains(m.CityID.Value)).ToList();
                    }

                    if (search.AreaList != null && search.AreaList.Count() > 0)
                    {
                        search.AreaList = search.AreaList.Select(s => s.ToLowerInvariant()).ToArray();
                        customerCreationList = customerCreationList.Where(m => search.AreaList.Contains(m.BillingArea.ToLower())).ToList();
                    }

                    if (search.Created == true)
                    {
                        var CreatedRecords = customerCreationList.Where(m => m.CreatedByID.Value != TallyUserID).ToList();
                        customerCreationList = new List<CustomerCreation>();
                        customerCreationList = CreatedRecords;
                    }
                    else if (search.Updated == true)
                    {
                        var UpdatedRecords = customerCreationList.Where(m => m.CreatedByID.Value == TallyUserID && m.ModifiedByID.Value != 0).ToList();
                        customerCreationList = new List<CustomerCreation>();
                        customerCreationList = UpdatedRecords;
                    }
                    else if (search.UpdatePending == true)
                    {
                        var UpdatedRecords = customerCreationList.Where(m => m.CreatedByID.Value == TallyUserID && m.ModifiedByID.Value == 0).ToList();
                        if(search.BillingCityList != null && search.BillingCityList.Count() > 0)
                        {
                            search.BillingCityList = search.BillingCityList.Select(b => b.ToLowerInvariant().Trim()).ToArray();
                            UpdatedRecords = UpdatedRecords.Where(c => search.BillingCityList.Contains(c.BillingCity.ToLower().Trim())).ToList();
                        }
                        customerCreationList = new List<CustomerCreation>();
                        customerCreationList = UpdatedRecords;
                    }

                    if (search.SalesmanList != null && search.SalesmanList.Count() > 0)
                    {
                        if (search.Created == true)
                        {
                            if (search.Created == true && search.Updated == true)
                            {
                                var CreatedByUser = customerCreationList.Where(m => search.SalesmanList.Contains(m.CreatedByID.Value) && m.CreatedByID.Value != TallyUserID).ToList();
                                var UpdatedByUser = customerCreationList.Where(m => search.SalesmanList.Contains(m.ModifiedByID.Value) && !search.SalesmanList.Contains(m.CreatedByID.Value)).ToList();
                                customerCreationList = new List<CustomerCreation>();
                                customerCreationList = CreatedByUser.Union(UpdatedByUser).Distinct().ToList();
                            }
                            else
                            {
                                var CreatedByUser = customerCreationList.Where(m => search.SalesmanList.Contains(m.CreatedByID.Value) && m.CreatedByID.Value != TallyUserID).ToList();
                                customerCreationList = new List<CustomerCreation>();
                                customerCreationList = CreatedByUser;
                                //customerCreationList = customerCreationList.Where(m => search.SalesmanList.Contains(m.CreatedByID.Value)).ToList();
                            }
                        }
                        else if (search.Updated == true)
                        {
                            //updated list
                            var UpdatedByUser = customerCreationList.Where(m => search.SalesmanList.Contains(m.ModifiedByID.Value) && !search.SalesmanList.Contains(m.CreatedByID.Value)).ToList();
                            customerCreationList = new List<CustomerCreation>();
                            customerCreationList = UpdatedByUser;
                            //customerCreationList = customerCreationList.Where(m => m.CreatedByID.Value == TallyUserID).ToList();
                        }
                        else
                        {
                            //salesman id list
                            //var customerCreationListSM = customerCreationList.Where(m => search.SalesmanList.Contains(m.SalesManID.Value)).ToList();
                            //created list
                            var customerCreationListCreated = customerCreationList.Where(m => search.SalesmanList.Contains(m.CreatedByID.Value) && m.CreatedByID.Value != TallyUserID).ToList();
                            //updated list
                            var customerCreationListUpdated = customerCreationList.Where(m => search.SalesmanList.Contains(m.ModifiedByID.Value) && !search.SalesmanList.Contains(m.CreatedByID.Value)).ToList();
                            customerCreationList = new List<CustomerCreation>();

                            //customerCreationList = customerCreationListSM.Union(customerCreationListCreated).Union(customerCreationListUpdated).Distinct().ToList();
                            customerCreationList = customerCreationListCreated.Union(customerCreationListUpdated).Distinct().ToList();

                            customerCreationList = customerCreationList.Distinct().ToList();
                        }
                    }

                    #region date filter
                    if (!string.IsNullOrEmpty(search.FromDate) && !string.IsNullOrEmpty(search.ToDate))
                    {
                        DateTime FromDateTime = Convert.ToDateTime(search.FromDate);
                        DateTime ToDateTime = Convert.ToDateTime(search.ToDate);

                        //created list
                        var customerCreationListCreated = customerCreationList.Where(c => Convert.ToDateTime(c.CreationDate.ToString("yyyy-MM-dd")) >= FromDateTime && Convert.ToDateTime(c.CreationDate.ToString("yyyy-MM-dd")) <= ToDateTime).ToList();
                        //updated list
                        var customerCreationListUpdated = customerCreationList.Where(c => Convert.ToDateTime(c.UpdatedDate.Value.ToString("yyyy-MM-dd")) >= FromDateTime && Convert.ToDateTime(c.UpdatedDate.Value.ToString("yyyy-MM-dd")) <= ToDateTime).ToList();

                        customerCreationList = new List<CustomerCreation>();

                        customerCreationList = customerCreationListCreated.Union(customerCreationListUpdated).Distinct().ToList();

                        customerCreationList = customerCreationList.Distinct().ToList();
                    }
                    #endregion

                    string LedgerType = string.Empty, CustomerType = string.Empty, CompanyType = string.Empty, CategoryType = string.Empty, TaxationType = string.Empty;

                    if (search.LedgerTypeID != null && search.LedgerTypeID != 0)
                    {
                        customerCreationList = customerCreationList.Where(m => m.LedgerTypeID == search.LedgerTypeID).ToList();
                    }
                    if (search.CustomerTypeList != null && search.CustomerTypeList.Count() > 0)
                    {
                        customerCreationList = customerCreationList.Where(ct => search.CustomerTypeList.Contains(ct.CustomerTypeID.Value)).ToList();
                    }
                    if (search.CompanyTypeList != null && search.CompanyTypeList.Count() > 0)
                    {
                        customerCreationList = customerCreationList.Where(m => search.CompanyTypeList.Contains(m.CompanyTypeID.Value)).ToList();
                    }
                    if (search.CategoryTypeList != null && search.CategoryTypeList.Count() > 0)
                    {
                        customerCreationList = customerCreationList.Where(m => search.CategoryTypeList.Contains(m.CategoryTypeID.Value)).ToList();
                    }
                    if (search.TaxationTypeList != null && search.TaxationTypeList.Count() > 0)
                    {
                        customerCreationList = customerCreationList.Where(m => search.TaxationTypeList.Contains(m.TaxationTypeID.Value)).ToList();
                    }

                    mainCList.PendingRecords = customerCreationList.Where(m => search.BranchList.Contains(Convert.ToInt32(m.BranchID)) && m.CreatedByID.Value == TallyUserID && m.ModifiedByID.Value == 0).Count();
                    mainCList.TotalRecords = customerCreationList.Where(v => search.BranchList.Contains(Convert.ToInt32(v.BranchID)) && v.CreatedByID == TallyUserID).Count();
                    mainCList.UpdatedRecords = customerCreationList.Where(v => search.BranchList.Contains(Convert.ToInt32(v.BranchID)) && v.CreatedByID == TallyUserID && v.ModifiedByID.Value != 0).Count();

                    mainCList.customerList = customerCreationList;
                    return mainCList;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        private class CustomerComparer : IEqualityComparer<CustomerCreation>
        {
            public bool Equals(CustomerCreation x, CustomerCreation y)
            {
                return x.CustID == y.CustID && x.SalesManID == y.SalesManID;
            }

            // If Equals() returns true for a pair of objects 
            // then GetHashCode() must return the same value for these objects.

            public int GetHashCode(CustomerCreation myModel)
            {
                return myModel.CustID.GetHashCode();
            }
        }
    }
}
