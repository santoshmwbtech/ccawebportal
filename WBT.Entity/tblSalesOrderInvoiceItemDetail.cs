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
    
    public partial class tblSalesOrderInvoiceItemDetail
    {
        public int ID { get; set; }
        public string SOInvoiceReferenceNumber { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public int Quantity { get; set; }
        public Nullable<decimal> BilledQty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> RateWithOutTax { get; set; }
        public string RatePerUnit { get; set; }
        public decimal Amount { get; set; }
        public Nullable<decimal> GST { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<int> UnitID { get; set; }
        public bool IsTallyUpdated { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string SourceOfUpdate { get; set; }
        public string Remark { get; set; }
        public string SIType { get; set; }
        public string SITypeNum { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<System.Guid> SalesOrderWithItemID { get; set; }
    
        public virtual tblItem tblItem { get; set; }
        public virtual tblSalesOrderInvoice tblSalesOrderInvoice { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
        public virtual tblWarehouse tblWarehouse { get; set; }
        public virtual tblBatch tblBatch { get; set; }
    }
}
