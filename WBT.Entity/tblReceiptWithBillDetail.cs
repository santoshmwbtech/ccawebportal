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
    
    public partial class tblReceiptWithBillDetail
    {
        public int ID { get; set; }
        public string ReceiptID { get; set; }
        public string billNo { get; set; }
        public string billdatetime { get; set; }
        public string TallyAmount { get; set; }
        public string discountamount { get; set; }
        public string billamount { get; set; }
        public string IsSalesOrderAddTally { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string SourceOfUpdate { get; set; }
        public Nullable<bool> TallySync { get; set; }
    
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
    }
}
