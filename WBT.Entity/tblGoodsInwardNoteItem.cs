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
    
    public partial class tblGoodsInwardNoteItem
    {
        public int GINItemId { get; set; }
        public string GINID { get; set; }
        public string ItemCode { get; set; }
        public decimal OrderedQTY { get; set; }
        public string OrderUnit { get; set; }
        public decimal RecievedQTYTillDate { get; set; }
        public decimal PendingQTY { get; set; }
        public Nullable<decimal> QTYTOBInwarded { get; set; }
        public Nullable<int> BatchID { get; set; }
        public Nullable<int> WareHouseId { get; set; }
        public Nullable<int> UnloadingSequence { get; set; }
        public string QualityRemark { get; set; }
        public string Remarks { get; set; }
        public int CreatedById { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedById { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<decimal> BilledQty { get; set; }
        public string Sizing { get; set; }
        public string Note { get; set; }
        public string InhouseBrand { get; set; }
        public string Status { get; set; }
        public string SourceOfUpdate { get; set; }
    
        public virtual tblBatch tblBatch { get; set; }
        public virtual tblGoodsInwardNote tblGoodsInwardNote { get; set; }
        public virtual tblItem tblItem { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
        public virtual tblWarehouse tblWarehouse { get; set; }
    }
}
