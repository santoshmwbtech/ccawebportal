using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLCreditTypes
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public MCreditType SaveData(MCreditType creditType, string OrgID, string UserID)
        {
            MCreditType Result = new MCreditType();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        var isValueExists = Entities.CreditTypes.AsNoTracking().Where(i => i.CreditTypeID == creditType.CreditTypeID).FirstOrDefault();

                        if (isValueExists == null)
                        {
                            var IsNameExists = Entities.CreditTypes.AsNoTracking().Where(i => i.CreditTypeName.ToLower().Trim() == creditType.CreditTypeName.ToLower().Trim()).FirstOrDefault();
                            if (IsNameExists == null)
                            {
                                CreditType tblcredittype = new CreditType();
                                tblcredittype.CreditTypeName = creditType.CreditTypeName;
                                tblcredittype.OrgId = OrgID;
                                tblcredittype.CreatedById = Convert.ToInt32(UserID);
                                tblcredittype.CreatedDate = DateTimeNow;
                                Entities.CreditTypes.Add(tblcredittype);
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                Result.DisplayMessage = "Credit Type Saved Successfully";
                                return Result;
                            }
                            else
                            {
                                Result.DisplayMessage = "Credit Type already exists";
                                return Result;
                            }
                        }
                        else
                        {
                            var IsNameExists = Entities.CreditTypes.AsNoTracking().Where(i => i.CreditTypeName.ToLower().Trim() == creditType.CreditTypeName.ToLower().Trim() && i.CreditTypeID != creditType.CreditTypeID).FirstOrDefault();
                            if (IsNameExists == null)
                            {
                                CreditType tblcredittype = new CreditType();
                                tblcredittype.CreditTypeID = creditType.CreditTypeID;
                                tblcredittype.CreditTypeName = creditType.CreditTypeName;
                                tblcredittype.OrgId = OrgID;
                                tblcredittype.CreatedById = Convert.ToInt32(UserID);
                                tblcredittype.CreatedDate = DateTimeNow;
                                Entities.CreditTypes.Add(tblcredittype);
                                Entities.Entry(tblcredittype).State = EntityState.Modified;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                Result.DisplayMessage = "Credit Type Updated Successfully";
                                return Result;
                            }
                            else
                            {
                                Result.DisplayMessage = "Credit Type already exists";
                                return Result;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Error.. Please contact administrator";
                return Result;
            }
        }
        public List<MCreditType> GetData(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<MCreditType> creditTypes = new List<MCreditType>();

                    creditTypes = (from c in Entities.CreditTypes
                                   where c.OrgId == OrgID
                                   select new MCreditType
                                   {
                                       CreditTypeID = c.CreditTypeID,
                                       CreditTypeName = c.CreditTypeName,
                                       CreatedById = c.CreatedById,
                                       CreatedDate = c.CreatedDate,
                                       OrgId = c.OrgId,
                                   }).OrderByDescending(i => i.CreditTypeName).ToList();

                    return creditTypes;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public MCreditType GetCreditTypeDetails(int CreditTypeID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    MCreditType creditType = new MCreditType();
                    creditType = (from c in Entities.CreditTypes
                                  join cm in Entities.CreditTypeMarginDetails on c.CreditTypeID equals cm.CreditTypeID
                                  where c.CreditTypeID == CreditTypeID
                                  select new MCreditType
                                  {
                                      CreditTypeID = c.CreditTypeID,
                                      CreditTypeName = c.CreditTypeName,
                                      CreatedById = c.CreatedById,
                                      CreatedDate = c.CreatedDate,
                                      OrgId = c.OrgId,
                                      CreditDays = cm.CreditDays,
                                      Margin = cm.Margin,
                                  }).FirstOrDefault();
                    return creditType;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public MCreditType DeleteCreditType(int CreditTypeID, string OrgID, string UserID)
        {
            MCreditType Result = new MCreditType();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.CreditTypes.AsNoTracking().Where(u => u.CreditTypeID == CreditTypeID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        var isExists = Entities.tblCustomerVendorDetails.Where(c => c.CreditType == CreditTypeID).FirstOrDefault();
                        if(isExists != null)
                        {
                            Result.DisplayMessage = "Can not delete Credit Type as it is being referenced.";
                            return Result;
                        }
                        else
                        {
                            Entities.CreditTypes.Remove(Entities.CreditTypes.Where(r => r.CreditTypeID == CreditTypeID).FirstOrDefault());
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Credit Type Deleted Successfully";
                            return Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Can not delete Credit Type as it is being used by other departments";
                return Result;
            }
        }
    }
    public class MCreditType
    {
        public int CreditTypeID { get; set; }
        [Required(ErrorMessage = "Please enter credit type name")]
        public string CreditTypeName { get; set; }
        public string OrgId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedById { get; set; }
        //[Required(ErrorMessage = "Please enter margin")]
        public Nullable<decimal> Margin { get; set; }
        //[Required(ErrorMessage = "Please enter credit days")]
        public Nullable<int> CreditDays { get; set; }
        public string BranchID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> FrmEffectiveDate { get; set; }
        public string FrmEffectiveTime { get; set; }
        public Nullable<System.DateTime> ToEffectiveDate { get; set; }
        public string ToEffectiveTime { get; set; }
        public string DisplayMessage { get; set; }
    }
}
