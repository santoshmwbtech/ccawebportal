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
    
    public partial class tblSubAccountGroupMaster
    {
        public int SubAccountGroupMasterID { get; set; }
        public string SubAccountName { get; set; }
        public int AccountGroupMasterID { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual tblAccountGroupMaster tblAccountGroupMaster { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
    }
}
