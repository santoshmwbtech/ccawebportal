using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Entity;
using System.Configuration;


namespace WBT.DLCustomerCreation
{
    public class ImportExport
    {

    }
    public class DLImportExport
    {
        MWBTCustomerAppEntities Entities = new WBT.Entity.MWBTCustomerAppEntities();
        public List<DLUserCreation> lstAddUserCreation = new List<DLUserCreation>();
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MWBTCustomerAppEntities"].ConnectionString);

        //OleDbConnection Econ;
        public List<DLUserCreation> GetData()
        {
            lstAddUserCreation = new List<DLUserCreation>();
            try
            {
                using (Entities = new WBT.Entity.MWBTCustomerAppEntities())
                {
                    if (Entities.Database.Connection.State == System.Data.ConnectionState.Closed)
                        Entities.Database.Connection.Open();

                    //#region new aug 19th 2020 by sneha
                    lstAddUserCreation = (from drow in Entities.tblSysUsers.AsNoTracking()
                                              //orderby drow.FName
                                          select new DLUserCreation()
                                          {
                                              UserID = drow.UserID,
                                              OrgID = drow.OrgID,
                                              BranchID = drow.BranchID,
                                              FName = drow.FName.Trim(),
                                              Alias = drow.Alias.Trim(),
                                              WarehouseID = drow.WarehouseID,
                                              Email = drow.Email.Trim(),
                                              Mobile = drow.Mobile.Trim(),
                                              Address = drow.Address.Trim(),
                                              Username = drow.Username.Trim(),
                                              Password = drow.Password,
                                              RoleID = drow.RoleID,
                                              // QuestionID = drow.QuestionID ,
                                              Answer = drow.Answer,
                                              // CanAddDiscount = drow.CanAddDiscount,
                                              IsActive = drow.IsActive.Value,
                                              OldPassword = drow.OldPassword,
                                              UpdatedBy = drow.UpdatedBy,
                                              UpdatedDatetime = drow.UpdatedDatetime,
                                              // ModifiedByID = drow.ModifiedByID,
                                              //SourceOfUpdate = drow.SourceOfUpdate,
                                              //DeviceId = drow.DeviceId,
                                              //  DiscountPercentage = drow.DiscountPercentage,
                                              //  DiscountValue = drow.DiscountValue,
                                              IsThresholdQtyAllowed = drow.IsThresholdQtyAllowed.Value,
                                              State = drow.State,
                                              City = drow.City,
                                              PinCode = drow.PinCode,
                                              PanNumber = drow.PanNumber,
                                              AdharNumber = drow.AdharNumber,
                                          }).OrderByDescending(i => i.UserID).ToList();
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
    }
}
