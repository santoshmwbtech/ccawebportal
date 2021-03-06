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
    
    public partial class tblDeliveryNoteItem
    {
        public int ID { get; set; }
        public string DeliveryNoteCode { get; set; }
        public Nullable<System.Guid> SalesOrderWithItemID { get; set; }
        public string ItemCode { get; set; }
        public Nullable<decimal> Ordered { get; set; }
        public Nullable<decimal> Delivered { get; set; }
        public string OrgID { get; set; }
        public int WarehouseID { get; set; }
        public int BatchID { get; set; }
        public Nullable<int> IsCorrectionRequired { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> ReasonID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string Remark { get; set; }
        public string DNType { get; set; }
        public string DNTypeNum { get; set; }
        public string SalesOrderNumber { get; set; }
    
        public virtual tblBatch tblBatch { get; set; }
        public virtual tblDeliveryNote tblDeliveryNote { get; set; }
        public virtual tblItem tblItem { get; set; }
        public virtual tblReason tblReason { get; set; }
        public virtual tblSalesOrderWithItem tblSalesOrderWithItem { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
        public virtual tblWarehouse tblWarehouse { get; set; }
        public virtual tblSysOrganization tblSysOrganization { get; set; }
    }
}
