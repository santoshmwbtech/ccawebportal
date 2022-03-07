using System;

namespace WBT.DLCustomerCreation.DTOs
{
    public class TaxLedgersDTO
    {
        public int ID { get; set; }
        public string OrgID { get; set; }
        public string Name { get; set; }
        public string Under { get; set; }
        public string TaxType { get; set; }
        public decimal? TaxPercentage { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DisplayMsg { get; set; }
        public bool IsTallyUpdated { get; set; }
        public bool TallySync { get; set; }
    }
}
