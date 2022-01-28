using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.DL;
using WBT.DL.Transaction;
using WBT.Entity;

namespace WBT.DL.Master
{
    public class WarehouseCreation
    {
        public string WarehouseName { get; set; }
        public int WarehouseID { get; set; }
        public string BatchID { get; set; }
        public int Quantity { get; set; }
        
    }
    public class DLItemWarehouseMapCreation
    {
        public string SearchText { get; set; }
        public int ItemWarehouseMapID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int WarehouseID { get; set; }
        public string OrgID { get; set; }
        public string BranchID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public int SubCategoryID { get; set; }
        public string SubCategoryname { get; set; }
        public string WarehouseName { get; set; }
        public Nullable<int> BatchID { get; set; }
        public string BatchNumber { get; set; }
        public string Brand { get; set; }
        public Nullable<decimal> InfectedQty { get; set; }
        public decimal Quantity { get; set; }
        public decimal AvailableStock { get; set; }
        public Nullable<decimal> SaleQuantity { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        //public virtual DLItemCreation tblitem { get; set; }
        //public virtual DLUserCreation DLUser { get; set; }
        //public virtual DLWarehouseCreation DLWarehouse { get; set; }
        //public string ParentOrgID { get; set; }

        //public Nullable<decimal> NegativestockQty { get; set; }
        public Nullable<bool> IsPrimaryWarehouse { get; set; }
        //public decimal PhysicalStock { get; set; }
        public DateTime BatchCreationDate { get; set; }
        public int DestinationWarehouseID { get; set; }
        public Nullable<decimal> DeliveredQTY { get; set; }
        public string ItemAlias { get; set; }
        //public int LineItemID { get; set; }
        public bool IsFiFOSkipped { get; set; }
        //used for mobile app cat and subcat serach in one textbox
        public string CatOrSubCatName { get; set; }
        //for mobile app 5th oct 2020
        public bool IsOfferPrice { get; set; }
        public decimal ItemPrice { get; set; }
        public string Description { get; set; }
        public string IsFlagItem { get; set; }
    }

    public class DLStockimportDetails : ApplicationActivate
    {
        public string BranchID { get; set; }
        public string BranchName { get; set; }
        public int ItemWarehouseMapID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<bool> IsOBStockUpdatedToTally { get; set; }
        public decimal Quantity { get; set; }
        public string Remark { get; set; }
        public string OrgID { get; set; }
        public string sIsTallyUpdated { get; set; }
        public decimal Rate { get; set; }
        public string ItemAlias { get; set; }
        public string BaseUnitName { get; set; }
        public decimal? BasePKTValue { get; set; }
        public decimal? AlternateUnit { get; set; }
        public decimal? AlternatePKTValue { get; set; }
        public string AlternateUnitName { get; set; }
    }
    public class DLItemWarehouseMap : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private tblItemWarehouseMap lItemWareHouse = new tblItemWarehouseMap();
        private tblBatch lBatch = new tblBatch();
        private List<DLItemWarehouseMapCreation> lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
        private DLItemWarehouseMapCreation mItemWareHouseCreation = new DLItemWarehouseMapCreation();
        public WarehouseCreation warehouseCreation = new WarehouseCreation();

        public List<DLItemWarehouseMapCreation> ItemWareHouseCreation
        {
            get { return lstItemWareHouseCreation; }
            set { lstItemWareHouseCreation = value; }
        }

        public override object DataActivate(object Context)
        {
            object lResult = null;
            try
            {
                switch (this.GetApplicationActivate.DataState)
                {
                    case Common.TransactionType.Load:
                        ////DLItemWarehouseMapCreation Criteria = (DLItemWarehouseMapCreation)Context;
                        //lResult = GetData(Context);
                        break;
                    case Common.TransactionType.Save:
                        lResult = SaveData(Context);
                        break;
                    case Common.TransactionType.Delete:
                        lResult = DeleteData(Context);
                        break;
                    case Common.TransactionType.TallyUpdation:
                        lResult = ObStockUpdateStatus(Context);
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

        //private object GetData(object Context)
        //{
        //    lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();                        //to open the connection if closed

        //            DLItemWarehouseMapCreation Criteria = (DLItemWarehouseMapCreation)Context;

        //            #region old code
        //            //var result = from gItemWarehouseMap in Entities.ItemWarehouseMaps.AsNoTracking().
        //            //             Where(e => e.IsActive == true && e.Quantity != 0).Distinct().ToList()
        //            //             orderby gItemWarehouseMap.tblItem.ItemName
        //            //             select gItemWarehouseMap;

        //            //foreach (var drow in result)
        //            //{
        //            //    mItemWareHouseCreation = new DLItemWarehouseMapCreation();
        //            //    mItemWareHouseCreation.ItemWarehouseMapID = drow.ItemWarehouseMapID;
        //            //    mItemWareHouseCreation.ItemCode = drow.ItemCode;
        //            //    mItemWareHouseCreation.ItemName = drow.tblItem.ItemName;
        //            //    mItemWareHouseCreation.CategoryID = drow.tblItem.CategoryID;
        //            //    mItemWareHouseCreation.CategoryName = drow.tblItem.tblCategory.CategoryName.Trim();
        //            //    mItemWareHouseCreation.SubCategoryID = drow.tblItem.SubCategoryID;
        //            //    mItemWareHouseCreation.SubCategoryname = drow.tblItem.tblSubCategory.SubCategoryName.Trim();
        //            //    mItemWareHouseCreation.WarehouseID = drow.WarehouseID;
        //            //    mItemWareHouseCreation.WarehouseName = drow.tblWarehouse.WarehouseName.Replace(System.Environment.NewLine, " ").Trim();
        //            //    mItemWareHouseCreation.OrgID = drow.OrgID;
        //            //    mItemWareHouseCreation.BranchID = drow.tblWarehouse.BranchID;
        //            //    mItemWareHouseCreation.Brand = drow.tblItem.tblBrand.BrandName;
        //            //    mItemWareHouseCreation.BatchID = drow.BatchID;
        //            //    mItemWareHouseCreation.BatchNumber = drow.tblBatch != null ? drow.tblBatch.BatchNumber : null;
        //            //    mItemWareHouseCreation.SaleQuantity = drow.SaleQuantity ?? 0;
        //            //    mItemWareHouseCreation.InfectedQty = drow.InfectedQty ?? 0;
        //            //    mItemWareHouseCreation.Quantity = drow.Quantity - mItemWareHouseCreation.SaleQuantity.Value - mItemWareHouseCreation.InfectedQty.Value;
        //            //    mItemWareHouseCreation.ItemPrice = drow.tblItem.tblItemRate.BaseRateOther.Value;
        //            //    mItemWareHouseCreation.Description = drow.tblItem.ItemDetail.Trim();
        //            //    mItemWareHouseCreation.IsOfferPrice = drow.tblItem.tblItemRate.IsOfferRate == null ? false : drow.tblItem.tblItemRate.IsOfferRate.Value;
        //            //    mItemWareHouseCreation.tblitem = new DLItemCreation()
        //            //    {
        //            //        ItemCode = drow.tblItem.ItemCode,
        //            //        CategoryID = drow.tblItem.CategoryID,
        //            //        SubCategoryID = drow.tblItem.SubCategoryID
        //            //    };

        //            //    lstItemWareHouseCreation.Add(mItemWareHouseCreation);
        //            //}

        //            #endregion

        //            lstItemWareHouseCreation = (from drow in Entities.tblItemWarehouseMaps.AsNoTracking().
        //                           Where(e => e.IsActive == true && e.Quantity != 0).Distinct()
        //                                        orderby drow.tblItem.ItemName
        //                                        select new DLItemWarehouseMapCreation()
        //                                        {
        //                                            ItemWarehouseMapID = drow.ItemWarehouseMapID,
        //                                            ItemCode = drow.ItemCode,
        //                                            ItemName = drow.tblItem.ItemName,
        //                                            CategoryID = drow.tblItem.CategoryID,
        //                                            CategoryName = drow.tblItem.tblCategory.CategoryName.Trim(),
        //                                            SubCategoryID = drow.tblItem.SubCategoryID,
        //                                            SubCategoryname = drow.tblItem.tblSubCategory.SubCategoryName.Trim(),
        //                                            WarehouseID = drow.WarehouseID,
        //                                            WarehouseName = drow.tblWarehouse.WarehouseName.Replace(System.Environment.NewLine, " ").Trim(),
        //                                            OrgID = drow.OrgID,
        //                                            BranchID = drow.tblWarehouse.BranchID,
        //                                            Brand = drow.tblItem.tblBrand.BrandName,
        //                                            BatchID = drow.BatchID,
        //                                            //BatchNumber = drow.tblb != null ? drow.tblBatch.BatchNumber : null,
        //                                            SaleQuantity = drow.SaleQuantity ?? 0,
        //                                            InfectedQty = drow.InfectedQty ?? 0,
        //                                            Quantity = drow.Quantity - (drow.SaleQuantity == null ? 0 : drow.SaleQuantity.Value) - (drow.InfectedQty == null ? 0 : drow.InfectedQty.Value),
        //                                            ItemPrice = drow.tblItem.tblItemRate.BaseRateOther.Value,
        //                                            Description = drow.tblItem.ItemDetail.Trim(),
        //                                            IsOfferPrice = drow.tblItem.tblItemRate.IsOfferRate == null ? false : drow.tblItem.tblItemRate.IsOfferRate.Value,
        //                                            tblitem = new DLItemCreation()
        //                                            {
        //                                                ItemCode = drow.tblItem.ItemCode,
        //                                                CategoryID = drow.tblItem.CategoryID,
        //                                                SubCategoryID = drow.tblItem.SubCategoryID
        //                                            },
        //                                        }).ToList();

        //            if (!string.IsNullOrEmpty(Criteria.OrgID))
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.OrgID.Trim() == Criteria.OrgID).ToList();

        //            if (!string.IsNullOrEmpty(Criteria.SearchText))
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.ItemName.ToLower().Trim().StartsWith(Criteria.SearchText.ToLower().Trim())
        //                || c.ItemCode.Trim() == Criteria.SearchText.Trim()).ToList();

        //            #region required for mobile app 19thSep2020

        //            if (!string.IsNullOrEmpty(Criteria.BranchID) && Convert.ToInt32(Criteria.BranchID) > 0)
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.BranchID == Criteria.BranchID).ToList();

        //            if (Convert.ToInt32(Criteria.CategoryID) > 0)
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.CategoryID == Criteria.CategoryID).ToList();

        //            if (Convert.ToInt32(Criteria.SubCategoryID) > 0)
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.SubCategoryID == Criteria.SubCategoryID).ToList();

        //            if ((Criteria.WarehouseID) > 0)
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.WarehouseID == Criteria.WarehouseID).ToList();

        //            if (!string.IsNullOrEmpty(Criteria.CatOrSubCatName))
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.CategoryName.ToLower().Trim().Contains(Criteria.CatOrSubCatName.ToLower().Trim())
        //                || c.SubCategoryname.ToLower().Trim().Contains(Criteria.CatOrSubCatName.ToLower().Trim())).ToList();

        //            #endregion
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
        //    return lstItemWareHouseCreation;
        //}
        private object SaveData(object Context)
        {
            mItemWareHouseCreation = ((DLItemWarehouseMapCreation)Context);
            try
            {
                var IsValueexists = (from gBatchs in Entities.tblBatches
                                     join gItemWarehouseMap in Entities.tblItemWarehouseMaps on gBatchs.BatchID equals gItemWarehouseMap.BatchID
                                     where gBatchs.BatchNumber.ToLower().Trim().Equals(mItemWareHouseCreation.BatchNumber.ToLower().Trim())
                                     && gBatchs.IsActive == true
                                     && gItemWarehouseMap.WarehouseID == mItemWareHouseCreation.WarehouseID
                                     && gItemWarehouseMap.OrgID == mItemWareHouseCreation.OrgID
                                     select gBatchs.BatchNumber);  //to check if name exists

                if (IsValueexists.Count() != 0)
                {
                    this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                }
                else
                {
                    using (Entities = new Entity.MWBTCustomerAppEntities())
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                //To create bath bfr increasing stock
                                lBatch.IsActive = true;
                                //lBatch.BatchID = WBT.Common.Helper.GetUniqueNumber;
                                lBatch.BatchNumber = this.mItemWareHouseCreation.BatchNumber;
                                lBatch.CreatedDate = DateTime.Now;
                                lBatch.ModifiedDate = DateTime.Now;
                                lBatch.CreatedByID = mItemWareHouseCreation.CreatedByID;
                                Entities.tblBatches.Add(lBatch);
                                Entities.SaveChanges();

                                lItemWareHouse.BatchID = lBatch.BatchID;
                                lItemWareHouse.IsActive = true;
                                lItemWareHouse.ItemCode = this.mItemWareHouseCreation.ItemCode;
                                lItemWareHouse.Quantity = this.mItemWareHouseCreation.Quantity;
                                lItemWareHouse.WarehouseID = this.mItemWareHouseCreation.WarehouseID;
                                lItemWareHouse.OrgID = mItemWareHouseCreation.OrgID;
                                lItemWareHouse.BranchID = mItemWareHouseCreation.BranchID;
                                lItemWareHouse.CreatedDate = DateTime.Now;
                                lItemWareHouse.ModifiedDate = DateTime.Now;
                                lItemWareHouse.CreatedByID = mItemWareHouseCreation.CreatedByID;
                                Entities.tblItemWarehouseMaps.Add(lItemWareHouse);
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
        private object DeleteData(object Context)
        {
            mItemWareHouseCreation = ((DLItemWarehouseMapCreation)Context);
            try
            {
                lItemWareHouse = (from gItemWarehouse in Entities.tblItemWarehouseMaps.AsNoTracking().ToList()
                                  where gItemWarehouse.ItemWarehouseMapID == mItemWareHouseCreation.ItemWarehouseMapID
                                  && gItemWarehouse.OrgID == mItemWareHouseCreation.OrgID
                                  select gItemWarehouse).First();

                var lBatch = (from gbatch in Entities.tblBatches.AsNoTracking().ToList()
                              where gbatch.BatchID == mItemWareHouseCreation.BatchID && gbatch.IsActive == true
                              && gbatch.Description == "Auto Generated Batch"
                              select gbatch).First();

                if (lItemWareHouse != null)
                {
                    using (Entities = new Entity.MWBTCustomerAppEntities())
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                //if(lBatch!=null)
                                //{
                                //    lBatch.IsActive = false;
                                //    lBatch.ModifiedDate=
                                //}
                                //lItemWareHouse.CategoryName = this.mItemWareHouseCreation.CategoryName;
                                lItemWareHouse.IsActive = false;
                                lItemWareHouse.ModifiedDate = DateTime.Now;//WBT.Common.Helper.GetCurrentDatetime;
                               // lItemWareHouse.CreatedByID = Common.User.UserID;
                                Entities.tblItemWarehouseMaps.Add(lItemWareHouse);
                                Entities.Entry(lItemWareHouse).State = EntityState.Modified;
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

        public object GetAllWarehose(string ItemCode, string orgID, Nullable<int> BatchID)
        {
            lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<WarehouseCreation> warehouses = (from itemwarehouse in Entities.tblItemWarehouseMaps
                                                          join warehouse in Entities.tblWarehouses on itemwarehouse.WarehouseID equals warehouse.WarehouseID
                                                          join org in Entities.tblSysOrganizations on itemwarehouse.OrgID equals org.OrgID
                                                          where  itemwarehouse.OrgID == orgID  //itemwarehouse.ItemCode == ItemCode &&
                                                          select new WarehouseCreation
                                                          {
                                                              WarehouseName = warehouse.WarehouseName,
                                                              WarehouseID = itemwarehouse.WarehouseID,                                                              
                                                          }).Distinct().ToList();
                    if (warehouses != null && BatchID.ToString() != null && BatchID > 0)
                    {
                        warehouses = warehouses.Where(b => b.BatchID == BatchID.ToString()).ToList();
                    }                    
                    return warehouses;
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

        //Added for salesorder in getwarehouseItems popUp
        //public object GetItemWarehouseMapByProductCode(string ItemCode, string orgID, string BranchID, bool IsFIFORequired)
        //{
        //    lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            var warehouses = (from itemwarehouse in Entities.tblItemWarehouseMaps
        //                              join org in Entities.tblSysOrganizations on itemwarehouse.OrgID equals org.OrgID
        //                              join orgMap in Entities.tblSysOrganizationMaps on org.OrgID equals orgMap.SisterOrgID
        //                              select new SalesOrderItemWarehouseMapResult
        //                              {
        //                                  BatchCreationDate = itemwarehouse.tblItem.CreatedDate.Value,// batch.CreatedDate.Value,
        //                                  WarehouseID = itemwarehouse.WarehouseID,
        //                                  BranchID = itemwarehouse.BranchID.ToString(),
        //                                  ItemCode = itemwarehouse.ItemCode,
        //                                  WarehouseName = org.Name + "-" + itemwarehouse.tblWarehouse.WarehouseName + " - " + itemwarehouse.tblWarehouse.City,
        //                                  //warehouse.WarehouseName + "-" + warehouse.City,
        //                                  //BatchNumber = itemwarehouse.tblBatch.BatchNumber,// batch.BatchNumber,
        //                                  QuantityAvailable = (itemwarehouse.Quantity - (itemwarehouse.SaleQuantity ?? 0) - (itemwarehouse.InfectedQty ?? 0)),
        //                                  BatchID = itemwarehouse.BatchID,// batch.BatchID,
        //                                  OrgID = itemwarehouse.OrgID,
        //                                  ParentOrgID = orgMap.ParentOrgID,
        //                                  SisterOrgID = orgMap.SisterOrgID,
        //                                  NegativestockQty = 0,
        //                                  IsPrimaryWarehouse = itemwarehouse.tblWarehouse.IsPrimary,// warehouse.IsPrimary,
        //                                  PhysicalStock = (itemwarehouse.Quantity - (itemwarehouse.DeliveredQTY ?? 0) - (itemwarehouse.InfectedQty ?? 0)),
        //                                  FuminQty = (from fuminItems in Entities.FumigationItemWrhsDetails
        //                                              where fuminItems.ItemCode == itemwarehouse.ItemCode
        //                                              && fuminItems.WarehouseID == itemwarehouse.WarehouseID
        //                                              && fuminItems.BatchID == itemwarehouse.BatchID// batch.BatchID
        //                                              && fuminItems.FuminStatus != FumigationStatus.Completed.ToString()
        //                                              select fuminItems).FirstOrDefault().FuminQty == null ? 0 :
        //                                           (from fuminItems in Entities.FumigationItemWrhsDetails
        //                                            where fuminItems.ItemCode == itemwarehouse.ItemCode
        //                                            && fuminItems.WarehouseID == itemwarehouse.WarehouseID
        //                                            && fuminItems.BatchID == itemwarehouse.BatchID// batch.BatchID
        //                                            && fuminItems.FuminStatus != FumigationStatus.Completed.ToString()
        //                                            select fuminItems).FirstOrDefault().FuminQty,
        //                              }).Where(e => e.ItemCode == ItemCode) // && e.ParentOrgID == orgID) Sir Changes
        //                               .Distinct().ToList<SalesOrderItemWarehouseMapResult>();
                    

        //            if (IsFIFORequired == true)
        //            {
        //                warehouses = warehouses.OrderBy(b => b.BatchCreationDate).ToList<SalesOrderItemWarehouseMapResult>();
        //            }
        //            if (BranchID != null || Convert.ToInt32(BranchID) > 0)
        //            {
        //                warehouses = warehouses.Where(b => b.BranchID == BranchID).ToList<SalesOrderItemWarehouseMapResult>();
        //            }
        //            else //jan 5th 2020 bcz only org ho data shuld come.
        //            {
        //                warehouses = warehouses.Where(b => string.IsNullOrEmpty(b.BranchID)).ToList<SalesOrderItemWarehouseMapResult>();
        //            }
        //            if (!string.IsNullOrEmpty(orgID))
        //            {
        //                warehouses = warehouses.Where(b => b.ParentOrgID == orgID).ToList<SalesOrderItemWarehouseMapResult>();
        //            }
        //            //Added to get all the records
        //            //if (isCalledForEdit == false)
        //            //{
        //            //    warehouses = warehouses.Where(e => e.QuantityAvailable > 0 && e.SisterOrgID != e.ParentOrgID).ToList();
        //            //}

        //            return warehouses;
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
        //}

        //public object GetItemWarehouseMapByProductCodeDC(string ItemCode, string orgID, string BranchID)
        //{
        //    lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            var warehouses = (from itemwarehouse in Entities.tblItemWarehouseMaps
        //                              join org in Entities.tblSysOrganizations on itemwarehouse.OrgID equals org.OrgID
        //                              join orgMap in Entities.tblSysOrganizations on org.OrgID equals orgMap.SisterOrgID
        //                              select new SalesOrderItemWarehouseMapResult
        //                              {
        //                                  BatchCreationDate = itemwarehouse.tblBatch.CreatedDate.Value,// batch.CreatedDate.Value,
        //                                  WarehouseID = itemwarehouse.WarehouseID,
        //                                  BranchID = itemwarehouse.BranchID.ToString(),
        //                                  ItemCode = itemwarehouse.ItemCode,
        //                                  WarehouseName = org.Name + "-" + itemwarehouse.tblWarehouse.WarehouseName + " - " + itemwarehouse.tblWarehouse.City,
        //                                  //warehouse.WarehouseName + "-" + warehouse.City,
        //                                  BatchNumber = itemwarehouse.tblBatch.BatchNumber,// batch.BatchNumber,
        //                                  QuantityAvailable = (itemwarehouse.Quantity - (itemwarehouse.SaleQuantity ?? 0) - (itemwarehouse.InfectedQty ?? 0)),
        //                                  BatchID = itemwarehouse.BatchID,// batch.BatchID,
        //                                  OrgID = itemwarehouse.OrgID,
        //                                  ParentOrgID = orgMap.ParentOrgID,
        //                                  SisterOrgID = orgMap.SisterOrgID,
        //                                  NegativestockQty = 0,
        //                                  IsPrimaryWarehouse = itemwarehouse.tblWarehouse.IsPrimary,// warehouse.IsPrimary,
        //                                  PhysicalStock = (itemwarehouse.Quantity - (itemwarehouse.DeliveredQTY ?? 0) - (itemwarehouse.InfectedQty ?? 0)),
        //                                  FuminQty = (from fuminItems in Entities.FumigationItemWrhsDetails
        //                                              where fuminItems.ItemCode == itemwarehouse.ItemCode
        //                                              && fuminItems.WarehouseID == itemwarehouse.WarehouseID
        //                                              && fuminItems.BatchID == itemwarehouse.BatchID// batch.BatchID
        //                                              && fuminItems.FuminStatus != FumigationStatus.Completed.ToString()
        //                                              select fuminItems).FirstOrDefault().FuminQty == null ? 0 :
        //                                           (from fuminItems in Entities.FumigationItemWrhsDetails
        //                                            where fuminItems.ItemCode == itemwarehouse.ItemCode
        //                                            && fuminItems.WarehouseID == itemwarehouse.WarehouseID
        //                                            && fuminItems.BatchID == itemwarehouse.BatchID// batch.BatchID
        //                                            && fuminItems.FuminStatus != FumigationStatus.Completed.ToString()
        //                                            select fuminItems).FirstOrDefault().FuminQty,
        //                              }).Where(e => e.ItemCode == ItemCode) // && e.ParentOrgID == orgID) Sir Changes
        //                               .Distinct().ToList<SalesOrderItemWarehouseMapResult>();


        //            //if (IsFIFORequired == true)
        //            //{
        //            //    warehouses = warehouses.OrderBy(b => b.BatchCreationDate).ToList<SalesOrderItemWarehouseMapResult>();
        //            //}
        //            //if (BranchID != null || Convert.ToInt32(BranchID) > 0)
        //            //{
        //            //    warehouses = warehouses.Where(b => b.BranchID == BranchID).ToList<SalesOrderItemWarehouseMapResult>();
        //            //}
        //            //else //jan 5th 2020 bcz only org ho data shuld come.
        //            //{
        //            //    warehouses = warehouses.Where(b => string.IsNullOrEmpty(b.BranchID)).ToList<SalesOrderItemWarehouseMapResult>();
        //            //}
        //            if (!string.IsNullOrEmpty(orgID))
        //            {
        //                warehouses = warehouses.Where(b => b.ParentOrgID == orgID).ToList<SalesOrderItemWarehouseMapResult>();
        //            }
        //            //Added to get all the records
        //            //if (isCalledForEdit == false)
        //            //{
        //            //    warehouses = warehouses.Where(e => e.QuantityAvailable > 0 && e.SisterOrgID != e.ParentOrgID).ToList();
        //            //}

        //            return warehouses;
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
        //}
        //public object GetAllBatchesForItem(string ItemCode, int warehoseID, string orgID, Nullable<int> BatchID, bool IsFIFORequired)
        //{
        //    lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            var warehouses = (from itemwarehouse in Entities.tblItemWarehouseMaps
        //                              join warehouse in Entities.tblWarehouses on itemwarehouse.WarehouseID equals warehouse.WarehouseID
        //                              join org in Entities.tblSysOrganizations on itemwarehouse.OrgID equals org.OrgID
        //                              join orgMap in Entities.tblSysOrganizationMaps on org.OrgID equals orgMap.SisterOrgID
        //                              join batch in Entities.tblBatches on itemwarehouse.BatchID equals batch.BatchID
        //                              join item in Entities.tblItems on itemwarehouse.ItemCode equals item.ItemCode
        //                              select new DLItemWarehouseMapCreation
        //                              {
        //                                  BatchCreationDate = batch.CreatedDate.Value,
        //                                  WarehouseName = warehouse.WarehouseName,
        //                                  WarehouseID = itemwarehouse.WarehouseID,
        //                                  BranchID = itemwarehouse.BranchID.ToString(),
        //                                  ItemCode = itemwarehouse.ItemCode,
        //                                  //WarehouseName = org.Name + "-" + warehouse.WarehouseName + "-" + warehouse.City,
        //                                  BatchNumber = batch.BatchNumber,
        //                                  AvailableStock = (itemwarehouse.Quantity - (itemwarehouse.SaleQuantity ?? 0) - (itemwarehouse.InfectedQty ?? 0)),
        //                                  BatchID = batch.BatchID,
        //                                  OrgID = itemwarehouse.OrgID,
        //                                  DestinationWarehouseID = itemwarehouse.WarehouseID,
        //                              }).Where(e => e.ItemCode == ItemCode && e.OrgID == orgID && e.AvailableStock > 0)
        //                               .OrderBy(e => e.BatchCreationDate)  // e.WarehouseID == warehoseID &&
        //                               .Distinct()
        //                               .ToList<DLItemWarehouseMapCreation>();

        //            if (IsFIFORequired == true)
        //            {
        //                warehouses = warehouses.OrderBy(b => b.BatchCreationDate).ToList<DLItemWarehouseMapCreation>();
        //            }

        //            if (warehouses != null && BatchID.ToString() != null && BatchID > 0)
        //            {
        //                warehouses = warehouses.Where(b => b.BatchID == BatchID).ToList<DLItemWarehouseMapCreation>();

        //            }
        //            return warehouses;
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
        //}

        public class GetItemPopUpData
        {
            public string BranchID { get; set; }
            public string ItemName { get; set; }
            public string ItemCode { get; set; }
            public string ItemAlias { get; set; }
            public Nullable<decimal> BagQTY { get; set; }
            public Nullable<int> BagUOMID { get; set; }
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public int SubCategoryID { get; set; }
            public string SubCategoryName { get; set; }
            public bool? IsOfferRate { get; set; }
            public Nullable<int> PerUnitRate { get; set; }
            public string PerUnitRateName { get; set; }
            public string BagUOM { get; set; }
            public decimal? Available_Quantity { get; set; }
            public decimal Quantity { get; set; }
            public decimal? Salesquantity { get; set; }
            public string OrgID { get; set; }
        }
        //manually bringing used in controllers
        //public List<GetItemPopUpData> GetAllItemsInWarehouseWithSISOrgItems(string SearchItemName, object orgOBJ)
        //{
        //    try
        //    {
        //        List<DLOrganizationMappingCreation> OrgsIdLst = (List<DLOrganizationMappingCreation>)orgOBJ;
        //        List<GetItemPopUpData> NewqueryResult = new List<GetItemPopUpData>();

        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            foreach (var Getorgid in OrgsIdLst)
        //            {
        //                //Warehouse join is commented to show all the items in the Sales Order Windows
        //                List<GetItemPopUpData>
        //                    queryResult = (from i in Entities.tblItems.AsNoTracking()
        //                                   where i.IsActive == true && i.OrgID == Getorgid.SisterOrgID
        //                                   && (string.IsNullOrEmpty(SearchItemName) ||
        //                                   (i.ItemName.Contains(SearchItemName) ||
        //                                   i.Alias.Contains(SearchItemName)))
        //                                   select new GetItemPopUpData
        //                                   {
        //                                       ItemCode = i.ItemCode,
        //                                       ItemName = i.ItemName,
        //                                       ItemAlias = i.Alias,
        //                                       BagQTY = i.BagQTY,               //inner pck qtt
        //                                       BagUOM = i.tblUOM != null ? i.tblUOM.Unit : "",   //inner pck unit
        //                                       OrgID = i.OrgID,
        //                                       CategoryID = i.CategoryID,

        //                                       SubCategoryID = i.SubCategoryID,
        //                                       CategoryName = i.tblCategory.CategoryName.Trim(), //For mobile app
        //                                       SubCategoryName = i.tblSubCategory.SubCategoryName.Trim(), //For mobile app
        //                                       IsOfferRate = i.tblItemRate.IsOfferRate,
        //                                   }).Distinct().ToList<GetItemPopUpData>();

        //                NewqueryResult.AddRange(queryResult);
        //            }
        //            //queryResult= queryResult.Where(i => orgOBJ.Contains(i.OrgID));
        //            //queryResult=queryResult.Where(orgOBJ.Contains(queryResult.ForEach(i=>i.OrgID)

        //            //NewqueryResult = NewqueryResult.Where(i => i.OrgID.Contains(OrgsIdLst.ToString()));
        //            return NewqueryResult = NewqueryResult.OrderBy(i => i.ItemName).ToList();
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
        //}

        //as sister concern items should manually be binded at HO no need to check mappping items 20th jan 2021 by sneha
        public List<GetItemPopUpData> GetAllItemsOFOrg(string OrgID, string BranchID)
        {
            try
            {
                List<GetItemPopUpData> NewqueryResult = new List<GetItemPopUpData>();

                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();


                    //Warehouse join is commented to show all the items in the Sales Order Windows
                    List<GetItemPopUpData> queryResult = (from i in Entities.tblItems.AsNoTracking()
                                                          join itemmap in Entities.tblItemMappings on i.ItemCode equals itemmap.ItemCode
                                                          where itemmap.OrgID == OrgID
                                                          && itemmap.IsActive == true
                                                          select new GetItemPopUpData
                                                          {
                                                              ItemCode = i.ItemCode,
                                                              ItemName = i.ItemName,
                                                              ItemAlias = i.Alias,
                                                              BagQTY = i.BagQTY,               //inner pck qtt
                                                              BagUOM = i.tblUOM != null ? i.tblUOM.Unit : "",   //inner pck unit
                                                              OrgID = itemmap.OrgID,
                                                              CategoryID = i.CategoryID,
                                                              SubCategoryID = i.SubCategoryID,
                                                              CategoryName = i.tblCategory.CategoryName.Trim(), //For mobile app
                                                              SubCategoryName = i.tblSubCategory.SubCategoryName.Trim(), //For mobile app
                                                              IsOfferRate = itemmap.tblItemRate.IsOfferRate,
                                                              BranchID = itemmap.BranchID,
                                                          }).Distinct().ToList<GetItemPopUpData>();



                    if (!string.IsNullOrEmpty(BranchID) && Convert.ToInt32(BranchID) > 0)
                        queryResult = queryResult.Where(i => i.BranchID == BranchID).ToList();
                    else
                        queryResult = queryResult.Where(i => i.BranchID == null).ToList();

                    NewqueryResult.AddRange(queryResult);

                    return NewqueryResult = NewqueryResult.OrderBy(i => i.ItemName).ToList();
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

        public List<GetItemPopUpData> GetAllItemsOFORG_PCN(string OrgID, string BranchID)
        {
            try
            {
                List<GetItemPopUpData> NewqueryResult = new List<GetItemPopUpData>();

                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();


                    //Warehouse join is commented to show all the items in the Sales Order Windows
                    List<GetItemPopUpData> queryResult = (from i in Entities.tblItems.AsNoTracking()
                                                          join itemmap in Entities.tblItemMappings on i.ItemCode equals itemmap.ItemCode
                                                          join itemwarehousmap in Entities.tblItemWarehouseMaps on i.ItemCode equals itemwarehousmap.ItemCode
                                                          where itemmap.OrgID == OrgID
                                                          && itemmap.IsActive == true && itemmap.tblItem.isProcessItem == false
                                                          select new GetItemPopUpData
                                                          {
                                                              ItemCode = i.ItemCode,
                                                              ItemName = i.ItemName,
                                                              ItemAlias = i.Alias,
                                                              BagQTY = i.BagQTY,                                  //inner pck qtt
                                                              BagUOM = i.tblUOM != null ? i.tblUOM.Unit : "",     //inner pck unit
                                                              OrgID = itemmap.OrgID,
                                                              CategoryID = i.CategoryID,
                                                              SubCategoryID = i.SubCategoryID,
                                                              CategoryName = i.tblCategory.CategoryName.Trim(),           //For mobile app
                                                              SubCategoryName = i.tblSubCategory.SubCategoryName.Trim(), //For mobile app
                                                              IsOfferRate = itemmap.tblItemRate.IsOfferRate,
                                                              BranchID = itemmap.BranchID,
                                                              Quantity = itemwarehousmap.Quantity,
                                                              Salesquantity = itemwarehousmap.SaleQuantity,
                                                              //Available_Quantity= 
                                                          }).Distinct().ToList<GetItemPopUpData>();


                    queryResult = queryResult.GroupBy(ac => new
                    {
                        ac.ItemCode
                    }).Select(g => new GetItemPopUpData
                    {
                        ItemCode = g.Key.ItemCode,
                        ItemName = g.Select(i => i.ItemName).FirstOrDefault(),
                        ItemAlias = g.Select(i => i.ItemAlias).FirstOrDefault(),
                        BagQTY = g.Select(i => i.BagQTY).FirstOrDefault(),
                        BagUOM = g.Select(i => i.BagUOM).FirstOrDefault(),
                        OrgID = g.Select(i => i.OrgID).FirstOrDefault(),
                        CategoryID = g.Select(i => i.CategoryID).FirstOrDefault(),
                        SubCategoryID = g.Select(i => i.SubCategoryID).FirstOrDefault(),
                        CategoryName = g.Select(i => i.CategoryName).FirstOrDefault(),
                        SubCategoryName = g.Select(i => i.SubCategoryName).FirstOrDefault(),
                        IsOfferRate = g.Select(i => i.IsOfferRate).FirstOrDefault(),
                        BranchID = g.Select(i => i.BranchID).FirstOrDefault(),
                        Quantity = g.Sum(i => i.Quantity),
                        Salesquantity = g.Sum(i => i.Salesquantity),
                        Available_Quantity = g.Sum(i => i.Quantity) - g.Sum(i => i.Salesquantity),
                    }).ToList();




                    if (!string.IsNullOrEmpty(BranchID) && Convert.ToInt32(BranchID) > 0)
                        queryResult = queryResult.Where(i => i.BranchID == BranchID).ToList();
                    else
                        queryResult = queryResult.Where(i => i.BranchID == null).ToList();

                    NewqueryResult.AddRange(queryResult);

                    return NewqueryResult = NewqueryResult.OrderBy(i => i.ItemName).ToList();
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


        
        //public object GetAllPackaingMaterial(string SearchItemName, object orgOBJ, int categoryId)
        //{

        //    try
        //    {
        //        List<DLOrganizationMappingCreation> OrgsIdLst = (List<DLOrganizationMappingCreation>)orgOBJ;
        //        List<DLItemCreation> NewqueryResult = new List<DLItemCreation>();
        //        using (Entities = new WBT.Entity.MWBTechnologyEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            foreach (var Getorgid in OrgsIdLst)
        //            {
        //                //Warehouse join is commented to show all the items in the Sales Order Windows
        //                List<DLItemCreation>
        //                    queryResult = (from i in Entities.Items.AsNoTracking()
        //                                   where i.IsActive == true
        //                                   && i.OrgID == Getorgid.SisterOrgID
        //                                   && (string.IsNullOrEmpty(SearchItemName) ||
        //                                   (i.ItemName.Contains(SearchItemName) || i.Alias.Contains(SearchItemName)))
        //                                   && i.CategoryID == categoryId
        //                                   select new DLItemCreation
        //                                   {
        //                                       ItemCode = i.ItemCode,
        //                                       ItemName = i.ItemName,
        //                                       ItemAlias = i.Alias,
        //                                       BagQTY = i.BagQTY,               //inner pck qtt
        //                                       BagUOM = i.tblUOM != null ? i.tblUOM.Unit : "",   //inner pck unit
        //                                       OrgID = i.OrgID,
        //                                       Quantity = (from iwr in Entities.ItemWarehouseMaps
        //                                                   where iwr.OrgID == i.OrgID && iwr.ItemCode == i.ItemCode
        //                                                   select iwr).Count() > 0 ? ((from iwr in Entities.ItemWarehouseMaps
        //                                                                               where iwr.OrgID == i.OrgID && iwr.ItemCode == i.ItemCode
        //                                                                               select iwr).Sum(j => j.Quantity) -
        //                                                                          (from iwr in Entities.ItemWarehouseMaps
        //                                                                           where iwr.OrgID == i.OrgID && iwr.ItemCode == i.ItemCode
        //                                                                           select iwr).Sum(k => k.SaleQuantity ?? 0)) : 0,
        //                                       //(i.tblItemWarehouseMaps != null && i.tblItemWarehouseMaps.Count>0) ? (i.tblItemWarehouseMaps.FirstOrDefault().Quantity):0
        //                                       //- (i.tblItemWarehouseMaps.FirstOrDefault().SaleQuantity ?? 0)
        //                                       //- (i.tblItemWarehouseMaps.FirstOrDefault().InfectedQty ?? 0)) : 0

        //                                   }).Distinct().ToList<DLItemCreation>();
        //                NewqueryResult.AddRange(queryResult);
        //            }

        //            return NewqueryResult.OrderBy(i => i.ItemName);
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
        //}

        //Used in Item stock transfer or brand trasfer
        //public object GetAllItemsForWarehouse(int WarehouseID)
        //{
        //    try

        //    {
        //        //bool whareClause = string.IsNullOrEmpty(WarehouseName);
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            //Warehouse join is commented to show all the items in the Sales Order Windows
        //            List<DLItemCreation> queryResult = (from i in Entities.Items.AsNoTracking()
        //                                                join w in Entities.ItemWarehouseMaps.AsNoTracking() on i.ItemCode equals w.ItemCode
        //                                                where i.IsActive == true && i.isProcessItem == false
        //                                                && !i.ItemName.ToUpper().Contains("Empty")
        //                                                && w.IsActive == true
        //                                                && w.WarehouseID == WarehouseID
        //                                                select new DLItemCreation
        //                                                {
        //                                                    ItemCode = i.ItemCode,
        //                                                    ItemName = i.ItemName,
        //                                                    ItemAlias = i.Alias,
        //                                                    BagQTY = i.BagQTY,             //inner pck qtt
        //                                                    BagUOM = i.tblUOM != null ? i.tblUOM.Unit : ""    //inner pck unit

        //                                                }).Distinct().ToList<DLItemCreation>();
        //            return queryResult;
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
        //}
        //not used
        //public object GetAllItemsForWarehousecategory(int WarehouseID, int categoryId)
        //{
        //    try
        //    {
        //        //bool whareClause = string.IsNullOrEmpty(WarehouseName);
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            //Warehouse join is commented to show all the items in the Sales Order Windows
        //            List<DLItemCreation> queryResult = (from i in Entities.Items.AsNoTracking()
        //                                                join w in Entities.ItemWarehouseMaps.AsNoTracking() on i.ItemCode equals w.ItemCode
        //                                                where i.IsActive == true
        //                                                && w.IsActive == true
        //                                                && w.WarehouseID == WarehouseID
        //                                                && i.CategoryID == categoryId
        //                                                select new DLItemCreation
        //                                                {
        //                                                    ItemCode = i.ItemCode,
        //                                                    ItemName = i.ItemName,
        //                                                    ItemAlias = i.Alias,
        //                                                    BagQTY = i.BagQTY,               //inner pck qtt
        //                                                    BagUOM = i.tblUOM != null ? i.tblUOM.Unit : ""    //inner pck unit

        //                                                }).Distinct().ToList<DLItemCreation>();
        //            return queryResult;
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
        //}

        public object GetItemWarehouseMapByItemCode(string ItemCode, string orgID, string BranchID)
        {
            lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var warehouses = (from itemwarehouse in Entities.tblItemWarehouseMaps
                                      join warehouse in Entities.tblWarehouses on itemwarehouse.WarehouseID equals warehouse.WarehouseID
                                      join org in Entities.tblSysOrganizations on itemwarehouse.OrgID equals org.OrgID
                                      join orgMap in Entities.tblSysOrganizationMaps on org.OrgID equals orgMap.SisterOrgID
                                      //join batch in Entities.Batches on itemwarehouse.BatchID equals batch.BatchID
                                      join item in Entities.tblItems on itemwarehouse.ItemCode equals item.ItemCode
                                      where itemwarehouse.ItemCode == ItemCode && itemwarehouse.OrgID == orgID
                                      && itemwarehouse.OrgID == orgID
                                      select new DLItemWarehouseMapCreation
                                      {
                                          ItemAlias = itemwarehouse.tblItem.Alias,
                                          WarehouseID = itemwarehouse.WarehouseID,
                                          BranchID = itemwarehouse.BranchID.ToString(),
                                          ItemCode = itemwarehouse.ItemCode,
                                          ItemName = itemwarehouse.tblItem.ItemName,
                                          //WarehouseName = warehouse.WarehouseName,
                                          WarehouseName = org.Name + "-" + warehouse.WarehouseName + "-" + warehouse.City,
                                          AvailableStock = (itemwarehouse.Quantity - (itemwarehouse.SaleQuantity ?? 0) - (itemwarehouse.InfectedQty ?? 0)),

                                      })/*.Where(e => e.OrgID == orgID)*/
                                       .Distinct()
                                       .Where(w => w.AvailableStock > 0)
                                       .ToList<DLItemWarehouseMapCreation>();


                    if (warehouses != null && warehouses.Count > 0 &&
                        BranchID != null || Convert.ToInt32(BranchID) > 0)
                    {
                        warehouses = warehouses.Where(b => b.BranchID == BranchID).ToList<DLItemWarehouseMapCreation>();
                    }

                    return warehouses;
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


        //public object GetWarehouseStockList(string ItemCode, string orgID, string BranchID)
        //{
        //    lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();

        //            var warehouses = (from itemwarehouse in Entities.ItemWarehouseMaps
        //                              join warehouse in Entities.Warehouses on itemwarehouse.WarehouseID equals warehouse.WarehouseID
        //                              join org in Entities.Organizations on itemwarehouse.OrgID equals org.OrgID
        //                              join orgMap in Entities.OrganizationMaps on org.OrgID equals orgMap.SisterOrgID
        //                              join item in Entities.Items on itemwarehouse.ItemCode equals item.ItemCode
        //                              where itemwarehouse.ItemCode == ItemCode
        //                              && itemwarehouse.OrgID == orgID
        //                              //&& warehouse.BranchID == null
        //                              select new DLItemWarehouseMapCreation
        //                              {
        //                                  WarehouseID = itemwarehouse.WarehouseID,
        //                                  //BranchID = itemwarehouse.BranchID.ToString(),
        //                                  //ItemCode = itemwarehouse.ItemCode,
        //                                  // WarehouseName = org.Name + "-" + warehouse.WarehouseName + "-" + warehouse.City,
        //                                  WarehouseName = warehouse.WarehouseName,
        //                                  AvailableStock = (itemwarehouse.Quantity - ((itemwarehouse.SaleQuantity ?? 0) + (itemwarehouse.InfectedQty ?? 0))),
        //                              }
        //                              )
        //                               .GroupBy(w => new
        //                               {
        //                                   w.WarehouseID
        //                               })
        //                                .Select(ac => new DLItemWarehouseMapCreation
        //                                {
        //                                    WarehouseID = ac.Key.WarehouseID,
        //                                    WarehouseName = ac.Select(f => f.WarehouseName).FirstOrDefault(),
        //                                    //AvailableStock = ac.Select(acs => acs.AvailableStock).FirstOrDefault()
        //                                    AvailableStock = ac.Sum(s => s.AvailableStock)
        //                                    //DeliveredQTY = ac.Sum(acs => acs.DeliveredQTY),
        //                                })
        //                               .Distinct()
        //                               .Where(w => w.AvailableStock > 0)
        //                               .ToList<DLItemWarehouseMapCreation>();


        //            if (warehouses != null && warehouses.Count > 0 &&
        //               BranchID != null || Convert.ToInt32(BranchID) > 0)
        //            {
        //                warehouses = warehouses.Where(b => b.BranchID == BranchID).ToList<DLItemWarehouseMapCreation>();
        //            }

        //            return warehouses;
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
        //}


        public object GetStockInHand(string ItemCode, int WarehouseID, int? BatchID, string OrgID)
        {
            lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    var drow = (from gItemWarehouseMap in Entities.tblItemWarehouseMaps.AsNoTracking().
                                 Where(e => e.IsActive == true
                                 && e.ItemCode == ItemCode
                                 && e.WarehouseID == WarehouseID
                                 && e.BatchID == BatchID
                                 && e.OrgID == OrgID)
                                select gItemWarehouseMap).FirstOrDefault();

                    if (drow != null)
                    {
                        mItemWareHouseCreation = new DLItemWarehouseMapCreation();
                        mItemWareHouseCreation.Quantity = drow.Quantity;
                        mItemWareHouseCreation.SaleQuantity = drow.SaleQuantity ?? 0;
                        mItemWareHouseCreation.InfectedQty = drow.InfectedQty ?? 0;
                        //drow.Quantity;// - (drow.SaleQuantity ?? 0);
                        return mItemWareHouseCreation;

                    }

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
            return null;
        }

        //sales ordder
        public object IncrementSaleQtyStock(object Context)
        {
            DLItemWarehouseMapCreation Criteria = (DLItemWarehouseMapCreation)Context;
            using (Entities = new Entity.MWBTCustomerAppEntities())
            {
                using (var dbcxtransaction = Entities.Database.BeginTransaction())
                {
                    try
                    {
                        var stock = Entities.tblItemWarehouseMaps.AsNoTracking().Where(e => e.WarehouseID == Criteria.WarehouseID
                                    && e.BatchID == Criteria.BatchID
                                    && e.ItemCode == Criteria.ItemCode
                                    && e.OrgID == Criteria.OrgID).FirstOrDefault();
                        if (stock != null)
                        {
                            stock.SaleQuantity = Criteria.Quantity + (stock.SaleQuantity ?? 0);     //In Quantity Im getting The Edited QTY                   
                            stock.ModifiedDate = DateTime.Now;
                            stock.ModifiedByID = Criteria.ModifiedByID;
                            Entities.tblItemWarehouseMaps.Attach(stock);
                            Entities.Entry(stock).State = EntityState.Modified;
                            Entities.SaveChanges();
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
            return this.GetApplicationActivate;
        }
        public object DecreaseSaleQTYStock(object Context)
        {
            DLItemWarehouseMapCreation Criteria = (DLItemWarehouseMapCreation)Context;
            using (Entities = new Entity.MWBTCustomerAppEntities())
            {
                using (var dbcxtransaction = Entities.Database.BeginTransaction())
                {
                    try
                    {
                        var stock = Entities.tblItemWarehouseMaps.AsNoTracking().Where(e => e.WarehouseID == Criteria.WarehouseID
                                    && e.BatchID == Criteria.BatchID
                                    && e.ItemCode == Criteria.ItemCode
                                    && e.OrgID == Criteria.OrgID).FirstOrDefault();
                        if (stock != null)
                        {
                            stock.SaleQuantity = stock.SaleQuantity - Criteria.Quantity;
                            stock.ModifiedDate = DateTime.Now;
                            stock.ModifiedByID = Criteria.ModifiedByID;
                            Entities.tblItemWarehouseMaps.Attach(stock);
                            Entities.Entry(stock).State = EntityState.Modified;
                            Entities.SaveChanges();
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
            return this.GetApplicationActivate;
        }
        public object DecreaseQTYStock(object Context)
        {
            DLItemWarehouseMapCreation Criteria = (DLItemWarehouseMapCreation)Context;
            // DLStockTransferHeaderCreation Criteria = (DLStockTransferHeaderCreation)Context;
            using (Entities = new Entity.MWBTCustomerAppEntities())
            {
                using (var dbcxtransaction = Entities.Database.BeginTransaction())
                {
                    try
                    {
                        var stock = Entities.tblItemWarehouseMaps.AsNoTracking().Where(e => e.BatchID == Criteria.BatchID
                                    && e.ItemCode == Criteria.ItemCode).FirstOrDefault();//e.WarehouseID == Criteria.WarehouseID &&
                        if (stock != null)
                        {
                            stock.SaleQuantity = stock.Quantity - Criteria.Quantity;//stock.SaleQuantity - Criteria.Quantity;
                            stock.ModifiedDate = DateTime.Now;
                            stock.ModifiedByID = Criteria.ModifiedByID;
                            Entities.tblItemWarehouseMaps.Attach(stock);
                            Entities.Entry(stock).State = EntityState.Modified;
                            Entities.SaveChanges();
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
            return this.GetApplicationActivate;
        }
        public class SalesOrderItemWarehouseMapResult
        {
            public int ID { get; set; }
            public string ItemName { get; set; }
            public string BranchID { get; set; }
            public Nullable<DateTime> BatchCreationDate { get; set; }
            public int WarehouseID { get; set; }
            public string ItemCode { get; set; }
            public decimal NegativestockQty { get; set; }
            public string WarehouseName { get; set; }
            public string BatchNumber { get; set; }
            public string PKTWT { get; set; }
            public decimal QuantityAvailable { get; set; }
            public decimal Quantity { get; set; }
            //26/12/2019 while editing SO not able to remove the old lineitem if mane it zero so added
            public decimal EditedQuantity { get; set; }
            public int? PacketSizeID { get; set; }
            public int? BatchID { get; set; }
            public int IsCorrectionRequired { get; set; }
            public bool IsNegativeStock { get; set; }
            public int Priority { get; set; }
            public string OrgID { get; set; }
            public string ParentOrgID { get; set; }
            public string SisterOrgID { get; set; }
            public DateTime Date { get; set; }
            public Guid LineItemID { get; set; }
            public Nullable<bool> IsPrimaryWarehouse { get; set; }
            public bool IsFiFOSkipped { get; set; }
            public decimal PhysicalStock { get; set; }
            //added on 20 Aug for compile all - Devika 
            public string RequistionNumber { get; set; }
            public string DCNo { get; set; }
            public int DCItemMapID { get; set; }

            public int? FuminQty { get; set; }
        }

        //stock release
        public object InCreaseStockAfterRelease(object Context)
        {
            List<DLItemWarehouseMapCreation> ItemDetails = (List<DLItemWarehouseMapCreation>)Context;
            using (Entities = new Entity.MWBTCustomerAppEntities())
            {
                using (var dbcxtransaction = Entities.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var Criteria in ItemDetails)
                        {
                            var stock = Entities.tblItemWarehouseMaps.AsNoTracking().Where(e => e.WarehouseID == Criteria.WarehouseID
                                  && e.BatchID == Criteria.BatchID
                                  && e.ItemCode == Criteria.ItemCode
                                  && e.OrgID == Criteria.OrgID).FirstOrDefault();
                            if (stock != null)
                            {
                                stock.SaleQuantity = stock.SaleQuantity - Criteria.SaleQuantity;    //In Quantity Im getting The Edited QTY                   
                                stock.ModifiedDate = DateTime.Now;
                                stock.ModifiedByID = Criteria.ModifiedByID;
                                Entities.tblItemWarehouseMaps.Attach(stock);
                                Entities.Entry(stock).State = EntityState.Modified;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;

                            }
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
            return this.GetApplicationActivate;
        }

        //public object GetWareHouseStock(object Context)
        //{
        //    lstItemWareHouseCreation = new List<DLItemWarehouseMapCreation>();
        //    try
        //    {
        //        using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
        //        {
        //            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
        //                Entities.Database.Connection.Open();                        //to open the connection if closed

        //            DLItemWarehouseMapCreation Criteria = (DLItemWarehouseMapCreation)Context;

        //            var result = from gItemWarehouseMap in Entities.ItemWarehouseMaps.AsNoTracking().
        //                         Where(e => e.IsActive == true && e.Quantity != 0).Distinct().ToList()
        //                         orderby gItemWarehouseMap.tblItem.ItemName
        //                         select gItemWarehouseMap;

        //            foreach (var drow in result)
        //            {
        //                mItemWareHouseCreation = new DLItemWarehouseMapCreation();
        //                mItemWareHouseCreation.ItemWarehouseMapID = drow.ItemWarehouseMapID;
        //                mItemWareHouseCreation.ItemCode = drow.ItemCode;
        //                mItemWareHouseCreation.ItemName = drow.tblItem.ItemName;
        //                mItemWareHouseCreation.CategoryID = drow.tblItem.CategoryID;
        //                mItemWareHouseCreation.CategoryName = drow.tblItem.tblCategory.CategoryName.Trim();
        //                mItemWareHouseCreation.SubCategoryname = drow.tblItem.tblSubCategory.SubCategoryName.Trim();
        //                mItemWareHouseCreation.SubCategoryID = drow.tblItem.SubCategoryID;
        //                mItemWareHouseCreation.WarehouseID = drow.WarehouseID;
        //                mItemWareHouseCreation.WarehouseName = drow.tblWarehouse.WarehouseName.Replace(System.Environment.NewLine, " ").Trim();
        //                mItemWareHouseCreation.OrgID = drow.OrgID;
        //                mItemWareHouseCreation.BranchID = drow.tblWarehouse.BranchID;
        //                mItemWareHouseCreation.BatchID = drow.BatchID;
        //                mItemWareHouseCreation.BatchNumber = drow.tblBatch != null ? drow.tblBatch.BatchNumber : null;
        //                mItemWareHouseCreation.Brand = drow.tblItem.tblBrand.BrandName;
        //                mItemWareHouseCreation.SaleQuantity = drow.SaleQuantity ?? 0;
        //                mItemWareHouseCreation.InfectedQty = drow.InfectedQty ?? 0;
        //                mItemWareHouseCreation.Quantity = drow.Quantity - mItemWareHouseCreation.SaleQuantity.Value - mItemWareHouseCreation.InfectedQty.Value;
        //                mItemWareHouseCreation.tblitem = new DLItemCreation()
        //                {
        //                    ItemCode = drow.tblItem.ItemCode,
        //                    CategoryID = drow.tblItem.CategoryID,
        //                    SubCategoryID = drow.tblItem.SubCategoryID
        //                };

        //                lstItemWareHouseCreation.Add(mItemWareHouseCreation);
        //            }


        //            if (!string.IsNullOrEmpty(Criteria.OrgID))
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.OrgID.Trim() == Criteria.OrgID).ToList();

        //            if (!string.IsNullOrEmpty(Criteria.SearchText))
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.ItemName.ToLower().Trim().Contains(Criteria.SearchText.ToLower().Trim())
        //                || c.ItemCode.Trim() == Criteria.SearchText.Trim()).ToList();
        //            #region required for mobile app 19thSep2020

        //            if (!string.IsNullOrEmpty(Criteria.BranchID) && Convert.ToInt32(Criteria.BranchID) > 0)
        //            {
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.BranchID == Criteria.BranchID).ToList();
        //            }

        //            if ((Criteria.WarehouseID) > 0)
        //            {
        //                lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.WarehouseID == Criteria.WarehouseID).ToList();

        //                if (Criteria.SubCategoryID > 0)
        //                {
        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.SubCategoryID == Criteria.SubCategoryID).ToList();

        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.GroupBy(ac => new
        //                    {
        //                        ac.ItemCode
        //                    }).Select(g => new DLItemWarehouseMapCreation
        //                    {
        //                        CategoryID = g.Select(i => i.CategoryID).FirstOrDefault(),
        //                        CategoryName = g.Select(i => i.CategoryName).FirstOrDefault(),
        //                        SubCategoryID = g.Select(i => i.SubCategoryID).FirstOrDefault(),
        //                        SubCategoryname = g.Select(i => i.SubCategoryname).FirstOrDefault(),
        //                        WarehouseID = g.Select(i => i.WarehouseID).FirstOrDefault(),
        //                        WarehouseName = g.Select(i => i.WarehouseName).FirstOrDefault(),
        //                        BatchNumber = g.Select(i => i.BatchNumber).FirstOrDefault(),
        //                        Brand = g.Select(i => i.Brand).FirstOrDefault(),
        //                        ItemName = g.Select(i => i.ItemName).FirstOrDefault(),
        //                        ItemCode = g.Key.ItemCode,
        //                        Quantity = g.Sum(i => i.Quantity),
        //                        OrgID = g.Select(i => i.OrgID).FirstOrDefault(),
        //                    }).OrderBy(i => i.ItemName).ToList();
        //                }
        //                else if (Criteria.CategoryID > 0)
        //                {
        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.CategoryID == Criteria.CategoryID).ToList();

        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.GroupBy(ac => new
        //                    {
        //                        ac.SubCategoryID
        //                    }).Select(g => new DLItemWarehouseMapCreation
        //                    {
        //                        CategoryID = g.Select(i => i.CategoryID).FirstOrDefault(),
        //                        CategoryName = g.Select(i => i.CategoryName).FirstOrDefault(),
        //                        SubCategoryID = g.Key.SubCategoryID,
        //                        SubCategoryname = g.Select(i => i.SubCategoryname).FirstOrDefault(),
        //                        WarehouseID = g.Select(i => i.WarehouseID).FirstOrDefault(),
        //                        WarehouseName = g.Select(i => i.WarehouseName).FirstOrDefault(),
        //                        Quantity = g.Sum(i => i.Quantity),
        //                        OrgID = g.Select(i => i.OrgID).FirstOrDefault(),
        //                    }).OrderBy(i => i.SubCategoryname).ToList();
        //                }
        //                else
        //                {
        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.GroupBy(ac => new
        //                    {
        //                        ac.CategoryID
        //                    }).Select(g => new DLItemWarehouseMapCreation
        //                    {
        //                        CategoryID = g.Key.CategoryID,
        //                        ItemCode = g.Select(i => i.ItemCode).FirstOrDefault(),
        //                        ItemName = g.Select(i => i.ItemName).FirstOrDefault(),
        //                        CategoryName = g.Select(i => i.CategoryName).FirstOrDefault(),
        //                        SubCategoryID = g.Select(i => i.SubCategoryID).FirstOrDefault(),
        //                        SubCategoryname = g.Select(i => i.SubCategoryname).FirstOrDefault(),
        //                        WarehouseID = g.Select(i => i.WarehouseID).FirstOrDefault(),
        //                        WarehouseName = g.Select(i => i.WarehouseName).FirstOrDefault(),
        //                        Quantity = g.Sum(i => i.Quantity),
        //                        OrgID = g.Select(i => i.OrgID).FirstOrDefault(),
        //                    }).OrderBy(i => i.CategoryName).ToList();
        //                }

        //                if (!string.IsNullOrEmpty(Criteria.CatOrSubCatName))
        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.CategoryName.ToLower().Trim().Contains(Criteria.CatOrSubCatName.ToLower().Trim())
        //                    || c.SubCategoryname.ToLower().Trim().Contains(Criteria.CatOrSubCatName.ToLower().Trim())).ToList();
        //            }
        //            else
        //            {
        //                if (Criteria.SubCategoryID > 0)
        //                {
        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.SubCategoryID == Criteria.SubCategoryID).ToList();

        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.GroupBy(ac => new
        //                    {
        //                        ac.ItemCode
        //                    }).Select(g => new DLItemWarehouseMapCreation
        //                    {
        //                        CategoryID = g.Select(i => i.CategoryID).FirstOrDefault(),
        //                        CategoryName = g.Select(i => i.CategoryName).FirstOrDefault(),
        //                        SubCategoryID = g.Select(i => i.SubCategoryID).FirstOrDefault(),
        //                        SubCategoryname = g.Select(i => i.SubCategoryname).FirstOrDefault(),
        //                        WarehouseID = g.Select(i => i.WarehouseID).FirstOrDefault(),
        //                        WarehouseName = g.Select(i => i.WarehouseName).FirstOrDefault(),
        //                        BatchNumber = g.Select(i => i.BatchNumber).FirstOrDefault(),
        //                        Brand = g.Select(i => i.Brand).FirstOrDefault(),
        //                        ItemName = g.Select(i => i.ItemName).FirstOrDefault(),
        //                        ItemCode = g.Key.ItemCode,
        //                        Quantity = g.Sum(i => i.Quantity),
        //                        OrgID = g.Select(i => i.OrgID).FirstOrDefault(),
        //                    }).OrderBy(i => i.ItemName).ToList();
        //                }
        //                else if (Criteria.CategoryID > 0)
        //                {
        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.CategoryID == Criteria.CategoryID).ToList();

        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.GroupBy(ac => new
        //                    {
        //                        ac.SubCategoryID
        //                    }).Select(g => new DLItemWarehouseMapCreation
        //                    {
        //                        CategoryID = g.Select(i => i.CategoryID).FirstOrDefault(),
        //                        CategoryName = g.Select(i => i.CategoryName).FirstOrDefault(),
        //                        SubCategoryID = g.Key.SubCategoryID,
        //                        SubCategoryname = g.Select(i => i.SubCategoryname).FirstOrDefault(),
        //                        WarehouseID = g.Select(i => i.WarehouseID).FirstOrDefault(),
        //                        WarehouseName = g.Select(i => i.WarehouseName).FirstOrDefault(),
        //                        Quantity = g.Sum(i => i.Quantity),
        //                        OrgID = g.Select(i => i.OrgID).FirstOrDefault(),
        //                    }).OrderBy(i => i.SubCategoryname).ToList();
        //                }
        //                else
        //                {
        //                    if (Criteria.IsFlagItem == "IsFlagItem")
        //                    {
        //                        lstItemWareHouseCreation = lstItemWareHouseCreation.GroupBy(ac => new
        //                        {
        //                            ac.ItemCode
        //                        }).Select(g => new DLItemWarehouseMapCreation
        //                        {
        //                            CategoryID = g.Select(i => i.CategoryID).FirstOrDefault(),
        //                            CategoryName = g.Select(i => i.CategoryName).FirstOrDefault(),
        //                            SubCategoryID = g.Select(i => i.SubCategoryID).FirstOrDefault(),
        //                            SubCategoryname = g.Select(i => i.SubCategoryname).FirstOrDefault(),
        //                            WarehouseID = g.Select(i => i.WarehouseID).FirstOrDefault(),
        //                            WarehouseName = g.Select(i => i.WarehouseName).FirstOrDefault(),
        //                            BatchNumber = g.Select(i => i.BatchNumber).FirstOrDefault(),
        //                            Brand = g.Select(i => i.Brand).FirstOrDefault(),
        //                            ItemName = g.Select(i => i.ItemName).FirstOrDefault(),
        //                            ItemCode = g.Key.ItemCode,
        //                            Quantity = g.Sum(i => i.Quantity),
        //                            OrgID = g.Select(i => i.OrgID).FirstOrDefault(),
        //                        }).OrderBy(i => i.ItemName).ToList();
        //                    }
        //                    else
        //                    {
        //                        lstItemWareHouseCreation = lstItemWareHouseCreation.GroupBy(ac => new
        //                        {
        //                            ac.CategoryID
        //                        }).Select(g => new DLItemWarehouseMapCreation
        //                        {
        //                            CategoryID = g.Key.CategoryID,
        //                            ItemCode = g.Select(i => i.ItemCode).FirstOrDefault(),
        //                            ItemName = g.Select(i => i.ItemName).FirstOrDefault(),
        //                            CategoryName = g.Select(i => i.CategoryName).FirstOrDefault(),
        //                            SubCategoryID = g.Select(i => i.SubCategoryID).FirstOrDefault(),
        //                            SubCategoryname = g.Select(i => i.SubCategoryname).FirstOrDefault(),
        //                            WarehouseID = g.Select(i => i.WarehouseID).FirstOrDefault(),
        //                            WarehouseName = g.Select(i => i.WarehouseName).FirstOrDefault(),
        //                            BatchNumber = g.Select(i => i.BatchNumber).FirstOrDefault(),
        //                            Brand = g.Select(i => i.Brand).FirstOrDefault(),
        //                            Quantity = g.Sum(i => i.Quantity),
        //                            OrgID = g.Select(i => i.OrgID).FirstOrDefault(),
        //                        }).OrderBy(i => i.CategoryName).ToList();
        //                    }
        //                }

        //                if (!string.IsNullOrEmpty(Criteria.CatOrSubCatName))
        //                    lstItemWareHouseCreation = lstItemWareHouseCreation.Where(c => c.CategoryName.ToLower().Trim().Contains(Criteria.CatOrSubCatName.ToLower().Trim())
        //                    || c.SubCategoryname.ToLower().Trim().Contains(Criteria.CatOrSubCatName.ToLower().Trim())).ToList();

        //            }
        //            #endregion

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
        //    return lstItemWareHouseCreation;
        //}

        public object OBStockUploadToTally(object Context)
        {
            List<DLStockimportDetails> lstDLStockimportDetails = new List<DLStockimportDetails>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    DLStockimportDetails Criteria = (DLStockimportDetails)Context;

                    lstDLStockimportDetails = (from drow in Entities.tblItemWarehouseMaps.AsNoTracking()
                                               where drow.IsActive == true && drow.Quantity != 0
                                               && drow.OrgID == Criteria.OrgID && drow.BranchID==Criteria.BranchID
                                               && drow.IsOBStockUpdatedToTally == false
                                               select new DLStockimportDetails()
                                               {
                                                   ItemWarehouseMapID = drow.ItemWarehouseMapID,
                                                   ItemCode = drow.ItemCode,
                                                   ItemName = drow.tblItem.ItemName,
                                                   OrgID = drow.OrgID,
                                                   Quantity = drow.Quantity,
                                                   Rate = (from items in Entities.tblItems
                                                           where items.ItemCode == drow.ItemCode
                                                           select items).FirstOrDefault().tblItemRate.BaseRateOther.Value,
                                                   ItemAlias = drow.tblItem.Alias.Trim(),
                                                   BaseUnitName = drow.tblItem.BaseUnit != null ? (from e in Entities.tblUOMs
                                                                                                   where e.UnitID == drow.tblItem.BaseUnit
                                                                                                   select e).FirstOrDefault().Unit : "",
                                                   BasePKTValue = drow.tblItem.BasePKTValue,
                                                   AlternateUnit = drow.tblItem.AlternateUnit,
                                                   AlternateUnitName = drow.tblItem.AlternateUnit != null ? Entities.tblUOMs.Where(i => i.UnitID == drow.tblItem.AlternateUnit).FirstOrDefault().Unit : "",
                                                   AlternatePKTValue = drow.tblItem.AlternatePKTValue,
                                                   
                                               }).ToList();


                    lstDLStockimportDetails = lstDLStockimportDetails.GroupBy(ac => new
                    {
                        ac.ItemCode
                    }).Select(g => new DLStockimportDetails
                    {
                        ItemWarehouseMapID = g.Select(i => i.ItemWarehouseMapID).FirstOrDefault(),
                        ItemName = g.Select(i => i.ItemName).FirstOrDefault(),
                        ItemCode = g.Key.ItemCode,
                        Quantity = g.Sum(i => i.Quantity),
                        OrgID = g.Select(i => i.OrgID).FirstOrDefault(),
                        Rate = g.Select(i => i.Rate).FirstOrDefault(),
                        ItemAlias = g.Select(i => i.ItemAlias).FirstOrDefault(),
                        BaseUnitName = g.Select(i => i.BaseUnitName).FirstOrDefault(),
                        BasePKTValue = g.Select(i => i.BasePKTValue).FirstOrDefault(),
                        AlternateUnit = g.Select(i => i.AlternateUnit).FirstOrDefault(),
                        AlternateUnitName = g.Select(i => i.AlternateUnitName).FirstOrDefault(),
                        AlternatePKTValue = g.Select(i => i.AlternatePKTValue).FirstOrDefault(),
                    }).OrderBy(i => i.ItemName).ToList();

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
            return lstDLStockimportDetails;
        }

        private object ObStockUpdateStatus(object Context)
        {
            DLItemWarehouseMapCreation mItemWarehouseMapCreation = (DLItemWarehouseMapCreation)Context;
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    tblItemWarehouseMap lItem = (from gItems in Entities.tblItemWarehouseMaps.AsNoTracking()
                                         where gItems.ItemCode == mItemWarehouseMapCreation.ItemCode
                                         && gItems.OrgID == mItemWarehouseMapCreation.OrgID
                                         && gItems.BranchID == mItemWarehouseMapCreation.BranchID
                                         select gItems).FirstOrDefault();

                    if (lItem != null)
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                              
                                lItem.IsOBStockUpdatedToTally = true;
                                //lItem.TallyUpdatedDate = Helper.GetCurrentDate;
                                //lItem.TallyUpdatedByID = mItemCreation.ModifiedByID;
                                Entities.tblItemWarehouseMaps.Add(lItem);
                                Entities.Entry(lItem).State = EntityState.Modified;
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
    }
}

