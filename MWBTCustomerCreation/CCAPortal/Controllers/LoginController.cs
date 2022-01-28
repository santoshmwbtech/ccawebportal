using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WBT.Common;
using WBT.DLCustomerCreation;
using WBT.Entity;

namespace CCAPortal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            WBT.DLCustomerCreation.CustomerCreations customerCreation = new WBT.DLCustomerCreation.CustomerCreations();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(Login login)
        {
            string ResultMsg = string.Empty;
            try
            {
                login.Password = Helper.Encrypt(login.Password);
                WBT.DLCustomerCreation.CustomerCreations customerCreation = new WBT.DLCustomerCreation.CustomerCreations();
                UserLogin User = customerCreation.Login(login);
                if (User != null)
                {
                    Session["UserID"] = User.UserId;
                    Session["OrgID"] = User.OrgID;
                    Session["UserName"] = User.FName;

                    DLGetRoleCreation dlRole = new DLGetRoleCreation();
                    var role = dlRole.GetDeatil(User.RoleID);

                    Session["RoleName"] = role.RoleName;
                    FormsAuthentication.SetAuthCookie(User.UserId.ToString(), login.RememberMe);

                    DLAccessControl dL = new DLAccessControl();
                    List<AccessControlItem> MenuList = dL.LoadAccessControlItems(User.RoleID);
                    Session["MenuMaster"] = MenuList;

                    if(User.IsTallyUsing == true && User.IsServiceInstalled == false)
                    {
                        ResultMsg = "Login Success!! Please install the tally service and configure to continue..";
                        var Result = new
                        {
                            resultmsg = ResultMsg,
                            success = true,
                            IsTallyUsing = User.IsTallyUsing,
                            IsServiceInstalled = User.IsServiceInstalled
                        };
                        return Json(Result);
                    }
                    else
                    {
                        ResultMsg = "Login Success!! Please wait..";
                        var Result = new
                        {
                            resultmsg = ResultMsg,
                            success = true,
                            IsTallyUsing = User.IsTallyUsing,
                            IsServiceInstalled = User.IsServiceInstalled
                        };
                        return Json(Result);
                    }
                }
                else
                {
                    ResultMsg = "Invalid Credentials";
                    var Result = new
                    {
                        resultmsg = ResultMsg,
                        success = false,
                        IsTallyUsing = false
                    };
                    return Json(Result);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ResultMsg = "Error!! Please try again later";
                var Result = new
                {
                    resultmsg = ResultMsg,
                    success = false,
                    IsTallyUsing = false
                };
                return Json(Result);
            }
        }
        public FileResult DownloadFile()
        {
            string FilePath = Server.MapPath(ConfigurationManager.AppSettings["ExeFileName"].ToString());
            System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
            byte[] bytes = System.IO.File.ReadAllBytes(FilePath);
            return File(bytes, "application/octet-stream", file.Name);
        }
    }
}