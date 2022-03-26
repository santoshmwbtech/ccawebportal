using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;
using System.ComponentModel.DataAnnotations;
namespace WBT.DLCustomerCreation
{
    public class DLSubCategoryCreation
    {
        /// <summary>
        /// Get or Set the subcategory ID in int
        /// </summary>
        public int SubCategoryID { get; set; }
        [Required(ErrorMessage ="Please enter Catogery name")]  
        public string SubCategoryName { get; set; }
       
        public string CategoryName { get; set; }
        public string OldSubCategoryName { get; set; }
        [Required(ErrorMessage = "Please select group")]
        public int CategoryID { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OrgID { get; set; }
        public Nullable<bool> IsTallyUpdated { get; set; }
        public string Remark { get; set; }
        public string stringIsTallyUpdated { get; set; }
        public Nullable<System.DateTime> TallyUpdatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string SerachText { get; set; }
        public int? ParentCatID { get; set; }
        public string DisplayMessage { get; set; }
    }
    public class DLGroupData
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    

    public class BindingData
    {
        public List<DLGroupData> DLGroupDataLst { get; set; } = new List<DLGroupData>();
        public List<DLSubCategoryCreation> DLSubCategoryCreationLst { get; set; } = new List<DLSubCategoryCreation>();
    }
    public class DLSubCategory : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private tblSubCategory lSubCategory = new tblSubCategory();

        public List<DLSubCategoryCreation> lstSubCategoryCreation = new List<DLSubCategoryCreation>();
        private DLSubCategoryCreation mSubCategoryCreation = new DLSubCategoryCreation();
        public List<DLSubCategoryCreation> SubCategoryCreation
        {
            get { return lstSubCategoryCreation; }
            set { lstSubCategoryCreation = value; }
        }
        public override object DataActivate(object Context)
        {
            object lResult = null;
            try
            {
                switch (this.GetApplicationActivate.DataState)
                {
                    case Common.TransactionType.Load:
                        DLSubCategoryCreation Criteria = (DLSubCategoryCreation)Context;
                        lResult = GetData(Criteria.SerachText, Criteria.OrgID);
                        break;
                    case Common.TransactionType.Save:
                        lResult = SaveData(Context);
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
                    case Common.TransactionType.BindAllData:
                        lResult = BindAllData(Context);
                        break;
                }
                return lResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tblCategory> GetCategoryList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblCategory> catgList = new List<tblCategory>();
                        catgList = (from s in Entities.tblCategories
                                    where s.OrgID == OrgID
                                    orderby s.CategoryName
                                    select s).OrderBy(a => a.CategoryName).ToList();

                        return catgList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<DLSubCategoryCreation> GetPrimaryCategoryList()
        {
            List<DLSubCategoryCreation> dLsubcLst = new List<DLSubCategoryCreation>();
            dLsubcLst = (from catgs in Entities.tblCategories.AsNoTracking()
                         select new DLSubCategoryCreation()
                         {
                             ParentCatID = catgs.ParentCatId,
                             CategoryName =  Entities.tblCategories.Where(e => e.CategoryID.ToString() == catgs.ParentCatId.ToString()).FirstOrDefault().CategoryName 
                         }).ToList();
            return dLsubcLst;
        }
        private object GetData(string SearchValue, string OrgID)
        {
            lstSubCategoryCreation = new List<DLSubCategoryCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();


                    lstSubCategoryCreation = (from gSubCategories in Entities.tblSubCategories.AsNoTracking()
                                 .Where(e => e.IsActive == true)
                                              select new DLSubCategoryCreation
                                              {
                                                  TallyUpdatedDate = gSubCategories.TallyUpdatedDate.Value,
                                                  SubCategoryID = gSubCategories.SubCategoryID,
                                                  SubCategoryName = gSubCategories.SubCategoryName,
                                                  CategoryID = gSubCategories.CategoryID,
                                                  CategoryName = gSubCategories.tblCategory.CategoryName,
                                                  IsTallyUpdated = gSubCategories.IsTallyUpdated,
                                                  OrgID = gSubCategories.OrgID,
                                                  ParentCatID = gSubCategories.tblCategory.ParentCatId,
                                              }).ToList();

                    lstSubCategoryCreation = lstSubCategoryCreation.Select(ac => new DLSubCategoryCreation()
                    {
                        CategoryID = ac.CategoryID,
                        CategoryName = ac.CategoryName,
                        SubCategoryID = ac.SubCategoryID,
                        SubCategoryName = ac.SubCategoryName,
                        IsTallyUpdated = ac.IsTallyUpdated,
                        TallyUpdatedDate = ac.TallyUpdatedDate,
                        stringIsTallyUpdated = ac.IsTallyUpdated == true ? "Yes" : "No",
                        ModifiedByID = ac.ModifiedByID,
                        CreatedByID = ac.CreatedByID,
                        OrgID = ac.OrgID,
                        ParentCatID = ac.ParentCatID
                    }).Distinct().OrderBy(i => i.CategoryName).ToList();
                    
                    if (!string.IsNullOrEmpty(OrgID))
                        lstSubCategoryCreation = lstSubCategoryCreation.Where(c => c.OrgID.Trim() == OrgID).ToList();

                    lstSubCategoryCreation = lstSubCategoryCreation.OrderBy(i => i.SubCategoryName).ToList();
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
            return lstSubCategoryCreation;
        }
        private object SaveData(object Context)
        {
            mSubCategoryCreation = ((DLSubCategoryCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    var IsValueexists = (from gSubCategories in Entities.tblSubCategories.AsNoTracking()
                                         where gSubCategories.SubCategoryName.ToLower().Trim().Equals(mSubCategoryCreation.SubCategoryName.ToLower().Trim())
                                         //&& gSubCategories.OrgID == mSubCategoryCreation.OrgID
                                         select gSubCategories.SubCategoryName).ToList();  //to check if name exists

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
                                lSubCategory.IsActive = true;
                                lSubCategory.SubCategoryName = this.mSubCategoryCreation.SubCategoryName;
                                lSubCategory.CategoryID = this.mSubCategoryCreation.CategoryID;
                                lSubCategory.IsTallyUpdated = false;
                                lSubCategory.CreatedDate = DateTime.Now;
                                lSubCategory.ModifiedDate = DateTime.Now;
                                lSubCategory.CreatedByID = this.mSubCategoryCreation.CreatedByID;
                                //lSubCategory.OrgID = mSubCategoryCreation.OrgID;
                                Entities.tblSubCategories.Add(lSubCategory);
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
            mSubCategoryCreation = ((DLSubCategoryCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    var IsValueexists = (from gSubCategories in Entities.tblSubCategories.AsNoTracking()
                                         where gSubCategories.SubCategoryName.ToLower().Trim() == mSubCategoryCreation.SubCategoryName.ToLower().Trim()
                                         && gSubCategories.SubCategoryID != mSubCategoryCreation.SubCategoryID
                                         //&& gSubCategories.OrgID == mSubCategoryCreation.OrgID
                                         select gSubCategories).ToList();  //so tat subcat name not repeats compare id

                    if (IsValueexists.Count() != 0)
                    {
                        this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                    }
                    else
                    {
                        lSubCategory = (from gSubCategories in Entities.tblSubCategories.AsNoTracking()
                                        where gSubCategories.SubCategoryID == mSubCategoryCreation.SubCategoryID
                                        //&& gSubCategories.OrgID == mSubCategoryCreation.OrgID
                                        select gSubCategories).FirstOrDefault();

                        if (lSubCategory != null)
                        {

                            using (var dbcxtransaction = Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    lSubCategory.IsActive = true;
                                    lSubCategory.SubCategoryName = this.mSubCategoryCreation.SubCategoryName;
                                    lSubCategory.CategoryID = this.mSubCategoryCreation.CategoryID;
                                    lSubCategory.ModifiedDate = Helper.GetCurrentDate;
                                    lSubCategory.ModifiedByID = this.mSubCategoryCreation.ModifiedByID;
                                    //lSubCategory.OrgID = mSubCategoryCreation.OrgID;
                                    Entities.tblSubCategories.Add(lSubCategory);
                                    Entities.Entry(lSubCategory).State = EntityState.Modified;
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
            mSubCategoryCreation = ((DLSubCategoryCreation)Context);
            try
            {
                lSubCategory = (from gSubCategories in Entities.tblSubCategories.AsNoTracking()
                                where gSubCategories.SubCategoryID == mSubCategoryCreation.SubCategoryID
                                //&& gSubCategories.OrgID == mSubCategoryCreation.OrgID
                                select gSubCategories).First();

                if (lSubCategory != null)
                {
                    if (lSubCategory.tblItems.Count == 0)
                    {
                        using (Entities = new Entity.MWBTCustomerAppEntities())
                        {
                            using (var dbcxtransaction = Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    lSubCategory.IsActive = false;
                                    lSubCategory.ModifiedDate = DateTime.Now;//WBT.Common.Helper.GetCurrentDatetime;
                                    lSubCategory.ModifiedByID = mSubCategoryCreation.ModifiedByID;
                                    Entities.tblSubCategories.Add(lSubCategory);
                                    Entities.Entry(lSubCategory).State = EntityState.Modified;
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
                    }
                    else
                    {
                        this.GetApplicationActivate.DataState = Common.TransactionType.DataDependency;
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
            mSubCategoryCreation = ((DLSubCategoryCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    lSubCategory = (from gSubCategories in Entities.tblSubCategories.AsNoTracking()
                                    where gSubCategories.SubCategoryName.ToLower().Trim() == mSubCategoryCreation.SubCategoryName.ToLower().Trim()
                                    //&& gSubCategories.OrgID == mSubCategoryCreation.OrgID
                                    select gSubCategories).FirstOrDefault();

                    if (lSubCategory != null)
                    {

                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                lSubCategory.IsTallyUpdated = true;
                                lSubCategory.TallyUpdatedDate = Helper.GetCurrentDate;
                                lSubCategory.ModifiedByID = mSubCategoryCreation.ModifiedByID;
                                lSubCategory.ModifiedDate = Helper.GetCurrentDate;
                                Entities.tblSubCategories.Add(lSubCategory);
                                Entities.Entry(lSubCategory).State = EntityState.Modified;
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
        private object BindAllData(object Context)
        {
            BindingData bindingData = new BindingData();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    bindingData.DLSubCategoryCreationLst = (from gSubCategories in Entities.tblSubCategories
                                                            where gSubCategories.IsActive == true
                                                            orderby gSubCategories.tblCategory.CategoryName
                                                            select new DLSubCategoryCreation
                                                            {
                                                                SubCategoryID = gSubCategories.SubCategoryID,
                                                                SubCategoryName = gSubCategories.SubCategoryName,
                                                                CategoryID = gSubCategories.CategoryID,
                                                                CategoryName = gSubCategories.tblCategory.CategoryName,
                                                                IsTallyUpdated = gSubCategories.IsTallyUpdated,
                                                                OrgID = gSubCategories.OrgID,
                                                                stringIsTallyUpdated = gSubCategories.IsTallyUpdated == true ? "Yes" : "No",
                                                            }).ToList();

                    bindingData.DLGroupDataLst = (from gCategories in Entities.tblCategories.AsNoTracking().Where(e => e.IsActive == true)
                                                  orderby gCategories.CategoryName
                                                  select new DLGroupData  //gCategories;
                                                  {
                                                      CategoryID = gCategories.CategoryID,
                                                      CategoryName = gCategories.CategoryName,
                                                  }).ToList();

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
            return bindingData;
        }
        public List<DLSubCategoryCreation> GetDatas(string SearchValue, string OrgID)
        {
            lstSubCategoryCreation = new List<DLSubCategoryCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed


                    lstSubCategoryCreation = (from gSubCategories in Entities.tblSubCategories.AsNoTracking()
                                 .Where(e => e.IsActive == true)
                                              select new DLSubCategoryCreation
                                              {
                                                  TallyUpdatedDate = gSubCategories.TallyUpdatedDate.Value,
                                                  SubCategoryID = gSubCategories.SubCategoryID,
                                                  SubCategoryName = gSubCategories.SubCategoryName,
                                                  CategoryID = gSubCategories.CategoryID,
                                                  CategoryName = gSubCategories.tblCategory.CategoryName,
                                                  IsTallyUpdated = gSubCategories.IsTallyUpdated,
                                                  OrgID = gSubCategories.OrgID,
                                                  ParentCatID = gSubCategories.tblCategory.ParentCatId,// gCategorys.ParentCatId
                                              }).ToList();

                    lstSubCategoryCreation = lstSubCategoryCreation.Select(ac => new DLSubCategoryCreation()
                    {
                        CategoryID = ac.CategoryID,
                        CategoryName = ac.CategoryName,
                        SubCategoryID = ac.SubCategoryID,
                        SubCategoryName = ac.SubCategoryName,
                        IsTallyUpdated = ac.IsTallyUpdated,
                        TallyUpdatedDate = ac.TallyUpdatedDate,
                        stringIsTallyUpdated = ac.IsTallyUpdated == true ? "Yes" : "No",
                        ModifiedByID = ac.ModifiedByID,
                        CreatedByID = ac.CreatedByID,
                        OrgID = ac.OrgID,
                        ParentCatID = ac.ParentCatID
                    }).Distinct().OrderBy(i => i.CategoryName).ToList();

                    //commented on 25 FEB 2021
                    //if (SearchValue != "Tally" && !string.IsNullOrEmpty(SearchValue))
                    //    lstSubCategoryCreation = lstSubCategoryCreation.Where(c => c.CategoryName.ToLower().Trim().StartsWith(SearchValue.ToLower().Trim())
                    //    || c.CategoryID.ToString().Trim() == SearchValue.ToLower().Trim()).ToList();
                    // && c.OrgID.Trim() == OrgID).ToList();

                    if (!string.IsNullOrEmpty(OrgID))
                        lstSubCategoryCreation = lstSubCategoryCreation.Where(c => c.OrgID == OrgID).ToList();

                    //if (!string.IsNullOrEmpty(SearchValue))
                    //    lstSubCategoryCreation = lstSubCategoryCreation.Where(c => c.SubCategoryID == Convert.ToInt32(SearchValue)).ToList();

                    //commented on 25 FEB 2021 so that all groups can be added to new company in tally irrespective of isTallyUpdated boolean
                    //if (SearchValue == "Tally")
                    //    lstSubCategoryCreation = lstSubCategoryCreation.Where(c => c.IsTallyUpdated == false).ToList();  
                    //&& c.OrgID.Trim() == OrgID 21/12/2019

                    lstSubCategoryCreation = lstSubCategoryCreation.OrderBy(i => i.SubCategoryName).ToList();
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
            return lstSubCategoryCreation;
        }
        public DLSubCategoryCreation GetDetails(string SearchValue, string OrgID)
        {
            DLSubCategoryCreation lstSubCategoryCreation1 = new DLSubCategoryCreation();
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    lstSubCategoryCreation1 = (from gSubCategories in dbContext.tblSubCategories
                            where gSubCategories.SubCategoryID.ToString() == SearchValue && gSubCategories.OrgID == OrgID.ToString()
                            select new DLSubCategoryCreation
                            {
                                CategoryID = gSubCategories.CategoryID,
                                CategoryName = dbContext.tblCategories.Where(i => i.CategoryID ==                 gSubCategories.CategoryID).FirstOrDefault().CategoryName,
                                SubCategoryID = gSubCategories.SubCategoryID,
                                SubCategoryName = gSubCategories.SubCategoryName,
                                IsTallyUpdated = gSubCategories.IsTallyUpdated,
                                TallyUpdatedDate = gSubCategories.TallyUpdatedDate,
                                stringIsTallyUpdated = gSubCategories.IsTallyUpdated == true ? "Yes" : "No",
                                ModifiedByID = gSubCategories.ModifiedByID,
                                CreatedByID = gSubCategories.CreatedByID,
                                OrgID = gSubCategories.OrgID,                                
                            }).FirstOrDefault();
                    return lstSubCategoryCreation1;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }

























            //try
            //{
            //    using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
            //    {
            //        if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
            //            Entities.Database.Connection.Open();                        //to open the connection if closed


            //        lstSubCategoryCreation1 = (from gSubCategories in Entities.tblSubCategories.AsNoTracking()
            //                     .Where(e => e.IsActive == true)
            //                                  select new DLSubCategoryCreation
            //                                  {
            //                                      TallyUpdatedDate = gSubCategories.TallyUpdatedDate.Value,
            //                                      SubCategoryID = gSubCategories.SubCategoryID,
            //                                      SubCategoryName = gSubCategories.SubCategoryName,
            //                                      CategoryID = gSubCategories.CategoryID,
            //                                      CategoryName = gSubCategories.tblCategory.CategoryName,
            //                                      IsTallyUpdated = gSubCategories.IsTallyUpdated,
            //                                      OrgID = gSubCategories.OrgID,
            //                                      ParentCatID = gSubCategories.tblCategory.ParentCatId,// gCategorys.ParentCatId
            //                                  }).FirstOrDefault();

            //        lstSubCategoryCreation1 = lstSubCategoryCreation1.Select(ac => new DLSubCategoryCreation()
            //        {
            //            CategoryID = ac.CategoryID,
            //            CategoryName = ac.CategoryName,
            //            SubCategoryID = ac.SubCategoryID,
            //            SubCategoryName = ac.SubCategoryName,
            //            IsTallyUpdated = ac.IsTallyUpdated,
            //            TallyUpdatedDate = ac.TallyUpdatedDate,
            //            stringIsTallyUpdated = ac.IsTallyUpdated == true ? "Yes" : "No",
            //            ModifiedByID = ac.ModifiedByID,
            //            CreatedByID = ac.CreatedByID,
            //            OrgID = ac.OrgID,
            //            ParentCatID = ac.ParentCatID
            //        }).Distinct().OrderBy(i => i.CategoryName).ToList();

            //        //commented on 25 FEB 2021
            //        //if (SearchValue != "Tally" && !string.IsNullOrEmpty(SearchValue))
            //        //    lstSubCategoryCreation = lstSubCategoryCreation.Where(c => c.CategoryName.ToLower().Trim().StartsWith(SearchValue.ToLower().Trim())
            //        //    || c.CategoryID.ToString().Trim() == SearchValue.ToLower().Trim()).ToList();
            //        // && c.OrgID.Trim() == OrgID).ToList();

            //        if (!string.IsNullOrEmpty(OrgID))
            //            lstSubCategoryCreation1 = lstSubCategoryCreation1.Where(c => c.OrgID == OrgID).ToList();

            //        if (!string.IsNullOrEmpty(SearchValue))
            //            lstSubCategoryCreation1 = lstSubCategoryCreation1.Where(c => c.SubCategoryID == Convert.ToInt32(SearchValue)).ToList();

            //        //commented on 25 FEB 2021 so that all groups can be added to new company in tally irrespective of isTallyUpdated boolean
            //        //if (SearchValue == "Tally")
            //        //    lstSubCategoryCreation = lstSubCategoryCreation.Where(c => c.IsTallyUpdated == false).ToList();  
            //        //&& c.OrgID.Trim() == OrgID 21/12/2019

            //        lstSubCategoryCreation1 = lstSubCategoryCreation1.OrderBy(i => i.SubCategoryName).ToList();
            //    }
            //}
            //catch (System.Data.SqlClient.SqlException sqlex)
            //{
            //    this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
            //    this.GetApplicationActivate.GetErrormessages = sqlex.Message;
            //    this.GetApplicationActivate.GetErrorSource = sqlex.Source;
            //    this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    this.GetApplicationActivate.DataState = Common.TransactionType.Error;
            //    this.GetApplicationActivate.GetErrormessages = ex.Message;
            //    this.GetApplicationActivate.GetErrorSource = ex.Source;
            //    this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
            //    throw;
            //}
            //return lstSubCategoryCreation1;
        }
        public DLSubCategoryCreation SaveDatas(DLSubCategoryCreation mSubCategoryCreation)
        {
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    var IsValueexists = (from gSubCategories in Entities.tblSubCategories.AsNoTracking()
                                         where gSubCategories.SubCategoryName.ToLower().Trim().Equals(mSubCategoryCreation.SubCategoryName.ToLower().Trim())
                                         && gSubCategories.OrgID == mSubCategoryCreation.OrgID
                                         select gSubCategories.SubCategoryName).ToList();  //to check if name exists

                    if (IsValueexists.Count() != 0)
                    {
                        this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                        mSubCategoryCreation.DisplayMessage = "Category Name Already Exists";
                        return mSubCategoryCreation;
                    }
                    else
                    {

                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                lSubCategory.IsActive = true;
                                lSubCategory.SubCategoryName = mSubCategoryCreation.SubCategoryName;
                                lSubCategory.CategoryID = mSubCategoryCreation.CategoryID;
                                lSubCategory.IsTallyUpdated = false;
                                lSubCategory.CreatedDate = DateTime.Now;
                                lSubCategory.ModifiedDate = DateTime.Now;
                                lSubCategory.CreatedByID = mSubCategoryCreation.CreatedByID;
                                lSubCategory.OrgID = mSubCategoryCreation.OrgID;
                                Entities.tblSubCategories.Add(lSubCategory);
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                                mSubCategoryCreation.DisplayMessage = "Category Saved Successfully";
                                return mSubCategoryCreation;
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
                                mSubCategoryCreation.DisplayMessage = "Error.. Please contact administrator";
                                return mSubCategoryCreation;
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
                mSubCategoryCreation.DisplayMessage = "Error.. Please contact administrator";
                return mSubCategoryCreation;
            }
            //return mSubCategoryCreation;
        }


        public DLSubCategoryCreation SaveCategory(DLSubCategoryCreation CatgDetails, int UserID1, string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {                    
                    var IsExists = (from gSubCategories in dbContext.tblSubCategories.AsNoTracking().ToList()
                                    where gSubCategories.SubCategoryID == CatgDetails.SubCategoryID
                                    && gSubCategories.OrgID == CatgDetails.OrgID
                                    select gSubCategories).FirstOrDefault();
                    
                    if (IsExists != null)
                    {
                        using (var dbcxtransaction = dbContext.Database.BeginTransaction())
                        {

                            var IsNameExists = Entities.tblSubCategories.AsNoTracking().Where(i => i.SubCategoryName.ToLower().Trim() == CatgDetails.SubCategoryName.ToLower().Trim()).Where(j => j.SubCategoryID != CatgDetails.SubCategoryID && j.OrgID == OrgID).FirstOrDefault();
                            if (IsNameExists == null)
                            {

                                lSubCategory.SubCategoryID = CatgDetails.SubCategoryID;
                                lSubCategory.IsActive = true;
                                lSubCategory.SubCategoryName = CatgDetails.SubCategoryName;
                                lSubCategory.CategoryID = CatgDetails.CategoryID;
                                lSubCategory.IsTallyUpdated = false;
                                lSubCategory.CreatedDate = DateTime.Now;
                                lSubCategory.ModifiedDate = DateTime.Now;
                                lSubCategory.OrgID = OrgID;
                                lSubCategory.ModifiedByID = UserID1;
                                lSubCategory.CreatedByID = IsExists.CreatedByID;
                                lSubCategory.IsTallyUpdated = CatgDetails.IsTallyUpdated;
                                lSubCategory.TallyUpdatedDate = CatgDetails.TallyUpdatedDate;


                                dbContext.tblSubCategories.Add(lSubCategory);
                                dbContext.Entry(lSubCategory).State = EntityState.Modified;
                                dbContext.SaveChanges();
                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                                CatgDetails.DisplayMessage = "Category Updated Successfully";
                                return CatgDetails;
                            }
                            else
                            {
                                CatgDetails.DisplayMessage = "Category Name Already Exists";
                                return CatgDetails;
                            }
                        }
                    }
                    else
                    {
                        CatgDetails.DisplayMessage = "Category details not found";
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
