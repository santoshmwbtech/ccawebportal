using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBT.Common;
using WBT.Entity;

namespace WBT.DLCustomerCreation
{
    public class ChangePassword
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ModifiedByID { get; set; }
        public string ReturnMessage { get; set; }
    }

    public class DLChangePassword
    {
        public ChangePassword UpdatePassword(ChangePassword changePassword)
        {
            try
            {
                ChangePassword returnObject = new ChangePassword();
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    var IsValueExists = dbContext.tblSysUsers.AsNoTracking().Where(p => p.UserID == changePassword.UserID).FirstOrDefault();

                    if (IsValueExists != null)
                    {
                        tblSysUser obj = new tblSysUser();
                        obj.UserID = changePassword.UserID;
                        obj.FName = IsValueExists.FName;
                        //obj.Password = Helper.Encrypt(changePassword.ConfirmPassword, "sblw-3hn8-sqoy19");
                        obj.Password = Helper.Encrypt(changePassword.ConfirmPassword);
                        dbContext.tblSysUsers.Attach(obj);
                        dbContext.Entry(obj).Property(x => x.Password).IsModified = true;
                        dbContext.SaveChanges();
                        returnObject.ReturnMessage = "Success";
                    }
                    else
                    {
                        returnObject.ReturnMessage = "User does not exist";
                    }
                    return returnObject;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                ChangePassword returnObject = new ChangePassword();
                returnObject.ReturnMessage = "Error!! Please try again later";
                return returnObject;
            }
        }

        public int ValidatePassword(string oldPassword, int UserID)
        {
            try
            {
                using (MWBTCustomerAppEntities dbcontext = new MWBTCustomerAppEntities())
                {
                    using (var dbcxtransaction = dbcontext.Database.BeginTransaction())
                    {
                        oldPassword = Helper.Encrypt(oldPassword);

                        var IsValueexists = dbcontext.tblSysUsers.Where(u => u.UserID == UserID && u.Password == oldPassword).FirstOrDefault();

                        if (IsValueexists != null)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string UpdateProfile(DLUserCreation userCreation)
        {
            string Result = string.Empty;
            try
            {
                ChangePassword returnObject = new ChangePassword();
                using (MWBTCustomerAppEntities dbContext = new MWBTCustomerAppEntities())
                {
                    var IsValueExists = dbContext.tblSysUsers.AsNoTracking().Where(p => p.UserID == userCreation.UserID).FirstOrDefault();                    

                    if (IsValueExists != null)
                    {
                        tblSysUser user = new tblSysUser();
                        user.UserID = userCreation.UserID;
                        user.FName = userCreation.FName;
                        user.Email = userCreation.Email;
                        user.Mobile = userCreation.Mobile;
                        user.Password = IsValueExists.Password;
                        dbContext.tblSysUsers.Attach(user);
                        dbContext.Entry(user).Property(x => x.FName).IsModified = true;
                        dbContext.Entry(user).Property(x => x.Email).IsModified = true;
                        dbContext.Entry(user).Property(x => x.Mobile).IsModified = true;
                        dbContext.SaveChanges();
                        Result = "Your profile updated successfully!!";
                    }
                    else
                    {
                        Result = "User does not exist";
                    }
                    return Result;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex.Message, ex.Source, ex.InnerException, ex.StackTrace);
                ChangePassword returnObject = new ChangePassword();
                Result = "Error!! Please try again later";
                return Result;
            }
        }
    }
}
