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
    
    public partial class tblAccountLedger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccountLedger()
        {
            this.tblAccountReceiptDetails = new HashSet<tblAccountReceiptDetail>();
        }
    
        public int ID { get; set; }
        public string LedgerID { get; set; }
        public string OrgID { get; set; }
        public string BranchID { get; set; }
        public string LedgerName { get; set; }
        public Nullable<int> AccountGroupID { get; set; }
        public string SalesOrPurchase { get; set; }
        public Nullable<bool> IsEditable { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsTallyUpdated { get; set; }
        public Nullable<System.DateTime> TallyUpdatedDate { get; set; }
        public Nullable<int> TallyUpdatedByID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string GSTN { get; set; }
        public string PANNumber { get; set; }
        public string Country { get; set; }
        public Nullable<int> StateID { get; set; }
        public string Pincode { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ActivateIntrestCalculation { get; set; }
        public Nullable<decimal> RateOfIntrestPer { get; set; }
        public string Per { get; set; }
        public string AccHolderName { get; set; }
        public string AccNumber { get; set; }
        public string IFSCode { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string BSRCode { get; set; }
        public string SourceOfUpdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccountReceiptDetail> tblAccountReceiptDetails { get; set; }
        public virtual tblSysOrganization tblSysOrganization { get; set; }
    }
}
