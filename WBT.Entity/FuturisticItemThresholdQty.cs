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
    
    public partial class FuturisticItemThresholdQty
    {
        public int FID { get; set; }
        public string OrgId { get; set; }
        public string BranchID { get; set; }
        public string ItemCode { get; set; }
        public int BusinessTypeID { get; set; }
        public int MinQty { get; set; }
        public int MaxQty { get; set; }
        public Nullable<int> MinQtyAfterPeriod { get; set; }
        public int MaxQtyAfterPeriod { get; set; }
        public System.DateTime FrmEffectiveDate { get; set; }
        public string FrmEffectiveTime { get; set; }
        public System.DateTime ToEffectiveDate { get; set; }
        public string ToEffectiveTime { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
    
        public virtual BusinessType BusinessType { get; set; }
        public virtual tblItem tblItem { get; set; }
    }
}
