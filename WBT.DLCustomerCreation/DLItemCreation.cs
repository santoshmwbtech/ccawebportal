using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.DLCustomerCreation.DTOs;
//using WBT.DL.Admin;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    #region public classes
    //added by devika used in vendor creation and dc creation for mapping items
    public class GetItemList
    {
        public int ItemMapID { get; set; }
        public int ID { get; set; }
        public string ItemCode { get; set; }
        public string ItemAlias { get; set; }
        public string ItemName { get; set; }
        public string OrgID { get; set; }
        public bool Select { get; set; }
        public bool SelectVendor { get; set; }
        //public int dcno { get; set; }
        public string custid { get; set; }
        //added for item supp mapping popup window while creating vendor
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        //added on 10 Feb 2021 by DEVIKA for item branch and Sis org mapping
        public string BranchID { get; set; }
        public string COrgID { get; set; }
        public bool IsActive { get; set; }
        public string CategoryName { get; set; }
    }
    public class DLCategorylist
    {
        public int CategoryID { get; set; }
        public string OrgID { get; set; }
        public string CategoryName { get; set; }
    }
    public class DLSubcategoryList
    {
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string OrgID { get; set; }
    }
    public class DLItemCompanyList
    {
        public int ItemCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string OrgID { get; set; }
    }
    public class DLBrandList
    {
        public string BrandID { get; set; }
        public string BrandName { get; set; }
        public string OrgID { get; set; }
        public Nullable<int> ItemCompanyID { get; set; }
    }
    public class DLUOMList
    {
        public int UnitID { get; set; }
        public string Unit { get; set; }
    }
    public class DLRackList
    {
        public int RackID { get; set; }
        public string RackNumber { get; set; }
        public string OrgID { get; set; }
    }

    public class DLBusinessTypeCreations
    {
        public int BusinessTypeID { get; set; }
        public string OrgID { get; set; }
        public string BusinessTypeName { get; set; }
        public int? MinQty { get; set; }
        public int? MaxQty { get; set; }
    }
    public class GetAllItemDropDownsData
    {
        public List<DLCategorylist> DLCategoryList { get; set; } = new List<DLCategorylist>();
        public List<DLSubcategoryList> DLSubcategoryList { get; set; } = new List<DLSubcategoryList>();
        public List<DLItemCompanyList> DLItemCompanyList { get; set; } = new List<DLItemCompanyList>();
        public List<DLBrandList> DLBrandList { get; set; } = new List<DLBrandList>();
        public List<DLUOMList> DLUOMList { get; set; } = new List<DLUOMList>();
        public List<DLRackList> DLRackList { get; set; } = new List<DLRackList>();
        //public List<DLBusinessTypeCreations> DLBussinessTypesList { get; set; } = new List<DLBusinessTypeCreations>();
        public List<GetItemList> GetItemList { get; set; } = new List<GetItemList>();
        //public List<DLBranchLst> DlBranchLst { get; set; } = new List<DLBranchLst>();
    }
    public class LstMappedOrganization
    {
        public string OrgName { get; set; }
        public string OrgID { get; set; }
        public string Itemcode { get; set; }
    }

    public class DLProcessItemCreation : DLItemCreation
    {
        public Nullable<bool> finisheditem_sale { get; set; }

    }
    public class DLItemCreation //: ApplicationActivate
    {
        public string Barcode { get; set; }
        public int ItemMapID { get; set; }
        public string COrgID { get; set; } = string.Empty;
        public bool IsProcessItemcheck { get; set; }
        public string SerachText { get; set; }
        //public bool IsParentOrg { get; set; }
        //public string ParentOrgID { get; set; }
        public string SearchText { get; set; }
        public string ParentOrgName { get; set; }
        public int ID { get; set; }
        public string ItemCode { get; set; }
        public string ItemAlias { get; set; }
        public string StorageSpace { get; set; }
        public string ItemName { get; set; }

        public string ItemNameWithUnit { get; set; }
        public string OldItemName { get; set; }
        public string TallyItemName { get; set; }
        //public string Status { get; set; } //Added on 02-01-2020
        public Nullable<int> HSNCode { get; set; }
        public Nullable<int> HSNSubCode { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        //public int UnitQuantityID { get; set; }
        //public string UOM { get; set; }
        //public Nullable<int> PacketSizeID { get; set; }
        public Nullable<int> BatchID { get; set; }
        public Nullable<int> RackID { get; set; }
        public decimal BaseRateOther { get; set; }
        public string ItemDetail { get; set; }
        public decimal ItemPrice { get; set; }
        //public decimal DealerPrice { get; set; }
        public decimal Quantity { get; set; }
        //public decimal PacketAvailable { get; set; }
        public decimal GST { get; set; }
        //public string IGST { get; set; }
        public Nullable<int> DaysToRefill { get; set; }
        public Nullable<bool> IsReturnable { get; set; }
        public Nullable<bool> IsTrademarkRegistered { get; set; }
        //public string CGST { get; set; }
        //public string SGST { get; set; }
        //public decimal ItemSize { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string sIsActive { get; set; }
        public Nullable<bool> IsItemBlocked { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public Nullable<bool> IsTallyUpdated { get; set; }
        public string stringIsTallyUpdated { get; set; }
        public string stringIsParentTallyUpdated { get; set; }
        public string Remark { get; set; }
        public string RatePer { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> RateID { get; set; }
        #region Added for StocklevelTree
        public string WarehouseName { get; internal set; }
        public decimal WarehouseStock { get; internal set; }
        public bool IsMinReaorderValueReached { get; set; }
        public string StockLevelTreeHeader { get; set; }
        public Nullable<System.DateTime> TallyUpdatedDate { get; set; }
        //public Nullable<decimal> TotalBagQuantity1 { get; set; }
        #endregion

        #region ItemChanges
        public Nullable<int> TallyUpdatedByID { get; set; }
        public string PacketUOM { get; set; }
        public string BagUOM { get; set; }
        public Nullable<decimal> PacketQTY { get; set; }
        public int? PacketUOMID { get; set; }
        public Nullable<decimal> BagQTY { get; set; }
        public int? BagUOMID { get; set; }
        public Nullable<int> ItemCompanyID { get; set; }
        public string SourceOfUpdate { get; set; }
        public Nullable<int> ReOrderlevel { get; set; }
        public Nullable<int> ReOrderQTY { get; set; }

        public string DisplayMessage { get; set; }

        #endregion
        //public virtual DLBatchCreation DLBatchCreation { get; set; }
        //public virtual DLBrandCreation DLBrandCreation { get; set; }
        //public virtual DLCategoryCreation DLCategoryCreation { get; set; }
        //public virtual DLPacketSizeDetailsCreation DLPacketSizeDetail { get; set; }
        //public virtual DLRackCreation DLRackCreation { get; set; }
        //public virtual DLSubCategoryCreation DLSubCategoryCreation { get; set; }
        //public virtual DLUserCreation DLUserCreation { get; set; }
        //public virtual DLUnitQuantityCreation DLUnitQuantityCreation { get; set; }

        public virtual DLItemRateCreation DLItemRateCreation { get; set; }
        public List<DLItemThresholdQtyCreation> dLBussinessTypesLists { get; set; }
        //public virtual List<DLDiscountCreation> DLDiscounts { get; set; }
        public Nullable<bool> IsCESSMapped { get; set; }
        public Nullable<decimal> CESSValue { get; set; }
        public Nullable<System.DateTime> CESSEffectiveDate { get; set; }
        public List<DLParameterCreation> SelectedParameters { get; set; }
        public Nullable<System.DateTime> GSTEffectiveDate { get; set; }
        public string DestinationItemCode { get; set; }
        public string DestinationItemName { get; set; }
        public string OrgID { get; set; }

        //added on 20/12/2019 so that child item to dump it to parent org
        public Nullable<bool> IsParentTallyUpdated { get; set; }
        //added on 28th aug 2020 for uom details and to be equal to tally
        public Nullable<int> BaseUnit { get; set; }
        public string BaseUnitName { get; set; }
        public Nullable<decimal> BasePKTValue { get; set; }
        public int? AlternateUnit { get; set; }
        public string AlternateUnitName { get; set; }
        public decimal? AlternatePKTValue { get; set; }
        public string BranchId { get; set; }
        public List<DLBranchCreation> lstBranches { get; set; }
        public List<LstMappedOrganization> lstMappedOrganization { get; set; }
    }

    #endregion
    public class DLItem : WBT.Common.DLActivate
    {
        private MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private tblItem lItem = new tblItem();
        private List<DLItemCreation> lstItemCreation = new List<DLItemCreation>();
        private DLItemCreation mItemCreation = new DLItemCreation();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<DLItemCreation> ItemCreation
        {
            get { return lstItemCreation; }
            set { lstItemCreation = value; }
        }
        public override object DataActivate(object Context)
        {
            object lResult = null;
            try
            {
                switch (this.GetApplicationActivate.DataState)
                {
                    //case Common.TransactionType.GetItemBranch:
                    //    lResult = GetDataForMapping(Context);
                    //    break;
                    //case Common.TransactionType.SaveGetItemBranch:
                    //    lResult = SaveDataForMapping(Context);
                    //    break;
                    //case Common.TransactionType.LoadItemList:
                    //    lResult = GetItemData(Context);
                    //    break;
                    case Common.TransactionType.Load:
                        DLItemCreation Criteria = (DLItemCreation)Context;
                        lResult = GetData(Criteria.SearchText, Criteria.OrgID);
                        break;
                    //case Common.TransactionType.GetFewItemData:
                    //    lResult = GetFewItemData(Context);
                    //    break;
                    //case Common.TransactionType.GetsingleItemData:
                    //    lResult = GetSingleItemData(Context);
                    //    break;
                    //case Common.TransactionType.TallySync:
                    //    lResult = GetDataForTallySync(Context);
                    //    break;
                    case Common.TransactionType.Save:
                        lResult = SaveData(Context);
                        break;
                    case Common.TransactionType.Edit:
                        lResult = EditData(Context);
                        break;
                    case Common.TransactionType.Delete:
                        lResult = DeleteData(Context);
                        break;
                    case Common.TransactionType.TallyUpdation:
                        lResult = TallyEditData(Context);
                        break;
                    case Common.TransactionType.BindAllData:
                        lResult = GetAllDdlData(Context);
                        break;
                        //case Common.TransactionType.GetBusinesType:
                        //    lResult = BusinessTypeCreations(Context);
                        //    break;
                        //case Common.TransactionType.GetSynItemCountForSySCpmy:
                        //    lResult = GetTallyUpdationPendingCount(Context);
                        //    break;
                }
                return lResult;
            }
            catch (Exception ex)
            {
                //        this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                //        this.GetApplicationActivate.GetErrormessages = ex.Message;
                //        this.GetApplicationActivate.GetErrorSource = ex.Source;
                //        this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }

        private object GetData(string SearchValue, string OrgID)
        {
            lstItemCreation = new List<DLItemCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    lstItemCreation = (List<DLItemCreation>)DLItemMapping.GetItemDetails();
                }

                #region delete code
                //using (Entities = new WBT.Entity.MWBTechnologyEntities())
                //{
                //    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                //        Entities.Database.Connection.Open();                        //to open the connection if closed

                //    #region New code refactor
                //    lstItemCreation = (from drow in Entities.Items.AsNoTracking()
                //                       select new DLItemCreation()
                //                       {
                //                           ID = drow.ID,
                //                           ItemCode = drow.ItemCode,
                //                           ItemName = drow.ItemName.Trim(),
                //                           ItemDetail = drow.ItemDetail.Trim(),
                //                           HSNCode = drow.HSNCode,
                //                           HSNSubCode = drow.HSNSubCode,
                //                           GST = drow.GST,
                //                           IsReturnable = drow.IsReturnable ?? null,
                //                           IsTrademarkRegistered = drow.IsTrademarkRegistered,
                //                           ReOrderlevel = drow.ReOrderlevel,
                //                           ReOrderQTY = drow.ReOrderQTY,
                //                           CategoryID = drow.CategoryID,
                //                           CategoryName = drow.tblCategory.CategoryName,
                //                           SubCategoryID = drow.SubCategoryID,
                //                           SubCategoryName = drow.tblSubCategory.SubCategoryName,
                //                           RackID = drow.RackID != null ? drow.RackID : 0,
                //                           PacketQTY = drow.PacketQTY,
                //                           PacketUOMID = drow.PacketUOMID,
                //                           BagQTY = drow.BagQTY,
                //                           BagUOMID = drow.BagUOMID,
                //                           IsItemBlocked = drow.IsItemBlocked,
                //                           ItemCompanyID = drow.tblBrand.ItemCompanyID,
                //                           BrandID = drow.BrandID,
                //                           IsActive = drow.IsActive,
                //                           ItemAlias = drow.Alias.Trim(),
                //                           Remark = string.Empty,
                //                           GSTEffectiveDate = drow.GSTEffectiveDate,
                //                           DestinationItemCode = drow.ItemCode,
                //                           DestinationItemName = drow.ItemName,
                //                           BaseUnit = drow.BaseUnit,
                //                           //if (drow.BaseUnit != null)
                //                           BaseUnitName = drow.BaseUnit != null ? (from e in Entities.UOMs
                //                                                                   where e.UnitID == drow.BaseUnit
                //                                                                   select e).FirstOrDefault().Unit : "",
                //                           BasePKTValue = drow.BasePKTValue,
                //                           AlternateUnit = drow.AlternateUnit,
                //                           //if (drow.AlternateUnit != null)
                //                           AlternateUnitName = drow.AlternateUnit != null ? Entities.UOMs.Where(i => i.UnitID == drow.AlternateUnit).FirstOrDefault().Unit : "",
                //                           AlternatePKTValue = drow.AlternatePKTValue,

                //                           #region Added For Tally
                //                           PacketUOM = drow.tblUOM1 != null ? drow.tblUOM1.Unit : "",
                //                           BagUOM = drow.tblUOM != null ? drow.tblUOM.Unit : "",
                //                           #endregion

                //                           StorageSpace = drow.StorageArea == null ? "" : drow.StorageArea.Trim(),
                //                           sIsActive = drow.IsActive == true ? "Yes" : "No",
                //                           IsTallyUpdated = drow.IsTallyUpdated.Value,
                //                           stringIsTallyUpdated = drow.IsTallyUpdated == false ? "No" : "Yes",
                //                           RateID = drow.RateID,
                //                           IsCESSMapped = drow.IsCESSMapped,
                //                           CESSValue = drow.CESSValue,
                //                           CESSEffectiveDate = drow.CESSEffectiveDate,
                //                           DaysToRefill = drow.DaysToRefill,
                //                           OrgID = drow.OrgID,
                //                           IsParentTallyUpdated = drow.IsParentTallyUpdated ?? false,
                //                           stringIsParentTallyUpdated = drow.IsParentTallyUpdated == false ? "No" : "Yes",

                //                           #region Item rate Details

                //                           DLItemRateCreation = drow.tblItemRate != null ?
                //                            new DLItemRateCreation()
                //                            {
                //                                RateID = drow.tblItemRate.RateID,
                //                                BaseRateOther = drow.tblItemRate.BaseRateOther,
                //                                PerUnitRate = drow.tblItemRate.PerUnitRate,
                //                            } : null,

                //                           #endregion

                //                           #region adding types of bussines value required to edit //sneha 3rd Sep 2020
                //                           dLBussinessTypesLists = drow.ItemThresholdQtyDetails.Select(a => new DLItemThresholdQtyCreation()
                //                           {
                //                               BusinessTypeID = a.BusinessTypeID != null ? a.BusinessTypeID.Value : 0,
                //                               BusinessTypeName = a.BusinessType.BusinessTypeName.Trim(),
                //                               MinQty = a.MinQty != null ? a.MinQty.Value : 1,
                //                               MaxQty = a.MaxQty != null ? a.MaxQty.Value : 1,
                //                               OrgId = a.OrgId,
                //                           }).ToList<DLItemThresholdQtyCreation>(),


                //                           #endregion
                //                       }).OrderBy(i => i.CategoryName).ToList();

                //    #endregion

                //    #region old code refactor 3rd sep 2020  by sneha
                //    //var result = (from gItems in Entities.Items.AsNoTracking()
                //    //              orderby gItems.ItemName
                //    //              select gItems);

                //    //foreach (var drow in result)
                //    //{
                //    //    mItemCreation = new DLItemCreation();
                //    //    mItemCreation.ID = drow.ID;
                //    //    mItemCreation.ItemCode = drow.ItemCode;
                //    //    mItemCreation.ItemName = drow.ItemName.Trim();
                //    //    mItemCreation.ItemDetail = drow.ItemDetail.Trim();
                //    //    // mItemCreation.HSNID = drow.HSNID != null ? drow.HSNID : (int?)null;
                //    //    mItemCreation.HSNCode = drow.HSNCode; //drow.tblHSNCode != null ? drow.tblHSNCode.HSNCode.ToString() : string.Empty;
                //    //    mItemCreation.HSNSubCode = drow.HSNSubCode;//drow.tblHSNCode != null ? drow.tblHSNCode.HSNSubCode.ToString() : string.Empty;
                //    //    mItemCreation.GST = drow.GST; //drow.tblHSNCode != null ? drow.tblHSNCode.GST : 0;
                //    //    mItemCreation.IsReturnable = drow.IsReturnable ?? null;
                //    //    mItemCreation.IsTrademarkRegistered = drow.IsTrademarkRegistered;// (drow.tblHSNCode != null && drow.tblHSNCode.IsTrademarkRegistered != null) ? drow.tblHSNCode.IsTrademarkRegistered : (bool?)null;
                //    //    mItemCreation.ReOrderlevel = drow.ReOrderlevel;
                //    //    mItemCreation.ReOrderQTY = drow.ReOrderQTY;
                //    //    mItemCreation.CategoryID = drow.CategoryID;
                //    //    mItemCreation.CategoryName = drow.tblCategory.CategoryName;
                //    //    mItemCreation.SubCategoryID = drow.SubCategoryID;
                //    //    mItemCreation.SubCategoryName = drow.tblSubCategory.SubCategoryName;
                //    //    mItemCreation.RackID = drow.RackID != null ? drow.RackID : 0;
                //    //    mItemCreation.PacketQTY = drow.PacketQTY;
                //    //    mItemCreation.PacketUOMID = drow.PacketUOMID;
                //    //    mItemCreation.BagQTY = drow.BagQTY;
                //    //    mItemCreation.BagUOMID = drow.BagUOMID;
                //    //    mItemCreation.IsItemBlocked = drow.IsItemBlocked;
                //    //    mItemCreation.ItemCompanyID = drow.tblBrand.ItemCompanyID;
                //    //    mItemCreation.BrandID = drow.BrandID;
                //    //    mItemCreation.IsActive = drow.IsActive;
                //    //    mItemCreation.ItemAlias = drow.Alias.Trim();
                //    //    mItemCreation.Remark = string.Empty;
                //    //    mItemCreation.GSTEffectiveDate = drow.GSTEffectiveDate;
                //    //    mItemCreation.DestinationItemCode = drow.ItemCode;
                //    //    mItemCreation.DestinationItemName = drow.ItemName;

                //    //    mItemCreation.BaseUnit = drow.BaseUnit;
                //    //    if (drow.BaseUnit != null)
                //    //        mItemCreation.BaseUnitName = (from e in Entities.UOMs.AsNoTracking()
                //    //                                      where e.UnitID == drow.BaseUnit
                //    //                                      select e).FirstOrDefault().Unit;
                //    //    mItemCreation.BasePKTValue = drow.BasePKTValue;
                //    //    mItemCreation.AlternateUnit = drow.AlternateUnit;
                //    //    if (drow.AlternateUnit != null)
                //    //        mItemCreation.AlternateUnitName = Entities.UOMs.AsNoTracking().Where(i => i.UnitID == drow.BaseUnit).FirstOrDefault().Unit;
                //    //    mItemCreation.AlternatePKTValue = drow.AlternatePKTValue;

                //    //    #region Added For Tally
                //    //    mItemCreation.CategoryName = drow.tblCategory.CategoryName;
                //    //    mItemCreation.PacketUOM = drow.tblUOM1 != null ? drow.tblUOM1.Unit : "";
                //    //    mItemCreation.BagUOM = drow.tblUOM != null ? drow.tblUOM.Unit : "";
                //    //    #endregion

                //    //    mItemCreation.StorageSpace = drow.StorageArea == null ? "" : drow.StorageArea.Trim();
                //    //    if (mItemCreation.IsActive == true)
                //    //    {
                //    //        mItemCreation.sIsActive = "Yes";
                //    //    }
                //    //    else
                //    //    {
                //    //        mItemCreation.sIsActive = "No";
                //    //    }
                //    //    mItemCreation.IsTallyUpdated = drow.IsTallyUpdated.Value;
                //    //    if (drow.IsTallyUpdated == false)
                //    //    {
                //    //        mItemCreation.stringIsTallyUpdated = "No";
                //    //    }
                //    //    else
                //    //    {
                //    //        mItemCreation.stringIsTallyUpdated = "Yes";
                //    //    }
                //    //    mItemCreation.RateID = drow.RateID;
                //    //    mItemCreation.IsCESSMapped = drow.IsCESSMapped;
                //    //    mItemCreation.CESSValue = drow.CESSValue;
                //    //    mItemCreation.CESSEffectiveDate = drow.CESSEffectiveDate;
                //    //    mItemCreation.DaysToRefill = drow.DaysToRefill;
                //    //    mItemCreation.OrgID = drow.OrgID;
                //    //    mItemCreation.IsParentTallyUpdated = drow.IsParentTallyUpdated ?? false;
                //    //    if (mItemCreation.IsParentTallyUpdated == false)
                //    //        mItemCreation.stringIsParentTallyUpdated = "No";
                //    //    else
                //    //        mItemCreation.stringIsParentTallyUpdated = "Yes";

                //    //    #region Item rate Details

                //    //    if (drow.tblItemRate != null)
                //    //    {
                //    //        mItemCreation.DLItemRateCreation = new DLItemRateCreation()
                //    //        {
                //    //            RateID = drow.tblItemRate.RateID,
                //    //            BaseRateOther = drow.tblItemRate.BaseRateOther,
                //    //            PerUnitRate = drow.tblItemRate.PerUnitRate,
                //    //        };
                //    //    }

                //    //    #endregion

                //    //    #region adding types of bussines value required to edit //sneha 17th AUg 2020
                //    //    if (drow.ItemThresholdQtyDetails != null && drow.ItemThresholdQtyDetails.Count > 0)
                //    //    {
                //    //        mItemCreation.dLBussinessTypesLists = new List<DLItemThresholdQtyCreation>();
                //    //        foreach (var item in drow.ItemThresholdQtyDetails)
                //    //        {
                //    //            DLItemThresholdQtyCreation dLItemThresholdQtyCreation = new DLItemThresholdQtyCreation();
                //    //            dLItemThresholdQtyCreation.BusinessTypeID = item.BusinessTypeID;
                //    //            dLItemThresholdQtyCreation.BusinessTypeName = item.BusinessType.BusinessTypeName;
                //    //            dLItemThresholdQtyCreation.MinQty = item.MinQty;
                //    //            dLItemThresholdQtyCreation.MaxQty = item.MaxQty;
                //    //            dLItemThresholdQtyCreation.OrgId = item.OrgId;
                //    //            mItemCreation.dLBussinessTypesLists.Add(dLItemThresholdQtyCreation);
                //    //        }

                //    //    }
                //    //    #endregion

                //    //    lstItemCreation.Add(mItemCreation);
                //    //}

                //    #endregion

                //    // is Item for prcess

                #endregion
                if (SearchValue != "Tally" && SearchValue != "Parent Tally" && !string.IsNullOrEmpty(SearchValue))
                    lstItemCreation = lstItemCreation.Where(c => (c.ItemName.ToLower().Trim().StartsWith(SearchValue.ToLower().Trim())
                   || c.ItemCode == SearchValue.ToLower().Trim()) && c.OrgID == OrgID).ToList();

                if (SearchValue == "Tally")
                    lstItemCreation = lstItemCreation.Where(t => t.IsTallyUpdated == false).ToList();

                if (SearchValue == "Parent Tally")
                    lstItemCreation = lstItemCreation.Where(t => t.IsParentTallyUpdated == false).ToList();

                return lstItemCreation;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }

        private object GetFewItemData(object Context)
        {
            lstItemCreation = new List<DLItemCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    DLItemCreation Criteria = (DLItemCreation)Context;

                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    lstItemCreation = (List<DLItemCreation>)DLItemMapping.GetFewItemDetails();
                }

                return lstItemCreation;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
        private object GetDataForTallySync(object Context)
        {
            lstItemCreation = new List<DLItemCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    DLItemCreation Criteria = (DLItemCreation)Context;

                    lstItemCreation = (List<DLItemCreation>)DLItemMapping.GetItemDetails(Criteria.OrgID, Criteria.BranchId);

                    //lstItemCreation = lstItemCreation.Where(i => i.IsTallyUpdated == false).ToList();
                }
                return lstItemCreation;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }

        private object SaveData(object Context)
        {
            mItemCreation = (DLItemCreation)Context;
            try
            {
                var IsValueexists = from gItems in Entities.tblItems.AsNoTracking()
                                    where gItems.ItemName.ToLower().Trim().Equals(mItemCreation.ItemName.ToLower().Trim())
                                    //&& gItems.IsActive == true
                                    select gItems.ItemName;

                var AliasExists = from gItems in Entities.tblItems.AsNoTracking()
                                  where gItems.Alias.ToLower().Trim().Equals(mItemCreation.ItemAlias)
                                  //&& gItems.IsActive == true
                                  select gItems.ItemName;

                var ItemCodeExists = from gItems in Entities.tblItems.AsNoTracking()
                                     where gItems.ItemCode.ToLower().Trim().Equals(mItemCreation.ItemCode)
                                     select gItems.ItemCode;

                ////Check the Alias exists
                if (AliasExists != null && AliasExists.Count() > 0)
                {
                    this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                }
                else if (IsValueexists.Count() != 0)
                {
                    this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                }
                else if (ItemCodeExists.Count() != 0)
                {
                    //this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                    this.GetApplicationActivate.DisplayMessage = "Item Code Exists.Referesh The Page";
                }
                else
                {
                    using (Entities = new Entity.MWBTCustomerAppEntities())
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                #region item rate tables insert
                                tblItemRate itemRate = new tblItemRate();
                                itemRate.RateID = Entities.tblItemRates.OrderByDescending(i => i.ID).FirstOrDefault().ID + 1; //WBT.Common.Helper.GetUniqueNumber;
                                itemRate.BaseRateOther = 0;// mItemCreation.DLItemRateCreation.BaseRateOther;
                                itemRate.PerUnitRate = 0;//mItemCreation.DLItemRateCreation.PerUnitRate;
                                itemRate.CreatedByID = mItemCreation.CreatedByID;
                                itemRate.ModifiedByID = mItemCreation.CreatedByID;
                                itemRate.CreationDate = Helper.GetCurrentDate;
                                itemRate.UpdateDate = Helper.GetCurrentDate;

                                var rateExists = (from gRate in Entities.tblItemRates.AsNoTracking()
                                                  where gRate.RateID == itemRate.RateID
                                                  select gRate).ToList();

                                ////Check the Alias exists
                                if (rateExists != null && rateExists.Count() > 0)
                                {
                                    Helper.TransactionLog("Item Rate Exists");
                                    int raterowCount = Entities.tblItemRates.AsNoTracking().Count();
                                    itemRate.RateID = raterowCount + 1;
                                }

                                Entities.tblItemRates.Add(itemRate);
                                Entities.SaveChanges();

                                #endregion

                                #region rate transaction details table insert added on 10th july 2020 for tracking and pricing changes

                                RateTransactionDetail rateTransactionDetail = new RateTransactionDetail();
                                rateTransactionDetail.RateID = itemRate.RateID;
                                rateTransactionDetail.OrgID = mItemCreation.OrgID;
                                rateTransactionDetail.BranchID = mItemCreation.BranchId;
                                rateTransactionDetail.Rate = mItemCreation.BaseRateOther;
                                rateTransactionDetail.CreatedById = mItemCreation.CreatedByID;
                                rateTransactionDetail.CreatedDate = Helper.GetCurrentDate;
                                Entities.RateTransactionDetails.Add(rateTransactionDetail);

                                Entities.SaveChanges();
                                #endregion

                                #region item table Details
                                mItemCreation.DLItemRateCreation.RateID = itemRate.RateID;
                                lItem.RateID = itemRate.RateID;
                                lItem.IsActive = true;
                                lItem.OldItemName = this.mItemCreation.OldItemName;
                                lItem.ItemCode = this.mItemCreation.ItemCode;
                                lItem.ItemName = this.mItemCreation.ItemName;
                                lItem.HSNCode = this.mItemCreation.HSNCode;
                                lItem.HSNSubCode = this.mItemCreation.HSNSubCode;
                                lItem.IsTrademarkRegistered = this.mItemCreation.IsTrademarkRegistered;
                                //lItem.GST = this.mItemCreation.GST;
                                //lItem.CESSValue = mItemCreation.CESSValue;
                                //lItem.CESSEffectiveDate = mItemCreation.CESSEffectiveDate;
                                //lItem.GSTEffectiveDate = mItemCreation.GSTEffectiveDate;
                                lItem.CategoryID = this.mItemCreation.CategoryID;
                                lItem.SubCategoryID = this.mItemCreation.SubCategoryID;
                                lItem.BrandID = this.mItemCreation.BrandID;
                                lItem.RackID = this.mItemCreation.RackID == 0 ? null : this.mItemCreation.RackID;
                                lItem.ItemDetail = this.mItemCreation.ItemDetail;
                                lItem.IsReturnable = this.mItemCreation.IsReturnable;
                                lItem.Alias = this.mItemCreation.ItemAlias;
                                lItem.StorageArea = this.mItemCreation.StorageSpace;
                                lItem.IsTallyUpdated = false;
                                lItem.PacketQTY = this.mItemCreation.PacketQTY;
                                lItem.PacketUOMID = this.mItemCreation.PacketUOMID;
                                lItem.BagQTY = this.mItemCreation.BagQTY;
                                lItem.BagUOMID = this.mItemCreation.BagUOMID;
                                lItem.IsItemBlocked = this.mItemCreation.IsItemBlocked;
                                lItem.ReOrderQTY = mItemCreation.ReOrderQTY;
                                lItem.ReOrderlevel = mItemCreation.ReOrderlevel;
                                lItem.DaysToRefill = mItemCreation.DaysToRefill;
                                lItem.IsCESSMapped = mItemCreation.IsCESSMapped;
                                lItem.CreatedDate = Helper.GetCurrentDate;
                                lItem.ModifiedDate = Helper.GetCurrentDate;
                                lItem.CreatedByID = mItemCreation.CreatedByID;
                                lItem.ModifiedByID = mItemCreation.CreatedByID;
                                lItem.SourceOfUpdate = mItemCreation.SourceOfUpdate;
                                lItem.OrgID = mItemCreation.OrgID;
                                lItem.BaseUnit = mItemCreation.BaseUnit;
                                lItem.BasePKTValue = mItemCreation.BasePKTValue;
                                lItem.AlternateUnit = mItemCreation.AlternateUnit;
                                lItem.AlternatePKTValue = mItemCreation.AlternatePKTValue;
                                lItem.isProcessItem = mItemCreation.IsProcessItemcheck;

                                #region ParameterMapping
                                if (mItemCreation.SelectedParameters != null && mItemCreation.SelectedParameters.Count > 0)
                                {
                                    #region deleteExistingParameterMapping
                                    var itemParameterListMapFromDB = Entities.tblItemParameterMaps.Where(e => e.ItemCode == this.mItemCreation.ItemCode).ToList();

                                    if (itemParameterListMapFromDB != null && itemParameterListMapFromDB.Count() > 0)
                                    {
                                        foreach (var parameterMap in itemParameterListMapFromDB)
                                        {
                                            Entities.Entry(parameterMap).State = EntityState.Deleted;
                                        }
                                    }
                                    #endregion

                                    lItem.tblItemParameterMaps.Clear();
                                    foreach (DLParameterCreation parameter in mItemCreation.SelectedParameters)
                                    {
                                        lItem.tblItemParameterMaps.Add(new tblItemParameterMap
                                        {
                                            ItemCode = this.mItemCreation.ItemCode,
                                            ParameterID = parameter.ParameterID,
                                            CreatedByID = this.mItemCreation.CreatedByID,
                                            ModifiedByID = this.mItemCreation.CreatedByID,
                                            CreatedDate = Helper.GetCurrentDate,
                                            UpdatedDate = Helper.GetCurrentDate,
                                            IsActive = true
                                        });
                                    }
                                }
                                #endregion

                                #region  assigned threshould qty added om 17th Aug 2020
                                if (mItemCreation.dLBussinessTypesLists != null && mItemCreation.dLBussinessTypesLists.Count() > 0)
                                {
                                    #region deleteExisting item threshold qty details

                                    var ItemsQty = Entities.ItemThresholdQtyDetails.Where(e => e.ItemCode == mItemCreation.ItemCode
                                    && e.OrgId == mItemCreation.OrgID && e.BranchID == mItemCreation.BranchId).ToList();

                                    if (ItemsQty != null && ItemsQty.Count() > 0)
                                    {
                                        foreach (var parameterMap in ItemsQty)
                                        {
                                            Entities.Entry(parameterMap).State = EntityState.Deleted;
                                        }
                                    }

                                    #endregion

                                    lItem.ItemThresholdQtyDetails.Clear();
                                    foreach (DLItemThresholdQtyCreation parameter in mItemCreation.dLBussinessTypesLists)
                                    {
                                        lItem.ItemThresholdQtyDetails.Add(new ItemThresholdQtyDetail
                                        {
                                            ItemCode = mItemCreation.ItemCode,
                                            OrgId = mItemCreation.OrgID,
                                            BranchID = mItemCreation.BranchId,
                                            BusinessTypeID = parameter.BusinessTypeID,
                                            CreatedById = this.mItemCreation.CreatedByID,
                                            ModifiedById = this.mItemCreation.CreatedByID,
                                            MaxQty = parameter.MaxQty,
                                            MinQty = parameter.MinQty,
                                            CreationDate = Helper.GetCurrentDate,
                                            ModifiedDate = Helper.GetCurrentDate,
                                        });

                                        lItem.FuturisticItemThresholdQties.Add(new FuturisticItemThresholdQty
                                        {
                                            ItemCode = mItemCreation.ItemCode,
                                            OrgId = mItemCreation.OrgID,
                                            BranchID = mItemCreation.BranchId,
                                            BusinessTypeID = parameter.BusinessTypeID,
                                            CreatedByID = this.mItemCreation.CreatedByID,
                                            ModifiedByID = this.mItemCreation.CreatedByID,
                                            MaxQty = parameter.MaxQty,
                                            MinQty = parameter.MinQty,
                                            MaxQtyAfterPeriod = parameter.MaxQty,
                                            MinQtyAfterPeriod = parameter.MinQty,
                                            CreatedDate = Helper.GetCurrentDate,
                                            ModifiedDate = Helper.GetCurrentDate,
                                            FrmEffectiveDate = Helper.GetCurrentDate.Date,
                                            FrmEffectiveTime = Helper.Get12hrtimeFormate(DateTime.Now),
                                            ToEffectiveDate = Helper.GetCurrentDate.AddDays(30).Date,
                                            ToEffectiveTime = Helper.Get12hrtimeFormate(DateTime.Now),
                                        });
                                    }
                                }
                                #endregion

                                Entities.tblItems.Add(lItem);



                                DLItemMapping.SaveData(mItemCreation, Entities);
                                Entities.SaveChanges();

                                //if (mItemCreation.lstBranches != null && mItemCreation.lstBranches.Count() > 0)
                                //{
                                //    foreach (var item in mItemCreation.lstBranches)
                                //    {
                                //        mItemCreation.BranchId = item.BranchID;
                                //        DLItemMapping.SaveData(mItemCreation, Entities);
                                //    }
                                //}
                                //29052021
                                #endregion

                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                this.GetApplicationActivate.GetErrormessages = ex.Message;
                                this.GetApplicationActivate.GetErrorSource = ex.Source;
                                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                throw;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return this.GetApplicationActivate;
        }

        private object EditData(object Context)
        {
            mItemCreation = ((DLItemCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    lItem = (from gItems in Entities.tblItems.AsNoTracking()
                             where gItems.ItemCode == mItemCreation.ItemCode
                             select gItems).FirstOrDefault();

                    if (lItem != null)
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                lItem.OldItemName = this.mItemCreation.OldItemName;
                                lItem.IsActive = this.mItemCreation.IsActive;
                                lItem.ItemName = this.mItemCreation.ItemName;
                                lItem.Alias = this.mItemCreation.ItemAlias;
                                lItem.IsReturnable = this.mItemCreation.IsReturnable;
                                lItem.RackID = this.mItemCreation.RackID;
                                lItem.ItemDetail = this.mItemCreation.ItemDetail;
                                lItem.StorageArea = this.mItemCreation.StorageSpace;
                                lItem.IsTrademarkRegistered = this.mItemCreation.IsTrademarkRegistered;
                                lItem.IsCESSMapped = mItemCreation.IsCESSMapped;
                                lItem.ReOrderlevel = mItemCreation.ReOrderlevel;
                                lItem.ReOrderQTY = mItemCreation.ReOrderQTY;
                                lItem.IsItemBlocked = mItemCreation.IsItemBlocked;
                                lItem.ModifiedDate = mItemCreation.CreatedDate;
                                lItem.ModifiedByID = mItemCreation.ModifiedByID;
                                lItem.SourceOfUpdate = mItemCreation.SourceOfUpdate;
                                lItem.DaysToRefill = mItemCreation.DaysToRefill;

                                #region CreateParameterMapping
                                if (mItemCreation.SelectedParameters != null && mItemCreation.SelectedParameters.Count > 0)
                                {
                                    #region  deleteExistingParameterMapping
                                    var itemParameterListMapFromDB = Entities.tblItemParameterMaps.Where(e => e.ItemCode == this.mItemCreation.ItemCode).ToList();

                                    if (itemParameterListMapFromDB != null && itemParameterListMapFromDB.Count > 0)
                                    {
                                        foreach (var parameterMap in itemParameterListMapFromDB)
                                        {
                                            Entities.Entry(parameterMap).State = EntityState.Deleted;
                                        }
                                    }
                                    #endregion

                                    lItem.tblItemParameterMaps = new List<tblItemParameterMap>();
                                    lItem.tblItemParameterMaps.Clear();
                                    foreach (DLParameterCreation parameter in mItemCreation.SelectedParameters)
                                    {
                                        lItem.tblItemParameterMaps.Add(new tblItemParameterMap
                                        {
                                            ItemCode = this.mItemCreation.ItemCode,
                                            ParameterID = parameter.ParameterID,
                                            CreatedByID = this.mItemCreation.CreatedByID,
                                            ModifiedByID = this.mItemCreation.CreatedByID,
                                            CreatedDate = DateTime.Now,
                                            UpdatedDate = DateTime.Now,
                                            IsActive = true
                                        });
                                    }

                                }

                                #endregion

                                #region  assigned threshould qty added on 17th Aug 2020 
                                //Edit option for threshold has been given a new screen on 7th sep 2020
                                #endregion

                                Entities.tblItems.Add(lItem);
                                Entities.Entry(lItem).State = EntityState.Modified;

                                DLItemMapping.SaveData(mItemCreation, Entities);

                                Entities.SaveChanges();

                                #region 
                                if (mItemCreation.lstMappedOrganization != null)
                                {
                                    foreach (var item in mItemCreation.lstMappedOrganization)
                                    {

                                        List<tblItemMapping> itemMapping = (from im in Entities.tblItemMappings.AsNoTracking()
                                                                            where im.ItemCode == mItemCreation.ItemCode
                                                                            && im.OrgID == item.OrgID
                                                                            select im).ToList();

                                        itemMapping.ForEach(i => i.IsTallyUpdated = false);
                                        itemMapping.ForEach(a => Entities.tblItemMappings.Add(a));
                                        itemMapping.ForEach(p => Entities.Entry(p).State = EntityState.Modified);
                                        Entities.SaveChanges();
                                    }

                                }
                                #endregion

                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                this.GetApplicationActivate.GetErrormessages = ex.Message;
                                this.GetApplicationActivate.GetErrorSource = ex.Source;
                                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                throw;
                            }
                        }
                        //}

                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return this.GetApplicationActivate;
        }
        //not used
        private object DeleteData(object Context)
        {
            mItemCreation = ((DLItemCreation)Context);
            try
            {
                lItem = (from gItems in Entities.tblItems.AsNoTracking()
                         where gItems.ItemCode == mItemCreation.ItemCode
                         && gItems.OrgID == mItemCreation.OrgID
                         select gItems).First();

                if (lItem != null)
                {
                    if (lItem.tblDeliveryNoteItems.Count == 0 || lItem.tblDiscounts.Count == 0
                        || lItem.tblPurchaseOrderWithItems.Count == 0 || lItem.tblSalesOrderInvoiceItemDetails.Count == 0
                        || lItem.tblSalesOrderItemWarehouseMaps.Count == 0 || lItem.tblSalesOrderWithItems.Count == 0
                        || lItem.tblItemMovements.Count == 0 || lItem.tblItemWarehouseMaps.Count == 0)
                    {
                        using (Entities = new Entity.MWBTCustomerAppEntities())
                        {
                            using (var dbcxtransaction = Entities.Database.BeginTransaction())
                            {
                                try
                                {
                                    lItem.IsActive = false;
                                    lItem.ModifiedDate = DateTime.Now;//WBT.Common.Helper.GetCurrentDatetime;
                                    lItem.CreatedByID = mItemCreation.CreatedByID;
                                    Entities.tblItems.Add(lItem);
                                    Entities.Entry(lItem).State = EntityState.Modified;
                                    Entities.SaveChanges();
                                    dbcxtransaction.Commit();
                                    this.GetApplicationActivate.DataState = Common.TransactionType.Deletesuccess;
                                }
                                catch (Exception ex)
                                {
                                    dbcxtransaction.Rollback();
                                    this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                    this.GetApplicationActivate.GetErrormessages = ex.Message;
                                    this.GetApplicationActivate.GetErrorSource = ex.Source;
                                    this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.GetApplicationActivate.DataState = Common.TransactionType.DataDependency;
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return this.GetApplicationActivate;
        }
        private object TallyEditData(object Context)
        {
            mItemCreation = ((DLItemCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    tblItemMapping lItem = (from gItems in Entities.tblItemMappings.AsNoTracking()
                                            where gItems.ItemCode == mItemCreation.ItemCode
                                            && gItems.OrgID == mItemCreation.OrgID
                                            && gItems.BranchID == mItemCreation.BranchId
                                            select gItems).FirstOrDefault();

                    if (lItem != null)
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                //if (mItemCreation.IsParentOrg == true)
                                //{
                                //    lItem.IsParentTallyUpdated = true;
                                //    lItem.IsTallyUpdated = true;
                                //}
                                //else
                                //{
                                //    lItem.IsParentTallyUpdated = false;
                                //    lItem.IsTallyUpdated = true;
                                //}
                                lItem.IsTallyUpdated = true;
                                lItem.TallyUpdatedDate = Helper.GetCurrentDate;
                                lItem.TallyUpdatedByID = mItemCreation.ModifiedByID;
                                Entities.tblItemMappings.Add(lItem);
                                Entities.Entry(lItem).State = EntityState.Modified;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                this.GetApplicationActivate.GetErrormessages = ex.Message;
                                this.GetApplicationActivate.GetErrorSource = ex.Source;
                                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                throw;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return this.GetApplicationActivate;
        }

        //Base price Screen
        public List<DLItemRateCreation> GetItemNameAndPriceForCategory(object Context)
        {
            List<DLItemRateCreation> lstItemRateCreation = new List<DLItemRateCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    DLItemRateCreation Criteria = (DLItemRateCreation)Context;

                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    lstItemRateCreation = (from imap in Entities.tblItemMappings.AsNoTracking()
                                           join item in Entities.tblItems on imap.ItemCode equals item.ItemCode
                                           join irate in Entities.tblItemRates on item.RateID equals irate.RateID
                                           where imap.IsActive == true && imap.OrgID == Criteria.OrgID
                                           select new DLItemRateCreation()
                                           {
                                               BranchID = imap.BranchID,
                                               OrgID = imap.OrgID,
                                               RateID = imap.RateID != null ? imap.RateID.Value : 0,
                                               ItemCode = imap.ItemCode,
                                               ItemName = imap.tblItem.ItemName.Trim(),
                                               CategoryID = imap.tblItem.CategoryID,
                                               SubCategoryID = imap.tblItem.SubCategoryID,
                                               CategoryName = imap.tblItem.tblCategory.CategoryName,
                                               IsEdited = false,
                                               IsOfferRate = imap.tblItemRate.IsOfferRate,
                                               PerUnitRate = imap.tblItemRate.PerUnitRate,
                                               PerUnitRateName = imap.tblItemRate.PerUnitRate == null ? "" : Entities.tblUOMs.Where(i => i.UnitID == imap.tblItemRate.PerUnitRate).FirstOrDefault().Unit,
                                               BaseRateOther = imap.tblItemRate.BaseRateOther.Value,
                                               EffectiveDate = imap.tblItemRate.UpdateDate == null ? (DateTime?)null : imap.tblItemRate.UpdateDate.Value,
                                               LastUpdated = (from rates in Entities.RateTransactionDetails
                                                              where rates.OrgID == Criteria.OrgID
                                                              orderby rates.TransID descending
                                                              select rates).Count() > 0 ?
                                                             (from rates in Entities.RateTransactionDetails
                                                              where rates.OrgID == Criteria.OrgID
                                                              orderby rates.TransID descending
                                                              select rates).FirstOrDefault().CreatedDate :
                                                             (from Item in Entities.tblItems
                                                              where Item.OrgID == Criteria.OrgID
                                                              orderby Item.CreatedDate descending
                                                              select Item).FirstOrDefault().CreatedDate,
                                           }).Distinct().ToList();

                    //Item Search
                    if (!string.IsNullOrEmpty(Criteria.ItemName))
                        lstItemRateCreation = lstItemRateCreation.Where(j => j.ItemName.ToLower().Contains(Criteria.ItemName.ToLower())).ToList();

                    if (Criteria.CategoryID > 0)
                        lstItemRateCreation = lstItemRateCreation.Where(i => i.CategoryID == Criteria.CategoryID).ToList();

                    if (Criteria.SubCategoryID > 0)
                        lstItemRateCreation = lstItemRateCreation.Where(j => j.SubCategoryID == Criteria.SubCategoryID).ToList();
                    lstItemRateCreation = lstItemRateCreation.Where(d => d.BaseRateOther > 0).ToList();

                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return lstItemRateCreation.OrderBy(a=>a.ItemName).ToList();
        }

        //Used In SalesOrder/pos for getting item details after selection of item
        public DLItemCreation GetItemDetailByCode(string itemCode, string OrgID, string BranchID)
        {
            mItemCreation = new DLItemCreation();
            try
            {
                // OrgID = Common.User.OrgID;
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    var item = Entities.tblItems.Where(e => e.ItemCode.ToUpper().Trim() == itemCode.ToUpper().Trim()
                    || e.Alias == itemCode).FirstOrDefault<tblItem>();
                    if (item != null)
                    {
                        mItemCreation.ItemCode = item.ItemCode;
                        mItemCreation.ItemDetail = item.ItemDetail;
                        mItemCreation.ItemName = item.ItemName;
                        mItemCreation.PacketUOM = item.tblUOM1 != null ? item.tblUOM1.Unit : "";  //inner pck unit
                        mItemCreation.PacketQTY = item.PacketQTY;                                  //inner pck qty
                        mItemCreation.BagQTY = item.BagQTY;                 //bag pck qtt
                        mItemCreation.BagUOM = item.tblUOM != null ? item.tblUOM.Unit : "";    //bag pck unit
                        mItemCreation.CreatedByID = item.CreatedByID;
                        mItemCreation.CreatedDate = item.CreatedDate;
                        mItemCreation.ModifiedDate = item.ModifiedDate;
                        mItemCreation.HSNCode = item.HSNCode;
                        if (item.tblItemWarehouseMaps.Count() > 0)
                            mItemCreation.Quantity = (item.tblItemWarehouseMaps.FirstOrDefault().Quantity - (item.tblItemWarehouseMaps.FirstOrDefault().SaleQuantity ?? 0) - (item.tblItemWarehouseMaps.FirstOrDefault().InfectedQty ?? 0));
                        //mItemCreation.ItemPrice = Convert.ToDecimal(Entities.ItemRates.Where(u => u.RateID == item.RateID).FirstOrDefault().BaseRateOther);                  
                        //mItemCreation.RatePer = Entities.ItemRates.Where(u => u.RateID == item.RateID).FirstOrDefault().tblUOM.Unit;
                        //mItemCreation.IsItemBlocked = item.IsItemBlocked;
                        //mItemCreation.GST = Convert.ToDecimal(item.GST);

                        //after addinh item mapping table 
                        if (!string.IsNullOrEmpty(OrgID))
                            mItemCreation.IsItemBlocked = Entities.tblItemMappings.Where(i => i.OrgID == OrgID && i.BranchID == BranchID && i.ItemCode == itemCode).Count() > 0 ? Entities.tblItemMappings.Where(i => i.OrgID == OrgID && i.BranchID == BranchID && i.ItemCode == itemCode).FirstOrDefault().IsItemBlocked : false;
                        else
                            mItemCreation.IsItemBlocked = false;

                        if (!string.IsNullOrEmpty(OrgID))
                        {
                            mItemCreation.ItemPrice = Entities.tblItemMappings.Where(i => i.OrgID == OrgID && i.BranchID == BranchID && i.ItemCode == itemCode).Count() > 0 ? (Convert.ToDecimal(Entities.tblItemMappings.Where(i => i.OrgID == OrgID && i.BranchID == BranchID && i.ItemCode == itemCode).FirstOrDefault().tblItemRate.BaseRateOther)) : 0;

                            mItemCreation.RatePer = Entities.tblItemMappings.Where(i => i.OrgID == OrgID && i.BranchID == BranchID && i.ItemCode == itemCode).Count() > 0 ? Entities.tblItemMappings.Where(i => i.OrgID == OrgID && i.BranchID == BranchID && i.ItemCode == itemCode).FirstOrDefault().tblItemRate.tblUOM.Unit : null;
                            mItemCreation.GST = Entities.tblItemMappings.Where(i => i.OrgID == OrgID && i.BranchID == BranchID && i.ItemCode == itemCode).Count() > 0 ? Entities.tblItemMappings.Where(i => i.OrgID == OrgID && i.BranchID == BranchID && i.ItemCode == itemCode).FirstOrDefault().GST ?? 0 : 0;
                        }
                    }
                }
            }

            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return mItemCreation;
        }
        public object GetstockLevelTreeData(object Context)
        {
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    DLItemCreation Criteria = (DLItemCreation)Context;
                    lstItemCreation = new List<DLItemCreation>();

                    if (Criteria.BrandID != null && Convert.ToInt32(Criteria.BranchId) > 0)
                        lstItemCreation = (from item in Entities.tblItems
                                           join warhousemap in Entities.tblItemWarehouseMaps on item.ItemCode equals warhousemap.ItemCode
                                           join warehouse in Entities.tblWarehouses on warhousemap.WarehouseID equals warehouse.WarehouseID
                                           where warhousemap.OrgID == Criteria.OrgID && warhousemap.BranchID == Criteria.BranchId
                                           select new DLItemCreation
                                           {
                                               ItemName = item.ItemName,
                                               ItemCode = item.ItemCode,
                                               ReOrderlevel = item.ReOrderlevel,
                                               ReOrderQTY = item.ReOrderQTY,
                                               WarehouseName = warehouse.WarehouseName,
                                               WarehouseStock = (warhousemap.Quantity - (warhousemap.SaleQuantity ?? 0)),
                                               IsMinReaorderValueReached = ((warhousemap.Quantity - (warhousemap.SaleQuantity ?? 0)) <= item.ReOrderlevel),
                                               StockLevelTreeHeader = item.ItemName + " " + warehouse.WarehouseName + " " + (warhousemap.Quantity - (warhousemap.SaleQuantity ?? 0))
                                           }).ToList<DLItemCreation>()
                                               .Where(e => e.WarehouseStock <= e.ReOrderlevel || e.WarehouseStock <= e.ReOrderQTY).OrderBy(e => e.IsMinReaorderValueReached).ToList<DLItemCreation>();
                    else
                        lstItemCreation = (from item in Entities.tblItems
                                           join warhousemap in Entities.tblItemWarehouseMaps on item.ItemCode equals warhousemap.ItemCode
                                           join warehouse in Entities.tblWarehouses on warhousemap.WarehouseID equals warehouse.WarehouseID
                                           where warhousemap.OrgID == Criteria.OrgID
                                           select new DLItemCreation
                                           {
                                               ItemName = item.ItemName,
                                               ItemCode = item.ItemCode,
                                               ReOrderlevel = item.ReOrderlevel ?? 0,
                                               ReOrderQTY = item.ReOrderQTY ?? 0,
                                               WarehouseName = warehouse.WarehouseName,
                                               WarehouseStock = (warhousemap.Quantity - (warhousemap.SaleQuantity ?? 0)),
                                               IsMinReaorderValueReached = ((warhousemap.Quantity - (warhousemap.SaleQuantity ?? 0)) <= (item.ReOrderlevel ?? 0)),
                                               StockLevelTreeHeader = item.ItemName + " " + warehouse.WarehouseName + " " + (warhousemap.Quantity - (warhousemap.SaleQuantity ?? 0))
                                           }).ToList<DLItemCreation>()
                                                    .Where(e => e.WarehouseStock <= e.ReOrderlevel).OrderBy(e => e.IsMinReaorderValueReached).ToList<DLItemCreation>();
                    //|| e.WarehouseStock <= e.ReOrderQTY

                    return lstItemCreation;
                }
            }

            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
        //to get stock in syn screen
        public decimal WarehouseListByItemCode(string ItemCode)
        {
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    return Entities.tblItemWarehouseMaps.Where(w => w.ItemCode.Trim() == ItemCode).ToList().Sum(q => q.Quantity);
                }
            }
            catch (Exception ex)
            {
                //Helper.LogError(ex);
                throw;
            }
        }
        private object GetItemData(object Context)
        {
            lstItemCreation = new List<DLItemCreation>();
            GetAllItemDropDownsData getItemLists = new GetAllItemDropDownsData();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    GetItemList CriteriaItem = (GetItemList)Context;

                    getItemLists.GetItemList = (from item in Entities.tblItems
                                                join itemmap in Entities.tblItemMappings on item.ItemCode equals itemmap.ItemCode
                                                where itemmap.OrgID == CriteriaItem.OrgID && itemmap.BranchID == null
                                                && itemmap.IsActive == true
                                                select new GetItemList
                                                {
                                                    ID = itemmap.ID,
                                                    ItemCode = itemmap.ItemCode,
                                                    ItemName = item.ItemName,
                                                    CategoryId = item.CategoryID,
                                                    SubCategoryId = item.SubCategoryID,
                                                    Select = (from dcitm in Entities.tblItemSupplierMappings
                                                              where dcitm.CustID == CriteriaItem.custid &&
                                                              dcitm.ItemCode == itemmap.ItemCode
                                                              select dcitm).Count() > 0 ? true : false,
                                                    OrgID = itemmap.OrgID,
                                                }).Distinct().ToList();

                    if (CriteriaItem.CategoryId > 0)
                        getItemLists.GetItemList = getItemLists.GetItemList.Where(i => i.CategoryId == CriteriaItem.CategoryId).ToList();
                    if (CriteriaItem.SubCategoryId > 0)
                        getItemLists.GetItemList = getItemLists.GetItemList.Where(i => i.SubCategoryId == CriteriaItem.SubCategoryId).ToList();
                    if (!string.IsNullOrEmpty(CriteriaItem.ItemName))
                        getItemLists.GetItemList = getItemLists.GetItemList.Where(i => i.ItemName.ToLower().StartsWith(CriteriaItem.ItemName.ToLower())).ToList();

                    getItemLists.DLSubcategoryList = (from subcat in Entities.tblSubCategories.AsNoTracking()
                                                      where subcat.OrgID == CriteriaItem.OrgID
                                                      select new DLSubcategoryList()
                                                      {
                                                          SubCategoryID = subcat.SubCategoryID,
                                                          SubCategoryName = subcat.SubCategoryName.Trim(),
                                                      }).ToList();

                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return getItemLists;
        }

        private object GetAllDdlData(object Context)
        {
            GetAllItemDropDownsData getAllItemDropDownsData = new GetAllItemDropDownsData();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    DLItemCreation Criteria = (DLItemCreation)Context;

                    if (Criteria.CategoryID > 0)
                    {
                        getAllItemDropDownsData.DLSubcategoryList = Subcategory(Criteria);
                    }
                    else if (Criteria.ItemCompanyID > 0)
                    {
                        getAllItemDropDownsData.DLBrandList = BrandList(Criteria);
                    }
                    else
                    {
                        getAllItemDropDownsData.DLSubcategoryList = Subcategory(Criteria);
                        getAllItemDropDownsData.DLCategoryList = Category(Criteria);
                        getAllItemDropDownsData.DLBrandList = BrandList(Criteria);
                        getAllItemDropDownsData.DLItemCompanyList = ItemCompanyList(Criteria);
                        getAllItemDropDownsData.DLRackList = RackList(Criteria);
                        getAllItemDropDownsData.DLUOMList = UOMList(Criteria);
                        //getAllItemDropDownsData.DlBranchLst = (from bran in Entities.Branches.AsNoTracking()
                        //where bran.OrgID == Criteria.OrgID
                        //select new DLBranchLst()
                        //{
                        //    OrgID = bran.OrgID,
                        //    BranchID = bran.BranchID,
                        //    BranchName = bran.Name,
                        //}).ToList();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return getAllItemDropDownsData;

        }
        private List<DLSubcategoryList> Subcategory(DLItemCreation Criteria)
        {
            List<DLSubcategoryList> DLSubcategoryList = new List<DLSubcategoryList>();

            DLSubcategoryList = (from Subcat in Entities.tblSubCategories.AsNoTracking()
                                     //where Subcat.SubCategoryID == Criteria.SubCategoryID
                                 select new DLSubcategoryList()
                                 {
                                     SubCategoryID = Subcat.SubCategoryID,
                                     SubCategoryName = Subcat.SubCategoryName.Trim(),
                                     OrgID = Subcat.OrgID,
                                     CategoryID = Subcat.CategoryID,
                                 }).ToList();

            if (Criteria.SubCategoryID > 0)
                DLSubcategoryList = DLSubcategoryList.Where(i => i.SubCategoryID == Criteria.SubCategoryID).ToList();

            if (Criteria.CategoryID > 0)
                DLSubcategoryList = DLSubcategoryList.Where(i => i.CategoryID == Criteria.CategoryID).ToList();

            return DLSubcategoryList;
        }
        private List<DLCategorylist> Category(DLItemCreation Criteria)
        {
            List<DLCategorylist> DLCategoryList = new List<DLCategorylist>();

            DLCategoryList = (from cat in Entities.tblCategories.AsNoTracking()
                                  //where cat.CategoryID == Criteria.CategoryID
                              select new DLCategorylist()
                              {
                                  CategoryID = cat.CategoryID,
                                  CategoryName = cat.CategoryName.Trim(),
                                  OrgID = cat.OrgID
                              }).ToList();

            if (Criteria.CategoryID > 0)
                DLCategoryList = DLCategoryList.Where(i => i.CategoryID == Criteria.CategoryID).ToList();

            return DLCategoryList;
        }
        private List<DLBrandList> BrandList(DLItemCreation Criteria)
        {
            List<DLBrandList> DLBrandList = new List<DLBrandList>();
            DLBrandList = (from Brands in Entities.tblBrands.AsNoTracking()
                               //where Brands.OrgID == Criteria.OrgID
                           select new DLBrandList()
                           {
                               BrandID = Brands.BrandID.ToString(),
                               BrandName = Brands.BrandName.Trim(),
                               OrgID = Brands.OrgID,
                               ItemCompanyID = Brands.ItemCompanyID,
                           }).ToList();

            if (Criteria.BrandID > 0)
                DLBrandList = DLBrandList.Where(i => Convert.ToInt32(i.BrandID) == Criteria.BrandID).ToList();

            if (Criteria.ItemCompanyID > 0)
                DLBrandList = DLBrandList.Where(i => i.ItemCompanyID == Criteria.ItemCompanyID).ToList();

            return DLBrandList;
        }
        private List<DLItemCompanyList> ItemCompanyList(DLItemCreation Criteria)
        {
            List<DLItemCompanyList> DLItemCompanyList = new List<DLItemCompanyList>();
            DLItemCompanyList = (from itmcmp in Entities.tblItemCompanies.AsNoTracking()
                                     //where itmcmp.OrgID == Criteria.OrgID
                                 select new DLItemCompanyList()
                                 {
                                     OrgID = itmcmp.OrgID,
                                     CompanyName = itmcmp.CompanyName.Trim(),
                                     ItemCompanyID = itmcmp.ItemCompanyID,
                                 }).ToList();
            return DLItemCompanyList;
        }
        private List<DLRackList> RackList(DLItemCreation Criteria)
        {
            List<DLRackList> DLRackList = new List<DLRackList>();
            DLRackList = (from rack in Entities.tblRacks.AsNoTracking()
                          where rack.OrgID == Criteria.OrgID
                          select new DLRackList()
                          {
                              RackID = rack.RackID,
                              RackNumber = rack.RackNumber.Trim(),
                          }).ToList();

            return DLRackList;
        }
        private List<DLUOMList> UOMList(DLItemCreation Criteria)
        {
            List<DLUOMList> DLUOMList = new List<DLUOMList>();
            DLUOMList = (from uoms in Entities.tblUOMs.AsNoTracking()
                         select new DLUOMList()
                         {
                             Unit = uoms.Unit,
                             UnitID = uoms.UnitID,
                         }).ToList();

            return DLUOMList;
        }

        //used in item to set threshould qty pop first time or during edit
        private List<DLBusinessTypeCreations> BusinessTypeCreations(object Context)
        {
            try
            {
                List<DLBusinessTypeCreations> DLBusinessTypeCreations = new List<DLBusinessTypeCreations>();
                DLItemCreation Criteria = (DLItemCreation)Context;

                if (Criteria.ItemCode != null)
                {
                    var itemthreshould = Entities.ItemThresholdQtyDetails.Where(i => i.ItemCode == Criteria.ItemCode && i.OrgId == Criteria.OrgID).ToList();

                    //DLBusinessTypeCreations = new List<DLBusinessTypeCreations>();
                    if (itemthreshould.Count == 0)
                    {
                        DLBusinessTypeCreations = (from Bt in Entities.BusinessTypes.AsNoTracking()
                                                   select new DLBusinessTypeCreations()
                                                   {
                                                       BusinessTypeName = Bt.BusinessTypeName.Trim(),
                                                       BusinessTypeID = Bt.BusinessTypeID,
                                                       OrgID = Bt.OrgId,
                                                       MinQty = 1,
                                                       MaxQty = 1,
                                                   }).Distinct().ToList();
                    }
                    else
                    {
                        var BusinessTypes = Entities.BusinessTypes.AsNoTracking().ToList();

                        DLBusinessTypeCreations = (from Bt in BusinessTypes
                                                   join BTQ in itemthreshould on Bt.BusinessTypeID
                                                   equals BTQ.BusinessTypeID
                                                   into ItemBasicExpenseDetails
                                                   from i in ItemBasicExpenseDetails.
                                                   DefaultIfEmpty()
                                                   select new DLBusinessTypeCreations()
                                                   {
                                                       BusinessTypeName = Bt.BusinessTypeName.Trim(),
                                                       BusinessTypeID = i?.BusinessTypeID == null ? 0 : i.BusinessTypeID.Value,
                                                       //OrgID = Bt.OrgId,
                                                       MinQty = i?.MinQty == null ? 1 : i.MinQty,
                                                       MaxQty = i?.MaxQty == null ? 1 : i.MaxQty,
                                                   }).Distinct().ToList();
                    }
                }

                return DLBusinessTypeCreations;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }

        #region Offer rates update Service

        #endregion

        #region "Added on 12-jan-2021  ---START"
        public object SaveProcessItemData(object Context)
        {
            DLProcessItemCreation dLProcessItemCreation = new DLProcessItemCreation();

            dLProcessItemCreation = (DLProcessItemCreation)Context;
            try
            {
                var IsValueexists = from gItems in Entities.tblProcessitem_Master.AsNoTracking()
                                    where gItems.ItemName.ToLower().Trim().Equals(mItemCreation.ItemName.ToLower().Trim())
                                   && gItems.IsActive == true
                                    //&& gItems.OrgID == mItemCreation.OrgID
                                    select gItems.ItemName;

                var AliasExists = from gItems in Entities.tblProcessitem_Master.AsNoTracking()
                                  where gItems.Alias.ToLower().Trim().Equals(mItemCreation.ItemAlias) && gItems.IsActive == true
                                  //&& gItems.OrgID == mItemCreation.OrgID
                                  select gItems.ItemName;

                ////Check the Alias exists
                if (AliasExists != null && AliasExists.Count() > 0)
                {
                    this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                }
                else if (IsValueexists.Count() != 0)
                {
                    this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                }
                else
                {
                    using (Entities = new Entity.MWBTCustomerAppEntities())
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                //#region item rate tables insert
                                //ItemRate itemRate = new ItemRate();
                                //itemRate.RateID = WBT.Common.Helper.GetUniqueNumber;
                                //itemRate.BaseRateOther = mItemCreation.DLItemRateCreation.BaseRateOther;
                                //itemRate.PerUnitRate = mItemCreation.DLItemRateCreation.PerUnitRate;
                                //itemRate.CreatedByID = mItemCreation.CreatedByID;
                                //itemRate.ModifiedByID = mItemCreation.CreatedByID;
                                //itemRate.CreationDate = Helper.GetCurrentDate;
                                //itemRate.UpdateDate = Helper.GetCurrentDate;

                                //var rateExists = (from gRate in Entities.ItemRates.AsNoTracking()
                                //                  where gRate.RateID == itemRate.RateID
                                //                  select gRate).ToList();

                                //////Check the Alias exists
                                //if (rateExists != null && rateExists.Count() > 0)
                                //{
                                //    Helper.TransactionLog("Item Rate Exists");
                                //    int raterowCount = Entities.ItemRates.AsNoTracking().Count();
                                //    itemRate.RateID = raterowCount + 1;
                                //}

                                //Entities.ItemRates.Add(itemRate);
                                //Entities.SaveChanges();

                                //#endregion

                                #region rate transaction details table insert added on 10th july 2020 for tracking and pricing changes

                                RateTransactionDetail rateTransactionDetail = new RateTransactionDetail();
                                rateTransactionDetail.RateID = 0;// itemRate.RateID;
                                rateTransactionDetail.Rate = mItemCreation.BaseRateOther;
                                rateTransactionDetail.CreatedById = mItemCreation.CreatedByID;
                                rateTransactionDetail.CreatedDate = Helper.GetCurrentDate;
                                Entities.RateTransactionDetails.Add(rateTransactionDetail);

                                Entities.SaveChanges();
                                #endregion

                                #region item table Details
                                lItem.RateID = 0;// itemRate.RateID;
                                lItem.IsActive = true;
                                lItem.ItemCode = this.mItemCreation.ItemCode;
                                lItem.ItemName = this.mItemCreation.ItemName;
                                lItem.HSNCode = this.mItemCreation.HSNCode;
                                lItem.HSNSubCode = this.mItemCreation.HSNSubCode;
                                lItem.IsTrademarkRegistered = this.mItemCreation.IsTrademarkRegistered;
                                lItem.GST = this.mItemCreation.GST;
                                lItem.CategoryID = this.mItemCreation.CategoryID;
                                lItem.SubCategoryID = this.mItemCreation.SubCategoryID;
                                lItem.BrandID = this.mItemCreation.BrandID;
                                lItem.RackID = this.mItemCreation.RackID == 0 ? null : this.mItemCreation.RackID;
                                lItem.ItemDetail = this.mItemCreation.ItemDetail;
                                lItem.IsReturnable = this.mItemCreation.IsReturnable;
                                lItem.Alias = this.mItemCreation.ItemAlias;
                                lItem.StorageArea = this.mItemCreation.StorageSpace;
                                lItem.IsTallyUpdated = false;
                                lItem.PacketQTY = this.mItemCreation.PacketQTY;
                                lItem.PacketUOMID = this.mItemCreation.PacketUOMID;
                                lItem.BagQTY = this.mItemCreation.BagQTY;
                                lItem.BagUOMID = this.mItemCreation.BagUOMID;
                                lItem.IsItemBlocked = this.mItemCreation.IsItemBlocked;
                                lItem.ReOrderQTY = mItemCreation.ReOrderQTY;
                                lItem.ReOrderlevel = mItemCreation.ReOrderlevel;
                                lItem.DaysToRefill = mItemCreation.DaysToRefill;
                                lItem.IsCESSMapped = mItemCreation.IsCESSMapped;
                                lItem.CESSValue = mItemCreation.CESSValue;
                                lItem.CESSEffectiveDate = mItemCreation.CESSEffectiveDate;
                                lItem.GSTEffectiveDate = mItemCreation.GSTEffectiveDate;
                                lItem.CreatedDate = Helper.GetCurrentDate;
                                lItem.ModifiedDate = Helper.GetCurrentDate;
                                lItem.CreatedByID = mItemCreation.CreatedByID;
                                lItem.ModifiedByID = mItemCreation.CreatedByID;
                                lItem.SourceOfUpdate = mItemCreation.SourceOfUpdate;
                                lItem.OrgID = mItemCreation.OrgID;
                                lItem.BaseUnit = mItemCreation.BaseUnit;
                                lItem.BasePKTValue = mItemCreation.BasePKTValue;
                                lItem.AlternateUnit = mItemCreation.AlternateUnit;
                                lItem.AlternatePKTValue = mItemCreation.AlternatePKTValue;

                                #region ParameterMapping
                                if (mItemCreation.SelectedParameters != null && mItemCreation.SelectedParameters.Count > 0)
                                {
                                    #region deleteExistingParameterMapping

                                    var itemParameterListMapFromDB = Entities.tblItemParameterMaps.Where(e => e.ItemCode == this.mItemCreation.ItemCode).ToList();

                                    if (itemParameterListMapFromDB != null && itemParameterListMapFromDB.Count() > 0)
                                    {
                                        foreach (var parameterMap in itemParameterListMapFromDB)
                                        {
                                            Entities.Entry(parameterMap).State = EntityState.Deleted;
                                        }
                                    }
                                    #endregion

                                    lItem.tblItemParameterMaps.Clear();
                                    foreach (DLParameterCreation parameter in mItemCreation.SelectedParameters)
                                    {
                                        lItem.tblItemParameterMaps.Add(new tblItemParameterMap
                                        {
                                            ItemCode = this.mItemCreation.ItemCode,
                                            ParameterID = parameter.ParameterID,
                                            CreatedByID = this.mItemCreation.CreatedByID,
                                            ModifiedByID = this.mItemCreation.CreatedByID,
                                            CreatedDate = Helper.GetCurrentDate,
                                            UpdatedDate = Helper.GetCurrentDate,
                                            IsActive = true
                                        });
                                    }
                                }
                                #endregion

                                //#region  assigned threshould qty added om 17th Aug 2020
                                //if (mItemCreation.dLBussinessTypesLists != null && mItemCreation.dLBussinessTypesLists.Count() > 0)
                                //{
                                //    #region deleteExistingParameterMapping
                                //    var ItemsQty = Entities.ItemThresholdQtyDetails.Where(e => e.ItemCode == mItemCreation.ItemCode).ToList();

                                //    if (ItemsQty != null && ItemsQty.Count() > 0)
                                //    {
                                //        foreach (var parameterMap in ItemsQty)
                                //        {
                                //            Entities.Entry(parameterMap).State = EntityState.Deleted;
                                //        }
                                //    }
                                //    #endregion

                                //    lItem.ItemThresholdQtyDetails.Clear();
                                //    foreach (DLItemThresholdQtyCreation parameter in mItemCreation.dLBussinessTypesLists)
                                //    {
                                //        lItem.ItemThresholdQtyDetails.Add(new ItemThresholdQtyDetail
                                //        {
                                //            ItemCode = mItemCreation.ItemCode,
                                //            OrgId = mItemCreation.OrgID,
                                //            BusinessTypeID = parameter.BusinessTypeID,
                                //            CreatedById = this.mItemCreation.CreatedByID,
                                //            ModifiedById = this.mItemCreation.CreatedByID,
                                //            MaxQty = parameter.MaxQty,
                                //            MinQty = parameter.MinQty,
                                //            CreationDate = Helper.GetCurrentDate,
                                //            ModifiedDate = Helper.GetCurrentDate,
                                //        });

                                //        lItem.FuturisticItemThresholdQties.Add(new FuturisticItemThresholdQty
                                //        {
                                //            ItemCode = mItemCreation.ItemCode,
                                //            OrgId = mItemCreation.OrgID,
                                //            BusinessTypeID = parameter.BusinessTypeID,
                                //            CreatedByID = this.mItemCreation.CreatedByID,
                                //            ModifiedByID = this.mItemCreation.CreatedByID,
                                //            MaxQty = parameter.MaxQty,
                                //            MinQty = parameter.MinQty,
                                //            MaxQtyAfterPeriod = parameter.MaxQty,
                                //            MinQtyAfterPeriod = parameter.MinQty,
                                //            CreatedDate = Helper.GetCurrentDate,
                                //            ModifiedDate = Helper.GetCurrentDate,
                                //            FrmEffectiveDate = Helper.GetCurrentDate.Date,
                                //            FrmEffectiveTime = Helper.Get12hrtimeFormate(DateTime.Now),
                                //            ToEffectiveDate = Helper.GetCurrentDate.AddDays(30).Date,
                                //            ToEffectiveTime = Helper.Get12hrtimeFormate(DateTime.Now),
                                //        });
                                //    }
                                //}
                                //#endregion

                                Entities.tblItems.Add(lItem);
                                Entities.SaveChanges();
                                #endregion

                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                this.GetApplicationActivate.GetErrormessages = ex.Message;
                                this.GetApplicationActivate.GetErrorSource = ex.Source;
                                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                throw;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return this.GetApplicationActivate;
        }

        public object GetProcessItemData(string SearchValue, string OrgID)
        {
            lstItemCreation = new List<DLItemCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    #region New code refactor
                    lstItemCreation = (from drow in Entities.tblProcessitem_Master.AsNoTracking()
                                       select new DLItemCreation()
                                       {
                                           ID = drow.ID,
                                           ItemCode = drow.ItemCode,
                                           ItemName = drow.ItemName.Trim(),
                                           ItemDetail = drow.ItemDetail.Trim(),
                                           HSNCode = drow.HSNCode,
                                           HSNSubCode = drow.HSNSubCode,
                                           GST = drow.GST,
                                           IsReturnable = drow.IsReturnable ?? null,
                                           IsTrademarkRegistered = drow.IsTrademarkRegistered,
                                           ReOrderlevel = drow.ReOrderlevel,
                                           ReOrderQTY = drow.ReOrderQTY,
                                           CategoryID = drow.CategoryID,
                                           CategoryName = Entities.tblCategories.Where(b => b.CategoryID == drow.CategoryID).Select(c => c.CategoryName).FirstOrDefault(),
                                           SubCategoryID = drow.SubCategoryID,
                                           SubCategoryName = Entities.tblSubCategories.Where(b => b.SubCategoryID == drow.SubCategoryID).Select(c => c.SubCategoryName).FirstOrDefault(),
                                           RackID = drow.RackID != null ? drow.RackID : 0,
                                           PacketQTY = drow.PacketQTY,
                                           PacketUOMID = drow.PacketUOMID,
                                           BagQTY = drow.BagQTY,
                                           BagUOMID = drow.BagUOMID,
                                           IsItemBlocked = drow.IsItemBlocked,
                                           ItemCompanyID = Entities.tblBrands.Where(b => b.BrandID == drow.BrandID).Select(c => c.ItemCompanyID).FirstOrDefault(), //
                                           BrandID = drow.BrandID,
                                           IsActive = drow.IsActive,
                                           ItemAlias = drow.Alias.Trim(),
                                           Remark = string.Empty,
                                           GSTEffectiveDate = drow.GSTEffectiveDate,
                                           DestinationItemCode = drow.ItemCode,
                                           DestinationItemName = drow.ItemName,
                                           BaseUnit = drow.BaseUnit,
                                           //if (drow.BaseUnit != null)
                                           BaseUnitName = drow.BaseUnit != null ? (from e in Entities.tblUOMs
                                                                                   where e.UnitID == drow.BaseUnit
                                                                                   select e).FirstOrDefault().Unit : "",
                                           BasePKTValue = drow.BasePKTValue,
                                           AlternateUnit = drow.AlternateUnit,
                                           //if (drow.AlternateUnit != null)
                                           AlternateUnitName = drow.AlternateUnit != null ? Entities.tblUOMs.Where(i => i.UnitID == drow.AlternateUnit).FirstOrDefault().Unit : "",
                                           AlternatePKTValue = drow.AlternatePKTValue,

                                           //#region Added For Tally
                                           //PacketUOM =Entities.UOMs.Where(uid=>uid.UnitID == drow.BaseUnit).FirstOrDefaultAsync().ToString(),    //drow.BaseUnit,//.tblUOM1 != null ? drow.tblUOM1.Unit : "",
                                           //BagUOM =  Entities.UOMs.Where(uid => uid.UnitID == drow.BaseUnit).Select(d=>d.b.FirstOrDefaultAsync().ToString(),    //
                                           //#endregion

                                           StorageSpace = drow.StorageArea == null ? "" : drow.StorageArea.Trim(),
                                           sIsActive = drow.IsActive == true ? "Yes" : "No",
                                           IsTallyUpdated = drow.IsTallyUpdated.Value,
                                           stringIsTallyUpdated = drow.IsTallyUpdated == false ? "No" : "Yes",
                                           RateID = drow.RateID,
                                           IsCESSMapped = drow.IsCESSMapped,
                                           CESSValue = drow.CESSValue,
                                           CESSEffectiveDate = drow.CESSEffectiveDate,
                                           DaysToRefill = drow.DaysToRefill,
                                           OrgID = drow.OrgID,
                                           IsParentTallyUpdated = drow.IsParentTallyUpdated ?? false,
                                           stringIsParentTallyUpdated = drow.IsParentTallyUpdated == false ? "No" : "Yes",

                                           #region Item rate Details

                                           //DLItemRateCreation = drow.tblItemRate != null ?
                                           // new DLItemRateCreation()
                                           // {
                                           //     RateID = drow.tblItemRate.RateID,
                                           //     BaseRateOther = drow.tblItemRate.BaseRateOther,
                                           //     PerUnitRate = drow.tblItemRate.PerUnitRate,
                                           // } : null,

                                           #endregion

                                           //#region adding types of bussines value required to edit //sneha 3rd Sep 2020
                                           //dLBussinessTypesLists = drow.ItemThresholdQtyDetails.Select(a => new DLItemThresholdQtyCreation()
                                           //{
                                           //    BusinessTypeID = a.BusinessTypeID != null ? a.BusinessTypeID.Value : 0,
                                           //    BusinessTypeName = a.BusinessType.BusinessTypeName.Trim(),
                                           //    MinQty = a.MinQty != null ? a.MinQty.Value : 1,
                                           //    MaxQty = a.MaxQty != null ? a.MaxQty.Value : 1,
                                           //    OrgId = a.OrgId,
                                           //}).ToList<DLItemThresholdQtyCreation>(),


                                           //#endregion
                                       }).OrderBy(i => i.CategoryName).ToList();

                    #endregion



                    if (SearchValue != "Tally" && SearchValue != "Parent Tally" && !string.IsNullOrEmpty(SearchValue))
                        lstItemCreation = lstItemCreation.Where(c => (c.ItemName.ToLower().Trim().StartsWith(SearchValue.ToLower().Trim())
                       || c.ItemCode == SearchValue.ToLower().Trim()) && c.OrgID == OrgID).ToList();

                    if (!string.IsNullOrEmpty(OrgID))
                        lstItemCreation = lstItemCreation.Where(c => c.OrgID.Trim() == OrgID).ToList();

                    if (SearchValue == "Tally")
                        lstItemCreation = lstItemCreation.Where(t => t.IsTallyUpdated == false).ToList();

                    if (SearchValue == "Parent Tally")
                        lstItemCreation = lstItemCreation.Where(t => t.IsParentTallyUpdated == false).ToList();

                    return lstItemCreation;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
        #endregion 'END'

        //added on 10 Feb 2021 by DEVIKA for item branch and Sis org mapping
        private object GetDataForMapping(object context)
        {
            GetItemList creation = new GetItemList();
            creation = (GetItemList)context;
            List<GetItemList> lstItemCreation = new List<GetItemList>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    if (creation.BranchID == null && creation.COrgID == null)
                    {

                        lstItemCreation = (from item in Entities.tblItemMappings
                                           where item.OrgID == creation.OrgID
                                           && item.BranchID == null
                                           select new GetItemList
                                           {

                                               ItemCode = item.ItemCode,
                                               ItemName = item.tblItem.ItemName,
                                               OrgID = item.OrgID,
                                               Select = false,
                                               IsActive = false,
                                               CategoryId = item.tblItem.CategoryID,
                                               CategoryName = item.tblItem.tblCategory.CategoryName,
                                               SubCategoryId = item.tblItem.SubCategoryID,
                                               BranchID = item.BranchID,
                                           }).OrderBy(g => g.CategoryName).ToList();
                    }
                    else if (creation.BranchID != null)
                    {
                        lstItemCreation = (from item in Entities.tblItemMappings
                                           where item.OrgID == creation.OrgID
                                           && item.BranchID == null
                                           select new GetItemList
                                           {
                                               ItemMapID = (from i in Entities.tblItemMappings
                                                            where i.OrgID == item.OrgID && i.BranchID == creation.BranchID
                                                            && i.ItemCode == item.ItemCode
                                                            select i).Count() == 0 ? 0 : (from i in Entities.tblItemMappings
                                                                                          where i.OrgID == item.OrgID && i.BranchID == creation.BranchID
                                                                                          && i.ItemCode == item.ItemCode
                                                                                          select i).FirstOrDefault().ItemMappingID,
                                               ItemCode = item.ItemCode,
                                               ItemName = item.tblItem.ItemName,
                                               OrgID = item.OrgID,
                                               Select = (from i in Entities.tblItemMappings
                                                         where i.OrgID == item.OrgID && i.BranchID == creation.BranchID
                                                         && i.ItemCode == item.ItemCode
                                                         select i).Count() == 0 ? false : true,
                                               IsActive = (from i in Entities.tblItemMappings
                                                           where i.OrgID == item.OrgID && i.BranchID == creation.BranchID
                                                           && i.ItemCode == item.ItemCode
                                                           select i).Count() == 0 ? false : (from i in Entities.tblItemMappings
                                                                                             where i.OrgID == item.OrgID && i.BranchID == creation.BranchID
                                                                                             && i.ItemCode == item.ItemCode
                                                                                             select i).FirstOrDefault().IsActive.Value,
                                               BranchID = item.BranchID,
                                               CategoryId = item.tblItem.CategoryID,
                                               CategoryName = item.tblItem.tblCategory.CategoryName,
                                               SubCategoryId = item.tblItem.SubCategoryID,
                                           }).OrderBy(g => g.CategoryName).ToList();
                    }
                    else if (creation.COrgID != null)
                    {
                        lstItemCreation = (from item in Entities.tblItemMappings
                                           where item.OrgID == creation.OrgID
                                           && item.BranchID == null
                                           select new GetItemList
                                           {
                                               ItemMapID = (from i in Entities.tblItemMappings
                                                            where i.OrgID == creation.COrgID && i.COrgID == creation.OrgID
                                                            && i.ItemCode == item.ItemCode
                                                            select i).Count() == 0 ? 0 : (from i in Entities.tblItemMappings
                                                                                          where i.OrgID == creation.COrgID && i.COrgID == creation.OrgID
                                                                                          && i.ItemCode == item.ItemCode
                                                                                          select i).FirstOrDefault().ItemMappingID,
                                               ItemCode = item.ItemCode,
                                               ItemName = item.tblItem.ItemName,
                                               OrgID = item.OrgID,
                                               Select = (from i in Entities.tblItemMappings
                                                         where i.OrgID == creation.COrgID && i.COrgID == creation.OrgID
                                                          && i.ItemCode == item.ItemCode
                                                         select i).Count() == 0 ? false : true,
                                               IsActive = (from i in Entities.tblItemMappings
                                                           where i.OrgID == creation.COrgID && i.COrgID == creation.OrgID
                                                            && i.ItemCode == item.ItemCode
                                                           select i).Count() == 0 ? false : (from i in Entities.tblItemMappings
                                                                                             where i.OrgID == creation.COrgID && i.COrgID == creation.OrgID
                                                                                             && i.ItemCode == item.ItemCode
                                                                                             select i).FirstOrDefault().IsActive.Value,
                                               BranchID = item.BranchID,
                                               CategoryId = item.tblItem.CategoryID,
                                               CategoryName = item.tblItem.tblCategory.CategoryName,
                                               SubCategoryId = item.tblItem.SubCategoryID,
                                           }).OrderBy(g => g.CategoryName).ToList();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return lstItemCreation;
        }
        public object SaveDataForMapping(object Context)
        {
            try
            {
                List<DLItemCreation> dLItemCreationLst = new List<DLItemCreation>();
                dLItemCreationLst = (List<DLItemCreation>)Context;
                tblItemMapping itemMapping;

                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            List<tblItemMapping> list = new List<tblItemMapping>();

                            if (dLItemCreationLst.FirstOrDefault().BranchId != null)
                            {
                                string orgid = dLItemCreationLst.FirstOrDefault().OrgID;
                                string bid = dLItemCreationLst.FirstOrDefault().BranchId;
                                list = (from i in Entities.tblItemMappings
                                        where i.OrgID == orgid
                                        && i.BranchID == bid
                                        select i).ToList();
                            }
                            else if (dLItemCreationLst.FirstOrDefault().COrgID != null)
                            {
                                string orgid = dLItemCreationLst.FirstOrDefault().OrgID; // child org id that is sister org id
                                string cid = dLItemCreationLst.FirstOrDefault().COrgID; //this contains parent org id
                                list = (from i in Entities.tblItemMappings
                                        where i.OrgID == orgid
                                        && i.COrgID == cid
                                        select i).ToList();
                            }

                            #region to delete
                            //if (list != null)
                            //{
                            //    if (list.Count > 0)
                            //    {
                            //        List<ItemMapping> data = new List<ItemMapping>();
                            //        data = (List<ItemMapping>)list;
                            //        foreach (var delItem in data)
                            //        {
                            //            List<DLItemCreation> lst = dLItemCreationLst.Where(i => i.ItemMapID == delItem.ItemMappingID).ToList();
                            //            if (lst.Count == 0)
                            //            {
                            //                Entities.Entry(delItem).State = EntityState.Deleted;
                            //                Entities.SaveChanges();
                            //            }
                            //        }
                            //    }
                            //}
                            #endregion

                            foreach (var dLItemCreation in dLItemCreationLst)
                            {

                                tblItemMapping exists = list.Count() > 0 ? list.Where(i => i.ItemMappingID == dLItemCreation.ItemMapID).FirstOrDefault() : null;
                                if (exists != null) //edit
                                {
                                    exists.BranchID = dLItemCreation.BranchId;
                                    exists.ItemCode = dLItemCreation.ItemCode;
                                    exists.OrgID = dLItemCreation.OrgID;
                                    exists.COrgID = dLItemCreation.COrgID;
                                    exists.IsActive = dLItemCreation.IsActive;
                                    exists.ModifiedByID = dLItemCreation.CreatedByID;
                                    exists.ModifiedDate = dLItemCreation.CreatedDate;
                                    Entities.Entry(exists).State = EntityState.Modified;
                                }
                                else
                                {
                                    tblItemMapping OrglevelData = (from items in Entities.tblItemMappings.AsNoTracking()
                                                                   where items.OrgID == (dLItemCreation.COrgID == null
                                                                   ? dLItemCreation.OrgID : dLItemCreation.COrgID)
                                                                   && items.ItemCode == dLItemCreation.ItemCode
                                                                   select items).FirstOrDefault();

                                    var mappingid = Entities.tblItemMappings.OrderByDescending(i => i.ID).FirstOrDefault().ID + 1;
                                    itemMapping = new tblItemMapping();
                                    itemMapping.ItemMappingID = mappingid;
                                    itemMapping.BranchID = dLItemCreation.BranchId;
                                    itemMapping.COrgID = dLItemCreation.COrgID;
                                    itemMapping.ItemCode = dLItemCreation.ItemCode;
                                    itemMapping.OrgID = dLItemCreation.OrgID;
                                    itemMapping.IsActive = dLItemCreation.IsActive;
                                    itemMapping.CreatedByID = dLItemCreation.CreatedByID;
                                    itemMapping.CreatedDatetime = dLItemCreation.CreatedDate;
                                    if (dLItemCreation.COrgID == null)
                                    {
                                        //added by sneha
                                        itemMapping.RateID = OrglevelData.RateID;
                                        itemMapping.GST = OrglevelData.GST;
                                        itemMapping.ReOrderlevel = OrglevelData.ReOrderlevel;
                                        itemMapping.ReOrderQTY = OrglevelData.ReOrderQTY;
                                        itemMapping.DaysToRefill = OrglevelData.DaysToRefill;
                                        itemMapping.CESSValue = OrglevelData.CESSValue;
                                        itemMapping.IsReturnable = OrglevelData.IsReturnable;
                                        Entities.tblItemMappings.Add(itemMapping);
                                    }
                                    else
                                    {
                                        #region item rate tables insert
                                        tblItemRate itemRate = new tblItemRate();
                                        itemRate.RateID = Entities.tblItemRates.OrderByDescending(i => i.ID).FirstOrDefault().ID + 1;
                                        itemRate.BaseRateOther = OrglevelData.tblItemRate.BaseRateOther;
                                        itemRate.PerUnitRate = OrglevelData.tblItemRate.PerUnitRate;
                                        itemRate.CreatedByID = dLItemCreation.CreatedByID;
                                        itemRate.CreationDate = Helper.GetCurrentDate;
                                        Entities.tblItemRates.Add(itemRate);
                                        Entities.SaveChanges();

                                        #endregion

                                        itemMapping.RateID = itemRate.RateID;
                                        itemMapping.GST = OrglevelData.GST;
                                        itemMapping.ReOrderlevel = OrglevelData.ReOrderlevel;
                                        itemMapping.ReOrderQTY = OrglevelData.ReOrderQTY;
                                        itemMapping.DaysToRefill = OrglevelData.DaysToRefill;
                                        itemMapping.CESSValue = OrglevelData.CESSValue;
                                        itemMapping.IsReturnable = OrglevelData.IsReturnable;
                                        Entities.tblItemMappings.Add(itemMapping);
                                        Entities.SaveChanges();
                                    }
                                }

                                Entities.SaveChanges();
                            }

                            dbcxtransaction.Commit();
                            this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                            this.GetApplicationActivate.GetErrormessages = ex.Message;
                            this.GetApplicationActivate.GetErrorSource = ex.Source;
                            this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return this.GetApplicationActivate;
        }

        /// <summary>
        /// added by sneha on 31st Mar 2021 to get tallyupdation pending items list for sister org
        /// </summary>
        /// <param name="Context"></param>
        private object GetTallyUpdationPendingCount(object Context)
        {
            int itemMappingPndg = 0;
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    DLItemCreation Criteria = (DLItemCreation)Context;

                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    itemMappingPndg = (from imap in Entities.tblItemMappings.AsNoTracking()
                                       where imap.OrgID == Criteria.OrgID &&
                                       (imap.IsTallyUpdated == false || imap.IsTallyUpdated == null)
                                       select imap).Count();
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
            return itemMappingPndg;
        }
        public List<tblCategory> GetGroupList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblCategory> catgList = new List<tblCategory>();
                        catgList = (from s in Entities.tblCategories
                                    where s.OrgID == OrgID
                                    select s).OrderBy(x => x.CategoryName).ToList();

                        return catgList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<DLSubCategoryCreation> GetSubCategoryList(int categoryId)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<DLSubCategoryCreation> subcatgList = new List<DLSubCategoryCreation>();
                        subcatgList = (from s in Entities.tblSubCategories
                                       where s.CategoryID == categoryId
                                       select new DLSubCategoryCreation
                                       {
                                           SubCategoryID = s.SubCategoryID,
                                           SubCategoryName = s.SubCategoryName,
                                       }).OrderBy(i => i.SubCategoryName).ToList();

                        return subcatgList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<tblUOM> GetUOMList()
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblUOM> uomList = new List<tblUOM>();
                        uomList = (from s in Entities.tblUOMs
                                   select s).ToList();
                        return uomList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<tblBrand> GetBrandList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblBrand> brandList = new List<tblBrand>();
                        brandList = (from s in Entities.tblBrands
                                     where s.OrgID == OrgID
                                     select s).OrderBy(m => m.BrandName).ToList();
                        return brandList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<tblItemCompany> GetCompanyList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblItemCompany> cmpnyList = new List<tblItemCompany>();
                        cmpnyList = (from s in Entities.tblItemCompanies
                                     where s.OrgID == OrgID
                                     select s).OrderBy(x => x.CompanyName).ToList();
                        return cmpnyList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public DLItemCreation SaveItem(DLItemCreation dlitemcreation)
        {
            DLItemCreation dLItemCreation = new DLItemCreation();

            mItemCreation = (DLItemCreation)dlitemcreation;
            try
            {
                var IsValueexists = from gItems in Entities.tblItems.AsNoTracking()
                                    where gItems.ItemName.ToLower().Trim().Equals(mItemCreation.ItemName.ToLower().Trim())
                                   && gItems.IsActive == true
                                    && gItems.OrgID == mItemCreation.OrgID
                                    select gItems.ItemName;

                var AliasExists = from gItems in Entities.tblItems.AsNoTracking()
                                  where gItems.Alias.ToLower().Trim().Equals(mItemCreation.ItemAlias) && gItems.IsActive == true
                                  && gItems.OrgID == mItemCreation.OrgID
                                  select gItems.ItemName;

                var ItemCodeExists = from gItems in Entities.tblItems.AsNoTracking()
                                     where gItems.ItemCode.ToLower().Trim().Equals(mItemCreation.ItemCode)
                                     select gItems.ItemCode;


                ////Check the Alias exists
                if (AliasExists != null && AliasExists.Count() > 0)
                {
                    this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                    mItemCreation.DisplayMessage = "Item Alias Name Already Exists";
                    return mItemCreation;
                }
                else if (IsValueexists.Count() != 0)
                {
                    this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                    mItemCreation.DisplayMessage = "Item Name Already Exists";
                    return mItemCreation;
                }
                else if (ItemCodeExists.Count() != 0)
                {
                    this.GetApplicationActivate.DataState = Common.TransactionType.DataExists;
                    mItemCreation.DisplayMessage = "Item Code Already Exists";
                    return mItemCreation;
                }
                else
                {
                    using (Entities = new Entity.MWBTCustomerAppEntities())
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                #region item rate tables insert
                                tblItemRate itemRate = new tblItemRate();
                                itemRate.RateID = WBT.Common.Helper.GetUniqueNumber;
                                mItemCreation.RateID = itemRate.RateID;
                                itemRate.BaseRateOther = mItemCreation.BaseRateOther;
                                itemRate.PerUnitRate = mItemCreation.BaseUnit;
                                itemRate.CreatedByID = mItemCreation.CreatedByID;
                                itemRate.ModifiedByID = mItemCreation.CreatedByID;
                                itemRate.CreationDate = Helper.GetCurrentDate;
                                itemRate.UpdateDate = Helper.GetCurrentDate;

                                var rateExists = (from gRate in Entities.tblItemRates.AsNoTracking()
                                                  where gRate.RateID == itemRate.RateID
                                                  select gRate).ToList();

                                ////Check the Alias exists
                                if (rateExists != null && rateExists.Count() > 0)
                                {
                                    Helper.TransactionLog("Item Rate Exists");
                                    int raterowCount = Entities.tblItemRates.AsNoTracking().Count();
                                    itemRate.RateID = raterowCount + 1;
                                }

                                Entities.tblItemRates.Add(itemRate);
                                Entities.SaveChanges();

                                #endregion

                                #region rate transaction details table insert added on 10th july 2020 for tracking and pricing changes

                                RateTransactionDetail rateTransactionDetail = new RateTransactionDetail();
                                rateTransactionDetail.RateID = itemRate.RateID;
                                rateTransactionDetail.Rate = mItemCreation.BaseRateOther;
                                rateTransactionDetail.CreatedById = mItemCreation.CreatedByID;
                                rateTransactionDetail.CreatedDate = Helper.GetCurrentDate;
                                Entities.RateTransactionDetails.Add(rateTransactionDetail);

                                Entities.SaveChanges();
                                #endregion

                                #region item table Details
                                lItem.RateID = itemRate.RateID;
                                lItem.IsActive = true;
                                lItem.ItemCode = this.mItemCreation.ItemCode;
                                lItem.ItemName = this.mItemCreation.ItemName + "" + mItemCreation.ItemNameWithUnit;
                                lItem.HSNCode = this.mItemCreation.HSNCode;
                                lItem.HSNSubCode = this.mItemCreation.HSNSubCode;
                                lItem.IsTrademarkRegistered = this.mItemCreation.IsTrademarkRegistered;
                                lItem.GST = this.mItemCreation.GST;
                                lItem.CategoryID = this.mItemCreation.CategoryID;
                                lItem.SubCategoryID = this.mItemCreation.SubCategoryID;
                                lItem.BrandID = this.mItemCreation.BrandID;
                                lItem.RackID = this.mItemCreation.RackID == 0 ? null : this.mItemCreation.RackID;
                                lItem.ItemDetail = this.mItemCreation.ItemDetail;
                                lItem.IsReturnable = this.mItemCreation.IsReturnable;
                                lItem.Alias = this.mItemCreation.ItemAlias;
                                lItem.StorageArea = this.mItemCreation.StorageSpace;
                                lItem.IsTallyUpdated = false;
                                lItem.PacketQTY = this.mItemCreation.PacketQTY;
                                lItem.PacketUOMID = this.mItemCreation.PacketUOMID;
                                lItem.BagQTY = this.mItemCreation.BagQTY;
                                lItem.BagUOMID = this.mItemCreation.BagUOMID;
                                lItem.IsItemBlocked = this.mItemCreation.IsItemBlocked;
                                lItem.ReOrderQTY = mItemCreation.ReOrderQTY;
                                lItem.ReOrderlevel = mItemCreation.ReOrderlevel;
                                lItem.DaysToRefill = mItemCreation.DaysToRefill;
                                lItem.IsCESSMapped = mItemCreation.IsCESSMapped;
                                lItem.CESSValue = mItemCreation.CESSValue;
                                lItem.CESSEffectiveDate = mItemCreation.CESSEffectiveDate;
                                lItem.GSTEffectiveDate = mItemCreation.GSTEffectiveDate;
                                lItem.CreatedDate = Helper.GetCurrentDate;
                                lItem.ModifiedDate = Helper.GetCurrentDate;
                                lItem.CreatedByID = mItemCreation.CreatedByID;
                                lItem.ModifiedByID = mItemCreation.CreatedByID;
                                lItem.SourceOfUpdate = mItemCreation.SourceOfUpdate;
                                lItem.OrgID = mItemCreation.OrgID;
                                lItem.BaseUnit = mItemCreation.BaseUnit;
                                lItem.BasePKTValue = mItemCreation.BasePKTValue;
                                lItem.AlternateUnit = mItemCreation.AlternateUnit;
                                lItem.AlternatePKTValue = mItemCreation.AlternatePKTValue;
                                lItem.isProcessItem = false;

                                #region ParameterMapping
                                if (mItemCreation.SelectedParameters != null && mItemCreation.SelectedParameters.Count > 0)
                                {
                                    #region deleteExistingParameterMapping

                                    var itemParameterListMapFromDB = Entities.tblItemParameterMaps.Where(e => e.ItemCode == this.mItemCreation.ItemCode).ToList();

                                    if (itemParameterListMapFromDB != null && itemParameterListMapFromDB.Count() > 0)
                                    {
                                        foreach (var parameterMap in itemParameterListMapFromDB)
                                        {
                                            Entities.Entry(parameterMap).State = EntityState.Deleted;
                                        }
                                    }
                                    #endregion

                                    lItem.tblItemParameterMaps.Clear();
                                    foreach (DLParameterCreation parameter in mItemCreation.SelectedParameters)
                                    {
                                        lItem.tblItemParameterMaps.Add(new tblItemParameterMap
                                        {
                                            ItemCode = this.mItemCreation.ItemCode,
                                            ParameterID = parameter.ParameterID,
                                            CreatedByID = this.mItemCreation.CreatedByID,
                                            ModifiedByID = this.mItemCreation.CreatedByID,
                                            CreatedDate = Helper.GetCurrentDate,
                                            UpdatedDate = Helper.GetCurrentDate,
                                            IsActive = true
                                        });
                                    }
                                }
                                #endregion

                                //#region  assigned threshould qty added om 17th Aug 2020
                                //if (mItemCreation.dLBussinessTypesLists != null && mItemCreation.dLBussinessTypesLists.Count() > 0)
                                //{
                                //    #region deleteExistingParameterMapping
                                //    var ItemsQty = Entities.ItemThresholdQtyDetails.Where(e => e.ItemCode == mItemCreation.ItemCode).ToList();

                                //    if (ItemsQty != null && ItemsQty.Count() > 0)
                                //    {
                                //        foreach (var parameterMap in ItemsQty)
                                //        {
                                //            Entities.Entry(parameterMap).State = EntityState.Deleted;
                                //        }
                                //    }
                                //    #endregion

                                //    lItem.ItemThresholdQtyDetails.Clear();
                                //    foreach (DLItemThresholdQtyCreation parameter in mItemCreation.dLBussinessTypesLists)
                                //    {
                                //        lItem.ItemThresholdQtyDetails.Add(new ItemThresholdQtyDetail
                                //        {
                                //            ItemCode = mItemCreation.ItemCode,
                                //            OrgId = mItemCreation.OrgID,
                                //            BusinessTypeID = parameter.BusinessTypeID,
                                //            CreatedById = this.mItemCreation.CreatedByID,
                                //            ModifiedById = this.mItemCreation.CreatedByID,
                                //            MaxQty = parameter.MaxQty,
                                //            MinQty = parameter.MinQty,
                                //            CreationDate = Helper.GetCurrentDate,
                                //            ModifiedDate = Helper.GetCurrentDate,
                                //        });

                                //        lItem.FuturisticItemThresholdQties.Add(new FuturisticItemThresholdQty
                                //        {
                                //            ItemCode = mItemCreation.ItemCode,
                                //            OrgId = mItemCreation.OrgID,
                                //            BusinessTypeID = parameter.BusinessTypeID,
                                //            CreatedByID = this.mItemCreation.CreatedByID,
                                //            ModifiedByID = this.mItemCreation.CreatedByID,
                                //            MaxQty = parameter.MaxQty,
                                //            MinQty = parameter.MinQty,
                                //            MaxQtyAfterPeriod = parameter.MaxQty,
                                //            MinQtyAfterPeriod = parameter.MinQty,
                                //            CreatedDate = Helper.GetCurrentDate,
                                //            ModifiedDate = Helper.GetCurrentDate,
                                //            FrmEffectiveDate = Helper.GetCurrentDate.Date,
                                //            FrmEffectiveTime = Helper.Get12hrtimeFormate(DateTime.Now),
                                //            ToEffectiveDate = Helper.GetCurrentDate.AddDays(30).Date,
                                //            ToEffectiveTime = Helper.Get12hrtimeFormate(DateTime.Now),
                                //        });
                                //    }
                                //}
                                //#endregion

                                Entities.tblItems.Add(lItem);

                                DLItemMapping.SaveData(mItemCreation, Entities);

                                Entities.SaveChanges();
                                #endregion

                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                                mItemCreation.DisplayMessage = "Item Saved Successfully";
                                return mItemCreation;
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                //this.GetApplicationActivate.GetErrormessages = ex.Message;
                                //this.GetApplicationActivate.GetErrorSource = ex.Source;
                                //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                //throw;
                                mItemCreation.DisplayMessage = "Failed to save Item.. Please contact Administrator";
                                return mItemCreation;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                //this.GetApplicationActivate.GetErrormessages = ex.Message;
                //this.GetApplicationActivate.GetErrorSource = ex.Source;
                //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                //throw;
                mItemCreation.DisplayMessage = "Failed to save Item.. Please contact Administrator";
                return mItemCreation;
            }
            //return mItemCreation;
        }
        public List<DLItemCreation> GetItems(string SearchValue, string OrgID)
        {
            lstItemCreation = new List<DLItemCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    //lstItemCreation = (List<DLItemCreation>)DLItemMapping.GetItemDetails();

                    lstItemCreation = (from gItems in Entities.tblItems.AsNoTracking().Where(e => e.IsActive == true)
                                       where gItems.OrgID == OrgID
                                       orderby gItems.ItemName
                                       select new DLItemCreation  //gCategories;
                                       {
                                           ID = gItems.ID,
                                           ItemName = gItems.ItemName,
                                           ItemCode = gItems.ItemCode,
                                           ItemAlias = gItems.Alias,
                                           OrgID = gItems.OrgID,
                                           RateID = gItems.RateID,
                                           BaseUnit = gItems.BaseUnit,
                                           BasePKTValue = gItems.BasePKTValue,
                                           AlternateUnit = gItems.AlternateUnit,
                                           AlternatePKTValue = gItems.AlternatePKTValue,
                                           PacketUOMID = gItems.PacketUOMID,
                                           PacketQTY = gItems.PacketQTY,
                                           BagUOMID = gItems.BagUOMID,
                                           BagQTY = gItems.BagQTY,
                                           IsTallyUpdated = gItems.IsTallyUpdated,
                                           IsParentTallyUpdated = gItems.IsParentTallyUpdated,
                                           IsCESSMapped = gItems.IsCESSMapped,
                                           CESSValue = gItems.CESSValue,
                                           CESSEffectiveDate = gItems.CESSEffectiveDate,
                                           BrandID = gItems.BrandID,
                                           CategoryID = gItems.CategoryID,
                                           SubCategoryID = gItems.SubCategoryID,
                                           RackID = gItems.RackID,
                                           ItemDetail = gItems.ItemDetail,
                                           StorageSpace = gItems.StorageArea,
                                           GST = gItems.GST,
                                           GSTEffectiveDate = gItems.GSTEffectiveDate,
                                           ReOrderlevel = gItems.ReOrderlevel,
                                           ReOrderQTY = gItems.ReOrderQTY,
                                           IsReturnable = gItems.IsReturnable,
                                           IsActive = gItems.IsActive,
                                           DaysToRefill = gItems.DaysToRefill,
                                           HSNCode = gItems.HSNCode,
                                           HSNSubCode = gItems.HSNSubCode,
                                           CreatedByID = gItems.CreatedByID,
                                           CreatedDate = gItems.CreatedDate,
                                           ModifiedByID = gItems.ModifiedByID,
                                           ModifiedDate = gItems.ModifiedDate


                                       }).ToList();
                }

                if (SearchValue != "" && !string.IsNullOrEmpty(SearchValue))
                    lstItemCreation = lstItemCreation.Where(c => (c.ItemCode.ToLower().Trim().StartsWith(SearchValue.ToLower().Trim())) && c.OrgID == OrgID).ToList();


                #region delete code
                //using (Entities = new WBT.Entity.MWBTechnologyEntities())
                //{
                //    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                //        Entities.Database.Connection.Open();                        //to open the connection if closed

                //    #region New code refactor
                //    lstItemCreation = (from drow in Entities.Items.AsNoTracking()
                //                       select new DLItemCreation()
                //                       {
                //                           ID = drow.ID,
                //                           ItemCode = drow.ItemCode,
                //                           ItemName = drow.ItemName.Trim(),
                //                           ItemDetail = drow.ItemDetail.Trim(),
                //                           HSNCode = drow.HSNCode,
                //                           HSNSubCode = drow.HSNSubCode,
                //                           GST = drow.GST,
                //                           IsReturnable = drow.IsReturnable ?? null,
                //                           IsTrademarkRegistered = drow.IsTrademarkRegistered,
                //                           ReOrderlevel = drow.ReOrderlevel,
                //                           ReOrderQTY = drow.ReOrderQTY,
                //                           CategoryID = drow.CategoryID,
                //                           CategoryName = drow.tblCategory.CategoryName,
                //                           SubCategoryID = drow.SubCategoryID,
                //                           SubCategoryName = drow.tblSubCategory.SubCategoryName,
                //                           RackID = drow.RackID != null ? drow.RackID : 0,
                //                           PacketQTY = drow.PacketQTY,
                //                           PacketUOMID = drow.PacketUOMID,
                //                           BagQTY = drow.BagQTY,
                //                           BagUOMID = drow.BagUOMID,
                //                           IsItemBlocked = drow.IsItemBlocked,
                //                           ItemCompanyID = drow.tblBrand.ItemCompanyID,
                //                           BrandID = drow.BrandID,
                //                           IsActive = drow.IsActive,
                //                           ItemAlias = drow.Alias.Trim(),
                //                           Remark = string.Empty,
                //                           GSTEffectiveDate = drow.GSTEffectiveDate,
                //                           DestinationItemCode = drow.ItemCode,
                //                           DestinationItemName = drow.ItemName,
                //                           BaseUnit = drow.BaseUnit,
                //                           //if (drow.BaseUnit != null)
                //                           BaseUnitName = drow.BaseUnit != null ? (from e in Entities.UOMs
                //                                                                   where e.UnitID == drow.BaseUnit
                //                                                                   select e).FirstOrDefault().Unit : "",
                //                           BasePKTValue = drow.BasePKTValue,
                //                           AlternateUnit = drow.AlternateUnit,
                //                           //if (drow.AlternateUnit != null)
                //                           AlternateUnitName = drow.AlternateUnit != null ? Entities.UOMs.Where(i => i.UnitID == drow.AlternateUnit).FirstOrDefault().Unit : "",
                //                           AlternatePKTValue = drow.AlternatePKTValue,

                //                           #region Added For Tally
                //                           PacketUOM = drow.tblUOM1 != null ? drow.tblUOM1.Unit : "",
                //                           BagUOM = drow.tblUOM != null ? drow.tblUOM.Unit : "",
                //                           #endregion

                //                           StorageSpace = drow.StorageArea == null ? "" : drow.StorageArea.Trim(),
                //                           sIsActive = drow.IsActive == true ? "Yes" : "No",
                //                           IsTallyUpdated = drow.IsTallyUpdated.Value,
                //                           stringIsTallyUpdated = drow.IsTallyUpdated == false ? "No" : "Yes",
                //                           RateID = drow.RateID,
                //                           IsCESSMapped = drow.IsCESSMapped,
                //                           CESSValue = drow.CESSValue,
                //                           CESSEffectiveDate = drow.CESSEffectiveDate,
                //                           DaysToRefill = drow.DaysToRefill,
                //                           OrgID = drow.OrgID,
                //                           IsParentTallyUpdated = drow.IsParentTallyUpdated ?? false,
                //                           stringIsParentTallyUpdated = drow.IsParentTallyUpdated == false ? "No" : "Yes",

                //                           #region Item rate Details

                //                           DLItemRateCreation = drow.tblItemRate != null ?
                //                            new DLItemRateCreation()
                //                            {
                //                                RateID = drow.tblItemRate.RateID,
                //                                BaseRateOther = drow.tblItemRate.BaseRateOther,
                //                                PerUnitRate = drow.tblItemRate.PerUnitRate,
                //                            } : null,

                //                           #endregion

                //                           #region adding types of bussines value required to edit //sneha 3rd Sep 2020
                //                           dLBussinessTypesLists = drow.ItemThresholdQtyDetails.Select(a => new DLItemThresholdQtyCreation()
                //                           {
                //                               BusinessTypeID = a.BusinessTypeID != null ? a.BusinessTypeID.Value : 0,
                //                               BusinessTypeName = a.BusinessType.BusinessTypeName.Trim(),
                //                               MinQty = a.MinQty != null ? a.MinQty.Value : 1,
                //                               MaxQty = a.MaxQty != null ? a.MaxQty.Value : 1,
                //                               OrgId = a.OrgId,
                //                           }).ToList<DLItemThresholdQtyCreation>(),


                //                           #endregion
                //                       }).OrderBy(i => i.CategoryName).ToList();

                //    #endregion

                //    #region old code refactor 3rd sep 2020  by sneha
                //    //var result = (from gItems in Entities.Items.AsNoTracking()
                //    //              orderby gItems.ItemName
                //    //              select gItems);

                //    //foreach (var drow in result)
                //    //{
                //    //    mItemCreation = new DLItemCreation();
                //    //    mItemCreation.ID = drow.ID;
                //    //    mItemCreation.ItemCode = drow.ItemCode;
                //    //    mItemCreation.ItemName = drow.ItemName.Trim();
                //    //    mItemCreation.ItemDetail = drow.ItemDetail.Trim();
                //    //    // mItemCreation.HSNID = drow.HSNID != null ? drow.HSNID : (int?)null;
                //    //    mItemCreation.HSNCode = drow.HSNCode; //drow.tblHSNCode != null ? drow.tblHSNCode.HSNCode.ToString() : string.Empty;
                //    //    mItemCreation.HSNSubCode = drow.HSNSubCode;//drow.tblHSNCode != null ? drow.tblHSNCode.HSNSubCode.ToString() : string.Empty;
                //    //    mItemCreation.GST = drow.GST; //drow.tblHSNCode != null ? drow.tblHSNCode.GST : 0;
                //    //    mItemCreation.IsReturnable = drow.IsReturnable ?? null;
                //    //    mItemCreation.IsTrademarkRegistered = drow.IsTrademarkRegistered;// (drow.tblHSNCode != null && drow.tblHSNCode.IsTrademarkRegistered != null) ? drow.tblHSNCode.IsTrademarkRegistered : (bool?)null;
                //    //    mItemCreation.ReOrderlevel = drow.ReOrderlevel;
                //    //    mItemCreation.ReOrderQTY = drow.ReOrderQTY;
                //    //    mItemCreation.CategoryID = drow.CategoryID;
                //    //    mItemCreation.CategoryName = drow.tblCategory.CategoryName;
                //    //    mItemCreation.SubCategoryID = drow.SubCategoryID;
                //    //    mItemCreation.SubCategoryName = drow.tblSubCategory.SubCategoryName;
                //    //    mItemCreation.RackID = drow.RackID != null ? drow.RackID : 0;
                //    //    mItemCreation.PacketQTY = drow.PacketQTY;
                //    //    mItemCreation.PacketUOMID = drow.PacketUOMID;
                //    //    mItemCreation.BagQTY = drow.BagQTY;
                //    //    mItemCreation.BagUOMID = drow.BagUOMID;
                //    //    mItemCreation.IsItemBlocked = drow.IsItemBlocked;
                //    //    mItemCreation.ItemCompanyID = drow.tblBrand.ItemCompanyID;
                //    //    mItemCreation.BrandID = drow.BrandID;
                //    //    mItemCreation.IsActive = drow.IsActive;
                //    //    mItemCreation.ItemAlias = drow.Alias.Trim();
                //    //    mItemCreation.Remark = string.Empty;
                //    //    mItemCreation.GSTEffectiveDate = drow.GSTEffectiveDate;
                //    //    mItemCreation.DestinationItemCode = drow.ItemCode;
                //    //    mItemCreation.DestinationItemName = drow.ItemName;

                //    //    mItemCreation.BaseUnit = drow.BaseUnit;
                //    //    if (drow.BaseUnit != null)
                //    //        mItemCreation.BaseUnitName = (from e in Entities.UOMs.AsNoTracking()
                //    //                                      where e.UnitID == drow.BaseUnit
                //    //                                      select e).FirstOrDefault().Unit;
                //    //    mItemCreation.BasePKTValue = drow.BasePKTValue;
                //    //    mItemCreation.AlternateUnit = drow.AlternateUnit;
                //    //    if (drow.AlternateUnit != null)
                //    //        mItemCreation.AlternateUnitName = Entities.UOMs.AsNoTracking().Where(i => i.UnitID == drow.BaseUnit).FirstOrDefault().Unit;
                //    //    mItemCreation.AlternatePKTValue = drow.AlternatePKTValue;

                //    //    #region Added For Tally
                //    //    mItemCreation.CategoryName = drow.tblCategory.CategoryName;
                //    //    mItemCreation.PacketUOM = drow.tblUOM1 != null ? drow.tblUOM1.Unit : "";
                //    //    mItemCreation.BagUOM = drow.tblUOM != null ? drow.tblUOM.Unit : "";
                //    //    #endregion

                //    //    mItemCreation.StorageSpace = drow.StorageArea == null ? "" : drow.StorageArea.Trim();
                //    //    if (mItemCreation.IsActive == true)
                //    //    {
                //    //        mItemCreation.sIsActive = "Yes";
                //    //    }
                //    //    else
                //    //    {
                //    //        mItemCreation.sIsActive = "No";
                //    //    }
                //    //    mItemCreation.IsTallyUpdated = drow.IsTallyUpdated.Value;
                //    //    if (drow.IsTallyUpdated == false)
                //    //    {
                //    //        mItemCreation.stringIsTallyUpdated = "No";
                //    //    }
                //    //    else
                //    //    {
                //    //        mItemCreation.stringIsTallyUpdated = "Yes";
                //    //    }
                //    //    mItemCreation.RateID = drow.RateID;
                //    //    mItemCreation.IsCESSMapped = drow.IsCESSMapped;
                //    //    mItemCreation.CESSValue = drow.CESSValue;
                //    //    mItemCreation.CESSEffectiveDate = drow.CESSEffectiveDate;
                //    //    mItemCreation.DaysToRefill = drow.DaysToRefill;
                //    //    mItemCreation.OrgID = drow.OrgID;
                //    //    mItemCreation.IsParentTallyUpdated = drow.IsParentTallyUpdated ?? false;
                //    //    if (mItemCreation.IsParentTallyUpdated == false)
                //    //        mItemCreation.stringIsParentTallyUpdated = "No";
                //    //    else
                //    //        mItemCreation.stringIsParentTallyUpdated = "Yes";

                //    //    #region Item rate Details

                //    //    if (drow.tblItemRate != null)
                //    //    {
                //    //        mItemCreation.DLItemRateCreation = new DLItemRateCreation()
                //    //        {
                //    //            RateID = drow.tblItemRate.RateID,
                //    //            BaseRateOther = drow.tblItemRate.BaseRateOther,
                //    //            PerUnitRate = drow.tblItemRate.PerUnitRate,
                //    //        };
                //    //    }

                //    //    #endregion

                //    //    #region adding types of bussines value required to edit //sneha 17th AUg 2020
                //    //    if (drow.ItemThresholdQtyDetails != null && drow.ItemThresholdQtyDetails.Count > 0)
                //    //    {
                //    //        mItemCreation.dLBussinessTypesLists = new List<DLItemThresholdQtyCreation>();
                //    //        foreach (var item in drow.ItemThresholdQtyDetails)
                //    //        {
                //    //            DLItemThresholdQtyCreation dLItemThresholdQtyCreation = new DLItemThresholdQtyCreation();
                //    //            dLItemThresholdQtyCreation.BusinessTypeID = item.BusinessTypeID;
                //    //            dLItemThresholdQtyCreation.BusinessTypeName = item.BusinessType.BusinessTypeName;
                //    //            dLItemThresholdQtyCreation.MinQty = item.MinQty;
                //    //            dLItemThresholdQtyCreation.MaxQty = item.MaxQty;
                //    //            dLItemThresholdQtyCreation.OrgId = item.OrgId;
                //    //            mItemCreation.dLBussinessTypesLists.Add(dLItemThresholdQtyCreation);
                //    //        }

                //    //    }
                //    //    #endregion

                //    //    lstItemCreation.Add(mItemCreation);
                //    //}

                //    #endregion

                //    // is Item for prcess

                #endregion
                //if (SearchValue != "Tally" && SearchValue != "Parent Tally" && !string.IsNullOrEmpty(SearchValue))
                //    lstItemCreation = lstItemCreation.Where(c => (c.ItemName.ToLower().Trim().StartsWith(SearchValue.ToLower().Trim())
                //   || c.ItemCode == SearchValue.ToLower().Trim()) && c.OrgID == OrgID).ToList();

                //if (SearchValue == "Tally")
                //    lstItemCreation = lstItemCreation.Where(t => t.IsTallyUpdated == false).ToList();

                //if (SearchValue == "Parent Tally")
                //    lstItemCreation = lstItemCreation.Where(t => t.IsParentTallyUpdated == false).ToList();

                return lstItemCreation;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
        public DLItemCreation GetItemsDetail(string SearchValue, string OrgID)
        {
            DLItemCreation itemDetails = new DLItemCreation();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();


                    itemDetails = (from gItems in Entities.tblItems.AsNoTracking().Where(e => e.IsActive == true)
                                   where gItems.OrgID == OrgID && gItems.ItemCode == SearchValue
                                   orderby gItems.ItemName
                                   select new DLItemCreation  //gCategories;
                                   {
                                       ID = gItems.ID,
                                       ItemName = gItems.ItemName,
                                       ItemCode = gItems.ItemCode,
                                       ItemAlias = gItems.Alias,
                                       OrgID = gItems.OrgID,
                                       RateID = gItems.RateID,
                                       BaseUnit = gItems.BaseUnit,
                                       BaseRateOther = gItems.tblItemRate.BaseRateOther == null ? 0 : gItems.tblItemRate.BaseRateOther.Value,
                                       BasePKTValue = gItems.BasePKTValue,
                                       AlternateUnit = gItems.AlternateUnit,
                                       AlternatePKTValue = gItems.AlternatePKTValue,
                                       PacketUOMID = gItems.PacketUOMID,
                                       PacketQTY = gItems.PacketQTY,
                                       BagUOMID = gItems.BagUOMID,
                                       BagQTY = gItems.BagQTY,
                                       IsTallyUpdated = gItems.IsTallyUpdated,
                                       IsParentTallyUpdated = gItems.IsParentTallyUpdated,
                                       IsCESSMapped = gItems.IsCESSMapped,
                                       CESSValue = gItems.CESSValue,
                                       CESSEffectiveDate = gItems.CESSEffectiveDate,
                                       BrandID = gItems.BrandID,
                                       CategoryID = gItems.CategoryID,
                                       SubCategoryID = gItems.SubCategoryID,
                                       RackID = gItems.RackID,
                                       ItemDetail = gItems.ItemDetail,
                                       StorageSpace = gItems.StorageArea,
                                       GST = gItems.tblItemMappings.Where(mp => mp.ItemCode == gItems.ItemCode).FirstOrDefault().GST.Value,
                                       GSTEffectiveDate = gItems.tblItemMappings.Where(mp => mp.ItemCode == gItems.ItemCode).FirstOrDefault().GSTEffectiveDate,
                                       ReOrderlevel = gItems.ReOrderlevel,
                                       ReOrderQTY = gItems.ReOrderQTY,
                                       IsReturnable = gItems.IsReturnable,
                                       IsActive = gItems.IsActive,
                                       DaysToRefill = gItems.DaysToRefill,
                                       HSNCode = gItems.HSNCode,
                                       HSNSubCode = gItems.HSNSubCode,
                                       CreatedByID = gItems.CreatedByID,
                                       CreatedDate = gItems.CreatedDate,
                                       ModifiedByID = gItems.ModifiedByID,
                                       ModifiedDate = gItems.ModifiedDate,
                                       ItemCompanyID = gItems.tblBrand.ItemCompanyID,
                                   }).FirstOrDefault();
                }

                return itemDetails;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.SystemError;
                this.GetApplicationActivate.GetErrormessages = sqlex.Message;
                this.GetApplicationActivate.GetErrorSource = sqlex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = sqlex.StackTrace;
                throw;
            }
            catch (Exception ex)
            {
                this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                this.GetApplicationActivate.GetErrormessages = ex.Message;
                this.GetApplicationActivate.GetErrorSource = ex.Source;
                this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                throw;
            }
        }
        public DLItemCreation UpdateItem(DLItemCreation dlitemcreations, int UserID1, string OrgID)
        {
            mItemCreation = ((DLItemCreation)dlitemcreations);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    lItem = (from gItems in Entities.tblItems.AsNoTracking()
                             where gItems.ItemCode == mItemCreation.ItemCode
                             select gItems).FirstOrDefault();

                    if (lItem != null)
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                lItem.OldItemName = this.mItemCreation.OldItemName;
                                lItem.IsActive = this.mItemCreation.IsActive;
                                lItem.ItemName = this.mItemCreation.ItemName;
                                lItem.Alias = this.mItemCreation.ItemAlias;
                                lItem.IsReturnable = this.mItemCreation.IsReturnable;
                                lItem.RackID = this.mItemCreation.RackID;
                                lItem.ItemDetail = this.mItemCreation.ItemDetail;
                                lItem.StorageArea = this.mItemCreation.StorageSpace;
                                lItem.IsTrademarkRegistered = this.mItemCreation.IsTrademarkRegistered;
                                lItem.IsCESSMapped = mItemCreation.IsCESSMapped;
                                lItem.ReOrderlevel = mItemCreation.ReOrderlevel;
                                lItem.ReOrderQTY = mItemCreation.ReOrderQTY;
                                lItem.IsItemBlocked = mItemCreation.IsItemBlocked;
                                lItem.ModifiedDate = mItemCreation.CreatedDate;
                                lItem.ModifiedByID = mItemCreation.ModifiedByID;
                                lItem.SourceOfUpdate = mItemCreation.SourceOfUpdate;
                                lItem.DaysToRefill = mItemCreation.DaysToRefill;
                                #region CreateParameterMapping
                                if (mItemCreation.SelectedParameters != null && mItemCreation.SelectedParameters.Count > 0)
                                {
                                    #region  deleteExistingParameterMapping
                                    var itemParameterListMapFromDB = Entities.tblItemParameterMaps.Where(e => e.ItemCode == this.mItemCreation.ItemCode).ToList();

                                    if (itemParameterListMapFromDB != null && itemParameterListMapFromDB.Count > 0)
                                    {
                                        foreach (var parameterMap in itemParameterListMapFromDB)
                                        {
                                            Entities.Entry(parameterMap).State = EntityState.Deleted;
                                        }
                                    }
                                    #endregion

                                    lItem.tblItemParameterMaps = new List<tblItemParameterMap>();
                                    lItem.tblItemParameterMaps.Clear();
                                    foreach (DLParameterCreation parameter in mItemCreation.SelectedParameters)
                                    {
                                        NewMethod(parameter);
                                    }

                                }

                                #endregion

                                #region  assigned threshould qty added on 17th Aug 2020 
                                //Edit option for threshold has been given a new screen on 7th sep 2020
                                #endregion

                                Entities.tblItems.Add(lItem);
                                Entities.Entry(lItem).State = EntityState.Modified;
                                mItemCreation.RateID = lItem.RateID;
                                DLItemMapping.SaveData(mItemCreation, Entities);

                                Entities.SaveChanges();

                                #region 
                                if (mItemCreation.lstMappedOrganization != null)
                                {
                                    foreach (var item in mItemCreation.lstMappedOrganization)
                                    {

                                        List<tblItemMapping> itemMapping = (from im in Entities.tblItemMappings.AsNoTracking()
                                                                            where im.ItemCode == mItemCreation.ItemCode
                                                                            && im.OrgID == item.OrgID
                                                                            select im).ToList();

                                        itemMapping.ForEach(i => i.IsTallyUpdated = false);
                                        itemMapping.ForEach(a => Entities.tblItemMappings.Add(a));
                                        itemMapping.ForEach(p => Entities.Entry(p).State = EntityState.Modified);
                                        Entities.SaveChanges();
                                    }

                                }
                                #endregion

                                dbcxtransaction.Commit();
                                this.GetApplicationActivate.DataState = Common.TransactionType.Success;
                                mItemCreation.DisplayMessage = "Item Updated Successfully";
                                return mItemCreation;
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                //this.GetApplicationActivate.DataState = Common.TransactionType.Error;
                                //this.GetApplicationActivate.GetErrormessages = ex.Message;
                                //this.GetApplicationActivate.GetErrorSource = ex.Source;
                                //this.GetApplicationActivate.GetErrorStackTrace = ex.StackTrace;
                                //throw;
                                mItemCreation.DisplayMessage = "Failed.. Please Contact Administrator";
                                return mItemCreation;
                            }

                        }
                        //}

                    }
                    else
                    {
                        mItemCreation.DisplayMessage = "Failed.. Please Contact Administrator";
                        return mItemCreation;
                    }
                }
            }
            catch (Exception ex)
            {
                mItemCreation.DisplayMessage = "Failed.. Please Contact Administrator";
                return mItemCreation;
            }
            //return mItemCreation;
        }

        private void NewMethod(DLParameterCreation parameter)
        {
            lItem.tblItemParameterMaps.Add(new tblItemParameterMap
            {
                ItemCode = this.mItemCreation.ItemCode,
                ParameterID = parameter.ParameterID,
                CreatedByID = this.mItemCreation.CreatedByID,
                ModifiedByID = this.mItemCreation.CreatedByID,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsActive = true
            });
        }

        public string ConstructingUOMPacketNumber(decimal packetQTY, string packetUnit, decimal bagQTY, string bagUnit) //unitid, int bulkunit)
        {
            if (packetQTY != 0 && bagQTY != 0)
            {

                string ConcatinatedName = string.Empty;
                string BulkUnitQTY = bagQTY + bagUnit;
                string packetUnitQTY = packetQTY + packetUnit;

                int unitValue = UnitCalculation(packetUnitQTY, BulkUnitQTY);
                if (unitValue > 0)
                {
                    if ((packetUnit.ToLower().Contains("pcs") || packetUnit.ToLower().Contains("ltr")) && bagUnit.ToLower().Contains("box"))
                        ConcatinatedName = " [ " + packetUnitQTY + " X " + BulkUnitQTY + " ] " + packetQTY + "Units";
                    else if (packetUnit.ToLower().Contains("ltr") && bagUnit.ToLower().Contains("tin"))
                        ConcatinatedName = " [ " + packetUnitQTY + " X " + BulkUnitQTY + " ] " + "1 Unit";
                    else
                        ConcatinatedName = " [ " + packetUnitQTY + " X " + unitValue + "Units" + " ]" + BulkUnitQTY;
                    return ConcatinatedName;
                }
                else
                {
                    return ConcatinatedName = null;
                }
            }
            else
                return null;
        }
        public int UnitCalculation(string packetUnitQTY, string bulkunit)
        {
            try
            {
                int unit = 0;
                //not used bcz tally does not allow
                if (packetUnitQTY.ToLower().Contains("kg") && bulkunit.ToLower().Contains("kg"))
                {
                    bulkunit = bulkunit.ToLower().Replace("kg", "");
                    packetUnitQTY = packetUnitQTY.ToLower().Replace("kg", "");
                    unit = Convert.ToInt32(bulkunit) / Convert.ToInt32(packetUnitQTY.ToString());
                }
                else if (packetUnitQTY.ToLower().Contains("ltr") && bulkunit.ToLower().Contains("ltr"))
                {
                    packetUnitQTY = packetUnitQTY.ToLower().Replace("ltr", "");
                    bulkunit = bulkunit.ToLower().Replace("ltr", "");
                    unit = Convert.ToInt32(bulkunit) * Convert.ToInt32(packetUnitQTY.ToString());
                }
                else if (packetUnitQTY.ToLower().Contains("pcs") && bulkunit.ToLower().Contains("pcs"))
                {
                    bulkunit = bulkunit.ToLower().Replace("pcs", "");
                    packetUnitQTY = packetUnitQTY.ToLower().Replace("pcs", "");
                    unit = Convert.ToInt32(bulkunit) / Convert.ToInt32(packetUnitQTY.ToString());
                }

                if (packetUnitQTY.ToLower().Contains("gms") && bulkunit.ToLower().Contains("kg"))
                {
                    bulkunit = bulkunit.ToLower().Replace("kg", "");
                    packetUnitQTY = packetUnitQTY.ToLower().Replace("gms", "");
                    unit = Convert.ToInt32(bulkunit) * 1000 / Convert.ToInt32(packetUnitQTY.ToString());
                }
                else if (packetUnitQTY.ToLower().Contains("pcs") && bulkunit.ToLower().Contains("box"))
                {
                    packetUnitQTY = packetUnitQTY.ToLower().Replace("pcs", "");
                    bulkunit = bulkunit.ToLower().Replace("box", "");
                    unit = Convert.ToInt32(bulkunit) * Convert.ToInt32(packetUnitQTY.ToString());
                }
                else if (packetUnitQTY.ToLower().Contains("ltr") && bulkunit.ToLower().Contains("box"))
                {
                    bulkunit = bulkunit.ToLower().Replace("box", "");
                    packetUnitQTY = packetUnitQTY.ToLower().Replace("ltr", "");
                    unit = Convert.ToInt32(bulkunit) * Convert.ToInt32(packetUnitQTY.ToString());
                }
                else if (packetUnitQTY.ToLower().Contains("ltr") && bulkunit.ToLower().Contains("tin"))
                {
                    bulkunit = bulkunit.ToLower().Replace("tin", "");
                    packetUnitQTY = packetUnitQTY.ToLower().Replace("ltr", "");
                    unit = Convert.ToInt32(bulkunit) * Convert.ToInt32(packetUnitQTY.ToString());
                }
                else
                {

                }
                return unit;
            }
            catch (Exception ex)
            {
                //Helper.LogError(ex.Message, ex.Source, ex.StackTrace);
                return 0;
            }

        }
        public List<ItemDTO> ImportExcel(List<ItemDTO> itemExcelData, string userID, string orgID)
        {
            string itemCode = string.Empty;
            List<ItemDTO> Result = new List<ItemDTO>();
            DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            try
            {
                if (itemExcelData != null)
                {
                    foreach (var item in itemExcelData)
                    {
                        using (Entities = new MWBTCustomerAppEntities())
                        {
                            if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                                Entities.Database.Connection.Open();

                            var items = Entities.tblItems.AsNoTracking().Where(d => d.OrgID == orgID);

                            if (!string.IsNullOrEmpty(item.ItemName))
                            {
                                tblItem IsValueexists = null;
                                if (!string.IsNullOrEmpty(item.ItemName))
                                {
                                    IsValueexists = Entities.tblItems.AsNoTracking().Where(C => C.ItemName.ToLower() == item.ItemName.ToLower() && C.OrgID == orgID).FirstOrDefault();
                                    if (IsValueexists != null)
                                        itemCode = IsValueexists.ItemCode;
                                }

                                using (var dbcxtransaction = Entities.Database.BeginTransaction())
                                {
                                    ItemDTO ResultItem = new ItemDTO();
                                    var tblitem = new tblItem();
                                    try
                                    {
                                        if (!string.IsNullOrEmpty(itemCode))
                                            item.ItemCode = itemCode;

                                        var AliasExists = (from gItems in items
                                                           where gItems.Alias.ToLower().Trim() == item.Alias.ToLower().Trim()
                                                           && gItems.OrgID == orgID
                                                           select gItems.ItemName).ToList();
                                        if (AliasExists != null && AliasExists.Count() > 0)
                                        {
                                            ResultItem.ItemName = item.ItemName;
                                            ResultItem.Status = "Alias Name already exists";
                                            Result.Add(ResultItem);
                                        }
                                        else
                                        {
                                            var IsItemCodeExist = (from gItems in items
                                                                   where gItems.ItemCode == item.ItemCode
                                                                   select gItems.ItemName).ToList();

                                            tblitem.ItemCode = item.ItemCode;
                                            if (IsItemCodeExist != null && IsItemCodeExist.Count() > 0)
                                            {
                                                tblitem.ItemCode = (Convert.ToInt64(item.ItemCode) + 1).ToString();
                                            }

                                            tblitem.ItemName = item.ItemName.Trim();
                                            tblitem.OrgID = orgID;
                                            tblitem.Alias = item.Alias;
                                            tblitem.StorageArea = null;
                                            tblitem.IsTallyUpdated = false;
                                            tblitem.IsParentTallyUpdated = false;
                                            tblitem.TallyItemName = item.TallyItemName.Trim();
                                            tblitem.CategoryID = InsertCategory(item, userID, orgID, Entities);
                                            item.CategoryID = tblitem.CategoryID;
                                            tblitem.SubCategoryID = InsertSubCategory(item, userID, orgID, Entities);
                                            tblitem.BrandID = InsertBrand(item, userID, orgID, Entities);
                                            var bUItem = InsertBasicAltUnits(item, userID, orgID, Entities);
                                            tblitem.BasePKTValue = bUItem.BasePKTValue;
                                            tblitem.BaseUnit = bUItem.BaseUnit;
                                            tblitem.AlternateUnit = bUItem.AlternateUnit;
                                            tblitem.AlternatePKTValue = bUItem.AlternatePKTValue;
                                            tblitem.RateID = InsertRate(item, userID, orgID, Entities);
                                            var bagItem = InsertPacketUnits(item, userID, orgID, Entities);
                                            tblitem.PacketUOMID = bagItem.PacketUOMID;
                                            tblitem.BagUOMID = bagItem.BagUOMID;
                                            tblitem.PacketQTY = bagItem.PacketQTY;
                                            tblitem.BagQTY = bagItem.BagQTY;
                                            tblitem.RackID = null;
                                            tblitem.ItemDetail = item.ItemDescription;
                                            if (!string.IsNullOrEmpty(item.GST))
                                                tblitem.GST = Convert.ToDecimal(item.GST);
                                            else
                                                tblitem.GST = 0;
                                            if (!string.IsNullOrEmpty(item.APMCCESS))
                                            {
                                                tblitem.CESSValue = Convert.ToDecimal(item.APMCCESS);
                                                if (!string.IsNullOrEmpty(item.APMCCESSEffectiveDate))
                                                    tblitem.CESSEffectiveDate = Convert.ToDateTime(item.APMCCESSEffectiveDate);
                                                else
                                                    tblitem.CESSEffectiveDate = null;
                                                lItem.IsCESSMapped = true;
                                            }
                                            else
                                            {
                                                lItem.IsCESSMapped = false;
                                            }
                                            tblitem.CreatedDate = Helper.GetCurrentDate;
                                            tblitem.CreatedByID = Convert.ToInt32(userID);
                                            tblitem.isProcessItem = false;
                                            tblitem.SourceOfUpdate = "P";
                                            tblitem.HSNCode = !string.IsNullOrEmpty(item.CorrectedHSNCode) ? Convert.ToInt32(item.CorrectedHSNCode) : (int?)null;
                                            tblitem.HSNSubCode = !string.IsNullOrEmpty(item.SubHSNCode) ? Convert.ToInt32(item.SubHSNCode) : (int?)null;
                                            Entities.tblItems.Add(tblitem);
                                            Entities.SaveChanges();
                                            dbcxtransaction.Commit();
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        ResultItem.ItemName = item.ItemName;
                                        ResultItem.Status = ex.Message;
                                        Result.Add(ResultItem);
                                        dbcxtransaction.Rollback();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ItemDTO ResultItem = new ItemDTO();
                ResultItem.Status = ex.Message;
                Result.Add(ResultItem);
            }
            return Result;
        }
        private int InsertCategory(ItemDTO item, string userID, string orgID, MWBTCustomerAppEntities Entities)
        {
            try
            {
                var categoryID = 0;
                //using (Entities = new MWBTCustomerAppEntities())
                {
                    tblCategory dBCategory = (from gCategory in Entities.tblCategories.AsNoTracking()
                                              where gCategory.CategoryName.ToLower().Trim()
                                              == item.GroupName.ToLower().Trim()
                                              && gCategory.OrgID == orgID
                                              select gCategory).FirstOrDefault();

                    //Check If CategoryAlreadyExists
                    if (dBCategory != null)
                    {
                        categoryID = dBCategory.CategoryID;
                        return categoryID;
                    }
                    //Create New Category
                    else
                    {
                        tblCategory lCategory = new tblCategory();
                        lCategory.IsActive = true;
                        lCategory.CategoryName = item.GroupName;
                        lCategory.AccOrInv = true;
                        lCategory.CreatedDate = Helper.GetCurrentDate;
                        lCategory.ModifiedDate = Helper.GetCurrentDate;
                        lCategory.IsTallyUpdated = false;
                        lCategory.CreatedByID = Convert.ToInt32(userID);
                        lCategory.ParentCatId = (from gCategory in Entities.tblCategories.AsNoTracking()
                                                 where gCategory.CategoryName.ToLower().Trim()
                                                 == "primary"
                                                 select gCategory).Count() > 0 ? (from gCategory in Entities.tblCategories.AsNoTracking()
                                                                                  where gCategory.CategoryName.ToLower().Trim()
                                                                                  == "primary"
                                                                                  select gCategory).FirstOrDefault().CategoryID : (int?)null;
                        Entities.tblCategories.Add(lCategory);
                        Entities.SaveChanges();

                        categoryID = lCategory.CategoryID;
                        return categoryID;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return 0;
            }
        }
        private int InsertSubCategory(ItemDTO item, string userID, string orgID, MWBTCustomerAppEntities Entities)
        {
            try
            {
                var subCategoryID = 0;
                //using (Entities = new MWBTCustomerAppEntities())
                {
                    tblSubCategory dBSubCategory = (from gSubCategory in Entities.tblSubCategories.AsNoTracking()
                                                    where gSubCategory.SubCategoryName.ToLower().Trim()
                                                    == item.Category.ToLower().Trim()
                                                    && gSubCategory.OrgID == orgID
                                                    select gSubCategory).FirstOrDefault();

                    //Check If CategoryAlreadyExists
                    if (dBSubCategory != null)
                    {
                        subCategoryID = dBSubCategory.SubCategoryID;
                        return subCategoryID;
                    }
                    //Create New Category
                    else
                    {
                        tblSubCategory subCategory = new tblSubCategory();
                        subCategory.IsActive = true;
                        subCategory.SubCategoryName = item.Category;
                        subCategory.CategoryID = item.CategoryID.Value;
                        subCategory.CreatedDate = Helper.GetCurrentDate;
                        subCategory.ModifiedDate = Helper.GetCurrentDate;
                        subCategory.IsTallyUpdated = false;
                        subCategory.CreatedByID = Convert.ToInt32(userID);
                        Entities.tblSubCategories.Add(subCategory);
                        Entities.SaveChanges();
                        subCategoryID = subCategory.SubCategoryID;
                        return subCategoryID;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return 0;
            }
        }
        private int InsertBrand(ItemDTO item, string userID, string orgID, MWBTCustomerAppEntities Entities)
        {
            try
            {
                //using (Entities = new MWBTCustomerAppEntities())
                {
                    var brandID = 0;
                    tblItemCompany dBItemCompany = (from gItemCompany in Entities.tblItemCompanies.AsNoTracking()
                                                    where gItemCompany.CompanyName.ToLower().Trim()
                                                    == item.Company.ToLower().Trim()
                                                    select gItemCompany).FirstOrDefault();

                    ////Check the ItemCompany exists
                    if (dBItemCompany != null)
                    {
                        #region Brand
                        tblBrand DBBrand = (from gBrands in Entities.tblBrands.AsNoTracking()
                                            where gBrands.BrandName.ToLower().Trim() == item.Brand.ToLower().Trim()
                                            select gBrands).FirstOrDefault();
                        if (DBBrand != null)
                        {
                            brandID = DBBrand.BrandID;
                        }
                        else
                        {
                            tblBrand lBrand = new tblBrand();
                            lBrand.IsActive = true;
                            lBrand.BrandName = item.Brand;
                            lBrand.ItemCompanyID = dBItemCompany.ItemCompanyID;
                            lBrand.IsTrademarkRegistered = false;
                            lBrand.CreatedDate = Helper.GetCurrentDate;
                            lBrand.ModifiedDate = Helper.GetCurrentDate;
                            lBrand.CreatedByID = Convert.ToInt32(userID);
                            Entities.tblBrands.Add(lBrand);
                            Entities.SaveChanges();
                            brandID = lBrand.BrandID;
                        }
                        return brandID;
                        #endregion
                    }
                    //Create New Company
                    else
                    {
                        tblItemCompany lItemCompany = new tblItemCompany();
                        lItemCompany.CompanyName = item.Company;
                        lItemCompany.IsActive = true;
                        lItemCompany.CreatedDate = Helper.GetCurrentDate;
                        lItemCompany.ModifiedDate = Helper.GetCurrentDate;
                        lItemCompany.CreatedByID = Convert.ToInt32(userID);
                        Entities.tblItemCompanies.Add(lItemCompany);
                        Entities.SaveChanges();

                        tblBrand lBrand = new tblBrand();
                        lBrand.IsActive = true;
                        lBrand.BrandName = item.Brand;
                        lBrand.ItemCompanyID = lItemCompany.ItemCompanyID;
                        lBrand.IsTrademarkRegistered = false;
                        lBrand.CreatedDate = Helper.GetCurrentDate;
                        lBrand.ModifiedDate = Helper.GetCurrentDate;
                        lBrand.CreatedByID = Convert.ToInt32(userID);
                        Entities.tblBrands.Add(lBrand);
                        Entities.SaveChanges();
                        brandID = lBrand.BrandID;
                        return brandID;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return 0;
            }
        }
        private tblItem InsertBasicAltUnits(ItemDTO item, string userID, string orgID, MWBTCustomerAppEntities Entities)
        {
            try
            {
                //using (Entities = new MWBTCustomerAppEntities())
                {
                    lItem.BasePKTValue = Convert.ToDecimal(item.BasicUnitValue);
                    var uoms = Entities.tblUOMs;
                    var Basicunit = (from pUom in uoms
                                     where pUom.Unit.ToLower().Trim() == item.BasicUnit.ToLower().Trim()
                                     select pUom).FirstOrDefault();

                    if (Basicunit != null)
                    {
                        lItem.BaseUnit = Basicunit.UnitID;
                    }

                    if (!string.IsNullOrWhiteSpace(item.AlternateUnit))
                    {
                        var Alternateunit = (from pUom in uoms
                                             where pUom.Unit.ToLower().Trim() == item.AlternateUnit.ToLower().Trim()
                                             select pUom).FirstOrDefault();

                        if (Alternateunit != null)
                        {
                            lItem.AlternateUnit = Alternateunit.UnitID;
                        }
                        lItem.AlternatePKTValue = Convert.ToDecimal(item.AlternateUnitValue);
                    }
                    return lItem;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return lItem;
            }
        }
        private int InsertRate(ItemDTO item, string userID, string orgID, MWBTCustomerAppEntities Entities)
        {
            try
            {
                //using (Entities = new MWBTCustomerAppEntities())
                {
                    tblItemRate itemRate = new tblItemRate();
                    int raterowCount = 0;
                    var ItemsRates = Entities.tblItemRates.ToList();
                    if (ItemsRates != null && ItemsRates.Count() > 0)
                        raterowCount = Entities.tblItemRates.AsNoTracking().OrderByDescending(i => i.ID).FirstOrDefault().ID;
                    else
                        raterowCount = 0;

                    itemRate.RateID = raterowCount + 1;
                    itemRate.BaseRateOther = Convert.ToDecimal(item.Rate);
                    //added on 14thJun2021 by sneha
                    itemRate.PerUnitRate = lItem.BaseUnit;
                    itemRate.CreatedByID = Convert.ToInt32(userID);
                    itemRate.CreationDate = Helper.GetCurrentDate;
                    itemRate.UpdateDate = Helper.GetCurrentDate;

                    var rateExists = (from gRate in Entities.tblItemRates.AsNoTracking()
                                      where gRate.RateID == itemRate.RateID
                                      select gRate).ToList();

                    if (rateExists != null && rateExists.Count() > 0)
                    {
                        itemRate.RateID = itemRate.RateID + 1;
                    }
                    Entities.tblItemRates.Add(itemRate);
                    Entities.SaveChanges();
                    return itemRate.RateID;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return 0;
            }
        }
        private tblItem InsertPacketUnits(ItemDTO item, string userID, string orgID, MWBTCustomerAppEntities Entities)
        {
            try
            {
                //using (Entities = new MWBTCustomerAppEntities())
                {
                    var packetuom = (from pUom in Entities.tblUOMs.AsNoTracking()
                                     where pUom.Unit.ToLower().Trim() == item.PacketUnit.ToLower().Trim()
                                     select pUom).FirstOrDefault();

                    if (packetuom != null)
                    {
                        lItem.PacketUOMID = packetuom.UnitID;
                    }
                    var BagUOM = (from BUom in Entities.tblUOMs.AsNoTracking()
                                  where BUom.Unit.ToLower().Trim() == item.BagUnit.ToLower().Trim()
                                  select BUom).FirstOrDefault();

                    if (BagUOM != null)
                    {
                        lItem.BagUOMID = BagUOM.UnitID;
                    }

                    lItem.PacketQTY = Convert.ToDecimal(item.PacketSize);
                    lItem.BagQTY = Convert.ToDecimal(item.BagSize);
                    return lItem;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return lItem;
            }
        }
    }

    public class DLItemMapping //: Common.DLActivate
    {
        private static MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        public static DLItemCreation GetItemMapping { get; set; } = new DLItemCreation();
        public static List<DLItemCreation> GetListMappings { get; set; } = new List<DLItemCreation>();
        //save and edit of item mapping table
        public static object SaveData(DLItemCreation dLItemCreation, MWBTCustomerAppEntities Entities)
        {
            GetListMappings = new List<DLItemCreation>();
            tblItemMapping itemMapping = new tblItemMapping();
            bool IsRecordExistst = false;
            //using (Entities = new Entity.MWBTechnologyEntities())
            {
                itemMapping = new tblItemMapping();

                dLItemCreation.ItemMapID = Entities.tblItemMappings.Where(d => d.ItemCode == dLItemCreation.ItemCode && d.OrgID == dLItemCreation.OrgID && d.BranchID == dLItemCreation.BranchId).Count() > 0 ?
                 Entities.tblItemMappings.Where(d => d.ItemCode == dLItemCreation.ItemCode && d.OrgID == dLItemCreation.OrgID && d.BranchID == dLItemCreation.BranchId).FirstOrDefault().ItemMappingID : 0;

                if (dLItemCreation.ItemMapID == 0 || Entities.tblItemMappings.Where(d => d.ItemMappingID == dLItemCreation.ItemMapID).Count() == 0)
                {
                    itemMapping.ItemMappingID = Entities.tblItemMappings.OrderByDescending(i => i.ID).FirstOrDefault().ID + 1;
                    IsRecordExistst = false;
                }
                else
                {
                    itemMapping = Entities.tblItemMappings.Where(i => i.ItemMappingID == dLItemCreation.ItemMapID).FirstOrDefault();
                    IsRecordExistst = true;
                }

                itemMapping.RateID = dLItemCreation.RateID;
                itemMapping.BranchID = dLItemCreation.BranchId;
                itemMapping.COrgID = string.IsNullOrEmpty(dLItemCreation.COrgID) ? null : dLItemCreation.COrgID;
                itemMapping.ItemCode = dLItemCreation.ItemCode;
                itemMapping.OrgID = dLItemCreation.OrgID;
                itemMapping.IsActive = true;
                itemMapping.ReOrderlevel = dLItemCreation.ReOrderlevel;
                itemMapping.ReOrderQTY = dLItemCreation.ReOrderQTY;
                itemMapping.IsReturnable = dLItemCreation.IsReturnable;
                itemMapping.DaysToRefill = dLItemCreation.DaysToRefill;
                itemMapping.IsItemBlocked = dLItemCreation.IsItemBlocked;
                itemMapping.GST = dLItemCreation.GST;
                itemMapping.GSTEffectiveDate = dLItemCreation.GSTEffectiveDate;
                itemMapping.CESSValue = dLItemCreation.CESSValue;
                itemMapping.CESSEffectiveDate = dLItemCreation.CESSEffectiveDate;

                if (IsRecordExistst == true)
                {
                    itemMapping.ModifiedDate = dLItemCreation.CreatedDate;// Helper.GetCurrentDate;
                    itemMapping.ModifiedByID = dLItemCreation.CreatedByID;// Common.User.UserID;
                }
                else
                {
                    itemMapping.IsTallyUpdated = false;
                    itemMapping.CreatedDatetime = dLItemCreation.CreatedDate;// Helper.GetCurrentDate;
                    itemMapping.CreatedByID = dLItemCreation.CreatedByID;// Common.User.UserID;
                }
                Entities.tblItemMappings.Add(itemMapping);
                if (IsRecordExistst == true)
                {
                    Entities.Entry(itemMapping).State = System.Data.Entity.EntityState.Modified;
                }

                Entities.SaveChanges();
            }
            return GetListMappings;
        }
        public static object GetItemDetails(string OrgID, string BranchID, string ItemCode = "")
        {
            DLItemCreation GetListMappings = new DLItemCreation();

            using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
            {
                if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                    Entities.Database.Connection.Open();

                GetListMappings = (from drow in Entities.tblItems.AsNoTracking()
                                   join itemMap in Entities.tblItemMappings on drow.ItemCode equals itemMap.ItemCode
                                   where itemMap.OrgID == OrgID && itemMap.BranchID == BranchID && itemMap.ItemCode == ItemCode
                                   select new DLItemCreation
                                   {
                                       ID = drow.ID,
                                       ItemCode = drow.ItemCode,
                                       ItemName = drow.ItemName.Trim(),
                                       ItemDetail = drow.ItemDetail,
                                       HSNCode = drow.HSNCode,
                                       HSNSubCode = drow.HSNSubCode,
                                       IsTrademarkRegistered = drow.IsTrademarkRegistered,
                                       CategoryID = drow.CategoryID,
                                       CategoryName = drow.tblCategory.CategoryName,
                                       SubCategoryID = drow.SubCategoryID,
                                       SubCategoryName = drow.tblSubCategory.SubCategoryName,
                                       RackID = drow.RackID != null ? drow.RackID : 0,
                                       PacketQTY = drow.PacketQTY,
                                       PacketUOMID = drow.PacketUOMID,
                                       BagQTY = drow.BagQTY,
                                       BagUOMID = drow.BagUOMID,
                                       ItemCompanyID = drow.tblBrand.ItemCompanyID,
                                       BrandID = drow.BrandID,
                                       ItemAlias = drow.Alias.Trim(),
                                       Remark = string.Empty,
                                       DestinationItemCode = drow.ItemCode,
                                       DestinationItemName = drow.ItemName,
                                       BaseUnit = drow.BaseUnit,
                                       BaseUnitName = drow.BaseUnit != null ? (from e in Entities.tblUOMs
                                                                               where e.UnitID == drow.BaseUnit
                                                                               select e).FirstOrDefault().Unit : "",
                                       BasePKTValue = drow.BasePKTValue,
                                       AlternateUnit = drow.AlternateUnit,
                                       AlternateUnitName = drow.AlternateUnit != null ? Entities.tblUOMs.Where(i => i.UnitID == drow.AlternateUnit).FirstOrDefault().Unit : "",
                                       AlternatePKTValue = drow.AlternatePKTValue,

                                       #region Added For Tally
                                       PacketUOM = drow.tblUOM1 != null ? drow.tblUOM1.Unit : "",
                                       BagUOM = drow.tblUOM != null ? drow.tblUOM.Unit : "",
                                       #endregion

                                       StorageSpace = string.IsNullOrEmpty(drow.StorageArea) ? "" : drow.StorageArea.Trim(),
                                       stringIsTallyUpdated = drow.IsTallyUpdated == false ? "No" : "Yes",
                                       IsCESSMapped = drow.IsCESSMapped,
                                       IsParentTallyUpdated = drow.IsParentTallyUpdated ?? false,
                                       stringIsParentTallyUpdated = drow.IsParentTallyUpdated == false ? "No" : "Yes",
                                       IsProcessItemcheck = drow.isProcessItem == null ? false : drow.isProcessItem.Value,

                                       #region adding types of bussines value required to edit //sneha 3rd Sep 2020
                                       dLBussinessTypesLists = drow.ItemThresholdQtyDetails.Select(a => new DLItemThresholdQtyCreation()
                                       {
                                           BusinessTypeID = a.BusinessTypeID != null ? a.BusinessTypeID.Value : 0,
                                           BusinessTypeName = a.BusinessType.BusinessTypeName.Trim(),
                                           MinQty = a.MinQty != null ? a.MinQty.Value : 1,
                                           MaxQty = a.MaxQty != null ? a.MaxQty.Value : 1,
                                           OrgId = a.OrgId,
                                       }).ToList<DLItemThresholdQtyCreation>(),
                                       #endregion

                                       #region Item rate Details
                                       DLItemRateCreation = itemMap.tblItemRate != null ?
                                                        new DLItemRateCreation()
                                                        {
                                                            RateID = itemMap.tblItemRate.RateID,
                                                            BaseRateOther = itemMap.tblItemRate.BaseRateOther,
                                                            PerUnitRate = itemMap.tblItemRate.PerUnitRate,
                                                        } : null,
                                       #endregion

                                       GST = itemMap.GST ?? 0,
                                       IsActive = itemMap.IsActive,
                                       GSTEffectiveDate = itemMap.GSTEffectiveDate,
                                       CESSValue = itemMap.CESSValue,
                                       CESSEffectiveDate = itemMap.CESSEffectiveDate,
                                       sIsActive = itemMap.IsActive == true ? "Yes" : "No",
                                       IsTallyUpdated = itemMap.IsTallyUpdated ?? false,// drow.IsTallyUpdated.Value,
                                       COrgID = itemMap.COrgID,
                                       BranchId = itemMap.BranchID,
                                       OrgID = itemMap.OrgID,
                                       ItemMapID = itemMap.ItemMappingID,
                                       ReOrderlevel = itemMap.ReOrderlevel,
                                       ReOrderQTY = itemMap.ReOrderQTY,
                                       IsReturnable = itemMap.IsReturnable == null ? false : itemMap.IsReturnable,
                                       IsItemBlocked = itemMap.IsItemBlocked == null ? false : itemMap.IsItemBlocked,
                                       RateID = itemMap.RateID,
                                       DaysToRefill = itemMap.DaysToRefill,
                                       TallyUpdatedDate = itemMap.TallyUpdatedDate,
                                   }).FirstOrDefault();
            }
            return GetListMappings;
        }
        public static object GetItemDetails(string OrgID, string BranchID = "")
        {
            return ItemData(OrgID, BranchID);
        }
        public static object GetItemDetails(string OrgID)
        {
            return ItemData(OrgID);
        }
        public static object GetItemDetails()
        {
            return ItemData("", "", "", false);
        }
        private static object ItemData(string OrgID = "", string BranchID = "", string ItemCode = "", bool IsFilterRequired = true, bool IsActive = true)
        {
            GetListMappings = new List<DLItemCreation>();

            using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
            {
                if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                    Entities.Database.Connection.Open();

                GetListMappings = (from drow in Entities.tblItems.AsNoTracking()
                                   join itemMap in Entities.tblItemMappings on drow.ItemCode equals itemMap.ItemCode
                                   //where itemMap.IsActive == true // added on 20 jan 2021 by Devika
                                   select new DLItemCreation
                                   {
                                       OldItemName = drow.OldItemName,
                                       TallyItemName = drow.TallyItemName,
                                       ID = drow.ID,
                                       ItemCode = drow.ItemCode,
                                       ItemName = drow.ItemName.Trim(),
                                       ItemDetail = drow.ItemDetail,
                                       HSNCode = drow.HSNCode,
                                       HSNSubCode = drow.HSNSubCode,
                                       IsTrademarkRegistered = drow.IsTrademarkRegistered,
                                       CategoryID = drow.CategoryID,
                                       CategoryName = drow.tblCategory.CategoryName,
                                       SubCategoryID = drow.SubCategoryID,
                                       SubCategoryName = drow.tblSubCategory.SubCategoryName,
                                       RackID = drow.RackID != null ? drow.RackID : 0,
                                       PacketQTY = drow.PacketQTY,
                                       PacketUOMID = drow.PacketUOMID,
                                       BagQTY = drow.BagQTY,
                                       BagUOMID = drow.BagUOMID,
                                       ItemCompanyID = drow.tblBrand.ItemCompanyID,
                                       BrandID = drow.BrandID,
                                       ItemAlias = drow.Alias.Trim(),
                                       Remark = string.Empty,
                                       DestinationItemCode = drow.ItemCode,
                                       DestinationItemName = drow.ItemName,
                                       BaseUnit = drow.BaseUnit,
                                       BaseUnitName = drow.BaseUnit != null ? (from e in Entities.tblUOMs
                                                                               where e.UnitID == drow.BaseUnit
                                                                               select e).FirstOrDefault().Unit : "",
                                       BasePKTValue = drow.BasePKTValue,
                                       AlternateUnit = drow.AlternateUnit,
                                       AlternateUnitName = drow.AlternateUnit != null ? Entities.tblUOMs.Where(i => i.UnitID == drow.AlternateUnit).FirstOrDefault().Unit : "",
                                       AlternatePKTValue = drow.AlternatePKTValue,

                                       #region Added For Tally
                                       PacketUOM = drow.tblUOM1 != null ? drow.tblUOM1.Unit : "",
                                       BagUOM = drow.tblUOM != null ? drow.tblUOM.Unit : "",
                                       #endregion

                                       StorageSpace = string.IsNullOrEmpty(drow.StorageArea) ? "" : drow.StorageArea.Trim(),
                                       stringIsTallyUpdated = drow.IsTallyUpdated == false ? "No" : "Yes",
                                       IsCESSMapped = drow.IsCESSMapped,
                                       IsParentTallyUpdated = drow.IsParentTallyUpdated ?? false,
                                       stringIsParentTallyUpdated = drow.IsParentTallyUpdated == false ? "No" : "Yes",
                                       IsProcessItemcheck = drow.isProcessItem == null ? false : drow.isProcessItem.Value,

                                       #region adding types of bussines value required to edit //sneha 3rd Sep 2020
                                       dLBussinessTypesLists = drow.ItemThresholdQtyDetails.Select(a => new DLItemThresholdQtyCreation()
                                       {
                                           BusinessTypeID = a.BusinessTypeID != null ? a.BusinessTypeID.Value : 0,
                                           BusinessTypeName = a.BusinessType.BusinessTypeName.Trim(),
                                           MinQty = a.MinQty != null ? a.MinQty.Value : 1,
                                           MaxQty = a.MaxQty != null ? a.MaxQty.Value : 1,
                                           OrgId = a.OrgId,
                                       }).ToList<DLItemThresholdQtyCreation>(),
                                       #endregion

                                       #region Item rate Details
                                       DLItemRateCreation = itemMap.tblItemRate != null ?
                                                        new DLItemRateCreation()
                                                        {
                                                            RateID = itemMap.tblItemRate.RateID,
                                                            BaseRateOther = itemMap.tblItemRate.BaseRateOther,
                                                            PerUnitRate = itemMap.tblItemRate.PerUnitRate,
                                                        } : null,
                                       #endregion

                                       GST = itemMap.GST ?? 0,
                                       IsActive = itemMap.IsActive,
                                       GSTEffectiveDate = itemMap.GSTEffectiveDate,
                                       CESSValue = itemMap.CESSValue,
                                       CESSEffectiveDate = itemMap.CESSEffectiveDate,
                                       sIsActive = itemMap.IsActive == true ? "Yes" : "No",
                                       IsTallyUpdated = itemMap.IsTallyUpdated ?? false,// drow.IsTallyUpdated.Value,
                                       COrgID = itemMap.COrgID,
                                       BranchId = itemMap.BranchID,
                                       OrgID = itemMap.OrgID,
                                       ItemMapID = itemMap.ItemMappingID,
                                       ReOrderlevel = itemMap.ReOrderlevel,
                                       ReOrderQTY = itemMap.ReOrderQTY,
                                       IsReturnable = itemMap.IsReturnable == null ? false : itemMap.IsReturnable,
                                       IsItemBlocked = itemMap.IsItemBlocked == null ? false : itemMap.IsItemBlocked,
                                       RateID = itemMap.RateID,
                                       DaysToRefill = itemMap.DaysToRefill,
                                       TallyUpdatedDate = itemMap.TallyUpdatedDate,
                                   }).ToList();

                if (IsFilterRequired == true)
                {
                    //bcz in item master not avtive list will come and they can make it as active if want
                    GetListMappings = GetListMappings.Where(b => b.IsActive == IsActive).ToList();

                    if (!string.IsNullOrEmpty(BranchID))
                        GetListMappings = GetListMappings.Where(b => b.BranchId == BranchID).ToList();

                    if (string.IsNullOrEmpty(BranchID))
                        GetListMappings = GetListMappings.Where(b => b.BranchId == null).ToList();

                    if (!string.IsNullOrEmpty(OrgID))
                        GetListMappings = GetListMappings.Where(b => b.OrgID == OrgID).ToList();
                    //else
                    //    GetListMappings = GetListMappings.GroupBy(ac => ac.ItemCode).SelectMany(ac => ac).ToList();
                }
            }
            return GetListMappings;
        }
        public static object GetFewItemDetails()
        {
            GetListMappings = new List<DLItemCreation>();

            using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
            {
                if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                    Entities.Database.Connection.Open();

                GetListMappings = (from drow in Entities.tblItems.AsNoTracking()
                                   join itemMap in Entities.tblItemMappings on drow.ItemCode equals itemMap.ItemCode
                                   select new DLItemCreation
                                   {
                                       ID = drow.ID,
                                       ItemCode = drow.ItemCode,
                                       ItemName = drow.ItemName,
                                       ItemAlias = drow.Alias.Trim(),
                                       BranchId = itemMap.BranchID,
                                       OrgID = itemMap.OrgID,
                                       ItemMapID = itemMap.ItemMappingID,
                                   }).ToList();
            }
            return GetListMappings;
        }
    }
}