//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WBT.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblStockTransferLineItem
    {
        public System.Guid StockTransferLineItemID { get; set; }
        public int StockTransferHeaderID { get; set; }
        public string ItemCode { get; set; }
        public decimal SourceQTY { get; set; }
        public int SourceWarehouseID { get; set; }
        public Nullable<int> SourceBatchID { get; set; }
        public int DestinationWarehouseID { get; set; }
        public string DestinationQTY { get; set; }
        public int DestinationBatchID { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string SourceOfUpdate { get; set; }
    
        public virtual tblBatch tblBatch { get; set; }
        public virtual tblItem tblItem { get; set; }
        public virtual tblStockTransferHeader tblStockTransferHeader { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblWarehouse tblWarehouse { get; set; }
        public virtual tblWarehouse tblWarehouse1 { get; set; }
    }
}
