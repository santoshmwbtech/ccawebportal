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
    public class DLAccessControl
    {
        private MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public List<tblSysRole> GetSysRoles()
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    List<tblSysRole> Roles = new List<tblSysRole>();
                    Roles = Entities.tblSysRoles.ToList();
                    return Roles.OrderBy(a=>a.RoleName).ToList();
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public AccessControl SaveAccessControl(AccessControl accessControl, int UserID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    AccessControl Result = new AccessControl();

                    var IsExists = Entities.tblAccessControls.Where(f => f.RoleID == accessControl.RoleID).AsNoTracking().FirstOrDefault();
                    if (IsExists != null)
                    {
                        Entities.tblAccessControlItems.RemoveRange(Entities.tblAccessControlItems.Where(x => x.AccessControlID == IsExists.AccessControlID));
                        Entities.SaveChanges();

                        if (accessControl.Items != null && accessControl.Items.Count() > 0)
                        {
                            foreach (var fItem in accessControl.Items)
                            {
                                tblAccessControlItem item = new tblAccessControlItem();
                                item.AccessControlID = IsExists.AccessControlID;
                                item.SubMenuID = fItem.SubMenuID;
                                item.RoleID = accessControl.RoleID;
                                item.CreatedDate = DateTimeNow;
                                item.CreatedID = UserID;
                                item.IsCreate = fItem.IsCreate;
                                item.IsView = fItem.IsView;
                                item.IsEdit = fItem.IsEdit;
                                item.IsDelete = fItem.IsDelete;
                                Entities.tblAccessControlItems.Add(item);
                            }
                            tblAccessControl tblFormPermission = new tblAccessControl();
                            tblFormPermission.AccessControlID = IsExists.AccessControlID;
                            tblFormPermission.CreatedDate = DateTimeNow;
                            tblFormPermission.CreatedID = UserID;
                            tblFormPermission.RoleID = accessControl.RoleID;
                            Entities.Entry(tblFormPermission).State = EntityState.Modified;
                            Entities.SaveChanges();
                        }

                        Result.Result = "Form permission updated Successfully!!";
                    }
                    else
                    {
                        if (accessControl.Items != null && accessControl.Items.Count() > 0)
                        {
                            tblAccessControl tblAccessControl = new tblAccessControl();
                            tblAccessControl.CreatedDate = DateTimeNow;
                            tblAccessControl.CreatedID = UserID;
                            tblAccessControl.RoleID = accessControl.RoleID;
                            Entities.tblAccessControls.Add(tblAccessControl);
                            Entities.SaveChanges();
                            int AccessControlID = tblAccessControl.AccessControlID;

                            foreach (var fItem in accessControl.Items)
                            {
                                tblAccessControlItem item = new tblAccessControlItem();
                                item.AccessControlID = AccessControlID;
                                item.SubMenuID = fItem.SubMenuID;
                                item.RoleID = fItem.RoleID;
                                item.CreatedDate = DateTimeNow;
                                item.CreatedID = UserID;
                                item.IsCreate = fItem.IsCreate;
                                item.IsView = fItem.IsView;
                                item.IsEdit = fItem.IsEdit;
                                item.IsDelete = fItem.IsDelete;
                                Entities.tblAccessControlItems.Add(item);
                            }
                            Entities.SaveChanges();
                        }
                        Result.Result = "Form permission saved Successfully!!";
                    }
                    return Result;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                AccessControl Result = new AccessControl();
                Result.Result = "Error while saving the form permission.. Please try later";
                return Result;
            }
        }

        public List<AccessControlItem> GetItems()
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    List<AccessControlItem> accessControlItems = new List<AccessControlItem>();
                    accessControlItems = (from s in Entities.tblSysSubMenus
                                           select new AccessControlItem
                                           {
                                               SubMenuID = s.SubMenuID,
                                               SubMenuName = s.SubMenuName,
                                               IsCreate = false,
                                               IsEdit = false,
                                               IsDelete = false,
                                               IsView = false,
                                           }).ToList();

                    return accessControlItems;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<AccessControlItem> LoadAccessControlItems(int? RoleID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new MWBTCustomerAppEntities())
                {
                    List<AccessControlItem> accessControlItems = new List<AccessControlItem>();
                    accessControlItems = (from f in Entities.tblAccessControls
                                          join fp in Entities.tblAccessControlItems on f.AccessControlID equals fp.AccessControlID
                                          join sm in Entities.tblSysSubMenus on fp.SubMenuID equals sm.SubMenuID into subs
                                          from sm in subs.DefaultIfEmpty()
                                          where f.RoleID == RoleID
                                          select new AccessControlItem
                                          {
                                              AccessControlID = f.AccessControlID,
                                              AccessControlItemID = fp.AccessControlItemID,
                                              RoleID = f.RoleID,
                                              MainMenuID = fp.MainMenuID,
                                              SubMenuID = sm.SubMenuID,
                                              SubMenuName = sm.SubMenuName,
                                              IsCreate = fp.IsCreate.Value,
                                              IsEdit = fp.IsEdit.Value,
                                              IsDelete = fp.IsDelete.Value,
                                              IsView = fp.IsView.Value,
                                          }).ToList();

                    if (accessControlItems == null || accessControlItems.Count() <= 0)
                    {
                        accessControlItems = (from s in Entities.tblSysSubMenus
                                              select new AccessControlItem
                                              {
                                                  SubMenuID = s.SubMenuID,
                                                  SubMenuName = s.SubMenuName,
                                                  IsCreate = false,
                                                  IsEdit = false,
                                                  IsDelete = false,
                                                  IsView = false,
                                              }).ToList();
                    }

                    return accessControlItems;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
    }
    public class AccessControl
    {
        public int? AccessControlID { get; set; }
        public int RoleID { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public int? CreatedID { get; set; }
        public List<AccessControlItem> Items { get; set; }
        public string Result { get; set; }

    }
    public class AccessControlItem
    {
        public int? AccessControlID { get; set; }
        public int? AccessControlItemID { get; set; }
        public int? RoleID { get; set; }
        public string MainMenuName { get; set; }
        public string SubMenuName { get; set; }
        public int? MainMenuID { get; set; }
        public int? SubMenuID { get; set; }
        public int? CreatedID { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public bool IsCreate { get; set; }
        public bool IsView { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool CheckAll { get; set; }

    }
}
