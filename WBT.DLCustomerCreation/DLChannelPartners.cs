using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLChannelPartners
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<ChannelPartner> GetChannelPartnerList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    List<ChannelPartner> channelPartners = new List<ChannelPartner>();
                    channelPartners = (from u in dbContext.tblSysChannelPartners
                                       join c in dbContext.tblSalesChannelTypes on u.ChannelTypeID equals c.ID
                                       where u.OrgID == OrgID
                                       select new ChannelPartner
                                       {
                                           ChannelPartnerID = u.ChannelPartnerID,
                                           BranchID = u.BranchID,
                                           ChannelPartnerName = u.ChannelPartnerName,
                                           BankName = u.BankName,
                                           Description = u.Description,
                                           OrgID = u.OrgID,
                                           ParentChannelPartnerID = u.ParentChannelPartnerID == null ? 0 : u.ParentChannelPartnerID.Value,
                                           ParentChannelPartner = dbContext.tblSysChannelPartners.Where(b => b.ChannelPartnerID == u.ParentChannelPartnerID.Value.ToString()).FirstOrDefault().ChannelPartnerName,
                                           ChannelType = dbContext.tblSalesChannelTypes.Where(c => c.ID == u.ChannelTypeID).FirstOrDefault().ChannelType,
                                           AssociatedTo = u.AssociatedTo,
                                           AssociatedToName = dbContext.tblSalesChannelTypes.Where(c => c.ID == u.AssociatedTo).FirstOrDefault().ChannelType,
                                           ChannelTypeID = u.ChannelTypeID == null ? 0 : u.ChannelTypeID.Value,
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

                    return channelPartners;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public ChannelPartner GetChannelPartnerDetails(string ChannelPartnerID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {

                    ChannelPartner channelPartner = new ChannelPartner();
                    string[] ParentChannelPartnerList = Entities.tblChannelPartnerMappings.Where(p => p.ChannelPartnerId == ChannelPartnerID).Select(x => x.ParentChannelPartnerId).ToArray();

                    channelPartner = (from u in dbContext.tblSysChannelPartners
                                      where u.ChannelPartnerID == ChannelPartnerID
                                      select new ChannelPartner
                                      {
                                          ChannelPartnerID = u.ChannelPartnerID,
                                          BranchID = u.BranchID,
                                          BankName = u.BankName,
                                          ChannelPartnerName = u.ChannelPartnerName,
                                          Description = u.Description,
                                          OrgID = u.OrgID,
                                          ParentChannelPartnerID = u.ParentChannelPartnerID == null ? 0 : u.ParentChannelPartnerID.Value,
                                          ParentChannelPartner = dbContext.tblSysChannelPartners.Where(b => b.ChannelPartnerID == u.ParentChannelPartnerID.Value.ToString()).FirstOrDefault().ChannelPartnerName,
                                          ChannelType = dbContext.tblSalesChannelTypes.Where(c => c.ID == u.ChannelTypeID).FirstOrDefault().ChannelType,
                                          AssociatedTo = u.AssociatedTo,
                                          AssociatedToName = dbContext.tblSalesChannelTypes.Where(c => c.ID == u.AssociatedTo).FirstOrDefault().ChannelType,
                                          ChannelTypeID = u.ChannelTypeID == null ? 0 : u.ChannelTypeID.Value,
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
                                          FinancialYearStart = SqlFunctions.DateName("day", u.FinancialYearStart) + "/" + SqlFunctions.StringConvert((double)u.FinancialYearStart.Value.Month).TrimStart() + "/" + SqlFunctions.DateName("year", u.FinancialYearStart),
                                          FinancialYearEnd = SqlFunctions.DateName("day", u.FinancialYearEnd) + "/" + SqlFunctions.StringConvert((double)u.FinancialYearEnd.Value.Month).TrimStart() + "/" + SqlFunctions.DateName("year", u.FinancialYearEnd),
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
                                      }).FirstOrDefault();

                    channelPartner.ParentChannelPartnerList = ParentChannelPartnerList;

                    channelPartner.userDocs = (from d in Entities.tblSPDocuments
                                               where d.SalesPartnerID == ChannelPartnerID
                                               select new UserDocs
                                               {
                                                   UserID = d.SalesPartnerID.ToString(),
                                                   DocBase64 = d.DocumentData,
                                                   DocumentNumber = d.DocumentNumber,
                                                   DocumentType = d.DocumentType,
                                                   Base64Str = d.DocumentData
                                               }).ToList();

                    if (channelPartner.userDocs != null && channelPartner.userDocs.Count() > 0)
                    {
                        foreach (var item in channelPartner.userDocs)
                        {
                            item.DocBase64 = string.Format("data:image/png;base64,{0}", item.DocBase64);
                        }
                    }

                    return channelPartner;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public bool Save(ChannelPartner channelPartner, string UserID, string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    var IsExists = dbContext.tblSysChannelPartners.AsNoTracking().Where(p => p.ChannelPartnerID == channelPartner.ChannelPartnerID).FirstOrDefault();
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    if (IsExists != null)
                    {
                        tblSysChannelPartner tblSysChannelPartner = new tblSysChannelPartner();
                        tblSysChannelPartner.ChannelPartnerID = IsExists.ChannelPartnerID;
                        tblSysChannelPartner.BranchID = IsExists.BranchID;
                        tblSysChannelPartner.ChannelPartnerName = channelPartner.ChannelPartnerName;
                        tblSysChannelPartner.Description = "null";
                        tblSysChannelPartner.OrgID = OrgID;
                        tblSysChannelPartner.Phone = channelPartner.Phone;
                        tblSysChannelPartner.ContactPerson = channelPartner.ContactPerson;
                        tblSysChannelPartner.ChannelTypeID = channelPartner.ChannelTypeID;
                        tblSysChannelPartner.Location = "null";
                        tblSysChannelPartner.State = channelPartner.State;
                        tblSysChannelPartner.City = channelPartner.City;
                        tblSysChannelPartner.PinCode = channelPartner.PinCode;
                        tblSysChannelPartner.BillingLandmark = channelPartner.BillingLandmark;
                        tblSysChannelPartner.ShippingLandmark = channelPartner.ShippinLandmark;
                        tblSysChannelPartner.BillingAddress = channelPartner.BillingAddress;
                        tblSysChannelPartner.Website = channelPartner.Website;
                        tblSysChannelPartner.Email = channelPartner.Email;
                        tblSysChannelPartner.Mobile = channelPartner.Mobile;
                        tblSysChannelPartner.Fax = channelPartner.Fax;
                        tblSysChannelPartner.ShippingAddress = channelPartner.ShippingAddress;
                        tblSysChannelPartner.MailingName = channelPartner.MailingName;
                        tblSysChannelPartner.Address = "null";

                        //DateTime financialYearStart = DateTime.ParseExact(branchDetails.FinancialYearStart, "d/M/yyyy", CultureInfo.InvariantCulture);
                        //tblSysBranch.FinancialYearStart = financialYearStart;
                        //DateTime financialYearEnd = DateTime.ParseExact(branchDetails.FinancialYearEnd, "d/M/yyyy", CultureInfo.InvariantCulture);
                        //tblSysBranch.FinancialYearEnd = financialYearEnd;

                        tblSysChannelPartner.BankName = channelPartner.BankName;
                        tblSysChannelPartner.BankBranchName = channelPartner.BankBranchName;
                        tblSysChannelPartner.BankCity = channelPartner.BankCity;
                        tblSysChannelPartner.AlternateNumber = channelPartner.AlternateNumber;
                        tblSysChannelPartner.ShippingPinCode = channelPartner.ShippingPinCode;
                        tblSysChannelPartner.AccountNumber = channelPartner.AccountNumber;
                        tblSysChannelPartner.IFSCCode = channelPartner.IFSCCode;
                        tblSysChannelPartner.FSSAICode = channelPartner.FSSAICode;
                        tblSysChannelPartner.GST = channelPartner.GST;
                        tblSysChannelPartner.PANNumber = channelPartner.PANNumber;
                        tblSysChannelPartner.ShippingCity = channelPartner.ShippingCity;
                        tblSysChannelPartner.ShippingState = channelPartner.ShippingState;
                        tblSysChannelPartner.IsMappedToOrg = Convert.ToBoolean(1);
                        tblSysChannelPartner.MappedOrgID = "";

                        tblSysChannelPartner.CreatedByID = IsExists.CreatedByID;
                        tblSysChannelPartner.CreatedDatetime = IsExists.CreatedDatetime;
                        tblSysChannelPartner.UpdatedBy = Convert.ToInt16(channelPartner.UpdatedBy);
                        tblSysChannelPartner.UpdatedDatetime = DateTime.Now;
                        tblSysChannelPartner.ModifiedByID = Convert.ToInt32(UserID);
                        tblSysChannelPartner.SourceOfUpdate = "";
                        tblSysChannelPartner.ParentChannelPartnerID = channelPartner.ParentChannelPartnerID;
                        tblSysChannelPartner.AssociatedTo = channelPartner.AssociatedTo;
                        tblSysChannelPartner.ChannelTypeID = channelPartner.ChannelTypeID;

                        //tblSysChannelPartner.BranchCompany = branchDetails.BranchCompany;
                        tblSysChannelPartner.BranchCity = channelPartner.BranchCity;
                        tblSysChannelPartner.BranchState = channelPartner.BranchState;

                        if (channelPartner.ParentChannelPartnerList != null && channelPartner.ParentChannelPartnerList.Count() > 0)
                        {
                            var Mappings = dbContext.tblChannelPartnerMappings.Where(cp => cp.ChannelPartnerId == IsExists.ChannelPartnerID).ToList();
                            dbContext.tblChannelPartnerMappings.RemoveRange(Mappings);
                            dbContext.SaveChanges();

                            foreach (var item in channelPartner.ParentChannelPartnerList)
                            {
                                tblChannelPartnerMapping tblChannelPartner = new tblChannelPartnerMapping();
                                tblChannelPartner.ChannelPartnerId = IsExists.ChannelPartnerID;
                                tblChannelPartner.ParentChannelPartnerId = item.ToString();
                                tblChannelPartner.CreatedDate = DateTimeNow;
                                tblChannelPartner.CreateddBy = Convert.ToInt32(UserID);
                                tblChannelPartner.OrgID = OrgID;
                                dbContext.tblChannelPartnerMappings.Add(tblChannelPartner);
                            }
                        }

                        if (channelPartner.userDocs != null && channelPartner.userDocs.Count() > 0)
                        {
                            var isValueExists = dbContext.tblSPDocuments.AsNoTracking().Where(u => u.SalesPartnerID == channelPartner.ChannelPartnerID).ToList();
                            if (isValueExists != null)
                            {
                                dbContext.tblSPDocuments.RemoveRange(Entities.tblSPDocuments.Where(u => u.SalesPartnerID == channelPartner.ChannelPartnerID));
                            }
                            foreach (var item in channelPartner.userDocs)
                            {
                                tblSPDocument sPDocument = new tblSPDocument();
                                sPDocument.SalesPartnerID = channelPartner.ChannelPartnerID;
                                sPDocument.DocumentType = item.DocumentType;
                                sPDocument.DocumentNumber = item.DocumentNumber;
                                sPDocument.DocumentData = item.DocBase64;
                                sPDocument.CreatedDate = DateTimeNow;
                                sPDocument.CreatedBy = Convert.ToInt32(UserID);
                                sPDocument.OrgID = OrgID;
                                dbContext.tblSPDocuments.Add(sPDocument);
                            }
                        }

                        dbContext.tblSysChannelPartners.Add(tblSysChannelPartner);
                        dbContext.Entry(tblSysChannelPartner).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        tblSysChannelPartner tblSysChannelPartner = new tblSysChannelPartner();

                        var PreviousCPID = dbContext.tblSysChannelPartners.Count();
                        int NewCPID = 0;

                        NewCPID = Convert.ToInt32(PreviousCPID) + 1;
                        tblSysChannelPartner.ChannelPartnerID = NewCPID.ToString();
                        tblSysChannelPartner.BranchID = channelPartner.BranchID;
                        tblSysChannelPartner.ChannelPartnerName = channelPartner.ChannelPartnerName;
                        tblSysChannelPartner.Description = "null";
                        tblSysChannelPartner.ChannelTypeID = channelPartner.ChannelTypeID;
                        tblSysChannelPartner.ParentChannelPartnerID = channelPartner.ParentChannelPartnerID;
                        tblSysChannelPartner.OrgID = OrgID;
                        tblSysChannelPartner.Phone = channelPartner.Phone;
                        tblSysChannelPartner.ContactPerson = channelPartner.ContactPerson;
                        tblSysChannelPartner.Location = "null";
                        tblSysChannelPartner.State = channelPartner.State;
                        tblSysChannelPartner.City = channelPartner.City;
                        tblSysChannelPartner.PinCode = channelPartner.PinCode;
                        tblSysChannelPartner.BillingLandmark = channelPartner.BillingLandmark;
                        tblSysChannelPartner.ShippingLandmark = channelPartner.ShippinLandmark;
                        tblSysChannelPartner.BillingAddress = channelPartner.BillingAddress;
                        tblSysChannelPartner.Website = channelPartner.Website;
                        tblSysChannelPartner.Email = channelPartner.Email;
                        tblSysChannelPartner.Mobile = channelPartner.Mobile;
                        tblSysChannelPartner.Fax = channelPartner.Fax;
                        tblSysChannelPartner.ShippingAddress = channelPartner.ShippingAddress;
                        tblSysChannelPartner.MailingName = channelPartner.MailingName;
                        tblSysChannelPartner.Address = "null";

                        //DateTime financialYearStart = DateTime.ParseExact(branchDetails.FinancialYearStart, "d/M/yyyy", CultureInfo.InvariantCulture);
                        //obj.FinancialYearStart = financialYearStart;
                        //DateTime financialYearEnd = DateTime.ParseExact(branchDetails.FinancialYearEnd, "d/M/yyyy", CultureInfo.InvariantCulture);
                        //obj.FinancialYearEnd = financialYearEnd;
                        tblSysChannelPartner.BankName = channelPartner.BankName;
                        tblSysChannelPartner.BankBranchName = channelPartner.BankBranchName;
                        tblSysChannelPartner.BankCity = channelPartner.BankCity;
                        tblSysChannelPartner.AlternateNumber = channelPartner.AlternateNumber;
                        tblSysChannelPartner.ShippingPinCode = channelPartner.ShippingPinCode;
                        tblSysChannelPartner.AccountNumber = channelPartner.AccountNumber;
                        tblSysChannelPartner.IFSCCode = channelPartner.IFSCCode;
                        tblSysChannelPartner.FSSAICode = channelPartner.FSSAICode;
                        tblSysChannelPartner.GST = channelPartner.GST;
                        tblSysChannelPartner.PANNumber = channelPartner.PANNumber;
                        tblSysChannelPartner.ShippingCity = channelPartner.ShippingCity;
                        tblSysChannelPartner.ShippingState = channelPartner.ShippingState;
                        tblSysChannelPartner.IsMappedToOrg = Convert.ToBoolean(1);
                        tblSysChannelPartner.MappedOrgID = "";
                        tblSysChannelPartner.ParentChannelPartnerID = channelPartner.ParentChannelPartnerID;
                        tblSysChannelPartner.AssociatedTo = channelPartner.AssociatedTo;
                        tblSysChannelPartner.ChannelTypeID = channelPartner.ChannelTypeID;

                        tblSysChannelPartner.CreatedByID = Convert.ToInt32(UserID);
                        tblSysChannelPartner.CreatedDatetime = DateTime.Now;
                        tblSysChannelPartner.UpdatedBy = Convert.ToInt32(UserID);
                        tblSysChannelPartner.UpdatedDatetime = DateTime.Now;
                        tblSysChannelPartner.ModifiedByID = Convert.ToInt32(UserID);
                        tblSysChannelPartner.SourceOfUpdate = "";

                        if (channelPartner.ParentChannelPartnerList != null && channelPartner.ParentChannelPartnerList.Count() > 0)
                        {
                            foreach (var item in channelPartner.ParentChannelPartnerList)
                            {
                                tblChannelPartnerMapping tblChannelPartner = new tblChannelPartnerMapping();
                                tblChannelPartner.ChannelPartnerId = NewCPID.ToString();
                                tblChannelPartner.ParentChannelPartnerId = item.ToString();
                                tblChannelPartner.CreatedDate = DateTimeNow;
                                tblChannelPartner.CreateddBy = Convert.ToInt32(UserID);
                                dbContext.tblChannelPartnerMappings.Add(tblChannelPartner);
                            }
                        }

                        if (channelPartner.userDocs != null && channelPartner.userDocs.Count() > 0)
                        {
                            var isValueExists = dbContext.tblSPDocuments.AsNoTracking().Where(u => u.SalesPartnerID == channelPartner.ChannelPartnerID).ToList();
                            if (isValueExists != null)
                            {
                                dbContext.tblSPDocuments.RemoveRange(Entities.tblSPDocuments.Where(u => u.SalesPartnerID == channelPartner.ChannelPartnerID));
                            }
                            foreach (var item in channelPartner.userDocs)
                            {
                                tblSPDocument sPDocument = new tblSPDocument();
                                sPDocument.SalesPartnerID = NewCPID.ToString();
                                sPDocument.DocumentType = item.DocumentType;
                                sPDocument.DocumentNumber = item.DocumentNumber;
                                sPDocument.DocumentData = item.DocBase64;
                                sPDocument.CreatedDate = DateTimeNow;
                                sPDocument.CreatedBy = Convert.ToInt32(UserID);
                                sPDocument.OrgID = OrgID;
                                dbContext.tblSPDocuments.Add(sPDocument);
                            }
                        }

                        //tblSysBranch.BranchCompany = branchDetails.BranchCompany;
                        tblSysChannelPartner.BranchCity = channelPartner.BranchCity;
                        tblSysChannelPartner.BranchState = channelPartner.BranchState;
                        dbContext.tblSysChannelPartners.Add(tblSysChannelPartner);
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
                        if (ChannelTypeID != null)
                        {
                            //int ParentChannelTypeID = Entities.tblSalesChannelTypes.Where(s => s.ID == ChannelTypeID.Value).FirstOrDefault().ParentChannelType.Value;

                            var list = (from c in Entities.tblSalesChannelTypes
                                        select new
                                        {
                                            label = c.ChannelType,
                                            value = c.ID
                                        }).ToList();
                            return list;
                        }
                        else
                        {
                            return null;
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
        public List<SalesChannelType> GetChannelTypeList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    List<SalesChannelType> salesChannelTypes = new List<SalesChannelType>();
                    salesChannelTypes = (from u in dbContext.tblSalesChannelTypes
                                         where u.IsParent == false
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
        public List<ChannelPartner> GetChannelPartners(int? ChannelTypeID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<ChannelPartner> PartnerList = (from c in Entities.tblSysChannelPartners
                                                            where c.ChannelTypeID == ChannelTypeID
                                                            select new ChannelPartner
                                                            {
                                                                ChannelPartnerID = c.ChannelPartnerID,
                                                                ChannelPartnerName = c.ChannelPartnerName
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
        public string DeleteChannelPartner(string ChannelPartnerID, string OrgID, string UserID)
        {
            string Result = string.Empty;
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblSysChannelPartners.AsNoTracking().Where(u => u.ChannelPartnerID == ChannelPartnerID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        Entities.tblSysChannelPartners.Remove(Entities.tblSysChannelPartners.Where(r => r.ChannelPartnerID == ChannelPartnerID).FirstOrDefault());
                        Entities.SaveChanges();
                        Result = "Channel Partner Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result = "Can not delete Channel Partner as it is being used by other departments";
                return Result;
            }
        }
    }
    public class ChannelPartner
    {
        public String ChannelPartnerID { get; set; }
        [Required(ErrorMessage = "Select Branch")]
        public String BranchID { get; set; }
        [Required(ErrorMessage = "Select Channel Partner Type")]
        public int ChannelTypeID { get; set; }
        public int? ParentChannelPartnerID { get; set; }
        public string ChannelType { get; set; }
        public string ParentChannelPartner { get; set; }
        [Required(ErrorMessage = "Select Associated To")]
        public int? AssociatedTo { get; set; }
        public string AssociatedToName { get; set; }
        //[Required(ErrorMessage = "Select Company")]
        public int? BranchCompany { get; set; }
        [Required(ErrorMessage = "Select State")]
        public int? BranchState { get; set; }
        [Required(ErrorMessage = "Enter City Name")]
        public int? BranchCity { get; set; }

        [Required(ErrorMessage = "Enter Firm Name")]
        public string ChannelPartnerName { get; set; }
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
        //[Required(ErrorMessage = "Enter Website Address")]
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
        //[Required(ErrorMessage = "Enter Alternate Number")]
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
        [Required(ErrorMessage = "Enter FSSAI Code")]
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
        public List<UserDocs> userDocs { get; set; }
    }
}
