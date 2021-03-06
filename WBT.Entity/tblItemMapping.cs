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
    
    public partial class tblItemMapping
    {
        public int ID { get; set; }
        public int ItemMappingID { get; set; }
        public string ItemCode { get; set; }
        public string OrgID { get; set; }
        public string COrgID { get; set; }
        public string BranchID { get; set; }
        public Nullable<int> RateID { get; set; }
        public Nullable<decimal> GST { get; set; }
        public Nullable<System.DateTime> GSTEffectiveDate { get; set; }
        public Nullable<decimal> CESSValue { get; set; }
        public Nullable<System.DateTime> CESSEffectiveDate { get; set; }
        public Nullable<int> ReOrderlevel { get; set; }
        public Nullable<int> ReOrderQTY { get; set; }
        public Nullable<bool> IsReturnable { get; set; }
        public Nullable<int> DaysToRefill { get; set; }
        public Nullable<bool> IsItemBlocked { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsTallyUpdated { get; set; }
        public Nullable<System.DateTime> TallyUpdatedDate { get; set; }
        public Nullable<int> TallyUpdatedByID { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedDatetime { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
    
        public virtual tblItem tblItem { get; set; }
        public virtual tblItemRate tblItemRate { get; set; }
        public virtual tblSysBranch tblSysBranch { get; set; }
        public virtual tblSysOrganization tblSysOrganization { get; set; }
    }
}
