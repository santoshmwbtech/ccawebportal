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
    
    public partial class tblSalesOrderWithItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSalesOrderWithItem()
        {
            this.tblDeliveryNoteItems = new HashSet<tblDeliveryNoteItem>();
            this.tblGatePassItems = new HashSet<tblGatePassItem>();
            this.tblItemMovements = new HashSet<tblItemMovement>();
            this.tblSalesOrderItemWarehouseMaps = new HashSet<tblSalesOrderItemWarehouseMap>();
        }
    
        public System.Guid SalesOrderWithItemID { get; set; }
        public string SalesOrderNumber { get; set; }
        public string ItemCode { get; set; }
        public string BagQTY { get; set; }
        public decimal TotalQTY { get; set; }
        public decimal Rate { get; set; }
        public decimal Value { get; set; }
        public Nullable<bool> IsRateInQuantls { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public Nullable<bool> IsDiscountRangeExceeded { get; set; }
        public string DiscountRangeApprovalStatus { get; set; }
        public string DiscountExceededReason { get; set; }
        public bool IsTallyUpdated { get; set; }
        public Nullable<int> ItemRowNumber { get; set; }
        public Nullable<decimal> FrieghtCharge { get; set; }
        public Nullable<decimal> LoadingUnloadingCharge { get; set; }
        public Nullable<decimal> OtherExpense { get; set; }
        public string SourceOfUpdate { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public Nullable<bool> TallySync { get; set; }
        public Nullable<decimal> DiscountAmt { get; set; }
        public Nullable<decimal> GSTPer { get; set; }
        public Nullable<decimal> GSTValue { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDeliveryNoteItem> tblDeliveryNoteItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGatePassItem> tblGatePassItems { get; set; }
        public virtual tblItem tblItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemMovement> tblItemMovements { get; set; }
        public virtual tblSalesOrder tblSalesOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSalesOrderItemWarehouseMap> tblSalesOrderItemWarehouseMaps { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
    }
}
