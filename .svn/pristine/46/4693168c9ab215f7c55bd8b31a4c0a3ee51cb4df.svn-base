using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;
//using PropertyChanged;

namespace WBT.DL.Transaction
{
   // [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class DLCustomerVendorDetailCreation : ApplicationActivate
    {
        #region old data
        //public int ID { get; set; }

        //public string CustID { get; set; }
        //public string OldFirmName { get; set; }
        //[Required]
        //public string ContactPersonName { get; set; }
        //public string CrLimit { get; set; }
        //public string CrDays { get; set; }
        //public Nullable<int> PercStrctureID { get; set; }
        //public Nullable<int> NoofOutstandingBill { get; set; }
        //public string ShippingAddress { get; set; }
        //public string ShippingLandMark { get; set; }
        //public string ShippingGPSLocation { get; set; }
        //[Required]
        //public string BillingAddress { get; set; }
        //public string BillingLandmark { get; set; }
        //public string BillingGPSLocation { get; set; }
        //public string Pincode { get; set; }
        //public string TelephoneNumber { get; set; }
        //public string MobileNumber { get; set; }
        //public string MobileNumber2 { get; set; }
        //[Required]
        //public string TINNumber { get; set; }
        //public string PANNumber { get; set; }
        //public string EmailID { get; set; }
        //public bool IsTallyUpdated { get; set; }
        //public string stringIsTallyUpdated { get; set; }
        //public string IsRemoved { get; set; }
        //public string LedgerName { get; set; }
        //public Nullable<bool> IsVendor { get; set; }
        //public int CreatedByID { get; set; }
        //public DateTime CreationDate { get; set; }
        //public Nullable<int> ModifiedByID { get; set; }
        //public Nullable<System.DateTime> UpdatedDate { get; set; }
        //public string Area { get; set; }
        //[Required]
        //public string FirmName { get; set; }
        //public string City { get; set; }
        //public string CityCode { get; set; }
        //public string CustomerLabel { get; set; }
        //public string SearchText { get; set; }
        //public string ApprovalStatus { get; set; }
        //public string RegistrationType { get; set; }
        //public string State { get; set; }
        //public string Remark { get; set; }
        //public Nullable<bool> ActivateIntrest { get; set; }
        //public Nullable<bool> PostDatedTransaction { get; set; }
        //public decimal OpeningBalance { get; set; }
        //public bool IsSupplierChecked { get; set; }
        //public DLDebtorsPlaceDetailCreation DLDebtorsPlaceDetailCreation { get; set; }
        //public int PercentageValue { get; set; }
        //public string LedgerType { get; set; }
        //public string BankName { get; set; }
        //public string BankBranch { get; set; }
        //public string AccountNo { get; set; }
        //public string IFSCCode { get; set; }
        //public Nullable<bool> IsActive { get; set; }
        //public string PlaceCode { get; set; }
        //public string SourceOfUpdate { get; set; }
        //public string BankCity { get; set; }
        //public string CompanyType { get; set; }
        //public string InsuranceCompany { get; set; }
        //public string InsuranceNumber { get; set; }
        //public Nullable<System.DateTime> InsuranceExpiryDate { get; set; }
        //public string OrgID { get; set; }
        #endregion

        #region
        public int SalesmanID { get; set; }
        public bool IsSupplierChecked { get; set; }
        public string OldFirmName { get; set; }
        public string stringIsTallyUpdated { get; set; }
        public string CustomerLabel { get; set; }
        public string SearchText { get; set; }
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
        public decimal OpeningBalance { get; set; }
        public string ContactPersonName { get; set; }
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
        public Nullable<bool> PostDatedTransaction { get; set; }
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
        public int? CustomerType { get; set; }
        public string AadhaarNumber { get; set; }
        public string AadhaarPhoto { get; set; }
        public string TypeofCategory { get; set; }
        public Nullable<int> ParentDebtorID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> CityID { get; set; }

        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
        public string Remark { get; set; }
        //public string DisplayMessage { get; set; }
        public string CompanyName { get; set; }
        public string WeekOffDay { get; set; }
        public Nullable<int> CreditTypeId { get; set; }

        public string CreditTypeName { get; set; }
        public string BusinessTypeName { get; set; }
        //used while creating Customer data in Customer vendor table and mapping item in item supplier table
        public List<DLItemSupplierMapCreation> dLItemSupplierMapCreations { get; set; }
        #endregion

    }
    public class DLCustomerVendorDetail : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private tblCustomerVendorDetail lCustomerVendor = new tblCustomerVendorDetail();
        private List<DLCustomerVendorDetailCreation> lstCustomerCreation = new List<DLCustomerVendorDetailCreation>();
        private DLCustomerVendorDetailCreation mCustomerVendorCreation = new DLCustomerVendorDetailCreation();
        private tblItemSupplierMapping supplierMapping;
        public List<DLCustomerVendorDetailCreation> CUstomerCreation
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
                        DLCustomerVendorDetailCreation Criteria = (DLCustomerVendorDetailCreation)Context;
                        lResult = GetData(Criteria.SearchText, Criteria.IsVendor.Value, Criteria.OrgID);
                        break;
                    case Common.TransactionType.Find:
                        DLCustomerVendorDetailCreation criteria = (DLCustomerVendorDetailCreation)Context;
                        lResult = GetCustomer(criteria.SearchText, criteria.RegistrationType, criteria.OrgID); /**/
                        break;
                    case Common.TransactionType.Save:
                        lResult = SaveData(Context);
                        break;
                    case Common.TransactionType.Edit:
                        lResult = EditData(Context);
                        break;
                    case Common.TransactionType.TallyUpdation:
                        lResult = EditDataTallyColumn(Context);
                        break;
                }
                return lResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private object GetData(string SearchValue, bool IsVendor, string OrgID)
        {
            lstCustomerCreation = new List<DLCustomerVendorDetailCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    #region old

                    //foreach (var drow in from gCustomers in Entities.CustomerVendorDetails.AsNoTracking().ToList()
                    //                     orderby gCustomers.ContactpersonName
                    //                     select gCustomers)
                    //{
                    //    mCustomerVendorCreation = new DLCustomerVendorDetailCreation();
                    //    mCustomerVendorCreation.CustID = drow.CustID;
                    //    mCustomerVendorCreation.EmailID = drow.EmailID == null ? "" : drow.EmailID;
                    //    mCustomerVendorCreation.ShippingAddress = drow.ShippingAddress;
                    //    mCustomerVendorCreation.BillingAddress = drow.BillingAddress == null ? "" : drow.BillingAddress;
                    //    mCustomerVendorCreation.ShippingLandMark = drow.ShippingLandMark == null ? "" : drow.ShippingLandMark;
                    //    mCustomerVendorCreation.BillingLandmark = drow.BillingLandmark == null ? "" : drow.BillingLandmark;
                    //    mCustomerVendorCreation.ContactPersonName = drow.ContactpersonName;
                    //    mCustomerVendorCreation.RegistrationType = drow.RegistrationType;
                    //    mCustomerVendorCreation.ApprovalStatus = drow.ApprovalStatus == null ? "" : drow.ApprovalStatus;
                    //    mCustomerVendorCreation.MobileNumber = drow.MobileNumber;
                    //    mCustomerVendorCreation.MobileNumber2 = drow.AlternateNumber;
                    //    mCustomerVendorCreation.NoofOutstandingBill = drow.NoofOutstandingBill ?? 0;
                    //    mCustomerVendorCreation.PANNumber = drow.PANNumber == null ? "" : drow.PANNumber;
                    //    mCustomerVendorCreation.Pincode = drow.BillingPincode == null ? "" : drow.BillingPincode;
                    //    mCustomerVendorCreation.City = drow.BillingCity ==null ? "" : drow.BillingCity;
                    //    mCustomerVendorCreation.CityCode = drow.BillingCityCode == null ? "" : drow.BillingCityCode;
                    //    mCustomerVendorCreation.Area = drow.BillingArea == null ? "" : drow.BillingArea;
                    //    // mCustomerVendorCreation.PlaceCode = drow.tblDebtorsPlaceDetail.PlaceCode == null ? "" : drow.tblDebtorsPlaceDetail.PlaceCode;
                    //    mCustomerVendorCreation.SalesmanID = drow.SalesManID ?? 0;
                    //    mCustomerVendorCreation.IsRemoved = drow.IsRemoved == null ? "" : drow.IsRemoved;

                    //    mCustomerVendorCreation.RegistrationType = drow.RegistrationType;
                    //    mCustomerVendorCreation.State = drow.State;
                    //    mCustomerVendorCreation.IsVendor = drow.IsVendor;
                    //    mCustomerVendorCreation.TelephoneNumber = drow.TelephoneNumber == null ? "" : drow.TelephoneNumber;
                    //    mCustomerVendorCreation.TINNumber = drow.TINNumber;
                    //    mCustomerVendorCreation.CreatedByID = drow.CreatedByID;
                    //    mCustomerVendorCreation.ModifiedByID = drow.ModifiedByID;
                    //    mCustomerVendorCreation.CrDays = drow.CrDays == null ? "" : drow.CrDays;
                    //    mCustomerVendorCreation.CrLimit = drow.CrLimit ?? string.Empty;
                    //    mCustomerVendorCreation.CreationDate = drow.CreationDate;
                    //    mCustomerVendorCreation.UpdatedDate = drow.UpdatedDate;
                    //    mCustomerVendorCreation.FirmName = drow.FirmName;
                    //    mCustomerVendorCreation.LedgerName = drow.LedgerName;
                    //    mCustomerVendorCreation.LedgerType = drow.LedgerType == null ? "" : drow.LedgerType;
                    //    mCustomerVendorCreation.BankName = drow.BankName == null ? "" : drow.BankName;
                    //    mCustomerVendorCreation.BankBranch = drow.BankBranch == null ? "" : drow.BankBranch;
                    //    mCustomerVendorCreation.BankCity = drow.BankCity == null ? "" : drow.BankCity;
                    //    mCustomerVendorCreation.AccountNo = drow.AccountNumber == null ? "" : drow.AccountNumber;
                    //    mCustomerVendorCreation.IFSCCode = drow.IFSCCode == null ? "" : drow.IFSCCode;
                    //    mCustomerVendorCreation.OpeningBalance = drow.OpeningBalance ?? 0;
                    //    mCustomerVendorCreation.ActivateIntrest = drow.ActivateIntrest;
                    //    mCustomerVendorCreation.PostDatedTransaction = drow.PostDatedTransaction;
                    //    mCustomerVendorCreation.Remark = string.Empty;
                    //    mCustomerVendorCreation.SourceOfUpdate = drow.SourceOfUpdate;
                    //    mCustomerVendorCreation.CompanyType = drow.CompanyType;
                    //    mCustomerVendorCreation.CustomerLabel = String.IsNullOrEmpty(drow.FirmName)  ? drow.Name.Trim() : drow.FirmName.Trim();
                    //    mCustomerVendorCreation.InsuranceCompany = drow.InsuranceCompany;
                    //    mCustomerVendorCreation.InsuranceNumber = drow.InsuranceNumber;
                    //    mCustomerVendorCreation.InsuranceExpiryDate = drow.InsuranceExpiryDate;
                    //    mCustomerVendorCreation.OrgID = drow.OrgID;
                    //    if (drow.IsTallyUpdated == false)
                    //    {
                    //        mCustomerVendorCreation.stringIsTallyUpdated = "No";
                    //    }
                    //    else
                    //    {
                    //        mCustomerVendorCreation.stringIsTallyUpdated = "Yes";
                    //    }
                    //    mCustomerVendorCreation.PercStrctureID = drow.PercStrctureID;

                    //    #region old code 
                    //    //if (drow.tblDebtorsPlaceDetail != null)
                    //    //{
                    //    //    mCustomerVendorCreation.DLDebtorsPlaceDetailCreation = new DLDebtorsPlaceDetailCreation()
                    //    //    {
                    //    //        PlaceID = drow.tblDebtorsPlaceDetail.PlaceID,
                    //    //        Place = drow.tblDebtorsPlaceDetail.Place,
                    //    //        PlaceCode = drow.tblDebtorsPlaceDetail.PlaceCode,
                    //    //        //SundryDebtors = drow.tblDebtorsPlaceDetail.SundryDebtors
                    //    //    };
                    //    //}
                    //    #endregion 

                    //    mCustomerVendorCreation.IsTallyUpdated = drow.IsTallyUpdated;
                    //    lstCustomerCreation.Add(mCustomerVendorCreation);
                    //}
                    #endregion

                    #region new
                    lstCustomerCreation = (from c in Entities.tblCustomerVendorDetails
                                           where c.OrgID == OrgID
                                           orderby c.ContactpersonName
                                           select new DLCustomerVendorDetailCreation
                                           {
                                               CustID = c.CustID,
                                               OrgID = c.OrgID,
                                               PercStrctureID = c.PercStrctureID,
                                               FirmName = c.FirmName,
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

                                               PostDatedTransaction = c.PostDatedTransaction,
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
                                               StateID = c.StateID,
                                               //!string.IsNullOrEmpty(c.BillingState) ? Entities.States.Where(st => st.StateName.ToLower() == c.BillingState).FirstOrDefault().StateID : 0,
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
                                               GSTNumber = c.TINNumber,
                                               RegistrationType = c.RegistrationType,

                                               TypeofCategory = c.TypeofCategory,
                                               WeekOffDay = c.WeekOffDay,
                                               CustomerType = c.CustomerType != null ? c.CustomerType.Value : 0,
                                               CreditTypeId = c.CreditType == null ? 0 : c.CreditType,

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
                                               OpeningBalance = c.OpeningBalance != null ? Convert.ToInt32(c.OpeningBalance) : 0,
                                               ContactPersonName = c.ContactpersonName,
                                               CompanyType = c.CompanyType,
                                               CompanyName = Entities.tblSysOrganizations.Where(o => o.OrgID == c.OrgID).FirstOrDefault().Name,

                                               CustomerLabel = string.IsNullOrEmpty(c.FirmName) ? c.ContactpersonName.Trim() : c.FirmName.Trim()
                                           }).ToList();
                    #endregion

                    if (SearchValue != "Tally" && !string.IsNullOrEmpty(SearchValue))
                        lstCustomerCreation = lstCustomerCreation.Where(c => c.ContactPersonName.ToLower().Trim().StartsWith(SearchValue.ToLower().Trim()) && c.OrgID == OrgID).ToList();

                    if (!string.IsNullOrEmpty(OrgID))
                        lstCustomerCreation = lstCustomerCreation.Where(c => c.IsVendor == IsVendor && c.OrgID == OrgID).ToList();

                    if (SearchValue == "Tally")
                        lstCustomerCreation = lstCustomerCreation.Where(t => t.IsTallyUpdated == false && t.OrgID == OrgID).ToList();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return lstCustomerCreation;
        }
        private object SaveData(object Context)
        {
            mCustomerVendorCreation = ((WBT.DL.Transaction.DLCustomerVendorDetailCreation)Context);
            try
            {

                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    var IsValueexists = from gCustomer in Entities.tblCustomerVendorDetails.AsNoTracking()
                                        where gCustomer.MobileNumber.Equals(mCustomerVendorCreation.MobileNumber.Trim())
                                        select gCustomer;

                    if (IsValueexists.Count() != 0)
                    {
                        this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                    }
                    else
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                #region
                                lCustomerVendor.Parent1 = this.mCustomerVendorCreation.Parent1;

                                lCustomerVendor.OrgID = this.mCustomerVendorCreation.OrgID;
                                lCustomerVendor.PercStrctureID = this.mCustomerVendorCreation.PercStrctureID;
                                lCustomerVendor.RegistrationType = this.mCustomerVendorCreation.RegistrationType;
                                lCustomerVendor.FirmName = this.mCustomerVendorCreation.FirmName;
                                lCustomerVendor.CompanyType = this.mCustomerVendorCreation.CompanyType;
                                lCustomerVendor.ContactpersonName = this.mCustomerVendorCreation.ContactPersonName;
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

                                lCustomerVendor.PostDatedTransaction = this.mCustomerVendorCreation.PostDatedTransaction;
                                lCustomerVendor.IsTallyUpdated = this.mCustomerVendorCreation.IsTallyUpdated;

                                lCustomerVendor.ActivateIntrest = this.mCustomerVendorCreation.ActivateIntrest;
                                lCustomerVendor.LedgerType = this.mCustomerVendorCreation.LedgerType;
                                lCustomerVendor.TelephoneNumber = this.mCustomerVendorCreation.TelephoneNumber;
                                lCustomerVendor.MobileNumber = this.mCustomerVendorCreation.MobileNumber;
                                lCustomerVendor.AlternateNumber = this.mCustomerVendorCreation.AlternateNumber;
                                lCustomerVendor.TINNumber = this.mCustomerVendorCreation.GSTNumber;
                                //lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;

                                if (this.mCustomerVendorCreation.GSTNumber != string.Empty)
                                {
                                    if (mCustomerVendorCreation.PANNumber == string.Empty)
                                    {
                                        lCustomerVendor.PANNumber = this.mCustomerVendorCreation.GSTNumber.Substring(2, 10);
                                    }
                                    else
                                    {
                                        lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;
                                    }
                                }
                                if (this.mCustomerVendorCreation.PANNumber != string.Empty)
                                {
                                    lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;
                                }

                                lCustomerVendor.NoofOutstandingBill = this.mCustomerVendorCreation.NoofOutstandingBill;
                                lCustomerVendor.LedgerName = this.mCustomerVendorCreation.LedgerName;
                                lCustomerVendor.IsVendor = this.mCustomerVendorCreation.IsVendor;
                                lCustomerVendor.CustID = this.mCustomerVendorCreation.CustID;
                                lCustomerVendor.OpeningBalance = this.mCustomerVendorCreation.OpeningBalance.ToString();
                                lCustomerVendor.CrDays = this.mCustomerVendorCreation.CrDays;
                                lCustomerVendor.CrLimit = this.mCustomerVendorCreation.CrLimit;
                                lCustomerVendor.PercStrctureID = mCustomerVendorCreation.PercStrctureID;
                                lCustomerVendor.CreationDate = Common.Helper.GetCurrentDate;
                                lCustomerVendor.UpdatedDate = Common.Helper.GetCurrentDate;
                                lCustomerVendor.IsActive = mCustomerVendorCreation.IsActive;
                                lCustomerVendor.CreatedByID = mCustomerVendorCreation.CreatedByID.Value;
                                lCustomerVendor.ModifiedByID = mCustomerVendorCreation.ModifiedByID;

                                lCustomerVendor.EmailID = this.mCustomerVendorCreation.EmailID;
                                lCustomerVendor.Religion = this.mCustomerVendorCreation.Religion;
                                lCustomerVendor.CustomerType = this.mCustomerVendorCreation.CustomerType;
                                lCustomerVendor.TypeofCategory = this.mCustomerVendorCreation.TypeofCategory;
                                lCustomerVendor.WeekOffDay = this.mCustomerVendorCreation.WeekOffDay;
                                lCustomerVendor.CreditType = this.mCustomerVendorCreation.CreditTypeId;

                                lCustomerVendor.BankName = this.mCustomerVendorCreation.BankName;
                                lCustomerVendor.BankBranch = this.mCustomerVendorCreation.BankBranch;
                                lCustomerVendor.BankCity = this.mCustomerVendorCreation.BankCity;
                                lCustomerVendor.AccountNumber = this.mCustomerVendorCreation.AccountNumber;
                                lCustomerVendor.IFSCCode = this.mCustomerVendorCreation.IFSCCode;
                                lCustomerVendor.InsuranceCompany = this.mCustomerVendorCreation.InsuranceCompany;
                                lCustomerVendor.InsuranceNumber = this.mCustomerVendorCreation.InsuranceNumber;
                                lCustomerVendor.InsuranceExpiryDate = this.mCustomerVendorCreation.InsuranceExpiryDate;
                                lCustomerVendor.StateID = this.mCustomerVendorCreation.StateID;
                                lCustomerVendor.CityID = this.mCustomerVendorCreation.CityID;

                                lCustomerVendor.SalesManID = this.mCustomerVendorCreation.SalesManID;
                                lCustomerVendor.ApprovalStatus = this.mCustomerVendorCreation.ApprovalStatus;
                                lCustomerVendor.SourceOfUpdate = this.mCustomerVendorCreation.SourceOfUpdate;
                                lCustomerVendor.IsRemoved = this.mCustomerVendorCreation.IsRemoved;

                                lCustomerVendor.AliasName = this.mCustomerVendorCreation.AliasName;
                                lCustomerVendor.AadhaarNumber = this.mCustomerVendorCreation.AadhaarNumber;


                                //images
                                lCustomerVendor.GSTPhoto = this.mCustomerVendorCreation.GSTPhoto;
                                lCustomerVendor.AadhaarPhoto = this.mCustomerVendorCreation.AadhaarPhoto;
                                lCustomerVendor.OwnerPhoto = this.mCustomerVendorCreation.OwnerPhoto;
                                lCustomerVendor.PANPhoto = this.mCustomerVendorCreation.PANPhoto;
                                lCustomerVendor.ShopImage = this.mCustomerVendorCreation.ShopImage;

                                #endregion

                                #region old
                                //lCustomerVendor.CustomerType = this.mCustomerVendorCreation.CustomerType;
                                //lCustomerVendor.CreditType = this.mCustomerVendorCreation.CreditType;
                                //lCustomerVendor.WeekOffDay = this.mCustomerVendorCreation.WeekOffDay;
                                //lCustomerVendor.TypeofCategory = this.mCustomerVendorCreation.TypeofCategory;

                                //lCustomerVendor.IsVendor = this.mCustomerVendorCreation.IsVendor;
                                //lCustomerVendor.RegistrationType = this.mCustomerVendorCreation.RegistrationType;
                                //lCustomerVendor.CustID = this.mCustomerVendorCreation.CustID;
                                //lCustomerVendor.ContactpersonName = this.mCustomerVendorCreation.ContactPersonName;
                                //lCustomerVendor.FirmName = this.mCustomerVendorCreation.FirmName;
                                //lCustomerVendor.MobileNumber = this.mCustomerVendorCreation.MobileNumber;
                                //lCustomerVendor.AlternateNumber = this.mCustomerVendorCreation.MobileNumber2;

                                //lCustomerVendor.BillingAddress = this.mCustomerVendorCreation.BillingAddress;
                                //lCustomerVendor.BillingLandmark = this.mCustomerVendorCreation.BillingLandmark;
                                //lCustomerVendor.BillingArea = this.mCustomerVendorCreation.Area;
                                //lCustomerVendor.BillingPincode = this.mCustomerVendorCreation.Pincode;
                                //lCustomerVendor.BillingCity = this.mCustomerVendorCreation.City;
                                //lCustomerVendor.BillingCityCode = this.mCustomerVendorCreation.CityCode;

                                //lCustomerVendor.ShippingAddress = this.mCustomerVendorCreation.BillingAddress;
                                //lCustomerVendor.ShippingLandMark = this.mCustomerVendorCreation.BillingLandmark;

                                //lCustomerVendor.NoofOutstandingBill = this.mCustomerVendorCreation.NoofOutstandingBill;
                                //lCustomerVendor.TelephoneNumber = mCustomerVendorCreation.TelephoneNumber;
                                //lCustomerVendor.EmailID = this.mCustomerVendorCreation.EmailID;
                                //lCustomerVendor.LedgerName = this.mCustomerVendorCreation.LedgerName;
                                //lCustomerVendor.TINNumber = this.mCustomerVendorCreation.TINNumber;
                                //lCustomerVendor.CompanyType = this.mCustomerVendorCreation.CompanyType;
                                //lCustomerVendor.InsuranceCompany = this.mCustomerVendorCreation.InsuranceCompany;
                                //lCustomerVendor.InsuranceNumber = this.mCustomerVendorCreation.InsuranceNumber;
                                //lCustomerVendor.InsuranceExpiryDate = this.mCustomerVendorCreation.InsuranceExpiryDate;
                                //if (this.mCustomerVendorCreation.TINNumber != string.Empty)
                                //{
                                //    if (mCustomerVendorCreation.PANNumber == string.Empty)
                                //    {
                                //        lCustomerVendor.PANNumber = this.mCustomerVendorCreation.TINNumber.Substring(2, 10);
                                //    }
                                //    else
                                //    {
                                //        lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;
                                //    }
                                //}
                                //if (this.mCustomerVendorCreation.PANNumber != string.Empty)
                                //{
                                //    lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;
                                //}
                                //lCustomerVendor.PostDatedTransaction = this.mCustomerVendorCreation.PostDatedTransaction;
                                //lCustomerVendor.ActivateIntrest = this.mCustomerVendorCreation.ActivateIntrest;
                                //lCustomerVendor.OpeningBalance = this.mCustomerVendorCreation.OpeningBalance;
                                //lCustomerVendor.IsRemoved = this.mCustomerVendorCreation.IsRemoved;
                                //lCustomerVendor.State = this.mCustomerVendorCreation.State;
                                //lCustomerVendor.ApprovalStatus = this.mCustomerVendorCreation.ApprovalStatus;
                                //lCustomerVendor.CrDays = this.mCustomerVendorCreation.CrDays;
                                //lCustomerVendor.CrLimit = this.mCustomerVendorCreation.CrLimit;
                                //lCustomerVendor.SalesManID = this.mCustomerVendorCreation.SalesmanID;
                                //lCustomerVendor.PercStrctureID = mCustomerVendorCreation.PercStrctureID;
                                //lCustomerVendor.LedgerType = mCustomerVendorCreation.LedgerType;
                                //lCustomerVendor.BankName = mCustomerVendorCreation.BankName;
                                //lCustomerVendor.BankBranch = mCustomerVendorCreation.BankBranch;
                                //lCustomerVendor.BankCity = mCustomerVendorCreation.BankCity;
                                //lCustomerVendor.AccountNumber = mCustomerVendorCreation.AccountNo;
                                //lCustomerVendor.IFSCCode = mCustomerVendorCreation.IFSCCode;
                                //lCustomerVendor.CreationDate = Common.Helper.GetCurrentDate;
                                //lCustomerVendor.UpdatedDate = Common.Helper.GetCurrentDate;
                                //lCustomerVendor.IsActive = mCustomerVendorCreation.IsActive;
                                //lCustomerVendor.CreatedByID = mCustomerVendorCreation.CreatedByID;
                                //lCustomerVendor.ModifiedByID = mCustomerVendorCreation.ModifiedByID;
                                //lCustomerVendor.OrgID = mCustomerVendorCreation.OrgID;

                                #endregion

                                #region to add customer item mapping details to Item SUpplier table
                                foreach (DLItemSupplierMapCreation item in mCustomerVendorCreation.dLItemSupplierMapCreations)
                                {
                                    supplierMapping = new tblItemSupplierMapping();
                                    //supplierMapping.ItemSupMappingID = WBT.Common.Helper.GetUniqueNumber;
                                    supplierMapping.ItemCode = item.ItemCode;
                                    supplierMapping.CustID = this.mCustomerVendorCreation.CustID;
                                    //supplierMapping.CreatedByID = Common.User.UserID;
                                    supplierMapping.CreatedDate = DateTime.Now;
                                    supplierMapping.ModifiedDate = DateTime.Now;
                                    supplierMapping.IsMapped = true;
                                    //supplierMapping.VendorType = VendorType.Undefined.ToString();
                                    Entities.tblItemSupplierMappings.Add(supplierMapping);   //saving vendor type while creating new vendors 

                                }
                                #endregion

                                Entities.tblCustomerVendorDetails.Add(lCustomerVendor);
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                this.GetApplicationActivate.GetErrormessages = ex.Message;
                                this.GetApplicationActivate.GetErrorSource = ex.Source;
                                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                throw;
                            }
                        }
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
            return this.GetApplicationActivate;
        }
        private object EditData(object Context)
        {
            mCustomerVendorCreation = ((DLCustomerVendorDetailCreation)Context);
            try
            {

                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    var IsValueexists1 = from gCustomer in Entities.tblCustomerVendorDetails.AsNoTracking()
                                         where gCustomer.MobileNumber.Trim().Equals(mCustomerVendorCreation.MobileNumber.Trim())
                                         && gCustomer.CustID != mCustomerVendorCreation.CustID
                                         select gCustomer;

                    if (IsValueexists1.Count() != 0)
                    {
                        this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                    }
                    else
                    {
                        lCustomerVendor = (from gCustomer in Entities.tblCustomerVendorDetails.AsNoTracking()
                                           where gCustomer.CustID == mCustomerVendorCreation.CustID
                                           select gCustomer).First();

                        if (lCustomerVendor != null)
                        {
                            using (var dbcxtransaction = Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    var IsValueexists = (from gCustomer in Entities.tblCustomerVendorDetails.AsNoTracking()
                                                         where gCustomer.CustID.Trim().Equals
                                                         (mCustomerVendorCreation.CustID.Trim())
                                                         select gCustomer).ToList();

                                    #region
                                    lCustomerVendor.CustID = this.mCustomerVendorCreation.CustID;
                                    lCustomerVendor.OrgID = this.mCustomerVendorCreation.OrgID;
                                    lCustomerVendor.PercStrctureID = this.mCustomerVendorCreation.PercStrctureID;
                                    lCustomerVendor.RegistrationType = this.mCustomerVendorCreation.RegistrationType;
                                    lCustomerVendor.FirmName = this.mCustomerVendorCreation.FirmName;
                                    lCustomerVendor.CompanyType = this.mCustomerVendorCreation.CompanyType;
                                    lCustomerVendor.ContactpersonName = this.mCustomerVendorCreation.ContactPersonName;

                                    lCustomerVendor.BillingAddress = this.mCustomerVendorCreation.BillingAddress;
                                    lCustomerVendor.BillingCity = this.mCustomerVendorCreation.BillingCity;
                                    lCustomerVendor.BillingCityCode = this.mCustomerVendorCreation.BillingCityCode;
                                    lCustomerVendor.BillingLandmark = this.mCustomerVendorCreation.BillingLandmark;
                                    lCustomerVendor.BillingPincode = this.mCustomerVendorCreation.BillingPincode;
                                    lCustomerVendor.BillingState = this.mCustomerVendorCreation.BillingState;
                                    lCustomerVendor.BillingArea = this.mCustomerVendorCreation.BillingArea;
                                    lCustomerVendor.StateID = this.mCustomerVendorCreation.StateID;
                                    lCustomerVendor.CityID = this.mCustomerVendorCreation.CityID;

                                    lCustomerVendor.PostDatedTransaction = this.mCustomerVendorCreation.PostDatedTransaction;
                                    lCustomerVendor.IsTallyUpdated = this.mCustomerVendorCreation.IsTallyUpdated;

                                    lCustomerVendor.ActivateIntrest = this.mCustomerVendorCreation.ActivateIntrest;
                                    lCustomerVendor.LedgerType = this.mCustomerVendorCreation.LedgerType;
                                    lCustomerVendor.TelephoneNumber = this.mCustomerVendorCreation.TelephoneNumber;
                                    lCustomerVendor.MobileNumber = this.mCustomerVendorCreation.MobileNumber;
                                    lCustomerVendor.AlternateNumber = this.mCustomerVendorCreation.AlternateNumber;
                                    lCustomerVendor.TINNumber = this.mCustomerVendorCreation.GSTNumber;
                                    //lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;

                                    if (this.mCustomerVendorCreation.GSTNumber != string.Empty)
                                    {
                                        if (mCustomerVendorCreation.PANNumber == string.Empty)
                                        {
                                            lCustomerVendor.PANNumber = this.mCustomerVendorCreation.GSTNumber.Substring(2, 10);
                                        }
                                        else
                                        {
                                            lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;
                                        }
                                    }
                                    if (this.mCustomerVendorCreation.PANNumber != string.Empty)
                                    {
                                        lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;
                                    }

                                    lCustomerVendor.NoofOutstandingBill = this.mCustomerVendorCreation.NoofOutstandingBill;
                                    lCustomerVendor.LedgerName = this.mCustomerVendorCreation.LedgerName;
                                    lCustomerVendor.IsVendor = this.mCustomerVendorCreation.IsVendor;

                                    lCustomerVendor.OpeningBalance = this.mCustomerVendorCreation.OpeningBalance.ToString();
                                    lCustomerVendor.CrDays = this.mCustomerVendorCreation.CrDays;
                                    lCustomerVendor.CrLimit = this.mCustomerVendorCreation.CrLimit;
                                    lCustomerVendor.PercStrctureID = mCustomerVendorCreation.PercStrctureID;
                                    lCustomerVendor.IsActive = mCustomerVendorCreation.IsActive;
                                    lCustomerVendor.EmailID = this.mCustomerVendorCreation.EmailID;
                                    lCustomerVendor.CustomerType = this.mCustomerVendorCreation.CustomerType;
                                    lCustomerVendor.TypeofCategory = this.mCustomerVendorCreation.TypeofCategory;
                                    lCustomerVendor.WeekOffDay = this.mCustomerVendorCreation.WeekOffDay;
                                    lCustomerVendor.CreditType = this.mCustomerVendorCreation.CreditTypeId;

                                    lCustomerVendor.BankName = this.mCustomerVendorCreation.BankName;
                                    lCustomerVendor.BankBranch = this.mCustomerVendorCreation.BankBranch;
                                    lCustomerVendor.BankCity = this.mCustomerVendorCreation.BankCity;
                                    lCustomerVendor.AccountNumber = this.mCustomerVendorCreation.AccountNumber;
                                    lCustomerVendor.IFSCCode = this.mCustomerVendorCreation.IFSCCode;
                                    lCustomerVendor.InsuranceCompany = this.mCustomerVendorCreation.InsuranceCompany;
                                    lCustomerVendor.InsuranceNumber = this.mCustomerVendorCreation.InsuranceNumber;
                                    lCustomerVendor.InsuranceExpiryDate = this.mCustomerVendorCreation.InsuranceExpiryDate;

                                    lCustomerVendor.SalesManID = this.mCustomerVendorCreation.SalesManID;
                                    lCustomerVendor.ApprovalStatus = this.mCustomerVendorCreation.ApprovalStatus;
                                    lCustomerVendor.SourceOfUpdate = this.mCustomerVendorCreation.SourceOfUpdate;

                                    lCustomerVendor.UpdatedDate = Common.Helper.GetCurrentDate;
                                    lCustomerVendor.ModifiedByID = mCustomerVendorCreation.ModifiedByID;

                                    if (IsValueexists.Count() != 0)
                                    {
                                        //images
                                        lCustomerVendor.GSTPhoto = IsValueexists.FirstOrDefault().GSTPhoto;
                                        lCustomerVendor.AadhaarPhoto = IsValueexists.FirstOrDefault().AadhaarPhoto;
                                        lCustomerVendor.OwnerPhoto = IsValueexists.FirstOrDefault().OwnerPhoto;
                                        lCustomerVendor.PANPhoto = IsValueexists.FirstOrDefault().PANPhoto;
                                        lCustomerVendor.ShopImage = IsValueexists.FirstOrDefault().ShopImage;

                                        lCustomerVendor.AliasName = IsValueexists.FirstOrDefault().AliasName;
                                        lCustomerVendor.AadhaarNumber = IsValueexists.FirstOrDefault().AadhaarNumber;

                                        lCustomerVendor.IsRemoved = IsValueexists.FirstOrDefault().IsRemoved;
                                        lCustomerVendor.ContactpersonPhone = IsValueexists.FirstOrDefault().ContactpersonPhone;

                                        lCustomerVendor.Religion = IsValueexists.FirstOrDefault().Religion;
                                        lCustomerVendor.BillingGPSLocation = IsValueexists.FirstOrDefault().BillingGPSLocation;
                                        lCustomerVendor.BillingLatitude = IsValueexists.FirstOrDefault().BillingLatitude;
                                        lCustomerVendor.BillingLongitude = IsValueexists.FirstOrDefault().BillingLongitude;

                                        lCustomerVendor.ShippingAddress = IsValueexists.FirstOrDefault().ShippingAddress;
                                        lCustomerVendor.ShippingArea = IsValueexists.FirstOrDefault().ShippingArea;
                                        lCustomerVendor.ShippingCity = IsValueexists.FirstOrDefault().ShippingCity;
                                        lCustomerVendor.ShippingCityCode = IsValueexists.FirstOrDefault().ShippingCityCode;
                                        lCustomerVendor.ShippingGPSLocation = IsValueexists.FirstOrDefault().ShippingGPSLocation;
                                        lCustomerVendor.ShippingLandMark = IsValueexists.FirstOrDefault().ShippingLandMark;
                                        lCustomerVendor.ShippingLatitude = IsValueexists.FirstOrDefault().ShippingLatitude;
                                        lCustomerVendor.ShippingLongitude = IsValueexists.FirstOrDefault().ShippingLongitude;
                                        lCustomerVendor.ShippingPincode = IsValueexists.FirstOrDefault().ShippingPincode;
                                        lCustomerVendor.ShippingState = IsValueexists.FirstOrDefault().ShippingState;

                                        //tally fields
                                        lCustomerVendor.FaxNo = IsValueexists.FirstOrDefault().FaxNo;
                                        lCustomerVendor.CCEmail = IsValueexists.FirstOrDefault().CCEmail;
                                        lCustomerVendor.Website = IsValueexists.FirstOrDefault().Website;
                                        lCustomerVendor.BillWiseYesNo = IsValueexists.FirstOrDefault().BillWiseYesNo;
                                        lCustomerVendor.Checkforcreditdaysduringvoucherentry = IsValueexists.FirstOrDefault().Checkforcreditdaysduringvoucherentry;
                                        lCustomerVendor.OverrideCreditlimit = IsValueexists.FirstOrDefault().OverrideCreditlimit;
                                        lCustomerVendor.Inventoryvaluesareaffected = IsValueexists.FirstOrDefault().Inventoryvaluesareaffected;
                                        lCustomerVendor.ActivateInterestCalculation = IsValueexists.FirstOrDefault().ActivateInterestCalculation;
                                        lCustomerVendor.CalculateInterestTransaction_by_Transaction = IsValueexists.FirstOrDefault().CalculateInterestTransaction_by_Transaction;
                                        lCustomerVendor.OverrideCreditlimit = IsValueexists.FirstOrDefault().OverrideCreditlimit;
                                        lCustomerVendor.PostDatedTransaction = IsValueexists.FirstOrDefault().PostDatedTransaction;
                                        lCustomerVendor.AlternateNumber = IsValueexists.FirstOrDefault().AlternateNumber.Trim();
                                        lCustomerVendor.Parent1 = IsValueexists.FirstOrDefault().Parent1;
                                        lCustomerVendor.Parent2 = IsValueexists.FirstOrDefault().Parent2;
                                        lCustomerVendor.Parent3 = IsValueexists.FirstOrDefault().Parent3;
                                        lCustomerVendor.Parent4 = IsValueexists.FirstOrDefault().Parent4;
                                        lCustomerVendor.ParentDebtorID = IsValueexists.FirstOrDefault().ParentDebtorID;
                                        lCustomerVendor.Country = IsValueexists.FirstOrDefault().Country;
                                        lCustomerVendor.CrLimit = IsValueexists.FirstOrDefault().CrDays;
                                        lCustomerVendor.CrDays = IsValueexists.FirstOrDefault().CrLimit;
                                        lCustomerVendor.OverrideParametersforeachtransaction = IsValueexists.FirstOrDefault().OverrideParametersforeachtransaction;
                                        lCustomerVendor.IntrestRate = IsValueexists.FirstOrDefault().IntrestRate;
                                        lCustomerVendor.InterestDays = IsValueexists.FirstOrDefault().InterestDays;
                                        lCustomerVendor.OpeningBalance = IsValueexists.FirstOrDefault().OpeningBalance;
                                        lCustomerVendor.NoofOutstandingBill = IsValueexists.FirstOrDefault().NoofOutstandingBill;
                                        lCustomerVendor.LedgerName = IsValueexists.FirstOrDefault().LedgerName;
                                        lCustomerVendor.IsVendor = IsValueexists.FirstOrDefault().IsVendor;
                                        lCustomerVendor.IsActive = IsValueexists.FirstOrDefault().IsActive;

                                        lCustomerVendor.ModifiedByID = mCustomerVendorCreation.ModifiedByID;
                                        lCustomerVendor.UpdatedDate = Helper.GetCurrentDate;
                                        lCustomerVendor.CreationDate = IsValueexists.FirstOrDefault().CreationDate;
                                        lCustomerVendor.CreatedByID = IsValueexists.FirstOrDefault().CreatedByID;
                                        Entities.Entry(lCustomerVendor).State = System.Data.Entity.EntityState.Modified;
                                        this.GetApplicationActivate.DataState = Common.TransactionType.Edit;
                                    }
                                    #endregion

                                    #region
                                    //lCustomerVendor.CustID = this.mCustomerVendorCreation.CustID;
                                    //lCustomerVendor.FirmName = this.mCustomerVendorCreation.FirmName;
                                    //lCustomerVendor.Name = this.mCustomerVendorCreation.ContactPersonName;
                                    //lCustomerVendor.MobileNumber = this.mCustomerVendorCreation.MobileNumber;
                                    //lCustomerVendor.AlternateNumber = this.mCustomerVendorCreation.MobileNumber2;
                                    //lCustomerVendor.PostDatedTransaction = this.mCustomerVendorCreation.PostDatedTransaction;
                                    //lCustomerVendor.ActivateIntrest = this.mCustomerVendorCreation.ActivateIntrest;
                                    //lCustomerVendor.EmailID = this.mCustomerVendorCreation.EmailID;
                                    //lCustomerVendor.ShippingAddress = this.mCustomerVendorCreation.ShippingAddress;
                                    //lCustomerVendor.ShippingLandMark = this.mCustomerVendorCreation.ShippingLandMark;
                                    //lCustomerVendor.BillingAddress = this.mCustomerVendorCreation.BillingAddress;
                                    //lCustomerVendor.BillingLandmark = this.mCustomerVendorCreation.BillingLandmark;
                                    //lCustomerVendor.SalesManID = this.mCustomerVendorCreation.SalesmanID;
                                    //lCustomerVendor.TelephoneNumber = this.mCustomerVendorCreation.TelephoneNumber;
                                    //lCustomerVendor.BillingArea = this.mCustomerVendorCreation.Area;
                                    //lCustomerVendor.PANNumber = this.mCustomerVendorCreation.PANNumber;
                                    //lCustomerVendor.BillingPincode = this.mCustomerVendorCreation.Pincode;
                                    //lCustomerVendor.State = this.mCustomerVendorCreation.State;
                                    //lCustomerVendor.RegistrationType = this.mCustomerVendorCreation.RegistrationType;
                                    //lCustomerVendor.LedgerName = this.mCustomerVendorCreation.LedgerName;
                                    //lCustomerVendor.BillingCity = this.mCustomerVendorCreation.City;
                                    //lCustomerVendor.BillingCityCode = this.mCustomerVendorCreation.CityCode;
                                    //lCustomerVendor.LedgerType = this.mCustomerVendorCreation.LedgerType;
                                    //lCustomerVendor.TINNumber = this.mCustomerVendorCreation.TINNumber;
                                    //lCustomerVendor.NoofOutstandingBill = this.mCustomerVendorCreation.NoofOutstandingBill;
                                    //lCustomerVendor.CrLimit = mCustomerVendorCreation.CrLimit;
                                    //lCustomerVendor.CrDays = mCustomerVendorCreation.CrDays;
                                    //lCustomerVendor.IsRemoved = this.mCustomerVendorCreation.IsRemoved;
                                    //lCustomerVendor.PercStrctureID = mCustomerVendorCreation.PercStrctureID;
                                    //lCustomerVendor.ApprovalStatus = mCustomerVendorCreation.ApprovalStatus;
                                    //lCustomerVendor.BankName = mCustomerVendorCreation.BankName;
                                    //lCustomerVendor.BankBranch = mCustomerVendorCreation.BankBranch;
                                    //lCustomerVendor.BankCity = mCustomerVendorCreation.BankCity;
                                    //lCustomerVendor.AccountNumber = mCustomerVendorCreation.AccountNo;
                                    //lCustomerVendor.IFSCCode = mCustomerVendorCreation.IFSCCode;
                                    //lCustomerVendor.UpdatedDate = Common.Helper.GetCurrentDate;
                                    //lCustomerVendor.IsActive = mCustomerVendorCreation.IsActive;
                                    //lCustomerVendor.ModifiedByID = mCustomerVendorCreation.ModifiedByID;
                                    //lCustomerVendor.SourceOfUpdate = mCustomerVendorCreation.SourceOfUpdate;
                                    //lCustomerVendor.CompanyType = mCustomerVendorCreation.CompanyType;
                                    //lCustomerVendor.InsuranceCompany = mCustomerVendorCreation.InsuranceCompany;
                                    //lCustomerVendor.InsuranceNumber = mCustomerVendorCreation.InsuranceNumber;
                                    //lCustomerVendor.InsuranceExpiryDate = mCustomerVendorCreation.InsuranceExpiryDate;
                                    //lCustomerVendor.OrgID = mCustomerVendorCreation.OrgID;
                                    #endregion
                                    Entities.tblCustomerVendorDetails.Add(lCustomerVendor);
                                    Entities.Entry(lCustomerVendor).State = EntityState.Modified;
                                    Entities.SaveChanges();
                                    dbcxtransaction.Commit();
                                    this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                                }
                                catch (Exception ex)
                                {
                                    dbcxtransaction.Rollback();
                                    this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                    this.GetApplicationActivate.GetErrormessages = ex.Message;
                                    this.GetApplicationActivate.GetErrorSource = ex.Source;
                                    this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                    throw;
                                }
                            }
                        }
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
            return this.GetApplicationActivate;

        }
        private object EditDataTallyColumn(object Context)
        {
            mCustomerVendorCreation = ((DLCustomerVendorDetailCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    lCustomerVendor = (from gCustomer in Entities.tblCustomerVendorDetails.AsNoTracking().ToList()
                                       where gCustomer.CustID == mCustomerVendorCreation.CustID
                                       && gCustomer.OrgID == mCustomerVendorCreation.OrgID
                                       select gCustomer).First();

                    if (lCustomerVendor != null)
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                lCustomerVendor.IsTallyUpdated = true;
                                lCustomerVendor.UpdatedDate = Common.Helper.GetCurrentDate;
                                lCustomerVendor.ModifiedByID = mCustomerVendorCreation.ModifiedByID;
                                Entities.tblCustomerVendorDetails.Add(lCustomerVendor);
                                Entities.Entry(lCustomerVendor).State = EntityState.Modified;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                this.GetApplicationActivate.GetErrormessages = ex.Message;
                                this.GetApplicationActivate.GetErrorSource = ex.Source;
                                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                throw;
                            }
                        }
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
            return this.GetApplicationActivate;
        }
        private object GetCustomer(string SearchText, string customerType, string orgID)
        {
            try
            {
                if (!string.IsNullOrEmpty(SearchText))
                {
                    // lstCustomerCreation = new List<DLCustomerVendorDetailCreation>();
                    //URDNumber is added to bring the unique recrods 
                    //Even if the same mobile is added twice in the table one will have GSTN and One will have URDN

                    using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                    {
                        if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                            Entities.Database.Connection.Open();                        //to open the connection if closed

                        ///to do to takes if todays data pesent in this table
                        //var CustomerCrediDetails = Entities.CustomerCreditDetails.Where(i => i.CustID.ToLower().Trim() == SearchText.ToLower().Trim()
                        //  && i.CreationDate.Value.Date.ToShortDateString() == DateTime.Now.Date.ToShortDateString()).FirstOrDefault();
                        //i.CreationDate.Value.Date == DateTime.Now.Date).FirstOrDefault();

                        var result = Entities.tblCustomerVendorDetails.Where(e =>
                            (e.CustID.ToLower().Trim() == SearchText.ToLower().Trim())
                            || (e.TINNumber.ToLower().Trim() == SearchText.ToLower().Trim())
                            || (e.MobileNumber.ToLower().Trim() == SearchText.ToLower().Trim())
                           && (e.OrgID == orgID.Trim())
                           //|| e.RegistrationType.ToLower().Trim() == customerType.ToLower().Trim())
                           ).FirstOrDefault();

                        if (result != null)
                        {
                            mCustomerVendorCreation = new DLCustomerVendorDetailCreation();
                            mCustomerVendorCreation.ApprovalStatus = result.ApprovalStatus;
                            mCustomerVendorCreation.CustID = result.CustID;
                            mCustomerVendorCreation.ShippingAddress = result.ShippingAddress;

                            mCustomerVendorCreation.ContactPersonName = result.ContactpersonName;
                            mCustomerVendorCreation.MobileNumber = result.MobileNumber;
                            mCustomerVendorCreation.NoofOutstandingBill = result.NoofOutstandingBill;
                            mCustomerVendorCreation.PANNumber = result.PANNumber;
                            mCustomerVendorCreation.BillingPincode = result.BillingPincode;
                            mCustomerVendorCreation.TelephoneNumber = result.TelephoneNumber;
                            mCustomerVendorCreation.GSTNumber = result.TINNumber;
                            mCustomerVendorCreation.CreatedByID = result.CreatedByID;
                            mCustomerVendorCreation.CreationDate = result.CreationDate;
                            mCustomerVendorCreation.UpdatedDate = result.UpdatedDate;
                            mCustomerVendorCreation.IsTallyUpdated = result.IsTallyUpdated;
                            mCustomerVendorCreation.FirmName = result.FirmName;
                            mCustomerVendorCreation.SalesManID = result.SalesManID ?? 0;
                            mCustomerVendorCreation.RegistrationType = result.RegistrationType;
                            mCustomerVendorCreation.PercStrctureID = result.tblPercentageStructure != null ? result.tblPercentageStructure.PercentageValue : 0;
                            mCustomerVendorCreation.CrDays = result.CrDays;
                            mCustomerVendorCreation.CrLimit = result.CrLimit;
                            mCustomerVendorCreation.NoofOutstandingBill = result.NoofOutstandingBill;
                            mCustomerVendorCreation.BillingAddress = result.BillingAddress;
                            mCustomerVendorCreation.BillingArea = result.BillingArea;
                            mCustomerVendorCreation.BillingCity = result.BillingCity;
                            mCustomerVendorCreation.BillingCityCode = result.BillingCityCode;
                            mCustomerVendorCreation.CompanyType = result.CompanyType;
                            mCustomerVendorCreation.CustomerType = result.CustomerType;
                            mCustomerVendorCreation.InsuranceCompany = result.InsuranceCompany;
                            mCustomerVendorCreation.InsuranceNumber = result.InsuranceNumber;
                            mCustomerVendorCreation.InsuranceExpiryDate = result.InsuranceExpiryDate;
                            mCustomerVendorCreation.OrgID = result.OrgID;
                            //mCustomerVendorCreation.CrDays = CustomerCrediDetails == null ? result.CrDays : CustomerCrediDetails.CrDays;                        
                            //mCustomerVendorCreation.CrLament = CustomerCrediDetails == null ? result.CrLimit : CustomerCrediDetails.CrLimit;
                            //mCustomerVendorCreation.NoofOutstandingBill = CustomerCrediDetails == null ? result.NoofOutstandingBill : CustomerCrediDetails.NoofOutstandingBill;

                            #region old code
                            //if (result.tblDebtorsPlaceDetail != null)
                            //{
                            //    mCustomerVendorCreation.DLDebtorsPlaceDetailCreation = new DLDebtorsPlaceDetailCreation()
                            //    {
                            //        PlaceID = result.tblDebtorsPlaceDetail.PlaceID,
                            //        Place = result.tblDebtorsPlaceDetail.Place,
                            //        PlaceCode = result.tblDebtorsPlaceDetail.PlaceCode,
                            //    };
                            //}
                            #endregion
                            return mCustomerVendorCreation;
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return null;
        }

        public object GetCustomersFromFirmName(string FirmName, string OrgID)
        {
            lstCustomerCreation = new List<DLCustomerVendorDetailCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    var customers = from gCustomers in Entities.tblCustomerVendorDetails.AsNoTracking()
                                    orderby gCustomers.ContactpersonName
                                    where gCustomers.FirmName.ToLower().Trim().Contains(FirmName.ToLower().Trim())
                                    && gCustomers.OrgID == OrgID
                                    select gCustomers;

                    if (customers != null & customers.Count() > 0)
                    {
                        foreach (var drow in customers)
                        {
                            mCustomerVendorCreation = new DLCustomerVendorDetailCreation();
                            mCustomerVendorCreation.CustID = drow.CustID;
                            mCustomerVendorCreation.EmailID = drow.EmailID == null ? "" : drow.EmailID;
                            mCustomerVendorCreation.ShippingAddress = drow.ShippingAddress;
                            mCustomerVendorCreation.BillingAddress = drow.BillingAddress == null ? "" : drow.BillingAddress;
                            mCustomerVendorCreation.ShippingLandMark = drow.ShippingLandMark == null ? "" : drow.ShippingLandMark;
                            mCustomerVendorCreation.BillingLandmark = drow.BillingLandmark == null ? "" : drow.BillingLandmark;
                            mCustomerVendorCreation.ContactPersonName = drow.ContactpersonName;
                            mCustomerVendorCreation.RegistrationType = drow.RegistrationType;
                            mCustomerVendorCreation.ApprovalStatus = drow.ApprovalStatus == null ? "" : drow.ApprovalStatus;
                            mCustomerVendorCreation.MobileNumber = drow.MobileNumber;
                            mCustomerVendorCreation.AlternateNumber = drow.AlternateNumber;
                            mCustomerVendorCreation.NoofOutstandingBill = drow.NoofOutstandingBill ?? 0;
                            mCustomerVendorCreation.PANNumber = drow.PANNumber == null ? "" : drow.PANNumber;
                            mCustomerVendorCreation.BillingPincode = drow.BillingPincode == null ? "" : drow.BillingPincode;
                            mCustomerVendorCreation.BillingCity = drow.BillingCity == null ? "" : drow.BillingCity;
                            mCustomerVendorCreation.BillingCityCode = drow.BillingCityCode == null ? "" : drow.BillingCityCode;
                            mCustomerVendorCreation.SalesManID = drow.SalesManID ?? 0;
                            mCustomerVendorCreation.IsRemoved = drow.IsRemoved == null ? "" : drow.IsRemoved;
                            mCustomerVendorCreation.BillingArea = drow.BillingArea == null ? "" : drow.BillingArea;
                            mCustomerVendorCreation.RegistrationType = drow.RegistrationType;
                            mCustomerVendorCreation.StateID = drow.StateID;
                            mCustomerVendorCreation.IsVendor = drow.IsVendor;
                            mCustomerVendorCreation.TelephoneNumber = drow.TelephoneNumber == null ? "" : drow.TelephoneNumber;
                            mCustomerVendorCreation.GSTNumber = drow.TINNumber;
                            mCustomerVendorCreation.CreatedByID = drow.CreatedByID;
                            mCustomerVendorCreation.ModifiedByID = drow.ModifiedByID;
                            mCustomerVendorCreation.CrDays = drow.CrDays == null ? "" : drow.CrDays;
                            mCustomerVendorCreation.CrLimit = drow.CrLimit ?? string.Empty;
                            mCustomerVendorCreation.CreationDate = drow.CreationDate;
                            mCustomerVendorCreation.UpdatedDate = drow.UpdatedDate;
                            mCustomerVendorCreation.FirmName = drow.FirmName;
                            mCustomerVendorCreation.LedgerName = drow.LedgerName;
                            mCustomerVendorCreation.LedgerType = drow.LedgerType == null ? "" : drow.LedgerType;
                            mCustomerVendorCreation.BankName = drow.BankName == null ? "" : drow.BankName;
                            mCustomerVendorCreation.BankBranch = drow.BankBranch == null ? "" : drow.BankBranch;
                            mCustomerVendorCreation.BankCity = drow.BankCity == null ? "" : drow.BankCity;
                            mCustomerVendorCreation.AccountNumber = drow.AccountNumber == null ? "" : drow.AccountNumber;
                            mCustomerVendorCreation.IFSCCode = drow.IFSCCode == null ? "" : drow.IFSCCode;
                            mCustomerVendorCreation.OpeningBalance = 0;//drow.OpeningBalance ?? 0;
                            mCustomerVendorCreation.ActivateIntrest = drow.ActivateIntrest;
                            mCustomerVendorCreation.PostDatedTransaction = drow.PostDatedTransaction;
                            mCustomerVendorCreation.Remark = string.Empty;
                            mCustomerVendorCreation.SourceOfUpdate = drow.SourceOfUpdate;
                            mCustomerVendorCreation.CompanyType = drow.CompanyType;
                            mCustomerVendorCreation.CustomerLabel = String.IsNullOrEmpty(drow.FirmName) ? drow.ContactpersonName.Trim() : drow.FirmName.Trim();
                            mCustomerVendorCreation.InsuranceCompany = drow.InsuranceCompany;
                            mCustomerVendorCreation.InsuranceNumber = drow.InsuranceNumber;
                            mCustomerVendorCreation.InsuranceExpiryDate = drow.InsuranceExpiryDate;
                            mCustomerVendorCreation.OrgID = drow.OrgID;
                            if (drow.IsTallyUpdated == false)
                            {
                                mCustomerVendorCreation.stringIsTallyUpdated = "No";
                            }
                            else
                            {
                                mCustomerVendorCreation.stringIsTallyUpdated = "Yes";
                            }
                            mCustomerVendorCreation.PercStrctureID = drow.PercStrctureID;
                            mCustomerVendorCreation.IsTallyUpdated = drow.IsTallyUpdated;
                            lstCustomerCreation.Add(mCustomerVendorCreation);
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return lstCustomerCreation;
        }

        public object GetCustomerType(object Context)
        {
            DLCustomerVendorDetailCreation dLCustomerVendorDetailCreation = (DLCustomerVendorDetailCreation)Context;
            mCustomerVendorCreation = new DLCustomerVendorDetailCreation();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    #region new
                    mCustomerVendorCreation = (from c in Entities.tblCustomerVendorDetails
                                               where c.CustID.ToLower() == dLCustomerVendorDetailCreation.CustID.ToLower()
                                               orderby c.ContactpersonName
                                               select new DLCustomerVendorDetailCreation
                                               {
                                                   CustID = c.CustID,
                                                   OrgID = c.OrgID,
                                                   CreditTypeId = c.CreditType == null ? 0 : c.CreditType,
                                               }).FirstOrDefault();

                    if (mCustomerVendorCreation.CreditTypeId != 0)
                    {
                        mCustomerVendorCreation.CreditTypeName = Entities.CreditTypes.Where(c => c.CreditTypeID == mCustomerVendorCreation.CreditTypeId).FirstOrDefault().CreditTypeName;
                    }
                    else
                    {
                        mCustomerVendorCreation.CreditTypeName = "Cash";
                    }

                    #endregion
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return mCustomerVendorCreation;
        }
    }
}