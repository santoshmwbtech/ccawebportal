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
    public class DLItemRateCreation
    {
        public string BranchID { get; set; }
        public int RateID { get; set; }
        public Nullable<decimal> IfBaseRateLessThan { get; set; }
        public Nullable<decimal> IfBaseRateGreaterThan { get; set; }
        public Nullable<decimal> BaseRateOther { get; set; }
        public Nullable<int> ItemQTY1 { get; set; }
        public Nullable<int> ItemQTY2 { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> DistributorPrice { get; set; }
        public Nullable<decimal> RetailerPrice { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public bool IsEdited { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public string CategoryName { get; set; }
        public Nullable<decimal> DiscountFrom { get; set; }
        public Nullable<decimal> DiscountTo { get; set; }
        public virtual ICollection<tblItem> tblItems { get; set; }
        public string OrgID { get; set; }

        //used in base price screen
        private DateTime Datetim;
        public Nullable<DateTime> EffectiveDate
        {
            get
            {
                return Helper.GetDateAsDateTimeFormat(Convert.ToDateTime(Datetim));
            }
            set
            {
                Datetim = Helper.GetDateAsDateTimeFormat(Convert.ToDateTime(value));
            }
        }
        public Nullable<DateTime> NewEffectiveDate { get; set; }

        public string FromEffectiveTime { get; set; }
        public string ToEffectiveTime { get; set; }
        public string FromEffectiveDate { get; set; }
        public string ToEffectiveDate { get; set; }

        public Nullable<decimal> NewRate { get; set; }
        public Nullable<DateTime> LastUpdated { get; set; }
        public bool? IsOfferRate { get; set; }
        public Nullable<int> PerUnitRate { get; set; }
        public string PerUnitRateName { get; set; }
        public decimal? UpdateValue { get; set; }
        public decimal? UpdatePercentage { get; set; }
        public string DisplayMessage { get; set; }
    }
    public class CategoryDetails
    {
        public int CategoryID { get; set; }
        public string OrgID { get; set; }
        public string CategoryName { get; set; }
    }
    public class SubCategoryDetails
    {
        public int CategoryID { get; set; }
        public string OrgID { get; set; }
        public string SubCategoryName { get; set; }
        public int subCategoryID { get; set; }
    }
    public class PriceMaster
    {
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public string ItemName { get; set; }
        public decimal? UpdateValue { get; set; }
        public decimal? UpdatePercentage { get; set; }
        public string DisplayMessage { get; set; }
        public List<DLItemRateCreation> ItemsWithRates { get; set; }
    }

    public class DLItemRate : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private tblItemRate lItem = new tblItemRate();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        private List<DLItemRateCreation> lstItemRateCreation = new List<DLItemRateCreation>();
        private DLItemRateCreation mItemRateCreation = new DLItemRateCreation();
        public List<DLItemRateCreation> ItemRateCreation
        {
            get { return lstItemRateCreation; }
            set { lstItemRateCreation = value; }
        }

        public override object DataActivate(object Context)
        {
            object lResult = null;
            try
            {
                switch (this.GetApplicationActivate.DataState)
                {
                    case Common.TransactionType.Load:
                        lResult = GetData(Context.ToString());
                        break;
                    case Common.TransactionType.Edit:
                        lResult = EditData(Context);
                        break;
                }
                return lResult;
            }
            catch (Exception ex)
            {
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
                throw;
            }
        }

        private object GetData(string SearchValue)
        {
            lstItemRateCreation = new List<DLItemRateCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    #region new code refactor 27/08/2020 sneha
                    lstItemRateCreation = (from drow in Entities.tblItemRates.AsNoTracking()
                                           select new DLItemRateCreation()
                                           {
                                               RateID = drow.RateID,
                                               BaseRateOther = drow.BaseRateOther,
                                               PerUnitRate = drow.PerUnitRate,
                                               ItemQTY1 = drow.ItemQTY1,
                                               ItemQTY2 = drow.ItemQTY2,
                                           }).ToList();

                    #endregion

                    #region old

                    //var result = from gItemRate in Entities.ItemRates.AsNoTracking().ToList()
                    //             select gItemRate;

                    //foreach (var drow in result)
                    //{
                    //    mItemRateCreation = new DLItemRateCreation();
                    //    mItemRateCreation.RateID = drow.RateID;
                    //    mItemRateCreation.BaseRateOther = drow.BaseRateOther;
                    //    //mItemRateCreation.IfBaseRateLessThan = drow.IfBaseRateLessThan;
                    //    //mItemRateCreation.IfBaseRateGreaterThan = drow.IfBaseRateGreaterThan;
                    //    mItemRateCreation.ItemQTY1 = drow.ItemQTY1;
                    //    mItemRateCreation.ItemQTY2 = drow.ItemQTY2;
                    //    //mItemRateCreation.DiscountFrom = drow.DiscountFrom == null ? 0 : drow.DiscountFrom;
                    //    //mItemRateCreation.DiscountTo = drow.DiscountTo == null ? 0 : drow.DiscountTo;
                    //    lstItemRateCreation.Add(mItemRateCreation);
                    //}

                    #endregion

                    if (!string.IsNullOrEmpty(SearchValue))
                        lstItemRateCreation = lstItemRateCreation.Where(c => c.RateID.ToString() == SearchValue).ToList();

                    return lstItemRateCreation;
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
        }

        private object EditData(object Context)
        {
            lstItemRateCreation = ((List<DLItemRateCreation>)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            if (lstItemRateCreation != null && lstItemRateCreation.Count > 0)
                            {
                                tblItemRate lItem;
                                foreach (DLItemRateCreation dLItemBlockCreation in lstItemRateCreation)
                                {
                                    lItem = new tblItemRate();

                                    lItem = (from gItems in Entities.tblItemRates.AsNoTracking()
                                             where gItems.RateID == dLItemBlockCreation.RateID
                                             select gItems).First();

                                    lItem.BaseRateOther = dLItemBlockCreation.BaseRateOther;
                                    //lItem.DiscountFrom = dLItemBlockCreation.DiscountFrom;
                                    //lItem.DiscountTo = dLItemBlockCreation.DiscountTo;
                                    lItem.CreatedByID = dLItemBlockCreation.CreatedByID;
                                    lItem.UpdateDate = DateTime.Now;
                                    Entities.tblItemRates.Add(lItem);
                                    Entities.Entry(lItem).State = EntityState.Modified;
                                    Entities.SaveChanges();
                                }
                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                            }
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
        public List<CategoryDetails> GetCategories(string OrgID)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    List<CategoryDetails> categories = (from cat in Entities.tblCategories.AsNoTracking()
                                                        where cat.OrgID == OrgID
                                                        select new CategoryDetails()
                                                        {
                                                            CategoryID = cat.CategoryID,
                                                            CategoryName = cat.CategoryName.Trim(),
                                                            OrgID = cat.OrgID,
                                                        }).ToList();
                    return categories.OrderBy(a=>a.CategoryName).ToList();//new line
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                Helper.LogError(sqlex.Message, sqlex.Source, sqlex.InnerException == null ? null : sqlex.InnerException, sqlex.StackTrace);
                return null;
            }
        }
        public List<SubCategoryDetails> GetSubCategories(string OrgID, int CategoryID)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    List<SubCategoryDetails> subCategories = new List<SubCategoryDetails>();

                    if (CategoryID == 0)
                    {
                        subCategories = (from subcat in Entities.tblSubCategories.AsNoTracking()
                                         where subcat.OrgID == OrgID
                                         select new SubCategoryDetails()
                                         {
                                             CategoryID = subcat.CategoryID,
                                             subCategoryID = subcat.SubCategoryID,
                                             SubCategoryName = subcat.SubCategoryName.Trim(),
                                             OrgID = subcat.OrgID,
                                         }).ToList();
                    }
                    else
                    {
                        subCategories = (from subcat in Entities.tblSubCategories.AsNoTracking()
                                         where subcat.OrgID == OrgID && subcat.CategoryID == CategoryID
                                         select new SubCategoryDetails()
                                         {
                                             CategoryID = subcat.CategoryID,
                                             subCategoryID = subcat.SubCategoryID,
                                             SubCategoryName = subcat.SubCategoryName.Trim(),
                                             OrgID = subcat.OrgID,
                                         }).ToList();
                    }
                    return subCategories.OrderBy(a=>a.SubCategoryName).ToList();//new line
                }

            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                Helper.LogError(sqlex.Message, sqlex.Source, sqlex.InnerException == null ? null : sqlex.InnerException, sqlex.StackTrace);
                return null;
            }
        }
        public string UpdatePrice(int? RateID, decimal? BaseRateOther, string UserID)
        {
            string Result = string.Empty;
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    lItem = new tblItemRate();

                    if (RateID > 0)
                    {
                        lItem = (from gItems in Entities.tblItemRates.AsNoTracking()
                                 where gItems.RateID == RateID
                                 select gItems).First();

                        lItem.BaseRateOther = BaseRateOther;
                        lItem.ModifiedByID = Convert.ToInt32(UserID);
                        lItem.UpdateDate = DateTimeNow;
                        Entities.tblItemRates.Attach(lItem);
                        Entities.Entry(lItem).Property(i => i.BaseRateOther).IsModified = true;
                        Entities.Entry(lItem).Property(i => i.ModifiedByID).IsModified = true;
                        Entities.Entry(lItem).Property(i => i.UpdateDate).IsModified = true;
                        Entities.SaveChanges();
                        Result = "Price Updated Successfully";
                        return Result;
                    }
                    else
                    {
                        Result = "Invalid Item";
                        return Result;
                    }
                }

            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result = "Error.. Please contact administrator";
                return Result;
            }
        }
        public DLItemRateCreation UpdatePriceList(PriceMaster priceMaster, string UserID)
        {
            List<DLItemRateCreation> lstItemRateCreation = priceMaster.ItemsWithRates;
            DLItemRateCreation Result = new DLItemRateCreation();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                            if (lstItemRateCreation != null && lstItemRateCreation.Count > 0)
                            {
                                tblItemRate lItem;
                                foreach (DLItemRateCreation dLItemBlockCreation in lstItemRateCreation)
                                {
                                    lItem = new tblItemRate();

                                    if (dLItemBlockCreation.RateID > 0)
                                    {
                                        lItem = (from gItems in Entities.tblItemRates.AsNoTracking()
                                                 where gItems.RateID == dLItemBlockCreation.RateID
                                                 select gItems).First();

                                        if (priceMaster.UpdatePercentage != null)
                                        {
                                            decimal percentageValue = 0;
                                            if (dLItemBlockCreation.BaseRateOther != null)
                                                percentageValue = priceMaster.UpdatePercentage.Value / 100;
                                            decimal percentageAmount = dLItemBlockCreation.BaseRateOther.Value * percentageValue;

                                            lItem.BaseRateOther = dLItemBlockCreation.BaseRateOther + percentageAmount;
                                        }
                                        else if (priceMaster.UpdateValue != null)
                                        {
                                            lItem.BaseRateOther = dLItemBlockCreation.BaseRateOther + priceMaster.UpdateValue;
                                        }
                                        lItem.RateID = dLItemBlockCreation.RateID;
                                        lItem.CreatedByID = Convert.ToInt32(UserID);
                                        lItem.UpdateDate = DateTimeNow;
                                        Entities.tblItemRates.Add(lItem);
                                        Entities.Entry(lItem).State = EntityState.Modified;
                                        Entities.SaveChanges();
                                    }
                                }
                                dbcxtransaction.Commit();
                                Result.DisplayMessage = "Price List updated successfully..";
                            }
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            Result.DisplayMessage = "Error!! Please contact administrator";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Result.DisplayMessage = "Error!! Please contact administrator";
            }
            return Result;
        }
    }
}