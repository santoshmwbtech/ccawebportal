using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLSystemDetails
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public tblOrgSystemDetail GetSystemDetails(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    tblOrgSystemDetail tblOrgSystemDetail = new tblOrgSystemDetail();
                    tblOrgSystemDetail = Entities.tblOrgSystemDetails.ToList().Find(a => a.OrgID == OrgID);
                    return tblOrgSystemDetail;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public bool SaveSystemDetails(string OrgID, bool IsTallyRunning)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    var IsExists = Entities.tblOrgSystemDetails.Where(s => s.OrgID == OrgID).AsNoTracking().FirstOrDefault();
                    if (IsExists != null)
                    {
                        tblOrgSystemDetail tblOrgSystemDetail = new tblOrgSystemDetail();
                        tblOrgSystemDetail.ID = IsExists.ID;
                        tblOrgSystemDetail.OrgID = OrgID;
                        tblOrgSystemDetail.IsTallyRunning = IsTallyRunning;
                        tblOrgSystemDetail.CurrentDate = DateTimeNow;
                        Entities.tblOrgSystemDetails.Add(tblOrgSystemDetail);
                        Entities.Entry(tblOrgSystemDetail).State = EntityState.Modified;
                        Entities.SaveChanges();
                    }
                    else
                    {
                        tblOrgSystemDetail tblOrgSystemDetail = new tblOrgSystemDetail();
                        tblOrgSystemDetail.OrgID = OrgID;
                        tblOrgSystemDetail.IsTallyRunning = IsTallyRunning;
                        tblOrgSystemDetail.CurrentDate = DateTimeNow;
                        Entities.tblOrgSystemDetails.Add(tblOrgSystemDetail);
                        Entities.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return false;
            }
        }
    }
}
