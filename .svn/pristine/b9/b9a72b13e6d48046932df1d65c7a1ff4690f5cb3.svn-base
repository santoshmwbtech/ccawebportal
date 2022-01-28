using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Entity;

namespace WBT.DL.Transaction
{
    public class DLSalesOrderItemWarehouseMapCreation
    {
        public int ID { get; set; }
        public string SalesOrderNumber { get; set; }
        public string ItemCode { get; set; }
        //Added for Negative Stock Tree
        public string ItemName { get; set; }
        public int WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public decimal TotalLinItemQuantity { get; set; }
        public decimal TotalNegativeStock { get; set; }
        public decimal QuantityOrdered { get; set; }
        public Nullable<bool> IsNegativeStock { get; set; }
        public Nullable<bool> IsFIFOSkipped { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Guid SalesOrderWithItemID { get; set; }
        public int? BatchID { get; set; }
        public int IsCorrectionRequired { get; set; }
        public string OrgID { get; set; }
        public string OrgName { get; set; }
        public Nullable<bool> IsPrimaryWarehouse { get; set; }
        public bool IsBulksale { get; set; }
        public string IsBulk { get; set; }
        public decimal TotalItemNegativeStock { get; set; }
        public decimal ChangeQty { get; set; }
        public bool Approve { get; set; }
        public bool ApproveitemDis { get; set; }
        public string View { get; set; }
        public Nullable<bool> IsOrderDiscountRangeExceeded { get; set; }
        public Nullable<bool> IsItemDiscountExceeded { get; set; }
        public decimal ItemDiscounts { get; set; }
        public decimal ChangeItemDiscounts { get; set; }
        public decimal Value { get; set; }
        public decimal Rate { get; set; }
        public string BagQty { get; set; }
        public decimal OrderDiscountValue { get; set; }
        public decimal OrderDiscountAmt { get; set; }
        public bool IsRateInQuantls { get; set; }
        public decimal AllotedQTY { get; set; }
        //public List<DLSalesOrderWithItemCreation> dLSalesOrderWithItem { get; set; }
    }
    public class DLSalesOrderItemWarehouseMap : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private tblSalesOrderItemWarehouseMap lDLDLSalesOrderItemWarehouseMapCreation = new tblSalesOrderItemWarehouseMap();

        private List<DLSalesOrderItemWarehouseMapCreation> lstSalesOrderItemWarehouseMapCreation = new List<DLSalesOrderItemWarehouseMapCreation>();
        private DLSalesOrderItemWarehouseMapCreation mSalesOrderItemWarehouseMap = new DLSalesOrderItemWarehouseMapCreation();
        public List<DLSalesOrderItemWarehouseMapCreation> SalesOrderItemWarehouseMapCreation
        {
            get { return lstSalesOrderItemWarehouseMapCreation; }
            set { lstSalesOrderItemWarehouseMapCreation = value; }
        }
        public override object DataActivate(object Context)
        {
            try
            {
                object lResult = null;
                switch (this.GetApplicationActivate.DataState)
                {
                    case Common.TransactionType.Load:
                       // lResult = GetData(Context.ToString());
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

        public object GetDataForAdminApproval(string SearchValue,string OrgID)
        {
            List<tblSalesOrderItemWarehouseMap> Result = new List<tblSalesOrderItemWarehouseMap>();
            lstSalesOrderItemWarehouseMapCreation = new List<DLSalesOrderItemWarehouseMapCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed


                    Result = Entities.tblSalesOrderItemWarehouseMaps.AsNoTracking().ToList();//.Where(c => c.SalesOrderNumber.ToLower().Trim() == SearchValue.ToLower().Trim()).ToList();
                    foreach (var drow in Result)
                    {
                        mSalesOrderItemWarehouseMap = new DLSalesOrderItemWarehouseMapCreation();
                        mSalesOrderItemWarehouseMap.SalesOrderWithItemID = drow.SalesOrderWithItemID;
                        mSalesOrderItemWarehouseMap.SalesOrderNumber = drow.SalesOrderNumber;
                        mSalesOrderItemWarehouseMap.ItemCode = drow.ItemCode;
                        mSalesOrderItemWarehouseMap.ItemName = drow.tblItem.ItemName;
                        mSalesOrderItemWarehouseMap.BatchID = drow.BatchID;
                        mSalesOrderItemWarehouseMap.OrgID = drow.OrgID;
                        mSalesOrderItemWarehouseMap.OrgName = drow.OrgID; //drow.tblSysOrganization.Name;
                        mSalesOrderItemWarehouseMap.WarehouseID = drow.WarehouseID;
                        mSalesOrderItemWarehouseMap.WarehouseName = drow.WarehouseID.ToString();//drow.tblSysOrganization.Name + "-" + drow.tblWarehouse.WarehouseName + "-" + drow.tblWarehouse.City;
                        mSalesOrderItemWarehouseMap.QuantityOrdered = drow.QuantityOrdered;
                        mSalesOrderItemWarehouseMap.IsFIFOSkipped = drow.IsFIFOSkipped;
                        mSalesOrderItemWarehouseMap.IsNegativeStock = drow.IsNegativeStock;
                        mSalesOrderItemWarehouseMap.TotalLinItemQuantity = drow.tblSalesOrderWithItem.TotalQTY;
                        mSalesOrderItemWarehouseMap.Rate = drow.tblSalesOrderWithItem.Rate;
                        mSalesOrderItemWarehouseMap.IsBulksale = drow.tblSalesOrder.IsBulkSale ?? false;
                        mSalesOrderItemWarehouseMap.IsBulk = mSalesOrderItemWarehouseMap.IsBulksale == true ? "Yes" : "No";
                        mSalesOrderItemWarehouseMap.ChangeQty =drow.QuantityOrdered;
                        mSalesOrderItemWarehouseMap.IsOrderDiscountRangeExceeded = drow.tblSalesOrder.IsDiscountRangeExceeded ?? false;
                        mSalesOrderItemWarehouseMap.IsItemDiscountExceeded = drow.tblSalesOrderWithItem.IsDiscountRangeExceeded ?? false;
                        mSalesOrderItemWarehouseMap.ItemDiscounts = drow.tblSalesOrderWithItem.DiscountPercentage ?? 0;
                        mSalesOrderItemWarehouseMap.ChangeItemDiscounts= drow.tblSalesOrderWithItem.DiscountPercentage ?? 0;
                        mSalesOrderItemWarehouseMap.Value = drow.tblSalesOrderWithItem.Value;
                        mSalesOrderItemWarehouseMap.BagQty = drow.tblSalesOrderWithItem.BagQTY;
                        mSalesOrderItemWarehouseMap.OrderDiscountValue = drow.tblSalesOrder.DiscountPercentage ?? 0;
                        mSalesOrderItemWarehouseMap.OrderDiscountAmt = drow.tblSalesOrder.DiscountAmt ?? 0;
                        mSalesOrderItemWarehouseMap.IsRateInQuantls = drow.tblSalesOrderWithItem.IsRateInQuantls ?? false;
                        mSalesOrderItemWarehouseMap.Approve = false;
                        mSalesOrderItemWarehouseMap.ApproveitemDis = false;
                        mSalesOrderItemWarehouseMap.View = "View";
                        if (drow.IsNegativeStock == true)
                        {
                            decimal warehouseVirtualTTl = 0; //decimal stockTotal = 0;
                            if ((Entities.tblSalesOrderItemWarehouseMaps.Where(s => s.ItemCode == drow.ItemCode && s.IsNegativeStock == true).Select(a => a.QuantityOrdered).Count())>0)
                               warehouseVirtualTTl = (Entities.tblSalesOrderItemWarehouseMaps.Where(s => s.ItemCode == drow.ItemCode && s.IsNegativeStock == true).Select(a => a.QuantityOrdered).Sum());

                            //if(Entities.ItemWarehouseMaps.Where(i => i.ItemCode == drow.ItemCode).Select(d => d.Quantity - (d.SaleQuantity ?? 0 + d.InfectedQty ?? 0)).Count()>0)
                            // stockTotal = Entities.ItemWarehouseMaps.Where(i => i.ItemCode == drow.ItemCode).Select(d => d.Quantity- (d.SaleQuantity ?? 0 + d.InfectedQty ?? 0)).Sum();

                            mSalesOrderItemWarehouseMap.TotalItemNegativeStock = warehouseVirtualTTl;// + stockTotal;
                        }                     
                       lstSalesOrderItemWarehouseMapCreation.Add(mSalesOrderItemWarehouseMap);
                    }

                    if (!string.IsNullOrEmpty(SearchValue))
                        lstSalesOrderItemWarehouseMapCreation = lstSalesOrderItemWarehouseMapCreation.Where(c => c.SalesOrderNumber.ToLower().Trim() == SearchValue.ToLower().Trim() && c.OrgID==OrgID).Distinct().ToList();
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
            return lstSalesOrderItemWarehouseMapCreation;
        }

    }
}
