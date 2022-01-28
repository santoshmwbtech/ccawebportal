using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBT.DLCustomerCreation
{
    public class DLRegisterFirm
    {

    }
    public class Organization
    {
        public int OrgID { get; set; }
        [Required(ErrorMessage = "Please enter firm name")]
        public string FirmName { get; set; }
        [Required(ErrorMessage = "Please enter mobile number")]
        public string MobileNumber { get; set; }
        public string EmailID { get;set; }
        public int? PlanID { get; set; }
        public string PaymentType { get; set; }
        public string UTRNumber { get; set; }
        public string PaymentAmount { get; set; }
        public string PlanStartDate { get; set; }
        public string PlanEndDate { get; set; }

    }
}
