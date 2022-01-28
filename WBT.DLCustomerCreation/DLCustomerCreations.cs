using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WBT.Accounts.Entity;
using WBT.Common;
using WBT.DL.Transaction;
using WBT.Entity;

namespace WBT.DL.CCAplusSO
{
    public class CustomerCreation
    {
        public int ID { get; set; }
        public string CustID { get; set; }
        public string OrgID { get; set; }
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
        public string ActivateIntrest { get; set; }
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
        //public string InsuranceExpiryDate { get; set; }
        public Nullable<System.DateTime> InsuranceExpiryDate { get; set; }
        public Nullable<bool> IsVendor { get; set; }
        public Nullable<int> SalesManID { get; set; }
        public string ApprovalStatus { get; set; }
        public string SourceOfUpdate { get; set; }
        public string IsRemoved { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Religion { get; set; }
        public string OwnerPhoto { get; set; }
        //public string CustomerType { get; set; }
        public Nullable<int> CustomerType { get; set; }

        public string AadhaarNumber { get; set; }
        public string AadhaarPhoto { get; set; }
        public string TypeofCategory { get; set; }
        public Nullable<int> ParentDebtorID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CityID { get; set; }

        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
        public string Remark { get; set; }
        public string DisplayMessage { get; set; }
        public string CompanyName { get; set; }
        public string WeekOffDay { get; set; }

        public int[] StateList { get; set; }
        public int[] CityList { get; set; }
        public string[] AreaList { get; set; }
        public int[] CustomerTypeList { get; set; }
        public int[] CompanyTypeList { get; set; }
        public int[] CategoryTypeList { get; set; }
        public int[] TaxationTypeList { get; set; }
        public int[] SalesmanList { get; set; }
        public int[] BranchList { get; set; }
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
        public string CreatedStr { get; set; }
        public string UpdatedStr { get; set; }

        public string WatsAppNumber { get; set; }
        public string OldTallyFirmName { get; set; }
        public string TINNumber { get; set; }
        public string OwnerName { get; set; }
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

    public class ReceiptListForApp
    {
        public int ID { get; set; }
        public string ReceiptID { get; set; }
        public string CustID { get; set; }
        public string Date { get; set; }
        public string CustomerName { get; set; }
       // public string ReceiptNo { get; set; }
        public string Amount { get; set; }
        public string BankOrCash { get; set; }
        public string PaymentType { get; set; }
        public List<DLReceiptsBillDetailsCreation> ListReceiptWithBillDetail { get; set; }
        //public string MobileNumber { get; set; }

    }
    public class DLReceiptsBillDetailsCreation
    {
        public string Refvalue { get; set; }
        public string CustomerName { get; set; }
        public System.Guid ReceiptWithBillID { get; set; }
        public string ReceiptID { get; set; }
        public string CustID { get; set; }
        public string OrgID { get; set; }
        private string mBillType;
        //public string BillType
        //{
        //    get
        //    {
        //        return mBillType;
        //    }
        //    set
        //    {
        //        BillType1 = (Common.ModeOfPayments)Enum.Parse(typeof(Common.ModeOfPayments), value);
        //        mBillType = value;
        //    }
        //}
        //public WBT.Common.ModeOfPayments BillType1
        //{
        //    get;
        //    set;
        //}
        public string BillNo { get; set; }
        public string OwnerName { get; set; }
        public string Billdatetime { get; set; }
        public string TallyAmount { get; set; }
        public string Discountamount { get; set; }
        public decimal? Billamount { get; set; }
        public string IsSalesOrderAddTally { get; set; }
        public string SourceOfUpdate { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string LedgerName { get; set; }
        public string OutstandingAmt { get; set; }
        public bool IsEdit { get; set; }

        //if he pay full amount for the respective bill then si item level status set as C
        public string StatusForSi { get; set; }
        public string Name { get; set; }
        public string BillType { get; set; }
    }



    public class CustomerID
    {
        public string CustID { get; set; }
        public int OrgID { get; set; }
        public int ModifiedByID { get; set; }
        public string UpdateStatus { get; set; }
        public int StatusCode { get; set; }
    }

    public class UserLogin
    {
        public int UserId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string OrgID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string OrgName { get; set; }
        public string Message { get; set; }
    }



    public class CustomerCreations : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        private WBT.Entity.tblCustomerVendorDetail lCustomerVendor = new WBT.Entity.tblCustomerVendorDetail();
        private List<Entity.tblCustomerVendorDetail> lstCustomerCreation = new List<Entity.tblCustomerVendorDetail>();
        private CustomerCreation mCustomerVendorCreation = new CustomerCreation();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<Entity.tblCustomerVendorDetail> CUstomerCreation
        {
            get { return lstCustomerCreation; }
            set { lstCustomerCreation = value; }
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
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
                throw;
            }
        }



        public CustomerID SaveData(object Context)
        {
            DLCustomerVendorDetailCreation mCustomerVendorCreation = ((DLCustomerVendorDetailCreation)Context);
            //mCustomerVendorCreation = ((CustomerCreation)Context);
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

                    Entity.tblCustomerVendorDetail IsValueexists = null;

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
                            lCustomerVendor.ID = mCustomerVendorCreation.ID;
                            lCustomerVendor.OrgID = mCustomerVendorCreation.OrgID;
                            lCustomerVendor.PercStrctureID = mCustomerVendorCreation.PercStrctureID;
                            lCustomerVendor.RegistrationType = mCustomerVendorCreation.RegistrationType;
                            lCustomerVendor.FirmName = mCustomerVendorCreation.FirmName;
                            lCustomerVendor.ContactpersonName = this.mCustomerVendorCreation.Name;
                            lCustomerVendor.CompanyType = mCustomerVendorCreation.CompanyType;
                            lCustomerVendor.ContactpersonName = this.mCustomerVendorCreation.ContactpersonName;
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


                            lCustomerVendor.IsTallyUpdated = mCustomerVendorCreation.IsTallyUpdated;


                            lCustomerVendor.LedgerType = mCustomerVendorCreation.LedgerType;
                            lCustomerVendor.TelephoneNumber = mCustomerVendorCreation.TelephoneNumber;
                            lCustomerVendor.MobileNumber = mCustomerVendorCreation.MobileNumber;
                            lCustomerVendor.AlternateNumber = mCustomerVendorCreation.AlternateNumber;
                            lCustomerVendor.TINNumber = mCustomerVendorCreation.GSTNumber; //need to add in table
                            lCustomerVendor.PANNumber = mCustomerVendorCreation.PANNumber;
                            lCustomerVendor.ContactpersonName = mCustomerVendorCreation.ContactPersonName;


                            lCustomerVendor.EmailID = mCustomerVendorCreation.EmailID;
                            lCustomerVendor.BankName = mCustomerVendorCreation.BankName;
                            lCustomerVendor.Religion = mCustomerVendorCreation.Religion;
                            lCustomerVendor.CustomerType = mCustomerVendorCreation.CustomerType;
                            lCustomerVendor.TypeofCategory = mCustomerVendorCreation.TypeofCategory;


                            lCustomerVendor.BankBranch = mCustomerVendorCreation.BankBranch;
                            lCustomerVendor.BankCity = mCustomerVendorCreation.BankCity;
                            lCustomerVendor.AccountNumber = mCustomerVendorCreation.AccountNumber;
                            lCustomerVendor.IFSCCode = mCustomerVendorCreation.IFSCCode;
                            lCustomerVendor.InsuranceCompany = mCustomerVendorCreation.InsuranceCompany;
                            lCustomerVendor.InsuranceNumber = mCustomerVendorCreation.InsuranceNumber;
                            lCustomerVendor.InsuranceExpiryDate = mCustomerVendorCreation.InsuranceExpiryDate;
                            lCustomerVendor.StateID = mCustomerVendorCreation.StateID;
                            lCustomerVendor.CityID = mCustomerVendorCreation.CityID;

                            lCustomerVendor.SalesManID = mCustomerVendorCreation.SalesManID;
                            lCustomerVendor.ApprovalStatus = mCustomerVendorCreation.ApprovalStatus;
                            lCustomerVendor.SourceOfUpdate = mCustomerVendorCreation.SourceOfUpdate;
                            lCustomerVendor.IsRemoved = mCustomerVendorCreation.IsRemoved;

                            lCustomerVendor.AliasName = mCustomerVendorCreation.AliasName;
                            lCustomerVendor.AadhaarNumber = mCustomerVendorCreation.AadhaarNumber;
                            lCustomerVendor.WeekOffDay = mCustomerVendorCreation.WeekOffDay;
                            //lCustomerVendor.OwnerName = mCustomerVendorCreation.OwnerName;
                           

                            //images
                            lCustomerVendor.GSTPhoto = mCustomerVendorCreation.GSTPhoto;
                            lCustomerVendor.AadhaarPhoto = mCustomerVendorCreation.AadhaarPhoto;
                            lCustomerVendor.OwnerPhoto = mCustomerVendorCreation.OwnerPhoto;
                            lCustomerVendor.PANPhoto = mCustomerVendorCreation.PANPhoto;
                            lCustomerVendor.ShopImage = mCustomerVendorCreation.ShopImage;

                            //lCustomerVendor.LedgerTypeID = mCustomerVendorCreation.LedgerTypeID;
                            //lCustomerVendor.CustomerTypeID = mCustomerVendorCreation.CustomerTypeID;
                            //lCustomerVendor.CompanyTypeID = mCustomerVendorCreation.CompanyTypeID;
                            //lCustomerVendor.CategoryTypeID = mCustomerVendorCreation.CategoryTypeID;
                            //lCustomerVendor.TaxationTypeID = mCustomerVendorCreation.TaxationTypeID;

                            //lCustomerVendor.WatsAppNumber = mCustomerVendorCreation.WatsAppNumber;
                            //lCustomerVendor.BranchID = mCustomerVendorCreation.BranchID;

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
                                lCustomerVendor.CustomerType = IsValueexists.CustomerType;
                                lCustomerVendor.OwnerName = IsValueexists.OwnerName;
                                lCustomerVendor.CustID = CustID;
                                lCustomerVendor.ModifiedByID = IsValueexists.ModifiedByID;
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
                                lCustomerVendor.CreatedByID = (int)mCustomerVendorCreation.CreatedByID;
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
                            //Helper.LogError(ex.InnerException.ToString(), null, null, false);
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

            //customerID.CustID = Convert.ToInt32(CustID);
            customerID.CustID = CustID;
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
                                                                           CustomerType = c.CustomerType,
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
                                                                           ActivateIntrest = c.ActivateIntrest == true ? "Yes" : "No",
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
                                                                           InsuranceExpiryDate = c.InsuranceExpiryDate,
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
                                                                           //  GSTNumber = c.GSTNumber,    need to add in table
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
                                                                           Name = c.ContactpersonName,
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


                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                            Entities.Database.Connection.Open();
                        Entity.tblCustomerVendorDetail tblCustomerVendorDetail = Entities.tblCustomerVendorDetails.AsNoTracking().Where(c => c.CustID == CustID.Trim()).FirstOrDefault();
                        SCustomerCreation.CustID = tblCustomerVendorDetail.CustID;
                        SCustomerCreation.OrgID = tblCustomerVendorDetail.OrgID;
                        SCustomerCreation.PercStrctureID = tblCustomerVendorDetail.PercStrctureID;
                        SCustomerCreation.FirmName = tblCustomerVendorDetail.FirmName;
                        SCustomerCreation.CustomerType = tblCustomerVendorDetail.CustomerType;
                        SCustomerCreation.AliasName = tblCustomerVendorDetail.AliasName;
                        SCustomerCreation.OwnerName = tblCustomerVendorDetail.OwnerName;

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

                        SCustomerCreation.AccountNumber = tblCustomerVendorDetail.AccountNumber;
                        SCustomerCreation.BankBranch = tblCustomerVendorDetail.BankBranch;
                        SCustomerCreation.BankCity = tblCustomerVendorDetail.BankCity;
                        SCustomerCreation.BankName = tblCustomerVendorDetail.BankName;
                        SCustomerCreation.IFSCCode = tblCustomerVendorDetail.IFSCCode;
                        SCustomerCreation.Country = tblCustomerVendorDetail.Country;
                        SCustomerCreation.StateID = !string.IsNullOrEmpty(tblCustomerVendorDetail.BillingState) ? Entities.tblStates.Where(st => st.StateName.ToLower() == tblCustomerVendorDetail.BillingState.ToLower()).FirstOrDefault().StateID : 0;
                        SCustomerCreation.CityID = tblCustomerVendorDetail.CityID;

                        SCustomerCreation.InsuranceNumber = tblCustomerVendorDetail.InsuranceNumber;
                        SCustomerCreation.InsuranceCompany = tblCustomerVendorDetail.InsuranceCompany;
                        SCustomerCreation.InsuranceExpiryDate = tblCustomerVendorDetail.InsuranceExpiryDate;
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
                        //SCustomerCreation.GSTNumber = tblCustomerVendorDetail.gs;
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
                        SCustomerCreation.WatsAppNumber = tblCustomerVendorDetail.WatsAppNumber;
                        SCustomerCreation.OldTallyFirmName = tblCustomerVendorDetail.OldTallyFirmName;
                        SCustomerCreation.TINNumber = tblCustomerVendorDetail.TINNumber;
                       

                        //if (tblCustomerVendorDetail.CreatedByID != null && tblCustomerVendorDetail.CreatedByID != 0)
                        //   SCustomerCreation.CreatedByName = Entities.Users.Where(s => s.UserID == tblCustomerVendorDetail.CreatedByID).FirstOrDefault().Username;
                        //if (tblCustomerVendorDetail.ModifiedByID != null && tblCustomerVendorDetail.ModifiedByID != 0)
                        //   SCustomerCreation.UpdatedByName = Entities.Users.Where(s => s.UserID == tblCustomerVendorDetail.ModifiedByID).FirstOrDefault().Username;

                        SCustomerCreation.CrDays = tblCustomerVendorDetail.CrDays;
                        SCustomerCreation.CrLimit = tblCustomerVendorDetail.CrLimit;
                        SCustomerCreation.OpeningBalance = tblCustomerVendorDetail.OpeningBalance;
                        // SCustomerCreation.Name = tblCustomerVendorDetail.Name;
                        SCustomerCreation.CompanyType = tblCustomerVendorDetail.CompanyType;
                        // SCustomerCreation.CompanyName = Entities.tblSysOrganizations.Where(o => o.OrgID == tblCustomerVendorDetail.OrgID).FirstOrDefault().Name;
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


        //public object GetCustomerOrderDetailsKYC(string CustomerID)
        //{
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            List<DLSalesOrderCreation> Result = (from so in Entities.SalesOrders
        //                                                 join SoItem in Entities.SalesOrderWithItems on so.SalesOrderNumber equals SoItem.SalesOrderNumber
        //                                                 where so.CustID.ToLower().Trim().Equals(CustomerID.ToLower().Trim())
        //                                                 select new DLSalesOrderCreation
        //                                                 {
        //                                                     TotalAmount = SoItem.Value,
        //                                                     TotalItemCount = so.TotalItemCount,
        //                                                     CreditTypeValue = (from i in Entities.CustomerVendorDetails join j in Entities.CreditTypeMarginDetails on i.CreditType equals j.CreditTypeID select j.CreditDays).FirstOrDefault(),
        //                                                     SalesDatetime = so.SalesDatetime,
        //                                                 }).ToList();

        //            Result = Result.GroupBy(ac => new
        //            {
        //                ac.SalesOrderNumber
        //            }).Select(g => new DLSalesOrderCreation
        //            {
        //                TotalAmount = g.Sum(i => i.TotalAmount),
        //                TotalItemCount = g.Select(i => i.TotalItemCount).FirstOrDefault(),
        //                CreditTypeValue = g.Select(i => i.CreditTypeValue).FirstOrDefault(),
        //                SalesDatetime = g.Select(i => i.SalesDatetime).FirstOrDefault(),
        //            }).ToList();

        //            Result = Result.OrderByDescending(i => i.SalesDatetime).Take(1).ToList();

        //            return Result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.GetApplicationActivate.DataState = Common.TransactionType.Error;
        //        this.GetApplicationActivate.GetErrormessages = ex.Message;
        //        this.GetApplicationActivate.GetErrorSource = ex.Source;
        //        this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
        //        throw;
        //    }
        //}



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
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.InnerException.ToString();
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }


        //GetCities
        public List<tblStateWithCity> GetCities(int StateID, string cityName)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblStateWithCity> cityList = new List<tblStateWithCity>();
                        cityList = (from s in Entities.tblStateWithCities
                                    where s.StateID == StateID && s.VillageLocalityname.Contains(cityName)
                                    select s).ToList();

                        return cityList;
                    }
                }
            }
            catch (Exception ex)
            {
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
                return null;
            }
        }


        //Login for App User
        //public UserLogin LoginAppUser(UserLogin userLogin)
        public UserLogin LoginAppUser(String MobileNumber, string Password, string UserName)
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
                                                  where ((s.Mobile == MobileNumber || s.Username.ToLower().Trim() == UserName.ToLower().Trim()))
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

                            if (Password == ValidateUser.Password)
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
                //Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                //Helper.LogError(ex.InnerException);
                return null;
            }
        }
                

        //public object GetCustomerOrderDetailsKYC(string CustomerID)
        //{
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTechnologyEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            List<DLSalesOrderCreation> Result = (from so in Entities.SalesOrders
        //                                                 where so.CustID.ToLower().Trim().Equals(CustomerID.ToLower().Trim())
        //                                                 select new DLSalesOrderCreation
        //                                                 {
        //                                                     //ItemCode = SIItem.ItemCode,
        //                                                     //ItemName = Item.Alias.Trim(),
        //                                                     //CustID = si.CustID,
        //                                                     //CategoryID = Item.CategoryID,
        //                                                     //Quantity = SIItem.Quantity,
        //                                                     //CategoryName = cateory.CategoryName,
        //                                                     CreationDate = so.CreationDate,
        //                                                     //TotalAmount = so.InvoiceTotal.Value,
        //                                                     VisitedDate = so.CreationDate,
        //                                                     //SalesDatetime = so.tblSalesOrder.CreationDate.ToString(),
        //                                                 }).OrderByDescending(j => j.SalesDatetime).Take(1).ToList();

        //            return Result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.GetApplicationActivate.DataState = Common.TransactionType.Error;
        //        this.GetApplicationActivate.GetErrormessages = ex.Message;
        //        this.GetApplicationActivate.GetErrorSource = ex.Source;
        //        this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
        //        throw;
        //    }
        //}
                          
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
                        //List<CustomerListForApp> customerCreationList = (from c in Entities.CustomerVendorDetails
                        //                                                 where c.OrgID == OrgID
                        //                                                 select new CustomerListForApp
                        //                                                 {
                        //                                                     CustID = c.CustID,
                        //                                                     OrgID = c.OrgID,
                        //                                                     FirmName = c.FirmName,
                        //                                                     CustomerType = c.CustomerType.ToString(),
                        //                                                     MobileNumber = c.MobileNumber,
                        //                                                 }).Take(100).ToList();
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
    
        public string GetPOSequenceNumber()
        {
            string newPoNumber = null;
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    int CustCount = 0;

                    if (Entities.tblAccountReceiptDetails.Count() > 0)
                    {
                        CustCount = Convert.ToInt32(Entities.tblAccountReceiptDetails.Max(e => e.ID));
                    }


                     newPoNumber = "R"+(CustCount + 1).ToString();

                //    var receiptNumber = Entities.tblAccountReceiptDetails.AsNoTracking().OrderByDescending(record => record.CreationDate).Take(1).FirstOrDefault();
                //    Helper.TransactionLog(receiptNumber.ToString(), true);
                //    if (receiptNumber != null)
                //    {
                //        string lastPoNumber = receiptNumber.ReceiptID;
                //        if (!string.IsNullOrEmpty(lastPoNumber))
                //        {
                //            int referencenumber = Convert.ToInt32(lastPoNumber.Substring(1, 8));
                //            newPoNumber = (referencenumber + 1).ToString().PadLeft(8, '0');
                //        }
                //    }
                //    else
                //    {
                //        newPoNumber = "00000001";
                //    }
                }
                Helper.TransactionLog(newPoNumber, true);
                return newPoNumber;
            }
            catch (Exception GeneralException)
            {
                //Helper.LogError(GeneralException.Message, GeneralException.Source, GeneralException.StackTrace);
                throw GeneralException;
            }
        }

        //public List<ReceiptListForApp> GetReceiptList(int createdID)
        //{
        //    try
        //    {
        //        using (MWBAccountsEntity Entities = new MWBAccountsEntity())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            using (var dbcxtransaction = Entities.Database.BeginTransaction())
        //            {
        //                List<ReceiptListForApp> customerCreationList = (from c in Entities.AccountReceiptDetails
        //                                                                where c.CreatedByID == createdID
        //                                                                select new ReceiptListForApp
        //                                                                {
        //                                                                    ReceiptID = c.ReceiptID,
        //                                                                    Date = c.ReceiptDatetime.ToString(),
        //                                                                    Amount = c.Amount.ToString(),
        //                                                                    BankOrCash = c.BankOrCash,
        //                                                                    PaymentType = c.PaymentType,

        //                                                                    //CustomerName = (from i in Entities.AccountReceiptWithBillDetails join j in Entities.CustomerVendorDetails on i.CustID equals j.CustID where j.CustID == i.CustID select j.FirmName).FirstOrDefault(),

        //                                                                    ListReceiptWithBillDetail = (from i in Entities.AccountReceiptWithBillDetails
        //                                                                                                 where i.ReceiptID == c.ReceiptID
        //                                                                                                 select new DLReceiptsBillDetailsCreation
        //                                                                                                 {
        //                                                                                                     CustID=i.CustID,
        //                                                                                                     CustomerName=Entities.CustomerVendorDetails.Where(g=>g.CustID==i.CustID).FirstOrDefault().FirmName,
        //                                                                                                     Billamount = i.Billamount,
        //                                                                                                     BillNo = i.BillNo,
        //                                                                                                     ReceiptID = i.ReceiptID,
        //                                                                                                     CreationDate = i.CreationDate,
        //                                                                                                     Discountamount = i.Discountamount.ToString(),
        //                                                                                                     Billdatetime = i.Billdatetime,
        //                                                                                                     TallyAmount = i.TallyAmount.ToString(),
        //                                                                                                     UpdatedDate = i.UpdatedDate,
        //                                                                                                     ModifiedByID = i.ModifiedByID,
        //                                                                                                     SourceOfUpdate = i.SourceOfUpdate,





        //                                                                                                 }).ToList()

        //                                                                }).ToList();
        //                return customerCreationList;
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        this.GetApplicationActivate.DataState = Common.TransactionType.Error;
        //        this.GetApplicationActivate.GetErrormessages = ex.InnerException.ToString();
        //        this.GetApplicationActivate.GetErrorSource = ex.Source;
        //        this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
        //        throw;
        //    }
        //}
        ////public List<ReceiptListForApp> GetReceiptList(int createdID)
        ////{
        ////    try
        ////    {
        ////        using (MWBAccountsEntity Entities = new MWBAccountsEntity())
        ////        {
        ////            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        ////                Entities.Database.Connection.Open();

        ////            using (var dbcxtransaction = Entities.Database.BeginTransaction())
        ////            {
        ////                List<ReceiptListForApp> customerCreationList = (from c in Entities.AccountReceiptDetails
        ////                                                                where c.CreatedByID == createdID
        ////                                                                select new ReceiptListForApp
        ////                                                                {
        ////                                                                    ReceiptID = c.ReceiptID,
        ////                                                                    Date = c.ReceiptDatetime.ToString(),
        ////                                                                    Amount = c.Amount.ToString(),
        ////                                                                    BankOrCash = c.BankOrCash,
        ////                                                                    PaymentType = c.PaymentType,
        ////                                                                    CustID=Entities.AccountReceiptWithBillDetails.Where(i=>i.ReceiptID==c.ReceiptID).().CustID,
        ////                                                                    CustomerName = (from i in Entities.AccountReceiptWithBillDetails join j in Entities.CustomerVendorDetails on i.CustID equals j.CustID where j.CustID == i.CustID select j.FirmName).FirstOrDefault(),


        ////                                                                    ListReceiptWithBillDetail = (from i in Entities.AccountReceiptWithBillDetails
        ////                                                                                                 where i.ReceiptID == c.ReceiptID
        ////                                                                                                 select new ReceiptWithBillDetail
        ////                                                                                                 {                                                                                                             
        ////                                                                                                     billamount = i.Billamount.ToString(),
        ////                                                                                                     billNo = i.BillNo,
        ////                                                                                                     ReceiptID = i.ReceiptID,
        ////                                                                                                     CreationDate = i.CreationDate,
        ////                                                                                                     discountamount = i.Discountamount.ToString(),
        ////                                                                                                     billdatetime = i.Billdatetime,
        ////                                                                                                     TallyAmount = i.TallyAmount.ToString(),
        ////                                                                                                     UpdatedDate = i.UpdatedDate,
        ////                                                                                                     ModifiedByID = i.ModifiedByID,
        ////                                                                                                     SourceOfUpdate = i.SourceOfUpdate,





        ////                                                                                                 }).ToList()

        ////                                                                }).ToList();
        ////                return customerCreationList;
        ////            }
        ////        }
        ////    }

        ////    catch (Exception ex)
        ////    {
        ////        this.GetApplicationActivate.DataState = Common.TransactionType.Error;
        ////        this.GetApplicationActivate.GetErrormessages = ex.InnerException.ToString();
        ////        this.GetApplicationActivate.GetErrorSource = ex.Source;
        ////        this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
        ////        throw;
        ////    }
        ////}

        public List<ReceiptListForApp> GetReceiptList(int createdID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<ReceiptListForApp> customerCreationList = (from c in Entities.tblAccountReceiptDetails
                                                                        where c.CreatedByID == createdID
                                                                        select new ReceiptListForApp
                                                                        {
                                                                            ReceiptID = c.ReceiptID,
                                                                            Date = c.ReceiptDatetime.ToString(),
                                                                            Amount = c.Amount.ToString(),
                                                                            BankOrCash = c.BankOrCash,
                                                                            PaymentType = c.PaymentType,

                                                                            //CustomerName = (from i in Entities.AccountReceiptWithBillDetails join j in Entities.CustomerVendorDetails on i.CustID equals j.CustID where j.CustID == i.CustID select j.FirmName).FirstOrDefault(),

                                                                            ListReceiptWithBillDetail = (from i in Entities.tblAccountReceiptWithBillDetails
                                                                                                         where i.ReceiptID == c.ReceiptID
                                                                                                         select new DLReceiptsBillDetailsCreation
                                                                                                         {
                                                                                                             CustID = i.CustID,
                                                                                                             CustomerName = Entities.tblCustomerVendorDetails.Where(g => g.CustID == i.CustID).FirstOrDefault().FirmName,
                                                                                                             Billamount = i.Billamount,
                                                                                                             BillNo = i.BillNo,
                                                                                                             ReceiptID = i.ReceiptID,
                                                                                                             CreationDate = i.CreationDate,
                                                                                                             Discountamount = i.Discountamount.ToString(),
                                                                                                             Billdatetime = i.Billdatetime,
                                                                                                             TallyAmount = i.TallyAmount.ToString(),
                                                                                                             UpdatedDate = i.UpdatedDate,
                                                                                                             ModifiedByID = i.ModifiedByID,
                                                                                                             SourceOfUpdate = i.SourceOfUpdate,





                                                                                                         }).ToList()

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

        public List<tblLedgerType> GetLedgerTypes()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    List<tblLedgerType> ledgerTypes = (from s in Entities.tblLedgerTypes
                                                       select s).ToList();
                    return ledgerTypes;
                }
            }
            catch (Exception GeneralException)
            {
                //Helper.LogError(GeneralException.Message, GeneralException.Source, GeneralException.StackTrace);
                return null;
            }
        }

        public List<tblCustomerType> GetCustomerTypes()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblCustomerType> CustomerTypes = new List<tblCustomerType>();
                        CustomerTypes = (from s in Entities.tblCustomerTypes
                                         select s).ToList();

                        return CustomerTypes;
                    }
                }
            }
            catch (Exception ex)
            {
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
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
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
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
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
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
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
                return null;
            }
        }                     
    }
}
