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
    
    public partial class tblDebtorsDetail
    {
        public int ID { get; set; }
        public string OrgID { get; set; }
        public string DebtorName { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentDebtorID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public Nullable<int> IsDefault { get; set; }
        public string OldDebtorName { get; set; }
        public Nullable<bool> IsTallyUpdated { get; set; }
        public string BranchID { get; set; }
        public Nullable<bool> TallySync { get; set; }
    }
}
