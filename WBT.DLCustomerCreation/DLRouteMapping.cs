using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class RouteMapping
    {
        public int ID { get; set; }
        public int ParentDebtorID { get; set; }
        public string FirmName { get; set; }
        [Required(ErrorMessage = "Select Salesman")]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Select Route")]
        public int RouteID { get; set; }
        public int CustID { get; set; }
        [Required(ErrorMessage = "Select Route")]
        public string AssignedDate { get; set; }

        public class CustomerVenderDetailsList
        {
            public int ID { get; set; }
            public int ParentDebtorID { get; set; }
            public string FirmName { get; set; }

        }
        public SysRolesLst sysrole { get; set; }
    }

    public class MtblRouteMapping
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RouteID { get; set; }
        public string AssignedDate { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public int ModifiedByID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }

    public class MtblRouteMappingDetail
    {
        public int ID { get; set; }
        public int RouteID { get; set; }
        public int UserID { get; set; }
        public int CustID { get; set; }
        public string AssignedDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public int CreatedByID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int ModifiedByID { get; set; }
    }

    public class DebtorsDetailsList
    {
        public string ID { get; set; }
        public String DebtorName { get; set; }
    }
    public class UserDetailsList
    {
        public int UserID { get; set; }
        public string Username { get; set; }
    }
    public class CustomerVendorDetails
    {
        public int ID { get; set; }
        public int ParentDebtorID { get; set; }
        public string FirmName { get; set; }
        public string MobileNumber { get; set; }
        public string BillingArea { get; set; }
        public string City { get; set; }
        public bool IsChecked { get; set; }
    }
    public class SysRolesLst
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int? UnderRole { get; set; }
    }
    public class DLRouteMapping
    {
        public MWBTCustomerAppEntities Entities = new Entity.MWBTCustomerAppEntities();
        public List<UserDetailsList> userDetailsList = new List<UserDetailsList>();
        public List<DebtorsDetailsList> debtorsDetailsList = new List<DebtorsDetailsList>();
        public List<CustomerVendorDetails> customerVenderDetailsList = new List<CustomerVendorDetails>();
        public List<UserDetailsList> GetSalesManList(string name, string OrgID)
        {
            try
            {
                using (Entities = new MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    var sysRoleId = (from sysRole in Entities.tblSysRoles
                                     where sysRole.RoleName == name
                                     //&& sysRole.OrgID == OrgID
                                     select sysRole.RoleID).FirstOrDefault();


                    userDetailsList = (from sysUser in Entities.tblSysUsers
                                       where sysUser.RoleID == sysRoleId
                                       && sysUser.OrgID == OrgID
                                       select new UserDetailsList
                                       {
                                           UserID = sysUser.UserID,
                                           Username = sysUser.FName,
                                       }).ToList();
                }
                return userDetailsList;
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
        public List<DebtorsDetailsList> GetRouteList()
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();
                    debtorsDetailsList = (from dbtrDts in Entities.tblDebtorsDetails.AsNoTracking()
                                          select new DebtorsDetailsList
                                          {
                                              DebtorName = dbtrDts.DebtorName,
                                              ID = dbtrDts.ID.ToString(),
                                          }).ToList();
                }
                return debtorsDetailsList;
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
        public List<CustomerVendorDetails> GetCustomerVenderList1(RouteMapping objectlist)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    customerVenderDetailsList = (from DbtDts in Entities.tblDebtorsDetails
                                                 join
                                                 ctmrVdrDts in Entities.tblCustomerVendorDetails on DbtDts.ID equals
                        ctmrVdrDts.ParentDebtorID
                                                 where ctmrVdrDts.ParentDebtorID == objectlist.ID

                                                 select new CustomerVendorDetails
                                                 {
                                                     FirmName = ctmrVdrDts.FirmName,

                                                     ID = ctmrVdrDts.ID,
                                                 }).ToList();
                }
                return customerVenderDetailsList;
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
        public List<CustomerVendorDetails> GetCustomerVenderList(int objectlist)
        {
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    customerVenderDetailsList = (from DbtDts in Entities.tblDebtorsDetails join
                                                 ctmrVdrDts in Entities.tblCustomerVendorDetails on DbtDts.ID equals ctmrVdrDts.ParentDebtorID
                                                 where ctmrVdrDts.ParentDebtorID == objectlist
                                                 select new CustomerVendorDetails
                                                 {
                                                     FirmName = ctmrVdrDts.FirmName,
                                                     ID = Convert.ToInt32(ctmrVdrDts.CustID),
                                                 }).ToList();
                }
                return customerVenderDetailsList;
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                throw;
            }
        }
    }
}
