using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class TallySync
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public bool InsertTallySyncErrors(string OrgID, string TallySyncType, string TallySyncDetails, string ErrorMsg)
        {
            MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        try
                        {
                            tblTallySyncError tblTallySyncError = new tblTallySyncError();
                            tblTallySyncError.OrgID = OrgID;
                            tblTallySyncError.TallySyncType = TallySyncType;
                            tblTallySyncError.TallySyncDetails = TallySyncDetails;
                            tblTallySyncError.ErrorMsg = ErrorMsg;
                            tblTallySyncError.CreatedDate = DateTimeNow;
                            Entities.tblTallySyncErrors.Add(tblTallySyncError);
                            Entities.SaveChanges();
                            dbcxtransaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            dbcxtransaction.Rollback();
                            Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return false;
            }
        }
    }
}
