using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;
using System.Web.Mvc;
using static WBT.DLCustomerCreation.DLUserCreation;
using WBT.DLCustomerCreation.Reports;
using System.Web;

namespace WBT.DLCustomerCreation
{
    public class GetAllUsersDropDownsData
    {
        public List<DLWarehouseLst> dLWarehouseLst { get; set; } = new List<DLWarehouseLst>();
        public List<DLBranchLst> dLBranchLst { get; set; } = new List<DLBranchLst>();
        public List<DLRolesLst> dLRolesLst { get; set; } = new List<DLRolesLst>();
        public List<DlUnderSysRole> dlUnderSysRole { get; set; } = new List<DlUnderSysRole>();
    }
    public class DLRolesLst
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int? UnderRole { get; set; }
    }
    public class Users
    {
        public string value { get; set; }
        public string text { get; set; }
    }
    public class DLBranchLst
    {
        public string BranchID { get; set; }
        public string BranchName { get; set; }
        public string OrgID { get; set; }
    }
    public class DLWarehouseLst
    {
        public int WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public string BranchID { get; set; }
        public string OrgID { get; set; }
    }
    public class DlUnderSysRole
    {

        [Required(ErrorMessage = "please assign Roleusers")]
        public int AssignedUserId { get; set; }
        public int UserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
    }
    public class FilterOptions
    {
        public int RoleID { get; set; }
        public int UserId { get; set; }
    }
    public class UserDocs
    {
        public string UserID { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public HttpPostedFileBase DocFile { get; set; }
        public string DocBase64 { get; set; }
        public string ExpiryDate { get; set; }
        public string Base64Str { get; set; }
    }
    public class DLUserCreation
    {
        public List<DlUnderSysRole> UnderSysRolelist { get; set; }
        public int[] ParentUserList { get; set; }
        //public int RoleUserId { get; set; }
        public string OrgID { get; set; }
        public string BranchID { get; set;}
        public int UserID { get; set; }
        public string FName { get; set; }
        public string Alias { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        private string mPassword = string.Empty;
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Password
        {
            get
            {
                return (mPassword);
            }
            set
            {
                mPassword = value;// WBT.Common.DataSecurity.Decrypt(value);
            }
        }
        public int RoleID { get; set; }
        public string OrgName { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public string BranchName { get; set; }
        public string RoleName { get; set; }
        public string Department { get; set; }
        public bool IsThresholdQtyAllowed { get; set; }
        public bool IsActive { get; set; }

        public string PinCode { get; set; }
        public int? City { get; set; }
        public int? State { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public int? CountryID { get; set; }
        public string AdharNumber { get; set; }
        public string PanNumber { get; set; }
        public int? QuestionID { get; set; }
        public string Answer { get; set; }
        public string CanAddDiscount { get; set; }
        public string OldPassword { get; set; }
        public string NoofPassword { get; set; }
        public DateTime LoggedInDateTime { get; set; }
        public DateTime UpdatedDatetime { get; set; }
        public int UpdatedBy { get; set; }
        public int DeviceId { get; set; }
        public string DiscountPercentage { get; set; }
        public string DiscountValue { get; set; }
        public int? ChannelPartnerID { get; set; }
        public int? ParentUserID { get; set; }
        public string ChannelPartnerName { get; set; }
        public string ParentUserName { get; set; }
        public string AadhaarDocument { get; set; }
        public string PANDocument { get; set; }
        public List<string> OtherDocuments { get; set; }
        public HttpPostedFileBase AadhaarDocumentFile { get; set; }
        public HttpPostedFileBase PANDocumentFile { get; set; }
        public List<HttpPostedFileBase> OtherDocumentFiles { get; set; }
        public string AadhaarDocumentNumber { get; set; }
        public string PANDocumentNumber { get; set; }
        public int[] StateList { get; set; }
        public int[] DistrictList { get; set; }
        public int[] CityList { get; set; }
        public string[] AreaList { get; set; }
        public List<CustomerVendorDetails> customers { get; set; }
        public List<UserDocs> userDocs { get; set; }
        public string TotalStates { get; set; }
        public string TotalDistricts { get; set; }
        public string TotalCities { get; set; }
        public string TotalAreas { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public bool IsServiceInstalled { get; set; }
    }
    public class DLGetUserCreation
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        public tblSysUser lAddUser = new tblSysUser();
        //public tblUserRoleMapping underSysRole = new tblUserRoleMapping();
        public List<DLUserCreation> lstAddUserCreation = new List<DLUserCreation>();
        public List<DLUserCreation> dLUserCreation = new List<DLUserCreation>();
        public List<DlUnderSysRole> ExistingUnderSysRole = new List<DlUnderSysRole>();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public DLUserCreation mAddUserCreation = new DLUserCreation();
        public List<DLUserCreation> GetData(string OrgID)
        {
            lstAddUserCreation = new List<DLUserCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    #region new aug 19th 2020 by sneha
                    lstAddUserCreation = (from drow in Entities.tblSysUsers.AsNoTracking()
                                          where drow.OrgID == OrgID
                                          select new DLUserCreation()
                                          {
                                              UserID = drow.UserID,
                                              FName = drow.FName.Trim(),
                                              Alias = drow.Alias.Trim(),
                                              Mobile = drow.Mobile.Trim(),
                                              Email = drow.Email.Trim(),
                                              OrgID = drow.OrgID.Trim(),
                                              BranchID = drow.BranchID != null ? drow.BranchID : "",
                                              RoleID = drow.RoleID,
                                              WarehouseID = drow.WarehouseID == null ? (int?)null : drow.WarehouseID.Value,
                                              //WarehouseName = drow.tblWarehouse == null ? string.Empty : drow.tblWarehouse.WarehouseName,
                                              Address = drow.Address.Trim(),
                                              Password = drow.Password,// WBT.Common.DataSecurity.Decrypt(drow.Password),
                                              Username = drow.Username.Trim(),
                                              //OrgName = drow.tblSysOrganization != null ? drow.tblSysOrganization.Name.Trim() : "",
                                              //BranchName = drow.tblSysBranch != null ? drow.tblSysBranch.Name.Trim() : "",
                                              RoleName = drow.tblSysRole != null ? drow.tblSysRole.RoleName.Trim() : "",
                                              Department = drow.tblDepartment != null ? drow.tblDepartment.DepartmentName.Trim() : "",
                                              // IsThresholdQtyAllowed = drow.IsThresholdQtyAllowed,
                                              State = drow.State,
                                              City = drow.City,
                                              PinCode = drow.PinCode,
                                              PanNumber = drow.PanNumber,
                                              AdharNumber = drow.AdharNumber,
                                              IsActive = drow.IsActive.Value,
                                              DepartmentID = drow.DepartmentID,
                                              BranchName = drow.tblSysBranch != null ? drow.tblSysBranch.Name : "",
                                          }).OrderByDescending(i => i.UserID).ToList();
                    #endregion
                    return lstAddUserCreation;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<DLUserCreation> GetUserDetailsByRoleIdWise(int RoleId)
        {
            List<DLUserCreation> dLUserCreationList = new List<DLUserCreation>();
            DLUserCreation UnderRoleID = new DLUserCreation();

            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var ParentRoleID = (from sysRole in Entities.tblSysRoles
                                        where sysRole.RoleID == RoleId
                                        select sysRole.ParentRoleID).FirstOrDefault();

                    dLUserCreationList = (from SysUser in Entities.tblSysUsers
                                          join SysRole in Entities.tblSysRoles on SysUser.RoleID equals SysRole.RoleID
                                          where SysUser.RoleID == ParentRoleID
                                          select new DLUserCreation
                                          {
                                              UserID = SysUser.UserID,
                                              Username = SysUser.Username,
                                              RoleID = SysUser.RoleID,
                                              RoleName = SysRole.RoleName,
                                          }).ToList();
                }
                return dLUserCreationList;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<DLUserCreation> GetAssignableUsersByUserID(int Userid)
        {
            List<DLUserCreation> dLUserCreationList = new List<DLUserCreation>();
            DLUserCreation UnderRoleID = new DLUserCreation();

            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed
                    var UserRoleID = (from sysuser in Entities.tblSysUsers
                                      where sysuser.UserID == Userid
                                      select sysuser.RoleID).FirstOrDefault();

                    var ParentRoleID = (from sysRole in Entities.tblSysRoles
                                        where sysRole.RoleID == UserRoleID
                                        select sysRole.ParentRoleID).FirstOrDefault();

                    //dLUserCreationList = (from sysUser in Entities.tblSysUsers
                    //                      join underSysRole in Entities.tblUserRoleMappings on sysUser.UserID equals underSysRole.AssignedUserId
                    //                      where underSysRole.UserId == Userid
                    //                      select new DLUserCreation
                    //                      {
                    //                          UserID = sysUser.UserID,
                    //                          Username = sysUser.Username,
                    //                      }).ToList();

                    dLUserCreationList = (from SysUser in Entities.tblSysUsers
                                          where SysUser.RoleID == ParentRoleID
                                          select new DLUserCreation
                                          {
                                              UserID = SysUser.UserID,
                                              Username = SysUser.Username,
                                          }).ToList();
                }
                return dLUserCreationList;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<DLUserCreation> GetAssignedUsersByUserID(int Userid)
        {
            List<DLUserCreation> dLUserCreationList = new List<DLUserCreation>();
            DLUserCreation UnderRoleID = new DLUserCreation();

            try
            {

                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    //dLUserCreationList = (from sysUser in Entities.tblSysUsers
                    //                      join underSysRole in Entities.tblUserRoleMappings on sysUser.UserID equals underSysRole.AssignedUserId
                    //                      where underSysRole.UserId == Userid

                    //                      select new DLUserCreation
                    //                      {
                    //                          UserID = sysUser.UserID,
                    //                          Username = sysUser.Username,
                    //                      }).ToList();
                }
                return dLUserCreationList;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                throw;
            }
        }
        public bool SaveData(DLUserCreation Context, int LoginUserID, string OrgID)
        {
            mAddUserCreation = ((DLUserCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                        List<tblSysUser> AliasExist = new List<tblSysUser>();
                        var IsValueexists = from gUser in Entities.tblSysUsers.AsNoTracking()
                                            where gUser.Username.ToLower().Trim().Equals(mAddUserCreation.Username.ToLower().Trim())
                                            select gUser.Username;

                        if (IsValueexists.Count() != 0)
                        {
                            return false;
                        }
                        else
                        {
                            try
                            {
                                var lastUserID = (from u in Entities.tblSysUsers orderby u.UserID descending select u.UserID).Max();
                                int UserID = 0;
                                UserID = lastUserID + 1;
                                lAddUser.IsActive = true;
                                lAddUser.UserID = UserID;
                                lAddUser.FName = this.mAddUserCreation.FName;
                                lAddUser.Alias = mAddUserCreation.Alias;
                                lAddUser.WarehouseID = this.mAddUserCreation.WarehouseID == 0 ? null : mAddUserCreation.WarehouseID;
                                lAddUser.Mobile = this.mAddUserCreation.Mobile;
                                lAddUser.Email = this.mAddUserCreation.Email;
                                lAddUser.Address = this.mAddUserCreation.Address;
                                lAddUser.Username = this.mAddUserCreation.Username;
                                lAddUser.Password = Helper.Encrypt(this.mAddUserCreation.Password);
                                lAddUser.OrgID = OrgID;
                                lAddUser.BranchID = this.mAddUserCreation.BranchID;
                                lAddUser.RoleID = this.mAddUserCreation.RoleID;
                                lAddUser.Department = this.mAddUserCreation.Department;
                                lAddUser.State = this.mAddUserCreation.State;
                                lAddUser.City = this.mAddUserCreation.City;
                                lAddUser.PanNumber = this.mAddUserCreation.PanNumber;
                                lAddUser.PinCode = this.mAddUserCreation.PinCode;
                                lAddUser.AdharNumber = this.mAddUserCreation.AdharNumber;
                                lAddUser.IsActive = mAddUserCreation.IsActive;
                                lAddUser.CreatedDatetime = DateTimeNow;
                                lAddUser.UpdatedDatetime = DateTimeNow;
                                lAddUser.CreatedByID = LoginUserID;
                                lAddUser.UpdatedBy = LoginUserID;
                                lAddUser.DepartmentID = this.mAddUserCreation.DepartmentID;
                                lAddUser.CountryID = mAddUserCreation.CountryID;
                                lAddUser.ParentUserID = mAddUserCreation.ParentUserID;
                                Entities.tblSysUsers.Add(lAddUser);

                                if (mAddUserCreation.ParentUserList != null)
                                {
                                    foreach (int ParentUserID in mAddUserCreation.ParentUserList)
                                    {
                                        tblUserMapping tblUserMapping = new tblUserMapping();
                                        tblUserMapping.UserId = UserID;
                                        tblUserMapping.ParentUserId = ParentUserID;
                                        tblUserMapping.CreatedDate = DateTimeNow;
                                        tblUserMapping.CreateddBy = LoginUserID;
                                        tblUserMapping.OrgID = OrgID;
                                        Entities.tblUserMappings.Add(tblUserMapping);
                                    }
                                }

                                if (mAddUserCreation.userDocs != null && mAddUserCreation.userDocs.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.userDocs)
                                    {
                                        tblUserDocument userDocument = new tblUserDocument();
                                        userDocument.UserID = UserID;
                                        userDocument.DocumentType = item.DocumentType;
                                        userDocument.DocumentNumber = item.DocumentNumber;
                                        userDocument.DocumentData = item.DocBase64;
                                        userDocument.CreatedDate = DateTimeNow;
                                        userDocument.CreatedBy = LoginUserID;
                                        userDocument.OrgID = OrgID;
                                        Entities.tblUserDocuments.Add(userDocument);
                                    }
                                }

                                if (mAddUserCreation.StateList != null && mAddUserCreation.StateList.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.StateList)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.StateID = item;
                                        areaofService.UserID = UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }
                                if (mAddUserCreation.DistrictList != null && mAddUserCreation.DistrictList.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.DistrictList)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.DistrictID = item;
                                        areaofService.UserID = UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }
                                if (mAddUserCreation.CityList != null && mAddUserCreation.CityList.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.CityList)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.CityID = item;
                                        areaofService.UserID = UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }
                                if (mAddUserCreation.AreaList != null && mAddUserCreation.AreaList.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.AreaList)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.AreaName = item.ToString();
                                        areaofService.UserID = UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }

                                if (mAddUserCreation.customers != null && mAddUserCreation.customers.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.customers)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.CustID = item.ID;
                                        areaofService.UserID = UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }

                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditData(DLUserCreation Context, int LoginUserID, string OrgID)
        {
            mAddUserCreation = ((DLUserCreation)Context);
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    List<tblSysUser> AliasExist = new List<tblSysUser>();
                    DateTime DateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                    lAddUser = (from gUser in Entities.tblSysUsers.AsNoTracking()
                                where gUser.UserID == mAddUserCreation.UserID
                                select gUser).First();
                    if (lAddUser != null)
                    {
                        using (var dbcxtransaction = Entities.Database.BeginTransaction())
                        {
                            try
                            {
                                var ExistingSysUsers = Entities.tblSysUsers.AsNoTracking().Where(p => p.UserID == Context.UserID).FirstOrDefault();
                                lAddUser.UserID = ExistingSysUsers.UserID;
                                lAddUser.FName = this.mAddUserCreation.FName;
                                lAddUser.Alias = mAddUserCreation.Alias;
                                lAddUser.WarehouseID = this.mAddUserCreation.WarehouseID == 0 ? null : mAddUserCreation.WarehouseID;
                                lAddUser.Mobile = this.mAddUserCreation.Mobile;
                                lAddUser.Email = this.mAddUserCreation.Email;
                                lAddUser.Address = this.mAddUserCreation.Address;
                                lAddUser.Username = this.mAddUserCreation.Username;
                                lAddUser.Password = Helper.Encrypt(this.mAddUserCreation.Password);
                                lAddUser.OrgID = OrgID;
                                lAddUser.BranchID = this.mAddUserCreation.BranchID;
                                lAddUser.RoleID = this.mAddUserCreation.RoleID;
                                lAddUser.Department = this.mAddUserCreation.Department;
                                lAddUser.CreatedDatetime = ExistingSysUsers.CreatedDatetime;
                                lAddUser.UpdatedDatetime = Common.Helper.GetCurrentDate;
                                lAddUser.CreatedByID = ExistingSysUsers.CreatedByID;
                                lAddUser.UpdatedBy = LoginUserID;
                                lAddUser.State = this.mAddUserCreation.State;
                                lAddUser.City = this.mAddUserCreation.City;
                                lAddUser.PanNumber = this.mAddUserCreation.PanNumber;
                                lAddUser.PinCode = this.mAddUserCreation.PinCode;
                                lAddUser.AdharNumber = this.mAddUserCreation.AdharNumber;
                                lAddUser.IsActive = this.mAddUserCreation.IsActive;
                                lAddUser.ParentUserID = mAddUserCreation.ParentUserID;
                                lAddUser.CountryID = mAddUserCreation.CountryID;
                                lAddUser.DepartmentID = this.mAddUserCreation.DepartmentID;
                                Entities.tblSysUsers.Add(lAddUser);
                                Entities.Entry(lAddUser).State = EntityState.Modified;

                                if (mAddUserCreation.ParentUserList != null)
                                {
                                    var isValueExists = Entities.tblUserMappings.AsNoTracking().Where(u => u.UserId == lAddUser.UserID).ToList();
                                    if (isValueExists != null)
                                    {
                                        Entities.tblUserMappings.RemoveRange(Entities.tblUserMappings.Where(u => u.UserId == mAddUserCreation.UserID));
                                    }
                                    foreach (int ParentUserID in mAddUserCreation.ParentUserList)
                                    {
                                        tblUserMapping tblUserMapping = new tblUserMapping();
                                        tblUserMapping.UserId = mAddUserCreation.UserID;
                                        tblUserMapping.ParentUserId = ParentUserID;
                                        tblUserMapping.CreatedDate = DateTime.Now;
                                        tblUserMapping.CreateddBy = LoginUserID;
                                        tblUserMapping.OrgID = OrgID;
                                        Entities.tblUserMappings.Add(tblUserMapping);
                                    }
                                }

                                if (mAddUserCreation.userDocs != null && mAddUserCreation.userDocs.Count() > 0)
                                {
                                    var isValueExists = Entities.tblUserDocuments.AsNoTracking().Where(u => u.UserID == lAddUser.UserID).ToList();
                                    if (isValueExists != null)
                                    {
                                        Entities.tblUserDocuments.RemoveRange(Entities.tblUserDocuments.Where(u => u.UserID == lAddUser.UserID));
                                    }
                                    foreach (var item in mAddUserCreation.userDocs)
                                    {
                                        tblUserDocument userDocument = new tblUserDocument();
                                        userDocument.UserID = mAddUserCreation.UserID;
                                        userDocument.DocumentType = item.DocumentType;
                                        userDocument.DocumentNumber = item.DocumentNumber;
                                        userDocument.DocumentData = item.DocBase64;
                                        userDocument.CreatedDate = DateTimeNow;
                                        userDocument.CreatedBy = LoginUserID;
                                        userDocument.OrgID = OrgID;
                                        Entities.tblUserDocuments.Add(userDocument);
                                    }
                                }

                                if (mAddUserCreation.StateList != null && mAddUserCreation.StateList.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.StateList)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.StateID = item;
                                        areaofService.UserID = ExistingSysUsers.UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }
                                if (mAddUserCreation.DistrictList != null && mAddUserCreation.DistrictList.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.DistrictList)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.DistrictID = item;
                                        areaofService.UserID = ExistingSysUsers.UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }
                                if (mAddUserCreation.CityList != null && mAddUserCreation.CityList.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.CityList)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.CityID = item;
                                        areaofService.UserID = ExistingSysUsers.UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }
                                if (mAddUserCreation.AreaList != null && mAddUserCreation.AreaList.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.AreaList)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.AreaName = item.ToString();
                                        areaofService.UserID = ExistingSysUsers.UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }

                                if (mAddUserCreation.customers != null && mAddUserCreation.customers.Count() > 0)
                                {
                                    foreach (var item in mAddUserCreation.customers)
                                    {
                                        tblUserAreaofService areaofService = new tblUserAreaofService();
                                        areaofService.CustID = item.ID;
                                        areaofService.UserID = ExistingSysUsers.UserID;
                                        areaofService.CreatedDate = DateTimeNow;
                                        areaofService.CreatedBy = LoginUserID;
                                        areaofService.OrgID = OrgID;
                                        Entities.tblUserAreaofServices.Add(areaofService);
                                    }
                                }

                                Entities.SaveChanges();
                                dbcxtransaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                dbcxtransaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
        public List<DLBranchLst> GetBranchData(string OrgID)
        {
            List<DLBranchLst> dLBranchLsts = new List<DLBranchLst>();
            dLBranchLsts = (from branchs in Entities.tblSysBranches.AsNoTracking()
                            where branchs.OrgID == OrgID
                            select new DLBranchLst()
                            {
                                BranchID = branchs.BranchID,
                                BranchName = branchs.Name.Trim(),
                                OrgID = branchs.OrgID,
                            }).ToList();


            return dLBranchLsts;
        }
        public List<DLRolesLst> GetRolesData()
        {
            List<DLRolesLst> dLRolesLst = new List<DLRolesLst>();
            dLRolesLst = (from role in Entities.tblSysRoles.AsNoTracking()
                          select new DLRolesLst()
                          {
                              RoleID = role.RoleID,
                              RoleName = role.RoleName.Trim(),
                              UnderRole = role.ParentRoleID,
                          }).ToList();
            return dLRolesLst.OrderBy(a=>a.RoleName).ToList();//new line
        }
        public List<DLWarehouseLst> GetWarehouseData(string OrgID)
        {
            //DLUserCreation Criteria = (DLUserCreation)Context;

            List<DLWarehouseLst> dLWarehouseLst = new List<DLWarehouseLst>();
            dLWarehouseLst = (from wrhs in Entities.tblWarehouses.AsNoTracking()
                              where wrhs.IsActive == true &&
                              wrhs.IsPrimary == false && wrhs.OrgID == OrgID
                              select new DLWarehouseLst()
                              {
                                  WarehouseID = wrhs.WarehouseID,
                                  WarehouseName = wrhs.WarehouseName.Trim(),
                                  OrgID = wrhs.OrgID,
                                  BranchID = wrhs.BranchID,
                              }).ToList();
            return dLWarehouseLst.OrderBy(a=>a.WarehouseName).ToList();
        }
        public List<DLWarehouseLst> GetSales()
        {
            List<DLWarehouseLst> dLWarehouseLst = new List<DLWarehouseLst>();
            dLWarehouseLst = (from wrhs in Entities.tblWarehouses.AsNoTracking()
                              where wrhs.IsActive == true &&
                              wrhs.IsPrimary == false
                              select new DLWarehouseLst()
                              {
                                  WarehouseID = wrhs.WarehouseID,
                                  WarehouseName = wrhs.WarehouseName.Trim(),
                                  OrgID = wrhs.OrgID,
                                  BranchID = wrhs.BranchID,
                              }).ToList();


            return dLWarehouseLst;
        }
        public DLUserCreation GetUserDeatil(int UserID)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    #region new aug 19th 2020 by sneha
                    //UnderSysRolelist
                    mAddUserCreation = (from drow in Entities.tblSysUsers.AsNoTracking()
                                        where drow.UserID == UserID
                                        select new DLUserCreation()
                                        {
                                            UserID = drow.UserID,
                                            FName = drow.FName.Trim(),
                                            Alias = drow.Alias.Trim(),
                                            Mobile = drow.Mobile.Trim(),
                                            Email = drow.Email.Trim(),
                                            OrgID = drow.OrgID.Trim(),
                                            Address = drow.Address.Trim(),
                                            Username = drow.Username.Trim(),
                                            RoleName = drow.tblSysRole != null ? drow.tblSysRole.RoleName.Trim() : "",
                                            Department = drow.tblDepartment != null ? drow.tblDepartment.DepartmentName.Trim() : "",
                                            State = drow.State,
                                            City = drow.City,
                                            PinCode = drow.PinCode,
                                            CityName = Entities.tblStateWithCities.Where(s => s.StatewithCityID == drow.City).FirstOrDefault().VillageLocalityname,
                                            StateName = Entities.tblStates.Where(s => s.StateID == drow.State).FirstOrDefault().StateName,
                                            PanNumber = drow.PanNumber,
                                            AdharNumber = drow.AdharNumber,
                                            IsActive = drow.IsActive.Value,
                                            DepartmentID = drow.DepartmentID,
                                            IsServiceInstalled = drow.tblSysOrganization.IsServiceInstalled == null ? false : drow.tblSysOrganization.IsServiceInstalled.Value,

                                        }).FirstOrDefault();

                    #endregion
                    return mAddUserCreation;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                Helper.LogError(sqlex.Message, sqlex.Source, sqlex.InnerException == null ? null : sqlex.InnerException, sqlex.StackTrace);
                return null;
            }
        }
        public List<DlUnderSysRole> UnderSysRoleList(int UserID)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    #region new aug 19th 2020 by sneha
                    List<DlUnderSysRole> UnderSysRolelis = new List<DlUnderSysRole>();
                    //UnderSysRolelis = (from undersysrole in Entities.tblUserRoleMappings   //into table1
                    //                   where undersysrole.UserId == UserID
                    //                   select new DlUnderSysRole()
                    //                   {
                    //                       AssignedUserId = undersysrole.AssignedUserId,
                    //                       UserId = undersysrole.UserId
                    //                   }).ToList();
                    #endregion
                    return UnderSysRolelis;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DLUserCreation GetUserDeatils(int UserID)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    List<DLUserCreation> lstAdduser = new List<DLUserCreation>();
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    int[] ParentUserList = Entities.tblUserMappings.Where(um => um.UserId == UserID).Select(x => x.ParentUserId).ToArray();

                    #region new aug 19th 2020 by sneha
                    DLUserCreation userCreation = (from drow in Entities.tblSysUsers.AsNoTracking()
                                                   where drow.UserID == UserID
                                                   select new DLUserCreation()
                                                   {
                                                       UserID = drow.UserID,
                                                       FName = drow.FName.Trim(),
                                                       Alias = drow.Alias.Trim(),
                                                       Mobile = drow.Mobile.Trim(),
                                                       Email = drow.Email.Trim(),
                                                       OrgID = drow.OrgID.Trim(),
                                                       BranchID = drow.BranchID != null ? drow.BranchID : "",
                                                       RoleID = drow.RoleID,
                                                       CountryID = drow.CountryID,
                                                       WarehouseID = drow.WarehouseID == null ? (int?)null : drow.WarehouseID.Value,
                                                       Address = drow.Address.Trim(),
                                                       Password = drow.Password,
                                                       Username = drow.Username.Trim(),
                                                       RoleName = drow.tblSysRole != null ? drow.tblSysRole.RoleName.Trim() : "",
                                                       Department = drow.tblDepartment != null ? drow.tblDepartment.DepartmentName.Trim() : "",
                                                       State = drow.State,
                                                       City = drow.City,
                                                       CityName = Entities.tblStateWithCities.Where(c => c.StatewithCityID == drow.City).FirstOrDefault().VillageLocalityname,
                                                       PinCode = drow.PinCode,
                                                       PanNumber = drow.PanNumber,
                                                       AdharNumber = drow.AdharNumber,
                                                       IsActive = drow.IsActive.Value,
                                                       DepartmentID = drow.DepartmentID,
                                                   }).AsNoTracking().SingleOrDefault();

                    userCreation.userDocs = (from d in Entities.tblUserDocuments
                                             where d.UserID == UserID
                                             select new UserDocs
                                             {
                                                 UserID = d.UserID.ToString(),
                                                 DocBase64 = d.DocumentData,
                                                 DocumentNumber = d.DocumentNumber,
                                                 DocumentType = d.DocumentType,
                                                 Base64Str = d.DocumentData
                                             }).ToList();

                    userCreation.customers = (from d in Entities.tblUserAreaofServices
                                              join c in Entities.tblCustomerVendorDetails on d.CustID.ToString() equals c.CustID
                                              where d.UserID == UserID
                                              select new CustomerVendorDetails
                                              {
                                                  ID = d.ID,
                                                  FirmName = c.FirmName,
                                                  MobileNumber = c.MobileNumber,
                                                  BillingArea = d.AreaName,
                                                  City = c.BillingCity,
                                                  IsChecked = true
                                              }).ToList();

                    userCreation.ParentUserList = ParentUserList;
                    #endregion
                    userCreation.Password = Helper.Decrypt(userCreation.Password);
                    var UserAreaofService = Entities.tblUserAreaofServices.Where(a => a.UserID == UserID).AsEnumerable();

                    int[] StateList = UserAreaofService.Where(s => s.StateID != null).Select(x => x.StateID.Value).ToArray();
                    int[] DistrictList = UserAreaofService.Where(d => d.DistrictID != null).Select(x => x.DistrictID.Value).ToArray();
                    int[] CityList = UserAreaofService.Where(c => c.CityID != null).Select(x => x.CityID.Value).ToArray();
                    string[] AreaList = UserAreaofService.Where(a => a.AreaName != null).Select(x => x.AreaName).ToArray();

                    userCreation.StateList = StateList;
                    userCreation.DistrictList = DistrictList;
                    userCreation.CityList = CityList;
                    userCreation.AreaList = AreaList;

                        if (userCreation.userDocs != null && userCreation.userDocs.Count() > 0)
                        {
                            foreach (var item in userCreation.userDocs)
                            {
                                item.DocBase64 = string.Format("data:image/png;base64,{0}", item.DocBase64);
                            }
                        }

                    //userCreation.AadhaarDocument = string.Format("data:image/png;base64,{0}", userCreation.AadhaarDocument);
                    //userCreation.PANDocument = string.Format("data:image/png;base64,{0}", userCreation.PANDocument);
                    //for(int i = 0; i < userCreation.OtherDocuments.Count(); i++)
                    //{
                    //    userCreation.OtherDocuments[i] = string.Format("data:image/png;base64,{0}", userCreation.OtherDocuments[i]);
                    //}
                    //foreach(var item in userCreation.OtherDocuments)
                    //{
                    //    item = string.Format("data:image/png;base64,{0}", item);
                    //}
                    return userCreation;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                Helper.LogError(sqlex.Message, sqlex.Source, sqlex.InnerException, sqlex.StackTrace);
                return null;
            }
        }
        public bool SearchUserName(string uname)
        {
            try
            {
                using (Entities = new Entity.MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<tblSysUser> AliasExist = new List<tblSysUser>();
                        var IsValueexists = from gUser in Entities.tblSysUsers.AsNoTracking()
                                            where gUser.Username.ToLower().Trim().Equals(uname.ToLower().Trim())
                                            select gUser.Username;

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
        public object GetCities(int? StateID, string Name)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        if (!string.IsNullOrEmpty(Name))
                        {
                            var cityList = (from s in Entities.tblStateWithCities
                                            where s.VillageLocalityname.ToLower().Contains(Name.ToLower())
                                            select new
                                            {
                                                id = s.StatewithCityID,
                                                text = s.VillageLocalityname
                                            }).Distinct().ToList();
                            cityList = cityList.GroupBy(d => d.id).Select(i => i.FirstOrDefault()).ToList();
                            return cityList;
                        }
                        else
                        {
                            var cityList = (from s in Entities.tblStateWithCities
                                            select new
                                            {
                                                id = s.StatewithCityID,
                                                text = s.VillageLocalityname
                                            }).Distinct().Take(200).ToList();
                            cityList = cityList.GroupBy(d => d.id).Select(i => i.FirstOrDefault()).ToList();
                            return cityList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<City> SearchByCityName(int? StateID, string Name)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        var cityList = new List<City>();
                        if (!string.IsNullOrEmpty(Name))
                        {
                            cityList = (from s in Entities.tblStateWithCities
                                        where s.VillageLocalityname.ToLower().Contains(Name.ToLower())
                                        select new City
                                        {
                                            CityID = s.StatewithCityID,
                                            CityName = s.VillageLocalityname
                                        }).Distinct().Take(200).ToList();
                        }
                        else
                        {
                            cityList = (from s in Entities.tblStateWithCities
                                        select new City
                                        {
                                            CityID = s.StatewithCityID,
                                            CityName = s.VillageLocalityname
                                        }).Distinct().Take(200).ToList();
                        }
                        cityList = cityList.GroupBy(d => d.CityID).Select(i => i.FirstOrDefault()).ToList();

                        return cityList;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public List<DLUserCreation> GetParentUsersOfaRole(int? RoleID, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<DLUserCreation> UserList = new List<DLUserCreation>();
                        int ParentRoleID = 0;
                        if (RoleID != 0 && RoleID != null)
                        {
                            var Roles = Entities.tblSysRoles.Where(r => r.RoleID == RoleID.Value).FirstOrDefault();
                            if (Roles != null)
                                ParentRoleID = Roles.ParentRoleID == null ? 0 : Roles.ParentRoleID.Value;
                        }

                        if (ParentRoleID != 0)
                        {
                            UserList = (from u in Entities.tblSysUsers
                                        join r in Entities.tblSysRoles on u.RoleID equals r.RoleID
                                        where r.RoleID == ParentRoleID && u.OrgID == OrgID
                                        select new DLUserCreation
                                        {
                                            UserID = u.UserID,
                                            FName = u.FName
                                        }).ToList();
                        }
                        else
                        {
                            UserList = (from u in Entities.tblSysUsers
                                        join r in Entities.tblSysRoles on u.RoleID equals r.RoleID
                                        where u.OrgID == OrgID
                                        select new DLUserCreation
                                        {
                                            UserID = u.UserID,
                                            FName = u.FName
                                        }).ToList();
                        }
                        return UserList.OrderBy(a=>a.FName).ToList();//new line
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetCities, districts and areas Of a state
        public ACLists GetDistrictsOfState(string StateList, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<City> cityList = new List<City>();
                        List<District> districts = new List<District>();
                        ACLists aCLists = new ACLists();
                        List<State> states = new List<State>();

                        if (!string.IsNullOrEmpty(StateList))
                        {
                            string[] splitstr = null;
                            if (StateList.Contains(','))
                            {
                                splitstr = StateList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int StateID = Convert.ToInt32(splitstr[i]);
                                    states.Add(new State()
                                    {
                                        StateID = StateID
                                    });
                                }
                            }
                            else
                            {
                                int StateID = Convert.ToInt32(StateList);
                                states.Add(new State()
                                {
                                    StateID = StateID
                                });
                            }

                            cityList = (from c in Entities.tblCustomerVendorDetails
                                        join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                        join s in Entities.tblStates on c.BillingState equals s.StateName
                                        where c.BillingCity != null && c.BillingState != null && c.StateID != null && c.CityID != null
                                        && c.OrgID == OrgID
                                        select new City
                                        {
                                            BranchID = c.OrgID,
                                            StateID = s.StateID,
                                            CityID = ct.StatewithCityID,
                                            CityName = ct.VillageLocalityname,
                                            DistrictID = ct.DistrictID.Value
                                        }).AsNoTracking().Distinct().ToList();

                            cityList = (from c in cityList
                                        join s in states on c.StateID equals s.StateID
                                        select new City
                                        {
                                            CityID = c.CityID,
                                            CityName = c.CityName,
                                            DistrictID = c.DistrictID,
                                            StateID = s.StateID
                                        }).Distinct().ToList();

                            var dList = cityList.GroupBy(dls => dls.DistrictID).Select(i => i.FirstOrDefault()).ToList();

                            var DistrictList = (from dst in Entities.tblDistricts.ToList()
                                                join s in states on dst.StateID equals s.StateID
                                                select new District
                                                {
                                                    DistrictID = dst.DistrictID,
                                                    DistrictName = dst.DistrictName
                                                }).Distinct().ToList();

                            DistrictList = (from dst in DistrictList
                                            join c in dList on dst.DistrictID equals c.DistrictID
                                            select new District
                                            {
                                                DistrictID = dst.DistrictID,
                                                DistrictName = dst.DistrictName
                                            }).Distinct().ToList();

                            districts = DistrictList.GroupBy(d => d.DistrictID).Select(i => i.FirstOrDefault()).ToList();



                        }
                        aCLists.districts = districts;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetCities, areas Of a state
        public ACLists GetCitiesOfDistrict(string DistrictList, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        List<City> cityList = new List<City>();
                        List<State> stateList = new List<State>();
                        List<AreaList> areaList = new List<AreaList>();
                        ACLists aCLists = new ACLists();
                        var tblStateWithCity = Entities.tblStateWithCities;

                        List<District> districts = new List<District>();
                        if (!string.IsNullOrEmpty(DistrictList))
                        {

                            string[] splitstr = null;
                            if (DistrictList.Contains(','))
                            {
                                splitstr = DistrictList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int DistrictID = Convert.ToInt32(splitstr[i]);
                                    districts.Add(new District()
                                    {
                                        DistrictID = DistrictID
                                    });
                                }
                            }
                            else
                            {
                                int DistrictID = Convert.ToInt32(DistrictList);
                                districts.Add(new District()
                                {
                                    DistrictID = DistrictID
                                });
                            }
                        }

                        if (districts != null && districts.Count() > 0)
                        {
                            cityList = (from c in Entities.tblCustomerVendorDetails
                                        join ct in Entities.tblStateWithCities on c.CityID equals ct.StatewithCityID
                                        join s in Entities.tblStates on c.BillingState equals s.StateName
                                        where c.BillingCity != null && c.BillingState != null
                                        && c.CityID != null && c.StateID != null
                                        && c.OrgID == OrgID
                                        select new City
                                        {
                                            BranchID = c.OrgID,
                                            StateID = s.StateID,
                                            CityID = ct.StatewithCityID,
                                            CityName = ct.VillageLocalityname,
                                            DistrictID = ct.DistrictID.Value
                                        }).Distinct().ToList();

                            cityList = (from c in cityList
                                        join d in districts on c.DistrictID equals d.DistrictID
                                        select new City
                                        {
                                            CityID = c.CityID,
                                            CityName = c.CityName,
                                            DistrictID = c.DistrictID
                                        }).Distinct().ToList();
                            cityList = cityList.GroupBy(d => d.CityID).Select(i => i.FirstOrDefault()).ToList();
                        }

                        aCLists.cities = cityList;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        //GetCities, areas Of a state
        public ACLists GetAreasofCity(string CityList, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        ACLists aCLists = new ACLists();
                        List<City> cityList = new List<City>();
                        List<City> cities = new List<City>();
                        List<AreaList> areaList = new List<AreaList>();

                        if (!string.IsNullOrEmpty(CityList))
                        {
                            string[] splitstr = null;
                            if (CityList.Contains(','))
                            {
                                splitstr = CityList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int CityID = Convert.ToInt32(splitstr[i]);
                                    cities.Add(new City()
                                    {
                                        CityID = CityID
                                    });
                                }
                            }
                            else
                            {
                                int CityID = Convert.ToInt32(CityList);
                                cities.Add(new City()
                                {
                                    CityID = CityID
                                });
                            }
                        }

                        if (!string.IsNullOrEmpty(CityList))
                        {
                            areaList = (from c in Entities.tblCustomerVendorDetails
                                        join s in Entities.tblStates on c.BillingState equals s.StateName
                                        where c.BillingArea != null && c.StateID != null && c.CityID != null
                                        && c.BillingArea != "" && c.OrgID == OrgID
                                        select new AreaList
                                        {
                                            BranchID = c.OrgID,
                                            StateID = s.StateID,
                                            CityID = c.CityID.Value,
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();

                            areaList = (from c in areaList
                                        join ct in cities on c.CityID equals ct.CityID
                                        select new AreaList
                                        {
                                            BillingArea = c.BillingArea,
                                            ShippingArea = c.BillingArea
                                        }).Distinct().ToList();
                        }
                        aCLists.areaLists = areaList;
                        return aCLists;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }

        public List<CustomerVendorDetails> GetCustomersofArea(string StateList, string DistrictList, string CityList, string AreaList, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        IList<CustomerVendorDetails> customerVendors = new List<CustomerVendorDetails>();
                        List<State> states = new List<State>();
                        List<District> districts = new List<District>();
                        List<City> cities = new List<City>();
                        List<AreaList> areas = new List<AreaList>();

                        if (!string.IsNullOrEmpty(StateList))
                        {

                            string[] splitstr = null;
                            if (StateList.Contains(','))
                            {
                                splitstr = StateList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int StateID = Convert.ToInt32(splitstr[i]);
                                    states.Add(new State()
                                    {
                                        StateID = StateID
                                    });
                                }
                            }
                            else
                            {
                                int StateID = Convert.ToInt32(StateList);
                                states.Add(new State()
                                {
                                    StateID = StateID
                                });
                            }
                        }
                        if (!string.IsNullOrEmpty(DistrictList))
                        {

                            string[] splitstr = null;
                            if (DistrictList.Contains(','))
                            {
                                splitstr = DistrictList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int DistrictID = Convert.ToInt32(splitstr[i]);
                                    districts.Add(new District()
                                    {
                                        DistrictID = DistrictID
                                    });
                                }
                            }
                            else
                            {
                                int DistrictID = Convert.ToInt32(DistrictList);
                                districts.Add(new District()
                                {
                                    DistrictID = DistrictID
                                });
                            }
                        }

                        if (!string.IsNullOrEmpty(CityList))
                        {
                            string[] splitstr = null;
                            if (CityList.Contains(','))
                            {
                                splitstr = CityList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    int CityID = Convert.ToInt32(splitstr[i]);
                                    cities.Add(new City()
                                    {
                                        CityID = CityID
                                    });
                                }
                            }
                            else
                            {
                                int CityID = Convert.ToInt32(CityList);
                                cities.Add(new City()
                                {
                                    CityID = CityID
                                });
                            }
                        }

                        if (!string.IsNullOrEmpty(AreaList))
                        {
                            string[] splitstr = null;
                            if (CityList.Contains(','))
                            {
                                splitstr = AreaList.Split(',');
                                for (int i = 0; i < splitstr.Length; i++)
                                {
                                    string Area = splitstr[i];
                                    areas.Add(new AreaList()
                                    {
                                        BillingArea = Area
                                    });
                                }
                            }
                            else
                            {
                                string Area = AreaList;
                                areas.Add(new AreaList()
                                {
                                    BillingArea = Area
                                });
                            }

                            customerVendors = (from c in Entities.tblCustomerVendorDetails.ToList()
                                               join s in states on c.StateID equals s.StateID
                                               join cc in cities on c.CityID equals cc.CityID
                                               join a in areas on c.BillingArea.ToLower() equals a.BillingArea.ToLower()
                                               where c.BillingArea != null && c.StateID != null && c.CityID != null
                                               && c.OrgID == OrgID
                                               select new CustomerVendorDetails
                                               {
                                                   ID = Convert.ToInt32(c.CustID),
                                                   FirmName = c.FirmName,
                                                   BillingArea = c.BillingArea,
                                                   City = c.BillingCity,
                                                   MobileNumber = c.MobileNumber,
                                               }).Distinct().ToList();

                        }
                        return customerVendors.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public string CheckDuplicateNumber(string MobileNumber)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed
                    string Result = string.Empty;

                    var Users = Entities.tblSysUsers.Where(u => u.Mobile == MobileNumber).FirstOrDefault();
                    if (Users != null)
                    {
                        Result = "1";
                    }
                    else
                        Result = "0";

                    return Result;
                }
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                Helper.LogError(sqlex.Message, sqlex.Source, sqlex.InnerException == null ? null : sqlex.InnerException, sqlex.StackTrace);
                return null;
            }
        }
        public List<tblDepartment> GetDepartments()
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();                        //to open the connection if closed

                    List<tblDepartment> departments = new List<tblDepartment>();
                    departments = Entities.tblDepartments.Where(d => d.IsActive == true).ToList();
                    return departments.OrderBy(a=>a.DepartmentName).ToList();//new line
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException == null ? null : ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public DLUserCreation GetCount(string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = Entities.Database.BeginTransaction())
                    {
                        mAddUserCreation.TotalDistricts = (from d in Entities.tblDistricts
                                                           join c in Entities.tblStateWithCities on d.DistrictID equals c.DistrictID
                                                           join cc in Entities.tblCustomerVendorDetails on c.StatewithCityID equals cc.CityID
                                                           where cc.StateID != null && cc.CityID != null
                                                           && cc.OrgID == OrgID
                                                           select d.DistrictID).Distinct().Count().ToString();

                        mAddUserCreation.TotalCities = (from c in Entities.tblStateWithCities
                                                        join cc in Entities.tblCustomerVendorDetails on c.StatewithCityID equals cc.CityID
                                                        where cc.StateID != null && cc.CityID != null
                                                        && cc.OrgID == OrgID
                                                        select c.StatewithCityID).Distinct().Count().ToString();

                        mAddUserCreation.TotalAreas = (from cc in Entities.tblCustomerVendorDetails
                                                       where cc.StateID != null && cc.CityID != null
                                                       && cc.OrgID == OrgID
                                                       select cc.BillingArea).Distinct().Count().ToString();

                        return mAddUserCreation;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                return null;
            }
        }
        public string DeleteUser(int UserID, string OrgID, string LoginUserID)
        {
            string Result = string.Empty;
            try
            {
                using (MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities())// Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var isValueExists = Entities.tblSysUsers.AsNoTracking().Where(u => u.UserID == UserID).FirstOrDefault();

                    if (isValueExists == null)
                    {
                        Result = "Bad Request!!";
                        return Result;
                    }
                    else
                    {
                        Entities.tblSysUsers.Remove(Entities.tblSysUsers.Where(u => u.UserID == UserID).FirstOrDefault());
                        Entities.SaveChanges();
                        Result = "User Deleted Successfully";
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                Result = "Can not delete User as it is being used in Other Departments";
                return Result;
            }
        }
    }
}
