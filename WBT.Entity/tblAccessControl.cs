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
    
    public partial class tblAccessControl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccessControl()
        {
            this.tblAccessControlItems = new HashSet<tblAccessControlItem>();
        }
    
        public int AccessControlID { get; set; }
        public int OrgID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccessControlItem> tblAccessControlItems { get; set; }
    }
}
