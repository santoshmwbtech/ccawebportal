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
    
    public partial class DCQtyAllocationItemWarehouseMap
    {
        public int DCItemMapID { get; set; }
        public Nullable<int> ID { get; set; }
        public string DCNo { get; set; }
        public string RequisitionNumber { get; set; }
        public string ItemCode { get; set; }
        public string OrgID { get; set; }
        public int WarehouseID { get; set; }
        public Nullable<int> BatchID { get; set; }
        public Nullable<decimal> TotalQuantity { get; set; }
        public Nullable<decimal> QuantityOrdered { get; set; }
        public Nullable<bool> IsNegativeStock { get; set; }
        public Nullable<bool> IsFIFOSkipped { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string SourceOfUpdate { get; set; }
    
        public virtual DCQuantityAllocation DCQuantityAllocation { get; set; }
        public virtual tblBatch tblBatch { get; set; }
        public virtual tblItem tblItem { get; set; }
        public virtual tblPurchaseRequisition tblPurchaseRequisition { get; set; }
        public virtual tblWarehouse tblWarehouse { get; set; }
    }
}
