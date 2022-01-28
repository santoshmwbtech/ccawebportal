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
    public class DLSalesChannelType
    {
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<SalesChannelType> GetSalesChannelTypeList(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    List<SalesChannelType> salesChannelTypes = new List<SalesChannelType>();
                    salesChannelTypes = (from u in dbContext.tblSalesChannelTypes
                                         where u.OrgID == OrgID
                                         select new SalesChannelType
                                         {
                                             ID = u.ID,
                                             ChannelType = u.ChannelType.Trim(),
                                             ParentChannelType = u.ParentChannelType,
                                             ParentChannelTypeName = (from i in dbContext.tblSalesChannelTypes
                                                                      where i.ID == u.ParentChannelType
                                                                      select i).FirstOrDefault().ChannelType,
                                             CreatedDate = u.CreatedDate,
                                             ModifiedDate = u.ModifiedDate,
                                             CreatedByStr = u.CreatedBy != null ? dbContext.tblSysUsers.Where(s => s.UserID == u.CreatedBy && s.OrgID == OrgID).FirstOrDefault().FName : "",
                                             ModifiedByStr = u.ModifiedBy != null ? dbContext.tblSysUsers.Where(s => s.UserID == u.ModifiedBy && s.OrgID == OrgID).FirstOrDefault().FName : "",
                                             IsParent = u.IsParent == null ? false : u.IsParent.Value,
                                         }).ToList();

                    return salesChannelTypes;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public SalesChannelType GetSalesChannelTypeDetails(int? ID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    SalesChannelType salesChannelType = new SalesChannelType();
                    salesChannelType = (from u in dbContext.tblSalesChannelTypes
                                        where u.ID == ID
                                        select new SalesChannelType
                                        {
                                            ID = u.ID,
                                            ChannelType = u.ChannelType.Trim(),
                                            ParentChannelType = u.ParentChannelType,
                                            CreatedDate = u.CreatedDate,
                                            IsParent = u.IsParent.Value,
                                        }).FirstOrDefault();
                    return salesChannelType;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public SalesChannelType SaveSalesChannelType(SalesChannelType salesChannelType, string UserID, string OrgID)
        {
            SalesChannelType Result = new SalesChannelType();
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    var IsExists = dbContext.tblSalesChannelTypes.AsNoTracking().Where(p => p.ID == salesChannelType.ID).FirstOrDefault();
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    if (IsExists != null)
                    {
                        tblSalesChannelType channelType = new tblSalesChannelType();
                        channelType.ID = salesChannelType.ID;
                        channelType.OrgID = OrgID;
                        channelType.ChannelType = salesChannelType.ChannelType;
                        channelType.ParentChannelType = salesChannelType.ParentChannelType;
                        channelType.ModifiedDate = DateTimeNow;
                        channelType.CreatedDate = IsExists.CreatedDate;
                        channelType.ModifiedBy = Convert.ToInt32(UserID);
                        channelType.CreatedBy = IsExists.CreatedBy;
                        channelType.IsParent = IsExists.IsParent;
                        dbContext.tblSalesChannelTypes.Add(channelType);
                        dbContext.Entry(channelType).State = EntityState.Modified;
                        dbContext.SaveChanges();
                        Result.DisplayMessage = "Channel Type Saved Successfully";
                    }
                    else
                    {
                        if (!CheckDuplicateChannelType(salesChannelType.ChannelType, OrgID))
                        {
                            tblSalesChannelType channelType = new tblSalesChannelType();
                            channelType.ChannelType = salesChannelType.ChannelType;
                            channelType.ParentChannelType = salesChannelType.ParentChannelType;
                            channelType.CreatedDate = DateTimeNow;
                            channelType.CreatedBy = Convert.ToInt32(UserID);
                            channelType.OrgID = OrgID;
                            dbContext.tblSalesChannelTypes.Add(channelType);
                            dbContext.SaveChanges();
                            Result.DisplayMessage = "Channel Type Updated Successfully";
                        }
                        else
                        {
                            Result.DisplayMessage = "Channel Type already exists.. Please choose different name to continue";
                        }
                    }
                    return Result;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Internal Server Error.. Please try later";
                return Result;
            }
        }
        public bool CheckDuplicateChannelType(string ChannelType, string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    var IsExists = dbContext.tblSalesChannelTypes.Where(c => c.ChannelType.ToLower().Trim() == ChannelType.ToLower().Trim() && c.OrgID == OrgID).FirstOrDefault();
                    if (IsExists != null)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return false;
            }
        }
        public SalesChannelType DeleteChannelType(int ID, string OrgID, string UserID)
        {
            SalesChannelType Result = new SalesChannelType();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblSalesChannelTypes.AsNoTracking().Where(u => u.ID == ID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        Entities.tblSalesChannelTypes.Remove(Entities.tblSalesChannelTypes.Where(r => r.ID == ID).FirstOrDefault());
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Channel Type Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Can not delete Channel Type as it is being used in Channel Partners Master";
                return Result;
            }
        }
    }
    public class SalesChannelType
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter Sales Channel Type")]
        public string ChannelType { get; set; }
        public Nullable<int> ParentChannelType { get; set; }
        public string ParentChannelTypeName { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string CreatedByStr { get; set; }
        public string ModifiedByStr { get; set; }
        public bool IsParent { get; set; }
        public string DisplayMessage { get; set; }
    }
}
