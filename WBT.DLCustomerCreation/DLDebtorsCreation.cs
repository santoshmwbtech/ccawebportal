using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DebtorsDetails
    {
        public int ID { get; set; }
        //[Required(ErrorMessage = "Please Select Company")]
        public string OrgID { get; set; }
        public string BranchID { get; set; }
        [Required(ErrorMessage = "Enter Debtor Name")]
        public string DebtorName { get; set; }
        public string Description { get; set; }
        public string ParentDebtorName { get; set; }
        public Nullable<int> ParentDebtorID { get; set; }
        public string CompanyName { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string CreatedByStr { get; set; }
        public string ModifiedByStr { get; set; }
        public string DisplayMessage { get; set; }
        public int? IsDefault { get; set; }
        public string BranchName { get; set; }
        public string OldDebtorName { get; set; }
        public Nullable<bool> IsTallyUpdated { get; set; }
        public int InsertedRecords { get; set; }
        public int FailedRecords { get; set; }
        public bool TallySync { get; set; }
        public bool IsEdited { get; set; }

    }
    public class DLDebtorsCreation
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<DebtorsDetails> GetDebtorsList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    List<DebtorsDetails> DebtorsList = new List<DebtorsDetails>();
                    DebtorsList = (from u in dbContext.tblDebtorsDetails
                                   where u.OrgID == OrgID
                                   select new DebtorsDetails
                                   {
                                       ID = u.ID,
                                       OrgID = u.OrgID,
                                       DebtorName = u.DebtorName.Trim(),
                                       Description = u.Description.Trim(),
                                       ParentDebtorID = u.ParentDebtorID,
                                       ParentDebtorName = (from i in dbContext.tblDebtorsDetails
                                                           where i.ID == u.ParentDebtorID
                                                           select i).FirstOrDefault().DebtorName,
                                       CompanyName = dbContext.tblSysOrganizations.Where(o => o.OrgID == u.OrgID).FirstOrDefault().Name,
                                       CreationDate = u.CreationDate,
                                       ModifiedDate = u.ModifiedDate,
                                       CreatedByStr = u.CreatedByID != null ? dbContext.tblSysUsers.Where(s => s.UserID == u.CreatedByID).FirstOrDefault().FName : "",
                                       ModifiedByStr = u.ModifiedByID != null ? dbContext.tblSysUsers.Where(s => s.UserID == u.ModifiedByID).FirstOrDefault().FName : "",
                                       IsDefault = u.IsDefault,
                                       BranchName = dbContext.tblSysBranches.Where(b => b.BranchID == u.BranchID).FirstOrDefault().Name,
                                       TallySync = u.TallySync == null ? false : u.TallySync.Value,
                                       IsTallyUpdated = u.IsTallyUpdated,
                                       IsEdited = u.IsEdited,
                                   }).OrderByDescending(x => x.IsDefault).ToList();
                    return DebtorsList;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public DebtorsDetails GetDebtorDetail(int? ID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    DebtorsDetails debtor = new DebtorsDetails();
                    debtor = (from d in dbContext.tblDebtorsDetails
                              where d.ID == ID
                              select new DebtorsDetails
                              {
                                  ID = d.ID,
                                  OrgID = d.OrgID,
                                  DebtorName = d.DebtorName.Trim(),
                                  Description = d.Description.Trim(),
                                  ParentDebtorID = d.ParentDebtorID,
                                  ParentDebtorName = dbContext.tblDebtorsDetails.Where(p => p.ID == d.ParentDebtorID).FirstOrDefault().DebtorName,
                                  CreationDate = d.CreationDate,
                                  OldDebtorName = d.OldDebtorName.Trim(),
                                  BranchName = dbContext.tblSysBranches.Where(b => b.BranchID == d.BranchID).FirstOrDefault().Name,
                                  BranchID = d.BranchID,
                                  IsEdited = d.IsEdited,
                                  IsTallyUpdated = d.IsTallyUpdated,
                              }).FirstOrDefault();
                    return debtor;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public int SaveDebtor(DebtorsDetails DebtorsDetail, string UserID, string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    var IsExists = dbContext.tblDebtorsDetails.AsNoTracking().Where(p => p.ID == DebtorsDetail.ID).FirstOrDefault();

                    if (IsExists != null)
                    {
                        var IsDebtorNameExists = dbContext.tblDebtorsDetails.AsNoTracking().Where(p => p.DebtorName.ToLower() == DebtorsDetail.DebtorName.ToLower() && p.ID != DebtorsDetail.ID).FirstOrDefault();

                        if(IsDebtorNameExists != null)
                        {
                            return 0;
                        }

                        tblDebtorsDetail debtor = new tblDebtorsDetail();
                        debtor.ID = IsExists.ID;
                        debtor.OrgID = OrgID;
                        debtor.DebtorName = DebtorsDetail.DebtorName;
                        debtor.Description = DebtorsDetail.Description;
                        debtor.ParentDebtorID = DebtorsDetail.ParentDebtorID;
                        debtor.ModifiedDate = DateTimeNow;
                        debtor.CreationDate = IsExists.CreationDate;
                        debtor.ModifiedByID = Convert.ToInt32(UserID);
                        debtor.CreatedByID = IsExists.CreatedByID;
                        debtor.OldDebtorName = DebtorsDetail.OldDebtorName;
                        debtor.IsDefault = IsExists.IsDefault;
                        debtor.BranchID = DebtorsDetail.BranchID;
                        debtor.IsEdited = IsExists.IsEdited;
                        dbContext.tblDebtorsDetails.Add(debtor);
                        dbContext.Entry(debtor).State = EntityState.Modified;
                        dbContext.SaveChanges();
                        return debtor.ID;
                    }
                    else
                    {
                        int DebtorsCount = 0;
                        if (dbContext.tblDebtorsDetails.Count() > 0)
                            DebtorsCount = Convert.ToInt32(dbContext.tblDebtorsDetails.Max(e => e.ID));
                        tblDebtorsDetail debtor = new tblDebtorsDetail();
                        debtor.ID = DebtorsCount + 1;
                        debtor.DebtorName = DebtorsDetail.DebtorName;
                        debtor.OrgID = OrgID;
                        debtor.Description = DebtorsDetail.Description;
                        debtor.ParentDebtorID = DebtorsDetail.ParentDebtorID;
                        debtor.CreationDate = DateTimeNow;
                        debtor.CreatedByID = Convert.ToInt32(UserID);
                        debtor.OldDebtorName = DebtorsDetail.DebtorName;
                        debtor.BranchID = DebtorsDetail.BranchID;
                        debtor.IsDefault = debtor.DebtorName.ToLower() == "sundry debtors" ? 1 : 0;
                        debtor.IsEdited = false;
                        dbContext.tblDebtorsDetails.Add(debtor);
                        dbContext.SaveChanges();
                        return debtor.ID;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return 0;
            }
        }
        public List<DebtorsDetails> ImportExcel(List<DebtorsDetails> ExcelData, string UserID, string BranchID, string OrgID)
        {
            int ID = 0;
            List<DebtorsDetails> Result = new List<DebtorsDetails>();
            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            string BranchName = Entities.tblSysBranches.Where(b => b.BranchID == BranchID && b.OrgID == OrgID).FirstOrDefault().Name.Trim();
            try
            {
                if (ExcelData != null)
                {
                    foreach (var debtor in ExcelData)
                    {
                        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                        {
                            string DebtorName = string.Empty;
                            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                                Entities.Database.Connection.Open();

                            if (!string.IsNullOrEmpty(debtor.DebtorName))
                            {
                                int DebtorsCount = Convert.ToInt32(Entities.tblDebtorsDetails.Max(e => e.ID));
                                tblDebtorsDetail IsValueexists = null;
                                if (!string.IsNullOrEmpty(debtor.DebtorName))
                                {
                                    IsValueexists = Entities.tblDebtorsDetails.AsNoTracking().Where(C => C.DebtorName.ToLower() == debtor.DebtorName.ToLower() && C.OrgID == OrgID).FirstOrDefault();
                                    if (IsValueexists != null)
                                        ID = IsValueexists.ID;
                                    else
                                        ID = DebtorsCount + 1;
                                }
                                else
                                {
                                    ID = DebtorsCount + 1;
                                }

                                using (var dbcxtransaction = Entities.Database.BeginTransaction())
                                {
                                    DebtorsDetails ResultItem = new DebtorsDetails();
                                    try
                                    {
                                        var ParentDebtor = Entities.tblDebtorsDetails.Where(d => d.DebtorName.ToLower() == debtor.ParentDebtorName.ToLower() && d.OrgID == OrgID).FirstOrDefault();
                                        if (ParentDebtor != null)
                                        {
                                            string BranchNameInFile = debtor.BranchName.Trim();

                                            BranchName = Regex.Replace(BranchName, @"\s+", String.Empty);
                                            BranchNameInFile = Regex.Replace(BranchNameInFile, @"\s+", String.Empty);

                                            bool isEqual = String.Equals(BranchName, BranchNameInFile, StringComparison.OrdinalIgnoreCase);

                                            if (isEqual)
                                            {
                                                int ParentDebtorID = ParentDebtor.ID;
                                                DebtorName = debtor.DebtorName;
                                                tblDebtorsDetail debtorsDetail = new tblDebtorsDetail();
                                                debtorsDetail.DebtorName = debtor.DebtorName;
                                                debtorsDetail.ID = ID;
                                                debtorsDetail.OrgID = OrgID;
                                                debtorsDetail.ParentDebtorID = ParentDebtorID;
                                                debtorsDetail.CreationDate = DateTimeNow;
                                                debtorsDetail.CreatedByID = Convert.ToInt32(UserID);
                                                debtorsDetail.IsDefault = 0;
                                                debtorsDetail.IsEdited = false;
                                                Entities.tblDebtorsDetails.Add(debtorsDetail);
                                                Entities.SaveChanges();
                                                dbcxtransaction.Commit();
                                            }
                                            else
                                            {
                                                ResultItem.DebtorName = debtor.DebtorName;
                                                ResultItem.DisplayMessage = "You have selected Branch Name <strong>"+ BranchName + "</strong> from the dropdown and in the excel file it is <stong>" + debtor.BranchName + "</stong>.. Please change the branch name in excel file.";
                                                Result.Add(ResultItem);
                                            }
                                        }
                                        else
                                        {
                                            ResultItem.DebtorName = debtor.DebtorName;
                                            ResultItem.DisplayMessage = "Parent Debtor <stong>" + debtor.ParentDebtorName + "</stong> is not present in the database... please create in <b>Masters</b> menu and then proceed";
                                            Result.Add(ResultItem);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        ResultItem.DebtorName = debtor.DebtorName;
                                        ResultItem.DisplayMessage = ex.Message;
                                        Result.Add(ResultItem);
                                        dbcxtransaction.Rollback();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebtorsDetails ResultItem = new DebtorsDetails();
                ResultItem.DisplayMessage = ex.Message;
                Result.Add(ResultItem);
            }
            return Result;
        }
        public bool UpdateTallyStatus(DebtorsDetails debtors)
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
                            tblDebtorsDetail tblDebtors = new tblDebtorsDetail();
                            tblDebtors.ID = debtors.ID;
                            tblDebtors.ModifiedDate = DateTimeNow;
                            tblDebtors.IsTallyUpdated = false;
                            tblDebtors.TallySync = true;
                            Entities.tblDebtorsDetails.Attach(tblDebtors);
                            Entities.Entry(tblDebtors).Property(c => c.ModifiedDate).IsModified = true;
                            Entities.Entry(tblDebtors).Property(c => c.IsTallyUpdated).IsModified = true;
                            Entities.Entry(tblDebtors).Property(c => c.TallySync).IsModified = true;
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
        public bool UpdateTallyStatusFromService(DebtorsDetails debtors, bool Error = false)
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
                                tblDebtorsDetail tblDebtors = new tblDebtorsDetail();
                                tblDebtors.ID = debtors.ID;
                                tblDebtors.ModifiedDate = DateTimeNow;
                                tblDebtors.IsTallyUpdated = false;
                                tblDebtors.TallySync = false;
                                Entities.tblDebtorsDetails.Attach(tblDebtors);
                                Entities.Entry(tblDebtors).Property(c => c.ModifiedDate).IsModified = true;
                                Entities.Entry(tblDebtors).Property(c => c.IsTallyUpdated).IsModified = true;
                                Entities.Entry(tblDebtors).Property(c => c.TallySync).IsModified = true;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                return true;
                            }
                            else
                            {
                                tblDebtorsDetail tblDebtors = new tblDebtorsDetail();
                                tblDebtors.ID = debtors.ID;
                                tblDebtors.ModifiedDate = DateTimeNow;
                                tblDebtors.IsTallyUpdated = true;
                                tblDebtors.TallySync = false;
                                tblDebtors.IsEdited = true;
                                Entities.tblDebtorsDetails.Attach(tblDebtors);
                                Entities.Entry(tblDebtors).Property(c => c.ModifiedDate).IsModified = true;
                                Entities.Entry(tblDebtors).Property(c => c.IsTallyUpdated).IsModified = true;
                                Entities.Entry(tblDebtors).Property(c => c.TallySync).IsModified = true;
                                Entities.Entry(tblDebtors).Property(c => c.IsEdited).IsModified = true;
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
        public DLRoleCreation DeleteDebtorGroup(int DebtorID, string OrgID, string UserID)
        {
            DLRoleCreation Result = new DLRoleCreation();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblDebtorsDetails.AsNoTracking().Where(u => u.ID == DebtorID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        Entities.tblDebtorsDetails.Remove(Entities.tblDebtorsDetails.Where(r => r.ID == DebtorID).FirstOrDefault());
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Debtor Group Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Can not delete Debtor Group as it is being used in Customers";
                return Result;
            }
        }
        public List<DebtorsDetails> GetDebtorsListForTallySync(string OrgID)
        {
            Helper.TransactionLog("Step 2", true);
            return GetDebtorsList(OrgID).Where(t => t.IsTallyUpdated == false && t.TallySync == true).ToList();

        }
    }
}
