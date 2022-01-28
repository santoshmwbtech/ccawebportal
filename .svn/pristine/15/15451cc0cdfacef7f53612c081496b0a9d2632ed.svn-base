using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLPlanMaster
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        public List<Plan> GetPlans()
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    List<Plan> plans = new List<Plan>();
                    plans = (from p in Entities.tblPlans
                             where p.IsActive == true
                             select new Plan
                             {
                                 PlanID = p.PlanID,
                                 PlanName = p.PlanName,
                                 PlanDuration = p.PlanDuration.Value,
                                 CreatedDate = p.CreatedDate,
                                 CreatedBy = p.CreatedBy.Value,
                             }).ToList();
                    return plans;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
    }
    public class Plan
    {   
        public int PlanID { get; set; }
        [Required(ErrorMessage = "Please enter plan name")]
        public string PlanName { get; set; }
        public int PlanDuration { get; set; }
        public bool IsActive { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public int CreatedBy { get; set; }

    }
}
