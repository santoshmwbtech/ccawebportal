using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.DLCustomerCreation.DTOs;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLTaxLedgers
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<TaxLedgersDTO> GetTaxLedgers(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    List<TaxLedgersDTO> taxLedgers = new List<TaxLedgersDTO>();
                    taxLedgers = (from taxLedger in dbContext.tblTaxLedgers
                                  where taxLedger.OrgID == OrgID
                                  select new TaxLedgersDTO
                                  {
                                      ID = taxLedger.ID,
                                      OrgID = taxLedger.OrgID,
                                      Name = taxLedger.Name.Trim(),
                                      CreatedBy = taxLedger.CreatedBy,
                                      CreatedDate = taxLedger.CreatedDate,
                                      ModifiedBy = taxLedger.ModifiedBy,
                                      ModifiedDate = taxLedger.ModifiedDate,
                                      TaxPercentage = taxLedger.TaxPercentage,
                                      TaxType = taxLedger.TaxType,
                                      Under = taxLedger.Under,
                                  }).OrderByDescending(x => x.Name).ToList();
                    return taxLedgers;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public TaxLedgersDTO GetDebtorDetail(int? ID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    var taxLedger = (from taxLedgers in dbContext.tblTaxLedgers
                                     where taxLedgers.ID == ID
                                     select new TaxLedgersDTO
                                     {
                                         ID = taxLedgers.ID,
                                         OrgID = taxLedgers.OrgID,
                                         Name = taxLedgers.Name.Trim(),
                                         CreatedBy = taxLedgers.CreatedBy,
                                         CreatedDate = taxLedgers.CreatedDate,
                                         ModifiedBy = taxLedgers.ModifiedBy,
                                         ModifiedDate = taxLedgers.ModifiedDate,
                                         TaxPercentage = taxLedgers.TaxPercentage,
                                         TaxType = taxLedgers.TaxType,
                                         Under = taxLedgers.Under,
                                     }).FirstOrDefault();
                    return taxLedger;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        //public int SaveTaxLedger(DebtorsDetails DebtorsDetail, string UserID, string OrgID)
        //{
        //    try
        //    {
        //        using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
        //        {
        //            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        //            var IsExists = dbContext.tblDebtorsDetails.AsNoTracking().Where(p => p.ID == DebtorsDetail.ID).FirstOrDefault();

        //            if (IsExists != null)
        //            {
        //                var IsDebtorNameExists = dbContext.tblDebtorsDetails.AsNoTracking().Where(p => p.DebtorName.ToLower() == DebtorsDetail.DebtorName.ToLower() && p.ID != DebtorsDetail.ID).FirstOrDefault();

        //                if (IsDebtorNameExists != null)
        //                {
        //                    return 0;
        //                }

        //                tblDebtorsDetail debtor = new tblDebtorsDetail();
        //                debtor.ID = IsExists.ID;
        //                debtor.OrgID = OrgID;
        //                debtor.DebtorName = DebtorsDetail.DebtorName;
        //                debtor.Description = DebtorsDetail.Description;
        //                debtor.ParentDebtorID = DebtorsDetail.ParentDebtorID;
        //                debtor.ModifiedDate = DateTimeNow;
        //                debtor.CreationDate = IsExists.CreationDate;
        //                debtor.ModifiedByID = Convert.ToInt32(UserID);
        //                debtor.CreatedByID = IsExists.CreatedByID;
        //                debtor.OldDebtorName = DebtorsDetail.OldDebtorName;
        //                debtor.IsDefault = IsExists.IsDefault;
        //                debtor.BranchID = DebtorsDetail.BranchID;
        //                debtor.IsEdited = IsExists.IsEdited;
        //                dbContext.tblDebtorsDetails.Add(debtor);
        //                dbContext.Entry(debtor).State = EntityState.Modified;
        //                dbContext.SaveChanges();
        //                return debtor.ID;
        //            }
        //            else
        //            {
        //                int DebtorsCount = 0;
        //                if (dbContext.tblDebtorsDetails.Count() > 0)
        //                    DebtorsCount = Convert.ToInt32(dbContext.tblDebtorsDetails.Max(e => e.ID));
        //                tblDebtorsDetail debtor = new tblDebtorsDetail();
        //                debtor.ID = DebtorsCount + 1;
        //                debtor.DebtorName = DebtorsDetail.DebtorName;
        //                debtor.OrgID = OrgID;
        //                debtor.Description = DebtorsDetail.Description;
        //                debtor.ParentDebtorID = DebtorsDetail.ParentDebtorID;
        //                debtor.CreationDate = DateTimeNow;
        //                debtor.CreatedByID = Convert.ToInt32(UserID);
        //                debtor.OldDebtorName = DebtorsDetail.DebtorName;
        //                debtor.BranchID = DebtorsDetail.BranchID;
        //                debtor.IsDefault = debtor.DebtorName.ToLower() == "sundry debtors" ? 1 : 0;
        //                debtor.IsEdited = false;
        //                dbContext.tblDebtorsDetails.Add(debtor);
        //                dbContext.SaveChanges();
        //                return debtor.ID;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
        //        return 0;
        //    }
        //}
        public List<TaxLedgersDTO> ImportExcel(List<TaxLedgersDTO> ExcelData, string UserID, string OrgID)
        {
            int ID = 0;
            var Result = new List<TaxLedgersDTO>();
            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            try
            {
                if (ExcelData != null)
                {
                    foreach (var taxLedger in ExcelData)
                    {
                        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                        {
                            string DebtorName = string.Empty;
                            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                                Entities.Database.Connection.Open();

                            if (!string.IsNullOrEmpty(taxLedger.Name))
                            {
                                bool isValueExists = false;
                                if (!string.IsNullOrEmpty(taxLedger.Name))
                                {
                                    var txLedger = Entities.tblTaxLedgers.AsNoTracking().Where(C => C.Name.ToLower() == taxLedger.Name.ToLower() && C.OrgID == OrgID).FirstOrDefault();
                                    if (txLedger != null)
                                        isValueExists = true;
                                    else
                                        isValueExists = false;
                                }

                                using (var dbcxtransaction = Entities.Database.BeginTransaction())
                                {
                                    TaxLedgersDTO ResultItem = new TaxLedgersDTO();
                                    try
                                    {
                                        if (!isValueExists)
                                        {
                                            var tblTaxLedger = new tblTaxLedger
                                            {
                                                ID = taxLedger.ID,
                                                Under = "Duty And Taxes",
                                                Name = taxLedger.Name,
                                                TaxPercentage = taxLedger.TaxPercentage,
                                                TaxType = taxLedger.TaxType,
                                                OrgID = OrgID,
                                                CreatedBy = Convert.ToInt32(UserID),
                                                CreatedDate = DateTimeNow,
                                            };
                                            Entities.tblTaxLedgers.Add(tblTaxLedger);
                                        }
                                        else
                                        {
                                            ResultItem.Name = taxLedger.Name;
                                            ResultItem.DisplayMsg = taxLedger.Name + " already exists";
                                            Result.Add(ResultItem);
                                        }
                                        Entities.SaveChanges();
                                        dbcxtransaction.Commit();
                                    }
                                    catch (Exception ex)
                                    {
                                        ResultItem.Name = taxLedger.Name;
                                        ResultItem.DisplayMsg = ex.Message;
                                        Result.Add(ResultItem);
                                        //dbcxtransaction.Rollback();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TaxLedgersDTO ResultItem = new TaxLedgersDTO();
                ResultItem.DisplayMsg = ex.Message;
                Result.Add(ResultItem);
            }
            return Result;
        }
        //public bool UpdateTallyStatus(DebtorsDetails debtors)
        //{
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

        //            using (var dbcxtransaction = Entities.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    tblDebtorsDetail tblDebtors = new tblDebtorsDetail();
        //                    tblDebtors.ID = debtors.ID;
        //                    tblDebtors.ModifiedDate = DateTimeNow;
        //                    tblDebtors.IsTallyUpdated = false;
        //                    tblDebtors.TallySync = true;
        //                    Entities.tblDebtorsDetails.Attach(tblDebtors);
        //                    Entities.Entry(tblDebtors).Property(c => c.ModifiedDate).IsModified = true;
        //                    Entities.Entry(tblDebtors).Property(c => c.IsTallyUpdated).IsModified = true;
        //                    Entities.Entry(tblDebtors).Property(c => c.TallySync).IsModified = true;
        //                    Entities.SaveChanges();
        //                    dbcxtransaction.Commit();
        //                    return true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    dbcxtransaction.Rollback();
        //                    Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
        //        return false;
        //    }
        //}
        //public bool UpdateTallyStatusFromService(DebtorsDetails debtors, bool Error = false)
        //{
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();
        //            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

        //            using (var dbcxtransaction = Entities.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    if (Error)
        //                    {
        //                        tblDebtorsDetail tblDebtors = new tblDebtorsDetail();
        //                        tblDebtors.ID = debtors.ID;
        //                        tblDebtors.ModifiedDate = DateTimeNow;
        //                        tblDebtors.IsTallyUpdated = false;
        //                        tblDebtors.TallySync = false;
        //                        Entities.tblDebtorsDetails.Attach(tblDebtors);
        //                        Entities.Entry(tblDebtors).Property(c => c.ModifiedDate).IsModified = true;
        //                        Entities.Entry(tblDebtors).Property(c => c.IsTallyUpdated).IsModified = true;
        //                        Entities.Entry(tblDebtors).Property(c => c.TallySync).IsModified = true;
        //                        Entities.SaveChanges();
        //                        dbcxtransaction.Commit();
        //                        return true;
        //                    }
        //                    else
        //                    {
        //                        tblDebtorsDetail tblDebtors = new tblDebtorsDetail();
        //                        tblDebtors.ID = debtors.ID;
        //                        tblDebtors.ModifiedDate = DateTimeNow;
        //                        tblDebtors.IsTallyUpdated = true;
        //                        tblDebtors.TallySync = false;
        //                        tblDebtors.IsEdited = true;
        //                        Entities.tblDebtorsDetails.Attach(tblDebtors);
        //                        Entities.Entry(tblDebtors).Property(c => c.ModifiedDate).IsModified = true;
        //                        Entities.Entry(tblDebtors).Property(c => c.IsTallyUpdated).IsModified = true;
        //                        Entities.Entry(tblDebtors).Property(c => c.TallySync).IsModified = true;
        //                        Entities.Entry(tblDebtors).Property(c => c.IsEdited).IsModified = true;
        //                        Entities.SaveChanges();
        //                        dbcxtransaction.Commit();
        //                        return true;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    dbcxtransaction.Rollback();
        //                    Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
        //        return false;
        //    }
        //}
        //public DLRoleCreation DeleteDebtorGroup(int DebtorID, string OrgID, string UserID)
        //{
        //    DLRoleCreation Result = new DLRoleCreation();
        //    try
        //    {
        //        using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            var isValueExists = Entities.tblDebtorsDetails.AsNoTracking().Where(u => u.ID == DebtorID).FirstOrDefault();

        //            if (isValueExists == null)
        //            {
        //                Result.DisplayMessage = "Bad Request!!";
        //                return Result;
        //            }
        //            else
        //            {
        //                Entities.tblDebtorsDetails.Remove(Entities.tblDebtorsDetails.Where(r => r.ID == DebtorID).FirstOrDefault());
        //                Entities.SaveChanges();
        //                Result.DisplayMessage = "Debtor Group Deleted Successfully";
        //                return Result;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
        //        Result.DisplayMessage = "Can not delete Debtor Group as it is being used in Customers";
        //        return Result;
        //    }
        //}
        //public List<DebtorsDetails> GetDebtorsListForTallySync(string OrgID)
        //{
        //    Helper.TransactionLog("Step 2", true);
        //    return GetDebtorsList(OrgID).Where(t => t.IsTallyUpdated == false && t.TallySync == true).ToList();

        //}
    }
}
