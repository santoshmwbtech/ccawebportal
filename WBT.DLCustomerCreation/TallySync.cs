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

        public List<TallySyncErrorDTO> GetTallySyncErrors(TallySyncErrorDTO search)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();
                    DateTime SortByDate = new DateTime();
                    if (!string.IsNullOrEmpty(search.CreatedDateStr))
                        SortByDate = Convert.ToDateTime(search.CreatedDateStr);
                    else
                        SortByDate = DateTime.Now;

                        var tallySyncErrors = (from tallySyncError in Entities.tblTallySyncErrors
                                           where tallySyncError.OrgID == search.OrgID
                                           && tallySyncError.CreatedDate.HasValue 
                                           && DbFunctions.TruncateTime(tallySyncError.CreatedDate.Value) == SortByDate.Date
                                           select new TallySyncErrorDTO
                                           {
                                               ID = tallySyncError.ID,
                                               OrgID = tallySyncError.OrgID,
                                               CreatedDateStr = tallySyncError.CreatedDate.ToString(),
                                               CreatedDate = tallySyncError.CreatedDate,
                                               ErrorMsg = tallySyncError.ErrorMsg,
                                               TallySyncDetails = tallySyncError.TallySyncDetails,
                                               TallySyncType = tallySyncError.TallySyncType,
                                           }).OrderByDescending(i => i.CreatedDate).ToList();
                    

                    return tallySyncErrors;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
    }

    public class TallySyncErrorDTO
    {
        public int ID { get; set; }
        public string OrgID { get; set; }
        public string TallySyncType { get; set; }
        public string TallySyncDetails { get; set; }
        public string ErrorMsg { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedDateStr { get; set; }
    }
}
