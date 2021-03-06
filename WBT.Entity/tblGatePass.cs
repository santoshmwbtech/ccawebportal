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
    
    public partial class tblGatePass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblGatePass()
        {
            this.DocumentUploads = new HashSet<DocumentUpload>();
            this.tblDeliveryNotes = new HashSet<tblDeliveryNote>();
            this.tblGatePassItems = new HashSet<tblGatePassItem>();
            this.tblSalesOrderInvoices = new HashSet<tblSalesOrderInvoice>();
        }
    
        public int ID { get; set; }
        public string GatePassCode { get; set; }
        public string OrgID { get; set; }
        public string SalesOrderNumber { get; set; }
        public string VehicalNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverNumber { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string TransporterName { get; set; }
        public Nullable<decimal> Tareweight { get; set; }
        public string LRNumber { get; set; }
        public Nullable<System.DateTime> GatePassDate { get; set; }
        public string SourceOfUpdate { get; set; }
        public string DriverPhone2 { get; set; }
        public bool IsTallyUpdated { get; set; }
        public int CreatedByID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string SOType { get; set; }
        public string SOTypeNum { get; set; }
        public string Remarks { get; set; }
        public string VoucherTypeNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentUpload> DocumentUploads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDeliveryNote> tblDeliveryNotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGatePassItem> tblGatePassItems { get; set; }
        public virtual tblVoucherType tblVoucherType { get; set; }
        public virtual tblSalesOrder tblSalesOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSalesOrderInvoice> tblSalesOrderInvoices { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
        public virtual tblSysOrganization tblSysOrganization { get; set; }
    }
}
