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
    
    public partial class tblTransitItemDetail
    {
        public int ID { get; set; }
        public int TransitItemID { get; set; }
        public string ItemCode { get; set; }
        public int QuantityOrdered { get; set; }
        public Nullable<int> QuantityInvoiced { get; set; }
        public string Remarks { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string SourceOfUpdate { get; set; }
    
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
        public virtual tblTransitItem tblTransitItem { get; set; }
    }
}
