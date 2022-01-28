
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/14/2021 23:06:49
-- Generated from EDMX file: E:\SantoshNewSVN\CCAWebPortal\WBT.Entity\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CCA_DEV];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__tblAccess__Acces__086B34A6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccessControlItem] DROP CONSTRAINT [FK__tblAccess__Acces__086B34A6];
GO
IF OBJECT_ID(N'[dbo].[FK__tblChanne__OrgID__6F9F86DC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblChannelPartnerMapping] DROP CONSTRAINT [FK__tblChanne__OrgID__6F9F86DC];
GO
IF OBJECT_ID(N'[dbo].[FK__tblCustom__OrgID__54B68676]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerVendorDetail] DROP CONSTRAINT [FK__tblCustom__OrgID__54B68676];
GO
IF OBJECT_ID(N'[dbo].[FK__tblSysUse__OrgID__5C8CB268]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysUser] DROP CONSTRAINT [FK__tblSysUse__OrgID__5C8CB268];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessTypes_BusinessTypeMarginDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessTypeMarginDetails] DROP CONSTRAINT [FK_BusinessTypes_BusinessTypeMarginDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessTypes_FuturisticBusinessTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FuturisticBusinessTypes] DROP CONSTRAINT [FK_BusinessTypes_FuturisticBusinessTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessTypes_FuturisticItemThresholdQty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FuturisticItemThresholdQty] DROP CONSTRAINT [FK_BusinessTypes_FuturisticItemThresholdQty];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessTypes_ItemThresholdQtyDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemThresholdQtyDetails] DROP CONSTRAINT [FK_BusinessTypes_ItemThresholdQtyDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_DCQtyAllocationItemWarehouseMap_DCQuantityAllocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMap] DROP CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_DCQuantityAllocation];
GO
IF OBJECT_ID(N'[dbo].[FK_DCQtyAllocationItemWarehouseMap_tblBatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMap] DROP CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_tblBatch];
GO
IF OBJECT_ID(N'[dbo].[FK_DCQtyAllocationItemWarehouseMap_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMap] DROP CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_DCQtyAllocationItemWarehouseMap_tblPurchaseRequisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMap] DROP CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_tblPurchaseRequisition];
GO
IF OBJECT_ID(N'[dbo].[FK_DCQtyAllocationItemWarehouseMap_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMap] DROP CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_DenominationMapWithTrans_CurrencyDenominationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DenominationMapWithTrans] DROP CONSTRAINT [FK_DenominationMapWithTrans_CurrencyDenominationType];
GO
IF OBJECT_ID(N'[dbo].[FK_DiscrepencyDetails_tblBatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscrepencyDetails] DROP CONSTRAINT [FK_DiscrepencyDetails_tblBatch];
GO
IF OBJECT_ID(N'[dbo].[FK_DiscrepencyDetails_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscrepencyDetails] DROP CONSTRAINT [FK_DiscrepencyDetails_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_DiscrepencyDetails_tblReason]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscrepencyDetails] DROP CONSTRAINT [FK_DiscrepencyDetails_tblReason];
GO
IF OBJECT_ID(N'[dbo].[FK_DiscrepencyDetails_tblSysBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscrepencyDetails] DROP CONSTRAINT [FK_DiscrepencyDetails_tblSysBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_DiscrepencyDetails_tblSysUserCrID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscrepencyDetails] DROP CONSTRAINT [FK_DiscrepencyDetails_tblSysUserCrID];
GO
IF OBJECT_ID(N'[dbo].[FK_DiscrepencyDetails_tblSysUserMdID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscrepencyDetails] DROP CONSTRAINT [FK_DiscrepencyDetails_tblSysUserMdID];
GO
IF OBJECT_ID(N'[dbo].[FK_DiscrepencyDetails_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscrepencyDetails] DROP CONSTRAINT [FK_DiscrepencyDetails_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentsList_DocumentsSetting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentsSetting] DROP CONSTRAINT [FK_DocumentsList_DocumentsSetting];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentUploads_tblGatePass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentUploads] DROP CONSTRAINT [FK_DocumentUploads_tblGatePass];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentUploads_tblGoodsInwardNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentUploads] DROP CONSTRAINT [FK_DocumentUploads_tblGoodsInwardNote];
GO
IF OBJECT_ID(N'[dbo].[FK_FumigationDetails_FumigationItemWrhsDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FumigationItemWrhsDetails] DROP CONSTRAINT [FK_FumigationDetails_FumigationItemWrhsDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_FumigationItemWrhsDetails_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FumigationItemWrhsDetails] DROP CONSTRAINT [FK_FumigationItemWrhsDetails_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_GoodsInwardNote_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNote] DROP CONSTRAINT [FK_GoodsInwardNote_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_GoodsInwardNote_tblSysUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNote] DROP CONSTRAINT [FK_GoodsInwardNote_tblSysUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_GoodsInwardNoteItem_tblGoodsInwardNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNoteItem] DROP CONSTRAINT [FK_GoodsInwardNoteItem_tblGoodsInwardNote];
GO
IF OBJECT_ID(N'[dbo].[FK_GoodsInwardNoteItem_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNoteItem] DROP CONSTRAINT [FK_GoodsInwardNoteItem_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_BasicExpensesDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BasicExpensesDetails] DROP CONSTRAINT [FK_Itbltem_BasicExpensesDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_DiscountsExpenseDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiscountsExpenseDetails] DROP CONSTRAINT [FK_Itbltem_DiscountsExpenseDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_FranchiseMarginDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FranchiseMarginDetails] DROP CONSTRAINT [FK_Itbltem_FranchiseMarginDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_FreightExpenseDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FreightExpenseDetails] DROP CONSTRAINT [FK_Itbltem_FreightExpenseDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_tblItemStockTransferDestination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferDestination] DROP CONSTRAINT [FK_Itbltem_tblItemStockTransferDestination];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_tblItemStockTransferSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferSource] DROP CONSTRAINT [FK_Itbltem_tblItemStockTransferSource];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_tblPurchaseOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderWithItem] DROP CONSTRAINT [FK_Itbltem_tblPurchaseOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_tblSalesOrderInvoiceItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetail] DROP CONSTRAINT [FK_Itbltem_tblSalesOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_tblSalesOrderItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMap] DROP CONSTRAINT [FK_Itbltem_tblSalesOrderItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_Itbltem_tblSalesOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderWithItem] DROP CONSTRAINT [FK_Itbltem_tblSalesOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesManAreaMappingChild_tblArea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesManAreaMappingChild] DROP CONSTRAINT [FK_SalesManAreaMappingChild_tblArea];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesManAreaMappingChild_tblSalesManAreaMappingParent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesManAreaMappingChild] DROP CONSTRAINT [FK_SalesManAreaMappingChild_tblSalesManAreaMappingParent];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesManAreaMappingParent_tblCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesManAreaMappingParent] DROP CONSTRAINT [FK_SalesManAreaMappingParent_tblCity];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesManAreaMappingParent_tblDistrict]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesManAreaMappingParent] DROP CONSTRAINT [FK_SalesManAreaMappingParent_tblDistrict];
GO
IF OBJECT_ID(N'[dbo].[FK_SalesManAreaMappingParent_tblState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesManAreaMappingParent] DROP CONSTRAINT [FK_SalesManAreaMappingParent_tblState];
GO
IF OBJECT_ID(N'[dbo].[FK_SysBranch_tblSalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrder] DROP CONSTRAINT [FK_SysBranch_tblSalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_SysBranchSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysUser] DROP CONSTRAINT [FK_SysBranchSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_SysMainMenuSubMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysSubMenu] DROP CONSTRAINT [FK_SysMainMenuSubMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_Table_1_tblCustomerVendorDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNote] DROP CONSTRAINT [FK_Table_1_tblCustomerVendorDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_Table_1_tblPurchaseOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNote] DROP CONSTRAINT [FK_Table_1_tblPurchaseOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountContraBillWithDetails_tblAccountContraDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountContraBillWithDetails] DROP CONSTRAINT [FK_tblAccountContraBillWithDetails_tblAccountContraDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountContraDetails_tblSysBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountContraDetails] DROP CONSTRAINT [FK_tblAccountContraDetails_tblSysBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountCreditNoteDetails_tblSysBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountCreditNoteDetails] DROP CONSTRAINT [FK_tblAccountCreditNoteDetails_tblSysBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountCreditNoteItemDetails_tblAccountCreditNoteDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountCreditNoteItemDetails] DROP CONSTRAINT [FK_tblAccountCreditNoteItemDetails_tblAccountCreditNoteDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountCreditNoteItemDetails_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountCreditNoteItemDetails] DROP CONSTRAINT [FK_tblAccountCreditNoteItemDetails_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountCreditNoteItemDetails_tblReason]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountCreditNoteItemDetails] DROP CONSTRAINT [FK_tblAccountCreditNoteItemDetails_tblReason];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountCreditNoteWithBillDetails_tblAccountCreditNoteDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountCreditNoteWithBillDetails] DROP CONSTRAINT [FK_tblAccountCreditNoteWithBillDetails_tblAccountCreditNoteDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountCreditNoteWithBillDetails_tblAccountCreditNoteWithBillDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountCreditNoteWithBillDetails] DROP CONSTRAINT [FK_tblAccountCreditNoteWithBillDetails_tblAccountCreditNoteWithBillDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountDebitNoteDetails_tblSysBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountDebitNoteDetails] DROP CONSTRAINT [FK_tblAccountDebitNoteDetails_tblSysBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountDebitNoteItemDetails_tblAccountDebitNoteDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountDebitNoteItemDetails] DROP CONSTRAINT [FK_tblAccountDebitNoteItemDetails_tblAccountDebitNoteDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountDebitNoteItemDetails_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountDebitNoteItemDetails] DROP CONSTRAINT [FK_tblAccountDebitNoteItemDetails_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountDebitNoteItemDetails_tblReason]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountDebitNoteItemDetails] DROP CONSTRAINT [FK_tblAccountDebitNoteItemDetails_tblReason];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountDebitNoteWithBillDetails_tblAccountDebitNoteDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountDebitNoteWithBillDetails] DROP CONSTRAINT [FK_tblAccountDebitNoteWithBillDetails_tblAccountDebitNoteDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountGroupMaster_tblAccountGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountGroup] DROP CONSTRAINT [FK_tblAccountGroupMaster_tblAccountGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountGroupMaster_tblSubAccountGroupMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubAccountGroupMaster] DROP CONSTRAINT [FK_tblAccountGroupMaster_tblSubAccountGroupMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountLedger_tblAccountReceiptDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountReceiptDetails] DROP CONSTRAINT [FK_tblAccountLedger_tblAccountReceiptDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountLedger_tblSysOrganization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountLedger] DROP CONSTRAINT [FK_tblAccountLedger_tblSysOrganization];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountPaymentWithBillDetails_tblAccountPaymentDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountPaymentWithBillDetails] DROP CONSTRAINT [FK_tblAccountPaymentWithBillDetails_tblAccountPaymentDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountReceiptDetails_tblAccountReceiptWithBillDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountReceiptWithBillDetails] DROP CONSTRAINT [FK_tblAccountReceiptDetails_tblAccountReceiptWithBillDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountReceiptDetails_tblSysOrganization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountReceiptDetails] DROP CONSTRAINT [FK_tblAccountReceiptDetails_tblSysOrganization];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAccountReceiptWithBillDetails_tblSysOrganization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountReceiptWithBillDetails] DROP CONSTRAINT [FK_tblAccountReceiptWithBillDetails_tblSysOrganization];
GO
IF OBJECT_ID(N'[dbo].[FK_tblActivity_tblSubMenuRoleMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubMenuRoleMap] DROP CONSTRAINT [FK_tblActivity_tblSubMenuRoleMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAddtoCartChild_tblAddtoCartParent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCartItems] DROP CONSTRAINT [FK_tblAddtoCartChild_tblAddtoCartParent];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAddtoCartParent_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCart] DROP CONSTRAINT [FK_tblAddtoCartParent_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblArea_tblCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblArea] DROP CONSTRAINT [FK_tblArea_tblCity];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBatch_tblDeliveryNoteItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNoteItem] DROP CONSTRAINT [FK_tblBatch_tblDeliveryNoteItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBatch_tblGatePassItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePassItem] DROP CONSTRAINT [FK_tblBatch_tblGatePassItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBatch_tblItemMovement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMovement] DROP CONSTRAINT [FK_tblBatch_tblItemMovement];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBatch_tblItemStockTransferDestination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferDestination] DROP CONSTRAINT [FK_tblBatch_tblItemStockTransferDestination];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBatch_tblItemStockTransferSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferSource] DROP CONSTRAINT [FK_tblBatch_tblItemStockTransferSource];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBatch_tblSalesOrderItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMap] DROP CONSTRAINT [FK_tblBatch_tblSalesOrderItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBatch1_tblStockTransferLineItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStockTransferLineItem] DROP CONSTRAINT [FK_tblBatch1_tblStockTransferLineItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblBrand_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItem] DROP CONSTRAINT [FK_tblBrand_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCartItems_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCartItems] DROP CONSTRAINT [FK_tblCartItems_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCategory_tblCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCategory] DROP CONSTRAINT [FK_tblCategory_tblCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCategory_tblHOMasterPriceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHOMasterPriceDetails] DROP CONSTRAINT [FK_tblCategory_tblHOMasterPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCategory_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItem] DROP CONSTRAINT [FK_tblCategory_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCategory_tblItemStockTransferDestination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferDestination] DROP CONSTRAINT [FK_tblCategory_tblItemStockTransferDestination];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCategory_tblParameter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblParameter] DROP CONSTRAINT [FK_tblCategory_tblParameter];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCategory_tblSubCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubCategory] DROP CONSTRAINT [FK_tblCategory_tblSubCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCity_tblDistrict]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCity] DROP CONSTRAINT [FK_tblCity_tblDistrict];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomerVendorDetail_tblGRN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRN] DROP CONSTRAINT [FK_tblCustomerVendorDetail_tblGRN];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomerVendorDetail_tblPOQuotationSuppliers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPOQuotationSuppliers] DROP CONSTRAINT [FK_tblCustomerVendorDetail_tblPOQuotationSuppliers];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomerVendorDetail_tblPurchaseOrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoice] DROP CONSTRAINT [FK_tblCustomerVendorDetail_tblPurchaseOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomerWarehouse_tblCustomerCreditDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerCreditDetail] DROP CONSTRAINT [FK_tblCustomerWarehouse_tblCustomerCreditDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomerWarehouse_tblPurchaseOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblCustomerWarehouse_tblPurchaseOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCustomerWarehouse_tblSalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrder] DROP CONSTRAINT [FK_tblCustomerWarehouse_tblSalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDebtorsPlaceDetails_tblDebtorsAreaDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDebtorsAreaDetails] DROP CONSTRAINT [FK_tblDebtorsPlaceDetails_tblDebtorsAreaDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDeliveryNote_tblDeliveryNoteItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNoteItem] DROP CONSTRAINT [FK_tblDeliveryNote_tblDeliveryNoteItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDeliveryNote_tblVoucherType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNote] DROP CONSTRAINT [FK_tblDeliveryNote_tblVoucherType];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDepartment_DeptID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysUser] DROP CONSTRAINT [FK_tblDepartment_DeptID];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDistrict_tblState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDistrict] DROP CONSTRAINT [FK_tblDistrict_tblState];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGatePass_tblDeliveryNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNote] DROP CONSTRAINT [FK_tblGatePass_tblDeliveryNote];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGatePass_tblGatePassItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePassItem] DROP CONSTRAINT [FK_tblGatePass_tblGatePassItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGatePass_tblVoucherType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePass] DROP CONSTRAINT [FK_tblGatePass_tblVoucherType];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGoodsInwardNote_tblPurchaseOrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoice] DROP CONSTRAINT [FK_tblGoodsInwardNote_tblPurchaseOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGoodsInwardNote_tblVoucherType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNote] DROP CONSTRAINT [FK_tblGoodsInwardNote_tblVoucherType];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGoodsInwardNoteItem_tblBatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNoteItem] DROP CONSTRAINT [FK_tblGoodsInwardNoteItem_tblBatch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGoodsInwardNoteItem_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNoteItem] DROP CONSTRAINT [FK_tblGoodsInwardNoteItem_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGoodsInwardNoteItem_tblSysUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNoteItem] DROP CONSTRAINT [FK_tblGoodsInwardNoteItem_tblSysUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGoodsInwardNoteItem_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGoodsInwardNoteItem] DROP CONSTRAINT [FK_tblGoodsInwardNoteItem_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGRN_tblGRNItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRNItems] DROP CONSTRAINT [FK_tblGRN_tblGRNItems];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGRN_tblVoucherType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRN] DROP CONSTRAINT [FK_tblGRN_tblVoucherType];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGRNItems_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRNItems] DROP CONSTRAINT [FK_tblGRNItems_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_FumigationItemWrhsDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FumigationItemWrhsDetails] DROP CONSTRAINT [FK_tblItem_FumigationItemWrhsDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_FuturisticItemThresholdQty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FuturisticItemThresholdQty] DROP CONSTRAINT [FK_tblItem_FuturisticItemThresholdQty];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_ItemThresholdQtyDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemThresholdQtyDetails] DROP CONSTRAINT [FK_tblItem_ItemThresholdQtyDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblDeliveryNoteItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNoteItem] DROP CONSTRAINT [FK_tblItem_tblDeliveryNoteItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblDiscount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDiscount] DROP CONSTRAINT [FK_tblItem_tblDiscount];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblGatePassItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePassItem] DROP CONSTRAINT [FK_tblItem_tblGatePassItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblGRNItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRNItems] DROP CONSTRAINT [FK_tblItem_tblGRNItems];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblHOBranchPriceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHOBranchPriceDetails] DROP CONSTRAINT [FK_tblItem_tblHOBranchPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblHOMasterPriceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHOMasterPriceDetails] DROP CONSTRAINT [FK_tblItem_tblHOMasterPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblItemMapping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMapping] DROP CONSTRAINT [FK_tblItem_tblItemMapping];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblItemMappingWithCESS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMappingWithCESS] DROP CONSTRAINT [FK_tblItem_tblItemMappingWithCESS];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblItemMovement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMovement] DROP CONSTRAINT [FK_tblItem_tblItemMovement];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblItemParameterMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemParameterMap] DROP CONSTRAINT [FK_tblItem_tblItemParameterMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblItemSupplierMapping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemSupplierMapping] DROP CONSTRAINT [FK_tblItem_tblItemSupplierMapping];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemWarehouseMap] DROP CONSTRAINT [FK_tblItem_tblItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblPOQuotation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPOQuotation] DROP CONSTRAINT [FK_tblItem_tblPOQuotation];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblPurchaseRequisitionItemsDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetail] DROP CONSTRAINT [FK_tblItem_tblPurchaseRequisitionItemsDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItem_tblStockTransferLineItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStockTransferLineItem] DROP CONSTRAINT [FK_tblItem_tblStockTransferLineItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemCompany_tblBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBrand] DROP CONSTRAINT [FK_tblItemCompany_tblBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemImageDetails_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemImageDetails] DROP CONSTRAINT [FK_tblItemImageDetails_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemRate_tblHOMasterPriceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHOMasterPriceDetails] DROP CONSTRAINT [FK_tblItemRate_tblHOMasterPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemRate_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItem] DROP CONSTRAINT [FK_tblItemRate_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemRate_tblItemMapping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMapping] DROP CONSTRAINT [FK_tblItemRate_tblItemMapping];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemStockTransferHeader_tblItemStockTransferSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferSource] DROP CONSTRAINT [FK_tblItemStockTransferHeader_tblItemStockTransferSource];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemStockTransferSource_tblItemStockTransferDestination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferDestination] DROP CONSTRAINT [FK_tblItemStockTransferSource_tblItemStockTransferDestination];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemSupplierMapping_tblCustomerVendorDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemSupplierMapping] DROP CONSTRAINT [FK_tblItemSupplierMapping_tblCustomerVendorDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemSupplierMapping_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemSupplierMapping] DROP CONSTRAINT [FK_tblItemSupplierMapping_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_tblItemWarehouseMap_tblGRN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemWarehouseMap] DROP CONSTRAINT [FK_tblItemWarehouseMap_tblGRN];
GO
IF OBJECT_ID(N'[dbo].[FK_tblNotification_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblNotification] DROP CONSTRAINT [FK_tblNotification_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblParameter_tblItemParameterMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemParameterMap] DROP CONSTRAINT [FK_tblParameter_tblItemParameterMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPCN_Details_tblPCN_Details]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPCN_Details] DROP CONSTRAINT [FK_tblPCN_Details_tblPCN_Details];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPercentageStructure_tblCustomerVendorDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerVendorDetail] DROP CONSTRAINT [FK_tblPercentageStructure_tblCustomerVendorDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPOQuotation_tblPOQuotationSuppliers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPOQuotationSuppliers] DROP CONSTRAINT [FK_tblPOQuotation_tblPOQuotationSuppliers];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblGRN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRN] DROP CONSTRAINT [FK_tblPurchaseOrder_tblGRN];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblPurchaseOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderWithItem] DROP CONSTRAINT [FK_tblPurchaseOrder_tblPurchaseOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblPurchaseRequisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblPurchaseOrder_tblPurchaseRequisition];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblSalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblPurchaseOrder_tblSalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblSysBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblPurchaseOrder_tblSysBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblPurchaseOrder_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblSysUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblPurchaseOrder_tblSysUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblTransitItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTransitItem] DROP CONSTRAINT [FK_tblPurchaseOrder_tblTransitItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblVoucherType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblPurchaseOrder_tblVoucherType];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrder_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblPurchaseOrder_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoice] DROP CONSTRAINT [FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoiceItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetail] DROP CONSTRAINT [FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrderInvoice_tblVoucherType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoice] DROP CONSTRAINT [FK_tblPurchaseOrderInvoice_tblVoucherType];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrderInvoiceItemDetail_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetail] DROP CONSTRAINT [FK_tblPurchaseOrderInvoiceItemDetail_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseOrderInvoiceItemDetail_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetail] DROP CONSTRAINT [FK_tblPurchaseOrderInvoiceItemDetail_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseRequisition_tblPurchaseRequisitionItemsDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetail] DROP CONSTRAINT [FK_tblPurchaseRequisition_tblPurchaseRequisitionItemsDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPurchaseRequisition_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseRequisition] DROP CONSTRAINT [FK_tblPurchaseRequisition_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblRack_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItem] DROP CONSTRAINT [FK_tblRack_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblReason_tblDeliveryNoteItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNoteItem] DROP CONSTRAINT [FK_tblReason_tblDeliveryNoteItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblReason_tblGatepassItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePassItem] DROP CONSTRAINT [FK_tblReason_tblGatepassItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblReason_tblGRNItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRNItems] DROP CONSTRAINT [FK_tblReason_tblGRNItems];
GO
IF OBJECT_ID(N'[dbo].[FK_tblReason_tblPurchaseOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderWithItem] DROP CONSTRAINT [FK_tblReason_tblPurchaseOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrder_tblDeliveryNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNote] DROP CONSTRAINT [FK_tblSalesOrder_tblDeliveryNote];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrder_tblGatePass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePass] DROP CONSTRAINT [FK_tblSalesOrder_tblGatePass];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrder_tblGatePassItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePassItem] DROP CONSTRAINT [FK_tblSalesOrder_tblGatePassItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrder_tblItemMovement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMovement] DROP CONSTRAINT [FK_tblSalesOrder_tblItemMovement];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrder_tblSalesOrderCashTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderCashTransaction] DROP CONSTRAINT [FK_tblSalesOrder_tblSalesOrderCashTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrder_tblSalesOrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoice] DROP CONSTRAINT [FK_tblSalesOrder_tblSalesOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrder_tblSalesOrderItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMap] DROP CONSTRAINT [FK_tblSalesOrder_tblSalesOrderItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrder_tblSalesOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderWithItem] DROP CONSTRAINT [FK_tblSalesOrder_tblSalesOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrderInvoice_tblCustomerVendorDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoice] DROP CONSTRAINT [FK_tblSalesOrderInvoice_tblCustomerVendorDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrderInvoice_tblGatePass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoice] DROP CONSTRAINT [FK_tblSalesOrderInvoice_tblGatePass];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrderInvoice_tblSalesOrderInvoiceItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetail] DROP CONSTRAINT [FK_tblSalesOrderInvoice_tblSalesOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrderWithItem_tblDeliveryNoteItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNoteItem] DROP CONSTRAINT [FK_tblSalesOrderWithItem_tblDeliveryNoteItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrderWithItem_tblGatePassItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePassItem] DROP CONSTRAINT [FK_tblSalesOrderWithItem_tblGatePassItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrderWithItem_tblItemMovement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMovement] DROP CONSTRAINT [FK_tblSalesOrderWithItem_tblItemMovement];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSalesOrderWithItem_tblSalesOrderItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMap] DROP CONSTRAINT [FK_tblSalesOrderWithItem_tblSalesOrderItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStickerDetails_tblGRN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStickerDetails] DROP CONSTRAINT [FK_tblStickerDetails_tblGRN];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStickerDetails_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStickerDetails] DROP CONSTRAINT [FK_tblStickerDetails_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStickerDetails_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStickerDetails] DROP CONSTRAINT [FK_tblStickerDetails_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStickerDetails_tblSysUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStickerDetails] DROP CONSTRAINT [FK_tblStickerDetails_tblSysUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStickerDetails_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStickerDetails] DROP CONSTRAINT [FK_tblStickerDetails_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStockTransferHeader_tblStockTransferLineItem1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStockTransferLineItem] DROP CONSTRAINT [FK_tblStockTransferHeader_tblStockTransferLineItem1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSubCategory_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItem] DROP CONSTRAINT [FK_tblSubCategory_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSubCategory_tblParameter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblParameter] DROP CONSTRAINT [FK_tblSubCategory_tblParameter];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_BasicExpensesDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BasicExpensesDetails] DROP CONSTRAINT [FK_tblSysBranch_BasicExpensesDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_BusinessTypeMarginDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessTypeMarginDetails] DROP CONSTRAINT [FK_tblSysBranch_BusinessTypeMarginDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_CreditTypeMarginDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditTypeMarginDetails] DROP CONSTRAINT [FK_tblSysBranch_CreditTypeMarginDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_tblHOBranchPriceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHOBranchPriceDetails] DROP CONSTRAINT [FK_tblSysBranch_tblHOBranchPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_tblItemMapping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMapping] DROP CONSTRAINT [FK_tblSysBranch_tblItemMapping];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_tblItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemWarehouseMap] DROP CONSTRAINT [FK_tblSysBranch_tblItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_tblOrganizationWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrganizationWarehouseMap] DROP CONSTRAINT [FK_tblSysBranch_tblOrganizationWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_tblPurchaseRequisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseRequisition] DROP CONSTRAINT [FK_tblSysBranch_tblPurchaseRequisition];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_tblSysChannelPartner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysChannelPartner] DROP CONSTRAINT [FK_tblSysBranch_tblSysChannelPartner];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysBranch_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWarehouse] DROP CONSTRAINT [FK_tblSysBranch_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysChannelPartner_ChannelTypeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysChannelPartner] DROP CONSTRAINT [FK_tblSysChannelPartner_ChannelTypeID];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysRole_Departments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysRole] DROP CONSTRAINT [FK_tblSysRole_Departments];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysRole_DeptID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysRole] DROP CONSTRAINT [FK_tblSysRole_DeptID];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysRole_tblSubMenuRoleMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubMenuRoleMap] DROP CONSTRAINT [FK_tblSysRole_tblSubMenuRoleMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysRole_tblsysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysUser] DROP CONSTRAINT [FK_tblSysRole_tblsysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysSubMenu_tblAccessRights]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccessRights] DROP CONSTRAINT [FK_tblSysSubMenu_tblAccessRights];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysSubMenu_tblSubMenuRoleMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubMenuRoleMap] DROP CONSTRAINT [FK_tblSysSubMenu_tblSubMenuRoleMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSystblUser_tblItemParameterMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemParameterMap] DROP CONSTRAINT [FK_tblSystblUser_tblItemParameterMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSystblUser_tblParameter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblParameter] DROP CONSTRAINT [FK_tblSystblUser_tblParameter];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_ItemCompanyID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemCompany] DROP CONSTRAINT [FK_tblsysUser_ItemCompanyID];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblAccessRights]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccessRights] DROP CONSTRAINT [FK_tblsysUser_tblAccessRights];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblAccountGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountGroup] DROP CONSTRAINT [FK_tblsysUser_tblAccountGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblAccountGroupMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountGroupMaster] DROP CONSTRAINT [FK_tblsysUser_tblAccountGroupMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblActivity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblActivity] DROP CONSTRAINT [FK_tblsysUser_tblActivity];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblAdminConfiguration]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAdminConfiguration] DROP CONSTRAINT [FK_tblsysUser_tblAdminConfiguration];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblBatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBatch] DROP CONSTRAINT [FK_tblsysUser_tblBatch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBrand] DROP CONSTRAINT [FK_tblsysUser_tblBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblCustomerCreditDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerCreditDetail] DROP CONSTRAINT [FK_tblsysUser_tblCustomerCreditDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblCustomerVendorDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerVendorDetail] DROP CONSTRAINT [FK_tblsysUser_tblCustomerVendorDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblDebtorsAreaDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDebtorsAreaDetails] DROP CONSTRAINT [FK_tblSysUser_tblDebtorsAreaDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblDebtorsPlaceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDebtorsPlaceDetails] DROP CONSTRAINT [FK_tblSysUser_tblDebtorsPlaceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblDiscount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDiscount] DROP CONSTRAINT [FK_tblsysUser_tblDiscount];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblGRN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRN] DROP CONSTRAINT [FK_tblsysUser_tblGRN];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblGRNItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRNItems] DROP CONSTRAINT [FK_tblsysUser_tblGRNItems];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblHOBranchPriceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHOBranchPriceDetails] DROP CONSTRAINT [FK_tblsysUser_tblHOBranchPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblHOMasterPriceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHOMasterPriceDetails] DROP CONSTRAINT [FK_tblsysUser_tblHOMasterPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblHSNCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHSNCode] DROP CONSTRAINT [FK_tblsysUser_tblHSNCode];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItem] DROP CONSTRAINT [FK_tblsysUser_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblItemMappingWithCESS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMappingWithCESS] DROP CONSTRAINT [FK_tblsysUser_tblItemMappingWithCESS];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblItemMovement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMovement] DROP CONSTRAINT [FK_tblsysUser_tblItemMovement];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblItemRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemRate] DROP CONSTRAINT [FK_tblSysUser_tblItemRate];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblItemStockTransferDestination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferDestination] DROP CONSTRAINT [FK_tblsysUser_tblItemStockTransferDestination];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblItemStockTransferHeader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferHeader] DROP CONSTRAINT [FK_tblSysUser_tblItemStockTransferHeader];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblItemSupplierMapping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemSupplierMapping] DROP CONSTRAINT [FK_tblsysUser_tblItemSupplierMapping];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblItemToItemTracking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemToItemTracking] DROP CONSTRAINT [FK_tblSysUser_tblItemToItemTracking];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemWarehouseMap] DROP CONSTRAINT [FK_tblsysUser_tblItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblOrganizationWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrganizationWarehouseMap] DROP CONSTRAINT [FK_tblSysUser_tblOrganizationWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblPacketSizeDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPacketSizeDetails] DROP CONSTRAINT [FK_tblSysUser_tblPacketSizeDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblPaymentReceipt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPaymentReceipt] DROP CONSTRAINT [FK_tblSysUser_tblPaymentReceipt];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblPercentageStructure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPercentageStructure] DROP CONSTRAINT [FK_tblsysUser_tblPercentageStructure];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblPOQuotation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPOQuotation] DROP CONSTRAINT [FK_tblsysUser_tblPOQuotation];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblPOQuotationSuppliers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPOQuotationSuppliers] DROP CONSTRAINT [FK_tblsysUser_tblPOQuotationSuppliers];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblPurchaseRequisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseRequisition] DROP CONSTRAINT [FK_tblSysUser_tblPurchaseRequisition];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblPurchaseRequisitionItemsDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetail] DROP CONSTRAINT [FK_tblSysUser_tblPurchaseRequisitionItemsDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblRack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblRack] DROP CONSTRAINT [FK_tblsysUser_tblRack];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblReason]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblReason] DROP CONSTRAINT [FK_tblSysUser_tblReason];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblReceiptDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblReceiptDetails] DROP CONSTRAINT [FK_tblSysUser_tblReceiptDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblReceiptWithBillDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblReceiptWithBillDetails] DROP CONSTRAINT [FK_tblSysUser_tblReceiptWithBillDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblSalesmanDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesmanDetails] DROP CONSTRAINT [FK_tblSysUser_tblSalesmanDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblSalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrder] DROP CONSTRAINT [FK_tblSysUser_tblSalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblStockTransferHeader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStockTransferHeader] DROP CONSTRAINT [FK_tblSysUser_tblStockTransferHeader];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblStockTransferLineItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStockTransferLineItem] DROP CONSTRAINT [FK_tblSysUser_tblStockTransferLineItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblSubAccountGroupMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubAccountGroupMaster] DROP CONSTRAINT [FK_tblsysUser_tblSubAccountGroupMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblSubCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubCategory] DROP CONSTRAINT [FK_tblsysUser_tblSubCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblSubMenuRoleMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubMenuRoleMap] DROP CONSTRAINT [FK_tblsysUser_tblSubMenuRoleMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblSysBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysBranch] DROP CONSTRAINT [FK_tblSysUser_tblSysBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblSysChannelPartner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysChannelPartner] DROP CONSTRAINT [FK_tblSysUser_tblSysChannelPartner];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblSysMainMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysMainMenu] DROP CONSTRAINT [FK_tblSysUser_tblSysMainMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblSysSubMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysSubMenu] DROP CONSTRAINT [FK_tblSysUser_tblSysSubMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysUser] DROP CONSTRAINT [FK_tblSysUser_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblTaxCESS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTaxCESS] DROP CONSTRAINT [FK_tblsysUser_tblTaxCESS];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblUnitQuantity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUnitQuantity] DROP CONSTRAINT [FK_tblsysUser_tblUnitQuantity];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblUOM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUOM] DROP CONSTRAINT [FK_tblSysUser_tblUOM];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblUserWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUserWarehouseMap] DROP CONSTRAINT [FK_tblsysUser_tblUserWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWarehouse] DROP CONSTRAINT [FK_tblsysUser_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser_tblWarehouseToWarehouseTracking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWarehouseToWarehouseTracking] DROP CONSTRAINT [FK_tblSysUser_tblWarehouseToWarehouseTracking];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblAccessRights]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccessRights] DROP CONSTRAINT [FK_tblSysUser1_tblAccessRights];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblActivity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblActivity] DROP CONSTRAINT [FK_tblSysUser1_tblActivity];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblAdminConfiguration]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAdminConfiguration] DROP CONSTRAINT [FK_tblSysUser1_tblAdminConfiguration];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblBatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBatch] DROP CONSTRAINT [FK_tblSysUser1_tblBatch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblBrand] DROP CONSTRAINT [FK_tblSysUser1_tblBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCategory] DROP CONSTRAINT [FK_tblSysUser1_tblCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblCustomerVendorDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerVendorDetail] DROP CONSTRAINT [FK_tblSysUser1_tblCustomerVendorDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblDebtorsAreaDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDebtorsAreaDetails] DROP CONSTRAINT [FK_tblSysUser1_tblDebtorsAreaDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblDebtorsPlaceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDebtorsPlaceDetails] DROP CONSTRAINT [FK_tblSysUser1_tblDebtorsPlaceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblDeliveryNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNote] DROP CONSTRAINT [FK_tblSysUser1_tblDeliveryNote];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblDeliveryNoteItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNoteItem] DROP CONSTRAINT [FK_tblSysUser1_tblDeliveryNoteItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblDiscount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDiscount] DROP CONSTRAINT [FK_tblSysUser1_tblDiscount];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblGatePass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePass] DROP CONSTRAINT [FK_tblSysUser1_tblGatePass];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblGatePassItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePassItem] DROP CONSTRAINT [FK_tblSysUser1_tblGatePassItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblGRN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRN] DROP CONSTRAINT [FK_tblSysUser1_tblGRN];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblGRNItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGRNItems] DROP CONSTRAINT [FK_tblSysUser1_tblGRNItems];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblHOBranchPriceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHOBranchPriceDetails] DROP CONSTRAINT [FK_tblSysUser1_tblHOBranchPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblHOMasterPriceDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHOMasterPriceDetails] DROP CONSTRAINT [FK_tblSysUser1_tblHOMasterPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblHSNCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHSNCode] DROP CONSTRAINT [FK_tblSysUser1_tblHSNCode];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItem] DROP CONSTRAINT [FK_tblSysUser1_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblItemCompany]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemCompany] DROP CONSTRAINT [FK_tblSysUser1_tblItemCompany];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblItemMappingWithCESS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMappingWithCESS] DROP CONSTRAINT [FK_tblSysUser1_tblItemMappingWithCESS];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblItemParameterMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemParameterMap] DROP CONSTRAINT [FK_tblSysUser1_tblItemParameterMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblItemRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemRate] DROP CONSTRAINT [FK_tblSysUser1_tblItemRate];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblItemSupplierMapping]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemSupplierMapping] DROP CONSTRAINT [FK_tblSysUser1_tblItemSupplierMapping];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblItemToItemTracking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemToItemTracking] DROP CONSTRAINT [FK_tblSysUser1_tblItemToItemTracking];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemWarehouseMap] DROP CONSTRAINT [FK_tblSysUser1_tblItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblOrganizationWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrganizationWarehouseMap] DROP CONSTRAINT [FK_tblSysUser1_tblOrganizationWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPacketSizeDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPacketSizeDetails] DROP CONSTRAINT [FK_tblSysUser1_tblPacketSizeDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblParameter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblParameter] DROP CONSTRAINT [FK_tblSysUser1_tblParameter];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPaymentReceipt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPaymentReceipt] DROP CONSTRAINT [FK_tblSysUser1_tblPaymentReceipt];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPercentageStructure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPercentageStructure] DROP CONSTRAINT [FK_tblSysUser1_tblPercentageStructure];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPOQuotation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPOQuotation] DROP CONSTRAINT [FK_tblSysUser1_tblPOQuotation];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPOQuotationSuppliers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPOQuotationSuppliers] DROP CONSTRAINT [FK_tblSysUser1_tblPOQuotationSuppliers];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPurchaseOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblSysUser1_tblPurchaseOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPurchaseOrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoice] DROP CONSTRAINT [FK_tblSysUser1_tblPurchaseOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPurchaseOrderInvoiceItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetail] DROP CONSTRAINT [FK_tblSysUser1_tblPurchaseOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPurchaseOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderWithItem] DROP CONSTRAINT [FK_tblSysUser1_tblPurchaseOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPurchaseRequisition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseRequisition] DROP CONSTRAINT [FK_tblSysUser1_tblPurchaseRequisition];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblPurchaseRequisitionItemsDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetail] DROP CONSTRAINT [FK_tblSysUser1_tblPurchaseRequisitionItemsDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblRack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblRack] DROP CONSTRAINT [FK_tblSysUser1_tblRack];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblReason]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblReason] DROP CONSTRAINT [FK_tblSysUser1_tblReason];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblReceiptDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblReceiptDetails] DROP CONSTRAINT [FK_tblSysUser1_tblReceiptDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblReceiptWithBillDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblReceiptWithBillDetails] DROP CONSTRAINT [FK_tblSysUser1_tblReceiptWithBillDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSalesmanDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesmanDetails] DROP CONSTRAINT [FK_tblSysUser1_tblSalesmanDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrder] DROP CONSTRAINT [FK_tblSysUser1_tblSalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSalesOrderCashTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderCashTransaction] DROP CONSTRAINT [FK_tblSysUser1_tblSalesOrderCashTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSalesOrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoice] DROP CONSTRAINT [FK_tblSysUser1_tblSalesOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSalesOrderInvoiceItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetail] DROP CONSTRAINT [FK_tblSysUser1_tblSalesOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSalesOrderItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMap] DROP CONSTRAINT [FK_tblSysUser1_tblSalesOrderItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSalesOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderWithItem] DROP CONSTRAINT [FK_tblSysUser1_tblSalesOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblsysUser1_tblSubAccountGroupMaster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubAccountGroupMaster] DROP CONSTRAINT [FK_tblsysUser1_tblSubAccountGroupMaster];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSubCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubCategory] DROP CONSTRAINT [FK_tblSysUser1_tblSubCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSubMenuRoleMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSubMenuRoleMap] DROP CONSTRAINT [FK_tblSysUser1_tblSubMenuRoleMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSysBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysBranch] DROP CONSTRAINT [FK_tblSysUser1_tblSysBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSysChannelPartner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysChannelPartner] DROP CONSTRAINT [FK_tblSysUser1_tblSysChannelPartner];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSysMainMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysMainMenu] DROP CONSTRAINT [FK_tblSysUser1_tblSysMainMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSysSubMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysSubMenu] DROP CONSTRAINT [FK_tblSysUser1_tblSysSubMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysUser] DROP CONSTRAINT [FK_tblSysUser1_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblTaxCESS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTaxCESS] DROP CONSTRAINT [FK_tblSysUser1_tblTaxCESS];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblTransitItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTransitItem] DROP CONSTRAINT [FK_tblSysUser1_tblTransitItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblTransitItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTransitItemDetail] DROP CONSTRAINT [FK_tblSysUser1_tblTransitItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblUnitQuantity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUnitQuantity] DROP CONSTRAINT [FK_tblSysUser1_tblUnitQuantity];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblUOM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUOM] DROP CONSTRAINT [FK_tblSysUser1_tblUOM];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblUserWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUserWarehouseMap] DROP CONSTRAINT [FK_tblSysUser1_tblUserWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblWarehouse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWarehouse] DROP CONSTRAINT [FK_tblSysUser1_tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser1_tblWarehouseToWarehouseTracking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblWarehouseToWarehouseTracking] DROP CONSTRAINT [FK_tblSysUser1_tblWarehouseToWarehouseTracking];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser2_tblAccessRights]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccessRights] DROP CONSTRAINT [FK_tblSysUser2_tblAccessRights];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUser2_tblCustomerVendorDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCustomerVendorDetail] DROP CONSTRAINT [FK_tblSysUser2_tblCustomerVendorDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSysUserBr_tblSalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrder] DROP CONSTRAINT [FK_tblSysUserBr_tblSalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTransitItem_tblTransitItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTransitItemDetail] DROP CONSTRAINT [FK_tblTransitItem_tblTransitItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUOM_tblItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItem] DROP CONSTRAINT [FK_tblUOM_tblItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUOM_tblItem1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItem] DROP CONSTRAINT [FK_tblUOM_tblItem1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUOM_tblItemRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemRate] DROP CONSTRAINT [FK_tblUOM_tblItemRate];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblDeliveryNoteItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNoteItem] DROP CONSTRAINT [FK_tblUser_tblDeliveryNoteItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblGatePass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePass] DROP CONSTRAINT [FK_tblUser_tblGatePass];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblGatePassItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNote] DROP CONSTRAINT [FK_tblUser_tblGatePassItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblItemStockTransferSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferSource] DROP CONSTRAINT [FK_tblUser_tblItemStockTransferSource];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblPurchaseOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrder] DROP CONSTRAINT [FK_tblUser_tblPurchaseOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblPurchaseOrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoice] DROP CONSTRAINT [FK_tblUser_tblPurchaseOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblPurchaseOrderInvoiceItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetail] DROP CONSTRAINT [FK_tblUser_tblPurchaseOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblPurchaseOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderWithItem] DROP CONSTRAINT [FK_tblUser_tblPurchaseOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblSalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrder] DROP CONSTRAINT [FK_tblUser_tblSalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblSalesOrderCashTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderCashTransaction] DROP CONSTRAINT [FK_tblUser_tblSalesOrderCashTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblSalesOrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoice] DROP CONSTRAINT [FK_tblUser_tblSalesOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblSalesOrderInvoiceItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetail] DROP CONSTRAINT [FK_tblUser_tblSalesOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblSalesOrderItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMap] DROP CONSTRAINT [FK_tblUser_tblSalesOrderItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblSalesOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderWithItem] DROP CONSTRAINT [FK_tblUser_tblSalesOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblTransitItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTransitItem] DROP CONSTRAINT [FK_tblUser_tblTransitItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblUser_tblTransitItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTransitItemDetail] DROP CONSTRAINT [FK_tblUser_tblTransitItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblVoucherType_tblSalesOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrder] DROP CONSTRAINT [FK_tblVoucherType_tblSalesOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_tblVoucherType_tblSalesOrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoice] DROP CONSTRAINT [FK_tblVoucherType_tblSalesOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_tblVoucherType_tblSysBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblVoucherType] DROP CONSTRAINT [FK_tblVoucherType_tblSysBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblVoucherType_tblSysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblVoucherType] DROP CONSTRAINT [FK_tblVoucherType_tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblVoucherType_tblSysUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblVoucherType] DROP CONSTRAINT [FK_tblVoucherType_tblSysUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblVoucherTypeDisplayCol_tblVoucherTypeNo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblVoucherType] DROP CONSTRAINT [FK_tblVoucherTypeDisplayCol_tblVoucherTypeNo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblDeliveryNoteItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDeliveryNoteItem] DROP CONSTRAINT [FK_tblWarehouse_tblDeliveryNoteItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblGatePassItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGatePassItem] DROP CONSTRAINT [FK_tblWarehouse_tblGatePassItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblItemMovement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemMovement] DROP CONSTRAINT [FK_tblWarehouse_tblItemMovement];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblItemStockTransferDestination]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferDestination] DROP CONSTRAINT [FK_tblWarehouse_tblItemStockTransferDestination];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblItemStockTransferSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemStockTransferSource] DROP CONSTRAINT [FK_tblWarehouse_tblItemStockTransferSource];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblItemWarehouseMap] DROP CONSTRAINT [FK_tblWarehouse_tblItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblOrganizationWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrganizationWarehouseMap] DROP CONSTRAINT [FK_tblWarehouse_tblOrganizationWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblPurchaseOrderWithItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseOrderWithItem] DROP CONSTRAINT [FK_tblWarehouse_tblPurchaseOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblPurchaseRequisitionItemsDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetail] DROP CONSTRAINT [FK_tblWarehouse_tblPurchaseRequisitionItemsDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblSalesOrderInvoiceItemDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetail] DROP CONSTRAINT [FK_tblWarehouse_tblSalesOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblSalesOrderItemWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMap] DROP CONSTRAINT [FK_tblWarehouse_tblSalesOrderItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblStockTransferLineItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStockTransferLineItem] DROP CONSTRAINT [FK_tblWarehouse_tblStockTransferLineItem];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblStockTransferLineItem1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStockTransferLineItem] DROP CONSTRAINT [FK_tblWarehouse_tblStockTransferLineItem1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblsysUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSysUser] DROP CONSTRAINT [FK_tblWarehouse_tblsysUser];
GO
IF OBJECT_ID(N'[dbo].[FK_tblWarehouse_tblUserWarehouseMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblUserWarehouseMap] DROP CONSTRAINT [FK_tblWarehouse_tblUserWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[FK_TypeOfExpenses_BasicExpensesDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BasicExpensesDetails] DROP CONSTRAINT [FK_TypeOfExpenses_BasicExpensesDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCategory] DROP CONSTRAINT [FK_UserCategory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountGroupDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountGroupDetails];
GO
IF OBJECT_ID(N'[dbo].[BasicExpensesDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BasicExpensesDetails];
GO
IF OBJECT_ID(N'[dbo].[BusinessTypeMarginDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessTypeMarginDetails];
GO
IF OBJECT_ID(N'[dbo].[BusinessTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessTypes];
GO
IF OBJECT_ID(N'[dbo].[CreditTypeMarginDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditTypeMarginDetails];
GO
IF OBJECT_ID(N'[dbo].[CreditTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditTypes];
GO
IF OBJECT_ID(N'[dbo].[CurrencyDenominationType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrencyDenominationType];
GO
IF OBJECT_ID(N'[dbo].[DCQtyAllocationItemWarehouseMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DCQtyAllocationItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[DCQuantityAllocation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DCQuantityAllocation];
GO
IF OBJECT_ID(N'[dbo].[DeliverycenterBranchMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliverycenterBranchMap];
GO
IF OBJECT_ID(N'[dbo].[DenominationMapWithTrans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DenominationMapWithTrans];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[DiscountsExpenseDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiscountsExpenseDetails];
GO
IF OBJECT_ID(N'[dbo].[DiscrepencyDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiscrepencyDetails];
GO
IF OBJECT_ID(N'[dbo].[DocumentsList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentsList];
GO
IF OBJECT_ID(N'[dbo].[DocumentsSetting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentsSetting];
GO
IF OBJECT_ID(N'[dbo].[DocumentUploads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentUploads];
GO
IF OBJECT_ID(N'[dbo].[FranchiseMarginDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FranchiseMarginDetails];
GO
IF OBJECT_ID(N'[dbo].[FreightExpenseDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FreightExpenseDetails];
GO
IF OBJECT_ID(N'[dbo].[FumigationDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FumigationDetails];
GO
IF OBJECT_ID(N'[dbo].[FumigationItemWrhsDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FumigationItemWrhsDetails];
GO
IF OBJECT_ID(N'[dbo].[FuturisticBusinessTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuturisticBusinessTypes];
GO
IF OBJECT_ID(N'[dbo].[FuturisticCreditTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuturisticCreditTypes];
GO
IF OBJECT_ID(N'[dbo].[FuturisticItemThresholdQty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuturisticItemThresholdQty];
GO
IF OBJECT_ID(N'[dbo].[ItemThresholdQtyDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemThresholdQtyDetails];
GO
IF OBJECT_ID(N'[dbo].[LedgersOpeningBalances]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LedgersOpeningBalances];
GO
IF OBJECT_ID(N'[dbo].[OfferPriceDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OfferPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[RateTransactionDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RateTransactionDetails];
GO
IF OBJECT_ID(N'[dbo].[SalesManAreaMappingChild]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesManAreaMappingChild];
GO
IF OBJECT_ID(N'[dbo].[SalesManAreaMappingParent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesManAreaMappingParent];
GO
IF OBJECT_ID(N'[dbo].[tblAccessControl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccessControl];
GO
IF OBJECT_ID(N'[dbo].[tblAccessControlItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccessControlItem];
GO
IF OBJECT_ID(N'[dbo].[tblAccessRights]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccessRights];
GO
IF OBJECT_ID(N'[dbo].[tblAccountContraBillWithDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountContraBillWithDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountContraDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountContraDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountCreditNoteDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountCreditNoteDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountCreditNoteItemDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountCreditNoteItemDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountCreditNoteWithBillDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountCreditNoteWithBillDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountDebitNoteDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountDebitNoteDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountDebitNoteItemDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountDebitNoteItemDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountDebitNoteWithBillDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountDebitNoteWithBillDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountGroup];
GO
IF OBJECT_ID(N'[dbo].[tblAccountGroupMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountGroupMaster];
GO
IF OBJECT_ID(N'[dbo].[tblAccountLedger]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountLedger];
GO
IF OBJECT_ID(N'[dbo].[tblAccountPaymentDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountPaymentDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountPaymentWithBillDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountPaymentWithBillDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountReceiptDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountReceiptDetails];
GO
IF OBJECT_ID(N'[dbo].[tblAccountReceiptWithBillDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountReceiptWithBillDetails];
GO
IF OBJECT_ID(N'[dbo].[tblActivity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblActivity];
GO
IF OBJECT_ID(N'[dbo].[tblAdminConfiguration]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAdminConfiguration];
GO
IF OBJECT_ID(N'[dbo].[tblAdminSettings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAdminSettings];
GO
IF OBJECT_ID(N'[dbo].[tblArea]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblArea];
GO
IF OBJECT_ID(N'[dbo].[tblBatch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBatch];
GO
IF OBJECT_ID(N'[dbo].[tblBranchDocuments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBranchDocuments];
GO
IF OBJECT_ID(N'[dbo].[tblBrand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBrand];
GO
IF OBJECT_ID(N'[dbo].[tblCart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCart];
GO
IF OBJECT_ID(N'[dbo].[tblCartItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCartItems];
GO
IF OBJECT_ID(N'[dbo].[tblCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCategory];
GO
IF OBJECT_ID(N'[dbo].[tblCategoryType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCategoryType];
GO
IF OBJECT_ID(N'[dbo].[tblChannelPartnerMapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblChannelPartnerMapping];
GO
IF OBJECT_ID(N'[dbo].[tblCity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCity];
GO
IF OBJECT_ID(N'[dbo].[tblCompanyType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCompanyType];
GO
IF OBJECT_ID(N'[dbo].[tblCountry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCountry];
GO
IF OBJECT_ID(N'[dbo].[tblCustomerCreditDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCustomerCreditDetail];
GO
IF OBJECT_ID(N'[dbo].[tblCustomerType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCustomerType];
GO
IF OBJECT_ID(N'[dbo].[tblCustomerVendorDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCustomerVendorDetail];
GO
IF OBJECT_ID(N'[dbo].[tblDebtorsAreaDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDebtorsAreaDetails];
GO
IF OBJECT_ID(N'[dbo].[tblDebtorsDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDebtorsDetails];
GO
IF OBJECT_ID(N'[dbo].[tblDebtorsPlaceDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDebtorsPlaceDetails];
GO
IF OBJECT_ID(N'[dbo].[tblDeliveryNote]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDeliveryNote];
GO
IF OBJECT_ID(N'[dbo].[tblDeliveryNoteItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDeliveryNoteItem];
GO
IF OBJECT_ID(N'[dbo].[tblDepartments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDepartments];
GO
IF OBJECT_ID(N'[dbo].[tblDiscount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDiscount];
GO
IF OBJECT_ID(N'[dbo].[tblDistrict]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDistrict];
GO
IF OBJECT_ID(N'[dbo].[tblEmailTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEmailTemplate];
GO
IF OBJECT_ID(N'[dbo].[tblGatePass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGatePass];
GO
IF OBJECT_ID(N'[dbo].[tblGatePassItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGatePassItem];
GO
IF OBJECT_ID(N'[dbo].[tblGoodsInwardNote]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGoodsInwardNote];
GO
IF OBJECT_ID(N'[dbo].[tblGoodsInwardNoteItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGoodsInwardNoteItem];
GO
IF OBJECT_ID(N'[dbo].[tblGRN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGRN];
GO
IF OBJECT_ID(N'[dbo].[tblGRNItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGRNItems];
GO
IF OBJECT_ID(N'[dbo].[tblHOBranchPriceDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblHOBranchPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[tblHOMasterPriceDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblHOMasterPriceDetails];
GO
IF OBJECT_ID(N'[dbo].[tblHSNCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblHSNCode];
GO
IF OBJECT_ID(N'[dbo].[tblItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItem];
GO
IF OBJECT_ID(N'[dbo].[tblItemCompany]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemCompany];
GO
IF OBJECT_ID(N'[dbo].[tblItemImageDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemImageDetails];
GO
IF OBJECT_ID(N'[dbo].[tblItemMapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemMapping];
GO
IF OBJECT_ID(N'[dbo].[tblItemMappingWithCESS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemMappingWithCESS];
GO
IF OBJECT_ID(N'[dbo].[tblItemMovement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemMovement];
GO
IF OBJECT_ID(N'[dbo].[tblItemParameterMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemParameterMap];
GO
IF OBJECT_ID(N'[dbo].[tblItemRate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemRate];
GO
IF OBJECT_ID(N'[dbo].[tblItemStockTransferDestination]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemStockTransferDestination];
GO
IF OBJECT_ID(N'[dbo].[tblItemStockTransferHeader]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemStockTransferHeader];
GO
IF OBJECT_ID(N'[dbo].[tblItemStockTransferSource]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemStockTransferSource];
GO
IF OBJECT_ID(N'[dbo].[tblItemSupplierMapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemSupplierMapping];
GO
IF OBJECT_ID(N'[dbo].[tblItemToItemTracking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemToItemTracking];
GO
IF OBJECT_ID(N'[dbo].[tblItemWarehouseMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[tblLedgerType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLedgerType];
GO
IF OBJECT_ID(N'[dbo].[tblNotification]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblNotification];
GO
IF OBJECT_ID(N'[dbo].[tblOrganizationWarehouseMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOrganizationWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[tblOrgSystemDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOrgSystemDetails];
GO
IF OBJECT_ID(N'[dbo].[tblPacketSizeDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPacketSizeDetails];
GO
IF OBJECT_ID(N'[dbo].[tblParameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblParameter];
GO
IF OBJECT_ID(N'[dbo].[tblPaymentReceipt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPaymentReceipt];
GO
IF OBJECT_ID(N'[dbo].[tblPCN_Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPCN_Details];
GO
IF OBJECT_ID(N'[dbo].[tblPercentageStructure]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPercentageStructure];
GO
IF OBJECT_ID(N'[dbo].[tblPlan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPlan];
GO
IF OBJECT_ID(N'[dbo].[tblPNCN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPNCN];
GO
IF OBJECT_ID(N'[dbo].[tblPOQuotation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPOQuotation];
GO
IF OBJECT_ID(N'[dbo].[tblPOQuotationSuppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPOQuotationSuppliers];
GO
IF OBJECT_ID(N'[dbo].[tblProcessitem_Master]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProcessitem_Master];
GO
IF OBJECT_ID(N'[dbo].[tblPurchaseOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchaseOrder];
GO
IF OBJECT_ID(N'[dbo].[tblPurchaseOrderInvoice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchaseOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[tblPurchaseOrderInvoiceItemDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchaseOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[tblPurchaseOrderWithItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchaseOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[tblPurchaseRequisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchaseRequisition];
GO
IF OBJECT_ID(N'[dbo].[tblPurchaseRequisitionItemsDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPurchaseRequisitionItemsDetail];
GO
IF OBJECT_ID(N'[dbo].[tblRack]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRack];
GO
IF OBJECT_ID(N'[dbo].[tblReason]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblReason];
GO
IF OBJECT_ID(N'[dbo].[tblReceiptDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblReceiptDetails];
GO
IF OBJECT_ID(N'[dbo].[tblReceiptWithBillDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblReceiptWithBillDetails];
GO
IF OBJECT_ID(N'[dbo].[tblRouteMapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRouteMapping];
GO
IF OBJECT_ID(N'[dbo].[tblRouteMappingDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRouteMappingDetails];
GO
IF OBJECT_ID(N'[dbo].[tblSalesChannelType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSalesChannelType];
GO
IF OBJECT_ID(N'[dbo].[tblSalesmanDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSalesmanDetails];
GO
IF OBJECT_ID(N'[dbo].[tblSalesOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSalesOrder];
GO
IF OBJECT_ID(N'[dbo].[tblSalesOrderCashTransaction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSalesOrderCashTransaction];
GO
IF OBJECT_ID(N'[dbo].[tblSalesOrderInvoice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSalesOrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[tblSalesOrderInvoiceItemDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSalesOrderInvoiceItemDetail];
GO
IF OBJECT_ID(N'[dbo].[tblSalesOrderItemWarehouseMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSalesOrderItemWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[tblSalesOrderWithItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSalesOrderWithItem];
GO
IF OBJECT_ID(N'[dbo].[tblSMSTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSMSTemplate];
GO
IF OBJECT_ID(N'[dbo].[tblSPDocuments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSPDocuments];
GO
IF OBJECT_ID(N'[dbo].[tblState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblState];
GO
IF OBJECT_ID(N'[dbo].[tblStateWithCity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStateWithCity];
GO
IF OBJECT_ID(N'[dbo].[tblStickerDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStickerDetails];
GO
IF OBJECT_ID(N'[dbo].[tblStockTransferHeader]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStockTransferHeader];
GO
IF OBJECT_ID(N'[dbo].[tblStockTransferLineItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStockTransferLineItem];
GO
IF OBJECT_ID(N'[dbo].[tblSubAccountGroupMaster]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSubAccountGroupMaster];
GO
IF OBJECT_ID(N'[dbo].[tblSubCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSubCategory];
GO
IF OBJECT_ID(N'[dbo].[tblSubMenuRoleMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSubMenuRoleMap];
GO
IF OBJECT_ID(N'[dbo].[tblSysBranch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSysBranch];
GO
IF OBJECT_ID(N'[dbo].[tblSysChannelPartner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSysChannelPartner];
GO
IF OBJECT_ID(N'[dbo].[tblSysMainMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSysMainMenu];
GO
IF OBJECT_ID(N'[dbo].[tblSysOrganization]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSysOrganization];
GO
IF OBJECT_ID(N'[dbo].[tblSysOrganizationMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSysOrganizationMap];
GO
IF OBJECT_ID(N'[dbo].[tblSysRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSysRole];
GO
IF OBJECT_ID(N'[dbo].[tblSysSubMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSysSubMenu];
GO
IF OBJECT_ID(N'[dbo].[tblSystemDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSystemDetail];
GO
IF OBJECT_ID(N'[dbo].[tblSysUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSysUser];
GO
IF OBJECT_ID(N'[dbo].[tblTaxationType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTaxationType];
GO
IF OBJECT_ID(N'[dbo].[tblTaxCESS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTaxCESS];
GO
IF OBJECT_ID(N'[dbo].[tblTemplateImage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTemplateImage];
GO
IF OBJECT_ID(N'[dbo].[tblTransitItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTransitItem];
GO
IF OBJECT_ID(N'[dbo].[tblTransitItemDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTransitItemDetail];
GO
IF OBJECT_ID(N'[dbo].[tblUnitQuantity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUnitQuantity];
GO
IF OBJECT_ID(N'[dbo].[tblUOM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUOM];
GO
IF OBJECT_ID(N'[dbo].[tblUserAreaofService]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUserAreaofService];
GO
IF OBJECT_ID(N'[dbo].[tblUserDocument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUserDocument];
GO
IF OBJECT_ID(N'[dbo].[tblUserMapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUserMapping];
GO
IF OBJECT_ID(N'[dbo].[tblUserTemplates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUserTemplates];
GO
IF OBJECT_ID(N'[dbo].[tblUserWarehouseMap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUserWarehouseMap];
GO
IF OBJECT_ID(N'[dbo].[tblVoucherType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblVoucherType];
GO
IF OBJECT_ID(N'[dbo].[tblWarehouse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWarehouse];
GO
IF OBJECT_ID(N'[dbo].[tblWarehouseToWarehouseTracking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWarehouseToWarehouseTracking];
GO
IF OBJECT_ID(N'[dbo].[tblWhatsappTemplate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblWhatsappTemplate];
GO
IF OBJECT_ID(N'[dbo].[TypeOfExpenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeOfExpenses];
GO
IF OBJECT_ID(N'[dbo].[VirtualWarehouseDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VirtualWarehouseDetails];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccountGroupDetails'
CREATE TABLE [dbo].[AccountGroupDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [AccGroupName] nvarchar(150)  NULL,
    [Description] nvarchar(550)  NULL,
    [ParentGroupID] int  NULL,
    [IsEditable] bit  NULL,
    [CreationDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [CreatedByID] int  NULL,
    [ModifiedByID] int  NULL,
    [isTallyUpdated] bit  NULL,
    [TallyUpdatedDate] datetime  NULL,
    [TallyUpdatedByID] int  NULL
);
GO

-- Creating table 'BasicExpensesDetails'
CREATE TABLE [dbo].[BasicExpensesDetails] (
    [BaiscExpID] int IDENTITY(1,1) NOT NULL,
    [ExpsID] int  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [CategoryID] int  NULL,
    [SubcategoryID] int  NULL,
    [BranchID] varchar(10)  NULL,
    [CityID] int  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [Value] decimal(18,2)  NULL,
    [ValueInPer] decimal(18,2)  NULL,
    [IsValueInPercentage] bit  NOT NULL,
    [Unit] nvarchar(10)  NULL,
    [CreatedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'BusinessTypeMarginDetails'
CREATE TABLE [dbo].[BusinessTypeMarginDetails] (
    [BTMarginsID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [BusinessTypeID] int  NULL,
    [Margin] decimal(4,2)  NULL,
    [BranchID] varchar(10)  NULL,
    [CityID] int  NULL,
    [IsActive] bit  NULL,
    [FrmEffectiveDate] datetime  NULL,
    [FrmEffectiveTime] nvarchar(10)  NULL,
    [ToEffectiveDate] datetime  NULL,
    [ToEffectiveTime] nvarchar(10)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedByID] int  NULL
);
GO

-- Creating table 'BusinessTypes'
CREATE TABLE [dbo].[BusinessTypes] (
    [BusinessTypeID] int IDENTITY(1,1) NOT NULL,
    [BusinessTypeName] nvarchar(150)  NULL,
    [OrgId] varchar(10)  NULL,
    [CreatedDate] datetime  NULL,
    [CreadtedById] int  NULL
);
GO

-- Creating table 'CreditTypeMarginDetails'
CREATE TABLE [dbo].[CreditTypeMarginDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrgId] varchar(10)  NULL,
    [CreditTypeID] int  NULL,
    [Margin] decimal(4,2)  NULL,
    [CreditDays] int  NULL,
    [BranchID] varchar(10)  NULL,
    [CityID] int  NULL,
    [IsActive] bit  NULL,
    [FrmEffectiveDate] datetime  NULL,
    [FrmEffectiveTime] nvarchar(10)  NULL,
    [ToEffectiveDate] datetime  NULL,
    [ToEffectiveTime] nvarchar(10)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedById] int  NULL
);
GO

-- Creating table 'CreditTypes'
CREATE TABLE [dbo].[CreditTypes] (
    [CreditTypeID] int IDENTITY(1,1) NOT NULL,
    [CreditTypeName] nvarchar(50)  NULL,
    [OrgId] varchar(10)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedById] int  NULL
);
GO

-- Creating table 'CurrencyDenominationTypes'
CREATE TABLE [dbo].[CurrencyDenominationTypes] (
    [DenominationID] int IDENTITY(1,1) NOT NULL,
    [Denomination] decimal(18,0)  NULL,
    [CreatedByID] int  NULL,
    [CreatedDatetime] datetime  NULL,
    [UpdatedByID] int  NULL,
    [UpdatedDatetime] datetime  NULL
);
GO

-- Creating table 'DCQtyAllocationItemWarehouseMaps'
CREATE TABLE [dbo].[DCQtyAllocationItemWarehouseMaps] (
    [DCItemMapID] int IDENTITY(1,1) NOT NULL,
    [ID] int  NULL,
    [DCNo] nvarchar(50)  NOT NULL,
    [RequisitionNumber] nvarchar(20)  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [WarehouseID] int  NOT NULL,
    [BatchID] int  NULL,
    [TotalQuantity] decimal(18,2)  NULL,
    [QuantityOrdered] decimal(18,2)  NULL,
    [IsNegativeStock] bit  NULL,
    [IsFIFOSkipped] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'DCQuantityAllocations'
CREATE TABLE [dbo].[DCQuantityAllocations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DCNo] nvarchar(50)  NULL,
    [RequisitionNumber] nvarchar(20)  NOT NULL,
    [ItemDetailsReqNumber] int  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [AllocatedQuantity] decimal(18,2)  NOT NULL,
    [Rate] decimal(18,2)  NOT NULL,
    [DeliveryDate] datetime  NOT NULL,
    [Status] nvarchar(150)  NULL,
    [CreatedID] int  NOT NULL,
    [CreationDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [BranchID] varchar(10)  NULL,
    [Remarks] nvarchar(250)  NULL,
    [Value] decimal(18,2)  NULL
);
GO

-- Creating table 'DeliverycenterBranchMaps'
CREATE TABLE [dbo].[DeliverycenterBranchMaps] (
    [DeliverycenterBranchMapID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NOT NULL,
    [BranchID] varchar(10)  NULL,
    [DelivercenterID] int  NOT NULL,
    [IsActive] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [UpdatedByID] int  NULL,
    [UpdatedDatetime] datetime  NULL
);
GO

-- Creating table 'DenominationMapWithTrans'
CREATE TABLE [dbo].[DenominationMapWithTrans] (
    [DenominationMapID] uniqueidentifier  NOT NULL,
    [DenominationID] int  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [TransactionID] uniqueidentifier  NULL,
    [TransactionType] nvarchar(5)  NULL,
    [Value] int  NULL,
    [DenominationAmount] decimal(18,0)  NULL,
    [CreatedByID] int  NULL,
    [CreatedDatetime] datetime  NULL,
    [UpdatedByID] int  NULL,
    [UpdatedDatetime] datetime  NULL,
    [PayOrRcpID] nvarchar(50)  NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [DeptID] int IDENTITY(1,1) NOT NULL,
    [DepartmentName] nvarchar(100)  NOT NULL,
    [IsEditable] bit  NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [CreatedById] int  NOT NULL,
    [CreatedDatetTime] datetime  NULL,
    [ModifiedByID] int  NULL,
    [ModifiedDateTime] datetime  NULL
);
GO

-- Creating table 'DiscountsExpenseDetails'
CREATE TABLE [dbo].[DiscountsExpenseDetails] (
    [PurDiscId] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [CategoryID] int  NULL,
    [SubCategoryID] int  NULL,
    [ItemCode] nvarchar(25)  NULL,
    [Unit] nvarchar(10)  NULL,
    [Discount] decimal(18,2)  NULL,
    [BranchID] varchar(10)  NULL,
    [CityID] int  NULL,
    [CreatedById] int  NULL,
    [CreatedDateTime] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'DiscrepencyDetails'
CREATE TABLE [dbo].[DiscrepencyDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrderNumber] nvarchar(15)  NULL,
    [ItemCode] nvarchar(25)  NULL,
    [WarehouseID] int  NULL,
    [Quantity] decimal(18,2)  NOT NULL,
    [ReasonForDiscrepency] int  NOT NULL,
    [BatchID] int  NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [SourceOfUpdate] nvarchar(2)  NULL,
    [PurchaseOrSales] nchar(2)  NULL,
    [CreationDate] datetime  NOT NULL,
    [CreationID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [Modifieddate] datetime  NULL,
    [IsTallyUpdated] bit  NOT NULL
);
GO

-- Creating table 'DocumentsLists'
CREATE TABLE [dbo].[DocumentsLists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocumentType] nvarchar(100)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'DocumentsSettings'
CREATE TABLE [dbo].[DocumentsSettings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DocumentID] int  NULL,
    [OrgID] varchar(10)  NULL,
    [IsMandatory] bit  NULL,
    [IsGPRecord] bit  NULL,
    [IsGINRecord] bit  NULL,
    [CreationDate] datetime  NULL,
    [CreatedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL
);
GO

-- Creating table 'DocumentUploads'
CREATE TABLE [dbo].[DocumentUploads] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GINID] nvarchar(15)  NULL,
    [GPNumber] nvarchar(15)  NULL,
    [DocumentType] nvarchar(100)  NOT NULL,
    [DocumentNumber] nvarchar(50)  NULL,
    [ScreenName] nchar(2)  NULL,
    [OrgID] varchar(10)  NULL,
    [Ordernumber] nvarchar(15)  NOT NULL,
    [PartyID] varchar(15)  NULL,
    [ConvertedFile] varchar(max)  NOT NULL,
    [FileExtension] nvarchar(10)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [Modifieddate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'FranchiseMarginDetails'
CREATE TABLE [dbo].[FranchiseMarginDetails] (
    [FranchiseID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [CategoryID] int  NULL,
    [SubCategoryID] int  NULL,
    [ItemCode] nvarchar(25)  NULL,
    [Unit] nvarchar(10)  NULL,
    [Margin] decimal(18,2)  NULL,
    [BranchID] varchar(10)  NULL,
    [CityID] int  NULL,
    [CreatedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'FreightExpenseDetails'
CREATE TABLE [dbo].[FreightExpenseDetails] (
    [FreightRateId] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [CategoryID] int  NULL,
    [SubCategoryID] int  NULL,
    [ItemCode] nvarchar(25)  NULL,
    [Unit] nvarchar(10)  NULL,
    [Value] decimal(18,2)  NULL,
    [BranchID] varchar(10)  NULL,
    [CityID] int  NULL,
    [CreatedById] int  NULL,
    [CreatedDateTime] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'FumigationDetails'
CREATE TABLE [dbo].[FumigationDetails] (
    [FuminID] int IDENTITY(1,1) NOT NULL,
    [FuminVchrNum] nvarchar(20)  NULL,
    [FuminDate] datetime  NULL,
    [FuminStartDate] datetime  NULL,
    [FuminEndDate] datetime  NULL,
    [FuminStatus] nvarchar(50)  NULL,
    [FuminPartyOrSupp] int  NULL,
    [FuminPartyOrSuppID] nvarchar(20)  NULL,
    [FuminPartyInHouseName] nvarchar(100)  NULL,
    [FuminCustomer] nvarchar(50)  NULL,
    [FuminInhouseCust] nvarchar(80)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [TotalQty] int  NULL,
    [TotalValue] decimal(18,2)  NULL,
    [ImageCertificate] varbinary(max)  NULL
);
GO

-- Creating table 'FumigationItemWrhsDetails'
CREATE TABLE [dbo].[FumigationItemWrhsDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FuminID] int  NULL,
    [ItemCode] nvarchar(25)  NULL,
    [WarehouseID] int  NULL,
    [BatchID] int  NULL,
    [FuminQty] int  NULL,
    [FuminRate] decimal(5,2)  NULL,
    [FuminStartDate] datetime  NULL,
    [FuminEndDate] datetime  NULL,
    [FuminStatus] nvarchar(50)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'FuturisticBusinessTypes'
CREATE TABLE [dbo].[FuturisticBusinessTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [BTMarginsID] int  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [BusinessTypeID] int  NULL,
    [Margin] decimal(4,2)  NULL,
    [NextMargin] decimal(4,2)  NULL,
    [BranchID] varchar(10)  NULL,
    [CityID] int  NULL,
    [FrmEffectiveDate] datetime  NULL,
    [FrmEffectiveTime] nvarchar(10)  NULL,
    [ToEffectiveDate] datetime  NULL,
    [ToEffectiveTime] nvarchar(10)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedByID] int  NULL
);
GO

-- Creating table 'FuturisticCreditTypes'
CREATE TABLE [dbo].[FuturisticCreditTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [CreditTypeID] int  NULL,
    [Margin] decimal(4,2)  NULL,
    [NextMargin] decimal(4,2)  NULL,
    [CreditDays] int  NULL,
    [BranchID] varchar(10)  NULL,
    [CityID] int  NULL,
    [FrmEffectiveDate] datetime  NULL,
    [FrmEffectiveTime] nvarchar(10)  NULL,
    [ToEffectiveDate] datetime  NULL,
    [ToEffectiveTime] nvarchar(10)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedByID] int  NULL
);
GO

-- Creating table 'FuturisticItemThresholdQties'
CREATE TABLE [dbo].[FuturisticItemThresholdQties] (
    [FID] int IDENTITY(1,1) NOT NULL,
    [OrgId] varchar(50)  NOT NULL,
    [BranchID] varchar(50)  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [BusinessTypeID] int  NOT NULL,
    [MinQty] int  NOT NULL,
    [MaxQty] int  NOT NULL,
    [MinQtyAfterPeriod] int  NULL,
    [MaxQtyAfterPeriod] int  NOT NULL,
    [FrmEffectiveDate] datetime  NOT NULL,
    [FrmEffectiveTime] nvarchar(10)  NOT NULL,
    [ToEffectiveDate] datetime  NOT NULL,
    [ToEffectiveTime] nvarchar(10)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'ItemThresholdQtyDetails'
CREATE TABLE [dbo].[ItemThresholdQtyDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrgId] varchar(50)  NULL,
    [BranchID] varchar(10)  NULL,
    [ItemCode] nvarchar(25)  NULL,
    [BusinessTypeID] int  NULL,
    [MaxQty] int  NULL,
    [MinQty] int  NULL,
    [CreationDate] datetime  NULL,
    [CreatedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL
);
GO

-- Creating table 'LedgersOpeningBalances'
CREATE TABLE [dbo].[LedgersOpeningBalances] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TransactionDate] datetime  NULL,
    [BillNumber] nvarchar(50)  NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [LedgerID] nvarchar(50)  NULL,
    [UnderLedgerType] nvarchar(50)  NULL,
    [DrPendingAmt] decimal(18,2)  NULL,
    [CrPendingAmt] decimal(18,2)  NULL,
    [Status] nvarchar(50)  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'OfferPriceDetails'
CREATE TABLE [dbo].[OfferPriceDetails] (
    [OffersID] int IDENTITY(1,1) NOT NULL,
    [TransID] int  NULL,
    [RateID] int  NULL,
    [OrgID] varchar(10)  NULL,
    [OfferRate] decimal(18,2)  NULL,
    [RateAfterOffer] decimal(18,2)  NULL,
    [FrmEffectiveDate] datetime  NULL,
    [FrmEffectiveTime] nvarchar(10)  NULL,
    [ToEffectiveDate] datetime  NULL,
    [ToEffectiveTime] nvarchar(10)  NULL,
    [Image] nvarchar(500)  NULL,
    [CreatedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'RateTransactionDetails'
CREATE TABLE [dbo].[RateTransactionDetails] (
    [TransID] int IDENTITY(1,1) NOT NULL,
    [RateID] int  NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [Rate] decimal(18,2)  NULL,
    [FrmEffectiveDate] datetime  NULL,
    [FrmEffectiveTime] nvarchar(10)  NULL,
    [ToEffectiveDate] datetime  NULL,
    [ToEffectiveTime] nvarchar(10)  NULL,
    [CreatedById] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'SalesManAreaMappingChilds'
CREATE TABLE [dbo].[SalesManAreaMappingChilds] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SalesManID] int  NULL,
    [AreaID] int  NULL,
    [Value] bit  NULL,
    [Pincode] int  NULL
);
GO

-- Creating table 'SalesManAreaMappingParents'
CREATE TABLE [dbo].[SalesManAreaMappingParents] (
    [ID] int  NULL,
    [SalesManID] int  NOT NULL,
    [StateID] int  NULL,
    [DistrictID] int  NULL,
    [CityID] int  NULL,
    [CreationDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [CreatedByID] int  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblAccessRights'
CREATE TABLE [dbo].[tblAccessRights] (
    [AccessRightsID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [CreatedByID] int  NOT NULL,
    [SubMenuID] int  NOT NULL,
    [SourceOfUpdate] char(1)  NULL,
    [Activity] nvarchar(20)  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblAccountContraBillWithDetails'
CREATE TABLE [dbo].[tblAccountContraBillWithDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ContraWithBillID] uniqueidentifier  NOT NULL,
    [ContraID] nvarchar(20)  NOT NULL,
    [CustID] varchar(15)  NULL,
    [OutstandingAmt] nvarchar(25)  NULL,
    [OrgID] varchar(10)  NULL,
    [TransactionType] nvarchar(10)  NULL,
    [BillType] nvarchar(100)  NULL,
    [Billdatetime] nvarchar(20)  NULL,
    [TallyAmount] decimal(18,2)  NULL,
    [Discountamount] decimal(18,2)  NULL,
    [CreditAmount] decimal(18,2)  NULL,
    [DebitAmount] decimal(18,2)  NULL,
    [Billamount] decimal(18,2)  NULL,
    [IsTallyUpdated] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [BankName] nvarchar(50)  NULL,
    [BranchName] nvarchar(100)  NULL,
    [IFSC] nvarchar(50)  NULL,
    [AccountNumber] nvarchar(50)  NULL,
    [TransactionNumber] nvarchar(20)  NULL,
    [CheckDate] datetime  NULL,
    [BankOrCash] char(1)  NULL
);
GO

-- Creating table 'tblAccountContraDetails'
CREATE TABLE [dbo].[tblAccountContraDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ContraID] nvarchar(20)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [ContraDatetime] datetime  NULL,
    [LedgerID] nvarchar(20)  NULL,
    [ContraType] nvarchar(50)  NULL,
    [BankOrCash] char(1)  NULL,
    [CrditAmount] decimal(18,2)  NULL,
    [DebitAmount] decimal(18,2)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL,
    [Amount] decimal(18,2)  NULL,
    [SalesManID] nvarchar(20)  NULL,
    [BankName] nvarchar(50)  NULL,
    [BranchName] nvarchar(100)  NULL,
    [IFSC] nvarchar(50)  NULL,
    [AccountNumber] nvarchar(50)  NULL,
    [TransactionNumber] nvarchar(20)  NULL,
    [CheckDate] datetime  NULL,
    [Status] nvarchar(50)  NULL,
    [SignatureImage] varchar(max)  NULL,
    [Comments] nvarchar(500)  NULL,
    [IsTallyUpdated] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CustLocation] nvarchar(500)  NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'tblAccountCreditNoteDetails'
CREATE TABLE [dbo].[tblAccountCreditNoteDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CreditNoteID] nvarchar(20)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [CreditNoteDatetime] datetime  NULL,
    [CreditNoteType] nvarchar(50)  NULL,
    [OriginalInvoiceNo] nvarchar(20)  NULL,
    [OriginalInvoiceDate] datetime  NULL,
    [BankOrCash] char(1)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL,
    [Amount] decimal(18,2)  NULL,
    [Debit] decimal(18,2)  NULL,
    [Credit] decimal(18,2)  NULL,
    [SalesManID] nvarchar(20)  NULL,
    [BankName] nvarchar(50)  NULL,
    [BranchName] nvarchar(100)  NULL,
    [IFSC] nvarchar(50)  NULL,
    [AccountNumber] nvarchar(50)  NULL,
    [TransactionNumber] nvarchar(20)  NULL,
    [CheckDate] datetime  NULL,
    [Status] nvarchar(50)  NULL,
    [SignatureImage] varchar(max)  NULL,
    [Comments] nvarchar(500)  NULL,
    [IsTallyUpdated] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CustLocation] nvarchar(500)  NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [IGST] decimal(18,2)  NULL,
    [CGST] decimal(18,2)  NULL,
    [SGST] decimal(18,2)  NULL
);
GO

-- Creating table 'tblAccountCreditNoteItemDetails'
CREATE TABLE [dbo].[tblAccountCreditNoteItemDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CreditNoteID] nvarchar(20)  NOT NULL,
    [CreditNoteWithID] uniqueidentifier  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [DeliveredQTY] decimal(18,0)  NULL,
    [ReturnQTY] decimal(18,0)  NULL,
    [Rate] decimal(18,0)  NULL,
    [Value] decimal(18,0)  NULL,
    [InvoiceNo] varchar(20)  NULL,
    [VoucherTypeNo] varchar(20)  NULL,
    [OrgID] varchar(10)  NULL,
    [WarehouseID] int  NOT NULL,
    [Comments] varchar(500)  NULL,
    [IsTallyUpdated] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [SourceOfUpdate] varchar(1)  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ReasonID] int  NULL,
    [ModifiedByID] int  NULL,
    [BatchID] int  NULL,
    [Discount] decimal(18,2)  NULL,
    [DiscountAmount] decimal(18,2)  NULL,
    [Tax] decimal(18,2)  NULL,
    [TaxValue] decimal(18,2)  NULL,
    [NetValue] decimal(18,2)  NULL,
    [GST] decimal(18,2)  NULL
);
GO

-- Creating table 'tblAccountCreditNoteWithBillDetails'
CREATE TABLE [dbo].[tblAccountCreditNoteWithBillDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CreditNoteWithBillID] uniqueidentifier  NOT NULL,
    [CreditNoteID] nvarchar(20)  NOT NULL,
    [LedgerID] varchar(20)  NULL,
    [CustID] nvarchar(50)  NULL,
    [OutstandingAmt] nvarchar(25)  NULL,
    [OrgID] varchar(10)  NULL,
    [BillType] nvarchar(100)  NULL,
    [BillNo] nvarchar(100)  NULL,
    [Billdatetime] nvarchar(20)  NULL,
    [TallyAmount] decimal(18,2)  NULL,
    [Discountamount] decimal(18,2)  NULL,
    [Billamount] decimal(18,2)  NULL,
    [Debit] decimal(18,2)  NULL,
    [Credit] decimal(18,2)  NULL,
    [IsTallyUpdated] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [ToLedgerID] varchar(20)  NULL
);
GO

-- Creating table 'tblAccountDebitNoteDetails'
CREATE TABLE [dbo].[tblAccountDebitNoteDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DebitNoteID] nvarchar(20)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [DebitNoteDatetime] datetime  NULL,
    [DebitNoteType] nvarchar(50)  NULL,
    [OriginalInvoiceNo] nvarchar(20)  NULL,
    [OriginalInvoiceDate] datetime  NULL,
    [BankOrCash] char(1)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL,
    [Amount] decimal(18,2)  NULL,
    [Debit] decimal(18,2)  NULL,
    [Credit] decimal(18,2)  NULL,
    [SalesManID] nvarchar(20)  NULL,
    [BankName] nvarchar(50)  NULL,
    [BranchName] nvarchar(100)  NULL,
    [IFSC] nvarchar(50)  NULL,
    [AccountNumber] nvarchar(50)  NULL,
    [TransactionNumber] nvarchar(20)  NULL,
    [CheckDate] datetime  NULL,
    [Status] nvarchar(50)  NULL,
    [SignatureImage] varchar(max)  NULL,
    [Comments] nvarchar(500)  NULL,
    [IsTallyUpdated] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CustLocation] nvarchar(500)  NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [IGST] decimal(18,2)  NULL,
    [CGST] decimal(18,2)  NULL,
    [SGST] decimal(18,2)  NULL
);
GO

-- Creating table 'tblAccountDebitNoteItemDetails'
CREATE TABLE [dbo].[tblAccountDebitNoteItemDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DebitNoteID] nvarchar(20)  NOT NULL,
    [DebitNoteWithID] uniqueidentifier  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [DeliveredQTY] decimal(18,0)  NULL,
    [ReturnQTY] decimal(18,0)  NULL,
    [Rate] decimal(18,0)  NULL,
    [Value] decimal(18,0)  NULL,
    [InvoiceNo] varchar(20)  NULL,
    [VoucherTypeNo] varchar(20)  NULL,
    [OrgID] varchar(10)  NULL,
    [WarehouseID] int  NOT NULL,
    [Comments] varchar(500)  NULL,
    [IsTallyUpdated] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [SourceOfUpdate] varchar(1)  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ReasonID] int  NULL,
    [ModifiedByID] int  NULL,
    [BatchID] int  NULL,
    [Discount] decimal(18,2)  NULL,
    [DiscountAmount] decimal(18,2)  NULL,
    [Tax] decimal(18,2)  NULL,
    [TaxValue] decimal(18,2)  NULL,
    [NetValue] decimal(18,2)  NULL,
    [GST] decimal(18,2)  NULL
);
GO

-- Creating table 'tblAccountDebitNoteWithBillDetails'
CREATE TABLE [dbo].[tblAccountDebitNoteWithBillDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DebitNoteWithBillID] uniqueidentifier  NOT NULL,
    [DebitNoteID] nvarchar(20)  NOT NULL,
    [LedgerID] varchar(20)  NULL,
    [CustID] nvarchar(50)  NULL,
    [OutstandingAmt] nvarchar(25)  NULL,
    [OrgID] varchar(10)  NULL,
    [BillType] nvarchar(100)  NULL,
    [BillNo] nvarchar(100)  NULL,
    [Billdatetime] nvarchar(20)  NULL,
    [TallyAmount] decimal(18,2)  NULL,
    [Discountamount] decimal(18,2)  NULL,
    [Billamount] decimal(18,2)  NULL,
    [Debit] decimal(18,2)  NULL,
    [Credit] decimal(18,2)  NULL,
    [IsTallyUpdated] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [ToLedgerID] varchar(20)  NULL
);
GO

-- Creating table 'tblAccountGroups'
CREATE TABLE [dbo].[tblAccountGroups] (
    [AccountGroup] int IDENTITY(1,1) NOT NULL,
    [AccountGroupMasterID] int  NOT NULL,
    [AccountName] nvarchar(150)  NOT NULL,
    [SaleOrPurchase] varchar(20)  NULL,
    [IsSubAccountGroup] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [IsTallyUpdated] bit  NULL
);
GO

-- Creating table 'tblAccountGroupMasters'
CREATE TABLE [dbo].[tblAccountGroupMasters] (
    [AccountGroupMasterID] int IDENTITY(1,1) NOT NULL,
    [AccountName] nvarchar(150)  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL
);
GO

-- Creating table 'tblAccountLedgers'
CREATE TABLE [dbo].[tblAccountLedgers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [LedgerID] nvarchar(20)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [LedgerName] nvarchar(100)  NOT NULL,
    [AccountGroupID] int  NULL,
    [SalesOrPurchase] nvarchar(50)  NULL,
    [IsEditable] bit  NULL,
    [CreatedByID] int  NULL,
    [ModifiedByID] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [IsTallyUpdated] bit  NULL,
    [TallyUpdatedDate] datetime  NULL,
    [TallyUpdatedByID] int  NULL
);
GO

-- Creating table 'tblAccountPaymentDetails'
CREATE TABLE [dbo].[tblAccountPaymentDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PaymentID] nvarchar(20)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [PaymentDatetime] datetime  NULL,
    [LedgerID] nvarchar(20)  NULL,
    [PaymentType] nvarchar(50)  NULL,
    [BankOrCash] char(1)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL,
    [Amount] decimal(18,2)  NULL,
    [SalesManID] nvarchar(20)  NULL,
    [BankName] nvarchar(50)  NULL,
    [BranchName] nvarchar(100)  NULL,
    [IFSC] nvarchar(50)  NULL,
    [AccountNumber] nvarchar(50)  NULL,
    [TransactionNumber] nvarchar(100)  NULL,
    [CheckDate] datetime  NULL,
    [Status] nvarchar(50)  NULL,
    [SignatureImage] varchar(max)  NULL,
    [Comments] nvarchar(500)  NULL,
    [IsTallyUpdated] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CustLocation] nvarchar(500)  NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'tblAccountPaymentWithBillDetails'
CREATE TABLE [dbo].[tblAccountPaymentWithBillDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PaymentWithBillID] uniqueidentifier  NOT NULL,
    [PaymentID] nvarchar(20)  NOT NULL,
    [CustID] varchar(15)  NULL,
    [OutstandingAmt] nvarchar(25)  NULL,
    [OrgID] varchar(10)  NULL,
    [BillType] nvarchar(100)  NULL,
    [BillNo] nvarchar(100)  NULL,
    [Billdatetime] nvarchar(20)  NULL,
    [TallyAmount] decimal(18,2)  NULL,
    [Discountamount] decimal(18,2)  NULL,
    [Billamount] decimal(18,2)  NULL,
    [IsTallyUpdated] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'tblAccountReceiptDetails'
CREATE TABLE [dbo].[tblAccountReceiptDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ReceiptID] nvarchar(20)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [ReceiptDatetime] datetime  NULL,
    [LedgerID] nvarchar(20)  NULL,
    [PaymentType] nvarchar(50)  NULL,
    [BankOrCash] char(1)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL,
    [Amount] decimal(18,2)  NULL,
    [Debit] decimal(18,2)  NULL,
    [Credit] decimal(18,2)  NULL,
    [SalesManID] nvarchar(20)  NULL,
    [BankName] nvarchar(50)  NULL,
    [BranchName] nvarchar(100)  NULL,
    [IFSC] nvarchar(50)  NULL,
    [AccountNumber] nvarchar(50)  NULL,
    [TransactionNumber] nvarchar(100)  NULL,
    [CheckDate] datetime  NULL,
    [Status] nvarchar(50)  NULL,
    [SignatureImage] varchar(max)  NULL,
    [Comments] nvarchar(500)  NULL,
    [IsTallyUpdates] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CustLocation] nvarchar(500)  NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [RecieverSignatureImage] varchar(max)  NULL,
    [ReferenceImage] varchar(max)  NULL,
    [TallySync] bit  NULL,
    [BranchID] varchar(100)  NULL,
    [RefValue] nvarchar(max)  NULL
);
GO

-- Creating table 'tblAccountReceiptWithBillDetails'
CREATE TABLE [dbo].[tblAccountReceiptWithBillDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ReceiptWithBillID] uniqueidentifier  NOT NULL,
    [ReceiptID] nvarchar(20)  NOT NULL,
    [CustID] varchar(15)  NULL,
    [OutstandingAmt] nvarchar(25)  NULL,
    [OrgID] varchar(10)  NULL,
    [BillType] nvarchar(100)  NULL,
    [BillNo] nvarchar(100)  NULL,
    [Billdatetime] nvarchar(20)  NULL,
    [TallyAmount] decimal(18,2)  NULL,
    [Discountamount] decimal(18,2)  NULL,
    [Billamount] decimal(18,2)  NULL,
    [Debit] decimal(18,2)  NULL,
    [Credit] decimal(18,2)  NULL,
    [IsTallyUpdated] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NULL,
    [ModifiedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [TallySync] bit  NULL,
    [Status] nvarchar(10)  NULL,
    [ParentVoucherName] char(3)  NULL,
    [OrgValueCr] decimal(18,2)  NULL
);
GO

-- Creating table 'tblActivities'
CREATE TABLE [dbo].[tblActivities] (
    [ActivityID] int IDENTITY(1,1) NOT NULL,
    [ActivityName] nvarchar(max)  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [IsChecked] bit  NOT NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblAdminConfigurations'
CREATE TABLE [dbo].[tblAdminConfigurations] (
    [AdminConfigurationID] int IDENTITY(1,1) NOT NULL,
    [AdminConfigName] nvarchar(max)  NOT NULL,
    [value] bit  NULL,
    [OrgID] varchar(10)  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblAreas'
CREATE TABLE [dbo].[tblAreas] (
    [ID] int  NULL,
    [CityID] int  NULL,
    [AreaID] int IDENTITY(1,1) NOT NULL,
    [AreaName] varchar(50)  NULL,
    [Pincode] int  NULL,
    [Value] bit  NULL
);
GO

-- Creating table 'tblBatches'
CREATE TABLE [dbo].[tblBatches] (
    [BatchID] int IDENTITY(1,1) NOT NULL,
    [BatchNumber] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(2)  NULL
);
GO

-- Creating table 'tblBrands'
CREATE TABLE [dbo].[tblBrands] (
    [BrandID] int IDENTITY(1,1) NOT NULL,
    [BrandName] nvarchar(max)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [ItemCompanyID] int  NULL,
    [IsTrademarkRegistered] bit  NULL,
    [IsActive] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblCarts'
CREATE TABLE [dbo].[tblCarts] (
    [CartID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedDate] datetime  NULL,
    [Quantity] decimal(18,0)  NULL,
    [TotalValue] decimal(18,0)  NULL,
    [CreatedByID] int  NULL,
    [UpdatedByID] int  NULL
);
GO

-- Creating table 'tblCartItems'
CREATE TABLE [dbo].[tblCartItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CartID] int  NOT NULL,
    [Itemcode] nvarchar(25)  NULL,
    [Quantity] int  NULL,
    [BagQty] nvarchar(50)  NULL,
    [Value] decimal(18,0)  NULL,
    [TotalValue] decimal(18,0)  NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedDate] datetime  NULL,
    [CreatedByID] int  NULL,
    [UpdatedByID] int  NULL
);
GO

-- Creating table 'tblCategories'
CREATE TABLE [dbo].[tblCategories] (
    [CategoryID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [AccOrInv] bit  NULL,
    [IsTallyUpdated] bit  NULL,
    [TallyUpdatedDate] datetime  NULL,
    [IsActive] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [ParentCatId] int  NULL
);
GO

-- Creating table 'tblCategoryTypes'
CREATE TABLE [dbo].[tblCategoryTypes] (
    [CategoryTypeID] int IDENTITY(1,1) NOT NULL,
    [CategoryType] varchar(50)  NULL
);
GO

-- Creating table 'tblChannelPartnerMappings'
CREATE TABLE [dbo].[tblChannelPartnerMappings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ChannelPartnerId] varchar(10)  NOT NULL,
    [ParentChannelPartnerId] varchar(10)  NOT NULL,
    [CreatedDate] datetime  NULL,
    [CreateddBy] int  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] int  NULL,
    [OrgID] varchar(10)  NULL
);
GO

-- Creating table 'tblCities'
CREATE TABLE [dbo].[tblCities] (
    [CityID] int IDENTITY(1,1) NOT NULL,
    [ID] int  NULL,
    [DistrictID] int  NULL,
    [CityName] varchar(50)  NULL
);
GO

-- Creating table 'tblCompanyTypes'
CREATE TABLE [dbo].[tblCompanyTypes] (
    [CompanyTypeID] int IDENTITY(1,1) NOT NULL,
    [CompanyType] varchar(500)  NULL
);
GO

-- Creating table 'tblCountries'
CREATE TABLE [dbo].[tblCountries] (
    [ID] int  NOT NULL,
    [CountryID] int IDENTITY(1,1) NOT NULL,
    [CountryName] varchar(500)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedByID] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblCustomerCreditDetails'
CREATE TABLE [dbo].[tblCustomerCreditDetails] (
    [CustomerCreditDetailID] int IDENTITY(1,1) NOT NULL,
    [CustID] varchar(15)  NOT NULL,
    [CrLimit] nvarchar(50)  NULL,
    [CrDays] nvarchar(50)  NULL,
    [NoofOutstandingBill] int  NULL,
    [CreationDate] datetime  NULL,
    [CreatedByID] int  NOT NULL
);
GO

-- Creating table 'tblCustomerTypes'
CREATE TABLE [dbo].[tblCustomerTypes] (
    [CustomerTypeID] int IDENTITY(1,1) NOT NULL,
    [CustomerType] varchar(500)  NULL
);
GO

-- Creating table 'tblCustomerVendorDetails'
CREATE TABLE [dbo].[tblCustomerVendorDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CustID] varchar(15)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [OldTallyFirmName] nvarchar(250)  NULL,
    [FirmName] nvarchar(500)  NULL,
    [ContactpersonName] nvarchar(255)  NULL,
    [OwnerName] nvarchar(250)  NULL,
    [RegistrationType] nvarchar(255)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [TallyUpdatedDate] datetime  NULL,
    [CrLimit] nvarchar(255)  NULL,
    [CrDays] nvarchar(255)  NULL,
    [NoofOutstandingBill] int  NULL,
    [DistrictID] int  NULL,
    [ShippingAddress] nvarchar(1000)  NULL,
    [ShippingLandMark] nvarchar(1000)  NULL,
    [ShippingGPSLocation] varchar(max)  NULL,
    [ShippingState] nvarchar(255)  NULL,
    [ShippingArea] nvarchar(255)  NULL,
    [ShippingCity] nvarchar(255)  NULL,
    [ShippingCityCode] nvarchar(255)  NULL,
    [ShippingPincode] nvarchar(255)  NULL,
    [ShippingLatitude] nvarchar(255)  NULL,
    [ShippingLongitude] nvarchar(255)  NULL,
    [BillingAddress] nvarchar(1000)  NULL,
    [BillingLandmark] nvarchar(1000)  NULL,
    [BillingGPSLocation] varchar(max)  NULL,
    [BillingPincode] nvarchar(255)  NULL,
    [BillingLatitude] nvarchar(255)  NULL,
    [BillingLongitude] nvarchar(255)  NULL,
    [BillingState] nvarchar(255)  NULL,
    [BillingCity] nvarchar(255)  NULL,
    [BillingCityCode] nvarchar(255)  NULL,
    [BillingArea] nvarchar(255)  NULL,
    [PostDatedTransaction] bit  NULL,
    [ActivateIntrest] bit  NULL,
    [OpeningBalance] nvarchar(255)  NULL,
    [OpeningBalType] nchar(3)  NULL,
    [LedgerName] nvarchar(255)  NULL,
    [LedgerType] nvarchar(50)  NULL,
    [TelephoneNumber] nvarchar(255)  NULL,
    [MobileNumber] nvarchar(255)  NULL,
    [AlternateNumber] nchar(255)  NULL,
    [TINNumber] nvarchar(50)  NULL,
    [PANNumber] nvarchar(255)  NULL,
    [EmailID] nvarchar(255)  NULL,
    [IsRemoved] char(1)  NULL,
    [IsVendor] bit  NULL,
    [CompanyType] nvarchar(255)  NULL,
    [SalesManID] int  NULL,
    [ApprovalStatus] nvarchar(50)  NULL,
    [BankName] nvarchar(255)  NULL,
    [BankBranch] nvarchar(255)  NULL,
    [BankCity] nvarchar(255)  NULL,
    [AccountNumber] nvarchar(255)  NULL,
    [IFSCCode] nvarchar(255)  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [InsuranceCompany] nvarchar(255)  NULL,
    [InsuranceNumber] nvarchar(255)  NULL,
    [InsuranceExpiryDate] datetime  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [Parent4] nvarchar(500)  NULL,
    [Parent3] nvarchar(500)  NULL,
    [Parent2] nvarchar(500)  NULL,
    [Parent1] nvarchar(500)  NULL,
    [AliasName] varchar(500)  NULL,
    [Address3] nvarchar(1000)  NULL,
    [Country] nvarchar(255)  NULL,
    [ContactpersonPhone] nvarchar(255)  NULL,
    [FaxNo] nvarchar(255)  NULL,
    [CCEmail] nvarchar(255)  NULL,
    [Website] nvarchar(255)  NULL,
    [Description] nvarchar(255)  NULL,
    [Narration] nvarchar(255)  NULL,
    [BillWiseYesNo] nvarchar(255)  NULL,
    [Checkforcreditdaysduringvoucherentry] nvarchar(255)  NULL,
    [OverrideCreditlimit] nvarchar(255)  NULL,
    [Inventoryvaluesareaffected] nvarchar(255)  NULL,
    [ActivateInterestCalculation] nvarchar(255)  NULL,
    [CalculateInterestTransaction_by_Transaction] nvarchar(255)  NULL,
    [OverrideParametersforeachtransaction] nvarchar(255)  NULL,
    [IntrestRate] nvarchar(255)  NULL,
    [InterestDays] nvarchar(255)  NULL,
    [GSTPhoto] nvarchar(500)  NULL,
    [PANPhoto] nvarchar(500)  NULL,
    [ShopImage] nvarchar(500)  NULL,
    [Religion] varchar(500)  NULL,
    [OwnerPhoto] varchar(500)  NULL,
    [AadhaarNumber] nvarchar(255)  NULL,
    [AadhaarPhoto] varchar(500)  NULL,
    [ParentDebtorID] int  NULL,
    [StateID] int  NULL,
    [CityID] int  NULL,
    [CustomerType] int  NULL,
    [CreditType] int  NULL,
    [TypeofCategory] varchar(10)  NULL,
    [WeekOffDay] varchar(500)  NULL,
    [WatsAppNumber] nvarchar(255)  NULL,
    [PercStrctureID] int  NULL,
    [LedgerTypeID] int  NULL,
    [CustomerTypeID] int  NULL,
    [CompanyTypeID] int  NULL,
    [CategoryTypeID] int  NULL,
    [TaxationTypeID] int  NULL,
    [CountryID] int  NULL,
    [Cityname] varchar(500)  NULL,
    [TallySync] bit  NULL,
    [DCUniqueID] uniqueidentifier  NULL,
    [MailingName] nvarchar(250)  NULL
);
GO

-- Creating table 'tblDebtorsAreaDetails'
CREATE TABLE [dbo].[tblDebtorsAreaDetails] (
    [AreaID] int  NOT NULL,
    [Area] nvarchar(250)  NOT NULL,
    [PlaceID] nvarchar(50)  NOT NULL,
    [SundryDebtors] nvarchar(50)  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblDebtorsDetails'
CREATE TABLE [dbo].[tblDebtorsDetails] (
    [ID] int  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [DebtorName] nvarchar(150)  NULL,
    [Description] nvarchar(550)  NULL,
    [ParentDebtorID] int  NULL,
    [CreationDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [CreatedByID] int  NULL,
    [ModifiedByID] int  NULL,
    [IsDefault] int  NULL,
    [OldDebtorName] varchar(150)  NULL,
    [IsTallyUpdated] bit  NULL,
    [BranchID] varchar(25)  NULL,
    [TallySync] bit  NULL
);
GO

-- Creating table 'tblDebtorsPlaceDetails'
CREATE TABLE [dbo].[tblDebtorsPlaceDetails] (
    [PlaceID] nvarchar(50)  NOT NULL,
    [PlaceCode] varchar(4)  NULL,
    [Place] nvarchar(50)  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblDeliveryNotes'
CREATE TABLE [dbo].[tblDeliveryNotes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DeliveryNoteCode] nvarchar(15)  NOT NULL,
    [GatePassCode] nvarchar(15)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [SalesOrderNumber] nvarchar(15)  NULL,
    [DeliveryNoteDate] datetime  NULL,
    [Status] nvarchar(200)  NOT NULL,
    [LoadStartDateTime] datetime  NULL,
    [LoadEndDateTime] datetime  NULL,
    [LoadingStatus] nvarchar(50)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [Remark] varchar(500)  NULL,
    [DNType] nvarchar(50)  NULL,
    [DNTypeNum] nvarchar(200)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL
);
GO

-- Creating table 'tblDeliveryNoteItems'
CREATE TABLE [dbo].[tblDeliveryNoteItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DeliveryNoteCode] nvarchar(15)  NOT NULL,
    [SalesOrderWithItemID] uniqueidentifier  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [Ordered] decimal(18,0)  NULL,
    [Delivered] decimal(18,0)  NULL,
    [OrgID] varchar(10)  NULL,
    [WarehouseID] int  NOT NULL,
    [BatchID] int  NOT NULL,
    [IsCorrectionRequired] int  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ReasonID] int  NULL,
    [ModifiedByID] int  NULL,
    [Remark] varchar(500)  NULL,
    [DNType] nvarchar(50)  NULL,
    [DNTypeNum] nvarchar(200)  NULL,
    [SalesOrderNumber] nvarchar(20)  NULL
);
GO

-- Creating table 'tblDepartments'
CREATE TABLE [dbo].[tblDepartments] (
    [DeptID] int IDENTITY(1,1) NOT NULL,
    [DepartmentName] nvarchar(100)  NOT NULL,
    [IsActive] bit  NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [CreatedById] int  NOT NULL,
    [CreatedDatetTime] datetime  NULL,
    [ModifiedByID] int  NULL,
    [ModifiedDateTime] datetime  NULL,
    [IsPredefined] bit  NULL
);
GO

-- Creating table 'tblDiscounts'
CREATE TABLE [dbo].[tblDiscounts] (
    [DiscountID] int IDENTITY(1,1) NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [IsDiscountInPercentage] bit  NOT NULL,
    [DiscountValue] decimal(18,2)  NOT NULL,
    [FromDateTime] datetime  NOT NULL,
    [ToDateTime] datetime  NOT NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblDistricts'
CREATE TABLE [dbo].[tblDistricts] (
    [ID] int  NULL,
    [StateID] int  NULL,
    [DistrictID] int IDENTITY(1,1) NOT NULL,
    [DistrictName] varchar(50)  NULL
);
GO

-- Creating table 'tblGatePasses'
CREATE TABLE [dbo].[tblGatePasses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GatePassCode] nvarchar(15)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [SalesOrderNumber] nvarchar(15)  NOT NULL,
    [VehicalNumber] nvarchar(15)  NOT NULL,
    [DriverName] nvarchar(200)  NOT NULL,
    [DriverNumber] nvarchar(15)  NOT NULL,
    [DriverLicenseNumber] nvarchar(18)  NULL,
    [TransporterName] nvarchar(100)  NULL,
    [Tareweight] decimal(18,2)  NULL,
    [LRNumber] nvarchar(50)  NULL,
    [GatePassDate] datetime  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [DriverPhone2] nvarchar(15)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SOType] nvarchar(50)  NULL,
    [SOTypeNum] nvarchar(200)  NULL,
    [Remarks] varchar(500)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL
);
GO

-- Creating table 'tblGatePassItems'
CREATE TABLE [dbo].[tblGatePassItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GatePassCode] nvarchar(15)  NOT NULL,
    [SalesOrderNumber] nvarchar(15)  NOT NULL,
    [SalesOrderWithItemID] uniqueidentifier  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [Ordered] decimal(18,0)  NOT NULL,
    [ToBeDeliveredQTY] decimal(18,0)  NOT NULL,
    [OrgID] varchar(10)  NOT NULL,
    [WarehouseID] int  NOT NULL,
    [BatchID] int  NOT NULL,
    [Priority] int  NOT NULL,
    [DeliveredQTY] decimal(18,0)  NULL,
    [Status] nvarchar(100)  NULL,
    [ReasonID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SOType] nvarchar(50)  NULL,
    [SOTypeNum] nvarchar(200)  NULL
);
GO

-- Creating table 'tblGoodsInwardNotes'
CREATE TABLE [dbo].[tblGoodsInwardNotes] (
    [GINID] nvarchar(15)  NOT NULL,
    [PurchaseOrderNumber] nvarchar(15)  NOT NULL,
    [SupplierId] varchar(15)  NOT NULL,
    [BranchId] varchar(10)  NULL,
    [OrgId] varchar(10)  NOT NULL,
    [VoucherTypeNo] nvarchar(20)  NULL,
    [InvoiceNumber] nvarchar(15)  NOT NULL,
    [GrossSupplierWeight] decimal(18,2)  NULL,
    [TareSupplierWeight] decimal(18,2)  NULL,
    [NetSupplierWeight] decimal(18,2)  NULL,
    [GrossInwardWeight] decimal(18,2)  NULL,
    [TareWeight] decimal(18,2)  NULL,
    [NetWeight] decimal(18,2)  NULL,
    [LRNumber] nvarchar(15)  NULL,
    [DriverName] nvarchar(200)  NULL,
    [DriverMobileNumber] nvarchar(15)  NULL,
    [DriverLicenseNumber] nvarchar(18)  NULL,
    [TransporterName] nvarchar(100)  NULL,
    [VehicleRegisterationNumber] nvarchar(15)  NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedById] int  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL,
    [Comments] nvarchar(250)  NULL,
    [Status] nchar(10)  NULL,
    [SourceOfUpdate] char(2)  NULL
);
GO

-- Creating table 'tblGoodsInwardNoteItems'
CREATE TABLE [dbo].[tblGoodsInwardNoteItems] (
    [GINItemId] int IDENTITY(1,1) NOT NULL,
    [GINID] nvarchar(15)  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [OrderedQTY] decimal(18,2)  NOT NULL,
    [OrderUnit] nvarchar(50)  NOT NULL,
    [RecievedQTYTillDate] decimal(18,2)  NOT NULL,
    [PendingQTY] decimal(18,2)  NOT NULL,
    [QTYTOBInwarded] decimal(18,2)  NULL,
    [BatchID] int  NULL,
    [WareHouseId] int  NULL,
    [UnloadingSequence] int  NULL,
    [QualityRemark] nvarchar(50)  NULL,
    [Remarks] nvarchar(50)  NULL,
    [CreatedById] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [BilledQty] decimal(18,2)  NULL,
    [Sizing] nvarchar(20)  NULL,
    [Note] nvarchar(50)  NULL,
    [InhouseBrand] nvarchar(50)  NULL,
    [Status] nchar(10)  NULL,
    [SourceOfUpdate] char(2)  NULL
);
GO

-- Creating table 'tblGRNs'
CREATE TABLE [dbo].[tblGRNs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GRNNumber] nvarchar(15)  NOT NULL,
    [PurchaseOrderNumber] nvarchar(15)  NOT NULL,
    [OrgId] varchar(10)  NOT NULL,
    [BranchId] varchar(10)  NULL,
    [InvoiceNumber] nvarchar(25)  NULL,
    [DeliveryNoteCode] nvarchar(15)  NULL,
    [CustID] varchar(15)  NOT NULL,
    [PurchaseOrderDate] datetime  NULL,
    [GRNDate] datetime  NULL,
    [VehicalNumber] nvarchar(15)  NOT NULL,
    [DriverName] nvarchar(200)  NULL,
    [DriverNumber] nvarchar(15)  NULL,
    [GrossWeight] decimal(18,2)  NULL,
    [NetWeight] decimal(18,2)  NULL,
    [TareWeight] decimal(18,2)  NULL,
    [FrieghtCharges] decimal(18,2)  NULL,
    [LoadingCharges] decimal(18,2)  NULL,
    [DeliveryType] varchar(10)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [SourceOfUpdate] char(2)  NULL,
    [CreatedByID] int  NULL,
    [CreationDate] datetime  NULL,
    [UpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [UnloadStartTime] datetime  NULL,
    [UnloadEndTime] datetime  NULL,
    [Status] nvarchar(20)  NULL,
    [VehicleComments] nvarchar(200)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL
);
GO

-- Creating table 'tblGRNItems'
CREATE TABLE [dbo].[tblGRNItems] (
    [GRNItemsID] int IDENTITY(1,1) NOT NULL,
    [GRNNumber] nvarchar(15)  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [WareHouseId] int  NOT NULL,
    [OrderedQuantity] decimal(18,2)  NOT NULL,
    [QuantityToBeInwarded] decimal(18,2)  NOT NULL,
    [DiscrepancyQty] decimal(18,2)  NULL,
    [RejectedQty] decimal(18,2)  NULL,
    [ReceivedQuantity] decimal(18,2)  NOT NULL,
    [ItemRemarks] nvarchar(250)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [Remarks] nvarchar(500)  NULL,
    [WaveOff] bit  NULL,
    [Status] nvarchar(200)  NULL,
    [ReasonID] int  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(2)  NULL
);
GO

-- Creating table 'tblHOBranchPriceDetails'
CREATE TABLE [dbo].[tblHOBranchPriceDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [HOBranchPriceDetailsID] int  NOT NULL,
    [BranchID] varchar(10)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [FreightCharges] decimal(18,2)  NULL,
    [Loading_Unloading] decimal(18,2)  NULL,
    [OtherExpenses] decimal(18,2)  NULL,
    [LandingPrice] decimal(18,2)  NULL,
    [BP1QtyLt] int  NOT NULL,
    [BP1_QtyGt] int  NOT NULL,
    [Margin1] decimal(18,2)  NOT NULL,
    [SellingPrice1] decimal(18,2)  NOT NULL,
    [BP2QtyLt] int  NOT NULL,
    [BP2QtyGt] int  NOT NULL,
    [Margin2] decimal(18,2)  NOT NULL,
    [SellingPrice2] decimal(18,2)  NOT NULL,
    [BP3QtyLt] int  NOT NULL,
    [BP3QtyGT] int  NOT NULL,
    [Margin3] decimal(18,2)  NOT NULL,
    [SellingPrice3] decimal(18,2)  NOT NULL,
    [FromDate] datetime  NULL,
    [ToDate] datetime  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblHOMasterPriceDetails'
CREATE TABLE [dbo].[tblHOMasterPriceDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [HOMasterPriceDetailsID] int  NOT NULL,
    [CategoryID] int  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [RateID] int  NOT NULL,
    [FreightCharges] decimal(18,2)  NULL,
    [Loading_Unloading] decimal(18,2)  NULL,
    [OtherExpenses] decimal(18,2)  NULL,
    [LandingPrice] decimal(18,2)  NULL,
    [BP1QtyLt] int  NULL,
    [BP1QtyGt] int  NULL,
    [Margin1] decimal(18,2)  NULL,
    [SellingPrice1] decimal(18,2)  NULL,
    [BP2QtyLt] int  NULL,
    [BP2QtyGt] int  NULL,
    [Margin2] decimal(18,2)  NULL,
    [SellingPrice2] decimal(18,2)  NULL,
    [BP3QtyLt] int  NULL,
    [BP3QtyGt] int  NULL,
    [Margin3] decimal(18,2)  NULL,
    [SellingPrice3] decimal(18,2)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblHSNCodes'
CREATE TABLE [dbo].[tblHSNCodes] (
    [HSNID] int IDENTITY(1,1) NOT NULL,
    [HSNCode] int  NOT NULL,
    [HSNSubCode] int  NULL,
    [Description] nvarchar(max)  NULL,
    [IsTrademarkRegistered] bit  NULL,
    [GST] int  NOT NULL,
    [IsActive] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblItems'
CREATE TABLE [dbo].[tblItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [Barcode] nvarchar(25)  NULL,
    [TallyItemName] nvarchar(max)  NULL,
    [OldItemName] nvarchar(max)  NULL,
    [ItemName] nvarchar(max)  NOT NULL,
    [Alias] nchar(10)  NULL,
    [OrgID] varchar(10)  NULL,
    [RateID] int  NULL,
    [BaseUnit] int  NULL,
    [BasePKTValue] decimal(7,2)  NULL,
    [AlternateUnit] int  NULL,
    [AlternatePKTValue] decimal(7,2)  NULL,
    [PacketUOMID] int  NULL,
    [PacketQTY] decimal(18,0)  NULL,
    [BagUOMID] int  NULL,
    [BagQTY] decimal(18,0)  NULL,
    [IsTallyUpdated] bit  NULL,
    [IsParentTallyUpdated] bit  NULL,
    [IsCESSMapped] bit  NULL,
    [CESSValue] decimal(18,2)  NULL,
    [CESSEffectiveDate] datetime  NULL,
    [BrandID] int  NOT NULL,
    [CategoryID] int  NOT NULL,
    [SubCategoryID] int  NOT NULL,
    [RackID] int  NULL,
    [ItemDetail] nvarchar(max)  NULL,
    [StorageArea] nvarchar(250)  NULL,
    [AllowNegativeStock] bit  NULL,
    [IsItemBlocked] bit  NULL,
    [GST] decimal(18,2)  NOT NULL,
    [GSTEffectiveDate] datetime  NULL,
    [IGST] nvarchar(30)  NULL,
    [CGST] nvarchar(30)  NULL,
    [SGST] nvarchar(30)  NULL,
    [ReOrderlevel] int  NULL,
    [ReOrderQTY] int  NULL,
    [IsReturnable] bit  NULL,
    [IsTrademarkRegistered] bit  NULL,
    [PreDefinedBarCode] varchar(max)  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [IsActive] bit  NULL,
    [DaysToRefill] int  NULL,
    [HSNCode] int  NULL,
    [HSNSubCode] int  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [isProcessItem] bit  NULL
);
GO

-- Creating table 'tblItemCompanies'
CREATE TABLE [dbo].[tblItemCompanies] (
    [ItemCompanyID] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblItemImageDetails'
CREATE TABLE [dbo].[tblItemImageDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ImageID] nvarchar(100)  NULL,
    [ItemCode] nvarchar(25)  NULL,
    [ImageFileName] nvarchar(75)  NULL,
    [ImageText] varchar(max)  NULL,
    [ImageType] nchar(10)  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblItemMappings'
CREATE TABLE [dbo].[tblItemMappings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ItemMappingID] int  NOT NULL,
    [ItemCode] nvarchar(25)  NULL,
    [OrgID] varchar(10)  NULL,
    [COrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [RateID] int  NULL,
    [GST] decimal(18,2)  NULL,
    [GSTEffectiveDate] datetime  NULL,
    [CESSValue] decimal(18,2)  NULL,
    [CESSEffectiveDate] datetime  NULL,
    [ReOrderlevel] int  NULL,
    [ReOrderQTY] int  NULL,
    [IsReturnable] bit  NULL,
    [DaysToRefill] int  NULL,
    [IsItemBlocked] bit  NULL,
    [IsActive] bit  NULL,
    [IsTallyUpdated] bit  NULL,
    [TallyUpdatedDate] datetime  NULL,
    [TallyUpdatedByID] int  NULL,
    [CreatedByID] int  NULL,
    [CreatedDatetime] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblItemMappingWithCESSes'
CREATE TABLE [dbo].[tblItemMappingWithCESSes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ItemMapCESSID] int  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [IsItemCESSMapped] bit  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblItemMovements'
CREATE TABLE [dbo].[tblItemMovements] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [TransactionType] nvarchar(25)  NOT NULL,
    [SalesOrderNumber] nvarchar(15)  NULL,
    [SalesOrderWithItemID] uniqueidentifier  NULL,
    [SaleQty] int  NULL,
    [DeliveredQty] int  NULL,
    [PendingQty] int  NULL,
    [NegativeQty] int  NULL,
    [ReceivedQty] int  NULL,
    [BatchID] int  NULL,
    [WarehouseID] int  NULL,
    [OrgID] varchar(10)  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblItemParameterMaps'
CREATE TABLE [dbo].[tblItemParameterMaps] (
    [ItemParameterMapID] int IDENTITY(1,1) NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [ParameterID] int  NOT NULL,
    [Comment] nvarchar(250)  NULL,
    [IsActive] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblItemRates'
CREATE TABLE [dbo].[tblItemRates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RateID] int  NOT NULL,
    [BaseRateOther] decimal(18,2)  NULL,
    [IsOfferRate] bit  NULL,
    [PerUnitRate] int  NULL,
    [ItemQTY1] int  NULL,
    [ItemQTY2] int  NULL,
    [MRP] decimal(18,2)  NULL,
    [MRPPercentage] int  NULL,
    [DistributorPrice] decimal(18,2)  NULL,
    [DistributorPercentage] int  NULL,
    [RetailerPrice] decimal(18,2)  NULL,
    [RetailerPercentage] int  NULL,
    [SuperStockist] decimal(18,2)  NULL,
    [SuperStockistPercentage] int  NULL,
    [DiscountFrom] decimal(18,2)  NULL,
    [DiscountTo] decimal(18,2)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblItemStockTransferDestinations'
CREATE TABLE [dbo].[tblItemStockTransferDestinations] (
    [ItemStockTransferDestinationID] int IDENTITY(1,1) NOT NULL,
    [ItemStockTransferSourceID] int  NULL,
    [BT_Num] varchar(100)  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [Quantity] decimal(18,2)  NOT NULL,
    [Rate] decimal(18,2)  NULL,
    [Amount] decimal(18,2)  NULL,
    [IsTallyUpdated] bit  NULL,
    [DestinationBatchID] int  NULL,
    [WarehouseID] int  NULL,
    [ShorgateAccountStatus] nvarchar(250)  NULL,
    [Status] nvarchar(50)  NULL,
    [CategoryID] int  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL
);
GO

-- Creating table 'tblItemStockTransferHeaders'
CREATE TABLE [dbo].[tblItemStockTransferHeaders] (
    [ItemStockTransferHeaderID] int IDENTITY(1,1) NOT NULL,
    [ItemStockTransferCode] nvarchar(15)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblItemStockTransferSources'
CREATE TABLE [dbo].[tblItemStockTransferSources] (
    [ItemStockTransferSourceID] int IDENTITY(1,1) NOT NULL,
    [ItemStockTransferHeaderID] int  NULL,
    [BT_Num] varchar(100)  NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [RequiredQuantity] decimal(18,2)  NULL,
    [BatchID] int  NULL,
    [Rate] decimal(18,2)  NULL,
    [Amount] decimal(18,2)  NULL,
    [IsTallyUpdated] bit  NULL,
    [Status] nvarchar(50)  NULL,
    [IsFIFOSkipped] bit  NOT NULL,
    [WarehouseID] int  NOT NULL,
    [QtyTransfered] decimal(18,2)  NULL,
    [ApprovalStatus] nvarchar(250)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL
);
GO

-- Creating table 'tblItemSupplierMappings'
CREATE TABLE [dbo].[tblItemSupplierMappings] (
    [ItemSupMappingID] int IDENTITY(1,1) NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [CustID] varchar(15)  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [IsMapped] bit  NULL,
    [ModifiedByID] int  NULL,
    [DelivercenterID] int  NULL,
    [Choice] nchar(2)  NULL,
    [VendorType] nvarchar(10)  NULL
);
GO

-- Creating table 'tblItemToItemTrackings'
CREATE TABLE [dbo].[tblItemToItemTrackings] (
    [ItemTrackingID] int IDENTITY(1,1) NOT NULL,
    [SourceItemCode] nvarchar(25)  NOT NULL,
    [SourceAvailbaleQty] decimal(18,2)  NOT NULL,
    [SourcePacketSize] nvarchar(50)  NULL,
    [SourceBagSize] nvarchar(50)  NULL,
    [SourceBatchID] int  NULL,
    [SourceWarehouseID] int  NULL,
    [SourceNetQty] decimal(18,2)  NULL,
    [DestinationWarehouseID] int  NOT NULL,
    [DestinationItemCode] nvarchar(25)  NOT NULL,
    [DestinationPacketSize] nvarchar(50)  NULL,
    [DestinationBagSize] nvarchar(50)  NULL,
    [DestinationQty] decimal(18,2)  NOT NULL,
    [DestinationNetQty] decimal(18,2)  NULL,
    [DestinationBatchID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblItemWarehouseMaps'
CREATE TABLE [dbo].[tblItemWarehouseMaps] (
    [ItemWarehouseMapID] int IDENTITY(1,1) NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [IsOBStockUpdatedToTally] bit  NULL,
    [GRNNumber] nvarchar(15)  NULL,
    [WarehouseID] int  NOT NULL,
    [OrgID] varchar(10)  NOT NULL,
    [Quantity] decimal(18,2)  NOT NULL,
    [SaleQuantity] decimal(18,0)  NULL,
    [InfectedQty] decimal(18,2)  NULL,
    [DeliveredQTY] decimal(18,2)  NULL,
    [BatchID] int  NULL,
    [BranchID] varchar(10)  NULL,
    [IsActive] bit  NOT NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [GINID] nvarchar(15)  NULL,
    [Status] nvarchar(50)  NULL
);
GO

-- Creating table 'tblLedgerTypes'
CREATE TABLE [dbo].[tblLedgerTypes] (
    [LedgerTypeID] int IDENTITY(1,1) NOT NULL,
    [LedgerType] varchar(500)  NULL
);
GO

-- Creating table 'tblNotifications'
CREATE TABLE [dbo].[tblNotifications] (
    [NotificationID] bigint IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [Notification] nvarchar(250)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedByID] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'tblOrganizationWarehouseMaps'
CREATE TABLE [dbo].[tblOrganizationWarehouseMaps] (
    [OrganizationWarehouseMapID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NOT NULL,
    [BranchID] varchar(10)  NULL,
    [WarehouseID] int  NOT NULL,
    [IsActive] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDatetime] datetime  NOT NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblPacketSizeDetails'
CREATE TABLE [dbo].[tblPacketSizeDetails] (
    [PacketSizeID] int IDENTITY(1,1) NOT NULL,
    [PacketSize] nvarchar(50)  NULL,
    [PacketDescription] nvarchar(50)  NULL,
    [CreatedByID] int  NULL,
    [CreationDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblParameters'
CREATE TABLE [dbo].[tblParameters] (
    [ParameterID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Value] varchar(100)  NULL,
    [MinRange] varchar(100)  NULL,
    [MaxRange] varchar(100)  NULL,
    [UnitOfMeasure] varchar(500)  NULL,
    [DeviationPercentage] decimal(18,0)  NULL,
    [CategoryID] int  NULL,
    [SubCategoryID] int  NULL,
    [ParameterType] varchar(500)  NULL,
    [IsActive] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblPaymentReceipts'
CREATE TABLE [dbo].[tblPaymentReceipts] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PaymentReceiptID] varchar(50)  NULL,
    [IsRequestSent] char(1)  NULL,
    [IsRequestReceived] char(1)  NULL,
    [CustID] varchar(35)  NULL,
    [CustName] varchar(350)  NULL,
    [RequestSentDatetime] varchar(35)  NULL,
    [RequestReceivedDatetime] varchar(35)  NULL,
    [PaymentReceiptFromTally] varchar(max)  NULL,
    [IsTallyUpdated] char(1)  NULL,
    [SalesmanID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblPCN_Details'
CREATE TABLE [dbo].[tblPCN_Details] (
    [pcndeatils_idpk] int IDENTITY(1,1) NOT NULL,
    [pcn_num] varchar(200)  NOT NULL,
    [Voucher_IDFK] varchar(200)  NULL,
    [itemcode] nvarchar(50)  NULL,
    [Quantity] decimal(18,2)  NULL,
    [Quantity_Qtl] decimal(18,2)  NULL,
    [Process_Id] int  NULL,
    [WarehouseId] int  NULL,
    [Status] varchar(10)  NULL,
    [Batch_Number] varchar(200)  NULL,
    [Rate] decimal(18,2)  NULL,
    [Amount] decimal(18,2)  NULL,
    [Pitemcode] varchar(200)  NULL,
    [PQuantity] decimal(18,2)  NULL,
    [PRate] decimal(18,2)  NULL,
    [PAmount] decimal(18,2)  NULL,
    [IsTallyUpdated] bit  NULL,
    [Created_by] int  NULL,
    [Created_Date] datetime  NULL,
    [Updated_by] int  NULL,
    [Updated_Date] datetime  NULL
);
GO

-- Creating table 'tblPercentageStructures'
CREATE TABLE [dbo].[tblPercentageStructures] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PercStrctureID] int  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [PercentageValue] int  NOT NULL,
    [IsActive] bit  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblPNCNs'
CREATE TABLE [dbo].[tblPNCNs] (
    [pcn_idpk] int IDENTITY(1,1) NOT NULL,
    [pcn_num] varchar(200)  NOT NULL,
    [Voucher_IDFK] varchar(200)  NULL,
    [pcn_date] datetime  NULL,
    [Remark] varchar(max)  NULL,
    [Total_Amount] decimal(18,2)  NULL,
    [Quantity_Qtl] decimal(18,2)  NULL,
    [OrgID] varchar(10)  NULL,
    [Status] varchar(10)  NOT NULL,
    [isTallyupdated] bit  NULL,
    [Created_By] int  NULL,
    [Created_Date] datetime  NULL,
    [Updated_By] int  NULL,
    [Updated_Date] datetime  NULL
);
GO

-- Creating table 'tblPOQuotations'
CREATE TABLE [dbo].[tblPOQuotations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [POQuotationID] int  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [Quantity] decimal(18,2)  NOT NULL,
    [Status] nvarchar(25)  NOT NULL,
    [QuotationDate] datetime  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL
);
GO

-- Creating table 'tblPOQuotationSuppliers'
CREATE TABLE [dbo].[tblPOQuotationSuppliers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [POQuotationSupID] int  NOT NULL,
    [POQuotationID] int  NOT NULL,
    [CustID] varchar(15)  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblProcessitem_Master'
CREATE TABLE [dbo].[tblProcessitem_Master] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [TallyItemName] nvarchar(250)  NULL,
    [ItemName] nvarchar(max)  NULL,
    [Alias] nchar(10)  NULL,
    [OrgID] varchar(10)  NULL,
    [RateID] int  NULL,
    [BaseUnit] int  NULL,
    [BasePKTValue] decimal(7,2)  NULL,
    [AlternateUnit] int  NULL,
    [AlternatePKTValue] decimal(7,2)  NULL,
    [PacketUOMID] int  NULL,
    [PacketQTY] decimal(18,0)  NULL,
    [BagUOMID] int  NULL,
    [BagQTY] decimal(18,0)  NULL,
    [IsTallyUpdated] bit  NULL,
    [IsParentTallyUpdated] bit  NULL,
    [IsCESSMapped] bit  NULL,
    [CESSValue] decimal(18,2)  NULL,
    [CESSEffectiveDate] datetime  NULL,
    [BrandID] int  NOT NULL,
    [CategoryID] int  NOT NULL,
    [SubCategoryID] int  NOT NULL,
    [RackID] int  NULL,
    [ItemDetail] nvarchar(max)  NULL,
    [StorageArea] nvarchar(250)  NULL,
    [AllowNegativeStock] bit  NULL,
    [IsItemBlocked] bit  NULL,
    [GST] decimal(18,2)  NOT NULL,
    [GSTEffectiveDate] datetime  NULL,
    [IGST] nvarchar(30)  NULL,
    [CGST] nvarchar(30)  NULL,
    [SGST] nvarchar(30)  NULL,
    [ReOrderlevel] int  NULL,
    [ReOrderQTY] int  NULL,
    [IsReturnable] bit  NULL,
    [IsTrademarkRegistered] bit  NULL,
    [PreDefinedBarCode] varchar(max)  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [IsActive] bit  NULL,
    [DaysToRefill] int  NULL,
    [HSNCode] int  NULL,
    [HSNSubCode] int  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [finisheditem_sale] bit  NULL
);
GO

-- Creating table 'tblPurchaseOrders'
CREATE TABLE [dbo].[tblPurchaseOrders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PurchaseOrderNumber] nvarchar(15)  NOT NULL,
    [PurchasOrderDate] datetime  NOT NULL,
    [PurchaseOrderExpectedDate] datetime  NULL,
    [PurchaseOrderSource] bit  NULL,
    [PurchaseRequisitionNumber] nvarchar(20)  NULL,
    [SupplierID] varchar(15)  NULL,
    [OrgId] varchar(10)  NULL,
    [BranchId] varchar(10)  NULL,
    [WareHouseId] int  NULL,
    [BrokerId] int  NULL,
    [OperatorId] int  NULL,
    [IsPurchaseOrderAddTally] char(1)  NULL,
    [FreightQty] decimal(18,2)  NULL,
    [FreightRate] decimal(18,2)  NULL,
    [FreightCharges] decimal(18,2)  NULL,
    [TotalValue] decimal(18,2)  NULL,
    [TotalItemCount] int  NULL,
    [Comments] nvarchar(250)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SalesOrderNumber] nvarchar(15)  NULL,
    [Status] nvarchar(50)  NULL,
    [Discount] decimal(18,2)  NULL,
    [DiscountVal] decimal(18,2)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL,
    [SMSStatus] nvarchar(10)  NULL,
    [PurchaseType] char(4)  NULL
);
GO

-- Creating table 'tblPurchaseOrderInvoices'
CREATE TABLE [dbo].[tblPurchaseOrderInvoices] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [POInvoiceReferenceNumber] nvarchar(15)  NOT NULL,
    [PaymentStatus] char(2)  NULL,
    [PurchaseOrderNumber] nvarchar(15)  NOT NULL,
    [GINID] nvarchar(15)  NULL,
    [InvoiceDate] datetime  NOT NULL,
    [InvoiceTotal] decimal(18,2)  NULL,
    [Shipping_Address] varchar(250)  NULL,
    [Billing_Address] varchar(250)  NULL,
    [OrgID] varchar(10)  NULL,
    [SuppID] varchar(15)  NULL,
    [DiscountValue] decimal(18,2)  NULL,
    [DiscountAmt] decimal(18,2)  NULL,
    [FreightAmount] decimal(18,2)  NULL,
    [GSTOnFreightAmount] decimal(18,2)  NULL,
    [InvoiceFreightChargesTotal] decimal(18,2)  NULL,
    [Loading_UnloadingTotal] decimal(18,2)  NULL,
    [OtherExpenses] decimal(18,2)  NULL,
    [CreationDate] datetime  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [TallyUpdatedByID] int  NULL,
    [TallyUpdatedDate] datetime  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [TareSupplierWeight] decimal(18,2)  NULL,
    [TareInwardWeight] decimal(18,2)  NULL,
    [NetSupplierWeight] decimal(18,2)  NULL,
    [NetInwardWeight] decimal(18,2)  NULL,
    [UnitwiseQty] nvarchar(50)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL
);
GO

-- Creating table 'tblPurchaseOrderInvoiceItemDetails'
CREATE TABLE [dbo].[tblPurchaseOrderInvoiceItemDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [POInvoiceReferenceNumbe] nvarchar(15)  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [WarehouseID] int  NULL,
    [QuantityBilled] int  NOT NULL,
    [BilledUOM] decimal(18,2)  NULL,
    [RateWOTax] decimal(18,2)  NULL,
    [Rate] decimal(18,2)  NULL,
    [RatePer] nvarchar(10)  NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [Discount] decimal(18,2)  NULL,
    [DiscountAmount] decimal(18,2)  NULL,
    [GST] decimal(18,2)  NULL,
    [TaxAmount] decimal(18,2)  NULL,
    [GoodsType] nvarchar(15)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [UnitID] int  NULL
);
GO

-- Creating table 'tblPurchaseOrderWithItems'
CREATE TABLE [dbo].[tblPurchaseOrderWithItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PurchaseOrderNumber] nvarchar(15)  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [PacketSizeID] int  NULL,
    [BagSizeID] int  NULL,
    [BagQTY] nvarchar(50)  NULL,
    [TotalQTY] decimal(18,2)  NULL,
    [BilledQty] decimal(18,2)  NULL,
    [Rate] decimal(18,2)  NULL,
    [Value] decimal(18,2)  NULL,
    [Discount] decimal(18,2)  NULL,
    [GST] decimal(18,2)  NULL,
    [TaxValue] decimal(18,2)  NULL,
    [BaseValue] decimal(18,2)  NULL,
    [DeliveryType] varchar(10)  NULL,
    [ExpectedDate] datetime  NULL,
    [Remarks] nvarchar(50)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [ItemRowNumber] int  NULL,
    [WarehouseID] int  NOT NULL,
    [Status] nvarchar(100)  NULL,
    [ReasonID] int  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblPurchaseRequisitions'
CREATE TABLE [dbo].[tblPurchaseRequisitions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RequisitionNumber] nvarchar(20)  NOT NULL,
    [DateOfPurchase] datetime  NULL,
    [RequisitionRequester] varchar(50)  NOT NULL,
    [ExpectedDate] datetime  NULL,
    [RequestedName] nvarchar(50)  NULL,
    [ContactNumber] nvarchar(50)  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [BranchID] varchar(10)  NULL,
    [OrgID] varchar(10)  NULL,
    [Status] nvarchar(10)  NULL
);
GO

-- Creating table 'tblPurchaseRequisitionItemsDetails'
CREATE TABLE [dbo].[tblPurchaseRequisitionItemsDetails] (
    [ItemDetailsReqNumber] int IDENTITY(1,1) NOT NULL,
    [RequisitionNumber] nvarchar(20)  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [Quantity] decimal(18,2)  NOT NULL,
    [Description] nvarchar(500)  NULL,
    [IsPoCreated] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [WarehouseID] int  NOT NULL,
    [DeliverycenterID] int  NULL,
    [Status] nvarchar(150)  NULL
);
GO

-- Creating table 'tblRacks'
CREATE TABLE [dbo].[tblRacks] (
    [RackID] int IDENTITY(1,1) NOT NULL,
    [RackNumber] nvarchar(100)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [Description] nvarchar(max)  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblReasons'
CREATE TABLE [dbo].[tblReasons] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ReasonID] int  NOT NULL,
    [ReasonDescription] nvarchar(250)  NOT NULL,
    [ScreenName] nvarchar(100)  NULL,
    [CreatedByID] int  NULL,
    [CreationDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblReceiptDetails'
CREATE TABLE [dbo].[tblReceiptDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ReceiptID] nvarchar(20)  NOT NULL,
    [ReceiptDatetime] nvarchar(20)  NULL,
    [CustID] nvarchar(20)  NULL,
    [Amount] decimal(18,2)  NULL,
    [SalesManID] nvarchar(20)  NULL,
    [BankName] nvarchar(30)  NULL,
    [ChequeNo] nvarchar(20)  NULL,
    [ReceiptCreationDate] datetime  NULL,
    [SignatureImage] varchar(max)  NULL,
    [Comments] nvarchar(500)  NULL,
    [IsSalesOrderAddTally] char(1)  NULL,
    [CustLocation] nvarchar(500)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [TallySync] bit  NULL
);
GO

-- Creating table 'tblReceiptWithBillDetails'
CREATE TABLE [dbo].[tblReceiptWithBillDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ReceiptID] nvarchar(20)  NOT NULL,
    [billNo] nvarchar(100)  NULL,
    [billdatetime] nvarchar(20)  NULL,
    [TallyAmount] nvarchar(20)  NULL,
    [discountamount] nvarchar(20)  NULL,
    [billamount] nvarchar(20)  NULL,
    [IsSalesOrderAddTally] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [TallySync] bit  NULL
);
GO

-- Creating table 'tblRouteMappings'
CREATE TABLE [dbo].[tblRouteMappings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [RouteID] int  NOT NULL,
    [AssignedDate] datetime  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [ModifiedDate] datetime  NULL,
    [OrgID] varchar(10)  NULL
);
GO

-- Creating table 'tblRouteMappingDetails'
CREATE TABLE [dbo].[tblRouteMappingDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RouteID] int  NOT NULL,
    [UserID] int  NULL,
    [CustID] int  NULL,
    [AssignedDate] datetime  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedByID] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [OrgID] varchar(10)  NULL
);
GO

-- Creating table 'tblSalesChannelTypes'
CREATE TABLE [dbo].[tblSalesChannelTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ChannelType] varchar(500)  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ParentChannelType] int  NULL,
    [OrgID] varchar(10)  NULL,
    [IsParent] bit  NULL
);
GO

-- Creating table 'tblSalesmanDetails'
CREATE TABLE [dbo].[tblSalesmanDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SalesManID] int  NOT NULL,
    [Fname] varchar(15)  NULL,
    [Mname] varchar(15)  NULL,
    [Lname] varchar(15)  NULL,
    [IsAdmin] char(10)  NULL,
    [IsBroker] bit  NULL,
    [Address] varchar(100)  NULL,
    [PhoneNumber] varchar(15)  NULL,
    [PhoneNumber1] varchar(15)  NULL,
    [EmailID] varchar(25)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblSalesOrders'
CREATE TABLE [dbo].[tblSalesOrders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SalesOrderNumber] nvarchar(15)  NOT NULL,
    [IsDirectSO] bit  NULL,
    [SalesDatetime] varchar(25)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [CustID] varchar(15)  NULL,
    [SalesmanID] int  NULL,
    [BrokerID] int  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL,
    [SignatureImage] varchar(max)  NULL,
    [IsBulkSale] bit  NULL,
    [SalesType] char(2)  NULL,
    [SMSStatus] nvarchar(50)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [IsDirectSale] bit  NULL,
    [DiscountPercentage] decimal(18,2)  NULL,
    [DiscountAmt] decimal(18,2)  NULL,
    [Status] nvarchar(150)  NULL,
    [ApprovalStatus] nvarchar(250)  NULL,
    [RegistrationType] nvarchar(50)  NULL,
    [TotalItemCount] decimal(18,2)  NOT NULL,
    [TransType] char(1)  NOT NULL,
    [Comments] nvarchar(250)  NULL,
    [Location] varchar(max)  NULL,
    [RSalesDatetime] datetime  NULL,
    [DueDate] datetime  NULL,
    [ReferenceNumber] nchar(10)  NULL,
    [IsDelivaryNote] bit  NULL,
    [IsGatePassEntered] bit  NULL,
    [URDNumber] nchar(15)  NULL,
    [BillingAddress] nchar(1000)  NULL,
    [BarCode] varchar(max)  NULL,
    [SourceOfUpdate] nvarchar(1)  NULL,
    [BranchID] varchar(10)  NULL,
    [IsDiscountRangeExceeded] bit  NULL,
    [RejectionRemark] nvarchar(100)  NULL,
    [IsActive] bit  NULL,
    [IsCreditLimitExceeded] bit  NULL,
    [IsCreditDaysExceeded] bit  NULL,
    [IsBillsExceeded] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [PANNumber] nvarchar(10)  NULL,
    [DCNo] nvarchar(50)  NULL,
    [OrderGivenPersonName] nvarchar(100)  NULL,
    [BusinessTypeId] int  NULL,
    [BusinessTypeValue] decimal(18,2)  NULL,
    [CreditTypeId] int  NULL,
    [CreditTypeValue] decimal(18,2)  NULL,
    [Photo1] varchar(max)  NULL,
    [Photo2] varchar(max)  NULL,
    [TallySync] bit  NULL
);
GO

-- Creating table 'tblSalesOrderCashTransactions'
CREATE TABLE [dbo].[tblSalesOrderCashTransactions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SalesOrderNumber] nvarchar(15)  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Address] nvarchar(1000)  NULL,
    [PhoneNumber] nvarchar(50)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblSalesOrderInvoices'
CREATE TABLE [dbo].[tblSalesOrderInvoices] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SOInvoiceReferenceNumber] nvarchar(15)  NOT NULL,
    [Receiptstatus] char(2)  NULL,
    [GatePassCode] nvarchar(15)  NULL,
    [SalesOrderNumber] nvarchar(15)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [CustID] varchar(15)  NULL,
    [VoucherTypeNo] nvarchar(20)  NULL,
    [Shipping_Address] varchar(250)  NULL,
    [UnitWiseQty] nvarchar(50)  NULL,
    [InvoiceDate] datetime  NOT NULL,
    [InvoiceTotal] decimal(18,2)  NULL,
    [DiscountValue] decimal(18,2)  NULL,
    [DiscountAmt] decimal(18,2)  NULL,
    [FreightAmount] decimal(18,2)  NULL,
    [GSTOnFreightAmount] decimal(18,2)  NULL,
    [GrossWeight] decimal(18,2)  NULL,
    [APMCPermitNumber] nvarchar(50)  NULL,
    [EWayNumber] nvarchar(50)  NULL,
    [InsuranceNumber] nvarchar(50)  NULL,
    [InvoiceFreightChargesTotal] decimal(18,2)  NULL,
    [Loading_UnloadingTotal] decimal(18,2)  NULL,
    [OtherExpenses] decimal(18,2)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [TallyUpdatedDate] datetime  NULL,
    [TallyUpdatedByID] int  NULL,
    [Remarks] nvarchar(max)  NULL,
    [InsuranceCharges] decimal(18,2)  NULL,
    [TCSPercentage] decimal(5,2)  NULL,
    [TCSValue] decimal(18,2)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [Remark] varchar(500)  NULL,
    [SIType] nvarchar(50)  NULL,
    [SITypeNum] nvarchar(200)  NULL
);
GO

-- Creating table 'tblSalesOrderInvoiceItemDetails'
CREATE TABLE [dbo].[tblSalesOrderInvoiceItemDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SOInvoiceReferenceNumber] nvarchar(15)  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [WarehouseID] int  NULL,
    [Quantity] int  NOT NULL,
    [BilledQty] decimal(18,2)  NULL,
    [Rate] decimal(18,2)  NULL,
    [RateWithOutTax] decimal(18,2)  NULL,
    [RatePerUnit] nvarchar(10)  NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [GST] decimal(18,0)  NULL,
    [TaxAmount] decimal(18,2)  NULL,
    [Discount] decimal(18,0)  NULL,
    [DiscountAmount] decimal(18,2)  NULL,
    [UnitID] int  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [Remark] varchar(500)  NULL,
    [SIType] nvarchar(50)  NULL,
    [SITypeNum] nvarchar(200)  NULL
);
GO

-- Creating table 'tblSalesOrderItemWarehouseMaps'
CREATE TABLE [dbo].[tblSalesOrderItemWarehouseMaps] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SalesOrderWithItemID] uniqueidentifier  NOT NULL,
    [SalesOrderNumber] nvarchar(15)  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [WarehouseID] int  NOT NULL,
    [BatchID] int  NULL,
    [TotalQuantity] decimal(18,2)  NOT NULL,
    [QuantityOrdered] decimal(18,2)  NOT NULL,
    [IsNegativeStock] bit  NULL,
    [NegativeStockApprovalStatus] nvarchar(50)  NULL,
    [NegativeStockApproveRemark] nvarchar(100)  NULL,
    [IsFIFOSkipped] bit  NULL,
    [FIFOApprovalStatus] nvarchar(50)  NULL,
    [FIFOApproveRemark] nvarchar(100)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblSalesOrderWithItems'
CREATE TABLE [dbo].[tblSalesOrderWithItems] (
    [SalesOrderWithItemID] uniqueidentifier  NOT NULL,
    [SalesOrderNumber] nvarchar(15)  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [BagQTY] nvarchar(50)  NOT NULL,
    [TotalQTY] decimal(18,2)  NOT NULL,
    [Rate] decimal(18,2)  NOT NULL,
    [Value] decimal(18,2)  NOT NULL,
    [IsRateInQuantls] bit  NULL,
    [DiscountPercentage] decimal(18,2)  NULL,
    [IsDiscountRangeExceeded] bit  NULL,
    [DiscountRangeApprovalStatus] nvarchar(50)  NULL,
    [DiscountExceededReason] nvarchar(100)  NULL,
    [IsTallyUpdated] bit  NOT NULL,
    [ItemRowNumber] int  NULL,
    [FrieghtCharge] decimal(18,2)  NULL,
    [LoadingUnloadingCharge] decimal(18,2)  NULL,
    [OtherExpense] decimal(18,2)  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [TallySync] bit  NULL
);
GO

-- Creating table 'tblSPDocuments'
CREATE TABLE [dbo].[tblSPDocuments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SalesPartnerID] varchar(150)  NULL,
    [DocumentName] varchar(50)  NULL,
    [DocumentData] varchar(max)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] int  NULL,
    [OrgID] varchar(10)  NULL,
    [DocumentType] varchar(100)  NULL,
    [ExpiryDate] datetime  NULL,
    [DocumentNumber] varchar(250)  NULL
);
GO

-- Creating table 'tblStates'
CREATE TABLE [dbo].[tblStates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [StateID] int  NOT NULL,
    [StateName] nvarchar(50)  NULL
);
GO

-- Creating table 'tblStateWithCities'
CREATE TABLE [dbo].[tblStateWithCities] (
    [ID] int  NOT NULL,
    [StatewithCityID] int IDENTITY(1,1) NOT NULL,
    [StateID] int  NOT NULL,
    [VillageLocalityname] nvarchar(500)  NOT NULL,
    [DistrictID] int  NULL
);
GO

-- Creating table 'tblStickerDetails'
CREATE TABLE [dbo].[tblStickerDetails] (
    [StickerId] int IDENTITY(1,1) NOT NULL,
    [GRNNumber] nvarchar(15)  NULL,
    [ItemCode] nvarchar(25)  NULL,
    [WareHouseId] int  NULL,
    [SupplierName] nvarchar(100)  NOT NULL,
    [DateOfReciept] datetime  NOT NULL,
    [InwardQTY] decimal(18,2)  NULL,
    [BatchNumber] nvarchar(100)  NOT NULL,
    [NoOfStickersPrinted] int  NULL,
    [CreatedById] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [GINID] nvarchar(15)  NULL,
    [BatchID] int  NULL,
    [SourceOfUpdate] char(2)  NULL
);
GO

-- Creating table 'tblStockTransferHeaders'
CREATE TABLE [dbo].[tblStockTransferHeaders] (
    [StockTransferHeaderID] int IDENTITY(1,1) NOT NULL,
    [StockTransferCode] nvarchar(15)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblStockTransferLineItems'
CREATE TABLE [dbo].[tblStockTransferLineItems] (
    [StockTransferLineItemID] uniqueidentifier  NOT NULL,
    [StockTransferHeaderID] int  NOT NULL,
    [ItemCode] nvarchar(25)  NOT NULL,
    [SourceQTY] decimal(18,2)  NOT NULL,
    [SourceWarehouseID] int  NOT NULL,
    [SourceBatchID] int  NULL,
    [DestinationWarehouseID] int  NOT NULL,
    [DestinationQTY] nchar(10)  NULL,
    [DestinationBatchID] int  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblSubAccountGroupMasters'
CREATE TABLE [dbo].[tblSubAccountGroupMasters] (
    [SubAccountGroupMasterID] int IDENTITY(1,1) NOT NULL,
    [SubAccountName] nvarchar(150)  NOT NULL,
    [AccountGroupMasterID] int  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedByID] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'tblSubCategories'
CREATE TABLE [dbo].[tblSubCategories] (
    [SubCategoryID] int IDENTITY(1,1) NOT NULL,
    [SubCategoryName] nvarchar(max)  NOT NULL,
    [CategoryID] int  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [IsTallyUpdated] bit  NULL,
    [TallyUpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblSubMenuRoleMaps'
CREATE TABLE [dbo].[tblSubMenuRoleMaps] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SubMenuID] int  NOT NULL,
    [RoleID] int  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [ActivityID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [OrgID] varchar(10)  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [SystemAccess] char(1)  NULL
);
GO

-- Creating table 'tblSysBranches'
CREATE TABLE [dbo].[tblSysBranches] (
    [BranchID] varchar(10)  NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [OrgID] varchar(10)  NULL,
    [Phone] nvarchar(50)  NULL,
    [ContactPerson] nvarchar(255)  NULL,
    [Location] nvarchar(100)  NULL,
    [State] nvarchar(50)  NULL,
    [City] nvarchar(100)  NULL,
    [PinCode] nvarchar(8)  NULL,
    [BillingLandmark] nvarchar(100)  NULL,
    [ShippingLandmark] nvarchar(100)  NULL,
    [BillingAddress] nvarchar(100)  NULL,
    [Website] nvarchar(50)  NULL,
    [Email] nvarchar(100)  NULL,
    [Mobile] nvarchar(50)  NULL,
    [Fax] nvarchar(20)  NULL,
    [ShippingAddress] nvarchar(100)  NULL,
    [MailingName] nvarchar(50)  NULL,
    [Address] nvarchar(255)  NULL,
    [FinancialYearStart] datetime  NULL,
    [FinancialYearEnd] datetime  NULL,
    [BankName] nvarchar(100)  NULL,
    [BankBranchName] nvarchar(100)  NULL,
    [BankCity] nvarchar(50)  NULL,
    [AlternateNumber] nvarchar(15)  NULL,
    [ShippingPinCode] nvarchar(15)  NULL,
    [AccountNumber] nvarchar(50)  NULL,
    [IFSCCode] nvarchar(50)  NULL,
    [FSSAICode] nvarchar(50)  NULL,
    [GST] nvarchar(15)  NULL,
    [PANNumber] nvarchar(15)  NULL,
    [ShippingCity] nvarchar(50)  NULL,
    [ShippingState] nvarchar(50)  NULL,
    [IsMappedToOrg] bit  NULL,
    [MappedOrgID] varchar(10)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDatetime] datetime  NOT NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [Quantitylimit] decimal(18,2)  NULL,
    [ChannelTypeID] int  NULL,
    [AssociatedTo] int  NULL,
    [ParentChannelPartnerID] int  NULL,
    [BranchCity] int  NULL,
    [BranchState] int  NULL
);
GO

-- Creating table 'tblSysMainMenus'
CREATE TABLE [dbo].[tblSysMainMenus] (
    [MainMenuID] int  NOT NULL,
    [MainMenuName] varchar(50)  NOT NULL,
    [ScreenName] varchar(128)  NULL,
    [Remark] nvarchar(100)  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblSysOrganizations'
CREATE TABLE [dbo].[tblSysOrganizations] (
    [OrgID] varchar(10)  NOT NULL,
    [Code] nvarchar(50)  NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Alias] nvarchar(3)  NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NULL,
    [GSTNumber] nvarchar(100)  NOT NULL,
    [ShippingAddress] nvarchar(100)  NOT NULL,
    [BillingAddress] nvarchar(100)  NULL,
    [BillingLandmark] nvarchar(100)  NULL,
    [ShippingLandmark] nvarchar(100)  NULL,
    [Website] nvarchar(50)  NULL,
    [Email] nvarchar(100)  NULL,
    [ContactPerson] nvarchar(100)  NOT NULL,
    [Phone] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NOT NULL,
    [Fax] nvarchar(20)  NULL,
    [BusinessType] nvarchar(100)  NULL,
    [CompanyType] nvarchar(100)  NULL,
    [BankName] nvarchar(50)  NOT NULL,
    [BranchName] nvarchar(50)  NOT NULL,
    [BankCode] nchar(50)  NULL,
    [BankCity] nvarchar(50)  NULL,
    [AccountNumber] nvarchar(50)  NOT NULL,
    [IFSCNumber] varchar(50)  NULL,
    [FSSAICode] varchar(50)  NULL,
    [NoOfOutstandingBills] int  NULL,
    [CreditDays] nvarchar(50)  NULL,
    [CreditLimitAmt] decimal(18,2)  NULL,
    [Logo] varbinary(max)  NULL,
    [IsActive] bit  NULL,
    [PANNumber] varchar(100)  NULL,
    [STNumber] varchar(100)  NULL,
    [CSTNumber] varchar(100)  NULL,
    [VATNumber] varchar(100)  NULL,
    [MailingName] nvarchar(50)  NULL,
    [Country] nvarchar(50)  NULL,
    [State] nvarchar(50)  NULL,
    [City] nvarchar(100)  NULL,
    [Pincode] nvarchar(10)  NULL,
    [ApplicationID] int  NULL,
    [AlternateNumber] nvarchar(15)  NULL,
    [ShippingCity] nvarchar(50)  NULL,
    [ShippingState] nvarchar(50)  NULL,
    [ShippingPinCode] nvarchar(15)  NULL,
    [CreatedByID] int  NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [ModifiedDatetime] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [Declaration] nvarchar(max)  NULL,
    [TermsAndConditions] nvarchar(max)  NULL,
    [IsServiceInstalled] bit  NULL,
    [IsTallyUsing] bit  NULL
);
GO

-- Creating table 'tblSysOrganizationMaps'
CREATE TABLE [dbo].[tblSysOrganizationMaps] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ParentOrgID] varchar(10)  NOT NULL,
    [SisterOrgID] varchar(10)  NOT NULL,
    [Priority] int  NOT NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [IsParent] char(1)  NULL,
    [IsMapped] bit  NULL,
    [IsDC] bit  NULL,
    [ModifiedDatetime] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblSysRoles'
CREATE TABLE [dbo].[tblSysRoles] (
    [RoleID] int  NOT NULL,
    [RoleName] varchar(50)  NOT NULL,
    [RoleDescription] varchar(128)  NULL,
    [DepartmentID] int  NULL,
    [Department] nvarchar(100)  NULL,
    [IsEditable] bit  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [ParentRoleID] int  NULL,
    [OrgID] varchar(10)  NULL
);
GO

-- Creating table 'tblSysSubMenus'
CREATE TABLE [dbo].[tblSysSubMenus] (
    [SubMenuID] int  NOT NULL,
    [MainMenuID] int  NOT NULL,
    [SubMenuName] varchar(50)  NOT NULL,
    [ScreenName] varchar(128)  NULL,
    [Remark] nvarchar(100)  NULL,
    [IsActive] bit  NULL,
    [OrgID] varchar(10)  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblSystemDetails'
CREATE TABLE [dbo].[tblSystemDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SystemID] int  NOT NULL,
    [SystemNumber] nvarchar(250)  NOT NULL,
    [SystemName] nvarchar(250)  NOT NULL,
    [Status] bit  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [StartTime] datetime  NULL,
    [EndTime] datetime  NULL,
    [LastStopTime] datetime  NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblSysUsers'
CREATE TABLE [dbo].[tblSysUsers] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NOT NULL,
    [BranchID] varchar(10)  NULL,
    [FName] nvarchar(50)  NOT NULL,
    [Alias] nvarchar(3)  NULL,
    [WarehouseID] int  NULL,
    [Email] nvarchar(100)  NULL,
    [Mobile] nvarchar(50)  NULL,
    [Address] nvarchar(250)  NULL,
    [Username] nvarchar(50)  NULL,
    [Password] nvarchar(max)  NOT NULL,
    [RoleID] int  NOT NULL,
    [QuestionID] int  NULL,
    [Answer] nvarchar(50)  NULL,
    [CanAddDiscount] bit  NULL,
    [IsActive] bit  NULL,
    [OldPassword] nvarchar(15)  NULL,
    [NoofPassword] int  NULL,
    [LoggedInDateTime] datetime  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDatetime] datetime  NOT NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [DeviceId] nvarchar(max)  NULL,
    [DiscountPercentage] decimal(18,2)  NULL,
    [DiscountValue] decimal(18,2)  NULL,
    [IsThresholdQtyAllowed] bit  NULL,
    [IsOTPVerified] bit  NULL,
    [SMSOTP] varchar(10)  NULL,
    [SystemAccess] char(10)  NULL,
    [PinCode] nvarchar(15)  NULL,
    [City] int  NULL,
    [State] int  NULL,
    [AdharNumber] nvarchar(12)  NULL,
    [PanNumber] nvarchar(10)  NULL,
    [Department] varchar(500)  NULL,
    [ParentUserID] int  NULL,
    [CountryID] int  NULL,
    [DepartmentID] int  NULL,
    [IsServiceInstalled] bit  NULL
);
GO

-- Creating table 'tblTaxationTypes'
CREATE TABLE [dbo].[tblTaxationTypes] (
    [TaxationTypeID] int IDENTITY(1,1) NOT NULL,
    [TaxationType] varchar(500)  NULL
);
GO

-- Creating table 'tblTaxCESSes'
CREATE TABLE [dbo].[tblTaxCESSes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TaxCESSID] int  NOT NULL,
    [TAXName] nvarchar(200)  NOT NULL,
    [TAXValue] decimal(18,2)  NOT NULL,
    [OrgId] varchar(10)  NULL,
    [Comments] nvarchar(250)  NULL,
    [EffectiveDate] datetime  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblTransitItems'
CREATE TABLE [dbo].[tblTransitItems] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PurchaseOrderNumber] nvarchar(15)  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblTransitItemDetails'
CREATE TABLE [dbo].[tblTransitItemDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TransitItemID] int  NOT NULL,
    [ItemCode] nvarchar(500)  NOT NULL,
    [QuantityOrdered] int  NOT NULL,
    [QuantityInvoiced] int  NULL,
    [Remarks] nvarchar(max)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [UpdateDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblUnitQuantities'
CREATE TABLE [dbo].[tblUnitQuantities] (
    [UnitQuantityID] int IDENTITY(1,1) NOT NULL,
    [UOM] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [OrgID] varchar(10)  NULL,
    [IsCompoundUnit] bit  NOT NULL,
    [FirstUnitID] int  NULL,
    [SecondUnitID] int  NULL,
    [Value] int  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblUOMs'
CREATE TABLE [dbo].[tblUOMs] (
    [UnitID] int IDENTITY(1,1) NOT NULL,
    [Unit] nvarchar(50)  NULL,
    [OrgID] varchar(10)  NULL,
    [IsFirstUnit] bit  NULL,
    [Description] nvarchar(100)  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [CreatedByID] int  NULL,
    [IsActive] bit  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblUserAreaofServices'
CREATE TABLE [dbo].[tblUserAreaofServices] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedBy] int  NULL,
    [StateID] int  NULL,
    [DistrictID] int  NULL,
    [CityID] int  NULL,
    [AreaName] varchar(500)  NULL,
    [CustID] int  NULL,
    [OrgID] varchar(10)  NULL
);
GO

-- Creating table 'tblUserDocuments'
CREATE TABLE [dbo].[tblUserDocuments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [DocumentNumber] varchar(250)  NULL,
    [DocumentType] varchar(500)  NULL,
    [DocumentData] varchar(max)  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ExpiryDate] varchar(50)  NULL,
    [OrgID] varchar(10)  NULL
);
GO

-- Creating table 'tblUserMappings'
CREATE TABLE [dbo].[tblUserMappings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ParentUserId] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [CreateddBy] int  NULL,
    [UpdatedDate] datetime  NULL,
    [UpdatedBy] int  NULL,
    [OrgID] varchar(10)  NULL
);
GO

-- Creating table 'tblUserWarehouseMaps'
CREATE TABLE [dbo].[tblUserWarehouseMaps] (
    [UserWarehouseMapID] int IDENTITY(1,1) NOT NULL,
    [CreatedByID] int  NOT NULL,
    [WarehouseID] int  NOT NULL,
    [IsActive] bit  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'tblVoucherTypes'
CREATE TABLE [dbo].[tblVoucherTypes] (
    [VoucherTypeNo] nvarchar(20)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Under] nvarchar(20)  NULL,
    [EffectiveDate] datetime  NULL,
    [AllowNarration] nvarchar(10)  NULL,
    [AliasOrAbbreviation] nvarchar(10)  NULL,
    [DisplayColumn] nvarchar(20)  NULL,
    [OrgID] varchar(10)  NOT NULL,
    [BranchID] varchar(10)  NULL,
    [IsEditable] bit  NULL,
    [IsTallyUpdated] bit  NULL,
    [TallyUpdatedDate] datetime  NULL,
    [CreationDate] datetime  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] nchar(2)  NULL
);
GO

-- Creating table 'tblWarehouses'
CREATE TABLE [dbo].[tblWarehouses] (
    [WarehouseID] int IDENTITY(1,1) NOT NULL,
    [IsWHorDC] nchar(2)  NULL,
    [WarehouseName] nvarchar(max)  NOT NULL,
    [ParentID] int  NULL,
    [LandMark] nvarchar(1000)  NULL,
    [City] nvarchar(120)  NOT NULL,
    [GPSLocation] varchar(max)  NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [BillingLandmark] nvarchar(100)  NULL,
    [ShippingLandmark] nvarchar(100)  NULL,
    [ShippingPinCode] nvarchar(15)  NULL,
    [ShippingCity] nvarchar(50)  NULL,
    [ShippingState] nvarchar(50)  NULL,
    [AlternateNumber] nvarchar(15)  NULL,
    [BillingAddress] nvarchar(100)  NULL,
    [Website] nvarchar(50)  NULL,
    [Email] nvarchar(100)  NULL,
    [ContactPerson] nvarchar(100)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Mobile] nvarchar(50)  NULL,
    [Fax] nvarchar(20)  NULL,
    [ShippingAddress] nvarchar(100)  NULL,
    [MailingName] nvarchar(50)  NULL,
    [State] nvarchar(50)  NULL,
    [PinCode] nvarchar(50)  NULL,
    [IsActive] bit  NULL,
    [IsPrimary] bit  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [IsTallyUpdated] bit  NULL,
    [TallyUpdatedDate] datetime  NULL
);
GO

-- Creating table 'tblWarehouseToWarehouseTrackings'
CREATE TABLE [dbo].[tblWarehouseToWarehouseTrackings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [WarehouseTrackingID] int  NOT NULL,
    [SourceWarehouseID] int  NOT NULL,
    [SourceItemCode] nvarchar(25)  NOT NULL,
    [SourceQty] decimal(18,2)  NOT NULL,
    [DestinationWarehouseID] int  NOT NULL,
    [DestinationItemCode] nvarchar(25)  NOT NULL,
    [DestinationQty] decimal(18,2)  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL
);
GO

-- Creating table 'TypeOfExpenses'
CREATE TABLE [dbo].[TypeOfExpenses] (
    [ExpsId] int IDENTITY(1,1) NOT NULL,
    [ExpenseName] nvarchar(100)  NULL,
    [OrgId] nvarchar(10)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedById] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedById] int  NULL
);
GO

-- Creating table 'VirtualWarehouseDetails'
CREATE TABLE [dbo].[VirtualWarehouseDetails] (
    [VID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [OrgID] nvarchar(10)  NULL,
    [DCOrOtherID] nvarchar(10)  NULL,
    [Address] nvarchar(100)  NULL,
    [State] nvarchar(50)  NULL,
    [City] nvarchar(120)  NULL,
    [PinCode] nvarchar(15)  NULL,
    [IsActive] bit  NULL,
    [CreatedByID] int  NULL,
    [CreatedDate] datetime  NULL
);
GO

-- Creating table 'tblPlans'
CREATE TABLE [dbo].[tblPlans] (
    [PlanID] int IDENTITY(1,1) NOT NULL,
    [PlanName] varchar(200)  NULL,
    [IsActive] bit  NULL,
    [PlanDuration] int  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] int  NULL,
    [ModifiedDate] datetime  NULL,
    [ModifiedBy] int  NULL
);
GO

-- Creating table 'tblSysChannelPartners'
CREATE TABLE [dbo].[tblSysChannelPartners] (
    [ChannelPartnerID] varchar(10)  NOT NULL,
    [ChannelPartnerName] nvarchar(255)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(10)  NULL,
    [Phone] nvarchar(50)  NULL,
    [ContactPerson] nvarchar(255)  NULL,
    [Location] nvarchar(100)  NULL,
    [State] nvarchar(50)  NULL,
    [City] nvarchar(100)  NULL,
    [PinCode] nvarchar(8)  NULL,
    [BillingLandmark] nvarchar(100)  NULL,
    [ShippingLandmark] nvarchar(100)  NULL,
    [BillingAddress] nvarchar(100)  NULL,
    [Website] nvarchar(50)  NULL,
    [Email] nvarchar(100)  NULL,
    [Mobile] nvarchar(50)  NULL,
    [Fax] nvarchar(20)  NULL,
    [ShippingAddress] nvarchar(100)  NULL,
    [MailingName] nvarchar(50)  NULL,
    [Address] nvarchar(255)  NULL,
    [FinancialYearStart] datetime  NULL,
    [FinancialYearEnd] datetime  NULL,
    [BankName] nvarchar(100)  NULL,
    [BankBranchName] nvarchar(100)  NULL,
    [BankCity] nvarchar(50)  NULL,
    [AlternateNumber] nvarchar(15)  NULL,
    [ShippingPinCode] nvarchar(15)  NULL,
    [AccountNumber] nvarchar(50)  NULL,
    [IFSCCode] nvarchar(50)  NULL,
    [FSSAICode] nvarchar(50)  NULL,
    [GST] nvarchar(15)  NULL,
    [PANNumber] nvarchar(15)  NULL,
    [ShippingCity] nvarchar(50)  NULL,
    [ShippingState] nvarchar(50)  NULL,
    [IsMappedToOrg] bit  NULL,
    [MappedOrgID] varchar(10)  NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDatetime] datetime  NOT NULL,
    [UpdatedBy] int  NOT NULL,
    [UpdatedDatetime] datetime  NOT NULL,
    [ModifiedByID] int  NULL,
    [SourceOfUpdate] char(1)  NULL,
    [Quantitylimit] decimal(18,2)  NULL,
    [ChannelTypeID] int  NULL,
    [AssociatedTo] int  NULL,
    [ParentChannelPartnerID] int  NULL,
    [BranchCity] int  NULL,
    [BranchState] int  NULL
);
GO

-- Creating table 'tblAccessControls'
CREATE TABLE [dbo].[tblAccessControls] (
    [AccessControlID] int IDENTITY(1,1) NOT NULL,
    [OrgID] int  NOT NULL,
    [RoleID] int  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedID] int  NULL
);
GO

-- Creating table 'tblAccessControlItems'
CREATE TABLE [dbo].[tblAccessControlItems] (
    [AccessControlItemID] int IDENTITY(1,1) NOT NULL,
    [AccessControlID] int  NULL,
    [RoleID] int  NULL,
    [SubMenuID] int  NULL,
    [MainMenuID] int  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedID] int  NULL,
    [IsCreate] bit  NULL,
    [IsView] bit  NULL,
    [IsEdit] bit  NULL,
    [IsDelete] bit  NULL
);
GO

-- Creating table 'tblAdminSettings'
CREATE TABLE [dbo].[tblAdminSettings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [MarketingEmailID] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [AutoSyncTally] bit  NOT NULL,
    [MailHost] varchar(50)  NULL,
    [SendingPort] varchar(50)  NULL,
    [SMSAPIKey] varchar(500)  NULL,
    [TransactionalBaseURL] varchar(500)  NULL,
    [TansactionalSenderID] varchar(50)  NULL,
    [PromotionSenderID] varchar(50)  NULL,
    [PromotionalBaseURL] varchar(500)  NULL,
    [OrgID] varchar(10)  NULL,
    [EnableSSL] bit  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedBy] int  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'tblBranchDocuments'
CREATE TABLE [dbo].[tblBranchDocuments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [BranchID] varchar(150)  NULL,
    [DocumentType] varchar(100)  NULL,
    [DocumentData] varchar(max)  NULL,
    [CreatedDate] datetime  NULL,
    [CreatedBy] int  NULL,
    [ExpiryDate] datetime  NULL,
    [DocumentNumber] varchar(250)  NULL
);
GO

-- Creating table 'tblEmailTemplates'
CREATE TABLE [dbo].[tblEmailTemplates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [TemplateName] varchar(500)  NULL,
    [TemplateBody] varchar(max)  NULL,
    [IsActive] int  NULL,
    [Deleted] int  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL,
    [TemplateSubject] varchar(500)  NULL
);
GO

-- Creating table 'tblSMSTemplates'
CREATE TABLE [dbo].[tblSMSTemplates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [TemplateName] varchar(500)  NULL,
    [TemplateBody] varchar(max)  NULL,
    [IsActive] int  NULL,
    [Deleted] int  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL
);
GO

-- Creating table 'tblWhatsappTemplates'
CREATE TABLE [dbo].[tblWhatsappTemplates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [TemplateName] varchar(500)  NULL,
    [TemplateBody] varchar(max)  NULL,
    [IsActive] int  NULL,
    [Deleted] int  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL,
    [TemplateSubject] varchar(500)  NULL
);
GO

-- Creating table 'tblTemplateImages'
CREATE TABLE [dbo].[tblTemplateImages] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ImageName] varchar(50)  NULL,
    [ImageString] varchar(max)  NULL,
    [UploadedBy] int  NULL,
    [UploadedDate] datetime  NULL
);
GO

-- Creating table 'tblUserTemplates'
CREATE TABLE [dbo].[tblUserTemplates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [TemplateName] varchar(500)  NULL,
    [TemplateURL] varchar(max)  NULL,
    [CreatedBy] int  NULL,
    [CreatedDate] datetime  NULL
);
GO

-- Creating table 'tblOrgSystemDetails'
CREATE TABLE [dbo].[tblOrgSystemDetails] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrgID] varchar(10)  NULL,
    [IsTallyRunning] bit  NULL,
    [TallyCompanyName] varchar(500)  NULL,
    [CurrentDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'AccountGroupDetails'
ALTER TABLE [dbo].[AccountGroupDetails]
ADD CONSTRAINT [PK_AccountGroupDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [BaiscExpID] in table 'BasicExpensesDetails'
ALTER TABLE [dbo].[BasicExpensesDetails]
ADD CONSTRAINT [PK_BasicExpensesDetails]
    PRIMARY KEY CLUSTERED ([BaiscExpID] ASC);
GO

-- Creating primary key on [BTMarginsID] in table 'BusinessTypeMarginDetails'
ALTER TABLE [dbo].[BusinessTypeMarginDetails]
ADD CONSTRAINT [PK_BusinessTypeMarginDetails]
    PRIMARY KEY CLUSTERED ([BTMarginsID] ASC);
GO

-- Creating primary key on [BusinessTypeID] in table 'BusinessTypes'
ALTER TABLE [dbo].[BusinessTypes]
ADD CONSTRAINT [PK_BusinessTypes]
    PRIMARY KEY CLUSTERED ([BusinessTypeID] ASC);
GO

-- Creating primary key on [ID] in table 'CreditTypeMarginDetails'
ALTER TABLE [dbo].[CreditTypeMarginDetails]
ADD CONSTRAINT [PK_CreditTypeMarginDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CreditTypeID] in table 'CreditTypes'
ALTER TABLE [dbo].[CreditTypes]
ADD CONSTRAINT [PK_CreditTypes]
    PRIMARY KEY CLUSTERED ([CreditTypeID] ASC);
GO

-- Creating primary key on [DenominationID] in table 'CurrencyDenominationTypes'
ALTER TABLE [dbo].[CurrencyDenominationTypes]
ADD CONSTRAINT [PK_CurrencyDenominationTypes]
    PRIMARY KEY CLUSTERED ([DenominationID] ASC);
GO

-- Creating primary key on [DCItemMapID] in table 'DCQtyAllocationItemWarehouseMaps'
ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMaps]
ADD CONSTRAINT [PK_DCQtyAllocationItemWarehouseMaps]
    PRIMARY KEY CLUSTERED ([DCItemMapID] ASC);
GO

-- Creating primary key on [ID] in table 'DCQuantityAllocations'
ALTER TABLE [dbo].[DCQuantityAllocations]
ADD CONSTRAINT [PK_DCQuantityAllocations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [DeliverycenterBranchMapID] in table 'DeliverycenterBranchMaps'
ALTER TABLE [dbo].[DeliverycenterBranchMaps]
ADD CONSTRAINT [PK_DeliverycenterBranchMaps]
    PRIMARY KEY CLUSTERED ([DeliverycenterBranchMapID] ASC);
GO

-- Creating primary key on [DenominationMapID] in table 'DenominationMapWithTrans'
ALTER TABLE [dbo].[DenominationMapWithTrans]
ADD CONSTRAINT [PK_DenominationMapWithTrans]
    PRIMARY KEY CLUSTERED ([DenominationMapID] ASC);
GO

-- Creating primary key on [DeptID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([DeptID] ASC);
GO

-- Creating primary key on [PurDiscId] in table 'DiscountsExpenseDetails'
ALTER TABLE [dbo].[DiscountsExpenseDetails]
ADD CONSTRAINT [PK_DiscountsExpenseDetails]
    PRIMARY KEY CLUSTERED ([PurDiscId] ASC);
GO

-- Creating primary key on [ID] in table 'DiscrepencyDetails'
ALTER TABLE [dbo].[DiscrepencyDetails]
ADD CONSTRAINT [PK_DiscrepencyDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'DocumentsLists'
ALTER TABLE [dbo].[DocumentsLists]
ADD CONSTRAINT [PK_DocumentsLists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'DocumentsSettings'
ALTER TABLE [dbo].[DocumentsSettings]
ADD CONSTRAINT [PK_DocumentsSettings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DocumentUploads'
ALTER TABLE [dbo].[DocumentUploads]
ADD CONSTRAINT [PK_DocumentUploads]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [FranchiseID] in table 'FranchiseMarginDetails'
ALTER TABLE [dbo].[FranchiseMarginDetails]
ADD CONSTRAINT [PK_FranchiseMarginDetails]
    PRIMARY KEY CLUSTERED ([FranchiseID] ASC);
GO

-- Creating primary key on [FreightRateId] in table 'FreightExpenseDetails'
ALTER TABLE [dbo].[FreightExpenseDetails]
ADD CONSTRAINT [PK_FreightExpenseDetails]
    PRIMARY KEY CLUSTERED ([FreightRateId] ASC);
GO

-- Creating primary key on [FuminID] in table 'FumigationDetails'
ALTER TABLE [dbo].[FumigationDetails]
ADD CONSTRAINT [PK_FumigationDetails]
    PRIMARY KEY CLUSTERED ([FuminID] ASC);
GO

-- Creating primary key on [ID] in table 'FumigationItemWrhsDetails'
ALTER TABLE [dbo].[FumigationItemWrhsDetails]
ADD CONSTRAINT [PK_FumigationItemWrhsDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FuturisticBusinessTypes'
ALTER TABLE [dbo].[FuturisticBusinessTypes]
ADD CONSTRAINT [PK_FuturisticBusinessTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FuturisticCreditTypes'
ALTER TABLE [dbo].[FuturisticCreditTypes]
ADD CONSTRAINT [PK_FuturisticCreditTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [FID] in table 'FuturisticItemThresholdQties'
ALTER TABLE [dbo].[FuturisticItemThresholdQties]
ADD CONSTRAINT [PK_FuturisticItemThresholdQties]
    PRIMARY KEY CLUSTERED ([FID] ASC);
GO

-- Creating primary key on [Id] in table 'ItemThresholdQtyDetails'
ALTER TABLE [dbo].[ItemThresholdQtyDetails]
ADD CONSTRAINT [PK_ItemThresholdQtyDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'LedgersOpeningBalances'
ALTER TABLE [dbo].[LedgersOpeningBalances]
ADD CONSTRAINT [PK_LedgersOpeningBalances]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [OffersID] in table 'OfferPriceDetails'
ALTER TABLE [dbo].[OfferPriceDetails]
ADD CONSTRAINT [PK_OfferPriceDetails]
    PRIMARY KEY CLUSTERED ([OffersID] ASC);
GO

-- Creating primary key on [TransID] in table 'RateTransactionDetails'
ALTER TABLE [dbo].[RateTransactionDetails]
ADD CONSTRAINT [PK_RateTransactionDetails]
    PRIMARY KEY CLUSTERED ([TransID] ASC);
GO

-- Creating primary key on [ID] in table 'SalesManAreaMappingChilds'
ALTER TABLE [dbo].[SalesManAreaMappingChilds]
ADD CONSTRAINT [PK_SalesManAreaMappingChilds]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [SalesManID] in table 'SalesManAreaMappingParents'
ALTER TABLE [dbo].[SalesManAreaMappingParents]
ADD CONSTRAINT [PK_SalesManAreaMappingParents]
    PRIMARY KEY CLUSTERED ([SalesManID] ASC);
GO

-- Creating primary key on [AccessRightsID] in table 'tblAccessRights'
ALTER TABLE [dbo].[tblAccessRights]
ADD CONSTRAINT [PK_tblAccessRights]
    PRIMARY KEY CLUSTERED ([AccessRightsID] ASC);
GO

-- Creating primary key on [ContraWithBillID] in table 'tblAccountContraBillWithDetails'
ALTER TABLE [dbo].[tblAccountContraBillWithDetails]
ADD CONSTRAINT [PK_tblAccountContraBillWithDetails]
    PRIMARY KEY CLUSTERED ([ContraWithBillID] ASC);
GO

-- Creating primary key on [ContraID] in table 'tblAccountContraDetails'
ALTER TABLE [dbo].[tblAccountContraDetails]
ADD CONSTRAINT [PK_tblAccountContraDetails]
    PRIMARY KEY CLUSTERED ([ContraID] ASC);
GO

-- Creating primary key on [CreditNoteID] in table 'tblAccountCreditNoteDetails'
ALTER TABLE [dbo].[tblAccountCreditNoteDetails]
ADD CONSTRAINT [PK_tblAccountCreditNoteDetails]
    PRIMARY KEY CLUSTERED ([CreditNoteID] ASC);
GO

-- Creating primary key on [ID] in table 'tblAccountCreditNoteItemDetails'
ALTER TABLE [dbo].[tblAccountCreditNoteItemDetails]
ADD CONSTRAINT [PK_tblAccountCreditNoteItemDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CreditNoteWithBillID] in table 'tblAccountCreditNoteWithBillDetails'
ALTER TABLE [dbo].[tblAccountCreditNoteWithBillDetails]
ADD CONSTRAINT [PK_tblAccountCreditNoteWithBillDetails]
    PRIMARY KEY CLUSTERED ([CreditNoteWithBillID] ASC);
GO

-- Creating primary key on [DebitNoteID] in table 'tblAccountDebitNoteDetails'
ALTER TABLE [dbo].[tblAccountDebitNoteDetails]
ADD CONSTRAINT [PK_tblAccountDebitNoteDetails]
    PRIMARY KEY CLUSTERED ([DebitNoteID] ASC);
GO

-- Creating primary key on [ID] in table 'tblAccountDebitNoteItemDetails'
ALTER TABLE [dbo].[tblAccountDebitNoteItemDetails]
ADD CONSTRAINT [PK_tblAccountDebitNoteItemDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [DebitNoteWithBillID] in table 'tblAccountDebitNoteWithBillDetails'
ALTER TABLE [dbo].[tblAccountDebitNoteWithBillDetails]
ADD CONSTRAINT [PK_tblAccountDebitNoteWithBillDetails]
    PRIMARY KEY CLUSTERED ([DebitNoteWithBillID] ASC);
GO

-- Creating primary key on [AccountGroup] in table 'tblAccountGroups'
ALTER TABLE [dbo].[tblAccountGroups]
ADD CONSTRAINT [PK_tblAccountGroups]
    PRIMARY KEY CLUSTERED ([AccountGroup] ASC);
GO

-- Creating primary key on [AccountGroupMasterID] in table 'tblAccountGroupMasters'
ALTER TABLE [dbo].[tblAccountGroupMasters]
ADD CONSTRAINT [PK_tblAccountGroupMasters]
    PRIMARY KEY CLUSTERED ([AccountGroupMasterID] ASC);
GO

-- Creating primary key on [LedgerID] in table 'tblAccountLedgers'
ALTER TABLE [dbo].[tblAccountLedgers]
ADD CONSTRAINT [PK_tblAccountLedgers]
    PRIMARY KEY CLUSTERED ([LedgerID] ASC);
GO

-- Creating primary key on [PaymentID] in table 'tblAccountPaymentDetails'
ALTER TABLE [dbo].[tblAccountPaymentDetails]
ADD CONSTRAINT [PK_tblAccountPaymentDetails]
    PRIMARY KEY CLUSTERED ([PaymentID] ASC);
GO

-- Creating primary key on [ID] in table 'tblAccountPaymentWithBillDetails'
ALTER TABLE [dbo].[tblAccountPaymentWithBillDetails]
ADD CONSTRAINT [PK_tblAccountPaymentWithBillDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ReceiptID] in table 'tblAccountReceiptDetails'
ALTER TABLE [dbo].[tblAccountReceiptDetails]
ADD CONSTRAINT [PK_tblAccountReceiptDetails]
    PRIMARY KEY CLUSTERED ([ReceiptID] ASC);
GO

-- Creating primary key on [ID] in table 'tblAccountReceiptWithBillDetails'
ALTER TABLE [dbo].[tblAccountReceiptWithBillDetails]
ADD CONSTRAINT [PK_tblAccountReceiptWithBillDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ActivityID] in table 'tblActivities'
ALTER TABLE [dbo].[tblActivities]
ADD CONSTRAINT [PK_tblActivities]
    PRIMARY KEY CLUSTERED ([ActivityID] ASC);
GO

-- Creating primary key on [AdminConfigurationID] in table 'tblAdminConfigurations'
ALTER TABLE [dbo].[tblAdminConfigurations]
ADD CONSTRAINT [PK_tblAdminConfigurations]
    PRIMARY KEY CLUSTERED ([AdminConfigurationID] ASC);
GO

-- Creating primary key on [AreaID] in table 'tblAreas'
ALTER TABLE [dbo].[tblAreas]
ADD CONSTRAINT [PK_tblAreas]
    PRIMARY KEY CLUSTERED ([AreaID] ASC);
GO

-- Creating primary key on [BatchID] in table 'tblBatches'
ALTER TABLE [dbo].[tblBatches]
ADD CONSTRAINT [PK_tblBatches]
    PRIMARY KEY CLUSTERED ([BatchID] ASC);
GO

-- Creating primary key on [BrandID] in table 'tblBrands'
ALTER TABLE [dbo].[tblBrands]
ADD CONSTRAINT [PK_tblBrands]
    PRIMARY KEY CLUSTERED ([BrandID] ASC);
GO

-- Creating primary key on [CartID] in table 'tblCarts'
ALTER TABLE [dbo].[tblCarts]
ADD CONSTRAINT [PK_tblCarts]
    PRIMARY KEY CLUSTERED ([CartID] ASC);
GO

-- Creating primary key on [ID] in table 'tblCartItems'
ALTER TABLE [dbo].[tblCartItems]
ADD CONSTRAINT [PK_tblCartItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'tblCategories'
ALTER TABLE [dbo].[tblCategories]
ADD CONSTRAINT [PK_tblCategories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [CategoryTypeID] in table 'tblCategoryTypes'
ALTER TABLE [dbo].[tblCategoryTypes]
ADD CONSTRAINT [PK_tblCategoryTypes]
    PRIMARY KEY CLUSTERED ([CategoryTypeID] ASC);
GO

-- Creating primary key on [ID] in table 'tblChannelPartnerMappings'
ALTER TABLE [dbo].[tblChannelPartnerMappings]
ADD CONSTRAINT [PK_tblChannelPartnerMappings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CityID] in table 'tblCities'
ALTER TABLE [dbo].[tblCities]
ADD CONSTRAINT [PK_tblCities]
    PRIMARY KEY CLUSTERED ([CityID] ASC);
GO

-- Creating primary key on [CompanyTypeID] in table 'tblCompanyTypes'
ALTER TABLE [dbo].[tblCompanyTypes]
ADD CONSTRAINT [PK_tblCompanyTypes]
    PRIMARY KEY CLUSTERED ([CompanyTypeID] ASC);
GO

-- Creating primary key on [ID] in table 'tblCountries'
ALTER TABLE [dbo].[tblCountries]
ADD CONSTRAINT [PK_tblCountries]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [CustomerCreditDetailID] in table 'tblCustomerCreditDetails'
ALTER TABLE [dbo].[tblCustomerCreditDetails]
ADD CONSTRAINT [PK_tblCustomerCreditDetails]
    PRIMARY KEY CLUSTERED ([CustomerCreditDetailID] ASC);
GO

-- Creating primary key on [CustomerTypeID] in table 'tblCustomerTypes'
ALTER TABLE [dbo].[tblCustomerTypes]
ADD CONSTRAINT [PK_tblCustomerTypes]
    PRIMARY KEY CLUSTERED ([CustomerTypeID] ASC);
GO

-- Creating primary key on [CustID] in table 'tblCustomerVendorDetails'
ALTER TABLE [dbo].[tblCustomerVendorDetails]
ADD CONSTRAINT [PK_tblCustomerVendorDetails]
    PRIMARY KEY CLUSTERED ([CustID] ASC);
GO

-- Creating primary key on [AreaID] in table 'tblDebtorsAreaDetails'
ALTER TABLE [dbo].[tblDebtorsAreaDetails]
ADD CONSTRAINT [PK_tblDebtorsAreaDetails]
    PRIMARY KEY CLUSTERED ([AreaID] ASC);
GO

-- Creating primary key on [ID] in table 'tblDebtorsDetails'
ALTER TABLE [dbo].[tblDebtorsDetails]
ADD CONSTRAINT [PK_tblDebtorsDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [PlaceID] in table 'tblDebtorsPlaceDetails'
ALTER TABLE [dbo].[tblDebtorsPlaceDetails]
ADD CONSTRAINT [PK_tblDebtorsPlaceDetails]
    PRIMARY KEY CLUSTERED ([PlaceID] ASC);
GO

-- Creating primary key on [DeliveryNoteCode] in table 'tblDeliveryNotes'
ALTER TABLE [dbo].[tblDeliveryNotes]
ADD CONSTRAINT [PK_tblDeliveryNotes]
    PRIMARY KEY CLUSTERED ([DeliveryNoteCode] ASC);
GO

-- Creating primary key on [ID] in table 'tblDeliveryNoteItems'
ALTER TABLE [dbo].[tblDeliveryNoteItems]
ADD CONSTRAINT [PK_tblDeliveryNoteItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [DeptID] in table 'tblDepartments'
ALTER TABLE [dbo].[tblDepartments]
ADD CONSTRAINT [PK_tblDepartments]
    PRIMARY KEY CLUSTERED ([DeptID] ASC);
GO

-- Creating primary key on [DiscountID] in table 'tblDiscounts'
ALTER TABLE [dbo].[tblDiscounts]
ADD CONSTRAINT [PK_tblDiscounts]
    PRIMARY KEY CLUSTERED ([DiscountID] ASC);
GO

-- Creating primary key on [DistrictID] in table 'tblDistricts'
ALTER TABLE [dbo].[tblDistricts]
ADD CONSTRAINT [PK_tblDistricts]
    PRIMARY KEY CLUSTERED ([DistrictID] ASC);
GO

-- Creating primary key on [GatePassCode] in table 'tblGatePasses'
ALTER TABLE [dbo].[tblGatePasses]
ADD CONSTRAINT [PK_tblGatePasses]
    PRIMARY KEY CLUSTERED ([GatePassCode] ASC);
GO

-- Creating primary key on [ID] in table 'tblGatePassItems'
ALTER TABLE [dbo].[tblGatePassItems]
ADD CONSTRAINT [PK_tblGatePassItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [GINID] in table 'tblGoodsInwardNotes'
ALTER TABLE [dbo].[tblGoodsInwardNotes]
ADD CONSTRAINT [PK_tblGoodsInwardNotes]
    PRIMARY KEY CLUSTERED ([GINID] ASC);
GO

-- Creating primary key on [GINItemId] in table 'tblGoodsInwardNoteItems'
ALTER TABLE [dbo].[tblGoodsInwardNoteItems]
ADD CONSTRAINT [PK_tblGoodsInwardNoteItems]
    PRIMARY KEY CLUSTERED ([GINItemId] ASC);
GO

-- Creating primary key on [GRNNumber] in table 'tblGRNs'
ALTER TABLE [dbo].[tblGRNs]
ADD CONSTRAINT [PK_tblGRNs]
    PRIMARY KEY CLUSTERED ([GRNNumber] ASC);
GO

-- Creating primary key on [GRNItemsID] in table 'tblGRNItems'
ALTER TABLE [dbo].[tblGRNItems]
ADD CONSTRAINT [PK_tblGRNItems]
    PRIMARY KEY CLUSTERED ([GRNItemsID] ASC);
GO

-- Creating primary key on [HOBranchPriceDetailsID] in table 'tblHOBranchPriceDetails'
ALTER TABLE [dbo].[tblHOBranchPriceDetails]
ADD CONSTRAINT [PK_tblHOBranchPriceDetails]
    PRIMARY KEY CLUSTERED ([HOBranchPriceDetailsID] ASC);
GO

-- Creating primary key on [HOMasterPriceDetailsID] in table 'tblHOMasterPriceDetails'
ALTER TABLE [dbo].[tblHOMasterPriceDetails]
ADD CONSTRAINT [PK_tblHOMasterPriceDetails]
    PRIMARY KEY CLUSTERED ([HOMasterPriceDetailsID] ASC);
GO

-- Creating primary key on [HSNID] in table 'tblHSNCodes'
ALTER TABLE [dbo].[tblHSNCodes]
ADD CONSTRAINT [PK_tblHSNCodes]
    PRIMARY KEY CLUSTERED ([HSNID] ASC);
GO

-- Creating primary key on [ItemCode] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [PK_tblItems]
    PRIMARY KEY CLUSTERED ([ItemCode] ASC);
GO

-- Creating primary key on [ItemCompanyID] in table 'tblItemCompanies'
ALTER TABLE [dbo].[tblItemCompanies]
ADD CONSTRAINT [PK_tblItemCompanies]
    PRIMARY KEY CLUSTERED ([ItemCompanyID] ASC);
GO

-- Creating primary key on [ID] in table 'tblItemImageDetails'
ALTER TABLE [dbo].[tblItemImageDetails]
ADD CONSTRAINT [PK_tblItemImageDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ItemMappingID] in table 'tblItemMappings'
ALTER TABLE [dbo].[tblItemMappings]
ADD CONSTRAINT [PK_tblItemMappings]
    PRIMARY KEY CLUSTERED ([ItemMappingID] ASC);
GO

-- Creating primary key on [ItemMapCESSID] in table 'tblItemMappingWithCESSes'
ALTER TABLE [dbo].[tblItemMappingWithCESSes]
ADD CONSTRAINT [PK_tblItemMappingWithCESSes]
    PRIMARY KEY CLUSTERED ([ItemMapCESSID] ASC);
GO

-- Creating primary key on [ID] in table 'tblItemMovements'
ALTER TABLE [dbo].[tblItemMovements]
ADD CONSTRAINT [PK_tblItemMovements]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ItemParameterMapID] in table 'tblItemParameterMaps'
ALTER TABLE [dbo].[tblItemParameterMaps]
ADD CONSTRAINT [PK_tblItemParameterMaps]
    PRIMARY KEY CLUSTERED ([ItemParameterMapID] ASC);
GO

-- Creating primary key on [RateID] in table 'tblItemRates'
ALTER TABLE [dbo].[tblItemRates]
ADD CONSTRAINT [PK_tblItemRates]
    PRIMARY KEY CLUSTERED ([RateID] ASC);
GO

-- Creating primary key on [ItemStockTransferDestinationID] in table 'tblItemStockTransferDestinations'
ALTER TABLE [dbo].[tblItemStockTransferDestinations]
ADD CONSTRAINT [PK_tblItemStockTransferDestinations]
    PRIMARY KEY CLUSTERED ([ItemStockTransferDestinationID] ASC);
GO

-- Creating primary key on [ItemStockTransferHeaderID] in table 'tblItemStockTransferHeaders'
ALTER TABLE [dbo].[tblItemStockTransferHeaders]
ADD CONSTRAINT [PK_tblItemStockTransferHeaders]
    PRIMARY KEY CLUSTERED ([ItemStockTransferHeaderID] ASC);
GO

-- Creating primary key on [ItemStockTransferSourceID] in table 'tblItemStockTransferSources'
ALTER TABLE [dbo].[tblItemStockTransferSources]
ADD CONSTRAINT [PK_tblItemStockTransferSources]
    PRIMARY KEY CLUSTERED ([ItemStockTransferSourceID] ASC);
GO

-- Creating primary key on [ItemSupMappingID] in table 'tblItemSupplierMappings'
ALTER TABLE [dbo].[tblItemSupplierMappings]
ADD CONSTRAINT [PK_tblItemSupplierMappings]
    PRIMARY KEY CLUSTERED ([ItemSupMappingID] ASC);
GO

-- Creating primary key on [ItemTrackingID] in table 'tblItemToItemTrackings'
ALTER TABLE [dbo].[tblItemToItemTrackings]
ADD CONSTRAINT [PK_tblItemToItemTrackings]
    PRIMARY KEY CLUSTERED ([ItemTrackingID] ASC);
GO

-- Creating primary key on [ItemWarehouseMapID] in table 'tblItemWarehouseMaps'
ALTER TABLE [dbo].[tblItemWarehouseMaps]
ADD CONSTRAINT [PK_tblItemWarehouseMaps]
    PRIMARY KEY CLUSTERED ([ItemWarehouseMapID] ASC);
GO

-- Creating primary key on [LedgerTypeID] in table 'tblLedgerTypes'
ALTER TABLE [dbo].[tblLedgerTypes]
ADD CONSTRAINT [PK_tblLedgerTypes]
    PRIMARY KEY CLUSTERED ([LedgerTypeID] ASC);
GO

-- Creating primary key on [NotificationID] in table 'tblNotifications'
ALTER TABLE [dbo].[tblNotifications]
ADD CONSTRAINT [PK_tblNotifications]
    PRIMARY KEY CLUSTERED ([NotificationID] ASC);
GO

-- Creating primary key on [OrganizationWarehouseMapID] in table 'tblOrganizationWarehouseMaps'
ALTER TABLE [dbo].[tblOrganizationWarehouseMaps]
ADD CONSTRAINT [PK_tblOrganizationWarehouseMaps]
    PRIMARY KEY CLUSTERED ([OrganizationWarehouseMapID] ASC);
GO

-- Creating primary key on [PacketSizeID] in table 'tblPacketSizeDetails'
ALTER TABLE [dbo].[tblPacketSizeDetails]
ADD CONSTRAINT [PK_tblPacketSizeDetails]
    PRIMARY KEY CLUSTERED ([PacketSizeID] ASC);
GO

-- Creating primary key on [ParameterID] in table 'tblParameters'
ALTER TABLE [dbo].[tblParameters]
ADD CONSTRAINT [PK_tblParameters]
    PRIMARY KEY CLUSTERED ([ParameterID] ASC);
GO

-- Creating primary key on [ID] in table 'tblPaymentReceipts'
ALTER TABLE [dbo].[tblPaymentReceipts]
ADD CONSTRAINT [PK_tblPaymentReceipts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [pcndeatils_idpk] in table 'tblPCN_Details'
ALTER TABLE [dbo].[tblPCN_Details]
ADD CONSTRAINT [PK_tblPCN_Details]
    PRIMARY KEY CLUSTERED ([pcndeatils_idpk] ASC);
GO

-- Creating primary key on [PercStrctureID] in table 'tblPercentageStructures'
ALTER TABLE [dbo].[tblPercentageStructures]
ADD CONSTRAINT [PK_tblPercentageStructures]
    PRIMARY KEY CLUSTERED ([PercStrctureID] ASC);
GO

-- Creating primary key on [pcn_num] in table 'tblPNCNs'
ALTER TABLE [dbo].[tblPNCNs]
ADD CONSTRAINT [PK_tblPNCNs]
    PRIMARY KEY CLUSTERED ([pcn_num] ASC);
GO

-- Creating primary key on [POQuotationID] in table 'tblPOQuotations'
ALTER TABLE [dbo].[tblPOQuotations]
ADD CONSTRAINT [PK_tblPOQuotations]
    PRIMARY KEY CLUSTERED ([POQuotationID] ASC);
GO

-- Creating primary key on [POQuotationSupID] in table 'tblPOQuotationSuppliers'
ALTER TABLE [dbo].[tblPOQuotationSuppliers]
ADD CONSTRAINT [PK_tblPOQuotationSuppliers]
    PRIMARY KEY CLUSTERED ([POQuotationSupID] ASC);
GO

-- Creating primary key on [ItemCode] in table 'tblProcessitem_Master'
ALTER TABLE [dbo].[tblProcessitem_Master]
ADD CONSTRAINT [PK_tblProcessitem_Master]
    PRIMARY KEY CLUSTERED ([ItemCode] ASC);
GO

-- Creating primary key on [PurchaseOrderNumber] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [PK_tblPurchaseOrders]
    PRIMARY KEY CLUSTERED ([PurchaseOrderNumber] ASC);
GO

-- Creating primary key on [POInvoiceReferenceNumber] in table 'tblPurchaseOrderInvoices'
ALTER TABLE [dbo].[tblPurchaseOrderInvoices]
ADD CONSTRAINT [PK_tblPurchaseOrderInvoices]
    PRIMARY KEY CLUSTERED ([POInvoiceReferenceNumber] ASC);
GO

-- Creating primary key on [ID] in table 'tblPurchaseOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetails]
ADD CONSTRAINT [PK_tblPurchaseOrderInvoiceItemDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblPurchaseOrderWithItems'
ALTER TABLE [dbo].[tblPurchaseOrderWithItems]
ADD CONSTRAINT [PK_tblPurchaseOrderWithItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [RequisitionNumber] in table 'tblPurchaseRequisitions'
ALTER TABLE [dbo].[tblPurchaseRequisitions]
ADD CONSTRAINT [PK_tblPurchaseRequisitions]
    PRIMARY KEY CLUSTERED ([RequisitionNumber] ASC);
GO

-- Creating primary key on [ItemDetailsReqNumber] in table 'tblPurchaseRequisitionItemsDetails'
ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetails]
ADD CONSTRAINT [PK_tblPurchaseRequisitionItemsDetails]
    PRIMARY KEY CLUSTERED ([ItemDetailsReqNumber] ASC);
GO

-- Creating primary key on [RackID] in table 'tblRacks'
ALTER TABLE [dbo].[tblRacks]
ADD CONSTRAINT [PK_tblRacks]
    PRIMARY KEY CLUSTERED ([RackID] ASC);
GO

-- Creating primary key on [ReasonID] in table 'tblReasons'
ALTER TABLE [dbo].[tblReasons]
ADD CONSTRAINT [PK_tblReasons]
    PRIMARY KEY CLUSTERED ([ReasonID] ASC);
GO

-- Creating primary key on [ID], [ReceiptID] in table 'tblReceiptDetails'
ALTER TABLE [dbo].[tblReceiptDetails]
ADD CONSTRAINT [PK_tblReceiptDetails]
    PRIMARY KEY CLUSTERED ([ID], [ReceiptID] ASC);
GO

-- Creating primary key on [ID] in table 'tblReceiptWithBillDetails'
ALTER TABLE [dbo].[tblReceiptWithBillDetails]
ADD CONSTRAINT [PK_tblReceiptWithBillDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblRouteMappings'
ALTER TABLE [dbo].[tblRouteMappings]
ADD CONSTRAINT [PK_tblRouteMappings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblRouteMappingDetails'
ALTER TABLE [dbo].[tblRouteMappingDetails]
ADD CONSTRAINT [PK_tblRouteMappingDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblSalesChannelTypes'
ALTER TABLE [dbo].[tblSalesChannelTypes]
ADD CONSTRAINT [PK_tblSalesChannelTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [SalesManID] in table 'tblSalesmanDetails'
ALTER TABLE [dbo].[tblSalesmanDetails]
ADD CONSTRAINT [PK_tblSalesmanDetails]
    PRIMARY KEY CLUSTERED ([SalesManID] ASC);
GO

-- Creating primary key on [SalesOrderNumber] in table 'tblSalesOrders'
ALTER TABLE [dbo].[tblSalesOrders]
ADD CONSTRAINT [PK_tblSalesOrders]
    PRIMARY KEY CLUSTERED ([SalesOrderNumber] ASC);
GO

-- Creating primary key on [ID] in table 'tblSalesOrderCashTransactions'
ALTER TABLE [dbo].[tblSalesOrderCashTransactions]
ADD CONSTRAINT [PK_tblSalesOrderCashTransactions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [SOInvoiceReferenceNumber] in table 'tblSalesOrderInvoices'
ALTER TABLE [dbo].[tblSalesOrderInvoices]
ADD CONSTRAINT [PK_tblSalesOrderInvoices]
    PRIMARY KEY CLUSTERED ([SOInvoiceReferenceNumber] ASC);
GO

-- Creating primary key on [ID] in table 'tblSalesOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetails]
ADD CONSTRAINT [PK_tblSalesOrderInvoiceItemDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblSalesOrderItemWarehouseMaps'
ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMaps]
ADD CONSTRAINT [PK_tblSalesOrderItemWarehouseMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [SalesOrderWithItemID] in table 'tblSalesOrderWithItems'
ALTER TABLE [dbo].[tblSalesOrderWithItems]
ADD CONSTRAINT [PK_tblSalesOrderWithItems]
    PRIMARY KEY CLUSTERED ([SalesOrderWithItemID] ASC);
GO

-- Creating primary key on [ID] in table 'tblSPDocuments'
ALTER TABLE [dbo].[tblSPDocuments]
ADD CONSTRAINT [PK_tblSPDocuments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [StateID] in table 'tblStates'
ALTER TABLE [dbo].[tblStates]
ADD CONSTRAINT [PK_tblStates]
    PRIMARY KEY CLUSTERED ([StateID] ASC);
GO

-- Creating primary key on [StatewithCityID] in table 'tblStateWithCities'
ALTER TABLE [dbo].[tblStateWithCities]
ADD CONSTRAINT [PK_tblStateWithCities]
    PRIMARY KEY CLUSTERED ([StatewithCityID] ASC);
GO

-- Creating primary key on [StickerId] in table 'tblStickerDetails'
ALTER TABLE [dbo].[tblStickerDetails]
ADD CONSTRAINT [PK_tblStickerDetails]
    PRIMARY KEY CLUSTERED ([StickerId] ASC);
GO

-- Creating primary key on [StockTransferHeaderID] in table 'tblStockTransferHeaders'
ALTER TABLE [dbo].[tblStockTransferHeaders]
ADD CONSTRAINT [PK_tblStockTransferHeaders]
    PRIMARY KEY CLUSTERED ([StockTransferHeaderID] ASC);
GO

-- Creating primary key on [StockTransferLineItemID] in table 'tblStockTransferLineItems'
ALTER TABLE [dbo].[tblStockTransferLineItems]
ADD CONSTRAINT [PK_tblStockTransferLineItems]
    PRIMARY KEY CLUSTERED ([StockTransferLineItemID] ASC);
GO

-- Creating primary key on [SubAccountGroupMasterID] in table 'tblSubAccountGroupMasters'
ALTER TABLE [dbo].[tblSubAccountGroupMasters]
ADD CONSTRAINT [PK_tblSubAccountGroupMasters]
    PRIMARY KEY CLUSTERED ([SubAccountGroupMasterID] ASC);
GO

-- Creating primary key on [SubCategoryID] in table 'tblSubCategories'
ALTER TABLE [dbo].[tblSubCategories]
ADD CONSTRAINT [PK_tblSubCategories]
    PRIMARY KEY CLUSTERED ([SubCategoryID] ASC);
GO

-- Creating primary key on [ID] in table 'tblSubMenuRoleMaps'
ALTER TABLE [dbo].[tblSubMenuRoleMaps]
ADD CONSTRAINT [PK_tblSubMenuRoleMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [BranchID] in table 'tblSysBranches'
ALTER TABLE [dbo].[tblSysBranches]
ADD CONSTRAINT [PK_tblSysBranches]
    PRIMARY KEY CLUSTERED ([BranchID] ASC);
GO

-- Creating primary key on [MainMenuID] in table 'tblSysMainMenus'
ALTER TABLE [dbo].[tblSysMainMenus]
ADD CONSTRAINT [PK_tblSysMainMenus]
    PRIMARY KEY CLUSTERED ([MainMenuID] ASC);
GO

-- Creating primary key on [OrgID] in table 'tblSysOrganizations'
ALTER TABLE [dbo].[tblSysOrganizations]
ADD CONSTRAINT [PK_tblSysOrganizations]
    PRIMARY KEY CLUSTERED ([OrgID] ASC);
GO

-- Creating primary key on [ID] in table 'tblSysOrganizationMaps'
ALTER TABLE [dbo].[tblSysOrganizationMaps]
ADD CONSTRAINT [PK_tblSysOrganizationMaps]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [RoleID] in table 'tblSysRoles'
ALTER TABLE [dbo].[tblSysRoles]
ADD CONSTRAINT [PK_tblSysRoles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [SubMenuID] in table 'tblSysSubMenus'
ALTER TABLE [dbo].[tblSysSubMenus]
ADD CONSTRAINT [PK_tblSysSubMenus]
    PRIMARY KEY CLUSTERED ([SubMenuID] ASC);
GO

-- Creating primary key on [SystemID] in table 'tblSystemDetails'
ALTER TABLE [dbo].[tblSystemDetails]
ADD CONSTRAINT [PK_tblSystemDetails]
    PRIMARY KEY CLUSTERED ([SystemID] ASC);
GO

-- Creating primary key on [UserID] in table 'tblSysUsers'
ALTER TABLE [dbo].[tblSysUsers]
ADD CONSTRAINT [PK_tblSysUsers]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [TaxationTypeID] in table 'tblTaxationTypes'
ALTER TABLE [dbo].[tblTaxationTypes]
ADD CONSTRAINT [PK_tblTaxationTypes]
    PRIMARY KEY CLUSTERED ([TaxationTypeID] ASC);
GO

-- Creating primary key on [TaxCESSID] in table 'tblTaxCESSes'
ALTER TABLE [dbo].[tblTaxCESSes]
ADD CONSTRAINT [PK_tblTaxCESSes]
    PRIMARY KEY CLUSTERED ([TaxCESSID] ASC);
GO

-- Creating primary key on [ID] in table 'tblTransitItems'
ALTER TABLE [dbo].[tblTransitItems]
ADD CONSTRAINT [PK_tblTransitItems]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblTransitItemDetails'
ALTER TABLE [dbo].[tblTransitItemDetails]
ADD CONSTRAINT [PK_tblTransitItemDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UnitQuantityID] in table 'tblUnitQuantities'
ALTER TABLE [dbo].[tblUnitQuantities]
ADD CONSTRAINT [PK_tblUnitQuantities]
    PRIMARY KEY CLUSTERED ([UnitQuantityID] ASC);
GO

-- Creating primary key on [UnitID] in table 'tblUOMs'
ALTER TABLE [dbo].[tblUOMs]
ADD CONSTRAINT [PK_tblUOMs]
    PRIMARY KEY CLUSTERED ([UnitID] ASC);
GO

-- Creating primary key on [ID] in table 'tblUserAreaofServices'
ALTER TABLE [dbo].[tblUserAreaofServices]
ADD CONSTRAINT [PK_tblUserAreaofServices]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblUserDocuments'
ALTER TABLE [dbo].[tblUserDocuments]
ADD CONSTRAINT [PK_tblUserDocuments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblUserMappings'
ALTER TABLE [dbo].[tblUserMappings]
ADD CONSTRAINT [PK_tblUserMappings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserWarehouseMapID] in table 'tblUserWarehouseMaps'
ALTER TABLE [dbo].[tblUserWarehouseMaps]
ADD CONSTRAINT [PK_tblUserWarehouseMaps]
    PRIMARY KEY CLUSTERED ([UserWarehouseMapID] ASC);
GO

-- Creating primary key on [VoucherTypeNo] in table 'tblVoucherTypes'
ALTER TABLE [dbo].[tblVoucherTypes]
ADD CONSTRAINT [PK_tblVoucherTypes]
    PRIMARY KEY CLUSTERED ([VoucherTypeNo] ASC);
GO

-- Creating primary key on [WarehouseID] in table 'tblWarehouses'
ALTER TABLE [dbo].[tblWarehouses]
ADD CONSTRAINT [PK_tblWarehouses]
    PRIMARY KEY CLUSTERED ([WarehouseID] ASC);
GO

-- Creating primary key on [WarehouseTrackingID] in table 'tblWarehouseToWarehouseTrackings'
ALTER TABLE [dbo].[tblWarehouseToWarehouseTrackings]
ADD CONSTRAINT [PK_tblWarehouseToWarehouseTrackings]
    PRIMARY KEY CLUSTERED ([WarehouseTrackingID] ASC);
GO

-- Creating primary key on [ExpsId] in table 'TypeOfExpenses'
ALTER TABLE [dbo].[TypeOfExpenses]
ADD CONSTRAINT [PK_TypeOfExpenses]
    PRIMARY KEY CLUSTERED ([ExpsId] ASC);
GO

-- Creating primary key on [VID] in table 'VirtualWarehouseDetails'
ALTER TABLE [dbo].[VirtualWarehouseDetails]
ADD CONSTRAINT [PK_VirtualWarehouseDetails]
    PRIMARY KEY CLUSTERED ([VID] ASC);
GO

-- Creating primary key on [PlanID] in table 'tblPlans'
ALTER TABLE [dbo].[tblPlans]
ADD CONSTRAINT [PK_tblPlans]
    PRIMARY KEY CLUSTERED ([PlanID] ASC);
GO

-- Creating primary key on [ChannelPartnerID] in table 'tblSysChannelPartners'
ALTER TABLE [dbo].[tblSysChannelPartners]
ADD CONSTRAINT [PK_tblSysChannelPartners]
    PRIMARY KEY CLUSTERED ([ChannelPartnerID] ASC);
GO

-- Creating primary key on [AccessControlID] in table 'tblAccessControls'
ALTER TABLE [dbo].[tblAccessControls]
ADD CONSTRAINT [PK_tblAccessControls]
    PRIMARY KEY CLUSTERED ([AccessControlID] ASC);
GO

-- Creating primary key on [AccessControlItemID] in table 'tblAccessControlItems'
ALTER TABLE [dbo].[tblAccessControlItems]
ADD CONSTRAINT [PK_tblAccessControlItems]
    PRIMARY KEY CLUSTERED ([AccessControlItemID] ASC);
GO

-- Creating primary key on [ID] in table 'tblAdminSettings'
ALTER TABLE [dbo].[tblAdminSettings]
ADD CONSTRAINT [PK_tblAdminSettings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblBranchDocuments'
ALTER TABLE [dbo].[tblBranchDocuments]
ADD CONSTRAINT [PK_tblBranchDocuments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblEmailTemplates'
ALTER TABLE [dbo].[tblEmailTemplates]
ADD CONSTRAINT [PK_tblEmailTemplates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblSMSTemplates'
ALTER TABLE [dbo].[tblSMSTemplates]
ADD CONSTRAINT [PK_tblSMSTemplates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblWhatsappTemplates'
ALTER TABLE [dbo].[tblWhatsappTemplates]
ADD CONSTRAINT [PK_tblWhatsappTemplates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblTemplateImages'
ALTER TABLE [dbo].[tblTemplateImages]
ADD CONSTRAINT [PK_tblTemplateImages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblUserTemplates'
ALTER TABLE [dbo].[tblUserTemplates]
ADD CONSTRAINT [PK_tblUserTemplates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tblOrgSystemDetails'
ALTER TABLE [dbo].[tblOrgSystemDetails]
ADD CONSTRAINT [PK_tblOrgSystemDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ItemCode] in table 'BasicExpensesDetails'
ALTER TABLE [dbo].[BasicExpensesDetails]
ADD CONSTRAINT [FK_Itbltem_BasicExpensesDetails]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_BasicExpensesDetails'
CREATE INDEX [IX_FK_Itbltem_BasicExpensesDetails]
ON [dbo].[BasicExpensesDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [BranchID] in table 'BasicExpensesDetails'
ALTER TABLE [dbo].[BasicExpensesDetails]
ADD CONSTRAINT [FK_tblSysBranch_BasicExpensesDetails]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_BasicExpensesDetails'
CREATE INDEX [IX_FK_tblSysBranch_BasicExpensesDetails]
ON [dbo].[BasicExpensesDetails]
    ([BranchID]);
GO

-- Creating foreign key on [ExpsID] in table 'BasicExpensesDetails'
ALTER TABLE [dbo].[BasicExpensesDetails]
ADD CONSTRAINT [FK_TypeOfExpenses_BasicExpensesDetails]
    FOREIGN KEY ([ExpsID])
    REFERENCES [dbo].[TypeOfExpenses]
        ([ExpsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeOfExpenses_BasicExpensesDetails'
CREATE INDEX [IX_FK_TypeOfExpenses_BasicExpensesDetails]
ON [dbo].[BasicExpensesDetails]
    ([ExpsID]);
GO

-- Creating foreign key on [BusinessTypeID] in table 'BusinessTypeMarginDetails'
ALTER TABLE [dbo].[BusinessTypeMarginDetails]
ADD CONSTRAINT [FK_BusinessTypes_BusinessTypeMarginDetails]
    FOREIGN KEY ([BusinessTypeID])
    REFERENCES [dbo].[BusinessTypes]
        ([BusinessTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessTypes_BusinessTypeMarginDetails'
CREATE INDEX [IX_FK_BusinessTypes_BusinessTypeMarginDetails]
ON [dbo].[BusinessTypeMarginDetails]
    ([BusinessTypeID]);
GO

-- Creating foreign key on [BranchID] in table 'BusinessTypeMarginDetails'
ALTER TABLE [dbo].[BusinessTypeMarginDetails]
ADD CONSTRAINT [FK_tblSysBranch_BusinessTypeMarginDetails]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_BusinessTypeMarginDetails'
CREATE INDEX [IX_FK_tblSysBranch_BusinessTypeMarginDetails]
ON [dbo].[BusinessTypeMarginDetails]
    ([BranchID]);
GO

-- Creating foreign key on [BusinessTypeID] in table 'FuturisticBusinessTypes'
ALTER TABLE [dbo].[FuturisticBusinessTypes]
ADD CONSTRAINT [FK_BusinessTypes_FuturisticBusinessTypes]
    FOREIGN KEY ([BusinessTypeID])
    REFERENCES [dbo].[BusinessTypes]
        ([BusinessTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessTypes_FuturisticBusinessTypes'
CREATE INDEX [IX_FK_BusinessTypes_FuturisticBusinessTypes]
ON [dbo].[FuturisticBusinessTypes]
    ([BusinessTypeID]);
GO

-- Creating foreign key on [BusinessTypeID] in table 'FuturisticItemThresholdQties'
ALTER TABLE [dbo].[FuturisticItemThresholdQties]
ADD CONSTRAINT [FK_BusinessTypes_FuturisticItemThresholdQty]
    FOREIGN KEY ([BusinessTypeID])
    REFERENCES [dbo].[BusinessTypes]
        ([BusinessTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessTypes_FuturisticItemThresholdQty'
CREATE INDEX [IX_FK_BusinessTypes_FuturisticItemThresholdQty]
ON [dbo].[FuturisticItemThresholdQties]
    ([BusinessTypeID]);
GO

-- Creating foreign key on [BusinessTypeID] in table 'ItemThresholdQtyDetails'
ALTER TABLE [dbo].[ItemThresholdQtyDetails]
ADD CONSTRAINT [FK_BusinessTypes_ItemThresholdQtyDetails]
    FOREIGN KEY ([BusinessTypeID])
    REFERENCES [dbo].[BusinessTypes]
        ([BusinessTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessTypes_ItemThresholdQtyDetails'
CREATE INDEX [IX_FK_BusinessTypes_ItemThresholdQtyDetails]
ON [dbo].[ItemThresholdQtyDetails]
    ([BusinessTypeID]);
GO

-- Creating foreign key on [BranchID] in table 'CreditTypeMarginDetails'
ALTER TABLE [dbo].[CreditTypeMarginDetails]
ADD CONSTRAINT [FK_tblSysBranch_CreditTypeMarginDetails]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_CreditTypeMarginDetails'
CREATE INDEX [IX_FK_tblSysBranch_CreditTypeMarginDetails]
ON [dbo].[CreditTypeMarginDetails]
    ([BranchID]);
GO

-- Creating foreign key on [DenominationID] in table 'DenominationMapWithTrans'
ALTER TABLE [dbo].[DenominationMapWithTrans]
ADD CONSTRAINT [FK_DenominationMapWithTrans_CurrencyDenominationType]
    FOREIGN KEY ([DenominationID])
    REFERENCES [dbo].[CurrencyDenominationTypes]
        ([DenominationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DenominationMapWithTrans_CurrencyDenominationType'
CREATE INDEX [IX_FK_DenominationMapWithTrans_CurrencyDenominationType]
ON [dbo].[DenominationMapWithTrans]
    ([DenominationID]);
GO

-- Creating foreign key on [ID] in table 'DCQtyAllocationItemWarehouseMaps'
ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMaps]
ADD CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_DCQuantityAllocation]
    FOREIGN KEY ([ID])
    REFERENCES [dbo].[DCQuantityAllocations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DCQtyAllocationItemWarehouseMap_DCQuantityAllocation'
CREATE INDEX [IX_FK_DCQtyAllocationItemWarehouseMap_DCQuantityAllocation]
ON [dbo].[DCQtyAllocationItemWarehouseMaps]
    ([ID]);
GO

-- Creating foreign key on [BatchID] in table 'DCQtyAllocationItemWarehouseMaps'
ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMaps]
ADD CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_tblBatch]
    FOREIGN KEY ([BatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DCQtyAllocationItemWarehouseMap_tblBatch'
CREATE INDEX [IX_FK_DCQtyAllocationItemWarehouseMap_tblBatch]
ON [dbo].[DCQtyAllocationItemWarehouseMaps]
    ([BatchID]);
GO

-- Creating foreign key on [ItemCode] in table 'DCQtyAllocationItemWarehouseMaps'
ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMaps]
ADD CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_tblItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DCQtyAllocationItemWarehouseMap_tblItem'
CREATE INDEX [IX_FK_DCQtyAllocationItemWarehouseMap_tblItem]
ON [dbo].[DCQtyAllocationItemWarehouseMaps]
    ([ItemCode]);
GO

-- Creating foreign key on [RequisitionNumber] in table 'DCQtyAllocationItemWarehouseMaps'
ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMaps]
ADD CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_tblPurchaseRequisition]
    FOREIGN KEY ([RequisitionNumber])
    REFERENCES [dbo].[tblPurchaseRequisitions]
        ([RequisitionNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DCQtyAllocationItemWarehouseMap_tblPurchaseRequisition'
CREATE INDEX [IX_FK_DCQtyAllocationItemWarehouseMap_tblPurchaseRequisition]
ON [dbo].[DCQtyAllocationItemWarehouseMaps]
    ([RequisitionNumber]);
GO

-- Creating foreign key on [WarehouseID] in table 'DCQtyAllocationItemWarehouseMaps'
ALTER TABLE [dbo].[DCQtyAllocationItemWarehouseMaps]
ADD CONSTRAINT [FK_DCQtyAllocationItemWarehouseMap_tblWarehouse]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DCQtyAllocationItemWarehouseMap_tblWarehouse'
CREATE INDEX [IX_FK_DCQtyAllocationItemWarehouseMap_tblWarehouse]
ON [dbo].[DCQtyAllocationItemWarehouseMaps]
    ([WarehouseID]);
GO

-- Creating foreign key on [BranchID] in table 'DeliverycenterBranchMaps'
ALTER TABLE [dbo].[DeliverycenterBranchMaps]
ADD CONSTRAINT [FK_tblSysSysBranch_DeliverycenterBranchMap]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysSysBranch_DeliverycenterBranchMap'
CREATE INDEX [IX_FK_tblSysSysBranch_DeliverycenterBranchMap]
ON [dbo].[DeliverycenterBranchMaps]
    ([BranchID]);
GO

-- Creating foreign key on [DelivercenterID] in table 'DeliverycenterBranchMaps'
ALTER TABLE [dbo].[DeliverycenterBranchMaps]
ADD CONSTRAINT [FK_tblWarehouse_DeliverycenterBranchMap]
    FOREIGN KEY ([DelivercenterID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_DeliverycenterBranchMap'
CREATE INDEX [IX_FK_tblWarehouse_DeliverycenterBranchMap]
ON [dbo].[DeliverycenterBranchMaps]
    ([DelivercenterID]);
GO

-- Creating foreign key on [DepartmentID] in table 'tblSysRoles'
ALTER TABLE [dbo].[tblSysRoles]
ADD CONSTRAINT [FK_tblSysRole_Departments]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([DeptID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysRole_Departments'
CREATE INDEX [IX_FK_tblSysRole_Departments]
ON [dbo].[tblSysRoles]
    ([DepartmentID]);
GO

-- Creating foreign key on [ItemCode] in table 'DiscountsExpenseDetails'
ALTER TABLE [dbo].[DiscountsExpenseDetails]
ADD CONSTRAINT [FK_Itbltem_DiscountsExpenseDetails]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_DiscountsExpenseDetails'
CREATE INDEX [IX_FK_Itbltem_DiscountsExpenseDetails]
ON [dbo].[DiscountsExpenseDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [BatchID] in table 'DiscrepencyDetails'
ALTER TABLE [dbo].[DiscrepencyDetails]
ADD CONSTRAINT [FK_DiscrepencyDetails_tblBatch]
    FOREIGN KEY ([BatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DiscrepencyDetails_tblBatch'
CREATE INDEX [IX_FK_DiscrepencyDetails_tblBatch]
ON [dbo].[DiscrepencyDetails]
    ([BatchID]);
GO

-- Creating foreign key on [ItemCode] in table 'DiscrepencyDetails'
ALTER TABLE [dbo].[DiscrepencyDetails]
ADD CONSTRAINT [FK_DiscrepencyDetails_tblItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DiscrepencyDetails_tblItem'
CREATE INDEX [IX_FK_DiscrepencyDetails_tblItem]
ON [dbo].[DiscrepencyDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [ReasonForDiscrepency] in table 'DiscrepencyDetails'
ALTER TABLE [dbo].[DiscrepencyDetails]
ADD CONSTRAINT [FK_DiscrepencyDetails_tblReason]
    FOREIGN KEY ([ReasonForDiscrepency])
    REFERENCES [dbo].[tblReasons]
        ([ReasonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DiscrepencyDetails_tblReason'
CREATE INDEX [IX_FK_DiscrepencyDetails_tblReason]
ON [dbo].[DiscrepencyDetails]
    ([ReasonForDiscrepency]);
GO

-- Creating foreign key on [BranchID] in table 'DiscrepencyDetails'
ALTER TABLE [dbo].[DiscrepencyDetails]
ADD CONSTRAINT [FK_DiscrepencyDetails_tblSysBranch]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DiscrepencyDetails_tblSysBranch'
CREATE INDEX [IX_FK_DiscrepencyDetails_tblSysBranch]
ON [dbo].[DiscrepencyDetails]
    ([BranchID]);
GO

-- Creating foreign key on [CreationID] in table 'DiscrepencyDetails'
ALTER TABLE [dbo].[DiscrepencyDetails]
ADD CONSTRAINT [FK_DiscrepencyDetails_tblSysUserCrID]
    FOREIGN KEY ([CreationID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DiscrepencyDetails_tblSysUserCrID'
CREATE INDEX [IX_FK_DiscrepencyDetails_tblSysUserCrID]
ON [dbo].[DiscrepencyDetails]
    ([CreationID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'DiscrepencyDetails'
ALTER TABLE [dbo].[DiscrepencyDetails]
ADD CONSTRAINT [FK_DiscrepencyDetails_tblSysUserMdID]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DiscrepencyDetails_tblSysUserMdID'
CREATE INDEX [IX_FK_DiscrepencyDetails_tblSysUserMdID]
ON [dbo].[DiscrepencyDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'DiscrepencyDetails'
ALTER TABLE [dbo].[DiscrepencyDetails]
ADD CONSTRAINT [FK_DiscrepencyDetails_tblWarehouse]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DiscrepencyDetails_tblWarehouse'
CREATE INDEX [IX_FK_DiscrepencyDetails_tblWarehouse]
ON [dbo].[DiscrepencyDetails]
    ([WarehouseID]);
GO

-- Creating foreign key on [DocumentID] in table 'DocumentsSettings'
ALTER TABLE [dbo].[DocumentsSettings]
ADD CONSTRAINT [FK_DocumentsList_DocumentsSetting]
    FOREIGN KEY ([DocumentID])
    REFERENCES [dbo].[DocumentsLists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentsList_DocumentsSetting'
CREATE INDEX [IX_FK_DocumentsList_DocumentsSetting]
ON [dbo].[DocumentsSettings]
    ([DocumentID]);
GO

-- Creating foreign key on [GPNumber] in table 'DocumentUploads'
ALTER TABLE [dbo].[DocumentUploads]
ADD CONSTRAINT [FK_DocumentUploads_tblGatePass]
    FOREIGN KEY ([GPNumber])
    REFERENCES [dbo].[tblGatePasses]
        ([GatePassCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentUploads_tblGatePass'
CREATE INDEX [IX_FK_DocumentUploads_tblGatePass]
ON [dbo].[DocumentUploads]
    ([GPNumber]);
GO

-- Creating foreign key on [GINID] in table 'DocumentUploads'
ALTER TABLE [dbo].[DocumentUploads]
ADD CONSTRAINT [FK_DocumentUploads_tblGoodsInwardNote]
    FOREIGN KEY ([GINID])
    REFERENCES [dbo].[tblGoodsInwardNotes]
        ([GINID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentUploads_tblGoodsInwardNote'
CREATE INDEX [IX_FK_DocumentUploads_tblGoodsInwardNote]
ON [dbo].[DocumentUploads]
    ([GINID]);
GO

-- Creating foreign key on [ItemCode] in table 'FranchiseMarginDetails'
ALTER TABLE [dbo].[FranchiseMarginDetails]
ADD CONSTRAINT [FK_Itbltem_FranchiseMarginDetails]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_FranchiseMarginDetails'
CREATE INDEX [IX_FK_Itbltem_FranchiseMarginDetails]
ON [dbo].[FranchiseMarginDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'FreightExpenseDetails'
ALTER TABLE [dbo].[FreightExpenseDetails]
ADD CONSTRAINT [FK_Itbltem_FreightExpenseDetails]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_FreightExpenseDetails'
CREATE INDEX [IX_FK_Itbltem_FreightExpenseDetails]
ON [dbo].[FreightExpenseDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [FuminID] in table 'FumigationItemWrhsDetails'
ALTER TABLE [dbo].[FumigationItemWrhsDetails]
ADD CONSTRAINT [FK_FumigationDetails_FumigationItemWrhsDetails]
    FOREIGN KEY ([FuminID])
    REFERENCES [dbo].[FumigationDetails]
        ([FuminID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FumigationDetails_FumigationItemWrhsDetails'
CREATE INDEX [IX_FK_FumigationDetails_FumigationItemWrhsDetails]
ON [dbo].[FumigationItemWrhsDetails]
    ([FuminID]);
GO

-- Creating foreign key on [WarehouseID] in table 'FumigationItemWrhsDetails'
ALTER TABLE [dbo].[FumigationItemWrhsDetails]
ADD CONSTRAINT [FK_FumigationItemWrhsDetails_tblWarehouse]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FumigationItemWrhsDetails_tblWarehouse'
CREATE INDEX [IX_FK_FumigationItemWrhsDetails_tblWarehouse]
ON [dbo].[FumigationItemWrhsDetails]
    ([WarehouseID]);
GO

-- Creating foreign key on [ItemCode] in table 'FumigationItemWrhsDetails'
ALTER TABLE [dbo].[FumigationItemWrhsDetails]
ADD CONSTRAINT [FK_tblItem_FumigationItemWrhsDetails]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_FumigationItemWrhsDetails'
CREATE INDEX [IX_FK_tblItem_FumigationItemWrhsDetails]
ON [dbo].[FumigationItemWrhsDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'FuturisticItemThresholdQties'
ALTER TABLE [dbo].[FuturisticItemThresholdQties]
ADD CONSTRAINT [FK_tblItem_FuturisticItemThresholdQty]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_FuturisticItemThresholdQty'
CREATE INDEX [IX_FK_tblItem_FuturisticItemThresholdQty]
ON [dbo].[FuturisticItemThresholdQties]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'ItemThresholdQtyDetails'
ALTER TABLE [dbo].[ItemThresholdQtyDetails]
ADD CONSTRAINT [FK_tblItem_ItemThresholdQtyDetails]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_ItemThresholdQtyDetails'
CREATE INDEX [IX_FK_tblItem_ItemThresholdQtyDetails]
ON [dbo].[ItemThresholdQtyDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [AreaID] in table 'SalesManAreaMappingChilds'
ALTER TABLE [dbo].[SalesManAreaMappingChilds]
ADD CONSTRAINT [FK_SalesManAreaMappingChild_tblArea]
    FOREIGN KEY ([AreaID])
    REFERENCES [dbo].[tblAreas]
        ([AreaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesManAreaMappingChild_tblArea'
CREATE INDEX [IX_FK_SalesManAreaMappingChild_tblArea]
ON [dbo].[SalesManAreaMappingChilds]
    ([AreaID]);
GO

-- Creating foreign key on [SalesManID] in table 'SalesManAreaMappingChilds'
ALTER TABLE [dbo].[SalesManAreaMappingChilds]
ADD CONSTRAINT [FK_SalesManAreaMappingChild_tblSalesManAreaMappingParent]
    FOREIGN KEY ([SalesManID])
    REFERENCES [dbo].[SalesManAreaMappingParents]
        ([SalesManID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesManAreaMappingChild_tblSalesManAreaMappingParent'
CREATE INDEX [IX_FK_SalesManAreaMappingChild_tblSalesManAreaMappingParent]
ON [dbo].[SalesManAreaMappingChilds]
    ([SalesManID]);
GO

-- Creating foreign key on [CityID] in table 'SalesManAreaMappingParents'
ALTER TABLE [dbo].[SalesManAreaMappingParents]
ADD CONSTRAINT [FK_SalesManAreaMappingParent_tblCity]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[tblCities]
        ([CityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesManAreaMappingParent_tblCity'
CREATE INDEX [IX_FK_SalesManAreaMappingParent_tblCity]
ON [dbo].[SalesManAreaMappingParents]
    ([CityID]);
GO

-- Creating foreign key on [DistrictID] in table 'SalesManAreaMappingParents'
ALTER TABLE [dbo].[SalesManAreaMappingParents]
ADD CONSTRAINT [FK_SalesManAreaMappingParent_tblDistrict]
    FOREIGN KEY ([DistrictID])
    REFERENCES [dbo].[tblDistricts]
        ([DistrictID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesManAreaMappingParent_tblDistrict'
CREATE INDEX [IX_FK_SalesManAreaMappingParent_tblDistrict]
ON [dbo].[SalesManAreaMappingParents]
    ([DistrictID]);
GO

-- Creating foreign key on [StateID] in table 'SalesManAreaMappingParents'
ALTER TABLE [dbo].[SalesManAreaMappingParents]
ADD CONSTRAINT [FK_SalesManAreaMappingParent_tblState]
    FOREIGN KEY ([StateID])
    REFERENCES [dbo].[tblStates]
        ([StateID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesManAreaMappingParent_tblState'
CREATE INDEX [IX_FK_SalesManAreaMappingParent_tblState]
ON [dbo].[SalesManAreaMappingParents]
    ([StateID]);
GO

-- Creating foreign key on [SubMenuID] in table 'tblAccessRights'
ALTER TABLE [dbo].[tblAccessRights]
ADD CONSTRAINT [FK_tblSysSubMenu_tblAccessRights]
    FOREIGN KEY ([SubMenuID])
    REFERENCES [dbo].[tblSysSubMenus]
        ([SubMenuID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysSubMenu_tblAccessRights'
CREATE INDEX [IX_FK_tblSysSubMenu_tblAccessRights]
ON [dbo].[tblAccessRights]
    ([SubMenuID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblAccessRights'
ALTER TABLE [dbo].[tblAccessRights]
ADD CONSTRAINT [FK_tblsysUser_tblAccessRights]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblAccessRights'
CREATE INDEX [IX_FK_tblsysUser_tblAccessRights]
ON [dbo].[tblAccessRights]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblAccessRights'
ALTER TABLE [dbo].[tblAccessRights]
ADD CONSTRAINT [FK_tblSysUser1_tblAccessRights]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblAccessRights'
CREATE INDEX [IX_FK_tblSysUser1_tblAccessRights]
ON [dbo].[tblAccessRights]
    ([ModifiedByID]);
GO

-- Creating foreign key on [UserID] in table 'tblAccessRights'
ALTER TABLE [dbo].[tblAccessRights]
ADD CONSTRAINT [FK_tblSysUser2_tblAccessRights]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser2_tblAccessRights'
CREATE INDEX [IX_FK_tblSysUser2_tblAccessRights]
ON [dbo].[tblAccessRights]
    ([UserID]);
GO

-- Creating foreign key on [ContraID] in table 'tblAccountContraBillWithDetails'
ALTER TABLE [dbo].[tblAccountContraBillWithDetails]
ADD CONSTRAINT [FK_tblAccountContraBillWithDetails_tblAccountContraDetails]
    FOREIGN KEY ([ContraID])
    REFERENCES [dbo].[tblAccountContraDetails]
        ([ContraID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountContraBillWithDetails_tblAccountContraDetails'
CREATE INDEX [IX_FK_tblAccountContraBillWithDetails_tblAccountContraDetails]
ON [dbo].[tblAccountContraBillWithDetails]
    ([ContraID]);
GO

-- Creating foreign key on [BranchID] in table 'tblAccountContraDetails'
ALTER TABLE [dbo].[tblAccountContraDetails]
ADD CONSTRAINT [FK_tblAccountContraDetails_tblSysBranch]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountContraDetails_tblSysBranch'
CREATE INDEX [IX_FK_tblAccountContraDetails_tblSysBranch]
ON [dbo].[tblAccountContraDetails]
    ([BranchID]);
GO

-- Creating foreign key on [BranchID] in table 'tblAccountCreditNoteDetails'
ALTER TABLE [dbo].[tblAccountCreditNoteDetails]
ADD CONSTRAINT [FK_tblAccountCreditNoteDetails_tblSysBranch]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountCreditNoteDetails_tblSysBranch'
CREATE INDEX [IX_FK_tblAccountCreditNoteDetails_tblSysBranch]
ON [dbo].[tblAccountCreditNoteDetails]
    ([BranchID]);
GO

-- Creating foreign key on [CreditNoteID] in table 'tblAccountCreditNoteItemDetails'
ALTER TABLE [dbo].[tblAccountCreditNoteItemDetails]
ADD CONSTRAINT [FK_tblAccountCreditNoteItemDetails_tblAccountCreditNoteDetails]
    FOREIGN KEY ([CreditNoteID])
    REFERENCES [dbo].[tblAccountCreditNoteDetails]
        ([CreditNoteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountCreditNoteItemDetails_tblAccountCreditNoteDetails'
CREATE INDEX [IX_FK_tblAccountCreditNoteItemDetails_tblAccountCreditNoteDetails]
ON [dbo].[tblAccountCreditNoteItemDetails]
    ([CreditNoteID]);
GO

-- Creating foreign key on [CreditNoteID] in table 'tblAccountCreditNoteWithBillDetails'
ALTER TABLE [dbo].[tblAccountCreditNoteWithBillDetails]
ADD CONSTRAINT [FK_tblAccountCreditNoteWithBillDetails_tblAccountCreditNoteDetails]
    FOREIGN KEY ([CreditNoteID])
    REFERENCES [dbo].[tblAccountCreditNoteDetails]
        ([CreditNoteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountCreditNoteWithBillDetails_tblAccountCreditNoteDetails'
CREATE INDEX [IX_FK_tblAccountCreditNoteWithBillDetails_tblAccountCreditNoteDetails]
ON [dbo].[tblAccountCreditNoteWithBillDetails]
    ([CreditNoteID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblAccountCreditNoteItemDetails'
ALTER TABLE [dbo].[tblAccountCreditNoteItemDetails]
ADD CONSTRAINT [FK_tblAccountCreditNoteItemDetails_tblItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountCreditNoteItemDetails_tblItem'
CREATE INDEX [IX_FK_tblAccountCreditNoteItemDetails_tblItem]
ON [dbo].[tblAccountCreditNoteItemDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [ReasonID] in table 'tblAccountCreditNoteItemDetails'
ALTER TABLE [dbo].[tblAccountCreditNoteItemDetails]
ADD CONSTRAINT [FK_tblAccountCreditNoteItemDetails_tblReason]
    FOREIGN KEY ([ReasonID])
    REFERENCES [dbo].[tblReasons]
        ([ReasonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountCreditNoteItemDetails_tblReason'
CREATE INDEX [IX_FK_tblAccountCreditNoteItemDetails_tblReason]
ON [dbo].[tblAccountCreditNoteItemDetails]
    ([ReasonID]);
GO

-- Creating foreign key on [CreditNoteWithBillID] in table 'tblAccountCreditNoteWithBillDetails'
ALTER TABLE [dbo].[tblAccountCreditNoteWithBillDetails]
ADD CONSTRAINT [FK_tblAccountCreditNoteWithBillDetails_tblAccountCreditNoteWithBillDetails]
    FOREIGN KEY ([CreditNoteWithBillID])
    REFERENCES [dbo].[tblAccountCreditNoteWithBillDetails]
        ([CreditNoteWithBillID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BranchID] in table 'tblAccountDebitNoteDetails'
ALTER TABLE [dbo].[tblAccountDebitNoteDetails]
ADD CONSTRAINT [FK_tblAccountDebitNoteDetails_tblSysBranch]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountDebitNoteDetails_tblSysBranch'
CREATE INDEX [IX_FK_tblAccountDebitNoteDetails_tblSysBranch]
ON [dbo].[tblAccountDebitNoteDetails]
    ([BranchID]);
GO

-- Creating foreign key on [DebitNoteID] in table 'tblAccountDebitNoteItemDetails'
ALTER TABLE [dbo].[tblAccountDebitNoteItemDetails]
ADD CONSTRAINT [FK_tblAccountDebitNoteItemDetails_tblAccountDebitNoteDetails]
    FOREIGN KEY ([DebitNoteID])
    REFERENCES [dbo].[tblAccountDebitNoteDetails]
        ([DebitNoteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountDebitNoteItemDetails_tblAccountDebitNoteDetails'
CREATE INDEX [IX_FK_tblAccountDebitNoteItemDetails_tblAccountDebitNoteDetails]
ON [dbo].[tblAccountDebitNoteItemDetails]
    ([DebitNoteID]);
GO

-- Creating foreign key on [DebitNoteID] in table 'tblAccountDebitNoteWithBillDetails'
ALTER TABLE [dbo].[tblAccountDebitNoteWithBillDetails]
ADD CONSTRAINT [FK_tblAccountDebitNoteWithBillDetails_tblAccountDebitNoteDetails]
    FOREIGN KEY ([DebitNoteID])
    REFERENCES [dbo].[tblAccountDebitNoteDetails]
        ([DebitNoteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountDebitNoteWithBillDetails_tblAccountDebitNoteDetails'
CREATE INDEX [IX_FK_tblAccountDebitNoteWithBillDetails_tblAccountDebitNoteDetails]
ON [dbo].[tblAccountDebitNoteWithBillDetails]
    ([DebitNoteID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblAccountDebitNoteItemDetails'
ALTER TABLE [dbo].[tblAccountDebitNoteItemDetails]
ADD CONSTRAINT [FK_tblAccountDebitNoteItemDetails_tblItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountDebitNoteItemDetails_tblItem'
CREATE INDEX [IX_FK_tblAccountDebitNoteItemDetails_tblItem]
ON [dbo].[tblAccountDebitNoteItemDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [ReasonID] in table 'tblAccountDebitNoteItemDetails'
ALTER TABLE [dbo].[tblAccountDebitNoteItemDetails]
ADD CONSTRAINT [FK_tblAccountDebitNoteItemDetails_tblReason]
    FOREIGN KEY ([ReasonID])
    REFERENCES [dbo].[tblReasons]
        ([ReasonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountDebitNoteItemDetails_tblReason'
CREATE INDEX [IX_FK_tblAccountDebitNoteItemDetails_tblReason]
ON [dbo].[tblAccountDebitNoteItemDetails]
    ([ReasonID]);
GO

-- Creating foreign key on [AccountGroupMasterID] in table 'tblAccountGroups'
ALTER TABLE [dbo].[tblAccountGroups]
ADD CONSTRAINT [FK_tblAccountGroupMaster_tblAccountGroup]
    FOREIGN KEY ([AccountGroupMasterID])
    REFERENCES [dbo].[tblAccountGroupMasters]
        ([AccountGroupMasterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountGroupMaster_tblAccountGroup'
CREATE INDEX [IX_FK_tblAccountGroupMaster_tblAccountGroup]
ON [dbo].[tblAccountGroups]
    ([AccountGroupMasterID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblAccountGroups'
ALTER TABLE [dbo].[tblAccountGroups]
ADD CONSTRAINT [FK_tblsysUser_tblAccountGroup]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblAccountGroup'
CREATE INDEX [IX_FK_tblsysUser_tblAccountGroup]
ON [dbo].[tblAccountGroups]
    ([CreatedByID]);
GO

-- Creating foreign key on [AccountGroupMasterID] in table 'tblSubAccountGroupMasters'
ALTER TABLE [dbo].[tblSubAccountGroupMasters]
ADD CONSTRAINT [FK_tblAccountGroupMaster_tblSubAccountGroupMaster]
    FOREIGN KEY ([AccountGroupMasterID])
    REFERENCES [dbo].[tblAccountGroupMasters]
        ([AccountGroupMasterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountGroupMaster_tblSubAccountGroupMaster'
CREATE INDEX [IX_FK_tblAccountGroupMaster_tblSubAccountGroupMaster]
ON [dbo].[tblSubAccountGroupMasters]
    ([AccountGroupMasterID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblAccountGroupMasters'
ALTER TABLE [dbo].[tblAccountGroupMasters]
ADD CONSTRAINT [FK_tblsysUser_tblAccountGroupMaster]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblAccountGroupMaster'
CREATE INDEX [IX_FK_tblsysUser_tblAccountGroupMaster]
ON [dbo].[tblAccountGroupMasters]
    ([CreatedByID]);
GO

-- Creating foreign key on [LedgerID] in table 'tblAccountReceiptDetails'
ALTER TABLE [dbo].[tblAccountReceiptDetails]
ADD CONSTRAINT [FK_tblAccountLedger_tblAccountReceiptDetails]
    FOREIGN KEY ([LedgerID])
    REFERENCES [dbo].[tblAccountLedgers]
        ([LedgerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountLedger_tblAccountReceiptDetails'
CREATE INDEX [IX_FK_tblAccountLedger_tblAccountReceiptDetails]
ON [dbo].[tblAccountReceiptDetails]
    ([LedgerID]);
GO

-- Creating foreign key on [OrgID] in table 'tblAccountLedgers'
ALTER TABLE [dbo].[tblAccountLedgers]
ADD CONSTRAINT [FK_tblAccountLedger_tblSysOrganization]
    FOREIGN KEY ([OrgID])
    REFERENCES [dbo].[tblSysOrganizations]
        ([OrgID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountLedger_tblSysOrganization'
CREATE INDEX [IX_FK_tblAccountLedger_tblSysOrganization]
ON [dbo].[tblAccountLedgers]
    ([OrgID]);
GO

-- Creating foreign key on [PaymentID] in table 'tblAccountPaymentWithBillDetails'
ALTER TABLE [dbo].[tblAccountPaymentWithBillDetails]
ADD CONSTRAINT [FK_tblAccountPaymentWithBillDetails_tblAccountPaymentDetails]
    FOREIGN KEY ([PaymentID])
    REFERENCES [dbo].[tblAccountPaymentDetails]
        ([PaymentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountPaymentWithBillDetails_tblAccountPaymentDetails'
CREATE INDEX [IX_FK_tblAccountPaymentWithBillDetails_tblAccountPaymentDetails]
ON [dbo].[tblAccountPaymentWithBillDetails]
    ([PaymentID]);
GO

-- Creating foreign key on [ReceiptID] in table 'tblAccountReceiptWithBillDetails'
ALTER TABLE [dbo].[tblAccountReceiptWithBillDetails]
ADD CONSTRAINT [FK_tblAccountReceiptDetails_tblAccountReceiptWithBillDetails]
    FOREIGN KEY ([ReceiptID])
    REFERENCES [dbo].[tblAccountReceiptDetails]
        ([ReceiptID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountReceiptDetails_tblAccountReceiptWithBillDetails'
CREATE INDEX [IX_FK_tblAccountReceiptDetails_tblAccountReceiptWithBillDetails]
ON [dbo].[tblAccountReceiptWithBillDetails]
    ([ReceiptID]);
GO

-- Creating foreign key on [OrgID] in table 'tblAccountReceiptDetails'
ALTER TABLE [dbo].[tblAccountReceiptDetails]
ADD CONSTRAINT [FK_tblAccountReceiptDetails_tblSysOrganization]
    FOREIGN KEY ([OrgID])
    REFERENCES [dbo].[tblSysOrganizations]
        ([OrgID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountReceiptDetails_tblSysOrganization'
CREATE INDEX [IX_FK_tblAccountReceiptDetails_tblSysOrganization]
ON [dbo].[tblAccountReceiptDetails]
    ([OrgID]);
GO

-- Creating foreign key on [OrgID] in table 'tblAccountReceiptWithBillDetails'
ALTER TABLE [dbo].[tblAccountReceiptWithBillDetails]
ADD CONSTRAINT [FK_tblAccountReceiptWithBillDetails_tblSysOrganization]
    FOREIGN KEY ([OrgID])
    REFERENCES [dbo].[tblSysOrganizations]
        ([OrgID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAccountReceiptWithBillDetails_tblSysOrganization'
CREATE INDEX [IX_FK_tblAccountReceiptWithBillDetails_tblSysOrganization]
ON [dbo].[tblAccountReceiptWithBillDetails]
    ([OrgID]);
GO

-- Creating foreign key on [ActivityID] in table 'tblSubMenuRoleMaps'
ALTER TABLE [dbo].[tblSubMenuRoleMaps]
ADD CONSTRAINT [FK_tblActivity_tblSubMenuRoleMap]
    FOREIGN KEY ([ActivityID])
    REFERENCES [dbo].[tblActivities]
        ([ActivityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblActivity_tblSubMenuRoleMap'
CREATE INDEX [IX_FK_tblActivity_tblSubMenuRoleMap]
ON [dbo].[tblSubMenuRoleMaps]
    ([ActivityID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblActivities'
ALTER TABLE [dbo].[tblActivities]
ADD CONSTRAINT [FK_tblsysUser_tblActivity]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblActivity'
CREATE INDEX [IX_FK_tblsysUser_tblActivity]
ON [dbo].[tblActivities]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblActivities'
ALTER TABLE [dbo].[tblActivities]
ADD CONSTRAINT [FK_tblSysUser1_tblActivity]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblActivity'
CREATE INDEX [IX_FK_tblSysUser1_tblActivity]
ON [dbo].[tblActivities]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblAdminConfigurations'
ALTER TABLE [dbo].[tblAdminConfigurations]
ADD CONSTRAINT [FK_tblsysUser_tblAdminConfiguration]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblAdminConfiguration'
CREATE INDEX [IX_FK_tblsysUser_tblAdminConfiguration]
ON [dbo].[tblAdminConfigurations]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblAdminConfigurations'
ALTER TABLE [dbo].[tblAdminConfigurations]
ADD CONSTRAINT [FK_tblSysUser1_tblAdminConfiguration]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblAdminConfiguration'
CREATE INDEX [IX_FK_tblSysUser1_tblAdminConfiguration]
ON [dbo].[tblAdminConfigurations]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CityID] in table 'tblAreas'
ALTER TABLE [dbo].[tblAreas]
ADD CONSTRAINT [FK_tblArea_tblCity]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[tblCities]
        ([CityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblArea_tblCity'
CREATE INDEX [IX_FK_tblArea_tblCity]
ON [dbo].[tblAreas]
    ([CityID]);
GO

-- Creating foreign key on [BatchID] in table 'tblDeliveryNoteItems'
ALTER TABLE [dbo].[tblDeliveryNoteItems]
ADD CONSTRAINT [FK_tblBatch_tblDeliveryNoteItem]
    FOREIGN KEY ([BatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBatch_tblDeliveryNoteItem'
CREATE INDEX [IX_FK_tblBatch_tblDeliveryNoteItem]
ON [dbo].[tblDeliveryNoteItems]
    ([BatchID]);
GO

-- Creating foreign key on [BatchID] in table 'tblGatePassItems'
ALTER TABLE [dbo].[tblGatePassItems]
ADD CONSTRAINT [FK_tblBatch_tblGatePassItem]
    FOREIGN KEY ([BatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBatch_tblGatePassItem'
CREATE INDEX [IX_FK_tblBatch_tblGatePassItem]
ON [dbo].[tblGatePassItems]
    ([BatchID]);
GO

-- Creating foreign key on [BatchID] in table 'tblItemMovements'
ALTER TABLE [dbo].[tblItemMovements]
ADD CONSTRAINT [FK_tblBatch_tblItemMovement]
    FOREIGN KEY ([BatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBatch_tblItemMovement'
CREATE INDEX [IX_FK_tblBatch_tblItemMovement]
ON [dbo].[tblItemMovements]
    ([BatchID]);
GO

-- Creating foreign key on [DestinationBatchID] in table 'tblItemStockTransferDestinations'
ALTER TABLE [dbo].[tblItemStockTransferDestinations]
ADD CONSTRAINT [FK_tblBatch_tblItemStockTransferDestination]
    FOREIGN KEY ([DestinationBatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBatch_tblItemStockTransferDestination'
CREATE INDEX [IX_FK_tblBatch_tblItemStockTransferDestination]
ON [dbo].[tblItemStockTransferDestinations]
    ([DestinationBatchID]);
GO

-- Creating foreign key on [BatchID] in table 'tblItemStockTransferSources'
ALTER TABLE [dbo].[tblItemStockTransferSources]
ADD CONSTRAINT [FK_tblBatch_tblItemStockTransferSource]
    FOREIGN KEY ([BatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBatch_tblItemStockTransferSource'
CREATE INDEX [IX_FK_tblBatch_tblItemStockTransferSource]
ON [dbo].[tblItemStockTransferSources]
    ([BatchID]);
GO

-- Creating foreign key on [BatchID] in table 'tblSalesOrderItemWarehouseMaps'
ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMaps]
ADD CONSTRAINT [FK_tblBatch_tblSalesOrderItemWarehouseMap]
    FOREIGN KEY ([BatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBatch_tblSalesOrderItemWarehouseMap'
CREATE INDEX [IX_FK_tblBatch_tblSalesOrderItemWarehouseMap]
ON [dbo].[tblSalesOrderItemWarehouseMaps]
    ([BatchID]);
GO

-- Creating foreign key on [DestinationBatchID] in table 'tblStockTransferLineItems'
ALTER TABLE [dbo].[tblStockTransferLineItems]
ADD CONSTRAINT [FK_tblBatch1_tblStockTransferLineItem]
    FOREIGN KEY ([DestinationBatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBatch1_tblStockTransferLineItem'
CREATE INDEX [IX_FK_tblBatch1_tblStockTransferLineItem]
ON [dbo].[tblStockTransferLineItems]
    ([DestinationBatchID]);
GO

-- Creating foreign key on [BatchID] in table 'tblGoodsInwardNoteItems'
ALTER TABLE [dbo].[tblGoodsInwardNoteItems]
ADD CONSTRAINT [FK_tblGoodsInwardNoteItem_tblBatch]
    FOREIGN KEY ([BatchID])
    REFERENCES [dbo].[tblBatches]
        ([BatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGoodsInwardNoteItem_tblBatch'
CREATE INDEX [IX_FK_tblGoodsInwardNoteItem_tblBatch]
ON [dbo].[tblGoodsInwardNoteItems]
    ([BatchID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblBatches'
ALTER TABLE [dbo].[tblBatches]
ADD CONSTRAINT [FK_tblsysUser_tblBatch]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblBatch'
CREATE INDEX [IX_FK_tblsysUser_tblBatch]
ON [dbo].[tblBatches]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblBatches'
ALTER TABLE [dbo].[tblBatches]
ADD CONSTRAINT [FK_tblSysUser1_tblBatch]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblBatch'
CREATE INDEX [IX_FK_tblSysUser1_tblBatch]
ON [dbo].[tblBatches]
    ([ModifiedByID]);
GO

-- Creating foreign key on [BrandID] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [FK_tblBrand_tblItem]
    FOREIGN KEY ([BrandID])
    REFERENCES [dbo].[tblBrands]
        ([BrandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblBrand_tblItem'
CREATE INDEX [IX_FK_tblBrand_tblItem]
ON [dbo].[tblItems]
    ([BrandID]);
GO

-- Creating foreign key on [ItemCompanyID] in table 'tblBrands'
ALTER TABLE [dbo].[tblBrands]
ADD CONSTRAINT [FK_tblItemCompany_tblBrand]
    FOREIGN KEY ([ItemCompanyID])
    REFERENCES [dbo].[tblItemCompanies]
        ([ItemCompanyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemCompany_tblBrand'
CREATE INDEX [IX_FK_tblItemCompany_tblBrand]
ON [dbo].[tblBrands]
    ([ItemCompanyID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblBrands'
ALTER TABLE [dbo].[tblBrands]
ADD CONSTRAINT [FK_tblsysUser_tblBrand]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblBrand'
CREATE INDEX [IX_FK_tblsysUser_tblBrand]
ON [dbo].[tblBrands]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblBrands'
ALTER TABLE [dbo].[tblBrands]
ADD CONSTRAINT [FK_tblSysUser1_tblBrand]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblBrand'
CREATE INDEX [IX_FK_tblSysUser1_tblBrand]
ON [dbo].[tblBrands]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CartID] in table 'tblCartItems'
ALTER TABLE [dbo].[tblCartItems]
ADD CONSTRAINT [FK_tblAddtoCartChild_tblAddtoCartParent]
    FOREIGN KEY ([CartID])
    REFERENCES [dbo].[tblCarts]
        ([CartID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAddtoCartChild_tblAddtoCartParent'
CREATE INDEX [IX_FK_tblAddtoCartChild_tblAddtoCartParent]
ON [dbo].[tblCartItems]
    ([CartID]);
GO

-- Creating foreign key on [UserID] in table 'tblCarts'
ALTER TABLE [dbo].[tblCarts]
ADD CONSTRAINT [FK_tblAddtoCartParent_tblSysUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAddtoCartParent_tblSysUser'
CREATE INDEX [IX_FK_tblAddtoCartParent_tblSysUser]
ON [dbo].[tblCarts]
    ([UserID]);
GO

-- Creating foreign key on [Itemcode] in table 'tblCartItems'
ALTER TABLE [dbo].[tblCartItems]
ADD CONSTRAINT [FK_tblCartItems_tblItem]
    FOREIGN KEY ([Itemcode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCartItems_tblItem'
CREATE INDEX [IX_FK_tblCartItems_tblItem]
ON [dbo].[tblCartItems]
    ([Itemcode]);
GO

-- Creating foreign key on [CategoryID] in table 'tblCategories'
ALTER TABLE [dbo].[tblCategories]
ADD CONSTRAINT [FK_tblCategory_tblCategory]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[tblCategories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CategoryID] in table 'tblHOMasterPriceDetails'
ALTER TABLE [dbo].[tblHOMasterPriceDetails]
ADD CONSTRAINT [FK_tblCategory_tblHOMasterPriceDetails]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[tblCategories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCategory_tblHOMasterPriceDetails'
CREATE INDEX [IX_FK_tblCategory_tblHOMasterPriceDetails]
ON [dbo].[tblHOMasterPriceDetails]
    ([CategoryID]);
GO

-- Creating foreign key on [CategoryID] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [FK_tblCategory_tblItem]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[tblCategories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCategory_tblItem'
CREATE INDEX [IX_FK_tblCategory_tblItem]
ON [dbo].[tblItems]
    ([CategoryID]);
GO

-- Creating foreign key on [CategoryID] in table 'tblItemStockTransferDestinations'
ALTER TABLE [dbo].[tblItemStockTransferDestinations]
ADD CONSTRAINT [FK_tblCategory_tblItemStockTransferDestination]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[tblCategories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCategory_tblItemStockTransferDestination'
CREATE INDEX [IX_FK_tblCategory_tblItemStockTransferDestination]
ON [dbo].[tblItemStockTransferDestinations]
    ([CategoryID]);
GO

-- Creating foreign key on [CategoryID] in table 'tblParameters'
ALTER TABLE [dbo].[tblParameters]
ADD CONSTRAINT [FK_tblCategory_tblParameter]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[tblCategories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCategory_tblParameter'
CREATE INDEX [IX_FK_tblCategory_tblParameter]
ON [dbo].[tblParameters]
    ([CategoryID]);
GO

-- Creating foreign key on [CategoryID] in table 'tblSubCategories'
ALTER TABLE [dbo].[tblSubCategories]
ADD CONSTRAINT [FK_tblCategory_tblSubCategory]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[tblCategories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCategory_tblSubCategory'
CREATE INDEX [IX_FK_tblCategory_tblSubCategory]
ON [dbo].[tblSubCategories]
    ([CategoryID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblCategories'
ALTER TABLE [dbo].[tblCategories]
ADD CONSTRAINT [FK_tblSysUser1_tblCategory]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblCategory'
CREATE INDEX [IX_FK_tblSysUser1_tblCategory]
ON [dbo].[tblCategories]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblCategories'
ALTER TABLE [dbo].[tblCategories]
ADD CONSTRAINT [FK_UserCategory]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCategory'
CREATE INDEX [IX_FK_UserCategory]
ON [dbo].[tblCategories]
    ([CreatedByID]);
GO

-- Creating foreign key on [DistrictID] in table 'tblCities'
ALTER TABLE [dbo].[tblCities]
ADD CONSTRAINT [FK_tblCity_tblDistrict]
    FOREIGN KEY ([DistrictID])
    REFERENCES [dbo].[tblDistricts]
        ([DistrictID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCity_tblDistrict'
CREATE INDEX [IX_FK_tblCity_tblDistrict]
ON [dbo].[tblCities]
    ([DistrictID]);
GO

-- Creating foreign key on [CustID] in table 'tblCustomerCreditDetails'
ALTER TABLE [dbo].[tblCustomerCreditDetails]
ADD CONSTRAINT [FK_tblCustomerWarehouse_tblCustomerCreditDetail]
    FOREIGN KEY ([CustID])
    REFERENCES [dbo].[tblCustomerVendorDetails]
        ([CustID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomerWarehouse_tblCustomerCreditDetail'
CREATE INDEX [IX_FK_tblCustomerWarehouse_tblCustomerCreditDetail]
ON [dbo].[tblCustomerCreditDetails]
    ([CustID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblCustomerCreditDetails'
ALTER TABLE [dbo].[tblCustomerCreditDetails]
ADD CONSTRAINT [FK_tblsysUser_tblCustomerCreditDetail]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblCustomerCreditDetail'
CREATE INDEX [IX_FK_tblsysUser_tblCustomerCreditDetail]
ON [dbo].[tblCustomerCreditDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [SupplierId] in table 'tblGoodsInwardNotes'
ALTER TABLE [dbo].[tblGoodsInwardNotes]
ADD CONSTRAINT [FK_Table_1_tblCustomerVendorDetail]
    FOREIGN KEY ([SupplierId])
    REFERENCES [dbo].[tblCustomerVendorDetails]
        ([CustID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Table_1_tblCustomerVendorDetail'
CREATE INDEX [IX_FK_Table_1_tblCustomerVendorDetail]
ON [dbo].[tblGoodsInwardNotes]
    ([SupplierId]);
GO

-- Creating foreign key on [CustID] in table 'tblGRNs'
ALTER TABLE [dbo].[tblGRNs]
ADD CONSTRAINT [FK_tblCustomerVendorDetail_tblGRN]
    FOREIGN KEY ([CustID])
    REFERENCES [dbo].[tblCustomerVendorDetails]
        ([CustID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomerVendorDetail_tblGRN'
CREATE INDEX [IX_FK_tblCustomerVendorDetail_tblGRN]
ON [dbo].[tblGRNs]
    ([CustID]);
GO

-- Creating foreign key on [CustID] in table 'tblPOQuotationSuppliers'
ALTER TABLE [dbo].[tblPOQuotationSuppliers]
ADD CONSTRAINT [FK_tblCustomerVendorDetail_tblPOQuotationSuppliers]
    FOREIGN KEY ([CustID])
    REFERENCES [dbo].[tblCustomerVendorDetails]
        ([CustID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomerVendorDetail_tblPOQuotationSuppliers'
CREATE INDEX [IX_FK_tblCustomerVendorDetail_tblPOQuotationSuppliers]
ON [dbo].[tblPOQuotationSuppliers]
    ([CustID]);
GO

-- Creating foreign key on [SuppID] in table 'tblPurchaseOrderInvoices'
ALTER TABLE [dbo].[tblPurchaseOrderInvoices]
ADD CONSTRAINT [FK_tblCustomerVendorDetail_tblPurchaseOrderInvoice]
    FOREIGN KEY ([SuppID])
    REFERENCES [dbo].[tblCustomerVendorDetails]
        ([CustID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomerVendorDetail_tblPurchaseOrderInvoice'
CREATE INDEX [IX_FK_tblCustomerVendorDetail_tblPurchaseOrderInvoice]
ON [dbo].[tblPurchaseOrderInvoices]
    ([SuppID]);
GO

-- Creating foreign key on [SupplierID] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblCustomerWarehouse_tblPurchaseOrder]
    FOREIGN KEY ([SupplierID])
    REFERENCES [dbo].[tblCustomerVendorDetails]
        ([CustID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomerWarehouse_tblPurchaseOrder'
CREATE INDEX [IX_FK_tblCustomerWarehouse_tblPurchaseOrder]
ON [dbo].[tblPurchaseOrders]
    ([SupplierID]);
GO

-- Creating foreign key on [CustID] in table 'tblSalesOrders'
ALTER TABLE [dbo].[tblSalesOrders]
ADD CONSTRAINT [FK_tblCustomerWarehouse_tblSalesOrder]
    FOREIGN KEY ([CustID])
    REFERENCES [dbo].[tblCustomerVendorDetails]
        ([CustID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCustomerWarehouse_tblSalesOrder'
CREATE INDEX [IX_FK_tblCustomerWarehouse_tblSalesOrder]
ON [dbo].[tblSalesOrders]
    ([CustID]);
GO

-- Creating foreign key on [CustID] in table 'tblItemSupplierMappings'
ALTER TABLE [dbo].[tblItemSupplierMappings]
ADD CONSTRAINT [FK_tblItemSupplierMapping_tblCustomerVendorDetail]
    FOREIGN KEY ([CustID])
    REFERENCES [dbo].[tblCustomerVendorDetails]
        ([CustID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemSupplierMapping_tblCustomerVendorDetail'
CREATE INDEX [IX_FK_tblItemSupplierMapping_tblCustomerVendorDetail]
ON [dbo].[tblItemSupplierMappings]
    ([CustID]);
GO

-- Creating foreign key on [PercStrctureID] in table 'tblCustomerVendorDetails'
ALTER TABLE [dbo].[tblCustomerVendorDetails]
ADD CONSTRAINT [FK_tblPercentageStructure_tblCustomerVendorDetail]
    FOREIGN KEY ([PercStrctureID])
    REFERENCES [dbo].[tblPercentageStructures]
        ([PercStrctureID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPercentageStructure_tblCustomerVendorDetail'
CREATE INDEX [IX_FK_tblPercentageStructure_tblCustomerVendorDetail]
ON [dbo].[tblCustomerVendorDetails]
    ([PercStrctureID]);
GO

-- Creating foreign key on [CustID] in table 'tblSalesOrderInvoices'
ALTER TABLE [dbo].[tblSalesOrderInvoices]
ADD CONSTRAINT [FK_tblSalesOrderInvoice_tblCustomerVendorDetail]
    FOREIGN KEY ([CustID])
    REFERENCES [dbo].[tblCustomerVendorDetails]
        ([CustID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrderInvoice_tblCustomerVendorDetail'
CREATE INDEX [IX_FK_tblSalesOrderInvoice_tblCustomerVendorDetail]
ON [dbo].[tblSalesOrderInvoices]
    ([CustID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblCustomerVendorDetails'
ALTER TABLE [dbo].[tblCustomerVendorDetails]
ADD CONSTRAINT [FK_tblsysUser_tblCustomerVendorDetail]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblCustomerVendorDetail'
CREATE INDEX [IX_FK_tblsysUser_tblCustomerVendorDetail]
ON [dbo].[tblCustomerVendorDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblCustomerVendorDetails'
ALTER TABLE [dbo].[tblCustomerVendorDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblCustomerVendorDetail]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblCustomerVendorDetail'
CREATE INDEX [IX_FK_tblSysUser1_tblCustomerVendorDetail]
ON [dbo].[tblCustomerVendorDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [SalesManID] in table 'tblCustomerVendorDetails'
ALTER TABLE [dbo].[tblCustomerVendorDetails]
ADD CONSTRAINT [FK_tblSysUser2_tblCustomerVendorDetail]
    FOREIGN KEY ([SalesManID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser2_tblCustomerVendorDetail'
CREATE INDEX [IX_FK_tblSysUser2_tblCustomerVendorDetail]
ON [dbo].[tblCustomerVendorDetails]
    ([SalesManID]);
GO

-- Creating foreign key on [PlaceID] in table 'tblDebtorsAreaDetails'
ALTER TABLE [dbo].[tblDebtorsAreaDetails]
ADD CONSTRAINT [FK_tblDebtorsPlaceDetails_tblDebtorsAreaDetails]
    FOREIGN KEY ([PlaceID])
    REFERENCES [dbo].[tblDebtorsPlaceDetails]
        ([PlaceID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDebtorsPlaceDetails_tblDebtorsAreaDetails'
CREATE INDEX [IX_FK_tblDebtorsPlaceDetails_tblDebtorsAreaDetails]
ON [dbo].[tblDebtorsAreaDetails]
    ([PlaceID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblDebtorsAreaDetails'
ALTER TABLE [dbo].[tblDebtorsAreaDetails]
ADD CONSTRAINT [FK_tblSysUser_tblDebtorsAreaDetails]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblDebtorsAreaDetails'
CREATE INDEX [IX_FK_tblSysUser_tblDebtorsAreaDetails]
ON [dbo].[tblDebtorsAreaDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblDebtorsAreaDetails'
ALTER TABLE [dbo].[tblDebtorsAreaDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblDebtorsAreaDetails]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblDebtorsAreaDetails'
CREATE INDEX [IX_FK_tblSysUser1_tblDebtorsAreaDetails]
ON [dbo].[tblDebtorsAreaDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblDebtorsPlaceDetails'
ALTER TABLE [dbo].[tblDebtorsPlaceDetails]
ADD CONSTRAINT [FK_tblSysUser_tblDebtorsPlaceDetails]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblDebtorsPlaceDetails'
CREATE INDEX [IX_FK_tblSysUser_tblDebtorsPlaceDetails]
ON [dbo].[tblDebtorsPlaceDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblDebtorsPlaceDetails'
ALTER TABLE [dbo].[tblDebtorsPlaceDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblDebtorsPlaceDetails]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblDebtorsPlaceDetails'
CREATE INDEX [IX_FK_tblSysUser1_tblDebtorsPlaceDetails]
ON [dbo].[tblDebtorsPlaceDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [DeliveryNoteCode] in table 'tblDeliveryNoteItems'
ALTER TABLE [dbo].[tblDeliveryNoteItems]
ADD CONSTRAINT [FK_tblDeliveryNote_tblDeliveryNoteItem]
    FOREIGN KEY ([DeliveryNoteCode])
    REFERENCES [dbo].[tblDeliveryNotes]
        ([DeliveryNoteCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDeliveryNote_tblDeliveryNoteItem'
CREATE INDEX [IX_FK_tblDeliveryNote_tblDeliveryNoteItem]
ON [dbo].[tblDeliveryNoteItems]
    ([DeliveryNoteCode]);
GO

-- Creating foreign key on [VoucherTypeNo] in table 'tblDeliveryNotes'
ALTER TABLE [dbo].[tblDeliveryNotes]
ADD CONSTRAINT [FK_tblDeliveryNote_tblVoucherType]
    FOREIGN KEY ([VoucherTypeNo])
    REFERENCES [dbo].[tblVoucherTypes]
        ([VoucherTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDeliveryNote_tblVoucherType'
CREATE INDEX [IX_FK_tblDeliveryNote_tblVoucherType]
ON [dbo].[tblDeliveryNotes]
    ([VoucherTypeNo]);
GO

-- Creating foreign key on [GatePassCode] in table 'tblDeliveryNotes'
ALTER TABLE [dbo].[tblDeliveryNotes]
ADD CONSTRAINT [FK_tblGatePass_tblDeliveryNote]
    FOREIGN KEY ([GatePassCode])
    REFERENCES [dbo].[tblGatePasses]
        ([GatePassCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGatePass_tblDeliveryNote'
CREATE INDEX [IX_FK_tblGatePass_tblDeliveryNote]
ON [dbo].[tblDeliveryNotes]
    ([GatePassCode]);
GO

-- Creating foreign key on [SalesOrderNumber] in table 'tblDeliveryNotes'
ALTER TABLE [dbo].[tblDeliveryNotes]
ADD CONSTRAINT [FK_tblSalesOrder_tblDeliveryNote]
    FOREIGN KEY ([SalesOrderNumber])
    REFERENCES [dbo].[tblSalesOrders]
        ([SalesOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrder_tblDeliveryNote'
CREATE INDEX [IX_FK_tblSalesOrder_tblDeliveryNote]
ON [dbo].[tblDeliveryNotes]
    ([SalesOrderNumber]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblDeliveryNotes'
ALTER TABLE [dbo].[tblDeliveryNotes]
ADD CONSTRAINT [FK_tblSysUser1_tblDeliveryNote]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblDeliveryNote'
CREATE INDEX [IX_FK_tblSysUser1_tblDeliveryNote]
ON [dbo].[tblDeliveryNotes]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblDeliveryNotes'
ALTER TABLE [dbo].[tblDeliveryNotes]
ADD CONSTRAINT [FK_tblUser_tblGatePassItem]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblGatePassItem'
CREATE INDEX [IX_FK_tblUser_tblGatePassItem]
ON [dbo].[tblDeliveryNotes]
    ([CreatedByID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblDeliveryNoteItems'
ALTER TABLE [dbo].[tblDeliveryNoteItems]
ADD CONSTRAINT [FK_tblItem_tblDeliveryNoteItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblDeliveryNoteItem'
CREATE INDEX [IX_FK_tblItem_tblDeliveryNoteItem]
ON [dbo].[tblDeliveryNoteItems]
    ([ItemCode]);
GO

-- Creating foreign key on [ReasonID] in table 'tblDeliveryNoteItems'
ALTER TABLE [dbo].[tblDeliveryNoteItems]
ADD CONSTRAINT [FK_tblReason_tblDeliveryNoteItem]
    FOREIGN KEY ([ReasonID])
    REFERENCES [dbo].[tblReasons]
        ([ReasonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblReason_tblDeliveryNoteItem'
CREATE INDEX [IX_FK_tblReason_tblDeliveryNoteItem]
ON [dbo].[tblDeliveryNoteItems]
    ([ReasonID]);
GO

-- Creating foreign key on [SalesOrderWithItemID] in table 'tblDeliveryNoteItems'
ALTER TABLE [dbo].[tblDeliveryNoteItems]
ADD CONSTRAINT [FK_tblSalesOrderWithItem_tblDeliveryNoteItem]
    FOREIGN KEY ([SalesOrderWithItemID])
    REFERENCES [dbo].[tblSalesOrderWithItems]
        ([SalesOrderWithItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrderWithItem_tblDeliveryNoteItem'
CREATE INDEX [IX_FK_tblSalesOrderWithItem_tblDeliveryNoteItem]
ON [dbo].[tblDeliveryNoteItems]
    ([SalesOrderWithItemID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblDeliveryNoteItems'
ALTER TABLE [dbo].[tblDeliveryNoteItems]
ADD CONSTRAINT [FK_tblSysUser1_tblDeliveryNoteItem]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblDeliveryNoteItem'
CREATE INDEX [IX_FK_tblSysUser1_tblDeliveryNoteItem]
ON [dbo].[tblDeliveryNoteItems]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblDeliveryNoteItems'
ALTER TABLE [dbo].[tblDeliveryNoteItems]
ADD CONSTRAINT [FK_tblUser_tblDeliveryNoteItem]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblDeliveryNoteItem'
CREATE INDEX [IX_FK_tblUser_tblDeliveryNoteItem]
ON [dbo].[tblDeliveryNoteItems]
    ([CreatedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblDeliveryNoteItems'
ALTER TABLE [dbo].[tblDeliveryNoteItems]
ADD CONSTRAINT [FK_tblWarehouse_tblDeliveryNoteItem]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblDeliveryNoteItem'
CREATE INDEX [IX_FK_tblWarehouse_tblDeliveryNoteItem]
ON [dbo].[tblDeliveryNoteItems]
    ([WarehouseID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblDiscounts'
ALTER TABLE [dbo].[tblDiscounts]
ADD CONSTRAINT [FK_tblItem_tblDiscount]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblDiscount'
CREATE INDEX [IX_FK_tblItem_tblDiscount]
ON [dbo].[tblDiscounts]
    ([ItemCode]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblDiscounts'
ALTER TABLE [dbo].[tblDiscounts]
ADD CONSTRAINT [FK_tblsysUser_tblDiscount]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblDiscount'
CREATE INDEX [IX_FK_tblsysUser_tblDiscount]
ON [dbo].[tblDiscounts]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblDiscounts'
ALTER TABLE [dbo].[tblDiscounts]
ADD CONSTRAINT [FK_tblSysUser1_tblDiscount]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblDiscount'
CREATE INDEX [IX_FK_tblSysUser1_tblDiscount]
ON [dbo].[tblDiscounts]
    ([ModifiedByID]);
GO

-- Creating foreign key on [StateID] in table 'tblDistricts'
ALTER TABLE [dbo].[tblDistricts]
ADD CONSTRAINT [FK_tblDistrict_tblState]
    FOREIGN KEY ([StateID])
    REFERENCES [dbo].[tblStates]
        ([StateID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDistrict_tblState'
CREATE INDEX [IX_FK_tblDistrict_tblState]
ON [dbo].[tblDistricts]
    ([StateID]);
GO

-- Creating foreign key on [GatePassCode] in table 'tblGatePassItems'
ALTER TABLE [dbo].[tblGatePassItems]
ADD CONSTRAINT [FK_tblGatePass_tblGatePassItem]
    FOREIGN KEY ([GatePassCode])
    REFERENCES [dbo].[tblGatePasses]
        ([GatePassCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGatePass_tblGatePassItem'
CREATE INDEX [IX_FK_tblGatePass_tblGatePassItem]
ON [dbo].[tblGatePassItems]
    ([GatePassCode]);
GO

-- Creating foreign key on [VoucherTypeNo] in table 'tblGatePasses'
ALTER TABLE [dbo].[tblGatePasses]
ADD CONSTRAINT [FK_tblGatePass_tblVoucherType]
    FOREIGN KEY ([VoucherTypeNo])
    REFERENCES [dbo].[tblVoucherTypes]
        ([VoucherTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGatePass_tblVoucherType'
CREATE INDEX [IX_FK_tblGatePass_tblVoucherType]
ON [dbo].[tblGatePasses]
    ([VoucherTypeNo]);
GO

-- Creating foreign key on [SalesOrderNumber] in table 'tblGatePasses'
ALTER TABLE [dbo].[tblGatePasses]
ADD CONSTRAINT [FK_tblSalesOrder_tblGatePass]
    FOREIGN KEY ([SalesOrderNumber])
    REFERENCES [dbo].[tblSalesOrders]
        ([SalesOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrder_tblGatePass'
CREATE INDEX [IX_FK_tblSalesOrder_tblGatePass]
ON [dbo].[tblGatePasses]
    ([SalesOrderNumber]);
GO

-- Creating foreign key on [GatePassCode] in table 'tblSalesOrderInvoices'
ALTER TABLE [dbo].[tblSalesOrderInvoices]
ADD CONSTRAINT [FK_tblSalesOrderInvoice_tblGatePass]
    FOREIGN KEY ([GatePassCode])
    REFERENCES [dbo].[tblGatePasses]
        ([GatePassCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrderInvoice_tblGatePass'
CREATE INDEX [IX_FK_tblSalesOrderInvoice_tblGatePass]
ON [dbo].[tblSalesOrderInvoices]
    ([GatePassCode]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblGatePasses'
ALTER TABLE [dbo].[tblGatePasses]
ADD CONSTRAINT [FK_tblSysUser1_tblGatePass]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblGatePass'
CREATE INDEX [IX_FK_tblSysUser1_tblGatePass]
ON [dbo].[tblGatePasses]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblGatePasses'
ALTER TABLE [dbo].[tblGatePasses]
ADD CONSTRAINT [FK_tblUser_tblGatePass]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblGatePass'
CREATE INDEX [IX_FK_tblUser_tblGatePass]
ON [dbo].[tblGatePasses]
    ([CreatedByID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblGatePassItems'
ALTER TABLE [dbo].[tblGatePassItems]
ADD CONSTRAINT [FK_tblItem_tblGatePassItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblGatePassItem'
CREATE INDEX [IX_FK_tblItem_tblGatePassItem]
ON [dbo].[tblGatePassItems]
    ([ItemCode]);
GO

-- Creating foreign key on [ReasonID] in table 'tblGatePassItems'
ALTER TABLE [dbo].[tblGatePassItems]
ADD CONSTRAINT [FK_tblReason_tblGatepassItem]
    FOREIGN KEY ([ReasonID])
    REFERENCES [dbo].[tblReasons]
        ([ReasonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblReason_tblGatepassItem'
CREATE INDEX [IX_FK_tblReason_tblGatepassItem]
ON [dbo].[tblGatePassItems]
    ([ReasonID]);
GO

-- Creating foreign key on [SalesOrderNumber] in table 'tblGatePassItems'
ALTER TABLE [dbo].[tblGatePassItems]
ADD CONSTRAINT [FK_tblSalesOrder_tblGatePassItem]
    FOREIGN KEY ([SalesOrderNumber])
    REFERENCES [dbo].[tblSalesOrders]
        ([SalesOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrder_tblGatePassItem'
CREATE INDEX [IX_FK_tblSalesOrder_tblGatePassItem]
ON [dbo].[tblGatePassItems]
    ([SalesOrderNumber]);
GO

-- Creating foreign key on [SalesOrderWithItemID] in table 'tblGatePassItems'
ALTER TABLE [dbo].[tblGatePassItems]
ADD CONSTRAINT [FK_tblSalesOrderWithItem_tblGatePassItem]
    FOREIGN KEY ([SalesOrderWithItemID])
    REFERENCES [dbo].[tblSalesOrderWithItems]
        ([SalesOrderWithItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrderWithItem_tblGatePassItem'
CREATE INDEX [IX_FK_tblSalesOrderWithItem_tblGatePassItem]
ON [dbo].[tblGatePassItems]
    ([SalesOrderWithItemID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblGatePassItems'
ALTER TABLE [dbo].[tblGatePassItems]
ADD CONSTRAINT [FK_tblSysUser1_tblGatePassItem]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblGatePassItem'
CREATE INDEX [IX_FK_tblSysUser1_tblGatePassItem]
ON [dbo].[tblGatePassItems]
    ([ModifiedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblGatePassItems'
ALTER TABLE [dbo].[tblGatePassItems]
ADD CONSTRAINT [FK_tblWarehouse_tblGatePassItem]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblGatePassItem'
CREATE INDEX [IX_FK_tblWarehouse_tblGatePassItem]
ON [dbo].[tblGatePassItems]
    ([WarehouseID]);
GO

-- Creating foreign key on [CreatedById] in table 'tblGoodsInwardNotes'
ALTER TABLE [dbo].[tblGoodsInwardNotes]
ADD CONSTRAINT [FK_GoodsInwardNote_tblSysUser]
    FOREIGN KEY ([CreatedById])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GoodsInwardNote_tblSysUser'
CREATE INDEX [IX_FK_GoodsInwardNote_tblSysUser]
ON [dbo].[tblGoodsInwardNotes]
    ([CreatedById]);
GO

-- Creating foreign key on [ModifiedById] in table 'tblGoodsInwardNotes'
ALTER TABLE [dbo].[tblGoodsInwardNotes]
ADD CONSTRAINT [FK_GoodsInwardNote_tblSysUser1]
    FOREIGN KEY ([ModifiedById])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GoodsInwardNote_tblSysUser1'
CREATE INDEX [IX_FK_GoodsInwardNote_tblSysUser1]
ON [dbo].[tblGoodsInwardNotes]
    ([ModifiedById]);
GO

-- Creating foreign key on [GINID] in table 'tblGoodsInwardNoteItems'
ALTER TABLE [dbo].[tblGoodsInwardNoteItems]
ADD CONSTRAINT [FK_GoodsInwardNoteItem_tblGoodsInwardNote]
    FOREIGN KEY ([GINID])
    REFERENCES [dbo].[tblGoodsInwardNotes]
        ([GINID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GoodsInwardNoteItem_tblGoodsInwardNote'
CREATE INDEX [IX_FK_GoodsInwardNoteItem_tblGoodsInwardNote]
ON [dbo].[tblGoodsInwardNoteItems]
    ([GINID]);
GO

-- Creating foreign key on [PurchaseOrderNumber] in table 'tblGoodsInwardNotes'
ALTER TABLE [dbo].[tblGoodsInwardNotes]
ADD CONSTRAINT [FK_Table_1_tblPurchaseOrder]
    FOREIGN KEY ([PurchaseOrderNumber])
    REFERENCES [dbo].[tblPurchaseOrders]
        ([PurchaseOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Table_1_tblPurchaseOrder'
CREATE INDEX [IX_FK_Table_1_tblPurchaseOrder]
ON [dbo].[tblGoodsInwardNotes]
    ([PurchaseOrderNumber]);
GO

-- Creating foreign key on [GINID] in table 'tblPurchaseOrderInvoices'
ALTER TABLE [dbo].[tblPurchaseOrderInvoices]
ADD CONSTRAINT [FK_tblGoodsInwardNote_tblPurchaseOrderInvoice]
    FOREIGN KEY ([GINID])
    REFERENCES [dbo].[tblGoodsInwardNotes]
        ([GINID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGoodsInwardNote_tblPurchaseOrderInvoice'
CREATE INDEX [IX_FK_tblGoodsInwardNote_tblPurchaseOrderInvoice]
ON [dbo].[tblPurchaseOrderInvoices]
    ([GINID]);
GO

-- Creating foreign key on [VoucherTypeNo] in table 'tblGoodsInwardNotes'
ALTER TABLE [dbo].[tblGoodsInwardNotes]
ADD CONSTRAINT [FK_tblGoodsInwardNote_tblVoucherType]
    FOREIGN KEY ([VoucherTypeNo])
    REFERENCES [dbo].[tblVoucherTypes]
        ([VoucherTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGoodsInwardNote_tblVoucherType'
CREATE INDEX [IX_FK_tblGoodsInwardNote_tblVoucherType]
ON [dbo].[tblGoodsInwardNotes]
    ([VoucherTypeNo]);
GO

-- Creating foreign key on [ItemCode] in table 'tblGoodsInwardNoteItems'
ALTER TABLE [dbo].[tblGoodsInwardNoteItems]
ADD CONSTRAINT [FK_GoodsInwardNoteItem_tblItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GoodsInwardNoteItem_tblItem'
CREATE INDEX [IX_FK_GoodsInwardNoteItem_tblItem]
ON [dbo].[tblGoodsInwardNoteItems]
    ([ItemCode]);
GO

-- Creating foreign key on [CreatedById] in table 'tblGoodsInwardNoteItems'
ALTER TABLE [dbo].[tblGoodsInwardNoteItems]
ADD CONSTRAINT [FK_tblGoodsInwardNoteItem_tblSysUser]
    FOREIGN KEY ([CreatedById])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGoodsInwardNoteItem_tblSysUser'
CREATE INDEX [IX_FK_tblGoodsInwardNoteItem_tblSysUser]
ON [dbo].[tblGoodsInwardNoteItems]
    ([CreatedById]);
GO

-- Creating foreign key on [ModifiedById] in table 'tblGoodsInwardNoteItems'
ALTER TABLE [dbo].[tblGoodsInwardNoteItems]
ADD CONSTRAINT [FK_tblGoodsInwardNoteItem_tblSysUser1]
    FOREIGN KEY ([ModifiedById])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGoodsInwardNoteItem_tblSysUser1'
CREATE INDEX [IX_FK_tblGoodsInwardNoteItem_tblSysUser1]
ON [dbo].[tblGoodsInwardNoteItems]
    ([ModifiedById]);
GO

-- Creating foreign key on [WareHouseId] in table 'tblGoodsInwardNoteItems'
ALTER TABLE [dbo].[tblGoodsInwardNoteItems]
ADD CONSTRAINT [FK_tblGoodsInwardNoteItem_tblWarehouse]
    FOREIGN KEY ([WareHouseId])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGoodsInwardNoteItem_tblWarehouse'
CREATE INDEX [IX_FK_tblGoodsInwardNoteItem_tblWarehouse]
ON [dbo].[tblGoodsInwardNoteItems]
    ([WareHouseId]);
GO

-- Creating foreign key on [GRNNumber] in table 'tblGRNItems'
ALTER TABLE [dbo].[tblGRNItems]
ADD CONSTRAINT [FK_tblGRN_tblGRNItems]
    FOREIGN KEY ([GRNNumber])
    REFERENCES [dbo].[tblGRNs]
        ([GRNNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGRN_tblGRNItems'
CREATE INDEX [IX_FK_tblGRN_tblGRNItems]
ON [dbo].[tblGRNItems]
    ([GRNNumber]);
GO

-- Creating foreign key on [VoucherTypeNo] in table 'tblGRNs'
ALTER TABLE [dbo].[tblGRNs]
ADD CONSTRAINT [FK_tblGRN_tblVoucherType]
    FOREIGN KEY ([VoucherTypeNo])
    REFERENCES [dbo].[tblVoucherTypes]
        ([VoucherTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGRN_tblVoucherType'
CREATE INDEX [IX_FK_tblGRN_tblVoucherType]
ON [dbo].[tblGRNs]
    ([VoucherTypeNo]);
GO

-- Creating foreign key on [GRNNumber] in table 'tblItemWarehouseMaps'
ALTER TABLE [dbo].[tblItemWarehouseMaps]
ADD CONSTRAINT [FK_tblItemWarehouseMap_tblGRN]
    FOREIGN KEY ([GRNNumber])
    REFERENCES [dbo].[tblGRNs]
        ([GRNNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemWarehouseMap_tblGRN'
CREATE INDEX [IX_FK_tblItemWarehouseMap_tblGRN]
ON [dbo].[tblItemWarehouseMaps]
    ([GRNNumber]);
GO

-- Creating foreign key on [PurchaseOrderNumber] in table 'tblGRNs'
ALTER TABLE [dbo].[tblGRNs]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblGRN]
    FOREIGN KEY ([PurchaseOrderNumber])
    REFERENCES [dbo].[tblPurchaseOrders]
        ([PurchaseOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblGRN'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblGRN]
ON [dbo].[tblGRNs]
    ([PurchaseOrderNumber]);
GO

-- Creating foreign key on [GRNNumber] in table 'tblStickerDetails'
ALTER TABLE [dbo].[tblStickerDetails]
ADD CONSTRAINT [FK_tblStickerDetails_tblGRN]
    FOREIGN KEY ([GRNNumber])
    REFERENCES [dbo].[tblGRNs]
        ([GRNNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStickerDetails_tblGRN'
CREATE INDEX [IX_FK_tblStickerDetails_tblGRN]
ON [dbo].[tblStickerDetails]
    ([GRNNumber]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblGRNs'
ALTER TABLE [dbo].[tblGRNs]
ADD CONSTRAINT [FK_tblsysUser_tblGRN]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblGRN'
CREATE INDEX [IX_FK_tblsysUser_tblGRN]
ON [dbo].[tblGRNs]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblGRNs'
ALTER TABLE [dbo].[tblGRNs]
ADD CONSTRAINT [FK_tblSysUser1_tblGRN]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblGRN'
CREATE INDEX [IX_FK_tblSysUser1_tblGRN]
ON [dbo].[tblGRNs]
    ([ModifiedByID]);
GO

-- Creating foreign key on [WareHouseId] in table 'tblGRNItems'
ALTER TABLE [dbo].[tblGRNItems]
ADD CONSTRAINT [FK_tblGRNItems_tblWarehouse]
    FOREIGN KEY ([WareHouseId])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblGRNItems_tblWarehouse'
CREATE INDEX [IX_FK_tblGRNItems_tblWarehouse]
ON [dbo].[tblGRNItems]
    ([WareHouseId]);
GO

-- Creating foreign key on [ItemCode] in table 'tblGRNItems'
ALTER TABLE [dbo].[tblGRNItems]
ADD CONSTRAINT [FK_tblItem_tblGRNItems]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblGRNItems'
CREATE INDEX [IX_FK_tblItem_tblGRNItems]
ON [dbo].[tblGRNItems]
    ([ItemCode]);
GO

-- Creating foreign key on [ReasonID] in table 'tblGRNItems'
ALTER TABLE [dbo].[tblGRNItems]
ADD CONSTRAINT [FK_tblReason_tblGRNItems]
    FOREIGN KEY ([ReasonID])
    REFERENCES [dbo].[tblReasons]
        ([ReasonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblReason_tblGRNItems'
CREATE INDEX [IX_FK_tblReason_tblGRNItems]
ON [dbo].[tblGRNItems]
    ([ReasonID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblGRNItems'
ALTER TABLE [dbo].[tblGRNItems]
ADD CONSTRAINT [FK_tblsysUser_tblGRNItems]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblGRNItems'
CREATE INDEX [IX_FK_tblsysUser_tblGRNItems]
ON [dbo].[tblGRNItems]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblGRNItems'
ALTER TABLE [dbo].[tblGRNItems]
ADD CONSTRAINT [FK_tblSysUser1_tblGRNItems]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblGRNItems'
CREATE INDEX [IX_FK_tblSysUser1_tblGRNItems]
ON [dbo].[tblGRNItems]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblHOBranchPriceDetails'
ALTER TABLE [dbo].[tblHOBranchPriceDetails]
ADD CONSTRAINT [FK_tblItem_tblHOBranchPriceDetails]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblHOBranchPriceDetails'
CREATE INDEX [IX_FK_tblItem_tblHOBranchPriceDetails]
ON [dbo].[tblHOBranchPriceDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [BranchID] in table 'tblHOBranchPriceDetails'
ALTER TABLE [dbo].[tblHOBranchPriceDetails]
ADD CONSTRAINT [FK_tblSysBranch_tblHOBranchPriceDetails]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_tblHOBranchPriceDetails'
CREATE INDEX [IX_FK_tblSysBranch_tblHOBranchPriceDetails]
ON [dbo].[tblHOBranchPriceDetails]
    ([BranchID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblHOBranchPriceDetails'
ALTER TABLE [dbo].[tblHOBranchPriceDetails]
ADD CONSTRAINT [FK_tblsysUser_tblHOBranchPriceDetails]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblHOBranchPriceDetails'
CREATE INDEX [IX_FK_tblsysUser_tblHOBranchPriceDetails]
ON [dbo].[tblHOBranchPriceDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblHOBranchPriceDetails'
ALTER TABLE [dbo].[tblHOBranchPriceDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblHOBranchPriceDetails]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblHOBranchPriceDetails'
CREATE INDEX [IX_FK_tblSysUser1_tblHOBranchPriceDetails]
ON [dbo].[tblHOBranchPriceDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblHOMasterPriceDetails'
ALTER TABLE [dbo].[tblHOMasterPriceDetails]
ADD CONSTRAINT [FK_tblItem_tblHOMasterPriceDetails]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblHOMasterPriceDetails'
CREATE INDEX [IX_FK_tblItem_tblHOMasterPriceDetails]
ON [dbo].[tblHOMasterPriceDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [RateID] in table 'tblHOMasterPriceDetails'
ALTER TABLE [dbo].[tblHOMasterPriceDetails]
ADD CONSTRAINT [FK_tblItemRate_tblHOMasterPriceDetails]
    FOREIGN KEY ([RateID])
    REFERENCES [dbo].[tblItemRates]
        ([RateID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemRate_tblHOMasterPriceDetails'
CREATE INDEX [IX_FK_tblItemRate_tblHOMasterPriceDetails]
ON [dbo].[tblHOMasterPriceDetails]
    ([RateID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblHOMasterPriceDetails'
ALTER TABLE [dbo].[tblHOMasterPriceDetails]
ADD CONSTRAINT [FK_tblsysUser_tblHOMasterPriceDetails]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblHOMasterPriceDetails'
CREATE INDEX [IX_FK_tblsysUser_tblHOMasterPriceDetails]
ON [dbo].[tblHOMasterPriceDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblHOMasterPriceDetails'
ALTER TABLE [dbo].[tblHOMasterPriceDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblHOMasterPriceDetails]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblHOMasterPriceDetails'
CREATE INDEX [IX_FK_tblSysUser1_tblHOMasterPriceDetails]
ON [dbo].[tblHOMasterPriceDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblHSNCodes'
ALTER TABLE [dbo].[tblHSNCodes]
ADD CONSTRAINT [FK_tblsysUser_tblHSNCode]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblHSNCode'
CREATE INDEX [IX_FK_tblsysUser_tblHSNCode]
ON [dbo].[tblHSNCodes]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblHSNCodes'
ALTER TABLE [dbo].[tblHSNCodes]
ADD CONSTRAINT [FK_tblSysUser1_tblHSNCode]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblHSNCode'
CREATE INDEX [IX_FK_tblSysUser1_tblHSNCode]
ON [dbo].[tblHSNCodes]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblItemStockTransferDestinations'
ALTER TABLE [dbo].[tblItemStockTransferDestinations]
ADD CONSTRAINT [FK_Itbltem_tblItemStockTransferDestination]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_tblItemStockTransferDestination'
CREATE INDEX [IX_FK_Itbltem_tblItemStockTransferDestination]
ON [dbo].[tblItemStockTransferDestinations]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblItemStockTransferSources'
ALTER TABLE [dbo].[tblItemStockTransferSources]
ADD CONSTRAINT [FK_Itbltem_tblItemStockTransferSource]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_tblItemStockTransferSource'
CREATE INDEX [IX_FK_Itbltem_tblItemStockTransferSource]
ON [dbo].[tblItemStockTransferSources]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblPurchaseOrderWithItems'
ALTER TABLE [dbo].[tblPurchaseOrderWithItems]
ADD CONSTRAINT [FK_Itbltem_tblPurchaseOrderWithItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_tblPurchaseOrderWithItem'
CREATE INDEX [IX_FK_Itbltem_tblPurchaseOrderWithItem]
ON [dbo].[tblPurchaseOrderWithItems]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblSalesOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_Itbltem_tblSalesOrderInvoiceItemDetail]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_tblSalesOrderInvoiceItemDetail'
CREATE INDEX [IX_FK_Itbltem_tblSalesOrderInvoiceItemDetail]
ON [dbo].[tblSalesOrderInvoiceItemDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblSalesOrderItemWarehouseMaps'
ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMaps]
ADD CONSTRAINT [FK_Itbltem_tblSalesOrderItemWarehouseMap]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_tblSalesOrderItemWarehouseMap'
CREATE INDEX [IX_FK_Itbltem_tblSalesOrderItemWarehouseMap]
ON [dbo].[tblSalesOrderItemWarehouseMaps]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblSalesOrderWithItems'
ALTER TABLE [dbo].[tblSalesOrderWithItems]
ADD CONSTRAINT [FK_Itbltem_tblSalesOrderWithItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Itbltem_tblSalesOrderWithItem'
CREATE INDEX [IX_FK_Itbltem_tblSalesOrderWithItem]
ON [dbo].[tblSalesOrderWithItems]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblItemMappings'
ALTER TABLE [dbo].[tblItemMappings]
ADD CONSTRAINT [FK_tblItem_tblItemMapping]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblItemMapping'
CREATE INDEX [IX_FK_tblItem_tblItemMapping]
ON [dbo].[tblItemMappings]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblItemMappingWithCESSes'
ALTER TABLE [dbo].[tblItemMappingWithCESSes]
ADD CONSTRAINT [FK_tblItem_tblItemMappingWithCESS]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblItemMappingWithCESS'
CREATE INDEX [IX_FK_tblItem_tblItemMappingWithCESS]
ON [dbo].[tblItemMappingWithCESSes]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblItemMovements'
ALTER TABLE [dbo].[tblItemMovements]
ADD CONSTRAINT [FK_tblItem_tblItemMovement]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblItemMovement'
CREATE INDEX [IX_FK_tblItem_tblItemMovement]
ON [dbo].[tblItemMovements]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblItemParameterMaps'
ALTER TABLE [dbo].[tblItemParameterMaps]
ADD CONSTRAINT [FK_tblItem_tblItemParameterMap]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblItemParameterMap'
CREATE INDEX [IX_FK_tblItem_tblItemParameterMap]
ON [dbo].[tblItemParameterMaps]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblItemSupplierMappings'
ALTER TABLE [dbo].[tblItemSupplierMappings]
ADD CONSTRAINT [FK_tblItem_tblItemSupplierMapping]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblItemSupplierMapping'
CREATE INDEX [IX_FK_tblItem_tblItemSupplierMapping]
ON [dbo].[tblItemSupplierMappings]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblItemWarehouseMaps'
ALTER TABLE [dbo].[tblItemWarehouseMaps]
ADD CONSTRAINT [FK_tblItem_tblItemWarehouseMap]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblItemWarehouseMap'
CREATE INDEX [IX_FK_tblItem_tblItemWarehouseMap]
ON [dbo].[tblItemWarehouseMaps]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblPOQuotations'
ALTER TABLE [dbo].[tblPOQuotations]
ADD CONSTRAINT [FK_tblItem_tblPOQuotation]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblPOQuotation'
CREATE INDEX [IX_FK_tblItem_tblPOQuotation]
ON [dbo].[tblPOQuotations]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblPurchaseRequisitionItemsDetails'
ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetails]
ADD CONSTRAINT [FK_tblItem_tblPurchaseRequisitionItemsDetail]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblPurchaseRequisitionItemsDetail'
CREATE INDEX [IX_FK_tblItem_tblPurchaseRequisitionItemsDetail]
ON [dbo].[tblPurchaseRequisitionItemsDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblStockTransferLineItems'
ALTER TABLE [dbo].[tblStockTransferLineItems]
ADD CONSTRAINT [FK_tblItem_tblStockTransferLineItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItem_tblStockTransferLineItem'
CREATE INDEX [IX_FK_tblItem_tblStockTransferLineItem]
ON [dbo].[tblStockTransferLineItems]
    ([ItemCode]);
GO

-- Creating foreign key on [ItemCode] in table 'tblItemImageDetails'
ALTER TABLE [dbo].[tblItemImageDetails]
ADD CONSTRAINT [FK_tblItemImageDetails_tblItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemImageDetails_tblItem'
CREATE INDEX [IX_FK_tblItemImageDetails_tblItem]
ON [dbo].[tblItemImageDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [RateID] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [FK_tblItemRate_tblItem]
    FOREIGN KEY ([RateID])
    REFERENCES [dbo].[tblItemRates]
        ([RateID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemRate_tblItem'
CREATE INDEX [IX_FK_tblItemRate_tblItem]
ON [dbo].[tblItems]
    ([RateID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblPurchaseOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_tblPurchaseOrderInvoiceItemDetail_tblItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrderInvoiceItemDetail_tblItem'
CREATE INDEX [IX_FK_tblPurchaseOrderInvoiceItemDetail_tblItem]
ON [dbo].[tblPurchaseOrderInvoiceItemDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [RackID] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [FK_tblRack_tblItem]
    FOREIGN KEY ([RackID])
    REFERENCES [dbo].[tblRacks]
        ([RackID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblRack_tblItem'
CREATE INDEX [IX_FK_tblRack_tblItem]
ON [dbo].[tblItems]
    ([RackID]);
GO

-- Creating foreign key on [ItemCode] in table 'tblStickerDetails'
ALTER TABLE [dbo].[tblStickerDetails]
ADD CONSTRAINT [FK_tblStickerDetails_tblItem]
    FOREIGN KEY ([ItemCode])
    REFERENCES [dbo].[tblItems]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStickerDetails_tblItem'
CREATE INDEX [IX_FK_tblStickerDetails_tblItem]
ON [dbo].[tblStickerDetails]
    ([ItemCode]);
GO

-- Creating foreign key on [SubCategoryID] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [FK_tblSubCategory_tblItem]
    FOREIGN KEY ([SubCategoryID])
    REFERENCES [dbo].[tblSubCategories]
        ([SubCategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSubCategory_tblItem'
CREATE INDEX [IX_FK_tblSubCategory_tblItem]
ON [dbo].[tblItems]
    ([SubCategoryID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [FK_tblsysUser_tblItem]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblItem'
CREATE INDEX [IX_FK_tblsysUser_tblItem]
ON [dbo].[tblItems]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [FK_tblSysUser1_tblItem]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblItem'
CREATE INDEX [IX_FK_tblSysUser1_tblItem]
ON [dbo].[tblItems]
    ([ModifiedByID]);
GO

-- Creating foreign key on [BagUOMID] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [FK_tblUOM_tblItem]
    FOREIGN KEY ([BagUOMID])
    REFERENCES [dbo].[tblUOMs]
        ([UnitID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUOM_tblItem'
CREATE INDEX [IX_FK_tblUOM_tblItem]
ON [dbo].[tblItems]
    ([BagUOMID]);
GO

-- Creating foreign key on [PacketUOMID] in table 'tblItems'
ALTER TABLE [dbo].[tblItems]
ADD CONSTRAINT [FK_tblUOM_tblItem1]
    FOREIGN KEY ([PacketUOMID])
    REFERENCES [dbo].[tblUOMs]
        ([UnitID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUOM_tblItem1'
CREATE INDEX [IX_FK_tblUOM_tblItem1]
ON [dbo].[tblItems]
    ([PacketUOMID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemCompanies'
ALTER TABLE [dbo].[tblItemCompanies]
ADD CONSTRAINT [FK_tblsysUser_ItemCompanyID]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_ItemCompanyID'
CREATE INDEX [IX_FK_tblsysUser_ItemCompanyID]
ON [dbo].[tblItemCompanies]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblItemCompanies'
ALTER TABLE [dbo].[tblItemCompanies]
ADD CONSTRAINT [FK_tblSysUser1_tblItemCompany]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblItemCompany'
CREATE INDEX [IX_FK_tblSysUser1_tblItemCompany]
ON [dbo].[tblItemCompanies]
    ([ModifiedByID]);
GO

-- Creating foreign key on [RateID] in table 'tblItemMappings'
ALTER TABLE [dbo].[tblItemMappings]
ADD CONSTRAINT [FK_tblItemRate_tblItemMapping]
    FOREIGN KEY ([RateID])
    REFERENCES [dbo].[tblItemRates]
        ([RateID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemRate_tblItemMapping'
CREATE INDEX [IX_FK_tblItemRate_tblItemMapping]
ON [dbo].[tblItemMappings]
    ([RateID]);
GO

-- Creating foreign key on [BranchID] in table 'tblItemMappings'
ALTER TABLE [dbo].[tblItemMappings]
ADD CONSTRAINT [FK_tblSysBranch_tblItemMapping]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_tblItemMapping'
CREATE INDEX [IX_FK_tblSysBranch_tblItemMapping]
ON [dbo].[tblItemMappings]
    ([BranchID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemMappingWithCESSes'
ALTER TABLE [dbo].[tblItemMappingWithCESSes]
ADD CONSTRAINT [FK_tblsysUser_tblItemMappingWithCESS]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblItemMappingWithCESS'
CREATE INDEX [IX_FK_tblsysUser_tblItemMappingWithCESS]
ON [dbo].[tblItemMappingWithCESSes]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblItemMappingWithCESSes'
ALTER TABLE [dbo].[tblItemMappingWithCESSes]
ADD CONSTRAINT [FK_tblSysUser1_tblItemMappingWithCESS]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblItemMappingWithCESS'
CREATE INDEX [IX_FK_tblSysUser1_tblItemMappingWithCESS]
ON [dbo].[tblItemMappingWithCESSes]
    ([ModifiedByID]);
GO

-- Creating foreign key on [SalesOrderNumber] in table 'tblItemMovements'
ALTER TABLE [dbo].[tblItemMovements]
ADD CONSTRAINT [FK_tblSalesOrder_tblItemMovement]
    FOREIGN KEY ([SalesOrderNumber])
    REFERENCES [dbo].[tblSalesOrders]
        ([SalesOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrder_tblItemMovement'
CREATE INDEX [IX_FK_tblSalesOrder_tblItemMovement]
ON [dbo].[tblItemMovements]
    ([SalesOrderNumber]);
GO

-- Creating foreign key on [SalesOrderWithItemID] in table 'tblItemMovements'
ALTER TABLE [dbo].[tblItemMovements]
ADD CONSTRAINT [FK_tblSalesOrderWithItem_tblItemMovement]
    FOREIGN KEY ([SalesOrderWithItemID])
    REFERENCES [dbo].[tblSalesOrderWithItems]
        ([SalesOrderWithItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrderWithItem_tblItemMovement'
CREATE INDEX [IX_FK_tblSalesOrderWithItem_tblItemMovement]
ON [dbo].[tblItemMovements]
    ([SalesOrderWithItemID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemMovements'
ALTER TABLE [dbo].[tblItemMovements]
ADD CONSTRAINT [FK_tblsysUser_tblItemMovement]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblItemMovement'
CREATE INDEX [IX_FK_tblsysUser_tblItemMovement]
ON [dbo].[tblItemMovements]
    ([CreatedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblItemMovements'
ALTER TABLE [dbo].[tblItemMovements]
ADD CONSTRAINT [FK_tblWarehouse_tblItemMovement]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblItemMovement'
CREATE INDEX [IX_FK_tblWarehouse_tblItemMovement]
ON [dbo].[tblItemMovements]
    ([WarehouseID]);
GO

-- Creating foreign key on [ParameterID] in table 'tblItemParameterMaps'
ALTER TABLE [dbo].[tblItemParameterMaps]
ADD CONSTRAINT [FK_tblParameter_tblItemParameterMap]
    FOREIGN KEY ([ParameterID])
    REFERENCES [dbo].[tblParameters]
        ([ParameterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblParameter_tblItemParameterMap'
CREATE INDEX [IX_FK_tblParameter_tblItemParameterMap]
ON [dbo].[tblItemParameterMaps]
    ([ParameterID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemParameterMaps'
ALTER TABLE [dbo].[tblItemParameterMaps]
ADD CONSTRAINT [FK_tblSystblUser_tblItemParameterMap]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSystblUser_tblItemParameterMap'
CREATE INDEX [IX_FK_tblSystblUser_tblItemParameterMap]
ON [dbo].[tblItemParameterMaps]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblItemParameterMaps'
ALTER TABLE [dbo].[tblItemParameterMaps]
ADD CONSTRAINT [FK_tblSysUser1_tblItemParameterMap]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblItemParameterMap'
CREATE INDEX [IX_FK_tblSysUser1_tblItemParameterMap]
ON [dbo].[tblItemParameterMaps]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemRates'
ALTER TABLE [dbo].[tblItemRates]
ADD CONSTRAINT [FK_tblSysUser_tblItemRate]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblItemRate'
CREATE INDEX [IX_FK_tblSysUser_tblItemRate]
ON [dbo].[tblItemRates]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblItemRates'
ALTER TABLE [dbo].[tblItemRates]
ADD CONSTRAINT [FK_tblSysUser1_tblItemRate]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblItemRate'
CREATE INDEX [IX_FK_tblSysUser1_tblItemRate]
ON [dbo].[tblItemRates]
    ([ModifiedByID]);
GO

-- Creating foreign key on [PerUnitRate] in table 'tblItemRates'
ALTER TABLE [dbo].[tblItemRates]
ADD CONSTRAINT [FK_tblUOM_tblItemRate]
    FOREIGN KEY ([PerUnitRate])
    REFERENCES [dbo].[tblUOMs]
        ([UnitID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUOM_tblItemRate'
CREATE INDEX [IX_FK_tblUOM_tblItemRate]
ON [dbo].[tblItemRates]
    ([PerUnitRate]);
GO

-- Creating foreign key on [ItemStockTransferSourceID] in table 'tblItemStockTransferDestinations'
ALTER TABLE [dbo].[tblItemStockTransferDestinations]
ADD CONSTRAINT [FK_tblItemStockTransferSource_tblItemStockTransferDestination]
    FOREIGN KEY ([ItemStockTransferSourceID])
    REFERENCES [dbo].[tblItemStockTransferSources]
        ([ItemStockTransferSourceID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemStockTransferSource_tblItemStockTransferDestination'
CREATE INDEX [IX_FK_tblItemStockTransferSource_tblItemStockTransferDestination]
ON [dbo].[tblItemStockTransferDestinations]
    ([ItemStockTransferSourceID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemStockTransferDestinations'
ALTER TABLE [dbo].[tblItemStockTransferDestinations]
ADD CONSTRAINT [FK_tblsysUser_tblItemStockTransferDestination]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblItemStockTransferDestination'
CREATE INDEX [IX_FK_tblsysUser_tblItemStockTransferDestination]
ON [dbo].[tblItemStockTransferDestinations]
    ([CreatedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblItemStockTransferDestinations'
ALTER TABLE [dbo].[tblItemStockTransferDestinations]
ADD CONSTRAINT [FK_tblWarehouse_tblItemStockTransferDestination]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblItemStockTransferDestination'
CREATE INDEX [IX_FK_tblWarehouse_tblItemStockTransferDestination]
ON [dbo].[tblItemStockTransferDestinations]
    ([WarehouseID]);
GO

-- Creating foreign key on [ItemStockTransferHeaderID] in table 'tblItemStockTransferSources'
ALTER TABLE [dbo].[tblItemStockTransferSources]
ADD CONSTRAINT [FK_tblItemStockTransferHeader_tblItemStockTransferSource]
    FOREIGN KEY ([ItemStockTransferHeaderID])
    REFERENCES [dbo].[tblItemStockTransferHeaders]
        ([ItemStockTransferHeaderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemStockTransferHeader_tblItemStockTransferSource'
CREATE INDEX [IX_FK_tblItemStockTransferHeader_tblItemStockTransferSource]
ON [dbo].[tblItemStockTransferSources]
    ([ItemStockTransferHeaderID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemStockTransferHeaders'
ALTER TABLE [dbo].[tblItemStockTransferHeaders]
ADD CONSTRAINT [FK_tblSysUser_tblItemStockTransferHeader]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblItemStockTransferHeader'
CREATE INDEX [IX_FK_tblSysUser_tblItemStockTransferHeader]
ON [dbo].[tblItemStockTransferHeaders]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemStockTransferSources'
ALTER TABLE [dbo].[tblItemStockTransferSources]
ADD CONSTRAINT [FK_tblUser_tblItemStockTransferSource]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblItemStockTransferSource'
CREATE INDEX [IX_FK_tblUser_tblItemStockTransferSource]
ON [dbo].[tblItemStockTransferSources]
    ([CreatedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblItemStockTransferSources'
ALTER TABLE [dbo].[tblItemStockTransferSources]
ADD CONSTRAINT [FK_tblWarehouse_tblItemStockTransferSource]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblItemStockTransferSource'
CREATE INDEX [IX_FK_tblWarehouse_tblItemStockTransferSource]
ON [dbo].[tblItemStockTransferSources]
    ([WarehouseID]);
GO

-- Creating foreign key on [DelivercenterID] in table 'tblItemSupplierMappings'
ALTER TABLE [dbo].[tblItemSupplierMappings]
ADD CONSTRAINT [FK_tblItemSupplierMapping_tblWarehouse]
    FOREIGN KEY ([DelivercenterID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblItemSupplierMapping_tblWarehouse'
CREATE INDEX [IX_FK_tblItemSupplierMapping_tblWarehouse]
ON [dbo].[tblItemSupplierMappings]
    ([DelivercenterID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemSupplierMappings'
ALTER TABLE [dbo].[tblItemSupplierMappings]
ADD CONSTRAINT [FK_tblsysUser_tblItemSupplierMapping]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblItemSupplierMapping'
CREATE INDEX [IX_FK_tblsysUser_tblItemSupplierMapping]
ON [dbo].[tblItemSupplierMappings]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblItemSupplierMappings'
ALTER TABLE [dbo].[tblItemSupplierMappings]
ADD CONSTRAINT [FK_tblSysUser1_tblItemSupplierMapping]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblItemSupplierMapping'
CREATE INDEX [IX_FK_tblSysUser1_tblItemSupplierMapping]
ON [dbo].[tblItemSupplierMappings]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemToItemTrackings'
ALTER TABLE [dbo].[tblItemToItemTrackings]
ADD CONSTRAINT [FK_tblSysUser_tblItemToItemTracking]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblItemToItemTracking'
CREATE INDEX [IX_FK_tblSysUser_tblItemToItemTracking]
ON [dbo].[tblItemToItemTrackings]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblItemToItemTrackings'
ALTER TABLE [dbo].[tblItemToItemTrackings]
ADD CONSTRAINT [FK_tblSysUser1_tblItemToItemTracking]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblItemToItemTracking'
CREATE INDEX [IX_FK_tblSysUser1_tblItemToItemTracking]
ON [dbo].[tblItemToItemTrackings]
    ([ModifiedByID]);
GO

-- Creating foreign key on [BranchID] in table 'tblItemWarehouseMaps'
ALTER TABLE [dbo].[tblItemWarehouseMaps]
ADD CONSTRAINT [FK_tblSysBranch_tblItemWarehouseMap]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_tblItemWarehouseMap'
CREATE INDEX [IX_FK_tblSysBranch_tblItemWarehouseMap]
ON [dbo].[tblItemWarehouseMaps]
    ([BranchID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblItemWarehouseMaps'
ALTER TABLE [dbo].[tblItemWarehouseMaps]
ADD CONSTRAINT [FK_tblsysUser_tblItemWarehouseMap]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblItemWarehouseMap'
CREATE INDEX [IX_FK_tblsysUser_tblItemWarehouseMap]
ON [dbo].[tblItemWarehouseMaps]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblItemWarehouseMaps'
ALTER TABLE [dbo].[tblItemWarehouseMaps]
ADD CONSTRAINT [FK_tblSysUser1_tblItemWarehouseMap]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblItemWarehouseMap'
CREATE INDEX [IX_FK_tblSysUser1_tblItemWarehouseMap]
ON [dbo].[tblItemWarehouseMaps]
    ([ModifiedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblItemWarehouseMaps'
ALTER TABLE [dbo].[tblItemWarehouseMaps]
ADD CONSTRAINT [FK_tblWarehouse_tblItemWarehouseMap]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblItemWarehouseMap'
CREATE INDEX [IX_FK_tblWarehouse_tblItemWarehouseMap]
ON [dbo].[tblItemWarehouseMaps]
    ([WarehouseID]);
GO

-- Creating foreign key on [UserID] in table 'tblNotifications'
ALTER TABLE [dbo].[tblNotifications]
ADD CONSTRAINT [FK_tblNotification_tblSysUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblNotification_tblSysUser'
CREATE INDEX [IX_FK_tblNotification_tblSysUser]
ON [dbo].[tblNotifications]
    ([UserID]);
GO

-- Creating foreign key on [BranchID] in table 'tblOrganizationWarehouseMaps'
ALTER TABLE [dbo].[tblOrganizationWarehouseMaps]
ADD CONSTRAINT [FK_tblSysBranch_tblOrganizationWarehouseMap]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_tblOrganizationWarehouseMap'
CREATE INDEX [IX_FK_tblSysBranch_tblOrganizationWarehouseMap]
ON [dbo].[tblOrganizationWarehouseMaps]
    ([BranchID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblOrganizationWarehouseMaps'
ALTER TABLE [dbo].[tblOrganizationWarehouseMaps]
ADD CONSTRAINT [FK_tblSysUser_tblOrganizationWarehouseMap]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblOrganizationWarehouseMap'
CREATE INDEX [IX_FK_tblSysUser_tblOrganizationWarehouseMap]
ON [dbo].[tblOrganizationWarehouseMaps]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblOrganizationWarehouseMaps'
ALTER TABLE [dbo].[tblOrganizationWarehouseMaps]
ADD CONSTRAINT [FK_tblSysUser1_tblOrganizationWarehouseMap]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblOrganizationWarehouseMap'
CREATE INDEX [IX_FK_tblSysUser1_tblOrganizationWarehouseMap]
ON [dbo].[tblOrganizationWarehouseMaps]
    ([ModifiedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblOrganizationWarehouseMaps'
ALTER TABLE [dbo].[tblOrganizationWarehouseMaps]
ADD CONSTRAINT [FK_tblWarehouse_tblOrganizationWarehouseMap]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblOrganizationWarehouseMap'
CREATE INDEX [IX_FK_tblWarehouse_tblOrganizationWarehouseMap]
ON [dbo].[tblOrganizationWarehouseMaps]
    ([WarehouseID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPacketSizeDetails'
ALTER TABLE [dbo].[tblPacketSizeDetails]
ADD CONSTRAINT [FK_tblSysUser_tblPacketSizeDetails]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblPacketSizeDetails'
CREATE INDEX [IX_FK_tblSysUser_tblPacketSizeDetails]
ON [dbo].[tblPacketSizeDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPacketSizeDetails'
ALTER TABLE [dbo].[tblPacketSizeDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblPacketSizeDetails]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPacketSizeDetails'
CREATE INDEX [IX_FK_tblSysUser1_tblPacketSizeDetails]
ON [dbo].[tblPacketSizeDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [SubCategoryID] in table 'tblParameters'
ALTER TABLE [dbo].[tblParameters]
ADD CONSTRAINT [FK_tblSubCategory_tblParameter]
    FOREIGN KEY ([SubCategoryID])
    REFERENCES [dbo].[tblSubCategories]
        ([SubCategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSubCategory_tblParameter'
CREATE INDEX [IX_FK_tblSubCategory_tblParameter]
ON [dbo].[tblParameters]
    ([SubCategoryID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblParameters'
ALTER TABLE [dbo].[tblParameters]
ADD CONSTRAINT [FK_tblSystblUser_tblParameter]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSystblUser_tblParameter'
CREATE INDEX [IX_FK_tblSystblUser_tblParameter]
ON [dbo].[tblParameters]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblParameters'
ALTER TABLE [dbo].[tblParameters]
ADD CONSTRAINT [FK_tblSysUser1_tblParameter]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblParameter'
CREATE INDEX [IX_FK_tblSysUser1_tblParameter]
ON [dbo].[tblParameters]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPaymentReceipts'
ALTER TABLE [dbo].[tblPaymentReceipts]
ADD CONSTRAINT [FK_tblSysUser_tblPaymentReceipt]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblPaymentReceipt'
CREATE INDEX [IX_FK_tblSysUser_tblPaymentReceipt]
ON [dbo].[tblPaymentReceipts]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPaymentReceipts'
ALTER TABLE [dbo].[tblPaymentReceipts]
ADD CONSTRAINT [FK_tblSysUser1_tblPaymentReceipt]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPaymentReceipt'
CREATE INDEX [IX_FK_tblSysUser1_tblPaymentReceipt]
ON [dbo].[tblPaymentReceipts]
    ([ModifiedByID]);
GO

-- Creating foreign key on [pcn_num] in table 'tblPCN_Details'
ALTER TABLE [dbo].[tblPCN_Details]
ADD CONSTRAINT [FK_tblPCN_Details_tblPCN_Details]
    FOREIGN KEY ([pcn_num])
    REFERENCES [dbo].[tblPNCNs]
        ([pcn_num])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPCN_Details_tblPCN_Details'
CREATE INDEX [IX_FK_tblPCN_Details_tblPCN_Details]
ON [dbo].[tblPCN_Details]
    ([pcn_num]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPercentageStructures'
ALTER TABLE [dbo].[tblPercentageStructures]
ADD CONSTRAINT [FK_tblsysUser_tblPercentageStructure]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblPercentageStructure'
CREATE INDEX [IX_FK_tblsysUser_tblPercentageStructure]
ON [dbo].[tblPercentageStructures]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPercentageStructures'
ALTER TABLE [dbo].[tblPercentageStructures]
ADD CONSTRAINT [FK_tblSysUser1_tblPercentageStructure]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPercentageStructure'
CREATE INDEX [IX_FK_tblSysUser1_tblPercentageStructure]
ON [dbo].[tblPercentageStructures]
    ([ModifiedByID]);
GO

-- Creating foreign key on [POQuotationID] in table 'tblPOQuotationSuppliers'
ALTER TABLE [dbo].[tblPOQuotationSuppliers]
ADD CONSTRAINT [FK_tblPOQuotation_tblPOQuotationSuppliers]
    FOREIGN KEY ([POQuotationID])
    REFERENCES [dbo].[tblPOQuotations]
        ([POQuotationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPOQuotation_tblPOQuotationSuppliers'
CREATE INDEX [IX_FK_tblPOQuotation_tblPOQuotationSuppliers]
ON [dbo].[tblPOQuotationSuppliers]
    ([POQuotationID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPOQuotations'
ALTER TABLE [dbo].[tblPOQuotations]
ADD CONSTRAINT [FK_tblsysUser_tblPOQuotation]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblPOQuotation'
CREATE INDEX [IX_FK_tblsysUser_tblPOQuotation]
ON [dbo].[tblPOQuotations]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPOQuotations'
ALTER TABLE [dbo].[tblPOQuotations]
ADD CONSTRAINT [FK_tblSysUser1_tblPOQuotation]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPOQuotation'
CREATE INDEX [IX_FK_tblSysUser1_tblPOQuotation]
ON [dbo].[tblPOQuotations]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPOQuotationSuppliers'
ALTER TABLE [dbo].[tblPOQuotationSuppliers]
ADD CONSTRAINT [FK_tblsysUser_tblPOQuotationSuppliers]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblPOQuotationSuppliers'
CREATE INDEX [IX_FK_tblsysUser_tblPOQuotationSuppliers]
ON [dbo].[tblPOQuotationSuppliers]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPOQuotationSuppliers'
ALTER TABLE [dbo].[tblPOQuotationSuppliers]
ADD CONSTRAINT [FK_tblSysUser1_tblPOQuotationSuppliers]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPOQuotationSuppliers'
CREATE INDEX [IX_FK_tblSysUser1_tblPOQuotationSuppliers]
ON [dbo].[tblPOQuotationSuppliers]
    ([ModifiedByID]);
GO

-- Creating foreign key on [PurchaseOrderNumber] in table 'tblPurchaseOrderWithItems'
ALTER TABLE [dbo].[tblPurchaseOrderWithItems]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblPurchaseOrderWithItem]
    FOREIGN KEY ([PurchaseOrderNumber])
    REFERENCES [dbo].[tblPurchaseOrders]
        ([PurchaseOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblPurchaseOrderWithItem'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblPurchaseOrderWithItem]
ON [dbo].[tblPurchaseOrderWithItems]
    ([PurchaseOrderNumber]);
GO

-- Creating foreign key on [PurchaseRequisitionNumber] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblPurchaseRequisition]
    FOREIGN KEY ([PurchaseRequisitionNumber])
    REFERENCES [dbo].[tblPurchaseRequisitions]
        ([RequisitionNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblPurchaseRequisition'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblPurchaseRequisition]
ON [dbo].[tblPurchaseOrders]
    ([PurchaseRequisitionNumber]);
GO

-- Creating foreign key on [SalesOrderNumber] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblSalesOrder]
    FOREIGN KEY ([SalesOrderNumber])
    REFERENCES [dbo].[tblSalesOrders]
        ([SalesOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblSalesOrder'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblSalesOrder]
ON [dbo].[tblPurchaseOrders]
    ([SalesOrderNumber]);
GO

-- Creating foreign key on [BranchId] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblSysBranch]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblSysBranch'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblSysBranch]
ON [dbo].[tblPurchaseOrders]
    ([BranchId]);
GO

-- Creating foreign key on [BrokerId] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblSysUser]
    FOREIGN KEY ([BrokerId])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblSysUser'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblSysUser]
ON [dbo].[tblPurchaseOrders]
    ([BrokerId]);
GO

-- Creating foreign key on [OperatorId] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblSysUser1]
    FOREIGN KEY ([OperatorId])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblSysUser1'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblSysUser1]
ON [dbo].[tblPurchaseOrders]
    ([OperatorId]);
GO

-- Creating foreign key on [PurchaseOrderNumber] in table 'tblTransitItems'
ALTER TABLE [dbo].[tblTransitItems]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblTransitItem]
    FOREIGN KEY ([PurchaseOrderNumber])
    REFERENCES [dbo].[tblPurchaseOrders]
        ([PurchaseOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblTransitItem'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblTransitItem]
ON [dbo].[tblTransitItems]
    ([PurchaseOrderNumber]);
GO

-- Creating foreign key on [VoucherTypeNo] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblVoucherType]
    FOREIGN KEY ([VoucherTypeNo])
    REFERENCES [dbo].[tblVoucherTypes]
        ([VoucherTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblVoucherType'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblVoucherType]
ON [dbo].[tblPurchaseOrders]
    ([VoucherTypeNo]);
GO

-- Creating foreign key on [WareHouseId] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblPurchaseOrder_tblWarehouse]
    FOREIGN KEY ([WareHouseId])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrder_tblWarehouse'
CREATE INDEX [IX_FK_tblPurchaseOrder_tblWarehouse]
ON [dbo].[tblPurchaseOrders]
    ([WareHouseId]);
GO

-- Creating foreign key on [PurchaseOrderNumber] in table 'tblPurchaseOrderInvoices'
ALTER TABLE [dbo].[tblPurchaseOrderInvoices]
ADD CONSTRAINT [FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoice]
    FOREIGN KEY ([PurchaseOrderNumber])
    REFERENCES [dbo].[tblPurchaseOrders]
        ([PurchaseOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoice'
CREATE INDEX [IX_FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoice]
ON [dbo].[tblPurchaseOrderInvoices]
    ([PurchaseOrderNumber]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblSysUser1_tblPurchaseOrder]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPurchaseOrder'
CREATE INDEX [IX_FK_tblSysUser1_tblPurchaseOrder]
ON [dbo].[tblPurchaseOrders]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPurchaseOrders'
ALTER TABLE [dbo].[tblPurchaseOrders]
ADD CONSTRAINT [FK_tblUser_tblPurchaseOrder]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblPurchaseOrder'
CREATE INDEX [IX_FK_tblUser_tblPurchaseOrder]
ON [dbo].[tblPurchaseOrders]
    ([CreatedByID]);
GO

-- Creating foreign key on [POInvoiceReferenceNumbe] in table 'tblPurchaseOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoiceItemDetail]
    FOREIGN KEY ([POInvoiceReferenceNumbe])
    REFERENCES [dbo].[tblPurchaseOrderInvoices]
        ([POInvoiceReferenceNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoiceItemDetail'
CREATE INDEX [IX_FK_tblPurchaseOrderInvoice_tblPurchaseOrderInvoiceItemDetail]
ON [dbo].[tblPurchaseOrderInvoiceItemDetails]
    ([POInvoiceReferenceNumbe]);
GO

-- Creating foreign key on [VoucherTypeNo] in table 'tblPurchaseOrderInvoices'
ALTER TABLE [dbo].[tblPurchaseOrderInvoices]
ADD CONSTRAINT [FK_tblPurchaseOrderInvoice_tblVoucherType]
    FOREIGN KEY ([VoucherTypeNo])
    REFERENCES [dbo].[tblVoucherTypes]
        ([VoucherTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrderInvoice_tblVoucherType'
CREATE INDEX [IX_FK_tblPurchaseOrderInvoice_tblVoucherType]
ON [dbo].[tblPurchaseOrderInvoices]
    ([VoucherTypeNo]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPurchaseOrderInvoices'
ALTER TABLE [dbo].[tblPurchaseOrderInvoices]
ADD CONSTRAINT [FK_tblSysUser1_tblPurchaseOrderInvoice]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPurchaseOrderInvoice'
CREATE INDEX [IX_FK_tblSysUser1_tblPurchaseOrderInvoice]
ON [dbo].[tblPurchaseOrderInvoices]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPurchaseOrderInvoices'
ALTER TABLE [dbo].[tblPurchaseOrderInvoices]
ADD CONSTRAINT [FK_tblUser_tblPurchaseOrderInvoice]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblPurchaseOrderInvoice'
CREATE INDEX [IX_FK_tblUser_tblPurchaseOrderInvoice]
ON [dbo].[tblPurchaseOrderInvoices]
    ([CreatedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblPurchaseOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_tblPurchaseOrderInvoiceItemDetail_tblWarehouse]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseOrderInvoiceItemDetail_tblWarehouse'
CREATE INDEX [IX_FK_tblPurchaseOrderInvoiceItemDetail_tblWarehouse]
ON [dbo].[tblPurchaseOrderInvoiceItemDetails]
    ([WarehouseID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPurchaseOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblPurchaseOrderInvoiceItemDetail]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPurchaseOrderInvoiceItemDetail'
CREATE INDEX [IX_FK_tblSysUser1_tblPurchaseOrderInvoiceItemDetail]
ON [dbo].[tblPurchaseOrderInvoiceItemDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPurchaseOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblPurchaseOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_tblUser_tblPurchaseOrderInvoiceItemDetail]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblPurchaseOrderInvoiceItemDetail'
CREATE INDEX [IX_FK_tblUser_tblPurchaseOrderInvoiceItemDetail]
ON [dbo].[tblPurchaseOrderInvoiceItemDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ReasonID] in table 'tblPurchaseOrderWithItems'
ALTER TABLE [dbo].[tblPurchaseOrderWithItems]
ADD CONSTRAINT [FK_tblReason_tblPurchaseOrderWithItem]
    FOREIGN KEY ([ReasonID])
    REFERENCES [dbo].[tblReasons]
        ([ReasonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblReason_tblPurchaseOrderWithItem'
CREATE INDEX [IX_FK_tblReason_tblPurchaseOrderWithItem]
ON [dbo].[tblPurchaseOrderWithItems]
    ([ReasonID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPurchaseOrderWithItems'
ALTER TABLE [dbo].[tblPurchaseOrderWithItems]
ADD CONSTRAINT [FK_tblSysUser1_tblPurchaseOrderWithItem]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPurchaseOrderWithItem'
CREATE INDEX [IX_FK_tblSysUser1_tblPurchaseOrderWithItem]
ON [dbo].[tblPurchaseOrderWithItems]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPurchaseOrderWithItems'
ALTER TABLE [dbo].[tblPurchaseOrderWithItems]
ADD CONSTRAINT [FK_tblUser_tblPurchaseOrderWithItem]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblPurchaseOrderWithItem'
CREATE INDEX [IX_FK_tblUser_tblPurchaseOrderWithItem]
ON [dbo].[tblPurchaseOrderWithItems]
    ([CreatedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblPurchaseOrderWithItems'
ALTER TABLE [dbo].[tblPurchaseOrderWithItems]
ADD CONSTRAINT [FK_tblWarehouse_tblPurchaseOrderWithItem]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblPurchaseOrderWithItem'
CREATE INDEX [IX_FK_tblWarehouse_tblPurchaseOrderWithItem]
ON [dbo].[tblPurchaseOrderWithItems]
    ([WarehouseID]);
GO

-- Creating foreign key on [RequisitionNumber] in table 'tblPurchaseRequisitionItemsDetails'
ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetails]
ADD CONSTRAINT [FK_tblPurchaseRequisition_tblPurchaseRequisitionItemsDetail]
    FOREIGN KEY ([RequisitionNumber])
    REFERENCES [dbo].[tblPurchaseRequisitions]
        ([RequisitionNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseRequisition_tblPurchaseRequisitionItemsDetail'
CREATE INDEX [IX_FK_tblPurchaseRequisition_tblPurchaseRequisitionItemsDetail]
ON [dbo].[tblPurchaseRequisitionItemsDetails]
    ([RequisitionNumber]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPurchaseRequisitions'
ALTER TABLE [dbo].[tblPurchaseRequisitions]
ADD CONSTRAINT [FK_tblPurchaseRequisition_tblSysUser]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPurchaseRequisition_tblSysUser'
CREATE INDEX [IX_FK_tblPurchaseRequisition_tblSysUser]
ON [dbo].[tblPurchaseRequisitions]
    ([CreatedByID]);
GO

-- Creating foreign key on [BranchID] in table 'tblPurchaseRequisitions'
ALTER TABLE [dbo].[tblPurchaseRequisitions]
ADD CONSTRAINT [FK_tblSysBranch_tblPurchaseRequisition]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_tblPurchaseRequisition'
CREATE INDEX [IX_FK_tblSysBranch_tblPurchaseRequisition]
ON [dbo].[tblPurchaseRequisitions]
    ([BranchID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPurchaseRequisitions'
ALTER TABLE [dbo].[tblPurchaseRequisitions]
ADD CONSTRAINT [FK_tblSysUser_tblPurchaseRequisition]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblPurchaseRequisition'
CREATE INDEX [IX_FK_tblSysUser_tblPurchaseRequisition]
ON [dbo].[tblPurchaseRequisitions]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPurchaseRequisitions'
ALTER TABLE [dbo].[tblPurchaseRequisitions]
ADD CONSTRAINT [FK_tblSysUser1_tblPurchaseRequisition]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPurchaseRequisition'
CREATE INDEX [IX_FK_tblSysUser1_tblPurchaseRequisition]
ON [dbo].[tblPurchaseRequisitions]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblPurchaseRequisitionItemsDetails'
ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetails]
ADD CONSTRAINT [FK_tblSysUser_tblPurchaseRequisitionItemsDetail]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblPurchaseRequisitionItemsDetail'
CREATE INDEX [IX_FK_tblSysUser_tblPurchaseRequisitionItemsDetail]
ON [dbo].[tblPurchaseRequisitionItemsDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblPurchaseRequisitionItemsDetails'
ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblPurchaseRequisitionItemsDetail]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblPurchaseRequisitionItemsDetail'
CREATE INDEX [IX_FK_tblSysUser1_tblPurchaseRequisitionItemsDetail]
ON [dbo].[tblPurchaseRequisitionItemsDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblPurchaseRequisitionItemsDetails'
ALTER TABLE [dbo].[tblPurchaseRequisitionItemsDetails]
ADD CONSTRAINT [FK_tblWarehouse_tblPurchaseRequisitionItemsDetail]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblPurchaseRequisitionItemsDetail'
CREATE INDEX [IX_FK_tblWarehouse_tblPurchaseRequisitionItemsDetail]
ON [dbo].[tblPurchaseRequisitionItemsDetails]
    ([WarehouseID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblRacks'
ALTER TABLE [dbo].[tblRacks]
ADD CONSTRAINT [FK_tblsysUser_tblRack]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblRack'
CREATE INDEX [IX_FK_tblsysUser_tblRack]
ON [dbo].[tblRacks]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblRacks'
ALTER TABLE [dbo].[tblRacks]
ADD CONSTRAINT [FK_tblSysUser1_tblRack]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblRack'
CREATE INDEX [IX_FK_tblSysUser1_tblRack]
ON [dbo].[tblRacks]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblReasons'
ALTER TABLE [dbo].[tblReasons]
ADD CONSTRAINT [FK_tblSysUser_tblReason]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblReason'
CREATE INDEX [IX_FK_tblSysUser_tblReason]
ON [dbo].[tblReasons]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblReasons'
ALTER TABLE [dbo].[tblReasons]
ADD CONSTRAINT [FK_tblSysUser1_tblReason]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblReason'
CREATE INDEX [IX_FK_tblSysUser1_tblReason]
ON [dbo].[tblReasons]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblReceiptDetails'
ALTER TABLE [dbo].[tblReceiptDetails]
ADD CONSTRAINT [FK_tblSysUser_tblReceiptDetails]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblReceiptDetails'
CREATE INDEX [IX_FK_tblSysUser_tblReceiptDetails]
ON [dbo].[tblReceiptDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblReceiptDetails'
ALTER TABLE [dbo].[tblReceiptDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblReceiptDetails]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblReceiptDetails'
CREATE INDEX [IX_FK_tblSysUser1_tblReceiptDetails]
ON [dbo].[tblReceiptDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblReceiptWithBillDetails'
ALTER TABLE [dbo].[tblReceiptWithBillDetails]
ADD CONSTRAINT [FK_tblSysUser_tblReceiptWithBillDetails]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblReceiptWithBillDetails'
CREATE INDEX [IX_FK_tblSysUser_tblReceiptWithBillDetails]
ON [dbo].[tblReceiptWithBillDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblReceiptWithBillDetails'
ALTER TABLE [dbo].[tblReceiptWithBillDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblReceiptWithBillDetails]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblReceiptWithBillDetails'
CREATE INDEX [IX_FK_tblSysUser1_tblReceiptWithBillDetails]
ON [dbo].[tblReceiptWithBillDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSalesmanDetails'
ALTER TABLE [dbo].[tblSalesmanDetails]
ADD CONSTRAINT [FK_tblSysUser_tblSalesmanDetails]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblSalesmanDetails'
CREATE INDEX [IX_FK_tblSysUser_tblSalesmanDetails]
ON [dbo].[tblSalesmanDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSalesmanDetails'
ALTER TABLE [dbo].[tblSalesmanDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblSalesmanDetails]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSalesmanDetails'
CREATE INDEX [IX_FK_tblSysUser1_tblSalesmanDetails]
ON [dbo].[tblSalesmanDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [BranchID] in table 'tblSalesOrders'
ALTER TABLE [dbo].[tblSalesOrders]
ADD CONSTRAINT [FK_SysBranch_tblSalesOrder]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SysBranch_tblSalesOrder'
CREATE INDEX [IX_FK_SysBranch_tblSalesOrder]
ON [dbo].[tblSalesOrders]
    ([BranchID]);
GO

-- Creating foreign key on [SalesOrderNumber] in table 'tblSalesOrderCashTransactions'
ALTER TABLE [dbo].[tblSalesOrderCashTransactions]
ADD CONSTRAINT [FK_tblSalesOrder_tblSalesOrderCashTransaction]
    FOREIGN KEY ([SalesOrderNumber])
    REFERENCES [dbo].[tblSalesOrders]
        ([SalesOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrder_tblSalesOrderCashTransaction'
CREATE INDEX [IX_FK_tblSalesOrder_tblSalesOrderCashTransaction]
ON [dbo].[tblSalesOrderCashTransactions]
    ([SalesOrderNumber]);
GO

-- Creating foreign key on [SalesOrderNumber] in table 'tblSalesOrderInvoices'
ALTER TABLE [dbo].[tblSalesOrderInvoices]
ADD CONSTRAINT [FK_tblSalesOrder_tblSalesOrderInvoice]
    FOREIGN KEY ([SalesOrderNumber])
    REFERENCES [dbo].[tblSalesOrders]
        ([SalesOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrder_tblSalesOrderInvoice'
CREATE INDEX [IX_FK_tblSalesOrder_tblSalesOrderInvoice]
ON [dbo].[tblSalesOrderInvoices]
    ([SalesOrderNumber]);
GO

-- Creating foreign key on [SalesOrderNumber] in table 'tblSalesOrderItemWarehouseMaps'
ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMaps]
ADD CONSTRAINT [FK_tblSalesOrder_tblSalesOrderItemWarehouseMap]
    FOREIGN KEY ([SalesOrderNumber])
    REFERENCES [dbo].[tblSalesOrders]
        ([SalesOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrder_tblSalesOrderItemWarehouseMap'
CREATE INDEX [IX_FK_tblSalesOrder_tblSalesOrderItemWarehouseMap]
ON [dbo].[tblSalesOrderItemWarehouseMaps]
    ([SalesOrderNumber]);
GO

-- Creating foreign key on [SalesOrderNumber] in table 'tblSalesOrderWithItems'
ALTER TABLE [dbo].[tblSalesOrderWithItems]
ADD CONSTRAINT [FK_tblSalesOrder_tblSalesOrderWithItem]
    FOREIGN KEY ([SalesOrderNumber])
    REFERENCES [dbo].[tblSalesOrders]
        ([SalesOrderNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrder_tblSalesOrderWithItem'
CREATE INDEX [IX_FK_tblSalesOrder_tblSalesOrderWithItem]
ON [dbo].[tblSalesOrderWithItems]
    ([SalesOrderNumber]);
GO

-- Creating foreign key on [SalesmanID] in table 'tblSalesOrders'
ALTER TABLE [dbo].[tblSalesOrders]
ADD CONSTRAINT [FK_tblSysUser_tblSalesOrder]
    FOREIGN KEY ([SalesmanID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblSalesOrder'
CREATE INDEX [IX_FK_tblSysUser_tblSalesOrder]
ON [dbo].[tblSalesOrders]
    ([SalesmanID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSalesOrders'
ALTER TABLE [dbo].[tblSalesOrders]
ADD CONSTRAINT [FK_tblSysUser1_tblSalesOrder]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSalesOrder'
CREATE INDEX [IX_FK_tblSysUser1_tblSalesOrder]
ON [dbo].[tblSalesOrders]
    ([ModifiedByID]);
GO

-- Creating foreign key on [BrokerID] in table 'tblSalesOrders'
ALTER TABLE [dbo].[tblSalesOrders]
ADD CONSTRAINT [FK_tblSysUserBr_tblSalesOrder]
    FOREIGN KEY ([BrokerID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUserBr_tblSalesOrder'
CREATE INDEX [IX_FK_tblSysUserBr_tblSalesOrder]
ON [dbo].[tblSalesOrders]
    ([BrokerID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSalesOrders'
ALTER TABLE [dbo].[tblSalesOrders]
ADD CONSTRAINT [FK_tblUser_tblSalesOrder]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblSalesOrder'
CREATE INDEX [IX_FK_tblUser_tblSalesOrder]
ON [dbo].[tblSalesOrders]
    ([CreatedByID]);
GO

-- Creating foreign key on [VoucherTypeNo] in table 'tblSalesOrders'
ALTER TABLE [dbo].[tblSalesOrders]
ADD CONSTRAINT [FK_tblVoucherType_tblSalesOrder]
    FOREIGN KEY ([VoucherTypeNo])
    REFERENCES [dbo].[tblVoucherTypes]
        ([VoucherTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblVoucherType_tblSalesOrder'
CREATE INDEX [IX_FK_tblVoucherType_tblSalesOrder]
ON [dbo].[tblSalesOrders]
    ([VoucherTypeNo]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSalesOrderCashTransactions'
ALTER TABLE [dbo].[tblSalesOrderCashTransactions]
ADD CONSTRAINT [FK_tblSysUser1_tblSalesOrderCashTransaction]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSalesOrderCashTransaction'
CREATE INDEX [IX_FK_tblSysUser1_tblSalesOrderCashTransaction]
ON [dbo].[tblSalesOrderCashTransactions]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSalesOrderCashTransactions'
ALTER TABLE [dbo].[tblSalesOrderCashTransactions]
ADD CONSTRAINT [FK_tblUser_tblSalesOrderCashTransaction]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblSalesOrderCashTransaction'
CREATE INDEX [IX_FK_tblUser_tblSalesOrderCashTransaction]
ON [dbo].[tblSalesOrderCashTransactions]
    ([CreatedByID]);
GO

-- Creating foreign key on [SOInvoiceReferenceNumber] in table 'tblSalesOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_tblSalesOrderInvoice_tblSalesOrderInvoiceItemDetail]
    FOREIGN KEY ([SOInvoiceReferenceNumber])
    REFERENCES [dbo].[tblSalesOrderInvoices]
        ([SOInvoiceReferenceNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrderInvoice_tblSalesOrderInvoiceItemDetail'
CREATE INDEX [IX_FK_tblSalesOrderInvoice_tblSalesOrderInvoiceItemDetail]
ON [dbo].[tblSalesOrderInvoiceItemDetails]
    ([SOInvoiceReferenceNumber]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSalesOrderInvoices'
ALTER TABLE [dbo].[tblSalesOrderInvoices]
ADD CONSTRAINT [FK_tblSysUser1_tblSalesOrderInvoice]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSalesOrderInvoice'
CREATE INDEX [IX_FK_tblSysUser1_tblSalesOrderInvoice]
ON [dbo].[tblSalesOrderInvoices]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSalesOrderInvoices'
ALTER TABLE [dbo].[tblSalesOrderInvoices]
ADD CONSTRAINT [FK_tblUser_tblSalesOrderInvoice]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblSalesOrderInvoice'
CREATE INDEX [IX_FK_tblUser_tblSalesOrderInvoice]
ON [dbo].[tblSalesOrderInvoices]
    ([CreatedByID]);
GO

-- Creating foreign key on [VoucherTypeNo] in table 'tblSalesOrderInvoices'
ALTER TABLE [dbo].[tblSalesOrderInvoices]
ADD CONSTRAINT [FK_tblVoucherType_tblSalesOrderInvoice]
    FOREIGN KEY ([VoucherTypeNo])
    REFERENCES [dbo].[tblVoucherTypes]
        ([VoucherTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblVoucherType_tblSalesOrderInvoice'
CREATE INDEX [IX_FK_tblVoucherType_tblSalesOrderInvoice]
ON [dbo].[tblSalesOrderInvoices]
    ([VoucherTypeNo]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSalesOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblSalesOrderInvoiceItemDetail]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSalesOrderInvoiceItemDetail'
CREATE INDEX [IX_FK_tblSysUser1_tblSalesOrderInvoiceItemDetail]
ON [dbo].[tblSalesOrderInvoiceItemDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSalesOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_tblUser_tblSalesOrderInvoiceItemDetail]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblSalesOrderInvoiceItemDetail'
CREATE INDEX [IX_FK_tblUser_tblSalesOrderInvoiceItemDetail]
ON [dbo].[tblSalesOrderInvoiceItemDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblSalesOrderInvoiceItemDetails'
ALTER TABLE [dbo].[tblSalesOrderInvoiceItemDetails]
ADD CONSTRAINT [FK_tblWarehouse_tblSalesOrderInvoiceItemDetail]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblSalesOrderInvoiceItemDetail'
CREATE INDEX [IX_FK_tblWarehouse_tblSalesOrderInvoiceItemDetail]
ON [dbo].[tblSalesOrderInvoiceItemDetails]
    ([WarehouseID]);
GO

-- Creating foreign key on [SalesOrderWithItemID] in table 'tblSalesOrderItemWarehouseMaps'
ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMaps]
ADD CONSTRAINT [FK_tblSalesOrderWithItem_tblSalesOrderItemWarehouseMap]
    FOREIGN KEY ([SalesOrderWithItemID])
    REFERENCES [dbo].[tblSalesOrderWithItems]
        ([SalesOrderWithItemID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSalesOrderWithItem_tblSalesOrderItemWarehouseMap'
CREATE INDEX [IX_FK_tblSalesOrderWithItem_tblSalesOrderItemWarehouseMap]
ON [dbo].[tblSalesOrderItemWarehouseMaps]
    ([SalesOrderWithItemID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSalesOrderItemWarehouseMaps'
ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMaps]
ADD CONSTRAINT [FK_tblSysUser1_tblSalesOrderItemWarehouseMap]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSalesOrderItemWarehouseMap'
CREATE INDEX [IX_FK_tblSysUser1_tblSalesOrderItemWarehouseMap]
ON [dbo].[tblSalesOrderItemWarehouseMaps]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSalesOrderItemWarehouseMaps'
ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMaps]
ADD CONSTRAINT [FK_tblUser_tblSalesOrderItemWarehouseMap]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblSalesOrderItemWarehouseMap'
CREATE INDEX [IX_FK_tblUser_tblSalesOrderItemWarehouseMap]
ON [dbo].[tblSalesOrderItemWarehouseMaps]
    ([CreatedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblSalesOrderItemWarehouseMaps'
ALTER TABLE [dbo].[tblSalesOrderItemWarehouseMaps]
ADD CONSTRAINT [FK_tblWarehouse_tblSalesOrderItemWarehouseMap]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblSalesOrderItemWarehouseMap'
CREATE INDEX [IX_FK_tblWarehouse_tblSalesOrderItemWarehouseMap]
ON [dbo].[tblSalesOrderItemWarehouseMaps]
    ([WarehouseID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSalesOrderWithItems'
ALTER TABLE [dbo].[tblSalesOrderWithItems]
ADD CONSTRAINT [FK_tblSysUser1_tblSalesOrderWithItem]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSalesOrderWithItem'
CREATE INDEX [IX_FK_tblSysUser1_tblSalesOrderWithItem]
ON [dbo].[tblSalesOrderWithItems]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSalesOrderWithItems'
ALTER TABLE [dbo].[tblSalesOrderWithItems]
ADD CONSTRAINT [FK_tblUser_tblSalesOrderWithItem]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblSalesOrderWithItem'
CREATE INDEX [IX_FK_tblUser_tblSalesOrderWithItem]
ON [dbo].[tblSalesOrderWithItems]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedById] in table 'tblStickerDetails'
ALTER TABLE [dbo].[tblStickerDetails]
ADD CONSTRAINT [FK_tblStickerDetails_tblSysUser]
    FOREIGN KEY ([CreatedById])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStickerDetails_tblSysUser'
CREATE INDEX [IX_FK_tblStickerDetails_tblSysUser]
ON [dbo].[tblStickerDetails]
    ([CreatedById]);
GO

-- Creating foreign key on [ModifiedById] in table 'tblStickerDetails'
ALTER TABLE [dbo].[tblStickerDetails]
ADD CONSTRAINT [FK_tblStickerDetails_tblSysUser1]
    FOREIGN KEY ([ModifiedById])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStickerDetails_tblSysUser1'
CREATE INDEX [IX_FK_tblStickerDetails_tblSysUser1]
ON [dbo].[tblStickerDetails]
    ([ModifiedById]);
GO

-- Creating foreign key on [WareHouseId] in table 'tblStickerDetails'
ALTER TABLE [dbo].[tblStickerDetails]
ADD CONSTRAINT [FK_tblStickerDetails_tblWarehouse]
    FOREIGN KEY ([WareHouseId])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStickerDetails_tblWarehouse'
CREATE INDEX [IX_FK_tblStickerDetails_tblWarehouse]
ON [dbo].[tblStickerDetails]
    ([WareHouseId]);
GO

-- Creating foreign key on [StockTransferHeaderID] in table 'tblStockTransferLineItems'
ALTER TABLE [dbo].[tblStockTransferLineItems]
ADD CONSTRAINT [FK_tblStockTransferHeader_tblStockTransferLineItem1]
    FOREIGN KEY ([StockTransferHeaderID])
    REFERENCES [dbo].[tblStockTransferHeaders]
        ([StockTransferHeaderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStockTransferHeader_tblStockTransferLineItem1'
CREATE INDEX [IX_FK_tblStockTransferHeader_tblStockTransferLineItem1]
ON [dbo].[tblStockTransferLineItems]
    ([StockTransferHeaderID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblStockTransferHeaders'
ALTER TABLE [dbo].[tblStockTransferHeaders]
ADD CONSTRAINT [FK_tblSysUser_tblStockTransferHeader]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblStockTransferHeader'
CREATE INDEX [IX_FK_tblSysUser_tblStockTransferHeader]
ON [dbo].[tblStockTransferHeaders]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblStockTransferLineItems'
ALTER TABLE [dbo].[tblStockTransferLineItems]
ADD CONSTRAINT [FK_tblSysUser_tblStockTransferLineItem]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblStockTransferLineItem'
CREATE INDEX [IX_FK_tblSysUser_tblStockTransferLineItem]
ON [dbo].[tblStockTransferLineItems]
    ([CreatedByID]);
GO

-- Creating foreign key on [DestinationWarehouseID] in table 'tblStockTransferLineItems'
ALTER TABLE [dbo].[tblStockTransferLineItems]
ADD CONSTRAINT [FK_tblWarehouse_tblStockTransferLineItem]
    FOREIGN KEY ([DestinationWarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblStockTransferLineItem'
CREATE INDEX [IX_FK_tblWarehouse_tblStockTransferLineItem]
ON [dbo].[tblStockTransferLineItems]
    ([DestinationWarehouseID]);
GO

-- Creating foreign key on [SourceWarehouseID] in table 'tblStockTransferLineItems'
ALTER TABLE [dbo].[tblStockTransferLineItems]
ADD CONSTRAINT [FK_tblWarehouse_tblStockTransferLineItem1]
    FOREIGN KEY ([SourceWarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblStockTransferLineItem1'
CREATE INDEX [IX_FK_tblWarehouse_tblStockTransferLineItem1]
ON [dbo].[tblStockTransferLineItems]
    ([SourceWarehouseID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSubAccountGroupMasters'
ALTER TABLE [dbo].[tblSubAccountGroupMasters]
ADD CONSTRAINT [FK_tblsysUser_tblSubAccountGroupMaster]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblSubAccountGroupMaster'
CREATE INDEX [IX_FK_tblsysUser_tblSubAccountGroupMaster]
ON [dbo].[tblSubAccountGroupMasters]
    ([CreatedByID]);
GO

-- Creating foreign key on [UpdatedByID] in table 'tblSubAccountGroupMasters'
ALTER TABLE [dbo].[tblSubAccountGroupMasters]
ADD CONSTRAINT [FK_tblsysUser1_tblSubAccountGroupMaster]
    FOREIGN KEY ([UpdatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser1_tblSubAccountGroupMaster'
CREATE INDEX [IX_FK_tblsysUser1_tblSubAccountGroupMaster]
ON [dbo].[tblSubAccountGroupMasters]
    ([UpdatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSubCategories'
ALTER TABLE [dbo].[tblSubCategories]
ADD CONSTRAINT [FK_tblsysUser_tblSubCategory]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblSubCategory'
CREATE INDEX [IX_FK_tblsysUser_tblSubCategory]
ON [dbo].[tblSubCategories]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSubCategories'
ALTER TABLE [dbo].[tblSubCategories]
ADD CONSTRAINT [FK_tblSysUser1_tblSubCategory]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSubCategory'
CREATE INDEX [IX_FK_tblSysUser1_tblSubCategory]
ON [dbo].[tblSubCategories]
    ([ModifiedByID]);
GO

-- Creating foreign key on [RoleID] in table 'tblSubMenuRoleMaps'
ALTER TABLE [dbo].[tblSubMenuRoleMaps]
ADD CONSTRAINT [FK_tblSysRole_tblSubMenuRoleMap]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[tblSysRoles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysRole_tblSubMenuRoleMap'
CREATE INDEX [IX_FK_tblSysRole_tblSubMenuRoleMap]
ON [dbo].[tblSubMenuRoleMaps]
    ([RoleID]);
GO

-- Creating foreign key on [SubMenuID] in table 'tblSubMenuRoleMaps'
ALTER TABLE [dbo].[tblSubMenuRoleMaps]
ADD CONSTRAINT [FK_tblSysSubMenu_tblSubMenuRoleMap]
    FOREIGN KEY ([SubMenuID])
    REFERENCES [dbo].[tblSysSubMenus]
        ([SubMenuID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysSubMenu_tblSubMenuRoleMap'
CREATE INDEX [IX_FK_tblSysSubMenu_tblSubMenuRoleMap]
ON [dbo].[tblSubMenuRoleMaps]
    ([SubMenuID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSubMenuRoleMaps'
ALTER TABLE [dbo].[tblSubMenuRoleMaps]
ADD CONSTRAINT [FK_tblsysUser_tblSubMenuRoleMap]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblSubMenuRoleMap'
CREATE INDEX [IX_FK_tblsysUser_tblSubMenuRoleMap]
ON [dbo].[tblSubMenuRoleMaps]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSubMenuRoleMaps'
ALTER TABLE [dbo].[tblSubMenuRoleMaps]
ADD CONSTRAINT [FK_tblSysUser1_tblSubMenuRoleMap]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSubMenuRoleMap'
CREATE INDEX [IX_FK_tblSysUser1_tblSubMenuRoleMap]
ON [dbo].[tblSubMenuRoleMaps]
    ([ModifiedByID]);
GO

-- Creating foreign key on [BranchID] in table 'tblSysUsers'
ALTER TABLE [dbo].[tblSysUsers]
ADD CONSTRAINT [FK_SysBranchSysUser]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SysBranchSysUser'
CREATE INDEX [IX_FK_SysBranchSysUser]
ON [dbo].[tblSysUsers]
    ([BranchID]);
GO

-- Creating foreign key on [BranchID] in table 'tblWarehouses'
ALTER TABLE [dbo].[tblWarehouses]
ADD CONSTRAINT [FK_tblSysBranch_tblWarehouse]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_tblWarehouse'
CREATE INDEX [IX_FK_tblSysBranch_tblWarehouse]
ON [dbo].[tblWarehouses]
    ([BranchID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSysBranches'
ALTER TABLE [dbo].[tblSysBranches]
ADD CONSTRAINT [FK_tblSysUser_tblSysBranch]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblSysBranch'
CREATE INDEX [IX_FK_tblSysUser_tblSysBranch]
ON [dbo].[tblSysBranches]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSysBranches'
ALTER TABLE [dbo].[tblSysBranches]
ADD CONSTRAINT [FK_tblSysUser1_tblSysBranch]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSysBranch'
CREATE INDEX [IX_FK_tblSysUser1_tblSysBranch]
ON [dbo].[tblSysBranches]
    ([ModifiedByID]);
GO

-- Creating foreign key on [BranchID] in table 'tblVoucherTypes'
ALTER TABLE [dbo].[tblVoucherTypes]
ADD CONSTRAINT [FK_tblVoucherType_tblSysBranch]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblVoucherType_tblSysBranch'
CREATE INDEX [IX_FK_tblVoucherType_tblSysBranch]
ON [dbo].[tblVoucherTypes]
    ([BranchID]);
GO

-- Creating foreign key on [MainMenuID] in table 'tblSysSubMenus'
ALTER TABLE [dbo].[tblSysSubMenus]
ADD CONSTRAINT [FK_SysMainMenuSubMenu]
    FOREIGN KEY ([MainMenuID])
    REFERENCES [dbo].[tblSysMainMenus]
        ([MainMenuID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SysMainMenuSubMenu'
CREATE INDEX [IX_FK_SysMainMenuSubMenu]
ON [dbo].[tblSysSubMenus]
    ([MainMenuID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSysMainMenus'
ALTER TABLE [dbo].[tblSysMainMenus]
ADD CONSTRAINT [FK_tblSysUser_tblSysMainMenu]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblSysMainMenu'
CREATE INDEX [IX_FK_tblSysUser_tblSysMainMenu]
ON [dbo].[tblSysMainMenus]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSysMainMenus'
ALTER TABLE [dbo].[tblSysMainMenus]
ADD CONSTRAINT [FK_tblSysUser1_tblSysMainMenu]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSysMainMenu'
CREATE INDEX [IX_FK_tblSysUser1_tblSysMainMenu]
ON [dbo].[tblSysMainMenus]
    ([ModifiedByID]);
GO

-- Creating foreign key on [RoleID] in table 'tblSysUsers'
ALTER TABLE [dbo].[tblSysUsers]
ADD CONSTRAINT [FK_tblSysRole_tblsysUser]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[tblSysRoles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysRole_tblsysUser'
CREATE INDEX [IX_FK_tblSysRole_tblsysUser]
ON [dbo].[tblSysUsers]
    ([RoleID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSysSubMenus'
ALTER TABLE [dbo].[tblSysSubMenus]
ADD CONSTRAINT [FK_tblSysUser_tblSysSubMenu]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblSysSubMenu'
CREATE INDEX [IX_FK_tblSysUser_tblSysSubMenu]
ON [dbo].[tblSysSubMenus]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSysSubMenus'
ALTER TABLE [dbo].[tblSysSubMenus]
ADD CONSTRAINT [FK_tblSysUser1_tblSysSubMenu]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSysSubMenu'
CREATE INDEX [IX_FK_tblSysUser1_tblSysSubMenu]
ON [dbo].[tblSysSubMenus]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSysUsers'
ALTER TABLE [dbo].[tblSysUsers]
ADD CONSTRAINT [FK_tblSysUser_tblSysUser]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblSysUser'
CREATE INDEX [IX_FK_tblSysUser_tblSysUser]
ON [dbo].[tblSysUsers]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblTaxCESSes'
ALTER TABLE [dbo].[tblTaxCESSes]
ADD CONSTRAINT [FK_tblsysUser_tblTaxCESS]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblTaxCESS'
CREATE INDEX [IX_FK_tblsysUser_tblTaxCESS]
ON [dbo].[tblTaxCESSes]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblUnitQuantities'
ALTER TABLE [dbo].[tblUnitQuantities]
ADD CONSTRAINT [FK_tblsysUser_tblUnitQuantity]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblUnitQuantity'
CREATE INDEX [IX_FK_tblsysUser_tblUnitQuantity]
ON [dbo].[tblUnitQuantities]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblUOMs'
ALTER TABLE [dbo].[tblUOMs]
ADD CONSTRAINT [FK_tblSysUser_tblUOM]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblUOM'
CREATE INDEX [IX_FK_tblSysUser_tblUOM]
ON [dbo].[tblUOMs]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblUserWarehouseMaps'
ALTER TABLE [dbo].[tblUserWarehouseMaps]
ADD CONSTRAINT [FK_tblsysUser_tblUserWarehouseMap]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblUserWarehouseMap'
CREATE INDEX [IX_FK_tblsysUser_tblUserWarehouseMap]
ON [dbo].[tblUserWarehouseMaps]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblWarehouses'
ALTER TABLE [dbo].[tblWarehouses]
ADD CONSTRAINT [FK_tblsysUser_tblWarehouse]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblsysUser_tblWarehouse'
CREATE INDEX [IX_FK_tblsysUser_tblWarehouse]
ON [dbo].[tblWarehouses]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblWarehouseToWarehouseTrackings'
ALTER TABLE [dbo].[tblWarehouseToWarehouseTrackings]
ADD CONSTRAINT [FK_tblSysUser_tblWarehouseToWarehouseTracking]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblWarehouseToWarehouseTracking'
CREATE INDEX [IX_FK_tblSysUser_tblWarehouseToWarehouseTracking]
ON [dbo].[tblWarehouseToWarehouseTrackings]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSysUsers'
ALTER TABLE [dbo].[tblSysUsers]
ADD CONSTRAINT [FK_tblSysUser1_tblSysUser]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSysUser'
CREATE INDEX [IX_FK_tblSysUser1_tblSysUser]
ON [dbo].[tblSysUsers]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblTaxCESSes'
ALTER TABLE [dbo].[tblTaxCESSes]
ADD CONSTRAINT [FK_tblSysUser1_tblTaxCESS]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblTaxCESS'
CREATE INDEX [IX_FK_tblSysUser1_tblTaxCESS]
ON [dbo].[tblTaxCESSes]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblTransitItems'
ALTER TABLE [dbo].[tblTransitItems]
ADD CONSTRAINT [FK_tblSysUser1_tblTransitItem]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblTransitItem'
CREATE INDEX [IX_FK_tblSysUser1_tblTransitItem]
ON [dbo].[tblTransitItems]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblTransitItemDetails'
ALTER TABLE [dbo].[tblTransitItemDetails]
ADD CONSTRAINT [FK_tblSysUser1_tblTransitItemDetail]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblTransitItemDetail'
CREATE INDEX [IX_FK_tblSysUser1_tblTransitItemDetail]
ON [dbo].[tblTransitItemDetails]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblUnitQuantities'
ALTER TABLE [dbo].[tblUnitQuantities]
ADD CONSTRAINT [FK_tblSysUser1_tblUnitQuantity]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblUnitQuantity'
CREATE INDEX [IX_FK_tblSysUser1_tblUnitQuantity]
ON [dbo].[tblUnitQuantities]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblUOMs'
ALTER TABLE [dbo].[tblUOMs]
ADD CONSTRAINT [FK_tblSysUser1_tblUOM]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblUOM'
CREATE INDEX [IX_FK_tblSysUser1_tblUOM]
ON [dbo].[tblUOMs]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblUserWarehouseMaps'
ALTER TABLE [dbo].[tblUserWarehouseMaps]
ADD CONSTRAINT [FK_tblSysUser1_tblUserWarehouseMap]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblUserWarehouseMap'
CREATE INDEX [IX_FK_tblSysUser1_tblUserWarehouseMap]
ON [dbo].[tblUserWarehouseMaps]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblWarehouses'
ALTER TABLE [dbo].[tblWarehouses]
ADD CONSTRAINT [FK_tblSysUser1_tblWarehouse]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblWarehouse'
CREATE INDEX [IX_FK_tblSysUser1_tblWarehouse]
ON [dbo].[tblWarehouses]
    ([ModifiedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblWarehouseToWarehouseTrackings'
ALTER TABLE [dbo].[tblWarehouseToWarehouseTrackings]
ADD CONSTRAINT [FK_tblSysUser1_tblWarehouseToWarehouseTracking]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblWarehouseToWarehouseTracking'
CREATE INDEX [IX_FK_tblSysUser1_tblWarehouseToWarehouseTracking]
ON [dbo].[tblWarehouseToWarehouseTrackings]
    ([ModifiedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblTransitItems'
ALTER TABLE [dbo].[tblTransitItems]
ADD CONSTRAINT [FK_tblUser_tblTransitItem]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblTransitItem'
CREATE INDEX [IX_FK_tblUser_tblTransitItem]
ON [dbo].[tblTransitItems]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblTransitItemDetails'
ALTER TABLE [dbo].[tblTransitItemDetails]
ADD CONSTRAINT [FK_tblUser_tblTransitItemDetail]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblUser_tblTransitItemDetail'
CREATE INDEX [IX_FK_tblUser_tblTransitItemDetail]
ON [dbo].[tblTransitItemDetails]
    ([CreatedByID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblVoucherTypes'
ALTER TABLE [dbo].[tblVoucherTypes]
ADD CONSTRAINT [FK_tblVoucherType_tblSysUser]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblVoucherType_tblSysUser'
CREATE INDEX [IX_FK_tblVoucherType_tblSysUser]
ON [dbo].[tblVoucherTypes]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblVoucherTypes'
ALTER TABLE [dbo].[tblVoucherTypes]
ADD CONSTRAINT [FK_tblVoucherType_tblSysUser1]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblVoucherType_tblSysUser1'
CREATE INDEX [IX_FK_tblVoucherType_tblSysUser1]
ON [dbo].[tblVoucherTypes]
    ([ModifiedByID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblSysUsers'
ALTER TABLE [dbo].[tblSysUsers]
ADD CONSTRAINT [FK_tblWarehouse_tblsysUser]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblsysUser'
CREATE INDEX [IX_FK_tblWarehouse_tblsysUser]
ON [dbo].[tblSysUsers]
    ([WarehouseID]);
GO

-- Creating foreign key on [TransitItemID] in table 'tblTransitItemDetails'
ALTER TABLE [dbo].[tblTransitItemDetails]
ADD CONSTRAINT [FK_tblTransitItem_tblTransitItemDetail]
    FOREIGN KEY ([TransitItemID])
    REFERENCES [dbo].[tblTransitItems]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTransitItem_tblTransitItemDetail'
CREATE INDEX [IX_FK_tblTransitItem_tblTransitItemDetail]
ON [dbo].[tblTransitItemDetails]
    ([TransitItemID]);
GO

-- Creating foreign key on [WarehouseID] in table 'tblUserWarehouseMaps'
ALTER TABLE [dbo].[tblUserWarehouseMaps]
ADD CONSTRAINT [FK_tblWarehouse_tblUserWarehouseMap]
    FOREIGN KEY ([WarehouseID])
    REFERENCES [dbo].[tblWarehouses]
        ([WarehouseID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblWarehouse_tblUserWarehouseMap'
CREATE INDEX [IX_FK_tblWarehouse_tblUserWarehouseMap]
ON [dbo].[tblUserWarehouseMaps]
    ([WarehouseID]);
GO

-- Creating foreign key on [DisplayColumn] in table 'tblVoucherTypes'
ALTER TABLE [dbo].[tblVoucherTypes]
ADD CONSTRAINT [FK_tblVoucherTypeDisplayCol_tblVoucherTypeNo]
    FOREIGN KEY ([DisplayColumn])
    REFERENCES [dbo].[tblVoucherTypes]
        ([VoucherTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblVoucherTypeDisplayCol_tblVoucherTypeNo'
CREATE INDEX [IX_FK_tblVoucherTypeDisplayCol_tblVoucherTypeNo]
ON [dbo].[tblVoucherTypes]
    ([DisplayColumn]);
GO

-- Creating foreign key on [OrgID] in table 'tblChannelPartnerMappings'
ALTER TABLE [dbo].[tblChannelPartnerMappings]
ADD CONSTRAINT [FK__tblChanne__OrgID__6F9F86DC]
    FOREIGN KEY ([OrgID])
    REFERENCES [dbo].[tblSysOrganizations]
        ([OrgID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblChanne__OrgID__6F9F86DC'
CREATE INDEX [IX_FK__tblChanne__OrgID__6F9F86DC]
ON [dbo].[tblChannelPartnerMappings]
    ([OrgID]);
GO

-- Creating foreign key on [OrgID] in table 'tblCustomerVendorDetails'
ALTER TABLE [dbo].[tblCustomerVendorDetails]
ADD CONSTRAINT [FK__tblCustom__OrgID__7093AB15]
    FOREIGN KEY ([OrgID])
    REFERENCES [dbo].[tblSysOrganizations]
        ([OrgID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblCustom__OrgID__7093AB15'
CREATE INDEX [IX_FK__tblCustom__OrgID__7093AB15]
ON [dbo].[tblCustomerVendorDetails]
    ([OrgID]);
GO

-- Creating foreign key on [OrgID] in table 'tblSysUsers'
ALTER TABLE [dbo].[tblSysUsers]
ADD CONSTRAINT [FK__tblSysUse__OrgID__5C8CB268]
    FOREIGN KEY ([OrgID])
    REFERENCES [dbo].[tblSysOrganizations]
        ([OrgID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblSysUse__OrgID__5C8CB268'
CREATE INDEX [IX_FK__tblSysUse__OrgID__5C8CB268]
ON [dbo].[tblSysUsers]
    ([OrgID]);
GO

-- Creating foreign key on [BranchID] in table 'tblSysChannelPartners'
ALTER TABLE [dbo].[tblSysChannelPartners]
ADD CONSTRAINT [FK_tblSysBranch_tblSysChannelPartner]
    FOREIGN KEY ([BranchID])
    REFERENCES [dbo].[tblSysBranches]
        ([BranchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysBranch_tblSysChannelPartner'
CREATE INDEX [IX_FK_tblSysBranch_tblSysChannelPartner]
ON [dbo].[tblSysChannelPartners]
    ([BranchID]);
GO

-- Creating foreign key on [CreatedByID] in table 'tblSysChannelPartners'
ALTER TABLE [dbo].[tblSysChannelPartners]
ADD CONSTRAINT [FK_tblSysUser_tblSysChannelPartner]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser_tblSysChannelPartner'
CREATE INDEX [IX_FK_tblSysUser_tblSysChannelPartner]
ON [dbo].[tblSysChannelPartners]
    ([CreatedByID]);
GO

-- Creating foreign key on [ModifiedByID] in table 'tblSysChannelPartners'
ALTER TABLE [dbo].[tblSysChannelPartners]
ADD CONSTRAINT [FK_tblSysUser1_tblSysChannelPartner]
    FOREIGN KEY ([ModifiedByID])
    REFERENCES [dbo].[tblSysUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysUser1_tblSysChannelPartner'
CREATE INDEX [IX_FK_tblSysUser1_tblSysChannelPartner]
ON [dbo].[tblSysChannelPartners]
    ([ModifiedByID]);
GO

-- Creating foreign key on [AccessControlID] in table 'tblAccessControlItems'
ALTER TABLE [dbo].[tblAccessControlItems]
ADD CONSTRAINT [FK__tblAccess__Acces__086B34A6]
    FOREIGN KEY ([AccessControlID])
    REFERENCES [dbo].[tblAccessControls]
        ([AccessControlID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblAccess__Acces__086B34A6'
CREATE INDEX [IX_FK__tblAccess__Acces__086B34A6]
ON [dbo].[tblAccessControlItems]
    ([AccessControlID]);
GO

-- Creating foreign key on [DepartmentID] in table 'tblSysUsers'
ALTER TABLE [dbo].[tblSysUsers]
ADD CONSTRAINT [FK_tblDepartment_DeptID]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[tblDepartments]
        ([DeptID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDepartment_DeptID'
CREATE INDEX [IX_FK_tblDepartment_DeptID]
ON [dbo].[tblSysUsers]
    ([DepartmentID]);
GO

-- Creating foreign key on [DepartmentID] in table 'tblSysRoles'
ALTER TABLE [dbo].[tblSysRoles]
ADD CONSTRAINT [FK_tblSysRole_DeptID]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[tblDepartments]
        ([DeptID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysRole_DeptID'
CREATE INDEX [IX_FK_tblSysRole_DeptID]
ON [dbo].[tblSysRoles]
    ([DepartmentID]);
GO

-- Creating foreign key on [ChannelTypeID] in table 'tblSysChannelPartners'
ALTER TABLE [dbo].[tblSysChannelPartners]
ADD CONSTRAINT [FK_tblSysChannelPartner_ChannelTypeID]
    FOREIGN KEY ([ChannelTypeID])
    REFERENCES [dbo].[tblSalesChannelTypes]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSysChannelPartner_ChannelTypeID'
CREATE INDEX [IX_FK_tblSysChannelPartner_ChannelTypeID]
ON [dbo].[tblSysChannelPartners]
    ([ChannelTypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------