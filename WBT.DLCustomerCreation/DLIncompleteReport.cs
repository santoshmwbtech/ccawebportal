using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WBT.Common;
using WBT.DLCustomerCreation;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLIncompleteReport
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        public List<IncompleteCustomers> GetIncompleteReport(IncompleteCustomers incomplete, string UserID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {

                        int iUserID = Convert.ToInt32(UserID);
                        string roleName = (from u in Entities.tblSysUsers
                                           join s in Entities.tblSysRoles on u.RoleID equals s.RoleID
                                           where u.UserID == iUserID
                                           select s.RoleName).FirstOrDefault();
                        var incompleteCustomers = (from c in Entities.tblCustomerVendorDetails
                                               where c.OrgID == incomplete.OrgID
                                               select new IncompleteCustomers
                                               {
                                                   OrgID = c.OrgID,
                                                   BranchID = c.BranchID == null ? "0" : c.BranchID,
                                                   CustID = c.CustID,
                                                   FirmName = c.FirmName,
                                                   Name = c.OwnerName,
                                                   CityName = c.BillingCity,
                                                   StateName = c.BillingState,
                                                   RoleName = roleName,
                                                   MobileNumber = c.MobileNumber,
                                                   CityID = c.CityID,
                                                   StateID = c.StateID,
                                                   AadhaarNumber = c.AadhaarNumber,
                                                   BillingAddress = c.BillingAddress,
                                                   GPSLocation = c.BillingGPSLocation,
                                                   GSTNumber = c.TINNumber,
                                                   PANNumber = c.PANNumber,
                                                   ShippingAddress = c.ShippingAddress,
                                                   CreationDate = c.CreationDate,
                                               }).ToList();

                        if (!string.IsNullOrEmpty(incomplete.FromDate) && !string.IsNullOrEmpty(incomplete.ToDate))
                        {
                            var fromDate = Convert.ToDateTime(incomplete.FromDate).Date;
                            var toDate = Convert.ToDateTime(incomplete.ToDate).Date;
                            incompleteCustomers = incompleteCustomers.Where(d => d.CreationDate.Date >= fromDate && d.CreationDate.Date <= toDate && d.OrgID == incomplete.OrgID).ToList();
                        }

                        if (incomplete.BranchList != null && incomplete.BranchList.Count() > 0)
                        {
                            incompleteCustomers = incompleteCustomers.Where(m => incomplete.BranchList.Contains(Convert.ToInt32(m.BranchID))).ToList();
                        }

                        if(incomplete.IncompleteType == SearchOptions.OwnerName)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.Name == null || i.Name == "").ToList();
                        }
                        if (incomplete.IncompleteType == SearchOptions.MobileNumber)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.MobileNumber == null || i.MobileNumber == "").ToList();
                        }
                        if (incomplete.IncompleteType == SearchOptions.City)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.CityID == null).ToList();
                        }
                        if (incomplete.IncompleteType == SearchOptions.State)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.StateID == null).ToList();
                        }
                        if (incomplete.IncompleteType == SearchOptions.AadhaarNumber)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.AadhaarNumber == null || i.AadhaarNumber == "").ToList();
                        }
                        if (incomplete.IncompleteType == SearchOptions.BillingAddress)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.BillingAddress == null || i.BillingAddress == "").ToList();
                        }
                        if (incomplete.IncompleteType == SearchOptions.GPSLocation)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.GPSLocation == null || i.GPSLocation == "").ToList();
                        }
                        if (incomplete.IncompleteType == SearchOptions.GSTNumber)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.GSTNumber == null || i.GSTNumber == "").ToList();
                        }
                        if (incomplete.IncompleteType == SearchOptions.PANNumber)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.PANNumber == null || i.PANNumber == "").ToList();
                        }
                        if (incomplete.IncompleteType == SearchOptions.ShippingAddress)
                        {
                            incompleteCustomers = incompleteCustomers.Where(i => i.ShippingAddress == null || i.ShippingAddress == "").ToList();
                        }
                        return incompleteCustomers;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return null;
            }
        }
    }
    public class IncompleteCustomers
    {
        public int ID { get; set; }
        public string CustID { get; set; }
        public string OrgID { get; set; }
        public string BranchID { get; set; }
        public string FirmName { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string RoleName { get; set; }
        public int[] BranchList { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int[] CategoryTypeList { get; set; }
        public int[] CompanyTypeList { get; set; }
        public SearchOptions IncompleteType { get; set; }
        public bool IsChecked { get; set; }
        public int? CityID { get; set; }
        public int? StateID { get; set; }
        public string AadhaarNumber { get; set; }
        public string PANNumber { get; set; }
        public string GSTNumber { get; set; }
        public string GPSLocation { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime CreationDate { get; set; }

    }
    public class IncompletePromotion
    {
        //public int TotalCategories { get; set; }
        //public int TotalStates { get; set; }
        //public int TotalCities { get; set; }
        //public int TotalCustomers { get; set; }
        public List<IncompleteCustomers> customerList { get; set; }
        public bool IsEmail { get; set; }
        public bool IsSMS { get; set; }
        public bool IsWhatsApp { get; set; }
        [Required(ErrorMessage = "Enter SMS body")]
        public string SMSBody { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Enter your message")]
        public string MailBody { get; set; }
        [Required(ErrorMessage = "Enter Mail Subject")]
        public string MailSubject { get; set; }
        public string RoleName { get; set; }
    }
    public enum SearchOptions
    {
        None,
        OwnerName,
        MobileNumber,
        City,
        State,
        AadhaarNumber,
        PANNumber,
        GSTNumber,
        GPSLocation,
        BillingAddress,
        ShippingAddress,
    }
}
