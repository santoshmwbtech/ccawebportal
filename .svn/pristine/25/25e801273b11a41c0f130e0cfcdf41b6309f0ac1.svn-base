using DocumentFormat.OpenXml.Office.CustomUI;
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
    public class DLItemCompany
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public ItemCompany SaveData(ItemCompany itemCompany, string OrgID, string UserID)
        {
            ItemCompany Result = new ItemCompany();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

                    var isValueExists = Entities.tblItemCompanies.AsNoTracking().Where(i => i.ItemCompanyID == itemCompany.ItemCompanyID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        var IsNameExists = Entities.tblItemCompanies.AsNoTracking().Where(i => i.CompanyName == itemCompany.CompanyName).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            tblItemCompany tblItem = new tblItemCompany();
                            tblItem.CompanyName = itemCompany.CompanyName;
                            tblItem.OrgID = OrgID;
                            tblItem.CreatedByID = Convert.ToInt32(UserID);
                            tblItem.CreatedDate = DateTimeNow;
                            tblItem.IsActive = itemCompany.IsActive;
                            Entities.tblItemCompanies.Add(tblItem);
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Brand Manufacturer Saved Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "Brand Manufacturer already exists";
                            return Result;
                        }
                    }
                    else
                    {
                        var IsNameExists = Entities.tblItemCompanies.AsNoTracking().Where(i => i.CompanyName == itemCompany.CompanyName && i.ItemCompanyID != itemCompany.ItemCompanyID).FirstOrDefault();

                        if (IsNameExists != null)
                        {
                            Result.DisplayMessage = "Brand Manufacturer already exists";
                            return Result;
                        }
                        else
                        {
                            tblItemCompany tblItem = new tblItemCompany();
                            tblItem.ItemCompanyID = itemCompany.ItemCompanyID;
                            tblItem.CompanyName = itemCompany.CompanyName;
                            tblItem.OrgID = OrgID;
                            tblItem.CreatedByID = isValueExists.CreatedByID;
                            tblItem.CreatedDate = isValueExists.CreatedDate;
                            tblItem.ModifiedByID = Convert.ToInt32(UserID);
                            tblItem.ModifiedDate = DateTimeNow;
                            tblItem.IsActive = itemCompany.IsActive;
                            Entities.tblItemCompanies.Add(tblItem);
                            Entities.Entry(tblItem).State = EntityState.Modified;
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Brand Manufacturer Updated Successfully";
                            return Result;
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
        public List<ItemCompany> GetData(string OrgID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    List<ItemCompany> itemCompanies = new List<ItemCompany>();

                    itemCompanies = (from i in Entities.tblItemCompanies
                                     where i.OrgID == OrgID
                                     select new ItemCompany
                                     {
                                         ItemCompanyID = i.ItemCompanyID,
                                         CompanyName = i.CompanyName,
                                         CreatedDate = i.CreatedDate,
                                         CreatedByID = i.CreatedByID,
                                         ModifiedByID = i.ModifiedByID,
                                         ModifiedDate = i.ModifiedDate,
                                         OrgID = i.OrgID,
                                         IsActive = i.IsActive,
                                         Status = i.IsActive == true ? "Active" : "Inactive",
                                     }).OrderBy(i => i.CompanyName).ToList();

                    return itemCompanies;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public ItemCompany GetItemCompanyDetail(int ItemCompanyID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    ItemCompany itemCompany = new ItemCompany();
                    itemCompany = (from i in dbContext.tblItemCompanies
                                   where i.ItemCompanyID == ItemCompanyID
                                   select new ItemCompany
                                   {
                                       ItemCompanyID = i.ItemCompanyID,
                                       CompanyName = i.CompanyName,
                                       CreatedDate = i.CreatedDate,
                                       CreatedByID = i.CreatedByID,
                                       ModifiedByID = i.ModifiedByID,
                                       ModifiedDate = i.ModifiedDate,
                                       OrgID = i.OrgID,
                                       IsActive = i.IsActive,
                                   }).FirstOrDefault();
                    return itemCompany;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public bool SearchRoleName(string rname)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        var IsValueexists = from gUser in Entities.tblSysRoles.AsNoTracking()
                                            where gUser.RoleName.ToLower().Trim().Equals(rname.ToLower().Trim())
                                            select gUser.RoleName;

                        if (IsValueexists.Count() != 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DLRoleCreation DeleteItemCompany(int ItemCompanyID, string OrgID, string UserID)
        {
            DLRoleCreation Result = new DLRoleCreation();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblItemCompanies.AsNoTracking().Where(u => u.ItemCompanyID == ItemCompanyID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        Entities.tblItemCompanies.Remove(Entities.tblItemCompanies.Where(r => r.ItemCompanyID == ItemCompanyID).FirstOrDefault());
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Brand Manufacturer Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Can not delete Brand Manufacturer as it is being used in brands master";
                return Result;
            }
        }
    }
    public class ItemCompany
    {
        public int ItemCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string OrgID { get; set; }
        public string SourceOfUpdate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedByID { get; set; }
        public string DisplayMessage { get; set; }
        public string Status { get; set; }
    }
}
