using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCAPortal.Models
{

    public class CustomerExcel
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
        public string InsuranceExpiryDate { get; set; }
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
        public string CustomerType { get; set; }
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
    }
}