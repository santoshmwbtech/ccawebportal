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
    public class DLBusinessTypes
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public MBusinessType SaveData(MBusinessType BusinessType, string OrgID, string UserID)
        {
            MBusinessType Result = new MBusinessType();
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        var isValueExists = Entities.BusinessTypes.AsNoTracking().Where(i => i.BusinessTypeID == BusinessType.BusinessTypeID && i.OrgId == OrgID).FirstOrDefault();

                        if (isValueExists == null)
                        {
                            var IsNameExists = Entities.BusinessTypes.AsNoTracking().Where(i => i.BusinessTypeName.ToLower().Trim() == BusinessType.BusinessTypeName.ToLower().Trim() && i.OrgId == OrgID).FirstOrDefault();
                            if (IsNameExists == null)
                            {
                                BusinessType tblBusinesstype = new BusinessType();
                                tblBusinesstype.BusinessTypeName = BusinessType.BusinessTypeName;
                                tblBusinesstype.OrgId = OrgID;
                                tblBusinesstype.CreadtedById = Convert.ToInt32(UserID);
                                tblBusinesstype.CreatedDate = DateTimeNow;
                                Entities.BusinessTypes.Add(tblBusinesstype);
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                Result.DisplayMessage = "Business Type Saved Successfully";
                                return Result;
                            }
                            else
                            {
                                Result.DisplayMessage = "Business Type already exists";
                                return Result;
                            }
                        }
                        else
                        {
                            var IsNameExists = Entities.BusinessTypes.AsNoTracking().Where(i => i.BusinessTypeName.ToLower().Trim() == BusinessType.BusinessTypeName.ToLower().Trim() && i.BusinessTypeID != BusinessType.BusinessTypeID && i.OrgId == OrgID).FirstOrDefault();
                            if (IsNameExists == null)
                            {
                                BusinessType tblBusinesstype = new BusinessType();
                                tblBusinesstype.BusinessTypeID = BusinessType.BusinessTypeID;
                                tblBusinesstype.BusinessTypeName = BusinessType.BusinessTypeName;
                                tblBusinesstype.OrgId = OrgID;
                                tblBusinesstype.CreadtedById = Convert.ToInt32(UserID);
                                tblBusinesstype.CreatedDate = DateTimeNow;
                                Entities.BusinessTypes.Add(tblBusinesstype);
                                Entities.Entry(tblBusinesstype).State = EntityState.Modified;
                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                                Result.DisplayMessage = "Business Type Updated Successfully";
                                return Result;
                            }
                            else
                            {
                                Result.DisplayMessage = "Business Type already exists";
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
        public List<MBusinessType> GetData(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<MBusinessType> BusinessTypes = new List<MBusinessType>();

                    BusinessTypes = (from c in Entities.BusinessTypes
                                   where c.OrgId == OrgID
                                   select new MBusinessType
                                   {
                                       BusinessTypeID = c.BusinessTypeID,
                                       BusinessTypeName = c.BusinessTypeName,
                                       CreadtedById = c.CreadtedById,
                                       CreatedDate = c.CreatedDate,
                                       OrgId = c.OrgId,
                                   }).OrderByDescending(i => i.BusinessTypeName).ToList();

                    return BusinessTypes;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public MBusinessType GetBusinessTypeDetails(int BusinessTypeID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    MBusinessType BusinessType = new MBusinessType();
                    BusinessType = (from c in Entities.BusinessTypes
                                  where c.BusinessTypeID == BusinessTypeID
                                  select new MBusinessType
                                  {
                                      BusinessTypeID = c.BusinessTypeID,
                                      BusinessTypeName = c.BusinessTypeName,
                                      CreadtedById = c.CreadtedById,
                                      CreatedDate = c.CreatedDate,
                                      OrgId = c.OrgId,
                                  }).FirstOrDefault();
                    return BusinessType;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public MBusinessType DeleteBusinessType(int BusinessTypeID, string OrgID, string UserID)
        {
            MBusinessType Result = new MBusinessType();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.BusinessTypes.AsNoTracking().Where(u => u.BusinessTypeID == BusinessTypeID && u.OrgId == OrgID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        var isExists = Entities.tblCustomerVendorDetails.Where(c => c.CustomerType == BusinessTypeID && c.OrgID == OrgID).FirstOrDefault();
                        if (isExists != null)
                        {
                            Result.DisplayMessage = "Can not delete Business Type as it is being referenced.";
                            return Result;
                        }
                        else
                        {
                            Entities.BusinessTypes.Remove(Entities.BusinessTypes.Where(r => r.BusinessTypeID == BusinessTypeID && r.OrgId == OrgID).FirstOrDefault());
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Business Type Deleted Successfully";
                            return Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Can not delete Business Type as it is being used by other departments";
                return Result;
            }
        }
    }
    public class MBusinessType
    {
        public int BusinessTypeID { get; set; }
        [Required(ErrorMessage = "Please enter business type name")]
        public string BusinessTypeName { get; set; }
        public string OrgId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreadtedById { get; set; }
        public string DisplayMessage { get; set; }
    }
}
