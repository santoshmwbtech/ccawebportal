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
    
    public partial class tblAccountContraDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccountContraDetail()
        {
            this.tblAccountContraBillWithDetails = new HashSet<tblAccountContraBillWithDetail>();
        }
    
        public int ID { get; set; }
        public string ContraID { get; set; }
        public string OrgID { get; set; }
        public string BranchID { get; set; }
        public Nullable<System.DateTime> ContraDatetime { get; set; }
        public string LedgerID { get; set; }
        public string ContraType { get; set; }
        public string BankOrCash { get; set; }
        public Nullable<decimal> CrditAmount { get; set; }
        public Nullable<decimal> DebitAmount { get; set; }
        public string VoucherTypeNo { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string SalesManID { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string IFSC { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionNumber { get; set; }
        public Nullable<System.DateTime> CheckDate { get; set; }
        public string Status { get; set; }
        public string SignatureImage { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> IsTallyUpdated { get; set; }
        public string SourceOfUpdate { get; set; }
        public string CustLocation { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccountContraBillWithDetail> tblAccountContraBillWithDetails { get; set; }
        public virtual tblSysBranch tblSysBranch { get; set; }
    }
}
