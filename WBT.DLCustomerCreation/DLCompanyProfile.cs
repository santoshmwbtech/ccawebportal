using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLCompanyProfile
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public SysOrganization GetOrganizationDetails(string UserID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    SysOrganization result = new SysOrganization();
                    result = (from u in Entities.tblSysUsers
                              join o in Entities.tblSysOrganizations on u.OrgID equals o.OrgID
                              where u.UserID.ToString() == UserID
                              select new SysOrganization
                              {
                                  OrgID = o.OrgID,
                                  Name = o.Name,
                                  ContactPerson = o.ContactPerson,
                                  Phone = o.Phone,
                                  Mobile = o.Mobile,
                                  Email = o.Email,
                                  Website = o.Website,
                                  GSTNumber = o.GSTNumber,
                                  Country = o.Country,
                                  State = o.State,
                                  City = o.City,
                                  BankName = o.BankName,
                                  BranchName = o.BranchName,
                                  AccountNumber = o.AccountNumber,
                                  BankCity = o.BankCity,
                                  Logo = o.Logo,
                                  LogoBase64 = string.Empty,
                                  UpdatedByName = o.tblSysUsers.FirstOrDefault().FName,
                                  UpdatedDatetime = o.ModifiedDatetime,
                              }).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public SysOrganization UpdateOrganizationDetails(SysOrganization sysOrganization)
        {
            SysOrganization Result = new SysOrganization();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        tblSysOrganization tbl = new tblSysOrganization();
                        tbl.OrgID = sysOrganization.OrgID;
                        tbl.Name = sysOrganization.Name;
                        tbl.ContactPerson = sysOrganization.ContactPerson;
                        tbl.Phone = sysOrganization.Phone;
                        tbl.Mobile = sysOrganization.Mobile;
                        tbl.Email = sysOrganization.Email;
                        tbl.Website = sysOrganization.Website;
                        tbl.GSTNumber = sysOrganization.GSTNumber;
                        tbl.Country = sysOrganization.Country;
                        tbl.State = sysOrganization.State;
                        tbl.City = sysOrganization.City;
                        tbl.BankName = sysOrganization.BankName;
                        tbl.BranchName = sysOrganization.BranchName;
                        tbl.AccountNumber = sysOrganization.AccountNumber;
                        tbl.ShippingAddress = "";
                        tbl.BankCity = sysOrganization.BankCity;
                        Entities.tblSysOrganizations.Attach(tbl);
                        Entities.Entry(tbl).Property(c => c.Name).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.ContactPerson).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.Phone).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.Mobile).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.Website).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.GSTNumber).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.Country).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.State).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.City).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.BankName).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.BranchName).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.AccountNumber).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.BankCity).IsModified = true;
                        Entities.Entry(tbl).Property(c => c.ShippingAddress).IsModified = true;
                        Entities.SaveChanges();
                        dbcxtransaction.Commit();
                        Result.DisplayMessage = "1";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Error!! Please contact administrator";
                return Result;
            }
        }
    }
    public class SysOrganization
    {
        public string OrgID { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter Organization Name")]
        public string Name { get; set; }
        public string Alias { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        [Required(ErrorMessage = "Please enter GST Number")]
        public string GSTNumber { get; set; }
        [Required(ErrorMessage = "Please enter Shipping Address")]
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string BillingLandmark { get; set; }
        public string ShippingLandmark { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Contact Person Name")]
        public string ContactPerson { get; set; }
        [Required(ErrorMessage = "Please enter Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter Mobile Number")]
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string BusinessType { get; set; }
        public string CompanyType { get; set; }
        [Required(ErrorMessage = "Please enter Bank Name")]
        public string BankName { get; set; }
        [Required(ErrorMessage = "Please enter Branch Name")]
        public string BranchName { get; set; }
        public string BankCode { get; set; }
        [Required(ErrorMessage = "Please enter bank city name")]
        public string BankCity { get; set; }
        [Required(ErrorMessage = "Please enter Account Number")]
        public string AccountNumber { get; set; }
        public string IFSCNumber { get; set; }
        public string FSSAICode { get; set; }
        public Nullable<int> NoOfOutstandingBills { get; set; }
        public string CreditDays { get; set; }
        public Nullable<decimal> CreditLimitAmt { get; set; }
        public byte[] Logo { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string PANNumber { get; set; }
        public string STNumber { get; set; }
        public string CSTNumber { get; set; }
        public string VATNumber { get; set; }
        public string MailingName { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Please select state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        public string City { get; set; }
        public string Pincode { get; set; }
        public Nullable<int> ApplicationID { get; set; }
        public string AlternateNumber { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPinCode { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDatetime { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string SourceOfUpdate { get; set; }
        public string UpdatedByName { get; set; }
        public string LogoBase64 { get; set; }
        public string DisplayMessage { get; set; }
    }
}
