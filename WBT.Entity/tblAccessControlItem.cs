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
    
    public partial class tblAccessControlItem
    {
        public int AccessControlItemID { get; set; }
        public Nullable<int> AccessControlID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> SubMenuID { get; set; }
        public Nullable<int> MainMenuID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedID { get; set; }
        public Nullable<bool> IsCreate { get; set; }
        public Nullable<bool> IsView { get; set; }
        public Nullable<bool> IsEdit { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual tblAccessControl tblAccessControl { get; set; }
    }
}
