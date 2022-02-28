using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.DLCustomerCreation.Reports;
using WBT.Entity;
using System.Linq.Dynamic;
using System.Configuration;
using System.Data.Entity;

namespace WBT.DLCustomerCreation
{
    public class CustomerCreation
    {
        public int ID { get; set; }
        public string CustID { get; set; }
        public string OrgID { get; set; }
        public string BranchID { get; set; }
        public Nullable<int> PercStrctureID { get; set; }
        public string Parent4 { get; set; }
        public string Parent3 { get; set; }
        public string Parent2 { get; set; }
        public string Parent1 { get; set; }
        public string FirmName { get; set; }
        public string AliasName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingLandMark { get; set; }
        public string Address3 { get; set; }
        public string Country { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPincode { get; set; }
        public string ContactpersonName { get; set; }
        public string TelephoneNumber { get; set; }
        public string ContactpersonPhone { get; set; }
        public string FaxNo { get; set; }
        public string EmailID { get; set; }
        public string CCEmail { get; set; }
        public string Website { get; set; }
        public string PANNumber { get; set; }
        public string GSTNumber { get; set; }
        public string RegistrationType { get; set; }
        public string CrDays { get; set; }
        public string Description { get; set; }
        public string Narration { get; set; }
        public string BillWiseYesNo { get; set; }
        public string CrLimit { get; set; }
        public string Checkforcreditdaysduringvoucherentry { get; set; }
        public string OverrideCreditlimit { get; set; }
        public string Inventoryvaluesareaffected { get; set; }
        public string ActivateInterestCalculation { get; set; }
        public string CalculateInterestTransaction_by_Transaction { get; set; }
        public string OverrideParametersforeachtransaction { get; set; }
        public string IntrestRate { get; set; }
        public string InterestDays { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string OpeningBalance { get; set; }
        public string Name { get; set; }
        public string CompanyType { get; set; }
        public string ShippingGPSLocation { get; set; }
        public string ShippingLatitude { get; set; }
        public string ShippingLongitude { get; set; }
        public string ShippingArea { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingCityCode { get; set; }
        public string BillingAddress { get; set; }
        public string BillingLandmark { get; set; }
        public string BillingGPSLocation { get; set; }
        public string BillingPincode { get; set; }
        public string BillingLatitude { get; set; }
        public string BillingLongitude { get; set; }
        public string BillingState { get; set; }
        public string BillingCity { get; set; }
        public string BillingCityCode { get; set; }
        public string BillingArea { get; set; }
        public string PostDatedTransaction { get; set; }
        public bool IsTallyUpdated { get; set; }
        public Nullable<int> NoofOutstandingBill { get; set; }
        public Nullable<bool> ActivateIntrest { get; set; }
        public string LedgerName { get; set; }
        public string LedgerType { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateNumber { get; set; }
        public string GSTPhoto { get; set; }
        public string PANPhoto { get; set; }
        public string ShopImage { get; set; }
        public string BankBranch { get; set; }
        public string BankCity { get; set; }
        public string InsuranceCompany { get; set; }
        public string InsuranceNumber { get; set; }
        public string InsuranceExpiryDate { get; set; }
        public Nullable<bool> IsVendor { get; set; }
        public Nullable<int> SalesManID { get; set; }
        public string ApprovalStatus { get; set; }
        public string SourceOfUpdate { get; set; }
        public string IsRemoved { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }

        System.DateTime mCreationDate = new DateTime();
        public System.DateTime CreationDate
        {
            get
            {
                return mCreationDate.Date;
            }
            set
            {
                mCreationDate = value.Date;
            }
        }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Religion { get; set; }
        public string OwnerPhoto { get; set; }
        public string CustomerType { get; set; }
        public string AadhaarNumber { get; set; }
        public string AadhaarPhoto { get; set; }
        public string TypeofCategory { get; set; }
        public Nullable<int> ParentDebtorID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<int> CityID { get; set; }
        public string Cityname { get; set; }
        public int? CountryID { get; set; }

        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
        public string Remark { get; set; }
        public string DisplayMessage { get; set; }
        public string CompanyName { get; set; }
        public string WeekOffDay { get; set; }
        public Nullable<int> CreditType { get; set; }

        public int[] StateList { get; set; }
        public int[] DistrictList { get; set; }
        public int[] CityList { get; set; }
        public string[] AreaList { get; set; }
        public int[] CustomerTypeList { get; set; }
        public int[] CompanyTypeList { get; set; }
        public int[] CategoryTypeList { get; set; }
        public int[] TaxationTypeList { get; set; }
        public int[] SalesmanList { get; set; }
        public int[] BranchList { get; set; }
        public string[] BillingCityList { get; set; }
        public int? LedgerTypeID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool IsChecked { get; set; }
        public int? CustomerTypeID { get; set; }
        public int? CompanyTypeID { get; set; }
        public int? CategoryTypeID { get; set; }
        public int? TaxationTypeID { get; set; }
        public bool Created { get; set; }
        public bool Updated { get; set; }
        public bool UpdatePending { get; set; }
        public string CreatedStr { get; set; }
        public string UpdatedStr { get; set; }
        public string WatsAppNumber { get; set; }
        public string OldTallyFirmName { get; set; }
        public int UpdatedRecords { get; set; }
        public int TotalRecords { get; set; }
        public bool IsEdited { get; set; }

    }

    public class CustomerListForApp
    {
        public int ID { get; set; }
        public string CustID { get; set; }
        public string OrgID { get; set; }
        public string FirmName { get; set; }
        public string CustomerType { get; set; }
        public string MobileNumber { get; set; }
    }

    public class CustomerCreations : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        private WBT.Entity.tblCustomerVendorDetail lCustomerVendor = new WBT.Entity.tblCustomerVendorDetail();
        private List<tblCustomerVendorDetail> lstCustomerCreation = new List<tblCustomerVendorDetail>();
        private CustomerCreation mCustomerVendorCreation = new CustomerCreation();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<tblCustomerVendorDetail> CUstomerCreation
        {
            get { return lstCustomerCreation; }
            set { lstCustomerCreation = value; }
        }

        //Login for App User
        public UserLogin LoginAppUser(UserLogin userLogin)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        UserLogin ValidateUser = (from s in Entities.tblSysUsers
                                                  join
                   o in Entities.tblSysOrganizations on s.OrgID equals o.OrgID
                                                  where ((s.Mobile == userLogin.MobileNumber || s.Username.ToLower().Trim() == userLogin.UserName.ToLower().Trim()))
                                                  select new UserLogin
                                                  {
                                                      MobileNumber = s.Mobile,
                                                      UserId = s.UserID,
                                                      UserName = s.Username,
                                                      OrgID = s.OrgID,
                                                      OrgName = o.Name,
                                                      Name = s.FName,
                                                      Password = s.Password,
                                                  }).FirstOrDefault();

                        if (ValidateUser != null)
                        {
                            if (userLogin.Password == ValidateUser.Password)
                            {
                                ValidateUser.Message = "success";
                                return ValidateUser;
                            }
                            else
                            {
                                ValidateUser.Message = "Invalid Password";
                                return ValidateUser;
                            }
                        }
                        return ValidateUser;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public UserLogin ForgotPassword(UserLogin userLogin, string BaseURL)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    UserLogin ValidateUser = new UserLogin();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        ValidateUser = (from s in Entities.tblSysUsers
                                        join o in Entities.tblSysOrganizations on s.OrgID equals o.OrgID
                                        where s.Email.ToLower().Trim() == userLogin.EmailID.ToLower().Trim()
                                        select new UserLogin
                                        {
                                            MobileNumber = s.Mobile,
                                            UserId = s.UserID,
                                            UserName = s.Username,
                                            OrgID = s.OrgID,
                                            OrgName = o.Name,
                                            Name = s.FName,
                                            Password = s.Password,
                                            EmailID = s.Email
                                        }).FirstOrDefault();

                        if (ValidateUser != null)
                        {
                            string FromMailID = ConfigurationManager.AppSettings["FromMailID"].ToString();
                            string MailPassword = ConfigurationManager.AppSettings["MailPassword"].ToString();
                            string MailServerHost = ConfigurationManager.AppSettings["MailServerHost"].ToString();
                            string SendingPort = ConfigurationManager.AppSettings["SendingPort"].ToString();
                            string Subject = "Password Recovery";
                            string Body = "Forgot your password? that's not a problem. Follow the link and restore access to your account.<br>" + BaseURL + "ResetPassword?route=" + Helper.Encrypt(ValidateUser.UserId.ToString());

                            ValidateUser.Password = Helper.Decrypt(ValidateUser.Password);
                            Helper.SendMail(ValidateUser.EmailID, FromMailID, Body, Subject, MailServerHost, MailPassword, SendingPort);
                            ValidateUser.Message = "Recover password link sent successfully to your email id.. Kindly check your mail";
                            return ValidateUser;
                        }
                        else
                        {
                            UserLogin Result = new UserLogin();
                            Result.Message = "Email ID is not registered.. Please enter the email id you registered with us";
                            return Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public CustomerID SaveData(object Context)
        {
            mCustomerVendorCreation = ((CustomerCreation)Context);
            string CustID = string.Empty;
            CustomerID customerID = new CustomerID();
            try
            {
                DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    //var IsValueexists = from gCustomer in Entities.tblCustomerVendorDetails.AsNoTracking().ToList()
                    //                    where gCustomer.MobileNumber.Equals(mCustomerVendorCreation.MobileNumber.Trim())
                    //                    select gCustomer;
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();
                    //int CustCount = Entities.tblCustomerVendorDetails.Select(c => c.CustID).Cast<int?>().Max().Value;

                    int CustCount = 0;

                    if (Entities.tblCustomerVendorDetails.Count() > 0)
                    {
                        CustCount = Convert.ToInt32(Entities.tblCustomerVendorDetails.Max(e => e.ID));
                    }

                    tblCustomerVendorDetail IsValueexists = null;

                    if (!string.IsNullOrEmpty(mCustomerVendorCreation.CustID) || mCustomerVendorCreation.CustID != "0")
                    {
                        var IsFirmExists = Entities.tblCustomerVendorDetails.AsNoTracking().Where(C => C.FirmName.ToLower() == mCustomerVendorCreation.FirmName.ToLower() && C.CustID != mCustomerVendorCreation.CustID).FirstOrDefault();
                        if (IsFirmExists != null)
                        {
                            customerID.UpdateStatus = "Firm Name already exists";
                            customerID.StatusCode = 409;
                            return customerID;
                        }

                        IsValueexists = Entities.tblCustomerVendorDetails.AsNoTracking().Where(C => C.CustID.Trim() == mCustomerVendorCreation.CustID.Trim()).FirstOrDefault();

                        if (IsValueexists != null)
                            CustID = IsValueexists.CustID;
                    }
                    else
                    {
                        var IsFirmExists = Entities.tblCustomerVendorDetails.AsNoTracking().Where(C => C.FirmName.ToLower() == mCustomerVendorCreation.FirmName.ToLower()).FirstOrDefault();
                        if (IsFirmExists != null)
                        {
                            customerID.UpdateStatus = "Firm Name already exists";
                            customerID.StatusCode = 409;
                            return customerID;
                        }
                    }

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            lCustomerVendor.OrgID = this.mCustomerVendorCreation.OrgID;
                            lCustomerVendor.PercStrctureID = this.mCustomerVendorCreation.PercStrctureID;
                            lCustomerVendor.RegistrationType = this.mCustomerVendorCreation.RegistrationType;
                            lCustomerVendor.FirmName = this.mCustomerVendorCreation.FirmName;
                            //lCustomerVendor.OwnerName = this.mCustomerVendorCreation.Name;
                            lCustomerVendor.CompanyType = this.mCustomerVendorCreation.CompanyType;
                            lCustomerVendor.ContactpersonName = this.mCustomerVendorCreation.ContactpersonName;
                            lCustomerVendor.ContactpersonPhone = this.mCustomerVendorCreation.ContactpersonPhone;

                            lCustomerVendor.ShippingAddress = this.mCustomerVendorCreation.ShippingAddress;
                            lCustomerVendor.ShippingArea = this.mCustomerVendorCreation.ShippingArea;
                            lCustomerVendor.ShippingCity = this.mCustomerVendorCreation.ShippingCity;
                            lCustomerVendor.ShippingCityCode = this.mCustomerVendorCreation.ShippingCityCode;
                            lCustomerVendor.ShippingGPSLocation = this.mCustomerVendorCreation.ShippingGPSLocation;
                            lCustomerVendor.ShippingLandMark = this.mCustomerVendorCreation.ShippingLandMark;
                            lCustomerVendor.ShippingLatitude = this.mCustomerVendorCreation.ShippingLatitude;
                            lCustomerVendor.ShippingLongitude = this.mCustomerVendorCreation.ShippingLongitude;
                            lCustomerVendor.ShippingPincode = this.mCustomerVendorCreation.ShippingPincode;
                            lCustomerVendor.ShippingState = this.mCustomerVendorCreation.ShippingState;

                            lCustomerVendor.BillingAddress = this.mCustomerVendorCreation.BillingAddress;
                            lCustomerVendor.BillingCity = this.mCustomerVendorCreation.BillingCity;
                            lCustomerVendor.BillingCityCode = this.mCustomerVendorCreation.BillingCityCode;
                            lCustomerVendor.BillingGPSLocation = this.mCustomerVendorCreation.BillingGPSLocation;
                            lCustomerVendor.BillingLandmark = this.mCustomerVendorCreation.BillingLandmark;
                            lCustomerVendor.BillingLatitude = this.mCustomerVendorCreation.BillingLatitude;
                            lCustomerVendor.BillingLongitude = this.mCustomerVendorCreation.BillingLongitude;
                            lCustomerVendor.BillingPincode = this.mCustomerVendorCreation.BillingPincode;
                            lCustomerVendor.BillingState = this.mCustomerVendorCreation.BillingState;
                            lCustomerVendor.BillingArea = this.mCustomerVendorCreation.BillingArea;


                            lCustomerVendor.IsTallyUpdated = this.mCustomerVendorCreation.IsTallyUpdated;


                            lCustomerVendor.LedgerType = this.mCustomerVendorCreation.LedgerType;
                            lCustomerVendor.TelephoneNumber = this.mCustomerVendorCreation.TelephoneNumber;
                            lCustomerVendor.MobileNumber = this.mCustomerVendorCreation.MobileNumber;
                            lCustomerVendor.AlternateNumber = this.mCustomerVendorCreation.AlternateNumber;
                            //lCustomerVendor.TINNumber = this.mCustomerVendorCreation.GSTNumber;
                            lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;


                            lCustomerVendor.EmailID = this.mCustomerVendorCreation.EmailID;
                            lCustomerVendor.BankName = this.mCustomerVendorCreation.BankName;
                            lCustomerVendor.Religion = this.mCustomerVendorCreation.Religion;
                            lCustomerVendor.CustomerType = this.mCustomerVendorCreation.CustomerTypeID;
                            lCustomerVendor.TypeofCategory = this.mCustomerVendorCreation.TypeofCategory;


                            lCustomerVendor.BankBranch = this.mCustomerVendorCreation.BankBranch;
                            lCustomerVendor.BankCity = this.mCustomerVendorCreation.BankCity;
                            lCustomerVendor.AccountNumber = this.mCustomerVendorCreation.AccountNumber;
                            lCustomerVendor.IFSCCode = this.mCustomerVendorCreation.IFSCCode;
                            lCustomerVendor.InsuranceCompany = this.mCustomerVendorCreation.InsuranceCompany;
                            lCustomerVendor.InsuranceNumber = this.mCustomerVendorCreation.InsuranceNumber;
                            lCustomerVendor.InsuranceExpiryDate = null;
                            lCustomerVendor.StateID = this.mCustomerVendorCreation.StateID;
                            lCustomerVendor.CityID = this.mCustomerVendorCreation.CityID;

                            lCustomerVendor.SalesManID = this.mCustomerVendorCreation.SalesManID;
                            lCustomerVendor.ApprovalStatus = this.mCustomerVendorCreation.ApprovalStatus;
                            lCustomerVendor.SourceOfUpdate = this.mCustomerVendorCreation.SourceOfUpdate;
                            lCustomerVendor.IsRemoved = this.mCustomerVendorCreation.IsRemoved;

                            lCustomerVendor.AliasName = this.mCustomerVendorCreation.AliasName;
                            lCustomerVendor.AadhaarNumber = this.mCustomerVendorCreation.AadhaarNumber;
                            lCustomerVendor.WeekOffDay = this.mCustomerVendorCreation.WeekOffDay;

                            //images
                            lCustomerVendor.GSTPhoto = this.mCustomerVendorCreation.GSTPhoto;
                            lCustomerVendor.AadhaarPhoto = this.mCustomerVendorCreation.AadhaarPhoto;
                            lCustomerVendor.OwnerPhoto = this.mCustomerVendorCreation.OwnerPhoto;
                            lCustomerVendor.PANPhoto = this.mCustomerVendorCreation.PANPhoto;
                            lCustomerVendor.ShopImage = this.mCustomerVendorCreation.ShopImage;

                            lCustomerVendor.LedgerTypeID = this.mCustomerVendorCreation.LedgerTypeID;
                            lCustomerVendor.CustomerTypeID = this.mCustomerVendorCreation.CustomerTypeID;
                            lCustomerVendor.CompanyTypeID = this.mCustomerVendorCreation.CompanyTypeID;
                            lCustomerVendor.CategoryTypeID = this.mCustomerVendorCreation.CategoryTypeID;
                            lCustomerVendor.TaxationTypeID = this.mCustomerVendorCreation.TaxationTypeID;

                            if (IsValueexists != null)
                            {
                                //tally fields
                                lCustomerVendor.FaxNo = IsValueexists.FaxNo;
                                lCustomerVendor.CCEmail = IsValueexists.CCEmail;
                                lCustomerVendor.Website = IsValueexists.Website;
                                lCustomerVendor.BillWiseYesNo = IsValueexists.BillWiseYesNo;
                                lCustomerVendor.Checkforcreditdaysduringvoucherentry = IsValueexists.Checkforcreditdaysduringvoucherentry;
                                lCustomerVendor.OverrideCreditlimit = IsValueexists.OverrideCreditlimit;
                                lCustomerVendor.Inventoryvaluesareaffected = IsValueexists.Inventoryvaluesareaffected;
                                lCustomerVendor.ActivateInterestCalculation = IsValueexists.ActivateInterestCalculation;
                                lCustomerVendor.CalculateInterestTransaction_by_Transaction = IsValueexists.CalculateInterestTransaction_by_Transaction;
                                lCustomerVendor.OverrideCreditlimit = IsValueexists.OverrideCreditlimit;
                                lCustomerVendor.PostDatedTransaction = IsValueexists.PostDatedTransaction;
                                lCustomerVendor.AlternateNumber = IsValueexists.AlternateNumber;
                                lCustomerVendor.Parent1 = IsValueexists.Parent1;
                                lCustomerVendor.Parent2 = IsValueexists.Parent2;
                                lCustomerVendor.Parent3 = IsValueexists.Parent3;
                                lCustomerVendor.Parent4 = IsValueexists.Parent4;
                                lCustomerVendor.ParentDebtorID = IsValueexists.ParentDebtorID;
                                lCustomerVendor.Country = IsValueexists.Country;
                                lCustomerVendor.CrLimit = IsValueexists.CrDays;
                                lCustomerVendor.CrDays = IsValueexists.CrLimit;
                                lCustomerVendor.OverrideParametersforeachtransaction = IsValueexists.OverrideParametersforeachtransaction;
                                lCustomerVendor.IntrestRate = IsValueexists.IntrestRate;
                                lCustomerVendor.InterestDays = IsValueexists.InterestDays;
                                lCustomerVendor.OpeningBalance = IsValueexists.OpeningBalance;
                                lCustomerVendor.NoofOutstandingBill = IsValueexists.NoofOutstandingBill;
                                lCustomerVendor.LedgerName = IsValueexists.LedgerName;
                                lCustomerVendor.IsVendor = IsValueexists.IsVendor;
                                lCustomerVendor.IsActive = IsValueexists.IsActive;
                                lCustomerVendor.PostDatedTransaction = IsValueexists.PostDatedTransaction;
                                lCustomerVendor.ActivateIntrest = IsValueexists.ActivateIntrest;

                                lCustomerVendor.CustID = CustID;
                                lCustomerVendor.ModifiedByID = mCustomerVendorCreation.ModifiedByID;
                                lCustomerVendor.UpdatedDate = DateTimeNow;
                                lCustomerVendor.CreationDate = IsValueexists.CreationDate;
                                lCustomerVendor.CreatedByID = IsValueexists.CreatedByID;
                                Entities.Entry(lCustomerVendor).State = System.Data.Entity.EntityState.Modified;
                                this.GetApplicationActivate.DataState = Common.TransactionType.Edit;
                                customerID.UpdateStatus = "Updated";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(CustID))
                                    CustID = "0";
                                CustID = (CustCount + 1).ToString();
                                lCustomerVendor.CustID = CustID; //(1 + CustCount).ToString();
                                lCustomerVendor.CreatedByID = mCustomerVendorCreation.CreatedByID.Value;
                                lCustomerVendor.CreationDate = DateTimeNow;
                                Entities.tblCustomerVendorDetails.Add(lCustomerVendor);
                                this.GetApplicationActivate.DataState = Common.TransactionType.Save;
                                customerID.UpdateStatus = "Created";
                            }

                            Entities.SaveChanges();
                            dbcxtransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                            this.GetApplicationActivate.GetErrormessages = ex.Message;
                            this.GetApplicationActivate.GetErrorSource = ex.Source;
                            this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                            CustID = "0";
                            customerID.StatusCode = 500;
                            customerID.UpdateStatus = "Error";
                            return customerID;
                            //throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                CustID = "0";
                customerID.StatusCode = 500;
                customerID.UpdateStatus = "Error";
                return customerID;
                //throw;
            }

            customerID.CustID = Convert.ToInt32(CustID);
            return customerID;
            //return this.GetApplicationActivate;
        }

        public List<CustomerCreation> GetData(string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<CustomerCreation> customerCreationList = (from c in Entities.tblCustomerVendorDetails
                                                                       where c.OrgID == OrgID
                                                                       select new CustomerCreation
                                                                       {
                                                                           CustID = c.CustID,
                                                                           OrgID = c.OrgID,
                                                                           PercStrctureID = c.PercStrctureID,
                                                                           FirmName = c.FirmName,
                                                                           CustomerTypeID = c.CustomerType,
                                                                           AliasName = c.AliasName,

                                                                           BillingAddress = c.BillingAddress,
                                                                           BillingLandmark = c.BillingLandmark,
                                                                           BillingPincode = c.BillingPincode,
                                                                           BillingGPSLocation = c.BillingGPSLocation,
                                                                           BillingLatitude = c.BillingLatitude,
                                                                           BillingLongitude = c.BillingLongitude,
                                                                           BillingState = c.BillingState,
                                                                           BillingCity = c.BillingCity,
                                                                           BillingCityCode = c.BillingCityCode,
                                                                           BillingArea = c.BillingArea,

                                                                           ShippingAddress = c.ShippingAddress,
                                                                           ShippingLandMark = c.ShippingLandMark,
                                                                           ShippingPincode = c.ShippingPincode,
                                                                           ShippingGPSLocation = c.ShippingGPSLocation,
                                                                           ShippingLatitude = c.ShippingLatitude,
                                                                           ShippingLongitude = c.ShippingLongitude,
                                                                           ShippingState = c.ShippingState,
                                                                           ShippingCity = c.ShippingCity,
                                                                           ShippingCityCode = c.ShippingCityCode,
                                                                           ShippingArea = c.ShippingArea,

                                                                           PostDatedTransaction = c.PostDatedTransaction == true ? "Yes" : "No",
                                                                           IsTallyUpdated = c.IsTallyUpdated,
                                                                           NoofOutstandingBill = c.NoofOutstandingBill,
                                                                           ActivateIntrest = c.ActivateIntrest,
                                                                           IntrestRate = c.IntrestRate,
                                                                           InterestDays = c.InterestDays,
                                                                           LedgerName = c.LedgerName,
                                                                           LedgerType = c.LedgerType,
                                                                           MobileNumber = c.MobileNumber,
                                                                           AlternateNumber = c.AlternateNumber,
                                                                           GSTPhoto = c.GSTPhoto,
                                                                           PANPhoto = c.PANPhoto,
                                                                           ShopImage = c.ShopImage,

                                                                           AccountNumber = c.AccountNumber,
                                                                           BankBranch = c.BankBranch,
                                                                           BankCity = c.BankCity,
                                                                           BankName = c.BankName,
                                                                           IFSCCode = c.IFSCCode,
                                                                           Country = c.Country,
                                                                           StateID = !string.IsNullOrEmpty(c.BillingState) ? Entities.tblStates.Where(st => st.StateName.ToLower() == c.BillingState).FirstOrDefault().StateID : 0,
                                                                           CityID = c.CityID,

                                                                           InsuranceNumber = c.InsuranceNumber,
                                                                           InsuranceCompany = c.InsuranceCompany,
                                                                           InsuranceExpiryDate = c.InsuranceExpiryDate.ToString(),
                                                                           IsVendor = c.IsVendor,
                                                                           SalesManID = c.SalesManID,
                                                                           ApprovalStatus = c.ApprovalStatus,
                                                                           SourceOfUpdate = c.SourceOfUpdate,
                                                                           IsRemoved = c.IsRemoved,
                                                                           IsActive = c.IsActive,

                                                                           CreatedByID = c.CreatedByID,
                                                                           ModifiedByID = c.ModifiedByID,
                                                                           CreationDate = c.CreationDate,
                                                                           UpdatedDate = c.UpdatedDate,

                                                                           Religion = c.Religion,
                                                                           OwnerPhoto = c.OwnerPhoto,
                                                                           AadhaarNumber = c.AadhaarNumber,
                                                                           AadhaarPhoto = c.AadhaarPhoto,
                                                                           ContactpersonName = c.ContactpersonName,
                                                                           ContactpersonPhone = c.ContactpersonPhone,
                                                                           TelephoneNumber = c.TelephoneNumber,
                                                                           EmailID = c.EmailID,
                                                                           PANNumber = c.PANNumber,
                                                                           //GSTNumber = c.TINNumber,
                                                                           RegistrationType = c.RegistrationType,
                                                                           TypeofCategory = c.TypeofCategory,
                                                                           WeekOffDay = c.WeekOffDay,

                                                                           FaxNo = c.FaxNo,
                                                                           CCEmail = c.CCEmail,
                                                                           Website = c.Website,
                                                                           BillWiseYesNo = c.BillWiseYesNo,
                                                                           Checkforcreditdaysduringvoucherentry = c.Checkforcreditdaysduringvoucherentry,
                                                                           OverrideCreditlimit = c.OverrideCreditlimit,
                                                                           Inventoryvaluesareaffected = c.Inventoryvaluesareaffected,
                                                                           ActivateInterestCalculation = c.ActivateInterestCalculation,
                                                                           CalculateInterestTransaction_by_Transaction = c.CalculateInterestTransaction_by_Transaction,
                                                                           ParentDebtorID = c.ParentDebtorID,
                                                                           Parent1 = c.Parent1,
                                                                           Parent2 = c.Parent2,
                                                                           Parent3 = c.Parent3,
                                                                           Parent4 = c.Parent4,
                                                                           CrDays = c.CrDays,
                                                                           CrLimit = c.CrLimit,
                                                                           OpeningBalance = c.OpeningBalance,
                                                                           //Name = c.OwnerName,
                                                                           CompanyType = c.CompanyType,
                                                                           CompanyName = Entities.tblSysOrganizations.Where(o => o.OrgID == c.OrgID).FirstOrDefault().Name,
                                                                       }).ToList();
                        return customerCreationList;
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.ToString();
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
        public CustomerCreation GetCustomerDetails(string CustID)
        {
            CustomerCreation SCustomerCreation = new CustomerCreation();
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        tblCustomerVendorDetail tblCustomerVendorDetail = Entities.tblCustomerVendorDetails.AsNoTracking().Where(c => c.CustID == CustID.Trim()).FirstOrDefault();
                        SCustomerCreation.CustID = tblCustomerVendorDetail.CustID;
                        SCustomerCreation.OrgID = tblCustomerVendorDetail.OrgID;
                        SCustomerCreation.BranchID = tblCustomerVendorDetail.BranchID;
                        SCustomerCreation.PercStrctureID = tblCustomerVendorDetail.PercStrctureID;
                        SCustomerCreation.FirmName = tblCustomerVendorDetail.FirmName;
                        SCustomerCreation.OldTallyFirmName = tblCustomerVendorDetail.OldTallyFirmName;
                        SCustomerCreation.CustomerTypeID = tblCustomerVendorDetail.CustomerTypeID;
                        SCustomerCreation.AliasName = tblCustomerVendorDetail.AliasName;

                        SCustomerCreation.BillingAddress = tblCustomerVendorDetail.BillingAddress;
                        SCustomerCreation.BillingLandmark = tblCustomerVendorDetail.BillingLandmark;
                        SCustomerCreation.BillingPincode = tblCustomerVendorDetail.BillingPincode;
                        SCustomerCreation.BillingGPSLocation = tblCustomerVendorDetail.BillingGPSLocation;
                        SCustomerCreation.BillingLatitude = tblCustomerVendorDetail.BillingLatitude;
                        SCustomerCreation.BillingLongitude = tblCustomerVendorDetail.BillingLongitude;
                        SCustomerCreation.BillingState = tblCustomerVendorDetail.BillingState;
                        SCustomerCreation.BillingCity = tblCustomerVendorDetail.BillingCity;
                        SCustomerCreation.BillingCityCode = tblCustomerVendorDetail.BillingCityCode;
                        SCustomerCreation.BillingArea = tblCustomerVendorDetail.BillingArea;

                        SCustomerCreation.ShippingAddress = tblCustomerVendorDetail.ShippingAddress;
                        SCustomerCreation.ShippingLandMark = tblCustomerVendorDetail.ShippingLandMark;
                        SCustomerCreation.ShippingPincode = tblCustomerVendorDetail.ShippingPincode;
                        SCustomerCreation.ShippingGPSLocation = tblCustomerVendorDetail.ShippingGPSLocation;
                        SCustomerCreation.ShippingLatitude = tblCustomerVendorDetail.ShippingLatitude;
                        SCustomerCreation.ShippingLongitude = tblCustomerVendorDetail.ShippingLongitude;
                        SCustomerCreation.ShippingState = tblCustomerVendorDetail.ShippingState;
                        SCustomerCreation.ShippingCity = tblCustomerVendorDetail.ShippingCity;
                        SCustomerCreation.ShippingCityCode = tblCustomerVendorDetail.ShippingCityCode;
                        SCustomerCreation.ShippingArea = tblCustomerVendorDetail.ShippingArea;

                        //SCustomerCreation.PostDatedTransaction = tblCustomerVendorDetail.PostDatedTransaction == true ? "Yes" : "No";
                        SCustomerCreation.IsTallyUpdated = tblCustomerVendorDetail.IsTallyUpdated;
                        SCustomerCreation.NoofOutstandingBill = tblCustomerVendorDetail.NoofOutstandingBill;
                        //SCustomerCreation.ActivateIntrest = tblCustomerVendorDetail.ActivateIntrest == true ? "Yes" : "No";
                        SCustomerCreation.IntrestRate = tblCustomerVendorDetail.IntrestRate;
                        SCustomerCreation.InterestDays = tblCustomerVendorDetail.InterestDays;
                        SCustomerCreation.LedgerName = tblCustomerVendorDetail.LedgerName;
                        SCustomerCreation.LedgerType = tblCustomerVendorDetail.LedgerType;
                        SCustomerCreation.MobileNumber = tblCustomerVendorDetail.MobileNumber;
                        SCustomerCreation.AlternateNumber = tblCustomerVendorDetail.AlternateNumber;
                        SCustomerCreation.GSTPhoto = tblCustomerVendorDetail.GSTPhoto;
                        SCustomerCreation.PANPhoto = tblCustomerVendorDetail.PANPhoto;
                        SCustomerCreation.ShopImage = tblCustomerVendorDetail.ShopImage;
                        SCustomerCreation.WatsAppNumber = tblCustomerVendorDetail.WatsAppNumber;
                        SCustomerCreation.Name = tblCustomerVendorDetail.OwnerName;

                        SCustomerCreation.AccountNumber = tblCustomerVendorDetail.AccountNumber;
                        SCustomerCreation.BankBranch = tblCustomerVendorDetail.BankBranch;
                        SCustomerCreation.BankCity = tblCustomerVendorDetail.BankCity;
                        SCustomerCreation.BankName = tblCustomerVendorDetail.BankName;
                        SCustomerCreation.IFSCCode = tblCustomerVendorDetail.IFSCCode;
                        SCustomerCreation.Country = tblCustomerVendorDetail.Country;
                        SCustomerCreation.StateID = !string.IsNullOrEmpty(tblCustomerVendorDetail.BillingState) ? Entities.tblStates.Where(st => st.StateName.ToLower() == tblCustomerVendorDetail.BillingState.ToLower()).FirstOrDefault().StateID : 0;
                        SCustomerCreation.CityID = tblCustomerVendorDetail.CityID;
                        if (tblCustomerVendorDetail.CityID != null)
                            SCustomerCreation.Cityname = Entities.tblStateWithCities.Where(c => c.StatewithCityID == tblCustomerVendorDetail.CityID).FirstOrDefault().VillageLocalityname;
                        SCustomerCreation.CountryID = tblCustomerVendorDetail.CountryID;

                        SCustomerCreation.InsuranceNumber = tblCustomerVendorDetail.InsuranceNumber;
                        SCustomerCreation.InsuranceCompany = tblCustomerVendorDetail.InsuranceCompany;
                        SCustomerCreation.InsuranceExpiryDate = tblCustomerVendorDetail.InsuranceExpiryDate.ToString();
                        SCustomerCreation.IsVendor = tblCustomerVendorDetail.IsVendor;
                        SCustomerCreation.SalesManID = tblCustomerVendorDetail.SalesManID;
                        SCustomerCreation.ApprovalStatus = tblCustomerVendorDetail.ApprovalStatus;
                        SCustomerCreation.SourceOfUpdate = tblCustomerVendorDetail.SourceOfUpdate;
                        SCustomerCreation.IsRemoved = tblCustomerVendorDetail.IsRemoved;
                        SCustomerCreation.IsActive = tblCustomerVendorDetail.IsActive;

                        SCustomerCreation.CreatedByID = tblCustomerVendorDetail.CreatedByID;
                        SCustomerCreation.ModifiedByID = tblCustomerVendorDetail.ModifiedByID;
                        SCustomerCreation.CreationDate = tblCustomerVendorDetail.CreationDate;
                        SCustomerCreation.UpdatedDate = tblCustomerVendorDetail.UpdatedDate;

                        SCustomerCreation.Religion = tblCustomerVendorDetail.Religion;
                        SCustomerCreation.OwnerPhoto = tblCustomerVendorDetail.OwnerPhoto;
                        SCustomerCreation.AadhaarNumber = tblCustomerVendorDetail.AadhaarNumber;
                        SCustomerCreation.AadhaarPhoto = tblCustomerVendorDetail.AadhaarPhoto;
                        SCustomerCreation.ContactpersonName = tblCustomerVendorDetail.ContactpersonName;
                        SCustomerCreation.ContactpersonPhone = tblCustomerVendorDetail.ContactpersonPhone;
                        SCustomerCreation.TelephoneNumber = tblCustomerVendorDetail.TelephoneNumber;
                        SCustomerCreation.EmailID = tblCustomerVendorDetail.EmailID;
                        SCustomerCreation.PANNumber = tblCustomerVendorDetail.PANNumber;
                        SCustomerCreation.GSTNumber = tblCustomerVendorDetail.TINNumber;
                        SCustomerCreation.RegistrationType = tblCustomerVendorDetail.RegistrationType;
                        SCustomerCreation.TypeofCategory = tblCustomerVendorDetail.TypeofCategory;

                        SCustomerCreation.FaxNo = tblCustomerVendorDetail.FaxNo;
                        SCustomerCreation.CCEmail = tblCustomerVendorDetail.CCEmail;
                        SCustomerCreation.Website = tblCustomerVendorDetail.Website;
                        SCustomerCreation.BillWiseYesNo = tblCustomerVendorDetail.BillWiseYesNo;
                        SCustomerCreation.Checkforcreditdaysduringvoucherentry = tblCustomerVendorDetail.Checkforcreditdaysduringvoucherentry;
                        SCustomerCreation.OverrideCreditlimit = tblCustomerVendorDetail.OverrideCreditlimit;
                        SCustomerCreation.OverrideParametersforeachtransaction = tblCustomerVendorDetail.OverrideParametersforeachtransaction;
                        SCustomerCreation.Inventoryvaluesareaffected = tblCustomerVendorDetail.Inventoryvaluesareaffected;
                        SCustomerCreation.ActivateInterestCalculation = tblCustomerVendorDetail.ActivateInterestCalculation;
                        SCustomerCreation.CalculateInterestTransaction_by_Transaction = tblCustomerVendorDetail.CalculateInterestTransaction_by_Transaction;
                        SCustomerCreation.ParentDebtorID = tblCustomerVendorDetail.ParentDebtorID;
                        SCustomerCreation.Parent1 = tblCustomerVendorDetail.Parent1;
                        SCustomerCreation.Parent2 = tblCustomerVendorDetail.Parent2;
                        SCustomerCreation.Parent3 = tblCustomerVendorDetail.Parent3;
                        SCustomerCreation.Parent4 = tblCustomerVendorDetail.Parent4;
                        SCustomerCreation.LedgerTypeID = tblCustomerVendorDetail.LedgerTypeID;
                        SCustomerCreation.CustomerTypeID = tblCustomerVendorDetail.CustomerTypeID;
                        SCustomerCreation.CompanyTypeID = tblCustomerVendorDetail.CompanyTypeID;
                        SCustomerCreation.CategoryTypeID = tblCustomerVendorDetail.CategoryTypeID;
                        SCustomerCreation.TaxationTypeID = tblCustomerVendorDetail.TaxationTypeID;
                        SCustomerCreation.CreditType = tblCustomerVendorDetail.CreditType;
                        SCustomerCreation.ActivateIntrest = tblCustomerVendorDetail.ActivateIntrest;
                        SCustomerCreation.IsEdited = tblCustomerVendorDetail.IsEdited;

                        if (tblCustomerVendorDetail.CreatedByID != 0)
                            SCustomerCreation.CreatedByName = Entities.tblSysUsers.Where(s => s.UserID == tblCustomerVendorDetail.CreatedByID).FirstOrDefault().Username;
                        if (tblCustomerVendorDetail.ModifiedByID != null && tblCustomerVendorDetail.ModifiedByID != 0)
                            SCustomerCreation.UpdatedByName = Entities.tblSysUsers.Where(s => s.UserID == tblCustomerVendorDetail.ModifiedByID).FirstOrDefault().Username;

                        SCustomerCreation.CrDays = tblCustomerVendorDetail.CrDays;
                        SCustomerCreation.CrLimit = tblCustomerVendorDetail.CrLimit;
                        SCustomerCreation.OpeningBalance = tblCustomerVendorDetail.OpeningBalance;
                        //SCustomerCreation.Name = tblCustomerVendorDetail.OwnerName;
                        SCustomerCreation.CompanyType = tblCustomerVendorDetail.CompanyType;
                        SCustomerCreation.CompanyName = Entities.tblSysBranches.Where(b => b.BranchID == tblCustomerVendorDetail.BranchID).FirstOrDefault().Name;
                        SCustomerCreation.WeekOffDay = tblCustomerVendorDetail.WeekOffDay;

                        return SCustomerCreation;
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }

        public override object DataActivate(object Context)
        {
            try
            {
                object lResult = null;
                switch (this.GetApplicationActivate.DataState)
                {
                    case Common.TransactionType.Load:
                        lResult = GetData(string.Empty);
                        break;
                    case Common.TransactionType.Find:
                        break;
                    case Common.TransactionType.Save:
                    case Common.TransactionType.Edit:
                        lResult = SaveData(Context);
                        break;
                    case Common.TransactionType.TallyUpdation:
                        break;
                }
                return lResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UserLogin Login(Login obj)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    UserLogin userLogin = new UserLogin();
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var LoginRoleID = (from sysuser in Entities.tblSysUsers
                                       where (sysuser.Username == obj.EmailID || sysuser.Email == obj.EmailID || sysuser.Mobile == obj.EmailID) && sysuser.Password == obj.Password
                                       select sysuser.RoleID).FirstOrDefault();

                    tblSysUser ValidateUser = Entities.tblSysUsers.Where(u => (u.Email == obj.EmailID || u.Username == obj.EmailID || u.Mobile == obj.EmailID) && u.Password == obj.Password && u.RoleID == LoginRoleID && u.IsActive == true).FirstOrDefault();
                    if (ValidateUser != null)
                    {
                        userLogin.UserId = ValidateUser.UserID;
                        userLogin.OrgID = ValidateUser.OrgID;
                        userLogin.FName = ValidateUser.FName;
                        userLogin.RoleID = ValidateUser.RoleID;
                        userLogin.IsTallyUsing = ValidateUser.tblSysOrganization.IsTallyUsing == null ? false : ValidateUser.tblSysOrganization.IsTallyUsing.Value;
                        userLogin.IsServiceInstalled = ValidateUser.tblSysOrganization.IsServiceInstalled == null ? false : ValidateUser.tblSysOrganization.IsServiceInstalled.Value;
                        userLogin.OrgName = ValidateUser.tblSysOrganization.Name;
                        return userLogin;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
        public bool UpdateTallyServiceStatus(string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var organization = Entities.tblSysOrganizations.AsNoTracking().Where(o => o.OrgID == OrgID).FirstOrDefault();

                    tblSysOrganization tblSysOrganization = new tblSysOrganization();
                    tblSysOrganization.OrgID = OrgID;
                    tblSysOrganization.Name = organization.Name;
                    tblSysOrganization.GSTNumber = organization.GSTNumber;
                    tblSysOrganization.ContactPerson = organization.ContactPerson;
                    tblSysOrganization.Mobile = organization.Mobile;
                    tblSysOrganization.BranchName = organization.BranchName;
                    tblSysOrganization.BankName = organization.BankName;
                    tblSysOrganization.AccountNumber = organization.AccountNumber;
                    tblSysOrganization.ShippingAddress = organization.ShippingAddress;
                    tblSysOrganization.IsServiceInstalled = true;
                    Entities.tblSysOrganizations.Attach(tblSysOrganization);
                    Entities.Entry(tblSysOrganization).Property(x => x.IsServiceInstalled).IsModified = true;
                    Entities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return false;
            }
        }

        //Country List
        public List<tblCountry> GetCountryList()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblCountry> countryList = new List<tblCountry>();
                        countryList = (from c in Entities.tblCountries
                                       select c).ToList();
                        return countryList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetStateList
        public List<tblState> GetStateList()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblState> stateList = new List<tblState>();
                        stateList = (from s in Entities.tblStates
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

        //GetStateList
        public List<tblState> GetRegisteredStates(string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblState> stateList = new List<tblState>();
                        stateList = (from s in Entities.tblStates
                                     join c in Entities.tblCustomerVendorDetails on s.StateID equals c.StateID
                                     where c.OrgID == OrgID
                                     select s).Distinct().ToList();

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

        //GetDistricts
        public List<District> GetDistricts()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<District> districts = new List<District>();
                        districts = (from d in Entities.tblDistricts
                                     select new District
                                     {
                                         DistrictID = d.DistrictID,
                                         DistrictName = d.DistrictName
                                     }).ToList();

                        return districts;
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
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblStateWithCity> cityList = new List<tblStateWithCity>();
                        cityList = (from s in Entities.tblStateWithCities
                                    where s.StateID == StateID
                                    select s).Distinct().ToList();

                        cityList = cityList.GroupBy(d => d.StatewithCityID).Select(i => i.FirstOrDefault()).ToList();
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

        public List<City> GetTallyCities(string OrgID, string BranchList)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblSysBranch> branches = new List<tblSysBranch>();
                        if (!string.IsNullOrEmpty(BranchList))
                        {
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
                        }

                        List<City> cityList = new List<City>();
                        cityList = (from s in Entities.tblCustomerVendorDetails
                                    where s.BillingCity != null && s.BillingCity != ""
                                    && s.OrgID == OrgID
                                    select new City
                                    {
                                        BranchID = s.OrgID,
                                        CityName = s.BillingCity
                                    }).Distinct().ToList();

                        if (branches != null && branches.Count() > 0)
                        {
                            cityList = cityList.Where(c => branches.Any(b => b.BranchID == c.BranchID)).ToList();
                        }
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

        //GetCities Of a Branch
        public ACLists GetCitiesOfBranch(List<tblSysBranch> BranchList, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<City> cityList = new List<City>();
                        List<City> billingcityList = new List<City>();
                        List<State> stateList = new List<State>();
                        List<AreaList> areaList = new List<AreaList>();

                        ACLists aCLists = new ACLists();
                        if (BranchList != null && BranchList.Count() > 0)
                        {
                            cityList = (from c in Entities.tblCustomerVendorDetails
                                        join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                        where c.CityID != null && c.StateID != null && c.OrgID == OrgID
                                        select new City
                                        {
                                            BranchID = c.BranchID,
                                            CityID = ct.StatewithCityID,
                                            CityName = ct.VillageLocalityname
                                        }).Distinct().ToList();

                           
                            cityList = (from c in cityList
                                        join b in BranchList on c.BranchID equals b.BranchID
                                        select new City
                                        {
                                            CityID = c.CityID,
                                            CityName = c.CityName
                                        }).Distinct().ToList();
                            cityList = cityList.GroupBy(d => d.CityID).Select(i => i.FirstOrDefault()).ToList();//new line


                            stateList = (from c in Entities.tblCustomerVendorDetails
                                         join s in Entities.tblStates on c.StateID equals s.StateID
                                         where c.StateID != null && c.OrgID == OrgID
                                         select new State
                                         {
                                             BranchID = c.BranchID,
                                             StateID = s.StateID,
                                             StateName = s.StateName
                                         }).Distinct().ToList();
                            stateList = stateList.GroupBy(d => d.StateID).Select(i =>i.FirstOrDefault()).ToList();//new line

                            
                            stateList = (from s in stateList
                                         join b in BranchList on s.BranchID equals b.BranchID
                                         select new State
                                         {
                                             StateID = s.StateID,
                                             StateName = s.StateName
                                         }).Distinct().ToList();
                            //cityList = cityList.GroupBy(d => d.CityID).Select(i => i.FirstOrDefault()).ToList();

                            areaList = (from c in Entities.tblCustomerVendorDetails
                                        where c.BillingArea != null && c.BillingArea != "" && c.OrgID == OrgID
                                        select new AreaList
                                        {
                                            BranchID = c.BranchID,
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();

                            areaList = (from c in areaList
                                        join b in BranchList on c.BranchID equals b.BranchID
                                        select new AreaList
                                        {
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();

                            areaList = areaList.GroupBy(d => d.ShippingArea).Select(i => i.FirstOrDefault()).ToList();//new line

                            var BCityList = Entities.tblCustomerVendorDetails.Where(cc => cc.BillingCity != null && cc.BillingCity != "" && cc.OrgID == OrgID).Select(c => new { c.BranchID, c.BillingCity }).Distinct().ToList();

                            billingcityList = (from c in BCityList
                                               join b in BranchList on c.BranchID equals b.BranchID
                                               where c.BillingCity != null && c.BillingCity != ""
                                               select new City
                                               {
                                                   CityName = c.BillingCity
                                               }).Distinct().ToList();
                            billingcityList = billingcityList.GroupBy(b => b.CityName).Select(i => i.FirstOrDefault()).ToList();

                        }

                        //var CustomerList = Entities.tblCustomerVendorDetails.ToList();
                        //var Cities = (from c in CustomerList
                        //              join ct in cityList on c.CityID equals ct.CityID
                        //              join b in BranchList on c.OrgID equals b.BranchID
                        //              select new City
                        //              {
                        //                  CityID = ct.CityID,
                        //                  CityName = ct.CityName
                        //              }).Distinct().ToList();

                        var bCitylist = (from c in billingcityList
                                         select new
                                         {
                                             label = c.CityName,
                                             value = c.CityName
                                         }).ToList();

                        aCLists.cities = cityList;
                        aCLists.states = stateList;
                        aCLists.areaLists = areaList;
                        aCLists.billingcities = bCitylist;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetCities, districts and areas Of a state
        public ACLists GetCitiesOfState(string BranchList, string StateList, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<City> cityList = new List<City>();
                        List<State> stateList = new List<State>();
                        List<AreaList> areaList = new List<AreaList>();
                        List<District> districts = new List<District>();
                        ACLists aCLists = new ACLists();

                        List<tblSysBranch> branches = new List<tblSysBranch>();
                        List<State> states = new List<State>();

                        if (!string.IsNullOrEmpty(StateList))
                        {
                            string[] splitstr = null;
                            if (StateList.Contains(','))
                            {
                                splitstr = StateList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int StateID = Convert.ToInt32(splitstr[i]);
                                    states.Add(new State()
                                    {
                                        StateID = StateID
                                    });
                                }
                            }
                            else
                            {
                                int StateID = Convert.ToInt32(StateList);
                                states.Add(new State()
                                {
                                    StateID = StateID
                                });
                            }
                            if (!string.IsNullOrEmpty(BranchList))
                            {
                                string[] splitBranchstr = null;
                                if (BranchList.Contains(','))
                                {
                                    splitBranchstr = BranchList.Split(',');
                                    for (int i = 0; i < splitBranchstr.Length; i++)
                                    {
                                        int BranchID = Convert.ToInt32(splitBranchstr[i]);
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

                            cityList = (from c in Entities.tblCustomerVendorDetails
                                        join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                        join s in Entities.tblStates on c.BillingState equals s.StateName
                                        where c.OrgID == OrgID && c.BillingCity != null && c.BillingState != null && c.StateID != null && c.CityID != null
                                        select new City
                                        {
                                            BranchID = c.BranchID,
                                            StateID = s.StateID,
                                            CityID = ct.StatewithCityID,
                                            CityName = ct.VillageLocalityname,
                                            DistrictID = ct.DistrictID.Value
                                        }).Distinct().ToList();

                            cityList = (from c in cityList
                                        join b in branches on c.BranchID equals b.BranchID
                                        join s in states on c.StateID equals s.StateID
                                        select new City
                                        {
                                            CityID = c.CityID,
                                            CityName = c.CityName,
                                            DistrictID = c.DistrictID,
                                            StateID = s.StateID
                                        }).Distinct().ToList();

                            var dList = cityList.GroupBy(dls => dls.DistrictID).Select(i => i.FirstOrDefault()).ToList();

                            //string json1 = JsonConvert.SerializeObject(dList);
                            //Helper.TransactionLog(json1, 1, true);

                            var DistrictList = (from dst in Entities.tblDistricts.ToList()
                                                join s in states on dst.StateID equals s.StateID
                                                select new District
                                                {
                                                    DistrictID = dst.DistrictID,
                                                    DistrictName = dst.DistrictName
                                                }).Distinct().ToList();

                            DistrictList = (from dst in DistrictList
                                            join c in dList on dst.DistrictID equals c.DistrictID
                                            select new District
                                            {
                                                DistrictID = dst.DistrictID,
                                                DistrictName = dst.DistrictName
                                            }).Distinct().ToList();
                            districts = DistrictList.GroupBy(d => d.DistrictID).Select(i => i.FirstOrDefault()).ToList();

                            areaList = (from c in Entities.tblCustomerVendorDetails
                                        join s in Entities.tblStates on c.BillingState equals s.StateName
                                        where c.OrgID == OrgID && c.BillingArea != null && c.BillingArea != "" && c.StateID != null
                                        select new AreaList
                                        {
                                            BranchID = c.BranchID,
                                            StateID = s.StateID,
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();

                            areaList = (from c in areaList
                                        join b in branches on c.BranchID equals b.BranchID
                                        join s in states on c.StateID equals s.StateID
                                        select new AreaList
                                        {
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();
                        }
                        areaList = areaList.GroupBy(d => d.ShippingArea).Select(i => i.FirstOrDefault()).ToList();//new line

                        aCLists.cities = cityList;
                        aCLists.districts = districts;
                        aCLists.areaLists = areaList;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetCities, areas Of a state
        public ACLists GetCitiesOfDistrict(string BranchList, string StateList, string DistrictList, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<City> cityList = new List<City>();
                        List<State> stateList = new List<State>();
                        List<AreaList> areaList = new List<AreaList>();
                        ACLists aCLists = new ACLists();

                        List<tblSysBranch> branches = new List<tblSysBranch>();
                        List<State> states = new List<State>();
                        List<District> districts = new List<District>();

                        if (!string.IsNullOrEmpty(StateList))
                        {

                            string[] splitstr = null;
                            if (StateList.Contains(','))
                            {
                                splitstr = StateList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int StateID = Convert.ToInt32(splitstr[i]);
                                    states.Add(new State()
                                    {
                                        StateID = StateID
                                    });
                                }
                            }
                            else
                            {
                                int StateID = Convert.ToInt32(StateList);
                                states.Add(new State()
                                {
                                    StateID = StateID
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(BranchList))
                        {

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
                        }
                        if (!string.IsNullOrEmpty(DistrictList))
                        {

                            string[] splitstr = null;
                            if (DistrictList.Contains(','))
                            {
                                splitstr = DistrictList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int DistrictID = Convert.ToInt32(splitstr[i]);
                                    districts.Add(new District()
                                    {
                                        DistrictID = DistrictID
                                    });
                                }
                            }
                            else
                            {
                                int DistrictID = Convert.ToInt32(DistrictList);
                                districts.Add(new District()
                                {
                                    DistrictID = DistrictID
                                });
                            }
                        }

                        cityList = (from c in Entities.tblCustomerVendorDetails
                                    join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                    join s in Entities.tblStates on c.BillingState equals s.StateName
                                    where c.OrgID == OrgID && c.BillingCity != null && c.BillingState != null
                                    select new City
                                    {
                                        BranchID = c.BranchID,
                                        StateID = s.StateID,
                                        CityID = ct.StatewithCityID,
                                        CityName = ct.VillageLocalityname,
                                        DistrictID = ct.DistrictID.Value
                                    }).Distinct().ToList();

                        if (states != null && states.Count() > 0)
                        {
                            cityList = (from c in cityList
                                        join b in branches on c.BranchID equals b.BranchID
                                        join s in states on c.StateID equals s.StateID
                                        join d in districts on c.DistrictID equals d.DistrictID
                                        select new City
                                        {
                                            CityID = c.CityID,
                                            CityName = c.CityName,
                                            DistrictID = c.DistrictID
                                        }).Distinct().ToList();
                            cityList = cityList.GroupBy(d => d.CityID).Select(i => i.FirstOrDefault()).ToList(); //new line

                        }
                        else
                        {
                            cityList = (from c in cityList
                                        join b in branches on c.BranchID equals b.BranchID
                                        join d in districts on c.DistrictID equals d.DistrictID
                                        select new City
                                        {
                                            CityID = c.CityID,
                                            CityName = c.CityName,
                                            DistrictID = c.DistrictID
                                        }).Distinct().ToList();
                        }

                        areaList = (from c in Entities.tblCustomerVendorDetails
                                    join s in Entities.tblStates on c.BillingState equals s.StateName
                                    where c.OrgID == OrgID && c.BillingArea != null && c.BillingArea != "" && c.StateID != null && c.CityID != null
                                    select new AreaList
                                    {
                                        BranchID = c.BranchID,
                                        StateID = s.StateID,
                                        CityID = c.CityID.Value,
                                        BillingArea = c.BillingArea,
                                        ShippingArea = c.BillingArea
                                    }).Distinct().ToList();
                         

                        if (states != null && states.Count() > 0)
                        {
                            areaList = (from c in areaList
                                        join b in branches on c.BranchID equals b.BranchID
                                        join s in states on c.StateID equals s.StateID
                                        join ct in cityList on c.CityID equals ct.CityID
                                        select new AreaList
                                        {
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();
                        }
                        

                        else
                        {
                            areaList = (from c in areaList
                                        join b in branches on c.BranchID equals b.BranchID
                                        select new AreaList
                                        {
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();
                           
                        }
                        areaList = areaList.GroupBy(d => d.ShippingArea).Select(i => i.FirstOrDefault()).ToList(); //new line

                        aCLists.cities = cityList;
                        aCLists.areaLists = areaList;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetCities, areas Of a state
        public ACLists GetAreasofCity(string BranchList, string StateList, string DistrictList, string CityList, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<City> cityList = new List<City>();
                        List<State> stateList = new List<State>();
                        List<AreaList> areaList = new List<AreaList>();
                        ACLists aCLists = new ACLists();

                        List<tblSysBranch> branches = new List<tblSysBranch>();
                        List<State> states = new List<State>();
                        List<District> districts = new List<District>();
                        List<City> cities = new List<City>();

                        if (!string.IsNullOrEmpty(StateList))
                        {

                            string[] splitstr = null;
                            if (StateList.Contains(','))
                            {
                                splitstr = StateList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int StateID = Convert.ToInt32(splitstr[i]);
                                    states.Add(new State()
                                    {
                                        StateID = StateID
                                    });
                                }
                            }
                            else
                            {
                                int StateID = Convert.ToInt32(StateList);
                                states.Add(new State()
                                {
                                    StateID = StateID
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(BranchList))
                        {

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
                        }
                        if (!string.IsNullOrEmpty(DistrictList))
                        {

                            string[] splitstr = null;
                            if (DistrictList.Contains(','))
                            {
                                splitstr = DistrictList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int DistrictID = Convert.ToInt32(splitstr[i]);
                                    districts.Add(new District()
                                    {
                                        DistrictID = DistrictID
                                    });
                                }
                            }
                            else
                            {
                                int DistrictID = Convert.ToInt32(DistrictList);
                                districts.Add(new District()
                                {
                                    DistrictID = DistrictID
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(CityList))
                        {
                            string[] splitstr = null;
                            if (CityList.Contains(','))
                            {
                                splitstr = CityList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int CityID = Convert.ToInt32(splitstr[i]);
                                    cities.Add(new City()
                                    {
                                        CityID = CityID
                                    });
                                }
                            }
                            else
                            {
                                int CityID = Convert.ToInt32(CityList);
                                cities.Add(new City()
                                {
                                    CityID = CityID
                                });
                            }
                        }

                        areaList = (from c in Entities.tblCustomerVendorDetails
                                    join s in Entities.tblStates on c.BillingState equals s.StateName
                                    where c.OrgID == OrgID && c.BillingArea != null && c.BillingArea != "" && c.StateID != null && c.CityID != null
                                    select new AreaList
                                    {
                                        BranchID = c.BranchID,
                                        StateID = s.StateID,
                                        CityID = c.CityID.Value,
                                        BillingArea = c.BillingArea,
                                        ShippingArea = c.BillingArea
                                    }).Distinct().ToList();

                        if (states != null && states.Count() > 0)
                        {
                            areaList = (from c in areaList
                                        join b in branches on c.BranchID equals b.BranchID
                                        join s in states on c.StateID equals s.StateID
                                        join ct in cities on c.CityID equals ct.CityID
                                        select new AreaList
                                        {
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();
                            areaList = areaList.GroupBy(d => d.ShippingArea).Select(i => i.FirstOrDefault()).ToList();//new line
                        }
                        else
                        {
                            areaList = (from c in areaList
                                        join b in branches on c.BranchID equals b.BranchID
                                        join ct in cities on c.CityID equals ct.CityID
                                        select new AreaList
                                        {
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();
                            
                        }
                        areaList = areaList.GroupBy(d => d.ShippingArea).Select(i => i.FirstOrDefault()).ToList();//new line

                        aCLists.areaLists = areaList;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public List<tblStateWithCity> GetAllCities(string OrgID, string UserID = "")
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblStateWithCity> cityList = new List<tblStateWithCity>();
                        if (!string.IsNullOrEmpty(UserID))
                        {
                            if (UserID == "1")
                            {
                                cityList = (from s in Entities.tblStateWithCities
                                            join c in Entities.tblCustomerVendorDetails on s.VillageLocalityname equals c.BillingCity
                                            where c.OrgID == OrgID
                                            select s).Distinct().ToList();

                                cityList = cityList.GroupBy(d => d.VillageLocalityname).Select(i => i.FirstOrDefault()).ToList();
                            }
                            else
                            {
                                cityList = (from s in Entities.tblStateWithCities
                                            join c in Entities.tblCustomerVendorDetails on s.VillageLocalityname equals c.BillingCity
                                            join u in Entities.tblSysUsers on c.OrgID equals u.OrgID
                                            where u.UserID.ToString() == UserID && c.OrgID == OrgID
                                            select s).Distinct().ToList();
                                cityList = cityList.GroupBy(d => d.VillageLocalityname).Select(i => i.FirstOrDefault()).ToList();
                            }
                        }
                        else
                        {
                            cityList = (from s in Entities.tblStateWithCities
                                        join c in Entities.tblCustomerVendorDetails on s.VillageLocalityname equals c.BillingCity
                                        where c.OrgID == OrgID
                                        select s).Distinct().ToList();
                            cityList = cityList.GroupBy(d => d.VillageLocalityname).Select(i => i.FirstOrDefault()).ToList();
                        }
                        return cityList.OrderBy(d => d.VillageLocalityname).ToList();//new line
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //Update from admin portal
        public bool UpdateCustomer(CustomerCreation customerCreation)
        {
            mCustomerVendorCreation = customerCreation;
            try
            {
                DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    var customer = Entities.tblCustomerVendorDetails.AsNoTracking().Where(d => d.CustID == customerCreation.CustID).FirstOrDefault();
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            lCustomerVendor.OrgID = this.mCustomerVendorCreation.OrgID;
                            lCustomerVendor.BranchID = this.mCustomerVendorCreation.BranchID;
                            lCustomerVendor.PercStrctureID = this.mCustomerVendorCreation.PercStrctureID;
                            lCustomerVendor.RegistrationType = this.mCustomerVendorCreation.RegistrationType;
                            lCustomerVendor.FirmName = this.mCustomerVendorCreation.FirmName;
                            lCustomerVendor.OwnerName = this.mCustomerVendorCreation.Name;
                            lCustomerVendor.CompanyType = this.mCustomerVendorCreation.CompanyType;
                            lCustomerVendor.ContactpersonName = this.mCustomerVendorCreation.ContactpersonName;
                            lCustomerVendor.ContactpersonPhone = this.mCustomerVendorCreation.ContactpersonPhone;

                            lCustomerVendor.ShippingAddress = this.mCustomerVendorCreation.ShippingAddress;
                            lCustomerVendor.ShippingArea = this.mCustomerVendorCreation.ShippingArea;
                            lCustomerVendor.ShippingCity = this.mCustomerVendorCreation.ShippingCity;
                            lCustomerVendor.ShippingCityCode = this.mCustomerVendorCreation.ShippingCityCode;
                            lCustomerVendor.ShippingGPSLocation = this.mCustomerVendorCreation.ShippingGPSLocation;
                            lCustomerVendor.ShippingLandMark = this.mCustomerVendorCreation.ShippingLandMark;
                            lCustomerVendor.ShippingLatitude = this.mCustomerVendorCreation.ShippingLatitude;
                            lCustomerVendor.ShippingLongitude = this.mCustomerVendorCreation.ShippingLongitude;
                            lCustomerVendor.ShippingPincode = this.mCustomerVendorCreation.ShippingPincode;
                            lCustomerVendor.ShippingState = this.mCustomerVendorCreation.ShippingState;

                            lCustomerVendor.BillingAddress = this.mCustomerVendorCreation.ShippingAddress;
                            lCustomerVendor.BillingCity = this.mCustomerVendorCreation.ShippingCity;
                            lCustomerVendor.BillingCityCode = this.mCustomerVendorCreation.ShippingCityCode;
                            lCustomerVendor.BillingGPSLocation = this.mCustomerVendorCreation.ShippingGPSLocation;
                            lCustomerVendor.BillingLandmark = this.mCustomerVendorCreation.ShippingLandMark;
                            lCustomerVendor.BillingLatitude = this.mCustomerVendorCreation.ShippingLatitude;
                            lCustomerVendor.BillingLongitude = this.mCustomerVendorCreation.ShippingLongitude;
                            lCustomerVendor.BillingPincode = this.mCustomerVendorCreation.ShippingPincode;
                            lCustomerVendor.BillingState = this.mCustomerVendorCreation.ShippingState;
                            lCustomerVendor.BillingArea = this.mCustomerVendorCreation.BillingArea;

                            lCustomerVendor.PostDatedTransaction = string.IsNullOrEmpty(this.mCustomerVendorCreation.PostDatedTransaction) ? false : true;
                            lCustomerVendor.IsTallyUpdated = this.mCustomerVendorCreation.IsTallyUpdated;
                            lCustomerVendor.CrLimit = this.mCustomerVendorCreation.CrLimit;
                            lCustomerVendor.CrDays = this.mCustomerVendorCreation.CrDays;
                            lCustomerVendor.NoofOutstandingBill = this.mCustomerVendorCreation.NoofOutstandingBill;
                            lCustomerVendor.ActivateIntrest = this.mCustomerVendorCreation.ActivateIntrest;
                            lCustomerVendor.OpeningBalance = this.mCustomerVendorCreation.OpeningBalance;
                            lCustomerVendor.LedgerName = this.mCustomerVendorCreation.LedgerName;
                            lCustomerVendor.LedgerType = this.mCustomerVendorCreation.LedgerType;
                            lCustomerVendor.TelephoneNumber = this.mCustomerVendorCreation.TelephoneNumber;
                            lCustomerVendor.MobileNumber = this.mCustomerVendorCreation.MobileNumber;
                            lCustomerVendor.AlternateNumber = this.mCustomerVendorCreation.AlternateNumber;
                            lCustomerVendor.TINNumber = this.mCustomerVendorCreation.GSTNumber;
                            lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;
                            lCustomerVendor.EmailID = this.mCustomerVendorCreation.EmailID;
                            lCustomerVendor.BankName = this.mCustomerVendorCreation.BankName;
                            lCustomerVendor.Religion = this.mCustomerVendorCreation.Religion;
                            lCustomerVendor.CustomerTypeID = this.mCustomerVendorCreation.CustomerTypeID;
                            lCustomerVendor.TypeofCategory = this.mCustomerVendorCreation.TypeofCategory;
                            lCustomerVendor.StateID = this.mCustomerVendorCreation.StateID;
                            lCustomerVendor.CityID = this.mCustomerVendorCreation.CityID;
                            lCustomerVendor.Cityname = this.mCustomerVendorCreation.Cityname;
                            lCustomerVendor.CountryID = this.mCustomerVendorCreation.CountryID;
                            lCustomerVendor.OldTallyFirmName = this.mCustomerVendorCreation.OldTallyFirmName;
                            lCustomerVendor.CreditType = this.mCustomerVendorCreation.CreditType;

                            lCustomerVendor.BankBranch = this.mCustomerVendorCreation.BankBranch;
                            lCustomerVendor.BankCity = this.mCustomerVendorCreation.BankCity;
                            lCustomerVendor.AccountNumber = this.mCustomerVendorCreation.AccountNumber;
                            lCustomerVendor.IFSCCode = this.mCustomerVendorCreation.IFSCCode;
                            lCustomerVendor.InsuranceCompany = this.mCustomerVendorCreation.InsuranceCompany;
                            lCustomerVendor.InsuranceNumber = this.mCustomerVendorCreation.InsuranceNumber;
                            lCustomerVendor.InsuranceExpiryDate = null;

                            lCustomerVendor.IntrestRate = this.mCustomerVendorCreation.IntrestRate;
                            lCustomerVendor.InterestDays = this.mCustomerVendorCreation.InterestDays;

                            lCustomerVendor.IsVendor = false; //this.mCustomerVendorCreation.IsVendor;
                            lCustomerVendor.SalesManID = this.mCustomerVendorCreation.SalesManID;
                            lCustomerVendor.ApprovalStatus = this.mCustomerVendorCreation.ApprovalStatus;
                            lCustomerVendor.SourceOfUpdate = this.mCustomerVendorCreation.SourceOfUpdate;
                            lCustomerVendor.IsRemoved = this.mCustomerVendorCreation.IsRemoved;
                            lCustomerVendor.IsActive = this.mCustomerVendorCreation.IsActive;
                            lCustomerVendor.Country = this.mCustomerVendorCreation.Country;

                            lCustomerVendor.AliasName = this.mCustomerVendorCreation.AliasName;
                            lCustomerVendor.AadhaarNumber = this.mCustomerVendorCreation.AadhaarNumber;

                            lCustomerVendor.AadhaarPhoto = customer.AadhaarPhoto;
                            lCustomerVendor.GSTPhoto = customer.GSTPhoto;
                            lCustomerVendor.PANPhoto = customer.PANPhoto;
                            lCustomerVendor.OwnerPhoto = customer.OwnerPhoto;
                            lCustomerVendor.ShopImage = customer.ShopImage;

                            lCustomerVendor.CustID = this.mCustomerVendorCreation.CustID;
                            lCustomerVendor.ModifiedByID = this.mCustomerVendorCreation.ModifiedByID;
                            lCustomerVendor.CreatedByID = this.mCustomerVendorCreation.CreatedByID.Value;
                            lCustomerVendor.UpdatedDate = DateTimeNow;
                            lCustomerVendor.CreationDate = this.mCustomerVendorCreation.CreationDate;
                            lCustomerVendor.WeekOffDay = this.mCustomerVendorCreation.WeekOffDay;
                            lCustomerVendor.WatsAppNumber = this.mCustomerVendorCreation.WatsAppNumber;

                            //tally fields
                            lCustomerVendor.FaxNo = this.mCustomerVendorCreation.FaxNo;
                            lCustomerVendor.CCEmail = this.mCustomerVendorCreation.CCEmail;
                            lCustomerVendor.Website = this.mCustomerVendorCreation.Website;
                            lCustomerVendor.BillWiseYesNo = this.mCustomerVendorCreation.BillWiseYesNo;
                            lCustomerVendor.Checkforcreditdaysduringvoucherentry = this.mCustomerVendorCreation.Checkforcreditdaysduringvoucherentry;
                            lCustomerVendor.OverrideCreditlimit = this.mCustomerVendorCreation.OverrideCreditlimit;
                            lCustomerVendor.OverrideParametersforeachtransaction = this.mCustomerVendorCreation.OverrideParametersforeachtransaction;
                            lCustomerVendor.Inventoryvaluesareaffected = this.mCustomerVendorCreation.Inventoryvaluesareaffected;
                            lCustomerVendor.ActivateInterestCalculation = this.mCustomerVendorCreation.ActivateInterestCalculation;
                            lCustomerVendor.CalculateInterestTransaction_by_Transaction = this.mCustomerVendorCreation.CalculateInterestTransaction_by_Transaction;
                            lCustomerVendor.AlternateNumber = this.mCustomerVendorCreation.AlternateNumber;
                            lCustomerVendor.Parent1 = this.mCustomerVendorCreation.Parent1;
                            lCustomerVendor.Parent2 = this.mCustomerVendorCreation.Parent2;
                            lCustomerVendor.Parent3 = this.mCustomerVendorCreation.Parent3;
                            lCustomerVendor.Parent4 = this.mCustomerVendorCreation.Parent4;
                            lCustomerVendor.ParentDebtorID = this.mCustomerVendorCreation.ParentDebtorID;
                            lCustomerVendor.LedgerTypeID = this.mCustomerVendorCreation.LedgerTypeID;
                            lCustomerVendor.CustomerTypeID = this.mCustomerVendorCreation.CustomerTypeID;
                            lCustomerVendor.CompanyTypeID = this.mCustomerVendorCreation.CompanyTypeID;
                            lCustomerVendor.CategoryTypeID = this.mCustomerVendorCreation.CategoryTypeID;
                            lCustomerVendor.TaxationTypeID = this.mCustomerVendorCreation.TaxationTypeID;
                            lCustomerVendor.IsEdited = customer.IsTallyUpdated == true ? true : false;

                            Entities.Entry(lCustomerVendor).State = System.Data.Entity.EntityState.Modified;
                            Entities.SaveChanges();
                            dbcxtransaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                            this.GetApplicationActivate.GetErrormessages = ex.Message;
                            this.GetApplicationActivate.GetErrorSource = ex.Source;
                            this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                            Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                            //throw;
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return false;
                //throw;
            }
        }

        //Tally Sync
        public bool UpdateTallyStatus(CustomerCreation customerCreation)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            tblCustomerVendorDetail tblCustomerVendorDetail = new tblCustomerVendorDetail();
                            tblCustomerVendorDetail.CustID = customerCreation.CustID;
                            tblCustomerVendorDetail.ModifiedByID = customerCreation.ModifiedByID;
                            tblCustomerVendorDetail.TallySync = true;
                            tblCustomerVendorDetail.IsTallyUpdated = false;
                            tblCustomerVendorDetail.UpdatedDate = DateTimeNow;
                            Entities.tblCustomerVendorDetails.Attach(tblCustomerVendorDetail);
                            Entities.Entry(tblCustomerVendorDetail).Property(c => c.ModifiedByID).IsModified = true;
                            Entities.Entry(tblCustomerVendorDetail).Property(c => c.UpdatedDate).IsModified = true;
                            Entities.Entry(tblCustomerVendorDetail).Property(c => c.TallySync).IsModified = true;
                            Entities.Entry(tblCustomerVendorDetail).Property(c => c.IsTallyUpdated).IsModified = true;
                            Entities.SaveChanges();
                            dbcxtransaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                            this.GetApplicationActivate.GetErrormessages = ex.Message;
                            this.GetApplicationActivate.GetErrorSource = ex.Source;
                            this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                            Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                            //throw;
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return false;
                //throw;
            }
        }

        public bool UpdateTallyStatusFromService(CustomerCreation customerCreation, bool Error = false)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            if (Error)
                            {
                                tblCustomerVendorDetail tblCustomerVendorDetail = new tblCustomerVendorDetail();
                                tblCustomerVendorDetail.CustID = customerCreation.CustID;
                                tblCustomerVendorDetail.TallySync = false;
                                tblCustomerVendorDetail.IsTallyUpdated = false;
                                tblCustomerVendorDetail.UpdatedDate = DateTimeNow;
                                Entities.tblCustomerVendorDetails.Attach(tblCustomerVendorDetail);
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.UpdatedDate).IsModified = true;
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.TallySync).IsModified = true;
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.IsTallyUpdated).IsModified = true;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                return true;
                            }
                            else
                            {
                                tblCustomerVendorDetail tblCustomerVendorDetail = new tblCustomerVendorDetail();
                                tblCustomerVendorDetail.CustID = customerCreation.CustID;
                                tblCustomerVendorDetail.TallySync = false;
                                tblCustomerVendorDetail.IsTallyUpdated = true;
                                tblCustomerVendorDetail.UpdatedDate = DateTimeNow;
                                tblCustomerVendorDetail.IsEdited = true;
                                Entities.tblCustomerVendorDetails.Attach(tblCustomerVendorDetail);
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.UpdatedDate).IsModified = true;
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.TallySync).IsModified = true;
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.IsTallyUpdated).IsModified = true;
                                Entities.Entry(tblCustomerVendorDetail).Property(c => c.IsEdited).IsModified = true;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                            this.GetApplicationActivate.GetErrormessages = ex.Message;
                            this.GetApplicationActivate.GetErrorSource = ex.Source;
                            this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                            Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                            //throw;
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return false;
                //throw;
            }
        }

        public List<tblSysOrganization> GetOrgList(string UserID = "")
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblSysOrganization> OrgList = new List<tblSysOrganization>();

                        if (!string.IsNullOrEmpty(UserID))
                        {
                            if (UserID == "1")
                            {

                                OrgList = (from s in Entities.tblSysOrganizations
                                           select s).ToList();
                            }
                            else
                            {
                                OrgList = (from s in Entities.tblSysOrganizations
                                           join u in Entities.tblSysUsers on s.OrgID equals u.OrgID
                                           where u.UserID.ToString() == UserID
                                           select s).ToList();
                            }
                        }
                        else
                        {
                            OrgList = (from s in Entities.tblSysOrganizations
                                       select s).ToList();
                        }

                        return OrgList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<tblSysBranch> GetBranchList(string OrgID, string UserID = "", string RoleName = "")
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblSysBranch> BranchList = new List<tblSysBranch>();

                        if (!string.IsNullOrEmpty(RoleName))
                        {
                            if (RoleName.ToLower() == "admin")
                            {

                                BranchList = (from s in Entities.tblSysBranches
                                              where s.OrgID == OrgID
                                              select s).ToList();
                            }
                            else
                            {
                                BranchList = (from s in Entities.tblSysBranches
                                              join u in Entities.tblSysUsers on s.BranchID equals u.BranchID
                                              where u.UserID.ToString() == UserID
                                              select s).ToList();
                            }
                        }
                        else
                        {
                            BranchList = (from s in Entities.tblSysBranches
                                          where s.OrgID == OrgID
                                          select s).ToList();
                        }

                        return BranchList.OrderBy(a=>a.BranchID).ToList();//new line
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<tblLedgerType> GetLedgerTypes()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblLedgerType> ledgerTypes = (from s in Entities.tblLedgerTypes
                                                           select s).ToList();
                        return ledgerTypes;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<CreditType> GetCreditTypes(string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<CreditType> creditTypes = (from c in Entities.CreditTypes
                                                        where c.OrgId == OrgID
                                                        select c).ToList();

                        return creditTypes;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<BusinessType> GetCustomerTypes(string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<BusinessType> CustomerTypes = new List<BusinessType>();
                        CustomerTypes = (from s in Entities.BusinessTypes
                                         where s.OrgId == OrgID
                                         select s).ToList();

                        return CustomerTypes;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<tblCompanyType> GetCompanyTypes()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblCompanyType> companyTypes = new List<tblCompanyType>();
                        companyTypes = (from s in Entities.tblCompanyTypes
                                        select s).ToList();

                        return companyTypes;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<tblCategoryType> GetCategoryTypes()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblCategoryType> categoryTypes = new List<tblCategoryType>();
                        categoryTypes = (from s in Entities.tblCategoryTypes
                                         select s).ToList();

                        return categoryTypes;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<tblTaxationType> GetTaxationTypes()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblTaxationType> taxationTypes = new List<tblTaxationType>();
                        taxationTypes = (from s in Entities.tblTaxationTypes
                                         select s).ToList();

                        return taxationTypes;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<tblTaxationType> GetReligionList()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblTaxationType> taxationTypes = new List<tblTaxationType>();
                        taxationTypes = (from s in Entities.tblTaxationTypes
                                         select s).ToList();

                        return taxationTypes;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public object GetDashboardData(string FromDate, string ToDate, string OrgID)
        {
            int registered = 0, states = 0, cities = 0, branches = 0;
            int registeredToday = 0, statesToday = 0, citiesToday = 0, branchesToday = 0, salesOrders = 0, salesOrdersToday = 0, receipts = 0, receiptsToday = 0;

            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {

                    //var Customers = Entities.tblCustomerVendorDetails.AsNoTracking().Where(cs => cs.OrgID == OrgID);

                    var Customers = (from c in Entities.tblCustomerVendorDetails
                                     where c.OrgID == OrgID
                                     select new CustomerCreation
                                     {
                                         CreationDate = c.CreationDate,
                                         CityID = c.CityID,
                                         BillingState = c.BillingState,
                                     }).AsEnumerable();

                    if (!string.IsNullOrEmpty(FromDate) && !string.IsNullOrEmpty(ToDate))
                        registered = Customers.Where(c => c.CreationDate <= Convert.ToDateTime(ToDate).Date && c.CreationDate >= Convert.ToDateTime(FromDate).Date).Count();
                    else
                        registered = Customers.Count();

                    registeredToday = Customers.Where(c => c.CreationDate == DateTimeNow.Date).Count();

                    if (!string.IsNullOrEmpty(FromDate) && !string.IsNullOrEmpty(ToDate))
                        states = Customers.Where(c => c.BillingState != null && c.CreationDate <= Convert.ToDateTime(ToDate).Date && c.CreationDate >= Convert.ToDateTime(FromDate).Date).Select(c => c.BillingState).Distinct().Count();
                    else
                        states = Customers.Where(cc => cc.BillingState != null).Select(c => c.BillingState).Distinct().Count();

                    statesToday = Customers.Where(c => c.BillingState != null && c.CreationDate == DateTimeNow.Date).Select(c => c.BillingState).Distinct().Count();

                    if (!string.IsNullOrEmpty(FromDate) && !string.IsNullOrEmpty(ToDate))
                        cities = Customers.Where(c => c.BillingState != null && c.CreationDate <= Convert.ToDateTime(ToDate).Date && c.CreationDate >= Convert.ToDateTime(FromDate).Date).Select(c => c.CityID).Distinct().Count();
                    else
                        cities = Customers.Select(c => c.CityID).Distinct().Count();

                    citiesToday = Customers.Where(c => c.CreationDate == DateTimeNow.Date).Select(c => c.CityID).Distinct().Count();

                    var branchesList = Entities.tblSysBranches.AsNoTracking().Where(b => b.OrgID == OrgID).ToList();
                    branches = branchesList.Count();

                    if (!string.IsNullOrEmpty(FromDate) && !string.IsNullOrEmpty(ToDate))
                    {
                        branches = branchesList.Where(b => b.CreatedDatetime.Date >= Convert.ToDateTime(FromDate).Date && b.CreatedDatetime.Date <= Convert.ToDateTime(ToDate).Date).Count();
                    }
                    else
                        branches = branchesList.Count();

                    if (Entities.tblSysBranches.AsNoTracking().Where(b => b.OrgID == OrgID).Count() > 0)
                        branchesToday = branchesList.Where(b => b.CreatedDatetime.Date == DateTimeNow.Date).Count();

                    //added on 13th October 2021 to get receipts and sales orders count
                    var soList = (from s in Entities.tblSalesOrders
                                  select s);
                    var receiptsList = (from r in Entities.tblAccountReceiptDetails
                                        select r);
                    if (!string.IsNullOrEmpty(FromDate) && !string.IsNullOrEmpty(ToDate))
                    {
                        salesOrders = soList.ToList().FindAll(so => so.CreationDate.Date >= Convert.ToDateTime(FromDate).Date && so.CreationDate.Date <= Convert.ToDateTime(ToDate).Date).Count();
                    }
                    else
                        salesOrders = soList.Count();

                    salesOrdersToday = soList.Where(so => DbFunctions.TruncateTime(so.CreationDate) == DateTimeNow.Date).Count();

                    if (!string.IsNullOrEmpty(FromDate) && !string.IsNullOrEmpty(ToDate))
                    {
                        receipts = receiptsList.ToList().FindAll(r => r.CreationDate.Date >= Convert.ToDateTime(FromDate).Date && r.CreationDate.Date <= Convert.ToDateTime(ToDate).Date).Count();
                    }
                    else
                        receipts = receiptsList.Count();
                    receiptsToday = receiptsList.Where(r => DbFunctions.TruncateTime(r.CreationDate) == DateTimeNow.Date).Count();

                    var json = new
                    {
                        Branches = branches,
                        BranchesToday = branchesToday,
                        Registered = registered,
                        RegisteredToday = registeredToday,
                        Cities = cities,
                        CitiesToday = citiesToday,
                        States = states,
                        StatesToday = statesToday,
                        salesOrders = salesOrders,
                        salesOrdersToday = salesOrdersToday,
                        receipts = receipts,
                        receiptsToday = receiptsToday
                    };

                    return json;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.Source);
                return ex.Message;
            }
            finally
            {

            }
        }
        public List<CustomerListForApp> GetCustomerListForApp(string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<CustomerListForApp> customerCreationList = (from c in Entities.tblCustomerVendorDetails
                                                                         where c.OrgID == OrgID
                                                                         select new CustomerListForApp
                                                                         {
                                                                             CustID = c.CustID,
                                                                             OrgID = c.OrgID,
                                                                             FirmName = c.FirmName,
                                                                             CustomerType = c.CustomerType.ToString(),
                                                                             MobileNumber = c.MobileNumber,
                                                                         }).ToList();
                        return customerCreationList;
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.ToString();
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
        public List<CustomerCreation> GetTallysyncCustomerData(string OrgID)
        {

            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {

                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {

                        List<CustomerCreation> customerCreationList = (from c in Entities.tblCustomerVendorDetails
                                                                       where c.TallySync == true && c.IsTallyUpdated == false
                                                                       && c.OrgID == OrgID
                                                                       select new CustomerCreation
                                                                       {
                                                                           CustID = c.CustID,
                                                                           OrgID = c.OrgID,
                                                                           PercStrctureID = c.PercStrctureID,
                                                                           FirmName = c.FirmName,
                                                                           CustomerTypeID = c.CustomerType,
                                                                           AliasName = c.AliasName,
                                                                           BranchID = c.BranchID,

                                                                           BillingAddress = c.BillingAddress,
                                                                           BillingLandmark = c.BillingLandmark,
                                                                           BillingPincode = c.BillingPincode,
                                                                           BillingGPSLocation = c.BillingGPSLocation,
                                                                           BillingLatitude = c.BillingLatitude,
                                                                           BillingLongitude = c.BillingLongitude,
                                                                           BillingState = c.BillingState,
                                                                           BillingCity = c.BillingCity,
                                                                           BillingCityCode = c.BillingCityCode,
                                                                           BillingArea = c.BillingArea,

                                                                           ShippingAddress = c.ShippingAddress,
                                                                           ShippingLandMark = c.ShippingLandMark,
                                                                           ShippingPincode = c.ShippingPincode,
                                                                           ShippingGPSLocation = c.ShippingGPSLocation,
                                                                           ShippingLatitude = c.ShippingLatitude,
                                                                           ShippingLongitude = c.ShippingLongitude,
                                                                           ShippingState = c.ShippingState,
                                                                           ShippingCity = c.ShippingCity,
                                                                           ShippingCityCode = c.ShippingCityCode,
                                                                           ShippingArea = c.ShippingArea,

                                                                           PostDatedTransaction = c.PostDatedTransaction == true ? "Yes" : "No",
                                                                           IsTallyUpdated = c.IsTallyUpdated,
                                                                           NoofOutstandingBill = c.NoofOutstandingBill,
                                                                           ActivateIntrest = c.ActivateIntrest,
                                                                           IntrestRate = c.IntrestRate,
                                                                           InterestDays = c.InterestDays,
                                                                           LedgerName = c.LedgerName,
                                                                           LedgerType = c.LedgerType,
                                                                           MobileNumber = c.MobileNumber,
                                                                           AlternateNumber = c.AlternateNumber,
                                                                           GSTPhoto = c.GSTPhoto,
                                                                           PANPhoto = c.PANPhoto,
                                                                           ShopImage = c.ShopImage,

                                                                           AccountNumber = c.AccountNumber,
                                                                           BankBranch = c.BankBranch,
                                                                           BankCity = c.BankCity,
                                                                           BankName = c.BankName,
                                                                           IFSCCode = c.IFSCCode,
                                                                           Country = c.Country,
                                                                           StateID = !string.IsNullOrEmpty(c.BillingState) ? Entities.tblStates.Where(st => st.StateName.ToLower() == c.BillingState).FirstOrDefault().StateID : 0,
                                                                           CityID = c.CityID,

                                                                           InsuranceNumber = c.InsuranceNumber,
                                                                           InsuranceCompany = c.InsuranceCompany,
                                                                           InsuranceExpiryDate = c.InsuranceExpiryDate.ToString(),
                                                                           IsVendor = c.IsVendor,
                                                                           SalesManID = c.SalesManID,
                                                                           ApprovalStatus = c.ApprovalStatus,
                                                                           SourceOfUpdate = c.SourceOfUpdate,
                                                                           IsRemoved = c.IsRemoved,
                                                                           IsActive = c.IsActive,

                                                                           CreatedByID = c.CreatedByID,
                                                                           ModifiedByID = c.ModifiedByID,
                                                                           CreationDate = c.CreationDate,
                                                                           UpdatedDate = c.UpdatedDate,

                                                                           Religion = c.Religion,
                                                                           OwnerPhoto = c.OwnerPhoto,
                                                                           AadhaarNumber = c.AadhaarNumber,
                                                                           AadhaarPhoto = c.AadhaarPhoto,
                                                                           ContactpersonName = c.ContactpersonName,
                                                                           ContactpersonPhone = c.ContactpersonPhone,
                                                                           TelephoneNumber = c.TelephoneNumber,
                                                                           EmailID = c.EmailID,
                                                                           PANNumber = c.PANNumber,
                                                                           //GSTNumber = c.TINNumber,
                                                                           RegistrationType = c.RegistrationType,
                                                                           TypeofCategory = c.TypeofCategory,
                                                                           WeekOffDay = c.WeekOffDay,

                                                                           FaxNo = c.FaxNo,
                                                                           CCEmail = c.CCEmail,
                                                                           Website = c.Website,
                                                                           BillWiseYesNo = c.BillWiseYesNo,
                                                                           Checkforcreditdaysduringvoucherentry = c.Checkforcreditdaysduringvoucherentry,
                                                                           OverrideCreditlimit = c.OverrideCreditlimit,
                                                                           Inventoryvaluesareaffected = c.Inventoryvaluesareaffected,
                                                                           ActivateInterestCalculation = c.ActivateInterestCalculation,
                                                                           CalculateInterestTransaction_by_Transaction = c.CalculateInterestTransaction_by_Transaction,
                                                                           ParentDebtorID = c.ParentDebtorID,
                                                                           Parent1 = c.Parent1,
                                                                           Parent2 = c.Parent2,
                                                                           Parent3 = c.Parent3,
                                                                           Parent4 = c.Parent4,
                                                                           CrDays = c.CrDays,
                                                                           CrLimit = c.CrLimit,
                                                                           OpeningBalance = c.OpeningBalance,
                                                                           //Name = c.OwnerName,
                                                                           CompanyType = c.CompanyType,
                                                                           CompanyName = Entities.tblSysBranches.Where(o => o.BranchID == c.BranchID).FirstOrDefault().Name,
                                                                       }).ToList();

                        return customerCreationList;
                    }
                }
            }
            catch (Exception ex)
            {

                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.ToString();
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }

        //Get Customer List for admin portal
        public List<CustomerCreation> GetCustomerList(CustomerCreation search)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();
                    //Get Tally User ID
                    int TallyUserID = Entities.tblSysUsers.Where(s => s.FName.ToLower().Contains("admin") && s.OrgID == search.OrgID).FirstOrDefault().UserID;
                    List<CustomerCreation> customerCreationList = new List<CustomerCreation>();

                    IQueryable<CustomerCreation> QueryableList = (from c in Entities.tblCustomerVendorDetails
                                                                  where c.OrgID == search.OrgID
                                                                  select new CustomerCreation
                                                                  {
                                                                      CustID = c.CustID,
                                                                      OrgID = c.OrgID,
                                                                      BranchID = c.BranchID,
                                                                      FirmName = c.FirmName,
                                                                      CustomerType = c.CustomerTypeID == null ? "" : Entities.tblCustomerTypes.Where(ct => ct.CustomerTypeID == c.CustomerTypeID).FirstOrDefault().CustomerType,
                                                                      AliasName = c.AliasName,
                                                                      BillingState = c.BillingState,
                                                                      BillingCity = c.BillingCity,
                                                                      LedgerType = c.LedgerType,
                                                                      MobileNumber = c.MobileNumber,
                                                                      StateID = c.StateID == null ? 0 : c.StateID.Value,
                                                                      CityID = c.CityID == null ? 0 : c.CityID,
                                                                      CreatedByID = c.CreatedByID,
                                                                      ModifiedByID = c.ModifiedByID == null ? 0 : c.ModifiedByID,
                                                                      CreationDate = c.CreationDate,
                                                                      UpdatedDate = c.UpdatedDate == null ? new DateTime() : c.UpdatedDate,
                                                                      BillingArea = string.IsNullOrEmpty(c.BillingArea) == true ? "" : c.BillingArea,
                                                                      EmailID = c.EmailID,
                                                                      RegistrationType = c.RegistrationType,
                                                                      TypeofCategory = c.TypeofCategory,
                                                                      Name = c.OwnerName,
                                                                      CompanyType = c.CompanyType,
                                                                      SalesManID = c.SalesManID,
                                                                      CreatedStr = c.CreatedByID == 0 ? string.Empty : (Entities.tblSysUsers.Where(s => s.UserID == c.CreatedByID).FirstOrDefault().FName),
                                                                      UpdatedStr = c.ModifiedByID == null ? string.Empty : (Entities.tblSysUsers.Where(s => s.UserID == c.ModifiedByID).FirstOrDefault().FName),
                                                                      Religion = c.Religion == null ? "" : c.Religion,
                                                                  }).AsQueryable();

                    customerCreationList = QueryableList.ToList();

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

                    if (search.SalesManID != 0)
                    {
                        //salesman id list
                        var customerCreationListSM = customerCreationList.Where(m => m.SalesManID == search.SalesManID).ToList();
                        //created list
                        var customerCreationListCreated = customerCreationList.Where(m => m.CreatedByID == search.SalesManID).ToList();
                        //updated list
                        var customerCreationListUpdated = customerCreationList.Where(m => m.ModifiedByID == search.SalesManID).ToList();

                        customerCreationList = new List<CustomerCreation>();

                        customerCreationList = customerCreationListSM.Union(customerCreationListCreated).Union(customerCreationListUpdated).Distinct().ToList();

                        customerCreationList = customerCreationList.Distinct().ToList();
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

                    if (search.SalesmanList != null && search.SalesmanList.Count() > 0)
                    {
                        customerCreationList = customerCreationList.Where(m => search.SalesmanList.Contains(m.SalesManID.Value)).ToList();
                        if (search.Created == true)
                            customerCreationList = customerCreationList.Where(m => search.SalesmanList.Contains(m.CreatedByID.Value)).ToList();
                        if (search.Updated == true)
                            customerCreationList = customerCreationList.Where(m => search.SalesmanList.Contains(m.ModifiedByID.Value)).ToList();
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
                        if (search.BillingCityList != null && search.BillingCityList.Count() > 0)
                        {
                            search.BillingCityList = search.BillingCityList.Select(b => b.ToLowerInvariant().Trim()).ToArray();
                            UpdatedRecords = UpdatedRecords.Where(c => search.BillingCityList.Contains(c.BillingCity.ToLower().Trim())).ToList();
                        }
                        customerCreationList = new List<CustomerCreation>();
                        customerCreationList = UpdatedRecords;

                    }

                    if (!string.IsNullOrEmpty(search.FromDate) && !string.IsNullOrEmpty(search.ToDate))
                    {
                        DateTime FromDateTime = DateTime.ParseExact(Convert.ToDateTime(search.FromDate).ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        DateTime ToDateTime = DateTime.ParseExact(Convert.ToDateTime(search.ToDate).ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        //customerCreationList = customerCreationList.Where(c => Convert.ToDateTime(c.CreationDate.Value.ToString("yyyy-MM-dd")) >= FromDateTime && Convert.ToDateTime(c.CreationDate.Value.ToString("yyyy-MM-dd")) <= ToDateTime).ToList();

                        //created list
                        var customerCreationListCreated = customerCreationList.Where(c => Convert.ToDateTime(c.CreationDate.ToString("yyyy-MM-dd")) >= FromDateTime && Convert.ToDateTime(c.CreationDate.ToString("yyyy-MM-dd")) <= ToDateTime).ToList();
                        //updated list
                        var customerCreationListUpdated = customerCreationList.Where(c => Convert.ToDateTime(c.UpdatedDate.Value.ToString("yyyy-MM-dd")) >= FromDateTime && Convert.ToDateTime(c.UpdatedDate.Value.ToString("yyyy-MM-dd")) <= ToDateTime).ToList();

                        customerCreationList = new List<CustomerCreation>();

                        customerCreationList = customerCreationListCreated.Union(customerCreationListUpdated).Distinct().ToList();

                        customerCreationList = customerCreationList.Distinct().ToList();
                    }

                    string LedgerType = string.Empty, CustomerType = string.Empty, CompanyType = string.Empty, CategoryType = string.Empty, TaxationType = string.Empty;
                    if (search.LedgerTypeID != null && search.LedgerTypeID != 0)
                    {
                        LedgerType = Entities.tblLedgerTypes.Where(l => l.LedgerTypeID == search.LedgerTypeID).FirstOrDefault().LedgerType;
                        customerCreationList = customerCreationList.Where(m => m.LedgerType == LedgerType).ToList();
                    }
                    if (search.CustomerTypeList != null && search.CustomerTypeList.Count() > 0)
                    {
                        List<tblCustomerType> customerTypes = Entities.tblCustomerTypes.Where(c => search.CustomerTypeList.Contains(c.CustomerTypeID)).ToList();
                        customerCreationList = customerCreationList.Where(m => customerTypes.Any(ct => ct.CustomerType == m.CustomerType)).ToList();
                    }
                    if (search.CompanyTypeList != null && search.CompanyTypeList.Count() > 0)
                    {
                        List<tblCompanyType> companyTypes = Entities.tblCompanyTypes.Where(c => search.CompanyTypeList.Contains(c.CompanyTypeID)).ToList();
                        customerCreationList = customerCreationList.Where(m => companyTypes.Any(ct => ct.CompanyType == m.CompanyType)).ToList();
                    }
                    if (search.CategoryTypeList != null && search.CategoryTypeList.Count() > 0)
                    {
                        List<tblCategoryType> categoryTypes = Entities.tblCategoryTypes.Where(c => search.CategoryTypeList.Contains(c.CategoryTypeID)).ToList();
                        customerCreationList = customerCreationList.Where(m => categoryTypes.Any(ct => ct.CategoryType == m.TypeofCategory)).ToList();
                    }
                    if (search.TaxationTypeList != null && search.TaxationTypeList.Count() > 0)
                    {
                        List<tblTaxationType> taxationTypes = Entities.tblTaxationTypes.Where(c => search.TaxationTypeList.Contains(c.TaxationTypeID)).ToList();
                        customerCreationList = customerCreationList.Where(m => taxationTypes.Any(ct => ct.TaxationType == m.RegistrationType)).ToList();
                    }


                    return customerCreationList;
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.ToString();
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
        public List<CustomerCreation> ImportExcel(List<CustomerCreation> ExcelData, string UserID, string BranchID, string OrgID)
        {
            string CustID = string.Empty;
            List<CustomerCreation> Result = new List<CustomerCreation>();
            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            string BranchName = Entities.tblSysBranches.Where(b => b.BranchID == BranchID && b.OrgID == OrgID).FirstOrDefault().Name.Trim();
            try
            {
                if (ExcelData != null)
                {
                    foreach (var mCustomerVendorCreation in ExcelData)
                    {
                        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                        {
                            string FirmName = string.Empty;
                            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                                Entities.Database.Connection.Open();

                            if (!string.IsNullOrEmpty(mCustomerVendorCreation.FirmName) && !string.IsNullOrEmpty(mCustomerVendorCreation.LedgerName))
                            {
                                int CustCount = Convert.ToInt32(Entities.tblCustomerVendorDetails.Max(e => e.ID));
                                tblCustomerVendorDetail IsValueexists = null;
                                if (!string.IsNullOrEmpty(mCustomerVendorCreation.CustID))
                                {
                                    IsValueexists = Entities.tblCustomerVendorDetails.AsNoTracking().Where(C => C.CustID.Trim() == mCustomerVendorCreation.CustID.Trim() && C.FirmName.ToLower() == mCustomerVendorCreation.FirmName.ToLower() && C.MobileNumber == mCustomerVendorCreation.MobileNumber && C.OrgID == OrgID).FirstOrDefault();

                                    if (IsValueexists != null)
                                        CustID = IsValueexists.CustID;
                                }

                                using (var dbcxtransaction = Entities.Database.BeginTransaction())
                                {
                                    CustomerCreation ResultItem = new CustomerCreation();
                                    try
                                    {
                                        FirmName = mCustomerVendorCreation.FirmName;
                                        lCustomerVendor.OrgID = OrgID;
                                        lCustomerVendor.BranchID = BranchID;
                                        lCustomerVendor.PercStrctureID = mCustomerVendorCreation.PercStrctureID;
                                        lCustomerVendor.RegistrationType = mCustomerVendorCreation.RegistrationType;
                                        lCustomerVendor.FirmName = mCustomerVendorCreation.FirmName;
                                        lCustomerVendor.OwnerName = mCustomerVendorCreation.Name;
                                        lCustomerVendor.CompanyType = mCustomerVendorCreation.CompanyType;
                                        lCustomerVendor.ContactpersonName = mCustomerVendorCreation.ContactpersonName;
                                        lCustomerVendor.ContactpersonPhone = mCustomerVendorCreation.ContactpersonPhone;

                                        lCustomerVendor.ShippingAddress = mCustomerVendorCreation.ShippingAddress;
                                        lCustomerVendor.ShippingArea = mCustomerVendorCreation.ShippingArea;
                                        lCustomerVendor.ShippingCity = mCustomerVendorCreation.ShippingCity;
                                        lCustomerVendor.ShippingCityCode = mCustomerVendorCreation.ShippingCityCode;
                                        lCustomerVendor.ShippingGPSLocation = mCustomerVendorCreation.ShippingGPSLocation;
                                        lCustomerVendor.ShippingLandMark = mCustomerVendorCreation.ShippingLandMark;
                                        lCustomerVendor.ShippingLatitude = mCustomerVendorCreation.ShippingLatitude;
                                        lCustomerVendor.ShippingLongitude = mCustomerVendorCreation.ShippingLongitude;
                                        lCustomerVendor.ShippingPincode = mCustomerVendorCreation.ShippingPincode;
                                        lCustomerVendor.ShippingState = mCustomerVendorCreation.ShippingState;

                                        lCustomerVendor.BillingAddress = mCustomerVendorCreation.BillingAddress;
                                        lCustomerVendor.BillingCity = mCustomerVendorCreation.BillingCity;
                                        lCustomerVendor.BillingCityCode = mCustomerVendorCreation.BillingCityCode;
                                        lCustomerVendor.BillingGPSLocation = mCustomerVendorCreation.BillingGPSLocation;
                                        lCustomerVendor.BillingLandmark = mCustomerVendorCreation.BillingLandmark;
                                        lCustomerVendor.BillingLatitude = mCustomerVendorCreation.BillingLatitude;
                                        lCustomerVendor.BillingLongitude = mCustomerVendorCreation.BillingLongitude;
                                        lCustomerVendor.BillingPincode = mCustomerVendorCreation.BillingPincode;
                                        lCustomerVendor.BillingState = mCustomerVendorCreation.BillingState;
                                        lCustomerVendor.BillingArea = mCustomerVendorCreation.BillingArea;

                                        //lCustomerVendor.PostDatedTransaction = mCustomerVendorCreation.PostDatedTransaction.ToLower() == "Yes" ? true : false; ;
                                        lCustomerVendor.IsTallyUpdated = mCustomerVendorCreation.IsTallyUpdated;

                                        //lCustomerVendor.ActivateIntrest = mCustomerVendorCreation.ActivateIntrest.ToLower() == "Yes" ? true : false; ;
                                        lCustomerVendor.LedgerType = mCustomerVendorCreation.LedgerType;
                                        lCustomerVendor.TelephoneNumber = mCustomerVendorCreation.TelephoneNumber;
                                        lCustomerVendor.MobileNumber = mCustomerVendorCreation.MobileNumber;
                                        lCustomerVendor.AlternateNumber = mCustomerVendorCreation.AlternateNumber;
                                        //lCustomerVendor.TINNumber = mCustomerVendorCreation.GSTNumber;
                                        lCustomerVendor.PANNumber = mCustomerVendorCreation.PANNumber;


                                        lCustomerVendor.EmailID = mCustomerVendorCreation.EmailID;
                                        lCustomerVendor.BankName = mCustomerVendorCreation.BankName;
                                        lCustomerVendor.Religion = mCustomerVendorCreation.Religion;
                                        lCustomerVendor.CustomerType = mCustomerVendorCreation.CustomerTypeID;
                                        lCustomerVendor.TypeofCategory = mCustomerVendorCreation.TypeofCategory;


                                        lCustomerVendor.BankBranch = mCustomerVendorCreation.BankBranch;
                                        lCustomerVendor.BankCity = mCustomerVendorCreation.BankCity;
                                        lCustomerVendor.AccountNumber = mCustomerVendorCreation.AccountNumber;
                                        lCustomerVendor.IFSCCode = mCustomerVendorCreation.IFSCCode;
                                        lCustomerVendor.InsuranceCompany = mCustomerVendorCreation.InsuranceCompany;
                                        lCustomerVendor.InsuranceNumber = mCustomerVendorCreation.InsuranceNumber;
                                        lCustomerVendor.InsuranceExpiryDate = null;

                                        if (mCustomerVendorCreation.BillingState != null && mCustomerVendorCreation.BillingState != "")
                                            lCustomerVendor.StateID = Entities.tblStates.Where(s => s.StateName.ToLower() == mCustomerVendorCreation.BillingState.ToLower()).FirstOrDefault().StateID;

                                        if (mCustomerVendorCreation.BillingCity != null && mCustomerVendorCreation.BillingCity != "")
                                            lCustomerVendor.CityID = Entities.tblStateWithCities.Where(s => s.VillageLocalityname.ToLower() == mCustomerVendorCreation.BillingCity.ToLower()).FirstOrDefault().StatewithCityID;

                                        lCustomerVendor.SalesManID = mCustomerVendorCreation.SalesManID;
                                        lCustomerVendor.ApprovalStatus = mCustomerVendorCreation.ApprovalStatus;
                                        lCustomerVendor.SourceOfUpdate = mCustomerVendorCreation.SourceOfUpdate;
                                        lCustomerVendor.IsRemoved = mCustomerVendorCreation.IsRemoved;

                                        lCustomerVendor.AliasName = mCustomerVendorCreation.AliasName;
                                        lCustomerVendor.AadhaarNumber = mCustomerVendorCreation.AadhaarNumber;
                                        lCustomerVendor.WeekOffDay = mCustomerVendorCreation.WeekOffDay;

                                        //images not uploading
                                        //lCustomerVendor.GSTPhoto = mCustomerVendorCreation.GSTPhoto;
                                        //lCustomerVendor.AadhaarPhoto = mCustomerVendorCreation.AadhaarPhoto;
                                        //lCustomerVendor.OwnerPhoto = mCustomerVendorCreation.OwnerPhoto;
                                        //lCustomerVendor.PANPhoto = mCustomerVendorCreation.PANPhoto;
                                        //lCustomerVendor.ShopImage = mCustomerVendorCreation.ShopImage;

                                        if (!string.IsNullOrEmpty(mCustomerVendorCreation.LedgerType))
                                            lCustomerVendor.LedgerTypeID = Entities.tblLedgerTypes.Where(l => l.LedgerType.ToLower() == mCustomerVendorCreation.LedgerType.ToLower()).FirstOrDefault().LedgerTypeID;

                                        if (!string.IsNullOrEmpty(mCustomerVendorCreation.CustomerType))
                                            lCustomerVendor.CustomerTypeID = Entities.tblCustomerTypes.Where(l => l.CustomerType.ToLower() == mCustomerVendorCreation.CustomerType.ToLower()).FirstOrDefault().CustomerTypeID;

                                        if (!string.IsNullOrEmpty(mCustomerVendorCreation.CompanyType))
                                            lCustomerVendor.CompanyTypeID = Entities.tblCompanyTypes.Where(l => l.CompanyType.ToLower() == mCustomerVendorCreation.CompanyType.ToLower()).FirstOrDefault().CompanyTypeID;

                                        if (!string.IsNullOrEmpty(mCustomerVendorCreation.TypeofCategory))
                                            lCustomerVendor.CategoryTypeID = Entities.tblCategoryTypes.Where(l => l.CategoryType.ToLower() == mCustomerVendorCreation.TypeofCategory.ToLower()).FirstOrDefault().CategoryTypeID;

                                        if (!string.IsNullOrEmpty(mCustomerVendorCreation.RegistrationType))
                                            lCustomerVendor.TaxationTypeID = Entities.tblTaxationTypes.Where(l => l.TaxationType.ToLower() == mCustomerVendorCreation.RegistrationType.ToLower()).FirstOrDefault().TaxationTypeID;

                                        lCustomerVendor.FaxNo = mCustomerVendorCreation.FaxNo;
                                        lCustomerVendor.CCEmail = mCustomerVendorCreation.CCEmail;
                                        lCustomerVendor.Website = mCustomerVendorCreation.Website;
                                        lCustomerVendor.BillWiseYesNo = mCustomerVendorCreation.BillWiseYesNo;
                                        lCustomerVendor.Checkforcreditdaysduringvoucherentry = mCustomerVendorCreation.Checkforcreditdaysduringvoucherentry;
                                        lCustomerVendor.OverrideCreditlimit = mCustomerVendorCreation.OverrideCreditlimit;
                                        lCustomerVendor.Inventoryvaluesareaffected = mCustomerVendorCreation.Inventoryvaluesareaffected;
                                        lCustomerVendor.ActivateInterestCalculation = mCustomerVendorCreation.ActivateInterestCalculation;
                                        lCustomerVendor.CalculateInterestTransaction_by_Transaction = mCustomerVendorCreation.CalculateInterestTransaction_by_Transaction;
                                        lCustomerVendor.OverrideCreditlimit = mCustomerVendorCreation.OverrideCreditlimit;
                                        //lCustomerVendor.PostDatedTransaction = mCustomerVendorCreation.PostDatedTransaction.ToLower() == "Yes" ? true : false;
                                        lCustomerVendor.AlternateNumber = mCustomerVendorCreation.AlternateNumber;
                                        lCustomerVendor.Parent1 = mCustomerVendorCreation.Parent1;
                                        lCustomerVendor.Parent2 = mCustomerVendorCreation.Parent2;
                                        lCustomerVendor.Parent3 = mCustomerVendorCreation.Parent3;
                                        lCustomerVendor.Parent4 = mCustomerVendorCreation.Parent4;
                                        lCustomerVendor.ParentDebtorID = mCustomerVendorCreation.ParentDebtorID;
                                        lCustomerVendor.Country = mCustomerVendorCreation.Country;
                                        lCustomerVendor.CrLimit = mCustomerVendorCreation.CrDays;
                                        lCustomerVendor.CrDays = mCustomerVendorCreation.CrLimit;
                                        lCustomerVendor.OverrideParametersforeachtransaction = mCustomerVendorCreation.OverrideParametersforeachtransaction;
                                        lCustomerVendor.IntrestRate = mCustomerVendorCreation.IntrestRate;
                                        lCustomerVendor.InterestDays = mCustomerVendorCreation.InterestDays;
                                        lCustomerVendor.OpeningBalance = mCustomerVendorCreation.OpeningBalance;
                                        lCustomerVendor.NoofOutstandingBill = mCustomerVendorCreation.NoofOutstandingBill;
                                        lCustomerVendor.LedgerName = mCustomerVendorCreation.LedgerName;
                                        lCustomerVendor.IsVendor = mCustomerVendorCreation.IsVendor;
                                        lCustomerVendor.IsActive = mCustomerVendorCreation.IsActive;
                                        lCustomerVendor.CreatedByID = Convert.ToInt32(UserID);
                                        lCustomerVendor.CreationDate = DateTimeNow;

                                        if (string.IsNullOrEmpty(CustID))
                                            CustID = "0";
                                        lCustomerVendor.CustID = (CustCount + 1).ToString();
                                        Entities.tblCustomerVendorDetails.Add(lCustomerVendor);
                                        Entities.SaveChanges();
                                        dbcxtransaction.Commit();
                                    }
                                    catch (Exception ex)
                                    {
                                        ResultItem.FirmName = FirmName;
                                        ResultItem.DisplayMessage = ex.Message;
                                        Result.Add(ResultItem);
                                        dbcxtransaction.Rollback();
                                        this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                        this.GetApplicationActivate.GetErrormessages = ex.Message;
                                        this.GetApplicationActivate.GetErrorSource = ex.Source;
                                        this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                        CustID = "0";
                                        //throw;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                CustID = "0";
                //throw;
            }
            return Result;
        }

        class DistrictComparer : IEqualityComparer<District>
        {
            public bool Equals(District x, District y)
            {
                return x.DistrictID == y.DistrictID;
            }

            // If Equals() returns true for a pair of objects 
            // then GetHashCode() must return the same value for these objects.

            public int GetHashCode(District myModel)
            {
                return myModel.DistrictID.GetHashCode();
            }
        }
    }
}
