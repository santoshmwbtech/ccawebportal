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
    
    public partial class FumigationItemWrhsDetail
    {
        public int ID { get; set; }
        public Nullable<int> FuminID { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> BatchID { get; set; }
        public Nullable<int> FuminQty { get; set; }
        public Nullable<decimal> FuminRate { get; set; }
        public Nullable<System.DateTime> FuminStartDate { get; set; }
        public Nullable<System.DateTime> FuminEndDate { get; set; }
        public string FuminStatus { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string FID { get; set; }
    
        public virtual FumigationDetail FumigationDetail { get; set; }
        public virtual tblWarehouse tblWarehouse { get; set; }
        public virtual tblItem tblItem { get; set; }
    }
}
