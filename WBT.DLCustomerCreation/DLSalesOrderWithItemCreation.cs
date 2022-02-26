using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Entity;


namespace WBT.DL.Transaction
{
    public class DLSalesOrderWithItemCreation
    {
        public Guid SalesOrderWithItemID { get; set; }
        public string SalesOrderNumber { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> PacketSizeID { get; set; }
        public string BagQTY { get; set; }
        public bool IsItemBlocked { get; set; }
        public decimal TotalQTY { get; set; }
        public decimal Rate { get; set; }
        public decimal Value { get; set; }
        public Nullable<int> ItemRowNumber { get; set; }
        public int WarehouseID { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public Nullable<decimal> FrieghtCharge { get; set; }
        public Nullable<decimal> LoadingUnloadingCharge { get; set; }
        public Nullable<decimal> OtherExpense { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public decimal? DiscountAmt { get; set; }
        public Nullable<decimal> MaxQuantity { get; set; }
        public bool IsCorrectionRequired { get; set; }
        
        public string SalesOrderStatus { get; set; }
        public string Unit { get; set; }
        public string ItemName { get; set; }
        public System.DateTime CreationDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public bool SoAdimApprove { get; set; }
        public Nullable<bool> IsRateInQuantls { get; set; }
        public Nullable<bool> IsDiscountRangeExceeded { get; set; }
        public List<DLSalesOrderItemWarehouseMapCreation> SalesOrderItemWarehouseMaps { get; set; }
        public decimal SupplyQty { get; set; }
        public decimal DemandedQty { get; set; }
        public Nullable<decimal> GSTPer { get; set; }
        public Nullable<decimal> GSTValue { get; set; }
        public string CGSTLedger { get; set; }
        public string SGSTLedger { get; set; }
        public string IGSTLedger { get; set; }

    }

    public class DLSalesOrderWithItem : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();

        private tblSalesOrderWithItem lSalesOrderWithItem = new tblSalesOrderWithItem();

        private List<DLSalesOrderWithItemCreation> lstSalesOrderWithItem = new List<DLSalesOrderWithItemCreation>();
        private DLSalesOrderWithItemCreation mSalesOrderWithItem = new DLSalesOrderWithItemCreation();
        public List<DLSalesOrderWithItemCreation> SalesOrderCreation
        {
            get { return lstSalesOrderWithItem; }
            set { lstSalesOrderWithItem = value; }
        }

        public override object DataActivate(object Context)
        {
            try
            {
                object lResult = null;
                switch (this.GetApplicationActivate.DataState)
                {
                    case Common.TransactionType.Find:
                        lResult = FindData(Context.ToString());
                        break;
                    case Common.TransactionType.Delete:
                        lResult = DeleteData(Context);
                        break;
                }
                return lResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object FindData(string SearchValue)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    var drow = Entities.tblSalesOrderWithItems.AsNoTracking().Where(e => e.SalesOrderWithItemID.ToString() == SearchValue).FirstOrDefault();

                    if (drow != null)
                    {
                        mSalesOrderWithItem = new DLSalesOrderWithItemCreation();

                        mSalesOrderWithItem.SalesOrderWithItemID = drow.SalesOrderWithItemID;
                        mSalesOrderWithItem.ItemCode = drow.ItemCode;
                        mSalesOrderWithItem.BagQTY = drow.BagQTY;
                        // mSalesOrderWithItem.PacketSizeID = drow.PacketSizeID;
                        mSalesOrderWithItem.TotalQTY = drow.TotalQTY;
                        mSalesOrderWithItem.Value = drow.Value;
                        mSalesOrderWithItem.Rate = drow.Rate;
                        mSalesOrderWithItem.CreatedByID = drow.CreatedByID;
                        mSalesOrderWithItem.CreationDate = drow.CreationDate;
                        mSalesOrderWithItem.UpdateDate = drow.UpdateDate;
                        mSalesOrderWithItem.ItemName = drow.tblItem.ItemName;
                        mSalesOrderWithItem.DiscountPercentage = drow.DiscountPercentage;
                        mSalesOrderWithItem.ItemName = Entities.tblItems.AsNoTracking().Where(e => e.ItemCode == drow.ItemCode).FirstOrDefault().ItemName;
                        //mSalesOrderWithItem.Unit = Entities.PacketSizeDetails.AsNoTracking().Where(e => e.PacketSizeID == drow.PacketSizeID).FirstOrDefault().PacketSize;

                        mSalesOrderWithItem.SalesOrderStatus = drow.tblSalesOrder.Status;

                        mSalesOrderWithItem.SalesOrderItemWarehouseMaps = new List<DLSalesOrderItemWarehouseMapCreation>();

                        foreach (var w in mSalesOrderWithItem.SalesOrderItemWarehouseMaps)
                        {
                            DLSalesOrderItemWarehouseMapCreation sw = new DLSalesOrderItemWarehouseMapCreation()
                            {
                                ID = w.ID,
                                ItemCode = w.ItemCode,
                                IsCorrectionRequired = w.IsCorrectionRequired,
                                BatchID = w.BatchID,
                                WarehouseID = w.WarehouseID,
                                TotalLinItemQuantity = w.TotalLinItemQuantity,
                                QuantityOrdered = w.QuantityOrdered,
                                IsNegativeStock = w.IsNegativeStock,
                                SalesOrderNumber = w.SalesOrderNumber,
                                CreationDate = w.CreationDate,
                                UpdateDate = w.UpdateDate,
                                CreatedByID = w.CreatedByID,
                                SalesOrderWithItemID = w.SalesOrderWithItemID

                            };
                            mSalesOrderWithItem.SalesOrderItemWarehouseMaps.Add(sw);
                        }
                        return mSalesOrderWithItem;
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

        private object DeleteData(object Context)
        {

            mSalesOrderWithItem = ((DLSalesOrderWithItemCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    lSalesOrderWithItem = (from sol in Entities.tblSalesOrderWithItems.AsNoTracking().ToList()
                                           where sol.SalesOrderWithItemID == mSalesOrderWithItem.SalesOrderWithItemID
                                           select sol).First();

                    if (lSalesOrderWithItem != null)
                    {

                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {

                                #region IncrementStock
                                foreach (var w in lSalesOrderWithItem.tblSalesOrderItemWarehouseMaps)
                                {
                                    var SOItemWarehouseMapFromDB = Entities.tblSalesOrderItemWarehouseMaps.AsNoTracking()
                                                         .Where(e => e.WarehouseID == w.WarehouseID
                                                        && e.BatchID == w.BatchID && e.ItemCode == w.ItemCode
                                                        && e.ID == w.ID).FirstOrDefault();

                                    if (SOItemWarehouseMapFromDB != null)
                                    {
                                        //Update Stock if the user has changed the QTY
                                        var stock = Entities.tblItemWarehouseMaps.AsNoTracking()
                                                   .Where(e => e.WarehouseID == w.WarehouseID
                                                    && e.BatchID == w.BatchID && e.ItemCode == w.ItemCode).FirstOrDefault();

                                        if (stock != null)
                                        {
                                            stock.ModifiedDate = DateTime.Now;
                                            stock.ModifiedByID = mSalesOrderWithItem.ModifiedByID;
                                            //increase Stock by reducing the sale QTY

                                            stock.SaleQuantity = stock.SaleQuantity.Value - SOItemWarehouseMapFromDB.QuantityOrdered;
                                            Entities.tblItemWarehouseMaps.Attach(stock);
                                            Entities.Entry(stock).State = EntityState.Modified;
                                        }
                                        Entities.tblSalesOrderItemWarehouseMaps.Attach(SOItemWarehouseMapFromDB);
                                        Entities.Entry(SOItemWarehouseMapFromDB).State = EntityState.Deleted;

                                    }
                                }
                                #endregion

                                lSalesOrderWithItem.tblSalesOrderItemWarehouseMaps.Clear();
                                Entities.Entry(lSalesOrderWithItem).State = EntityState.Deleted;
                                
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
                    else
                    {
                        DeleteLineItemWarehouseMap(mSalesOrderWithItem.SalesOrderItemWarehouseMaps);
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
        public object DeleteLineItemWarehouseMap(object Context)
        {
            List<Master.DLItemWarehouseMap.SalesOrderItemWarehouseMapResult> SalesOrderItemWarehouseMaps = (List<Master.DLItemWarehouseMap.SalesOrderItemWarehouseMapResult>)Context;
           //mSalesOrderWithItem = ((DLSalesOrderWithItemCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            #region IncrementStock
                            foreach (var w in SalesOrderItemWarehouseMaps)
                            {

                                //Update Stock if the user has changed the QTY
                                var stock = Entities.tblItemWarehouseMaps.AsNoTracking()
                                           .Where(e => e.WarehouseID == w.WarehouseID
                                            && e.BatchID == w.BatchID && e.ItemCode == w.ItemCode
                                            && e.OrgID== w.OrgID).FirstOrDefault();

                                if (stock != null)
                                {
                                    stock.ModifiedDate = DateTime.Now;
                                    stock.ModifiedByID = lSalesOrderWithItem.ModifiedByID;
                                    //increase Stock by reducing the sale QTY
                                    stock.SaleQuantity = stock.SaleQuantity.Value - w.Quantity;
                                    Entities.tblItemWarehouseMaps.Attach(stock);
                                    Entities.Entry(stock).State = EntityState.Modified;
                                }
                            }
                            #endregion

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
