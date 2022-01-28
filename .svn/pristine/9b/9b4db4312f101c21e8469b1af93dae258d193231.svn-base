using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLParameterCreation
    {
        public int ParameterID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string MinRange { get; set; }
        public string MaxRange { get; set; }
        public string ParameterType { get; set; }
        public string UnitOfMeasure { get; set; }
        public Nullable<decimal> DeviationPercentage { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> SubCategoryID { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsParameterChecked { get; set; }
        public string ItemCode { get; set; }
        //public DLCategoryCreation DLCategory { get; set; }
        //public DLSubCategoryCreation DLSubCategory { get; set; }
    }

    //public class BindAllData
    //{
    //    public List<DLCategoryCreation> DLCategoryCreation { get; set; } = new List<DLCategoryCreation>();
    //    public List<DLSubCategoryCreation> DLSubCategoryCreation { get; set; } = new List<DLSubCategoryCreation>();
    //}
    public class DLParameter : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private List<DLParameterCreation> lstParameterCreation = new List<DLParameterCreation>();
        private DLParameterCreation mParameterCreation = new DLParameterCreation();

        private tblParameter lParameter = new tblParameter();
        public List<DLParameterCreation> AddParameter
        {
            get { return lstParameterCreation; }
            set { lstParameterCreation = value; }
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
                    case Common.TransactionType.Save:
                        lResult = SaveData(Context);
                        break;
                    case Common.TransactionType.Edit:
                        lResult = EditData(Context);
                        break;
                    case Common.TransactionType.BindAllData:
                        lResult = BindData(Context);
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

        private object EditData(object Context)
        {
            mParameterCreation = ((DLParameterCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    //var IsValueexists = from gParameters in Entities.Parameters.AsNoTracking().ToList()
                    //                    where gParameters.Name.ToLower().Trim().Equals(mParameterCreation.Name.ToLower().Trim())
                    //                    && gParameters.ParameterID != mParameterCreation.ParameterID
                    //                    select gParameters;  //so tat subcat name not repeats compare id

                    //if (IsValueexists.Count() != 0)
                    //{
                    //    this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                    //}
                    //else
                    {
                        lParameter = (from gParameters in Entities.tblParameters.AsNoTracking()
                                      where gParameters.ParameterID == mParameterCreation.ParameterID
                                      select gParameters).First();

                        if (lParameter != null)
                        {

                            using (var dbcxtransaction = Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    lParameter.IsActive = true;
                                    lParameter.Name = this.mParameterCreation.Name;
                                    lParameter.Value = this.mParameterCreation.Value;
                                    lParameter.ParameterType = this.mParameterCreation.ParameterType;
                                    lParameter.MinRange = this.mParameterCreation.MinRange;
                                    lParameter.MaxRange = this.mParameterCreation.MaxRange;
                                    lParameter.UnitOfMeasure = this.mParameterCreation.UnitOfMeasure;
                                    if (this.mParameterCreation.CategoryID == 0)
                                        lParameter.CategoryID = null;
                                    else
                                        lParameter.CategoryID = this.mParameterCreation.CategoryID;

                                    if (this.mParameterCreation.SubCategoryID == 0)
                                        lParameter.SubCategoryID = null;
                                    else
                                        lParameter.SubCategoryID = this.mParameterCreation.SubCategoryID;
                                    lParameter.DeviationPercentage = this.mParameterCreation.DeviationPercentage;
                                    lParameter.ModifiedByID = this.mParameterCreation.CreatedByID;
                                    lParameter.UpdatedDate = WBT.Common.Helper.GetCurrentDate;
                                    Entities.tblParameters.Add(lParameter);
                                    Entities.Entry(lParameter).State = EntityState.Modified;
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
        private object GetData(string SearchValue)
        {
            lstParameterCreation = new List<DLParameterCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    #region old code

                    //var parameters = from gParameter in Entities.Parameters.AsNoTracking().ToList()
                    //                 where gParameter.IsActive == true
                    //                 orderby gParameter.Name
                    //                 select gParameter;

                    //foreach (var parameter in parameters)
                    //{
                    //    mParameterCreation = new DLParameterCreation();
                    //    mParameterCreation.ParameterID = parameter.ParameterID;
                    //    mParameterCreation.Name = parameter.Name;
                    //    mParameterCreation.Value = parameter.Value;
                    //    mParameterCreation.ParameterType = parameter.ParameterType;
                    //    mParameterCreation.MinRange = parameter.MinRange;
                    //    mParameterCreation.MaxRange = parameter.MaxRange;
                    //    mParameterCreation.DeviationPercentage = parameter.DeviationPercentage;

                    //    if (parameter.tblCategory != null)
                    //    {
                    //        mParameterCreation.CategoryID = parameter.CategoryID;
                    //        mParameterCreation.CategoryName = parameter.tblCategory.CategoryName;
                    //    }

                    //    mParameterCreation.UnitOfMeasure = parameter.UnitOfMeasure;
                    //    mParameterCreation.SubCategoryID = parameter.SubCategoryID;
                    //    if (parameter.tblSubCategory != null)
                    //    {
                    //        mParameterCreation.SubCategoryName = parameter.tblSubCategory.SubCategoryName;
                    //    }

                    //    mParameterCreation.CreatedByID = parameter.CreatedByID;
                    //    mParameterCreation.CreatedDate = parameter.CreatedDate;
                    //    mParameterCreation.UpdatedDate = parameter.UpdatedDate;

                    //    lstParameterCreation.Add(mParameterCreation);

                    //}

                    #endregion

                    #region by sneha 1st feb 2021

                    lstParameterCreation = (from parameter in Entities.tblParameters.AsNoTracking()
                                            where parameter.IsActive == true
                                            orderby parameter.Name
                                            select new DLParameterCreation()
                                            {
                                                ParameterID = parameter.ParameterID,
                                                Name = parameter.Name,
                                                Value = parameter.Value,
                                                ParameterType = parameter.ParameterType,
                                                MinRange = parameter.MinRange,
                                                MaxRange = parameter.MaxRange,
                                                DeviationPercentage = parameter.DeviationPercentage,
                                                CategoryID = parameter.tblCategory != null ? parameter.CategoryID : null,
                                                CategoryName = parameter.tblCategory != null ? parameter.tblCategory.CategoryName : string.Empty,
                                                UnitOfMeasure = parameter.UnitOfMeasure,
                                                SubCategoryID = parameter.SubCategoryID,
                                                SubCategoryName = parameter.tblSubCategory != null ?
                                                parameter.tblSubCategory.SubCategoryName : string.Empty,
                                                CreatedByID = parameter.CreatedByID,
                                                CreatedDate = parameter.CreatedDate,
                                                UpdatedDate = parameter.UpdatedDate,
                                            }).OrderBy(e => e.CategoryName).ToList();
                    #endregion

                    if (!string.IsNullOrEmpty(SearchValue))
                        lstParameterCreation = lstParameterCreation.Where(c => c.Name.ToLower().Trim().StartsWith(SearchValue.ToLower().ToString().Trim())).ToList();

                    return lstParameterCreation;

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

        private object SaveData(object Context)
        {
            mParameterCreation = ((DLParameterCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {

                        var IsValueexists = from gParameter in Entities.tblParameters.AsNoTracking()
                                            where gParameter.Name.ToString().ToLower().Trim() == mParameterCreation.Name.ToString().ToLower().Trim()
                                            && gParameter.IsActive == true
                                            select gParameter.Name;

                        if (IsValueexists.Count() != 0)
                        {
                            this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                            return this.GetApplicationActivate.DisplayMessage;
                        }
                        else
                        {
                            try
                            {
                                lParameter.IsActive = true;
                                lParameter.ParameterID = WBT.Common.Helper.GetUniqueNumber;
                                lParameter.Name = this.mParameterCreation.Name;
                                lParameter.Value = this.mParameterCreation.Value;
                                lParameter.ParameterType = this.mParameterCreation.ParameterType;
                                lParameter.IsActive = true;
                                lParameter.MinRange = this.mParameterCreation.MinRange;
                                lParameter.MaxRange = this.mParameterCreation.MaxRange;
                                lParameter.UnitOfMeasure = this.mParameterCreation.UnitOfMeasure;
                                if (this.mParameterCreation.CategoryID == 0)
                                    lParameter.CategoryID = null;
                                else
                                    lParameter.CategoryID = this.mParameterCreation.CategoryID;
                                if (this.mParameterCreation.SubCategoryID == 0)
                                    lParameter.SubCategoryID = null;
                                else
                                    lParameter.SubCategoryID = this.mParameterCreation.SubCategoryID;
                                if (this.mParameterCreation.DeviationPercentage == 0)
                                    lParameter.DeviationPercentage = null;
                                else
                                    lParameter.DeviationPercentage = this.mParameterCreation.DeviationPercentage;

                                lParameter.CreatedDate = WBT.Common.Helper.GetCurrentDate;
                                lParameter.UpdatedDate = WBT.Common.Helper.GetCurrentDate;

                                lParameter.CreatedByID = this.mParameterCreation.CreatedByID;

                                Entities.tblParameters.Add(lParameter);
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

        public object GetParameterMappingForItem(string searchValue, string itemCode, int CategoryID, int SubcategoryID)
        {
            lstParameterCreation = new List<DLParameterCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    var resultForItemParameterMapping = (from gParameter in Entities.tblParameters
                                                         join gitemParamMap in Entities.tblItemParameterMaps
                                                         on gParameter.ParameterID equals gitemParamMap.ParameterID
                                                         join gitem in Entities.tblItems on gitemParamMap.ItemCode equals gitem.ItemCode
                                                         select new DLParameterCreation
                                                         {
                                                             ParameterID = gParameter.ParameterID,
                                                             Name = gParameter.Name,
                                                             Value = gParameter.Value,
                                                             ItemCode = gitem.ItemCode,
                                                             MinRange = gParameter.MinRange,
                                                             MaxRange = gParameter.MaxRange,
                                                             ParameterType = gParameter.ParameterType,
                                                             UnitOfMeasure = gParameter.UnitOfMeasure,
                                                             IsParameterChecked = false
                                                         }).Where(e => e.ItemCode.ToLower().Trim() ==
                                                         itemCode.ToLower().Trim())
                                                        .ToList<DLParameterCreation>(); //ToList<DLParameterCreation>().


                    var allParameters = (from gParameter in Entities.tblParameters.AsNoTracking()
                                             //.Where(e => (e.CategoryID == null || e.CategoryID == CategoryID)
                                             //&& (e.SubCategoryID == null || e.SubCategoryID == SubcategoryID))
                                         select new DLParameterCreation
                                         {
                                             ParameterID = gParameter.ParameterID,
                                             Name = gParameter.Name,
                                             CategoryID = gParameter.CategoryID,
                                             SubCategoryID = gParameter.SubCategoryID,
                                             MinRange = gParameter.MinRange,
                                             MaxRange = gParameter.MaxRange,
                                             Value = gParameter.Value

                                         }).OrderBy(e => e.Name).ToList<DLParameterCreation>();

                    if (CategoryID > 0)
                        allParameters = allParameters.Where(i => i.CategoryID == CategoryID).ToList();

                    if(SubcategoryID>0)
                        allParameters = allParameters.Where(i => i.SubCategoryID == SubcategoryID).ToList();

                    if (resultForItemParameterMapping != null && resultForItemParameterMapping.Count > 0)
                    {
                        foreach (var parammap in resultForItemParameterMapping)
                        {
                            if (allParameters.Any(n => n.ParameterID == parammap.ParameterID))  //added warehouse condition
                            {
                                int j = allParameters.FindIndex(i => i.ParameterID == parammap.ParameterID); //Finds the item index
                                if (j >= 0)
                                {
                                    allParameters[j].IsParameterChecked = true;
                                }
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(searchValue))
                        allParameters = allParameters.Where(c => c.Name.ToLower().Trim().StartsWith(searchValue.ToLower().ToString().Trim())).ToList();

                    return allParameters;
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

        private object BindData(object Context)
        {
        //    BindAllData bindAllData = new BindAllData();
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();                        //to open the connection if closed

        //            bindAllData.DLCategoryCreation = (from c in Entities.tblCategories.AsNoTracking()
        //                                              select new DLCategoryCreation()
        //                                              {
        //                                                  CategoryID = c.CategoryID,
        //                                                  CategoryName = c.CategoryName,
        //                                              }).ToList();

        //            bindAllData.DLSubCategoryCreation = (from c in Entities.SubCategories.AsNoTracking()
        //                                                 select new DLSubCategoryCreation()
        //                                                 {
        //                                                     CategoryID = c.CategoryID,
        //                                                     SubCategoryID = c.SubCategoryID,
        //                                                     SubCategoryName = c.SubCategoryName,
        //                                                 }).ToList();
        //        }
        //    }
        //    catch (System.Data.SqlClient.SqlException sqlex)
        //    {
        //        this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
        //        this.GetApplicationActivate.GetErrormessages = sqlex.Message;
        //        this.GetApplicationActivate.GetErrorSource = sqlex.Source;
        //        this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.GetApplicationActivate.DataState = Common.TransactionType.Error;
        //        this.GetApplicationActivate.GetErrormessages = ex.Message;
        //        this.GetApplicationActivate.GetErrorSource = ex.Source;
        //        this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
        //        throw;
        //    }
            return "";
        }
    }
}
