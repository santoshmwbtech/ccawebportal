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
    
    public partial class DiscrepencyDetail
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public decimal Quantity { get; set; }
        public int ReasonForDiscrepency { get; set; }
        public Nullable<int> BatchID { get; set; }
        public string OrgID { get; set; }
        public string BranchID { get; set; }
        public string SourceOfUpdate { get; set; }
        public string PurchaseOrSales { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int CreationID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public Nullable<System.DateTime> Modifieddate { get; set; }
        public bool IsTallyUpdated { get; set; }
    
        public virtual tblBatch tblBatch { get; set; }
        public virtual tblItem tblItem { get; set; }
        public virtual tblReason tblReason { get; set; }
        public virtual tblSysBranch tblSysBranch { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
        public virtual tblWarehouse tblWarehouse { get; set; }
        public virtual tblSysOrganization tblSysOrganization { get; set; }
    }
}
