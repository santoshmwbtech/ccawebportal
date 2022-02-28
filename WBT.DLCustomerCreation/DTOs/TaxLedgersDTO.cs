using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBT.DLCustomerCreation.DTOs
{
    public class TaxLedgersDTO
    {
        public int ID { get; set; }
        public string OrgID { get; set; }
        public string Name { get; set; }
        public string Under { get; set; }
        public string TaxType { get; set; }
        public Nullable<decimal> TaxPercentage { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string DisplayMsg { get; set; }
    }
}
