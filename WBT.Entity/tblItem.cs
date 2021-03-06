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
    
    public partial class tblItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblItem()
        {
            this.BasicExpensesDetails = new HashSet<BasicExpensesDetail>();
            this.DCQtyAllocationItemWarehouseMaps = new HashSet<DCQtyAllocationItemWarehouseMap>();
            this.DiscountsExpenseDetails = new HashSet<DiscountsExpenseDetail>();
            this.DiscrepencyDetails = new HashSet<DiscrepencyDetail>();
            this.FranchiseMarginDetails = new HashSet<FranchiseMarginDetail>();
            this.FreightExpenseDetails = new HashSet<FreightExpenseDetail>();
            this.FumigationItemWrhsDetails = new HashSet<FumigationItemWrhsDetail>();
            this.FuturisticItemThresholdQties = new HashSet<FuturisticItemThresholdQty>();
            this.ItemThresholdQtyDetails = new HashSet<ItemThresholdQtyDetail>();
            this.tblAccountCreditNoteItemDetails = new HashSet<tblAccountCreditNoteItemDetail>();
            this.tblAccountDebitNoteItemDetails = new HashSet<tblAccountDebitNoteItemDetail>();
            this.tblCartItems = new HashSet<tblCartItem>();
            this.tblDeliveryNoteItems = new HashSet<tblDeliveryNoteItem>();
            this.tblDiscounts = new HashSet<tblDiscount>();
            this.tblGatePassItems = new HashSet<tblGatePassItem>();
            this.tblGoodsInwardNoteItems = new HashSet<tblGoodsInwardNoteItem>();
            this.tblGRNItems = new HashSet<tblGRNItem>();
            this.tblHOBranchPriceDetails = new HashSet<tblHOBranchPriceDetail>();
            this.tblHOMasterPriceDetails = new HashSet<tblHOMasterPriceDetail>();
            this.tblItemStockTransferDestinations = new HashSet<tblItemStockTransferDestination>();
            this.tblItemStockTransferSources = new HashSet<tblItemStockTransferSource>();
            this.tblPurchaseOrderWithItems = new HashSet<tblPurchaseOrderWithItem>();
            this.tblSalesOrderInvoiceItemDetails = new HashSet<tblSalesOrderInvoiceItemDetail>();
            this.tblSalesOrderItemWarehouseMaps = new HashSet<tblSalesOrderItemWarehouseMap>();
            this.tblSalesOrderWithItems = new HashSet<tblSalesOrderWithItem>();
            this.tblItemMappings = new HashSet<tblItemMapping>();
            this.tblItemMappingWithCESSes = new HashSet<tblItemMappingWithCESS>();
            this.tblItemMovements = new HashSet<tblItemMovement>();
            this.tblItemParameterMaps = new HashSet<tblItemParameterMap>();
            this.tblItemSupplierMappings = new HashSet<tblItemSupplierMapping>();
            this.tblItemWarehouseMaps = new HashSet<tblItemWarehouseMap>();
            this.tblPOQuotations = new HashSet<tblPOQuotation>();
            this.tblPurchaseRequisitionItemsDetails = new HashSet<tblPurchaseRequisitionItemsDetail>();
            this.tblStockTransferLineItems = new HashSet<tblStockTransferLineItem>();
            this.tblItemImageDetails = new HashSet<tblItemImageDetail>();
            this.tblPurchaseOrderInvoiceItemDetails = new HashSet<tblPurchaseOrderInvoiceItemDetail>();
            this.tblStickerDetails = new HashSet<tblStickerDetail>();
        }
    
        public int ID { get; set; }
        public string ItemCode { get; set; }
        public string Barcode { get; set; }
        public string TallyItemName { get; set; }
        public string OldItemName { get; set; }
        public string ItemName { get; set; }
        public string Alias { get; set; }
        public string OrgID { get; set; }
        public Nullable<int> RateID { get; set; }
        public Nullable<int> BaseUnit { get; set; }
        public Nullable<decimal> BasePKTValue { get; set; }
        public Nullable<int> AlternateUnit { get; set; }
        public Nullable<decimal> AlternatePKTValue { get; set; }
        public Nullable<int> PacketUOMID { get; set; }
        public Nullable<decimal> PacketQTY { get; set; }
        public Nullable<int> BagUOMID { get; set; }
        public Nullable<decimal> BagQTY { get; set; }
        public Nullable<bool> IsTallyUpdated { get; set; }
        public Nullable<bool> IsParentTallyUpdated { get; set; }
        public Nullable<bool> IsCESSMapped { get; set; }
        public Nullable<decimal> CESSValue { get; set; }
        public Nullable<System.DateTime> CESSEffectiveDate { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public Nullable<int> RackID { get; set; }
        public string ItemDetail { get; set; }
        public string StorageArea { get; set; }
        public Nullable<bool> AllowNegativeStock { get; set; }
        public Nullable<bool> IsItemBlocked { get; set; }
        public decimal GST { get; set; }
        public Nullable<System.DateTime> GSTEffectiveDate { get; set; }
        public string IGST { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public Nullable<int> ReOrderlevel { get; set; }
        public Nullable<int> ReOrderQTY { get; set; }
        public Nullable<bool> IsReturnable { get; set; }
        public Nullable<bool> IsTrademarkRegistered { get; set; }
        public string PreDefinedBarCode { get; set; }
        public string SourceOfUpdate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> DaysToRefill { get; set; }
        public Nullable<int> HSNCode { get; set; }
        public Nullable<int> HSNSubCode { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public Nullable<bool> isProcessItem { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasicExpensesDetail> BasicExpensesDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DCQtyAllocationItemWarehouseMap> DCQtyAllocationItemWarehouseMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscountsExpenseDetail> DiscountsExpenseDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscrepencyDetail> DiscrepencyDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FranchiseMarginDetail> FranchiseMarginDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FreightExpenseDetail> FreightExpenseDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FumigationItemWrhsDetail> FumigationItemWrhsDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FuturisticItemThresholdQty> FuturisticItemThresholdQties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemThresholdQtyDetail> ItemThresholdQtyDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccountCreditNoteItemDetail> tblAccountCreditNoteItemDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccountDebitNoteItemDetail> tblAccountDebitNoteItemDetails { get; set; }
        public virtual tblBrand tblBrand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCartItem> tblCartItems { get; set; }
        public virtual tblCategory tblCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDeliveryNoteItem> tblDeliveryNoteItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDiscount> tblDiscounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGatePassItem> tblGatePassItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGoodsInwardNoteItem> tblGoodsInwardNoteItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGRNItem> tblGRNItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHOBranchPriceDetail> tblHOBranchPriceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHOMasterPriceDetail> tblHOMasterPriceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemStockTransferDestination> tblItemStockTransferDestinations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemStockTransferSource> tblItemStockTransferSources { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseOrderWithItem> tblPurchaseOrderWithItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSalesOrderInvoiceItemDetail> tblSalesOrderInvoiceItemDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSalesOrderItemWarehouseMap> tblSalesOrderItemWarehouseMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSalesOrderWithItem> tblSalesOrderWithItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemMapping> tblItemMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemMappingWithCESS> tblItemMappingWithCESSes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemMovement> tblItemMovements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemParameterMap> tblItemParameterMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemSupplierMapping> tblItemSupplierMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemWarehouseMap> tblItemWarehouseMaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPOQuotation> tblPOQuotations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseRequisitionItemsDetail> tblPurchaseRequisitionItemsDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStockTransferLineItem> tblStockTransferLineItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblItemImageDetail> tblItemImageDetails { get; set; }
        public virtual tblItemRate tblItemRate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPurchaseOrderInvoiceItemDetail> tblPurchaseOrderInvoiceItemDetails { get; set; }
        public virtual tblRack tblRack { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStickerDetail> tblStickerDetails { get; set; }
        public virtual tblSubCategory tblSubCategory { get; set; }
        public virtual tblSysUser tblSysUser { get; set; }
        public virtual tblSysUser tblSysUser1 { get; set; }
        public virtual tblUOM tblUOM { get; set; }
        public virtual tblUOM tblUOM1 { get; set; }
    }
}
