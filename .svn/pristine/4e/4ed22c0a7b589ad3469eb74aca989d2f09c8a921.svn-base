using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class DLRoleCreation
    {
        public int RoleID { get; set; }
        // [Required(ErrorMessage = "Enter RoleName")]
        public string RoleName { get; set; }
        //  [Required(ErrorMessage = "Enter RoleDescription")]
        public string RoleDescription { get; set; }
        public int? ParentRoleID { get; set; }
        public string ParentRoleName { get; set; }
        public int UnderRoleId { get; set; }
        // [Required(ErrorMessage = "Select Department")]
        public string Department { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DisplayMessage { get; set; }
        public int? DepartmentID { get; set; }
    }


    public class DLGetRoleCreation
    {
        List<DLRoleCreation> Rolelist = new List<DLRoleCreation>();
        tblSysRole objtblRole = new tblSysRole();
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();

        public DLRoleCreation SaveData(DLRoleCreation dLRoleCreation)
        {
            DLRoleCreation Result = new DLRoleCreation();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();
                    var isValueExists = Entities.tblSysRoles.AsNoTracking().Where(u => u.RoleName.ToLower() == dLRoleCreation.RoleName.ToLower()).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        var IsNameExists = Entities.tblSysRoles.AsNoTracking().Where(u => u.RoleName == dLRoleCreation.RoleName).FirstOrDefault();
                        if (IsNameExists == null)
                        {
                            int RoleID = 1;
                            var Exists = Entities.tblSysRoles;
                            if(Exists != null)
                            {
                                RoleID = Exists.Select(r => r.RoleID).Max() + 1;
                            }
                            objtblRole.RoleID = RoleID;
                            objtblRole.DepartmentID = dLRoleCreation.DepartmentID;
                            objtblRole.RoleName = dLRoleCreation.RoleName;
                            objtblRole.RoleDescription = dLRoleCreation.RoleDescription;
                            objtblRole.ParentRoleID = Convert.ToInt32(dLRoleCreation.ParentRoleID);
                            objtblRole.CreatedDate = DateTime.Now;
                            objtblRole.DepartmentID = dLRoleCreation.DepartmentID;
                            Entities.tblSysRoles.Add(objtblRole);
                            Entities.SaveChanges();
                            Result.DisplayMessage = "Role Saved Successfully";
                            return Result;
                        }
                        else
                        {
                            Result.DisplayMessage = "Role Name already exists";
                            return Result;
                        }
                    }
                    else
                    {
                        objtblRole.RoleID = dLRoleCreation.RoleID;
                        //objtblRole.RoleID = dLRoleCreation.RoleID;
                        objtblRole.DepartmentID = dLRoleCreation.DepartmentID;
                        objtblRole.RoleName = dLRoleCreation.RoleName;
                        objtblRole.RoleDescription = dLRoleCreation.RoleDescription;
                        objtblRole.ParentRoleID = Convert.ToInt32(dLRoleCreation.ParentRoleID);
                        objtblRole.CreatedDate = isValueExists.CreatedDate;
                        objtblRole.UpdatedDate = DateTime.Now;
                        objtblRole.DepartmentID = dLRoleCreation.DepartmentID;
                        Entities.tblSysRoles.Add(objtblRole);
                        Entities.Entry(objtblRole).State = EntityState.Modified;
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Role Updated Successfully";
                        return Result;
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
        public List<DLRoleCreation> GetData(string Name = "")
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    if (!string.IsNullOrEmpty(Name))
                    {
                        Rolelist = (from role in Entities.tblSysRoles
                                    where role.RoleName.ToLower().Contains(Name)
                                    select new DLRoleCreation
                                    {
                                        RoleID = role.RoleID,
                                        DepartmentID = role.DepartmentID,
                                        RoleDescription = role.RoleDescription,
                                        ParentRoleName = Entities.tblSysRoles.Where(r => r.RoleID == role.ParentRoleID).FirstOrDefault().RoleName,
                                        Department = Entities.tblDepartments.Where(d => d.DeptID == role.DepartmentID).FirstOrDefault().DepartmentName,
                                        RoleName = role.RoleName,
                                    }).OrderByDescending(i => i.RoleID).ToList();
                    }
                    else
                    {
                        Rolelist = (from role in Entities.tblSysRoles
                                    select new DLRoleCreation
                                    {
                                        RoleID = role.RoleID,
                                        DepartmentID = role.DepartmentID,
                                        RoleDescription = role.RoleDescription,
                                        ParentRoleName = Entities.tblSysRoles.Where(r => r.RoleID == role.ParentRoleID).FirstOrDefault().RoleName,
                                        RoleName = role.RoleName,
                                        Department = Entities.tblDepartments.Where(d => d.DeptID == role.DepartmentID).FirstOrDefault().DepartmentName,
                                    }).OrderByDescending(i => i.RoleID).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return Rolelist;
        }
        public DLRoleCreation GetDeatil(int RoleID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    DLRoleCreation result = new DLRoleCreation();
                    result = (from u in dbContext.tblSysRoles
                              where u.RoleID == RoleID
                              select new DLRoleCreation
                              {
                                  RoleID = u.RoleID,
                                  RoleName = u.RoleName,
                                  RoleDescription = u.RoleDescription,
                                  ParentRoleID = u.ParentRoleID,
                                  Department = u.Department,
                                  DepartmentID = u.DepartmentID
                              }).FirstOrDefault();
                    return result;
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
        public List<DLRoleCreation> LoadDeptRoles(int? DeptID)
        {
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();


                    if (DeptID != null)
                    {
                        Rolelist = (from role in Entities.tblSysRoles
                                    join d in Entities.tblDepartments on role.DepartmentID equals d.DeptID
                                    where d.DeptID == DeptID
                                    select new DLRoleCreation
                                    {
                                        RoleID = role.RoleID,
                                        RoleName = role.RoleName,
                                    }).OrderBy(i => i.RoleName).ToList();
                    }
                    else
                    {
                        Rolelist = (from role in Entities.tblSysRoles
                                    join d in Entities.tblDepartments on role.DepartmentID equals d.DeptID
                                    select new DLRoleCreation
                                    {
                                        RoleID = role.RoleID,
                                        RoleName = role.RoleName,
                                    }).OrderBy(i => i.RoleName).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Rolelist;
        }
        public DLRoleCreation DeleteRole(int RoleID, string OrgID, string UserID)
        {
            DLRoleCreation Result = new DLRoleCreation();
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblSysRoles.AsNoTracking().Where(u => u.RoleID == RoleID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result.DisplayMessage = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        Entities.tblSysRoles.Remove(Entities.tblSysRoles.Where(r => r.RoleID == RoleID).FirstOrDefault());
                        Entities.SaveChanges();
                        Result.DisplayMessage = "Role Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result.DisplayMessage = "Can not delete Role as it is being used in Users Master";
                return Result;
            }
        }
    }
}
