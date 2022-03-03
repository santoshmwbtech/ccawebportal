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
    public class DLCategoryCreation /*: ApplicationActivate*/
    {
        public string SerachText { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public int? CategoryTypeId { get; set; }
        /// <summary>
        /// Get or set User ID in int
        /// </summary>
        public int CreatedByID { get; set; }

        /// Get or set User ID in int
        /// </summary>
        public Nullable<int> ModifiedByID { get; set; }
        /// <summary>
        /// Get or set Created date in datetime
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Get or set Modified Date in datetime
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        public Nullable<bool> IsTallyUpdated { get; set; }
        public string stringIsTallyUpdated { get; set; }
        public Nullable<System.DateTime> TallyUpdatedDate { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> IsActive { get; set; } 
        public string CategoryOldName { get; set; }
        public Nullable<bool> AccOrInv { get; set; }
        public string OrgID { get; set; }

        public string ParentCatId { get; set; }
        public virtual DLItemCreation tblItems { get; set; }
        public virtual DLSubCategoryCreation tblSubCategories { get; set; }
        public string DisplayMessage { get; set; }
    }

    public class DLGroupDetails : DLCategoryCreation
    {
        public int CatID { get; set; }
        public string CatName { get; set; }
    }

    public class DLCategory : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private tblCategory lCategory = new tblCategory();

        public List<DLCategoryCreation> lstCategoryCreation = new List<DLCategoryCreation>();
        private DLCategoryCreation mCategoryCreation = new DLCategoryCreation();
        public List<DLCategoryCreation> CategoryCreation
        {
            get { return lstCategoryCreation; }
            set { lstCategoryCreation = value; }
        }

        public TimeZoneInfo INDIAN_ZONE { get; private set; }

        public override object DataActivate(object Context)
        {
            object lResult = null;
            try
            {
                switch (this.GetApplicationActivate.DataState)
                {
                    case Common.TransactionType.Load:
                        DLCategoryCreation Criteria = (DLCategoryCreation)Context;
                        lResult = GetData(Criteria.CategoryName, Criteria.OrgID);
                        break;
                    case Common.TransactionType.Save:
                       // lResult = SaveData(Context);
                        break;
                    case Common.TransactionType.Edit:
                        lResult = EditData(Context);
                        break;
                    case Common.TransactionType.Delete:
                        lResult = DeleteData(Context);
                        break;
                    case Common.TransactionType.TallyUpdation:
                        lResult = TallyEditData(Context);
                        break;
                }
                return lResult;
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
        public List<DLCategoryCreation> GetData(string SerachText, string OrgID)
        {
            lstCategoryCreation = new List<DLCategoryCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {

                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    lstCategoryCreation = (from gCategories in Entities.tblCategories.AsNoTracking().Where(e => e.IsActive == true)
                                           orderby gCategories.CategoryName
                                           select new DLCategoryCreation  //gCategories;
                                           {
                                               CategoryID = gCategories.CategoryID,
                                               CategoryName = gCategories.CategoryName,
                                               //below two are added on 3 Feb 2021 by DEVIKA
                                               CategoryType = gCategories.ParentCatId == null ? "Primary" :
                                               (from e in Entities.tblCategories
                                                where e.CategoryID == gCategories.ParentCatId
                                                select e).Count() > 0 ? (from e in Entities.tblCategories
                                                                         where e.CategoryID == gCategories.ParentCatId
                                                                         select e).FirstOrDefault().CategoryName : "",
                                               CategoryTypeId = gCategories.ParentCatId == null ? null : gCategories.ParentCatId,
                                               IsTallyUpdated = gCategories.IsTallyUpdated,
                                               TallyUpdatedDate = gCategories.TallyUpdatedDate,
                                               AccOrInv = gCategories.AccOrInv,
                                               ModifiedByID = gCategories.ModifiedByID,
                                               CreatedByID = gCategories.CreatedByID,
                                               OrgID = gCategories.OrgID,
                                               stringIsTallyUpdated = gCategories.IsTallyUpdated == true ? "Yes" : "No",
                                           }).ToList();

                    //commented on 25 FEB 2021 
                    //if (SerachText != "Tally" && !string.IsNullOrEmpty(SerachText))
                    //    lstCategoryCreation = lstCategoryCreation.Where(c => c.CategoryName.ToLower().Trim().StartsWith(SerachText.ToLower().Trim())).ToList();

                    if (!string.IsNullOrEmpty(OrgID))
                        lstCategoryCreation = lstCategoryCreation.Where(c => c.OrgID == OrgID).ToList();

                    //commented on 25 FEB 2021 so that all groups can be added to new company in tally irrespective of isTallyUpdated boolean
                    //if (SerachText == "Tally")
                    //    lstCategoryCreation = lstCategoryCreation.Where(c => c.IsTallyUpdated == false).ToList();  //&& c.OrgID == OrgID 21/12/19
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
            return lstCategoryCreation;
        }
        public DLCategoryCreation SaveData(DLCategoryCreation mCategoryCreation)
        {
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    var IsValueexists = (from gCategories in Entities.tblCategories.AsNoTracking()
                                         where gCategories.CategoryName.ToLower().Trim().Equals(mCategoryCreation.CategoryName.ToLower().Trim())
                                         && gCategories.IsActive == true && gCategories.OrgID == mCategoryCreation.OrgID
                                         select gCategories.CategoryName).ToList();

                    if (IsValueexists.Count() != 0)
                    {
                        this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                        mCategoryCreation.DisplayMessage = "Group Name already exists";
                        return mCategoryCreation;
                    }
                    else
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                var IsNameExists = Entities.tblCategories.AsNoTracking().Where(i => i.CategoryName.ToLower().Trim() == mCategoryCreation.CategoryName.ToLower().Trim()).FirstOrDefault();
                                if (IsNameExists == null)
                                {

                                    lCategory.ParentCatId = mCategoryCreation.CategoryID;
                                    lCategory.IsActive = true;
                                    lCategory.CategoryName = mCategoryCreation.CategoryName;
                                    lCategory.AccOrInv = mCategoryCreation.AccOrInv;
                                    lCategory.CreatedDate = Common.Helper.GetCurrentDate;
                                    lCategory.ModifiedDate = Common.Helper.GetCurrentDate;
                                    lCategory.IsTallyUpdated = false;
                                    lCategory.CreatedByID = mCategoryCreation.CreatedByID;
                                    lCategory.OrgID = mCategoryCreation.OrgID;
                                    Entities.tblCategories.Add(lCategory);
                                    Entities.SaveChanges();
                                    dbcxtransaction.Commit();
                                    this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                                    mCategoryCreation.DisplayMessage = "Group Saved Successfully";
                                    return mCategoryCreation;
                                }
                                else
                                {
                                    mCategoryCreation.DisplayMessage = "Group Name already exists";
                                    return mCategoryCreation;
                                }
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                //this.GetApplicationActivate.GetErrormessages = ex.Message;
                                //this.GetApplicationActivate.GetErrorSource = ex.Source;
                                //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                //throw;
                                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                                mCategoryCreation.DisplayMessage = "Error.. Please contact administrator";
                                return mCategoryCreation;
                            }
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
                //throw;
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                mCategoryCreation.DisplayMessage = "Error.. Please contact administrator";
                return mCategoryCreation;
            }
        }

        public object EditData(object Context)
        {
            mCategoryCreation = ((DLCategoryCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    var IsValueexists = (from gCategories in Entities.tblCategories.AsNoTracking()
                                         where gCategories.CategoryName.ToLower().Trim()
                                         .Equals(mCategoryCreation.CategoryName.ToLower().Trim())
                                         && gCategories.IsActive == true
                                         //&& gCategories.OrgID == mCategoryCreation.OrgID
                                         select gCategories.CategoryName).ToList();

                    if (IsValueexists.Count() != 0)
                    {
                        this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                        mCategoryCreation.DisplayMessage = "Group Name Already Exists";
                        return mCategoryCreation;
                    }
                    else
                    {
                        lCategory = (from gCategories in Entities.tblCategories.AsNoTracking().ToList()
                                     where gCategories.CategoryID == mCategoryCreation.CategoryID
                                     //&& gCategories.OrgID == mCategoryCreation.OrgID
                                     select gCategories).First();

                        if (lCategory != null)
                        {
                            using (var dbcxtransaction = Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    lCategory.CategoryName = this.mCategoryCreation.CategoryName;
                                    lCategory.ParentCatId = this.mCategoryCreation.CategoryTypeId; //added on 3 Feb 2021 by DEVIKA so that he can edit parent cat ID
                                    lCategory.ModifiedDate = Common.Helper.GetCurrentDate;
                                    lCategory.ModifiedByID = mCategoryCreation.ModifiedByID;
                                    lCategory.AccOrInv = mCategoryCreation.AccOrInv;
                                    lCategory.OrgID = mCategoryCreation.OrgID;
                                    Entities.tblCategories.Add(lCategory);
                                    Entities.Entry(lCategory).State = EntityState.Modified;
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
        private object DeleteData(object Context)
        {
            mCategoryCreation = ((DLCategoryCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {

                    lCategory = (from gCategories in Entities.tblCategories.AsNoTracking()
                                 where gCategories.CategoryID == mCategoryCreation.CategoryID
                                 && gCategories.IsActive == true
                                 //&& gCategories.OrgID == mCategoryCreation.OrgID
                                 select gCategories).FirstOrDefault();
                                       

                    if (lCategory != null)
                    {
                        if (lCategory.tblItems.Count == 0 && lCategory.tblSubCategories.Count == 0 && lCategory.tblHOMasterPriceDetails.Count == 0 && lCategory.tblItemStockTransferDestinations.Count == 0 && lCategory.tblParameters.Count == 0)
                        {
                            using (var dbcxtransaction = Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    //lCategory.IsActive = false;
                                    //lCategory.ModifiedDate = Common.Helper.GetCurrentDate;
                                    //lCategory.CreatedByID = mCategoryCreation.CreatedByID;
                                    Entities.tblCategories.Add(lCategory);
                                    Entities.Entry(lCategory).State = EntityState.Deleted;
                                    Entities.SaveChanges();
                                    dbcxtransaction.Commit();
                                    this.GetApplicationActivate.DataState = Common.TransactionType.Deletesuccess;
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
                        else
                            this.GetApplicationActivate.DataState = Common.TransactionType.DataDependency;
                    }
                    else
                    {
                        //this.GetApplicationActivate.DataState = Common.TransactionType.NotFound;
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
        private object TallyEditData(object Context)
        {
            mCategoryCreation = ((DLCategoryCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    lCategory = (from gCategories in Entities.tblCategories.AsNoTracking()
                                 where gCategories.CategoryName.ToLower().Trim()
                                 == mCategoryCreation.CategoryName.ToLower().Trim()
                                 //&& gCategories.OrgID == mCategoryCreation.OrgID
                                 select gCategories).FirstOrDefault();

                    if (lCategory != null)
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                lCategory.IsTallyUpdated = true;
                                lCategory.TallyUpdatedDate = Common.Helper.GetCurrentDate;
                                lCategory.ModifiedByID = mCategoryCreation.ModifiedByID;
                                Entities.tblCategories.Add(lCategory);
                                Entities.Entry(lCategory).State = EntityState.Modified;
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
        public DLCategoryCreation GetDetails(int categoryID, string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    DLCategoryCreation catg = new DLCategoryCreation();
                    catg = (from gCategories in dbContext.tblCategories
                              where gCategories.CategoryID == categoryID && gCategories.OrgID == OrgID.ToString()
                              select new DLCategoryCreation
                              {
                                  CategoryID = gCategories.CategoryID,
                                  CategoryName = gCategories.CategoryName,
                                  //below two are added on 3 Feb 2021 by DEVIKA
                                  CategoryType = gCategories.ParentCatId == null ? "Primary" :
                                               (from e in dbContext.tblCategories
                                                where e.CategoryID == gCategories.ParentCatId && e.OrgID == OrgID
                                                select e).Count() > 0 ? (from e in dbContext.tblCategories
                                                                         where e.CategoryID == gCategories.ParentCatId
                                                                         select e).FirstOrDefault().CategoryName : "",
                                  CategoryTypeId = gCategories.ParentCatId == null ? null : gCategories.ParentCatId,
                                  IsTallyUpdated = gCategories.IsTallyUpdated,
                                  TallyUpdatedDate = gCategories.TallyUpdatedDate,
                                  AccOrInv = gCategories.AccOrInv,
                                  ModifiedByID = gCategories.ModifiedByID,
                                  CreatedByID = gCategories.CreatedByID,
                                  OrgID = gCategories.OrgID,
                                  IsActive = gCategories.IsActive,
                                  ParentCatId = gCategories.ParentCatId.ToString(),
                                  stringIsTallyUpdated = gCategories.IsTallyUpdated == true ? "Yes" : "No",
                              }).FirstOrDefault();
                    return catg;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }            
        }
        public DLCategoryCreation SaveGroup(DLCategoryCreation CatgDetails, int UserID1, string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    //DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    var IsExists = (from gCategories in dbContext.tblCategories.AsNoTracking().ToList()
                                    where gCategories.CategoryID == CatgDetails.CategoryID
                                    && gCategories.OrgID == CatgDetails.OrgID
                                    select gCategories).FirstOrDefault();


                    if (IsExists != null)
                    {
                        using (var dbcxtransaction = dbContext.Database.BeginTransaction())
                        {
                            var IsNameExists = Entities.tblCategories.AsNoTracking().Where(i => i.CategoryName.ToLower().Trim() == CatgDetails.CategoryName.ToLower().Trim()).Where(j => j.CategoryID != CatgDetails.CategoryID).FirstOrDefault();
                            if (IsNameExists == null)
                            {                                
                                lCategory.CategoryID = CatgDetails.CategoryID;
                                lCategory.CategoryName = CatgDetails.CategoryName;
                                lCategory.ParentCatId = Convert.ToInt32(CatgDetails.ParentCatId);
                                lCategory.ModifiedDate = Common.Helper.GetCurrentDate;
                                lCategory.ModifiedByID = UserID1;
                                lCategory.CreatedByID = IsExists.CreatedByID;
                                lCategory.AccOrInv = CatgDetails.AccOrInv;
                                lCategory.OrgID = CatgDetails.OrgID;
                                lCategory.IsActive = CatgDetails.IsActive;
                                lCategory.IsTallyUpdated = CatgDetails.IsTallyUpdated;
                                lCategory.TallyUpdatedDate = CatgDetails.TallyUpdatedDate;

                                dbContext.tblCategories.Add(lCategory);
                                dbContext.Entry(lCategory).State = EntityState.Modified;
                                dbContext.SaveChanges();
                                dbcxtransaction.Commit();
                                //this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                                //return lCategory.CategoryID;
                                CatgDetails.DisplayMessage = "Group Saved Successfully";
                                return CatgDetails;
                            }
                            else
                            {
                                CatgDetails.DisplayMessage = "Group Name Already Exists";
                                return CatgDetails;
                            }
                        }                        
                    }
                    else
                    {                        
                         CatgDetails.DisplayMessage = "Error.. Please contact administrator";
                         return CatgDetails;                        
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                CatgDetails.DisplayMessage = "Error.. Please contact administrator";
                return CatgDetails;
            }
        }
    }
}