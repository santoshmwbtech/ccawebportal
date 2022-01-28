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
    public class MobileAppUsers
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Select Company")]
        public string OrgID { get; set; }
        [Required(ErrorMessage = "Enter User Name")]
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<int> ModifiedByID { get; set; }

    }
    public class DLMobileAppUsers
    {
        public List<MobileAppUsers> GetMobileAppUsersList()
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    List<MobileAppUsers> MobileAppUsersList = new List<MobileAppUsers>();
                    MobileAppUsersList = (from u in dbContext.tblSysUsers
                                          join mr in dbContext.tblSysRoles on u.RoleID equals mr.RoleID
                                   select new MobileAppUsers
                                   {
                                       ID = u.UserID,
                                       OrgID = u.OrgID,
                                       UserName = u.Username.Trim(),
                                       RoleID = u.RoleID,
                                       RoleName = mr.RoleName,
                                       CompanyName = dbContext.tblSysOrganizations.Where(o => o.OrgID == u.OrgID).FirstOrDefault().Name,
                                       CreationDate = u.CreatedDatetime,
                                       ModifiedDate = u.UpdatedDatetime
                                   }).ToList();

                    return MobileAppUsersList;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public MobileAppUsers GetUserDetails(int? ID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    MobileAppUsers AppUser = new MobileAppUsers();
                    AppUser = (from u in dbContext.tblSysUsers
                              join mr in dbContext.tblSysRoles on u.RoleID equals mr.RoleID
                              join mo in dbContext.tblSysOrganizations on u.OrgID equals mo.OrgID
                              where u.UserID == ID
                              select new MobileAppUsers
                              {
                                  ID = u.UserID,
                                  OrgID = u.OrgID,
                                  UserName = u.Username.Trim(),
                                  RoleID = u.RoleID,
                                  RoleName = mr.RoleName,
                                  CompanyName = mo.Name,
                                  CreationDate = u.CreatedDatetime,
                                  ModifiedDate = u.UpdatedDatetime
                              }).FirstOrDefault();
                    return AppUser;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public bool SaveMobileAppUser(MobileAppUsers MobileAppUser, string UserID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    var ExistingUser = dbContext.tblSysUsers.AsNoTracking().Where(p => p.UserID == MobileAppUser.ID).FirstOrDefault();

                    if (ExistingUser != null)
                    {
                        tblSysUser obj = new tblSysUser();
                        obj.UserID = MobileAppUser.ID;
                        obj.OrgID = MobileAppUser.OrgID;
                        obj.Username = MobileAppUser.UserName;
                        obj.RoleID = MobileAppUser.RoleID;
                        obj.Password = MobileAppUser.Password;
                        obj.UpdatedDatetime = DateTime.Now;
                        obj.CreatedDatetime = ExistingUser.CreatedDatetime;
                        obj.ModifiedByID = Convert.ToInt32(UserID);
                        obj.CreatedByID = ExistingUser.CreatedByID;
                        dbContext.tblSysUsers.Add(obj);
                        dbContext.Entry(obj).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        tblSysUser obj = new tblSysUser();
                        obj.Username = MobileAppUser.UserName;
                        obj.OrgID = MobileAppUser.OrgID;
                        obj.RoleID = MobileAppUser.RoleID;
                        obj.Password = MobileAppUser.Password;
                        obj.CreatedDatetime = DateTime.Now;
                        obj.CreatedByID = Convert.ToInt32(UserID);
                        dbContext.tblSysUsers.Add(obj);
                        dbContext.SaveChanges();
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
