using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class Receipts
    {
        public int ID { get; set; }
        public Nullable<decimal> Credit { get; set; }
        public Nullable<decimal> Debit { get; set; }

        public string ReceiptID { get; set; }
        public string CustID { get; set; }
        public string OrgID { get; set; }
        public string OrgName { get; set; }
        public string BranchID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string FormattedDate
        {
            get
            {
                return string.Format("{0:dd-MM-yyyy}", Date);
            }
        }
        public string CustomerName { get; set; }
        // public string ReceiptNo { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string BankOrCash { get; set; }
        public string PaymentType { get; set; }
        public List<DLReceiptsBillDetailsCreation> ListReceiptWithBillDetail { get; set; }
        //public string MobileNumber { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int CreatedByID { get; set; }
        public string VoucherTypeName { get; set; }
        public string VoucherTypeNo { get; set; }
        public Nullable<DateTime> ReceiptDatetime { get; set; }
        public string ReceiptDateStr { get; set; }
        public string SalesManID { get; set; }
        public string BankName { get; set; }
        public string SignatureImage { get; set; }
        public string RecieverSignatureImage { get; set; }
        public string ReferenceImage { get; set; }
        public string Comments { get; set; }
        public string SourceOfUpdate { get; set; }
        public string CustLocation { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string LedgerID { get; set; }
        public string LedgerName { get; set; }
        public string BranchName { get; set; }
        public string IFSC { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionNumber { get; set; }
        public string Status { get; set; }
        public Nullable<bool> IsTallyUpdates { get; set; }
        public Nullable<System.DateTime> CheckDate { get; set; }
        public System.Guid ReceiptWithBillID { get; set; }
        public string BankOrCashName { get; set; }
        public string OwnerName { get; set; }
        public string DisplayMessage { get; set; }
        public bool IsTallyUpdated { get; set; }
        public bool TallySync { get; set; }
        public string SysBranchName { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public List<DLReceiptsBillDetailsCreation> DLReceiptsBillDetailsCreation { get; set; }
        public List<Receipts> ReceiptsList = new List<Receipts>();
        public List<DLReceiptsBillDetailsCreation> ReceiptsDetails { get; set; }
        public bool IsChecked { get; set; }
        public int[] BranchList { get; set; }
        public int[] StateList { get; set; }
        public int[] DistrictList { get; set; }
        public int[] CityList { get; set; }
        public string[] AreaList { get; set; }
        public int[] CustomerTypeList { get; set; }

        public static explicit operator List<object>(Receipts v)
        {
            throw new NotImplementedException();
        }
        public int[] CompanyTypeList { get; set; }
        public int[] TaxationTypeList { get; set; }
        public int[] salesmanList { get; set; }
        public int? LedgerTypeID { get; set; }

        public int? stateID { get; set; }
        public int? cityID { get; set; }
        public int? districtID { get; set; }
        public string area { get; set; }
        public int? companyTypeID { get; set; }
        public int? customerType { get; set; }
        public string TallyStatus { get; set; }
        public bool IsEdited { get; set; }

        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public List<Receipts> GetReceipts(Receipts search)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<Receipts> rLists = (from rd in Entities.tblAccountReceiptDetails
                                             join rdl in Entities.tblAccountReceiptWithBillDetails on rd.ReceiptID equals rdl.ReceiptID
                                             join c in Entities.tblCustomerVendorDetails on rdl.CustID equals c.CustID
                                             where rd.OrgID == search.OrgID
                                             select new Receipts
                                             {
                                                 CustID = Entities.tblAccountReceiptWithBillDetails.Where(r => r.ReceiptID == rd.ReceiptID).FirstOrDefault().CustID,    // rdwb.CustID,
                                                 OrgID = rd.OrgID,
                                                 Date = rd.ReceiptDatetime,
                                                 ReceiptID = rd.ReceiptID,
                                                 Amount = rd.Amount,
                                                 CustomerName = c.FirmName,

                                                 stateID = c.StateID,

                                                 districtID = Entities.tblStateWithCities.Where(ct => ct.StatewithCityID == c.CityID).FirstOrDefault().DistrictID,

                                                 cityID = c.CityID,

                                                 area = c.BillingArea,

                                                 companyTypeID = c.CompanyTypeID,

                                                 customerType = c.CustomerTypeID,
                                                 TallyStatus = rd.IsTallyUpdates == true ? "Yes" : "No",
                                                 IsTallyUpdated = rd.IsTallyUpdates.Value,
                                                 TallySync = rd.TallySync == null ? false : rd.TallySync.Value,
                                                 SalesManID = rd.SalesManID,
                                                 BranchName = Entities.tblSysBranches.Where(br => br.BranchID == rd.BranchID).FirstOrDefault().Name,
                                                 BranchID = rd.BranchID
                                             }).ToList();

                    rLists = rLists.GroupBy(ac => new
                    {
                        ac.ReceiptID
                    }).Select(bv => new Receipts
                    {
                        CustID = bv.FirstOrDefault().CustID,
                        ReceiptID = bv.FirstOrDefault().ReceiptID,
                        BranchID= bv.FirstOrDefault().BranchID,
                        area = bv.FirstOrDefault().area,
                        OrgID = bv.FirstOrDefault().OrgID,
                        Date = bv.FirstOrDefault().Date,
                        Amount = bv.FirstOrDefault().Amount,
                        CustomerName = bv.FirstOrDefault().CustomerName,
                        stateID = bv.FirstOrDefault().stateID,
                        districtID = bv.FirstOrDefault().districtID,
                        cityID = bv.FirstOrDefault().cityID,
                        companyTypeID = bv.FirstOrDefault().companyTypeID,
                        customerType = bv.FirstOrDefault().customerType,
                        TallyStatus = bv.FirstOrDefault().TallyStatus,
                        IsTallyUpdated = bv.FirstOrDefault().IsTallyUpdated,
                        TallySync = bv.FirstOrDefault().TallySync,
                        SalesManID = bv.FirstOrDefault().SalesManID,
                        BranchName = bv.FirstOrDefault().BranchName,
                    }).ToList();


                    if (!string.IsNullOrEmpty(search.ReceiptID) && !string.IsNullOrEmpty(search.ReceiptID))
                    {
                        rLists = rLists.Where(m => m.ReceiptID.ToString().ToLower() == search.ReceiptID.ToLower()).ToList();
                    }

                    if (search.BranchList != null && search.BranchList.Count() > 0)
                    {
                        rLists = rLists.Where(m => search.BranchList.Contains(Convert.ToInt32(m.BranchID))).ToList();
                    }

                    if (search.salesmanList != null && search.salesmanList.Count() > 0)
                    {
                        rLists = rLists.Where(m => search.salesmanList.Contains(Convert.ToInt32(m.SalesManID))).ToList();
                    }

                    if (!string.IsNullOrEmpty(search.CustomerName) && !string.IsNullOrEmpty(search.CustomerName))
                    {
                        rLists = rLists.Where(m => m.CustomerName.ToLower().Contains(search.CustomerName.ToLower())).ToList();
                    }

                    if (search.StateList != null && search.StateList.Count() > 0)
                    {
                        rLists = rLists.Where(m => search.StateList.Contains(Convert.ToInt32(m.stateID))).ToList();
                    }

                    if (search.DistrictList != null && search.DistrictList.Count() > 0)
                    {
                        rLists = rLists.Where(m => search.DistrictList.Contains(Convert.ToInt32(m.districtID))).ToList();
                    }

                    if (search.CityList != null && search.CityList.Count() > 0)
                    {
                        rLists = rLists.Where(m => search.CityList.Contains(Convert.ToInt32(m.cityID))).ToList();
                    }

                    if (search.CompanyTypeList != null && search.CompanyTypeList.Count() > 0)
                    {
                        rLists = rLists.Where(m => search.CompanyTypeList.Contains(Convert.ToInt32(m.companyTypeID))).ToList();
                    }

                    if (search.CustomerTypeList != null && search.CustomerTypeList.Count() > 0)
                    {
                        rLists = rLists.Where(m => search.CustomerTypeList.Contains(Convert.ToInt32(m.customerType))).ToList();
                    }

                    if (search.AreaList != null && search.AreaList.Count() > 0)
                    {
                        rLists = rLists.Where(m => search.AreaList.Contains(m.area)).ToList();
                    }

                    #region date filter
                    if (!string.IsNullOrEmpty(search.FromDate) && !string.IsNullOrEmpty(search.ToDate))
                    {
                        DateTime FromDateTime = Convert.ToDateTime(search.FromDate);
                        DateTime ToDateTime = Convert.ToDateTime(search.ToDate);

                        //created list
                        rLists = rLists.Where(c => Convert.ToDateTime(c.Date.ToString()) >= FromDateTime && Convert.ToDateTime(c.Date.ToString()) <= ToDateTime).ToList(); //"yyyy-MM-dd"                        
                    }
                    #endregion

                    return rLists;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        
        public Receipts GetReceiptDetails(string ReceiptID)
        {
            MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
            Receipts dlrd = new Receipts();
            try
            {                
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        tblAccountReceiptDetail tblAccountReceiptDetails = Entities.tblAccountReceiptDetails.AsNoTracking().Where(c => c.ReceiptID == ReceiptID.Trim()).FirstOrDefault();

                        dlrd.ReceiptID = tblAccountReceiptDetails.ReceiptID;
                        dlrd.OrgID = tblAccountReceiptDetails.OrgID;
                        dlrd.Date = tblAccountReceiptDetails.ReceiptDatetime;
                        dlrd.Amount = tblAccountReceiptDetails.Amount;                        
                        dlrd.CreatedByID = tblAccountReceiptDetails.CreatedByID;
                        dlrd.CustomerName = Entities.tblCustomerVendorDetails.Where(r => r.CustID == Entities.tblAccountReceiptWithBillDetails.Where(r1 => r1.ReceiptID == tblAccountReceiptDetails.ReceiptID).FirstOrDefault().CustID).FirstOrDefault().FirmName;
                        dlrd.VoucherTypeNo = tblAccountReceiptDetails.VoucherTypeNo;
                        dlrd.LedgerID =  tblAccountReceiptDetails.LedgerID;
                        dlrd.PaymentType = tblAccountReceiptDetails.PaymentType;
                        dlrd.BankOrCash = tblAccountReceiptDetails.BankOrCash;
                        dlrd.SalesManID = tblAccountReceiptDetails.SalesManID;
                        dlrd.BankName = tblAccountReceiptDetails.BankName;
                        dlrd.BranchName = tblAccountReceiptDetails.BranchName;
                        dlrd.IFSC = tblAccountReceiptDetails.IFSC;
                        dlrd.AccountNumber = tblAccountReceiptDetails.AccountNumber;
                        dlrd.TransactionNumber = tblAccountReceiptDetails.TransactionNumber;
                        dlrd.CheckDate = tblAccountReceiptDetails.CheckDate;
                        dlrd.Status = tblAccountReceiptDetails.Status;
                        dlrd.SignatureImage = tblAccountReceiptDetails.SignatureImage;
                        dlrd.Comments = tblAccountReceiptDetails.Comments;
                        dlrd.IsTallyUpdates = tblAccountReceiptDetails.IsTallyUpdates;
                        dlrd.SourceOfUpdate = tblAccountReceiptDetails.SourceOfUpdate;
                        dlrd.CustLocation = tblAccountReceiptDetails.CustLocation;
                        dlrd.CreationDate = tblAccountReceiptDetails.CreationDate;
                        dlrd.ModifiedByID = tblAccountReceiptDetails.ModifiedByID;
                        dlrd.ModifiedByID = tblAccountReceiptDetails.ModifiedByID;
                        dlrd.RecieverSignatureImage = tblAccountReceiptDetails.RecieverSignatureImage;
                        dlrd.ReferenceImage = tblAccountReceiptDetails.ReferenceImage;
                        dlrd.ReceiptDatetime = tblAccountReceiptDetails.ReceiptDatetime;
                        dlrd.ReceiptDateStr = tblAccountReceiptDetails.ReceiptDatetime.Value.ToString("dd/MM/yyyy");
                        dlrd.IsEdited = tblAccountReceiptDetails.IsEdited;

                        var itemsList = (from a in Entities.tblAccountReceiptDetails
                                         join b in Entities.tblAccountReceiptWithBillDetails on a.ReceiptID.ToLower().Trim() equals b.ReceiptID.ToLower().Trim()
                                         where a.ReceiptID == ReceiptID
                                         select new DLReceiptsBillDetailsCreation
                                         {
                                             Billdatetime = b.Billdatetime,
                                             Billamount = b.Credit,
                                             BillNo = b.BillNo,
                                             ReceiptID = b.ReceiptID,
                                             ReceiptWithBillID = b.ReceiptWithBillID,
                                             CustID = b.CustID,
                                             OutstandingAmt = b.OutstandingAmt,
                                             OrgID = b.OrgID,
                                             BillType = b.BillType,
                                             TallyAmount = b.TallyAmount,
                                             Discountamount = b.Discountamount,
                                             IsTallyUpdated = b.IsTallyUpdated,
                                             SourceOfUpdate = b.SourceOfUpdate,
                                             CreatedByID = b.CreatedByID,
                                             ModifiedByID = b.ModifiedByID,
                                             CreationDate = b.CreationDate,
                                             UpdatedDate = b.UpdatedDate
                                         }).Distinct().ToList();

                        dlrd.ReceiptsDetails = itemsList.ToList();

                        return dlrd;
                    }
                }
            }
            catch (Exception ex)
            {               
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public bool UpdateTallyStatus(Receipts receipts)
        {
            MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            tblAccountReceiptDetail tblAccountReceiptDetails = new tblAccountReceiptDetail();
                            tblAccountReceiptDetails.ReceiptID = receipts.ReceiptID;
                            tblAccountReceiptDetails.ModifiedByID = receipts.ModifiedByID;
                            tblAccountReceiptDetails.UpdatedDate = receipts.ModifiedDate;
                            tblAccountReceiptDetails.IsTallyUpdates = false;
                            tblAccountReceiptDetails.TallySync = true;
                            Entities.tblAccountReceiptDetails.Attach(tblAccountReceiptDetails);
                            Entities.Entry(tblAccountReceiptDetails).Property(c => c.ModifiedByID).IsModified = true;
                            Entities.Entry(tblAccountReceiptDetails).Property(c => c.UpdatedDate).IsModified = true;
                            Entities.Entry(tblAccountReceiptDetails).Property(c => c.IsTallyUpdates).IsModified = true;
                            Entities.Entry(tblAccountReceiptDetails).Property(c => c.TallySync).IsModified = true;
                            Entities.SaveChanges();
                            dbcxtransaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return false;
            }
        }
        public bool UpdateTallyStatusFromService(Receipts receipts, bool Error = false)
        {
            MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
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
                                tblAccountReceiptDetail tblAccountReceiptDetails = new tblAccountReceiptDetail();
                                tblAccountReceiptDetails.ReceiptID = receipts.ReceiptID;
                                tblAccountReceiptDetails.UpdatedDate = DateTimeNow;
                                tblAccountReceiptDetails.IsTallyUpdates = false;
                                tblAccountReceiptDetails.TallySync = false;
                                Entities.tblAccountReceiptDetails.Attach(tblAccountReceiptDetails);
                                Entities.Entry(tblAccountReceiptDetails).Property(c => c.UpdatedDate).IsModified = true;
                                Entities.Entry(tblAccountReceiptDetails).Property(c => c.IsTallyUpdates).IsModified = true;
                                Entities.Entry(tblAccountReceiptDetails).Property(c => c.TallySync).IsModified = true;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                return true;
                            }
                            else
                            {
                                tblAccountReceiptDetail tblAccountReceiptDetails = new tblAccountReceiptDetail();
                                tblAccountReceiptDetails.ReceiptID = receipts.ReceiptID;
                                tblAccountReceiptDetails.UpdatedDate = DateTimeNow;
                                tblAccountReceiptDetails.IsTallyUpdates = true;
                                tblAccountReceiptDetails.TallySync = false;
                                tblAccountReceiptDetails.IsEdited = true;
                                Entities.tblAccountReceiptDetails.Attach(tblAccountReceiptDetails);
                                Entities.Entry(tblAccountReceiptDetails).Property(c => c.UpdatedDate).IsModified = true;
                                Entities.Entry(tblAccountReceiptDetails).Property(c => c.IsTallyUpdates).IsModified = true;
                                Entities.Entry(tblAccountReceiptDetails).Property(c => c.TallySync).IsModified = true;
                                Entities.Entry(tblAccountReceiptDetails).Property(c => c.IsEdited).IsModified = true;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return false;
            }
        }
        public List<Receipts> GetReceiptDetailTally(string Orgid)
        {
            MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
            Receipts dlrd = new Receipts();
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<Receipts> Receipt = (from c in Entities.tblAccountReceiptDetails
                                                  where c.TallySync == true && c.IsTallyUpdates == false && c.OrgID == Orgid
                                                  select new Receipts
                                                  {
                                                      ReceiptID = c.ReceiptID,
                                                      OrgID = c.OrgID,
                                                      Date = c.ReceiptDatetime,
                                                      Amount = c.Amount,
                                                      CreatedByID = c.CreatedByID,
                                                      CustomerName = Entities.tblCustomerVendorDetails.Where(r => r.CustID == Entities.tblAccountReceiptWithBillDetails.Where(r1 => r1.ReceiptID == c.ReceiptID).FirstOrDefault().CustID).FirstOrDefault().FirmName,
                                                      VoucherTypeNo = c.VoucherTypeNo,
                                                      LedgerID = c.LedgerID,
                                                      PaymentType = c.PaymentType,
                                                      BankOrCash = c.BankOrCash,
                                                      SalesManID = c.SalesManID,
                                                      BankName = c.BankName,
                                                      BranchName = c.BranchName,
                                                      IFSC = c.IFSC,
                                                      AccountNumber = c.AccountNumber,
                                                      TransactionNumber = c.TransactionNumber,
                                                      CheckDate = c.CheckDate,
                                                      Status = c.Status,
                                                      SignatureImage = c.SignatureImage,
                                                      Comments = c.Comments,
                                                      IsTallyUpdates = c.IsTallyUpdates,
                                                      SourceOfUpdate = c.SourceOfUpdate,
                                                      CustLocation = c.CustLocation,
                                                      CreationDate = c.CreationDate,
                                                      ModifiedByID = c.ModifiedByID,
                                                      RecieverSignatureImage = c.RecieverSignatureImage,
                                                      ReferenceImage = c.ReferenceImage,
                                                      ReceiptDatetime = c.ReceiptDatetime,
                                                      BranchID = c.BranchID,
                                                      OrgName = c.BranchID == null ? string.Empty : Entities.tblSysBranches.Where(sb => sb.BranchID == BranchID).FirstOrDefault().Name,
                                                  }).ToList();
                        return Receipt;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public object GetReceiptsBillDetails_TallySync(string ReceiptID, string OrgID)
        {
            Receipts lDLReceiptsCreation = new Receipts();
            try
            {

                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    lDLReceiptsCreation = (from pay in Entities.tblAccountReceiptDetails.AsNoTracking()
                                           where pay.ReceiptID == ReceiptID && pay.OrgID == OrgID
                                           && pay.TallySync == true && pay.IsTallyUpdates == false
                                           select new Receipts()
                                           {
                                               ID = pay.ID,
                                               OrgID = pay.OrgID,
                                               BranchID = pay.BranchID,
                                               OrgName = pay.BranchID == null ? string.Empty : Entities.tblSysBranches.Where(i => i.BranchID == pay.BranchID).FirstOrDefault().Name,
                                               ReceiptID = pay.ReceiptID,
                                               ReceiptDatetime = pay.ReceiptDatetime.Value,
                                               Amount = pay.Amount,
                                               Credit = pay.Credit,
                                               SalesManID = pay.SalesManID,
                                               BankName = pay.BankName,
                                               BranchName = pay.BranchName,
                                               IFSC = pay.IFSC,
                                               AccountNumber = pay.AccountNumber,
                                               TransactionNumber = pay.TransactionNumber,
                                               PaymentType = pay.PaymentType,
                                               BankOrCash = pay.BankOrCash,
                                               CheckDate = pay.CheckDate,
                                               Status = pay.Status,
                                               Comments = pay.Comments.Trim(),
                                               IsTallyUpdates = pay.IsTallyUpdates,
                                               SourceOfUpdate = pay.SourceOfUpdate,
                                               LedgerID = pay.LedgerID,
                                               LedgerName = pay.BankOrCash == "C" ? Entities.tblAccountLedgers.Where(a => a.LedgerName == "Cash").FirstOrDefault().LedgerName : Entities.tblSysOrganizations.Where(o => o.OrgID == OrgID).FirstOrDefault().BankName,
                                               BankOrCashName = pay.BankOrCash == "C" ? Entities.tblAccountLedgers.Where(a => a.LedgerName == "Cash").FirstOrDefault().LedgerName : Entities.tblSysOrganizations.Where(o => o.OrgID == OrgID).FirstOrDefault().BankName,
                                               VoucherTypeName = Entities.tblVoucherTypes.Where(i => i.VoucherTypeNo == pay.VoucherTypeNo).FirstOrDefault().Name,
                                               DLReceiptsBillDetailsCreation = pay.tblAccountReceiptWithBillDetails
                                               .Select(i => new DLReceiptsBillDetailsCreation()
                                               {
                                                   ReceiptWithBillID = i.ReceiptWithBillID,
                                                   ReceiptID = i.ReceiptID,
                                                   CustID = i.CustID,
                                                   LedgerName = Entities.tblCustomerVendorDetails.Where(d => d.CustID == i.CustID).FirstOrDefault().FirmName,
                                                   BillType = i.BillType.Trim(),
                                                   BillNo = i.BillNo,
                                                   Billdatetime = i.Billdatetime,
                                                   Billamount = i.Billamount.Value,
                                                   Credit = i.Credit == null ? 0 : Math.Abs(i.Credit.Value),
                                                   Debit = i.Debit == null ? 0 : Math.Abs(i.Debit.Value),
                                                   OutstandingAmt = i.OutstandingAmt == null ? "0" : i.OutstandingAmt.Trim(),
                                                   CreatedByID = i.CreatedByID,
                                                   CreationDate = i.CreationDate,
                                                   Name = (i.BillType.ToString() == ModeOfPayments.New_Reference.ToString() || i.BillType.ToString() == ModeOfPayments.Advance.ToString()) ? i.BillNo : string.Empty,
                                               }).ToList(),
                                               IsEdited = pay.IsEdited,
                                           }).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return null;
            }
            return lDLReceiptsCreation;
        }
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
        public Nullable<decimal> TallyAmount { get; set; }

        public Nullable<bool> IsTallyUpdated { get; set; }
        public Nullable<decimal> Discountamount { get; set; }
        public decimal? Billamount { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
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

    public class DLReceipts
    {
        private Receipts mDLReceiptsCreation = new Receipts();
        MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        private List<Receipts> lstDLReceiptsCreation = new List<Receipts>();
        private tblAccountReceiptDetail lReceiptDetails = new tblAccountReceiptDetail();

        public Receipts EditData(Receipts receipts)
        {
            Receipts Result = new Receipts();
            try
            {
                mDLReceiptsCreation = (Receipts)receipts;
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            lReceiptDetails = (from pay in Entities.tblAccountReceiptDetails.AsNoTracking()
                                               where pay.ReceiptID.Equals(mDLReceiptsCreation.ReceiptID)
                                               && pay.OrgID == mDLReceiptsCreation.OrgID
                                               select pay).FirstOrDefault();

                            if (lReceiptDetails != null)
                            {
                                lReceiptDetails.VoucherTypeNo = mDLReceiptsCreation.VoucherTypeNo;
                                lReceiptDetails.ReceiptID = mDLReceiptsCreation.ReceiptID;
                                lReceiptDetails.OrgID = mDLReceiptsCreation.OrgID;
                                lReceiptDetails.ReceiptDatetime = mDLReceiptsCreation.ReceiptDatetime;
                                lReceiptDetails.Amount = mDLReceiptsCreation.Amount;
                                lReceiptDetails.ModifiedByID = mDLReceiptsCreation.CreatedByID;
                                lReceiptDetails.UpdatedDate = mDLReceiptsCreation.CreationDate;
                                lReceiptDetails.Status = mDLReceiptsCreation.Status;
                                lReceiptDetails.LedgerID = mDLReceiptsCreation.LedgerID == "0" ? null : mDLReceiptsCreation.LedgerID;
                                lReceiptDetails.BankOrCash = mDLReceiptsCreation.BankOrCash;
                                lReceiptDetails.PaymentType = mDLReceiptsCreation.PaymentType;
                                lReceiptDetails.Comments = mDLReceiptsCreation.Comments;
                                lReceiptDetails.BankName = mDLReceiptsCreation.BankName;
                                lReceiptDetails.BranchName = mDLReceiptsCreation.BranchName;
                                lReceiptDetails.AccountNumber = mDLReceiptsCreation.AccountNumber;
                                lReceiptDetails.IFSC = mDLReceiptsCreation.IFSC;
                                lReceiptDetails.TransactionNumber = mDLReceiptsCreation.TransactionNumber;
                                lReceiptDetails.CheckDate = mDLReceiptsCreation.CheckDate;
                                lReceiptDetails.SignatureImage = mDLReceiptsCreation.SignatureImage;
                                lReceiptDetails.BranchID = lReceiptDetails.BranchID;
                                lReceiptDetails.IsEdited = lReceiptDetails.IsTallyUpdates == true ? true : false;

                                Entities.tblAccountReceiptDetails.Add(lReceiptDetails);
                                Entities.Entry(lReceiptDetails).State = EntityState.Modified;

                                foreach (var item in mDLReceiptsCreation.ReceiptsDetails)
                                {
                                    //if bill exist but amount made o remove it
                                    if (item.Billamount == 0)
                                    {
                                        var getExistingBill = (from payBilll in Entities.tblAccountReceiptWithBillDetails
                                                               where
                                                                payBilll.BillNo == item.BillNo &&
                                                                payBilll.ReceiptID == mDLReceiptsCreation.ReceiptID
                                                               && payBilll.ReceiptWithBillID == item.ReceiptWithBillID
                                                               select payBilll).FirstOrDefault();

                                        if (getExistingBill != null)
                                        {
                                            Entities.Entry(getExistingBill).State = EntityState.Deleted;
                                        }
                                        Entities.SaveChanges();
                                    }
                                    else
                                    {
                                        //if bill exist modify
                                        List<tblAccountReceiptWithBillDetail> accountReceiptWithBillDetail = new List<tblAccountReceiptWithBillDetail>();
                                        var BillExist = (from payBilll in Entities.tblAccountReceiptWithBillDetails
                                                         where
                                                         payBilll.BillNo == item.BillNo &&
                                                          payBilll.ReceiptID == mDLReceiptsCreation.ReceiptID
                                                         && payBilll.ReceiptWithBillID == item.ReceiptWithBillID
                                                         select payBilll).FirstOrDefault();

                                        if (BillExist != null)
                                        {
                                            BillExist.BillNo = string.IsNullOrEmpty(item.Name) ? item.BillNo : item.Name;
                                            BillExist.BillType = item.BillType;
                                            BillExist.Billamount = item.Billamount;
                                            BillExist.Credit = item.Billamount;
                                            BillExist.Billdatetime = item.Billdatetime;
                                            BillExist.CustID = item.CustID;
                                            BillExist.OutstandingAmt = BillExist.OutstandingAmt;
                                            BillExist.UpdatedDate = BillExist.CreationDate;
                                            BillExist.ModifiedByID = BillExist.CreatedByID;
                                            accountReceiptWithBillDetail.Add(BillExist);
                                            Entities.Entry(BillExist).State = EntityState.Modified;
                                        }
                                        else // bill doesnt exist save new
                                        {
                                            tblAccountReceiptWithBillDetail dLReceiptBillDetailsCreation = new tblAccountReceiptWithBillDetail();
                                            dLReceiptBillDetailsCreation.ReceiptWithBillID = item.ReceiptWithBillID;
                                            dLReceiptBillDetailsCreation.ReceiptID = mDLReceiptsCreation.ReceiptID;
                                            dLReceiptBillDetailsCreation.CustID = item.CustID;
                                            dLReceiptBillDetailsCreation.OutstandingAmt = item.OutstandingAmt;
                                            dLReceiptBillDetailsCreation.OrgID = mDLReceiptsCreation.OrgID;
                                            dLReceiptBillDetailsCreation.BillType = item.BillType.Trim();
                                            dLReceiptBillDetailsCreation.BillNo = string.IsNullOrEmpty(item.Name) ? item.BillNo : item.Name;
                                            dLReceiptBillDetailsCreation.Billdatetime = item.Billdatetime;
                                            dLReceiptBillDetailsCreation.Billamount = item.Billamount;
                                            dLReceiptBillDetailsCreation.SourceOfUpdate = item.SourceOfUpdate;
                                            dLReceiptBillDetailsCreation.CreatedByID = mDLReceiptsCreation.CreatedByID;
                                            dLReceiptBillDetailsCreation.CreationDate = mDLReceiptsCreation.CreationDate;
                                            dLReceiptBillDetailsCreation.UpdatedDate = mDLReceiptsCreation.CreationDate;
                                            Entities.tblAccountReceiptWithBillDetails.Add(dLReceiptBillDetailsCreation);
                                        }
                                    }

                                    #region Si Status update
                                    if (item.BillNo != null)
                                    {
                                        tblSalesOrderInvoice
                                            salesOrderInvoice = (from si in Entities.tblSalesOrderInvoices.AsNoTracking()
                                                                 where si.SOInvoiceReferenceNumber == item.BillNo
                                                             && si.OrgID == item.OrgID
                                                                 //&& si.InvoiceDate.Date == Convert.ToDateTime(item.Billdatetime).Date
                                                                 select si).FirstOrDefault();

                                        if (salesOrderInvoice != null)
                                        {
                                            salesOrderInvoice.Receiptstatus = item.StatusForSi;
                                            Entities.Entry(salesOrderInvoice).State = EntityState.Modified;
                                            Entities.SaveChanges();
                                        }
                                    }
                                    #endregion
                                }

                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                Result.DisplayMessage = "Receipt updated successfully";
                                //this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                            }

                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            Result.DisplayMessage = "Error!! Please contact administrator";
                            //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                            //this.GetApplicationActivate.GetErrormessages = ex.Message;
                            //this.GetApplicationActivate.GetErrorSource = ex.Source;
                            //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                //this.GetApplicationActivate.GetErrormessages = ex.Message;
                //this.GetApplicationActivate.GetErrorSource = ex.Source;
                //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                Result.DisplayMessage = "Error!! Please contact administrator";
                throw;
            }
            return Result;
        }
    }

    public enum ModeOfPayments
    {
        None = 0,
        New_Reference = 1,
        Against_Reference = 2,
        Advance = 3,
        OnAccount = 4,
    }
}
