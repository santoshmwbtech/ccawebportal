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
    
    public partial class tblHSNCode
    {
        public int HSNID { get; set; }
        public int HSNCode { get; set; }
        public Nullable<int> HSNSubCode { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsTrademarkRegistered { get; set; }
        public int GST { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string SourceOfUpdate { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
    
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
    }
}
