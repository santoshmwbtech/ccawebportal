using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.SqlServer.Server;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Web;
//using WBT.Entity;

namespace WBT.DLCustomerCreation
{

    public class BranchDetails
    {
        public String BranchID { get; set; }
        //[Required(ErrorMessage = "Select Channel Partner Type")]
        //public int ChannelTypeID { get; set; }
        //public int? ParentChannelPartnerID { get; set; }
        //public string ChannelType { get; set; }
        //public string ParentChannelPartner { get; set; }
        //[Required(ErrorMessage = "Select Associated To")]
        //public int? AssociatedTo { get; set; }
        //public string AssociatedToName { get; set; }
        //[Required(ErrorMessage = "Select Company")]
        //public int? BranchCompany { get; set; }
        [Required(ErrorMessage = "Select State")]
        public int? BranchState { get; set; }
        [Required(ErrorMessage = "Enter City Name")]
        public int? BranchCity { get; set; }

        [Required(ErrorMessage = "Enter Firm Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrgID { get; set; }
        [Required(ErrorMessage = "Telephone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter Contact Person Name")]
        public string ContactPerson { get; set; }
        public string Location { get; set; }
        [Required(ErrorMessage = "Select State")]
        public string State { get; set; }
        public string StateName { get; set; }

        [Required(ErrorMessage = "Enter City Name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter PinCode")]
        [Range(0, Int64.MaxValue, ErrorMessage = "PinCode should be a number")]
        public string PinCode { get; set; }

        [Required(ErrorMessage = "Enter Billing Landmark")]
        public string BillingLandmark { get; set; }
        [Required(ErrorMessage = "Enter Shipping Landmark")]
        public string ShippinLandmark { get; set; }
        [Required(ErrorMessage = "Enter Billing Address")]
        public string BillingAddress { get; set; }
        [Required(ErrorMessage = "Enter Website Address")]
        public string Website { get; set; }
        [Required(ErrorMessage = "Enter Email Id")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Mobile { get; set; }
        //[Required(ErrorMessage = "Enter Fax Number")]
        public string Fax { get; set; }
        [Required(ErrorMessage = "Enter Shipping Address")]
        public string ShippingAddress { get; set; }
        [Required(ErrorMessage = "Enter Mailing Name")]
        public string MailingName { get; set; }
        public string Address { get; set; }
        //[Required(ErrorMessage = "Enter Financial Year Start")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]

        public string FinancialYearStart { get; set; }
        //[Required(ErrorMessage = "Enter Financial Year End")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]

        public string FinancialYearEnd { get; set; }
        [Required(ErrorMessage = "Enter Bank Name")]
        public string BankName { get; set; }
        [Required(ErrorMessage = "Enter Bank Branch Name")]
        public string BankBranchName { get; set; }
        [Required(ErrorMessage = "Enter Bank City")]
        public string BankCity { get; set; }
        [Required(ErrorMessage = "Enter Alternate Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string AlternateNumber { get; set; }
        [Required(ErrorMessage = "Enter PinCode")]
        public string ShippingPinCode { get; set; }
        [Required(ErrorMessage = "Enter Account Number")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Enter IFSC Code")]
        [StringLength(11, ErrorMessage = "IFSCCode 11 digits.")]
        public string IFSCCode { get; set; }
        //[Required(ErrorMessage = "Enter FSSAI Code")]
        [StringLength(14, ErrorMessage = "FSSAICode 14 digits.")]
        public string FSSAICode { get; set; }

        [Required(ErrorMessage = "Enter GST")]
        [StringLength(15, ErrorMessage = "FSSAICode 14 digits.")]
        public string GST { get; set; }
        [Required(ErrorMessage = "Enter PAN Number")]
        [StringLength(10, ErrorMessage = "PANNumber 10 digits.")]
        public string PANNumber { get; set; }
        [Required(ErrorMessage = "Enter City")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string ShippingCity { get; set; }
        [Required(ErrorMessage = "Enter State")]
        public string ShippingState { get; set; }
        public string IsMappedToOrg { get; set; }
        public string MappedOrgID { get; set; }
        public int CreatedByID { get; set; }
        public string CreatedDatetime { get; set; }
        public string CompanyName { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedDatetime { get; set; }
        public int ModifiedByID { get; set; }
        public string SourceOfUpdate { get; set; }
        public string[] ParentChannelPartnerList { get; set; }
        public List<HttpPostedFileBase> DocumentFiles { get; set; }
        public List<string> Documents { get; set; }

        public List<QRDocs> qrDocs { get; set; }
        public string QRCodes { get; set; }
    }

    public class QRDocs
    {
        public string BranchID { get; set; }
        public string DocumentType { get; set; }
        //public string DocumentNumber { get; set; }
        public HttpPostedFileBase DocFile { get; set; }
        public string DocBase64 { get; set; }
        //public string ExpiryDate { get; set; }
        public string Base64Str { get; set; }
    }

    public class DLBranchCreation
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<BranchDetails> GetBranchDetailsList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    List<BranchDetails> BranchDetailsList = new List<BranchDetails>();
                    BranchDetailsList = (from u in dbContext.tblSysBranches
                                         where u.OrgID == OrgID
                                         orderby u.BranchID descending
                                         select new BranchDetails
                                         {
                                             BranchID = u.BranchID,
                                             Name = u.Name,
                                             BankName = u.BankName,
                                             Description = u.Description,
                                             OrgID = u.OrgID,
                                             Phone = u.Phone,
                                             ContactPerson = u.ContactPerson,
                                             Location = u.Location,
                                             State = u.State,
                                             StateName = dbContext.tblStates.Where(s => s.StateID.ToString() == u.State).FirstOrDefault().StateName,
                                             City = u.City,
                                             PinCode = u.PinCode,
                                             BillingLandmark = u.BillingLandmark,
                                             Website = u.Website,
                                             Email = u.Email,
                                             Mobile = u.Mobile,
                                             Fax = u.Fax,
                                             ShippingAddress = u.ShippingAddress,
                                             MailingName = u.MailingName,
                                             Address = u.Address,
                                             //FinancialYearStart = SqlFunctions.DateName("day", u.FinancialYearStart) + "/" + SqlFunctions.StringConvert((double)u.FinancialYearStart.Value.Month).TrimStart() + "/" + SqlFunctions.DateName("year", u.FinancialYearStart),
                                             //FinancialYearEnd = SqlFunctions.DateName("day", u.FinancialYearEnd) + "/" + SqlFunctions.StringConvert((double)u.FinancialYearEnd.Value.Month).TrimStart() + "/" + SqlFunctions.DateName("year", u.FinancialYearEnd),
                                             BankBranchName = u.BankBranchName,
                                             BillingAddress = u.BillingAddress,
                                             BankCity = u.BankCity,
                                             AlternateNumber = u.AlternateNumber,
                                             ShippingPinCode = u.ShippingPinCode,
                                             AccountNumber = u.AccountNumber,
                                             IFSCCode = u.IFSCCode,
                                             FSSAICode = u.FSSAICode,
                                             GST = u.GST,
                                             PANNumber = u.PANNumber,
                                             ShippingCity = u.ShippingCity,
                                             ShippingState = u.ShippingState,
                                             MappedOrgID = u.MappedOrgID,
                                             CreatedByID = u.CreatedByID,
                                             UpdatedBy = u.UpdatedBy,
                                             BranchCity = u.BranchCity.Value,
                                             //BranchCompany = u.BranchCompany,
                                             BranchState = u.BranchState,
                                         }).OrderByDescending(u => u.BranchID).ToList();

                    foreach (var item in BranchDetailsList)
                    {
                        var qrcodes = Entities.tblBranchDocuments.Where(q => q.BranchID == item.BranchID).ToList();
                        if(qrcodes != null && qrcodes.Count() > 0)
                        {
                            List<string> qrCodes = qrcodes.Select(q => q.DocumentType).ToList();
                            item.QRCodes = String.Join(",", qrCodes);
                        }
                    }
                    return BranchDetailsList;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public BranchDetails GetBranchDetail(string BranchID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {

                    BranchDetails branchDetails = new BranchDetails();
                    string[] ParentChannelPartnerList = Entities.tblChannelPartnerMappings.Where(p => p.ChannelPartnerId == BranchID).Select(x => x.ParentChannelPartnerId).ToArray();

                    branchDetails = (from u in dbContext.tblSysBranches
                                     where u.BranchID == BranchID
                                     select new BranchDetails
                                     {
                                         BankName = u.BankName,
                                         Name = u.Name,
                                         Description = u.Description,
                                         OrgID = u.OrgID,
                                         Phone = u.Phone,
                                         ContactPerson = u.ContactPerson,
                                         Location = u.Location,
                                         State = u.State,
                                         City = u.City,
                                         PinCode = u.PinCode,
                                         BillingLandmark = u.BillingLandmark,
                                         Website = u.Website,
                                         Email = u.Email,
                                         Mobile = u.Mobile,
                                         Fax = u.Fax,
                                         ShippingAddress = u.ShippingAddress,
                                         ShippinLandmark = u.ShippingLandmark,
                                         MailingName = u.MailingName,
                                         Address = u.Address,
                                         //FinancialYearStart = SqlFunctions.DateName("day", u.FinancialYearStart) + "/" + SqlFunctions.StringConvert((double)u.FinancialYearStart.Value.Month).TrimStart() + "/" + SqlFunctions.DateName("year", u.FinancialYearStart),
                                         //FinancialYearEnd = SqlFunctions.DateName("day", u.FinancialYearEnd) + "/" + SqlFunctions.StringConvert((double)u.FinancialYearEnd.Value.Month).TrimStart() + "/" + SqlFunctions.DateName("year", u.FinancialYearEnd),
                                         BankBranchName = u.BankBranchName,
                                         BillingAddress = u.BillingAddress,
                                         BankCity = u.BankCity,
                                         AlternateNumber = u.AlternateNumber,
                                         ShippingPinCode = u.ShippingPinCode,
                                         AccountNumber = u.AccountNumber,
                                         IFSCCode = u.IFSCCode,
                                         FSSAICode = u.FSSAICode,
                                         GST = u.GST,
                                         PANNumber = u.PANNumber,
                                         ShippingCity = u.ShippingCity,
                                         ShippingState = u.ShippingState,
                                         MappedOrgID = u.MappedOrgID,
                                         CreatedByID = u.CreatedByID,
                                         UpdatedBy = u.UpdatedBy,
                                         BranchCity = u.BranchCity,
                                         //BranchCompany = u.BranchCompany,
                                         BranchState = u.BranchState == null ? 0 : u.BranchState.Value,
                                         Documents = dbContext.tblSPDocuments.Where(sp => sp.SalesPartnerID == BranchID).Select(sps => sps.DocumentData).ToList(),
                                     }).FirstOrDefault();

                    branchDetails.qrDocs = (from d in Entities.tblBranchDocuments
                                            where d.BranchID == BranchID
                                            select new QRDocs
                                            {
                                                BranchID = d.BranchID.ToString(),
                                                DocBase64 = d.DocumentData,
                                                DocumentType = d.DocumentType,
                                                Base64Str = d.DocumentData
                                            }).ToList();


                    branchDetails.ParentChannelPartnerList = ParentChannelPartnerList;
                    for (int i = 0; i < branchDetails.Documents.Count(); i++)
                    {
                        branchDetails.Documents[i] = string.Format("data:image/png;base64,{0}", branchDetails.Documents[i]);
                    }

                    if (branchDetails.qrDocs != null && branchDetails.qrDocs.Count() > 0)
                    {
                        foreach (var item in branchDetails.qrDocs)
                        {
                            item.DocBase64 = string.Format("data:image/png;base64,{0}", item.DocBase64);
                        }
                    }

                    return branchDetails;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public bool SaveBranch(BranchDetails branchDetails, string UserID, string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    var IsExists = dbContext.tblSysBranches.AsNoTracking().Where(p => p.BranchID == branchDetails.BranchID).FirstOrDefault();
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    if (IsExists != null)
                    {
                        tblSysBranch tblSysBranch = new tblSysBranch();
                        tblSysBranch.BranchID = IsExists.BranchID;
                        tblSysBranch.Name = branchDetails.Name;
                        tblSysBranch.Description = "null";
                        tblSysBranch.OrgID = OrgID;
                        tblSysBranch.Phone = branchDetails.Phone;
                        tblSysBranch.ContactPerson = branchDetails.ContactPerson;
                        tblSysBranch.Location = "null";
                        tblSysBranch.State = branchDetails.State;
                        tblSysBranch.City = branchDetails.City;
                        tblSysBranch.PinCode = branchDetails.PinCode;
                        tblSysBranch.BillingLandmark = branchDetails.BillingLandmark;
                        tblSysBranch.ShippingLandmark = branchDetails.ShippinLandmark;
                        tblSysBranch.BillingAddress = branchDetails.BillingAddress;
                        tblSysBranch.Website = branchDetails.Website;
                        tblSysBranch.Email = branchDetails.Email;
                        tblSysBranch.Mobile = branchDetails.Mobile;
                        tblSysBranch.Fax = branchDetails.Fax;
                        tblSysBranch.ShippingAddress = branchDetails.ShippingAddress;
                        tblSysBranch.MailingName = branchDetails.MailingName;
                        tblSysBranch.Address = "null";

                        //DateTime financialYearStart = DateTime.ParseExact(branchDetails.FinancialYearStart, "d/M/yyyy", CultureInfo.InvariantCulture);
                        //tblSysBranch.FinancialYearStart = financialYearStart;
                        //DateTime financialYearEnd = DateTime.ParseExact(branchDetails.FinancialYearEnd, "d/M/yyyy", CultureInfo.InvariantCulture);
                        //tblSysBranch.FinancialYearEnd = financialYearEnd;

                        tblSysBranch.BankName = branchDetails.BankName;
                        tblSysBranch.BankBranchName = branchDetails.BankBranchName;
                        tblSysBranch.BankCity = branchDetails.BankCity;
                        tblSysBranch.AlternateNumber = branchDetails.AlternateNumber;
                        tblSysBranch.ShippingPinCode = branchDetails.ShippingPinCode;
                        tblSysBranch.AccountNumber = branchDetails.AccountNumber;
                        tblSysBranch.IFSCCode = branchDetails.IFSCCode;
                        tblSysBranch.FSSAICode = branchDetails.FSSAICode;
                        tblSysBranch.GST = branchDetails.GST;
                        tblSysBranch.PANNumber = branchDetails.PANNumber;
                        tblSysBranch.ShippingCity = branchDetails.ShippingCity;
                        tblSysBranch.ShippingState = branchDetails.ShippingState;
                        tblSysBranch.IsMappedToOrg = Convert.ToBoolean(1);
                        tblSysBranch.MappedOrgID = "";

                        tblSysBranch.CreatedByID = IsExists.CreatedByID;
                        tblSysBranch.CreatedDatetime = IsExists.CreatedDatetime;
                        tblSysBranch.UpdatedBy = Convert.ToInt16(branchDetails.UpdatedBy);
                        tblSysBranch.UpdatedDatetime = DateTime.Now;
                        tblSysBranch.ModifiedByID = Convert.ToInt32(UserID);
                        tblSysBranch.SourceOfUpdate = "";

                        //tblSysBranch.BranchCompany = branchDetails.BranchCompany;
                        tblSysBranch.BranchCity = branchDetails.BranchCity;
                        tblSysBranch.BranchState = branchDetails.BranchState;

                        if (branchDetails.ParentChannelPartnerList != null && branchDetails.ParentChannelPartnerList.Count() > 0)
                        {
                            var Mappings = dbContext.tblChannelPartnerMappings.Where(cp => cp.ChannelPartnerId == IsExists.BranchID).ToList();
                            dbContext.tblChannelPartnerMappings.RemoveRange(Mappings);
                            dbContext.SaveChanges();

                            foreach (var item in branchDetails.ParentChannelPartnerList)
                            {
                                tblChannelPartnerMapping tblChannelPartner = new tblChannelPartnerMapping();
                                tblChannelPartner.ChannelPartnerId = IsExists.BranchID;
                                tblChannelPartner.ParentChannelPartnerId = item.ToString();
                                tblChannelPartner.CreatedDate = DateTimeNow;
                                tblChannelPartner.CreateddBy = Convert.ToInt32(UserID);
                                dbContext.tblChannelPartnerMappings.Add(tblChannelPartner);

                            }
                        }

                        //if(branchDetails.Documents != null && branchDetails.Documents.Count() > 0)
                        //{
                        //    var isValueExists = dbContext.tblSPDocuments.AsNoTracking().Where(sp => sp.SalesPartnerID == IsExists.BranchID).ToList();
                        //    if (isValueExists != null)
                        //    {
                        //        dbContext.tblSPDocuments.RemoveRange(dbContext.tblSPDocuments.Where(u => u.SalesPartnerID == IsExists.BranchID));
                        //    }

                        //    foreach (var item in branchDetails.Documents)
                        //    {
                        //        tblSPDocument sPDocument = new tblSPDocument();
                        //        sPDocument.SalesPartnerID = IsExists.BranchID;
                        //        sPDocument.DocumentName = "Other Document";
                        //        sPDocument.DocumentData = item;
                        //        sPDocument.CreatedBy = Convert.ToInt32(UserID);
                        //        sPDocument.CreatedDate = DateTimeNow;
                        //        dbContext.tblSPDocuments.Add(sPDocument);
                        //    }
                        //}


                        //////// QR Code Branch Code
                        if (branchDetails.qrDocs != null && branchDetails.qrDocs.Count() > 0)
                        {
                            var isValueExists = dbContext.tblBranchDocuments.AsNoTracking().Where(sp => sp.BranchID == IsExists.BranchID).ToList();
                            if (isValueExists != null)
                            {
                                dbContext.tblBranchDocuments.RemoveRange(dbContext.tblBranchDocuments.Where(u => u.BranchID == IsExists.BranchID));
                            }
                            foreach (var item in branchDetails.qrDocs)
                            {
                                tblBranchDocument branchDocument = new tblBranchDocument();
                                branchDocument.BranchID = IsExists.BranchID;
                                branchDocument.OrgID = OrgID;
                                branchDocument.DocumentType = item.DocumentType;
                                branchDocument.DocumentData = item.DocBase64;
                                branchDocument.CreatedBy = Convert.ToInt32(UserID);
                                branchDocument.CreatedDate = DateTimeNow;
                                dbContext.tblBranchDocuments.Add(branchDocument);
                            }
                        }

                        dbContext.tblSysBranches.Add(tblSysBranch);
                        dbContext.Entry(tblSysBranch).State = EntityState.Modified;
                        dbContext.SaveChanges();


                    }
                    else
                    {
                        tblSysBranch tblSysBranch = new tblSysBranch();
                        //var PreviousBranchID = (from u in dbContext.tblSysBranches orderby u.BranchID descending select u.BranchID).Max();
                        var PreviousBranchID = dbContext.tblSysBranches.Count();
                        int NewBranchID = 0;

                        NewBranchID = Convert.ToInt32(PreviousBranchID) + 1;
                        tblSysBranch.BranchID = NewBranchID.ToString();
                        tblSysBranch.Name = branchDetails.Name;
                        tblSysBranch.Description = "null";
                        tblSysBranch.OrgID = OrgID;
                        tblSysBranch.Phone = branchDetails.Phone;
                        tblSysBranch.ContactPerson = branchDetails.ContactPerson;
                        tblSysBranch.Location = "null";
                        tblSysBranch.State = branchDetails.State;
                        tblSysBranch.City = branchDetails.City;
                        tblSysBranch.PinCode = branchDetails.PinCode;
                        tblSysBranch.BillingLandmark = branchDetails.BillingLandmark;
                        tblSysBranch.ShippingLandmark = branchDetails.ShippinLandmark;
                        tblSysBranch.BillingAddress = branchDetails.BillingAddress;
                        tblSysBranch.Website = branchDetails.Website;
                        tblSysBranch.Email = branchDetails.Email;
                        tblSysBranch.Mobile = branchDetails.Mobile;
                        tblSysBranch.Fax = branchDetails.Fax;
                        tblSysBranch.ShippingAddress = branchDetails.ShippingAddress;
                        tblSysBranch.MailingName = branchDetails.MailingName;
                        tblSysBranch.Address = "null";

                        //DateTime financialYearStart = DateTime.ParseExact(branchDetails.FinancialYearStart, "d/M/yyyy", CultureInfo.InvariantCulture);
                        //obj.FinancialYearStart = financialYearStart;
                        //DateTime financialYearEnd = DateTime.ParseExact(branchDetails.FinancialYearEnd, "d/M/yyyy", CultureInfo.InvariantCulture);
                        //obj.FinancialYearEnd = financialYearEnd;
                        tblSysBranch.BankName = branchDetails.BankName;
                        tblSysBranch.BankBranchName = branchDetails.BankBranchName;
                        tblSysBranch.BankCity = branchDetails.BankCity;
                        tblSysBranch.AlternateNumber = branchDetails.AlternateNumber;
                        tblSysBranch.ShippingPinCode = branchDetails.ShippingPinCode;
                        tblSysBranch.AccountNumber = branchDetails.AccountNumber;
                        tblSysBranch.IFSCCode = branchDetails.IFSCCode;
                        tblSysBranch.FSSAICode = branchDetails.FSSAICode;
                        tblSysBranch.GST = branchDetails.GST;
                        tblSysBranch.PANNumber = branchDetails.PANNumber;
                        tblSysBranch.ShippingCity = branchDetails.ShippingCity;
                        tblSysBranch.ShippingState = branchDetails.ShippingState;
                        tblSysBranch.IsMappedToOrg = Convert.ToBoolean(1);
                        tblSysBranch.MappedOrgID = "";

                        tblSysBranch.CreatedByID = Convert.ToInt32(UserID);
                        tblSysBranch.CreatedDatetime = DateTime.Now;
                        tblSysBranch.UpdatedBy = Convert.ToInt32(UserID);
                        tblSysBranch.UpdatedDatetime = DateTime.Now;
                        tblSysBranch.ModifiedByID = Convert.ToInt32(UserID);
                        tblSysBranch.SourceOfUpdate = "";

                        //if (branchDetails.ParentChannelPartnerList != null && branchDetails.ParentChannelPartnerList.Count() > 0)
                        //{
                        //    foreach (var item in branchDetails.ParentChannelPartnerList)
                        //    {
                        //        tblChannelPartnerMapping tblChannelPartner = new tblChannelPartnerMapping();
                        //        tblChannelPartner.ChannelPartnerId = NewBranchID.ToString();
                        //        tblChannelPartner.ParentChannelPartnerId = item.ToString();
                        //        tblChannelPartner.CreatedDate = DateTimeNow;
                        //        tblChannelPartner.CreateddBy = Convert.ToInt32(UserID);
                        //        dbContext.tblChannelPartnerMappings.Add(tblChannelPartner);
                        //    }
                        //}
                        //if (branchDetails.Documents != null && branchDetails.Documents.Count() > 0)
                        //{
                        //    foreach (var item in branchDetails.Documents)
                        //    {
                        //        tblSPDocument sPDocument = new tblSPDocument();
                        //        sPDocument.SalesPartnerID = NewBranchID.ToString();
                        //        sPDocument.DocumentName = "Other Document";
                        //        sPDocument.DocumentData = item;
                        //        sPDocument.CreatedBy = Convert.ToInt32(UserID);
                        //        sPDocument.CreatedDate = DateTimeNow;
                        //        dbContext.tblSPDocuments.Add(sPDocument);
                        //    }
                        //}

                        //////// QR Code Branch Code
                        if (branchDetails.qrDocs != null && branchDetails.qrDocs.Count() > 0)
                        {
                            foreach (var item in branchDetails.qrDocs)
                            {
                                tblBranchDocument brancDocument = new tblBranchDocument();
                                brancDocument.BranchID = NewBranchID.ToString();
                                brancDocument.OrgID = OrgID;
                                brancDocument.DocumentData = item.DocBase64;
                                brancDocument.DocumentType = item.DocumentType;
                                brancDocument.CreatedBy = Convert.ToInt32(UserID);
                                brancDocument.CreatedDate = DateTimeNow;
                                dbContext.tblBranchDocuments.Add(brancDocument);
                            }
                        }


                        //tblSysBranch.BranchCompany = branchDetails.BranchCompany;
                        tblSysBranch.BranchCity = branchDetails.BranchCity;
                        tblSysBranch.BranchState = branchDetails.BranchState;
                        dbContext.tblSysBranches.Add(tblSysBranch);
                        dbContext.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return false;
            }
        }
        public object GetAssociates(int? ChannelTypeID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        int ParentChannelTypeID = Entities.tblSalesChannelTypes.Where(s => s.ID == ChannelTypeID.Value).FirstOrDefault().ParentChannelType.Value;

                        var list = (from c in Entities.tblSalesChannelTypes
                                    where c.ParentChannelType != ChannelTypeID && c.ID != ChannelTypeID
                                    select new
                                    {
                                        label = c.ChannelType.ToLower() == "parent" ? "Company" : c.ChannelType,
                                        value = c.ID
                                    }).ToList();
                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<SalesChannelType> GetSalesChannelTypeList()
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    List<SalesChannelType> salesChannelTypes = new List<SalesChannelType>();
                    salesChannelTypes = (from u in dbContext.tblSalesChannelTypes
                                         where u.ChannelType.ToLower() != "parent"
                                         select new SalesChannelType
                                         {
                                             ID = u.ID,
                                             ChannelType = u.ChannelType.Trim(),
                                         }).ToList();

                    return salesChannelTypes;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<BranchDetails> GetChannelPartners(int? ChannelTypeID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<BranchDetails> PartnerList = (from c in Entities.tblSysBranches
                                                           where c.ChannelTypeID == ChannelTypeID
                                                           select new BranchDetails
                                                           {
                                                               BranchID = c.BranchID,
                                                               Name = c.Name
                                                           }).ToList();
                        return PartnerList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public object GetCities(int? StateID, string Name)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        if (!string.IsNullOrEmpty(Name))
                        {
                            var cityList = (from s in Entities.tblStateWithCities
                                            where s.VillageLocalityname.ToLower().Contains(Name.ToLower())
                                            select new
                                            {
                                                id = s.StatewithCityID,
                                                text = s.VillageLocalityname
                                            }).Distinct().ToList();
                            cityList = cityList.GroupBy(d => d.id).Select(i => i.FirstOrDefault()).ToList();
                            return cityList;
                        }
                        else
                        {
                            var cityList = (from s in Entities.tblStateWithCities
                                            select new
                                            {
                                                id = s.StatewithCityID,
                                                text = s.VillageLocalityname
                                            }).Distinct().Take(200).ToList();
                            cityList = cityList.GroupBy(d => d.id).Select(i => i.FirstOrDefault()).ToList();
                            return cityList;
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
        public string DeleteBranch(string BranchID, string OrgID, string UserID)
        {
            string Result = string.Empty;
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblSysBranches.AsNoTracking().Where(u => u.BranchID == BranchID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        Entities.tblSysBranches.Remove(Entities.tblSysBranches.Where(b => b.BranchID == BranchID).FirstOrDefault());
                        Entities.SaveChanges();
                        Result = "Branch Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result = "Can not delete Branch as it is being used in Other Departments";
                return Result;
            }
        }
    }
}
