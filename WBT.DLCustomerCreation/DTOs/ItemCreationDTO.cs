using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBT.DLCustomerCreation.DTOs
{
    public class ItemCreationDTO
    {
        public int RateID { get; set; }
        public string ItemCode { get; set; }
        public string ItemAlias { get; set; }
        public string ItemName { get; set; }
        public string TallyItemName { get; set; }
        public string HSNCode { get; set; }
        public string HSNSubCode { get; set; }
        public string BrandName { get; set; }
        public string ItemCompany { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public decimal BaseRateOther { get; set; }
        public string ItemDetail { get; set; }
        public decimal? GST { get; set; }
        public Nullable<DateTime> GSTEffectivedate { get; set; }
        public decimal? APMCCess { get; set; }
        public Nullable<DateTime> APMCCessDte { get; set; }
        public int? DaysToRefill { get; set; }
        public Nullable<bool> IsReturnable { get; set; }
        public Nullable<bool> IsTrademarkRegistered { get; set; }
        public Nullable<bool> IsItemBlocked { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string PacketUOM { get; set; }
        public string BagUOM { get; set; }
        public Nullable<decimal> PacketQTY { get; set; }
        public Nullable<decimal> BagQTY { get; set; }
        public Nullable<int> BagUOMID { get; set; }
        public string SourceOfUpdate { get; set; }
        public Nullable<int> ReOrderlevel { get; set; }
        public Nullable<int> ReOrderQTY { get; set; }
        public string BatchNumber { get; set; }
        public string Quantity { get; set; }

        public string WarehouseName { get; set; }

        public string WarehouseCity { get; set; }

        public decimal? BasicUnitValue { get; set; }
        public string BasicUnit { get; set; }
        public decimal? AlterntaeUnitValue { get; set; }
        public string AlterntaeUnit { get; set; }
        public string OrgId { get; set; }
        public string BranchID { get; set; }
        public string BranchName { get; set; }
    }
}
