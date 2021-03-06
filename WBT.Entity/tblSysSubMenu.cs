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
    
    public partial class tblSysSubMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSysSubMenu()
        {
            this.tblAccessRights = new HashSet<tblAccessRight>();
            this.tblSubMenuRoleMaps = new HashSet<tblSubMenuRoleMap>();
        }
    
        public int SubMenuID { get; set; }
        public int MainMenuID { get; set; }
        public string SubMenuName { get; set; }
        public string ScreenName { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string OrgID { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string SourceOfUpdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccessRight> tblAccessRights { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSubMenuRoleMap> tblSubMenuRoleMaps { get; set; }
        public virtual tblSysMainMenu tblSysMainMenu { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
    }
}
