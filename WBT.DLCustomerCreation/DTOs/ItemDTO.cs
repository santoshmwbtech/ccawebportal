using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBT.DLCustomerCreation.DTOs
{
    public class ItemDTO
    {
        public string TallyItemName { get; set; }
        public string Brand { get; set; }
        public string ItemName { get; set; }
        public string Rate { get; set; }
        public string Alias { get; set; }
        public string GroupName { get; set; }
        public int? CategoryID { get; set; }
        public string Category { get; set; }
        public int? SubCategoryID { get; set; }
        public string Company { get; set; }
        public int? ItemCompanyID { get; set; }
        public string ItemDescription { get; set; }
        public string FromTallyHSNCode { get; set; }
        public string CorrectedHSNCode { get; set; }
        public string SubHSNCode { get; set; }
        public string PacketSize { get; set; }
        public string PacketUnit { get; set; }
        public string BagSize { get; set; }
        public string BagUnit { get; set; }
        public string BasicUnitValue { get; set; }
        public string BasicUnit { get; set; }
        public string AlternateUnitValue { get; set; }
        public string AlternateUnit { get; set; }
        public string GST { get; set; }
        public string GSTEffectiveDate { get; set; }
        public string APMCCESS { get; set; }
        public string APMCCESSEffectiveDate { get; set; }
        public string ReOrderLevel { get; set; }
        public string ReOrderQTY { get; set; }
        public string DaysToRefill { get; set; }
        public string IsItemReturnable { get; set; }
        public string ItemCode { get; set; }
        public string NewItemName { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
